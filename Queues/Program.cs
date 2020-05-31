using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            // FIFO - first in, first out
            var q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            Reverse(q);

            var aq = new ArrayQueue(10);
            aq.Enqueue(10);
            aq.Enqueue(20);
            aq.Enqueue(30);

            Console.WriteLine(aq.Peek());

            aq.Dequeue();
            Console.WriteLine(aq.Peek());
            aq.Dequeue();
            Console.WriteLine(aq.Peek());
            aq.Dequeue();
        }

        static void Reverse(Queue<int> queue)
        {
            var stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

        }
    }

    class ArrayQueue
    {
        int[] _items;

        int front, rear, count;

        public ArrayQueue(int capacity)
        {
            _items = new int[capacity];
        }

        public void Enqueue(int value)
        {
            if (IsFull()) throw new Exception();

            _items[rear] = value;
            rear = (rear + 1) % _items.Length;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new Exception();

            var item = _items[front];
            _items[front] = 0;
            front = (front + 1) % _items.Length;
            count--;

            return item;
        }

        public int Peek()
        {
            if (IsEmpty()) throw new Exception();
            return _items[front];
        }

        public bool IsEmpty() => front == rear;

        public bool IsFull() => count == _items.Length;
    }

    class StackQueue
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public void Enqueue(int value)
        {
            stack1.Push(value);
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new Exception();
            MoveStack1ToStack2();

            return stack2.Pop();
        }

        private void MoveStack1ToStack2()
        {
            if (stack2.Count == 0)
                while (stack1.Count > 0)
                    stack2.Push(stack1.Pop());
        }

        public int Peek()
        {
            if (IsEmpty()) throw new Exception();
            MoveStack1ToStack2();

            return stack2.Peek();
        }

        public bool IsEmpty() => stack1.Count == 0 && stack2.Count == 0;
    }

    class PriorityQueue
    {
        private int[] Items { get; }
        private int Size { get; set; }

        public PriorityQueue(int capacity)
        {
            Items = new int[capacity];
        }

        public void Enqueue(int value)
        {
            if (Size == Items.Length) throw new Exception();

            var i = ShiftItemsToInsert(value);
            Items[i] = value;
            Size++;
        }

        private int ShiftItemsToInsert(int value)
        {
            int i;
            for (i = Size - 1; i >= 0; i--)
            {
                if (Items[i] > value)
                    Items[i + 1] = Items[i];
                else break;
            }

            return i + 1;
        }

        public int Dequeue()
        {
            if (Size == 0) throw new Exception();

            return Items[--Size];
        }

        public override string ToString()
        {
            return string.Join(", ", Items);
        }
    }
}
