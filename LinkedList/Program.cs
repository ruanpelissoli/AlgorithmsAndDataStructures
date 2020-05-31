using System;
using System.Collections.Generic;
using System.Data;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // can grow and shrink automatically
            // each node holds 2 pieces a data: value and the address of the next node in the list
            // first node: head. last node: tail
            // lookup by value: O(n), by index: O(n)
            // insert at the end: O(1), at beginning O(1). Just reference the new head or tail
            // in the middle: O(n)
            // delete: beginning O(1). end and middle: O(n)

            var linkedList = new LinkedList<int>();

            var myLinkedList = new MyLinkedList();
            myLinkedList.AddLast(10);
            myLinkedList.AddLast(20);
            myLinkedList.AddLast(30);

            myLinkedList.Reverse();
        }
    }

    public class MyLinkedList
    {
        private class Node
        {
            public int Value;
            public Node Next;

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node _first;
        private Node _last;

        private int _size;

        public void AddFirst(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                node.Next = _first;
                _first = node;
            }

            _size++;
        }

        public void AddLast(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                _last.Next = node;
                _last = node;
            }

            _size++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty()) throw new NoNullAllowedException();

            if (_first == _last)
                _first = _last = null;
            else
            {
                var second = _first.Next;
                _first.Next = null;
                _first = second;
            }

            _size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty()) throw new NoNullAllowedException();

            if (_first == _last)
                _first = _last = null;
            else
            {
                var previous = GetPrevious(_last);
                _last = previous;
                _last.Next = null;
            }

            _size--;
        }

        public int Size() => _size;

        public int[] ToArray()
        {
            var array = new int[_size];
            var current = _first;
            var index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Reverse()
        {
            // [10 -> 20 -> 30]
            // [10 <- 20 <- 30]
            // [30 -> 20 -> 10]

            if (IsEmpty()) return;

            var previous = _first;
            var current = _first.Next;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }

            _last = _first;
            _last.Next = null;
            _first = previous;
        }

        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new ArgumentException();

            var a = _first;
            var b = _first;

            for (int i = 0; i < k - 1; i++)
            {
                b = b.Next;
                if (b == null) throw new ArgumentOutOfRangeException();
            }

            while (b != _last)
            {
                a = a.Next;
                b = b.Next;
            }

            return a.Value;
        }

        private Node GetPrevious(Node node)
        {
            var current = _first;

            while (current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }

            return null;
        }

        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        private int IndexOf(int value)
        {
            int index = 0;
            var current = _first;

            while (current != null)
            {
                if (current.Value == value) return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        private bool IsEmpty() => _first == null;
    }


}
