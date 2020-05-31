using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Stacks
{
    class Program
    {
        private static List<char> LeftBrackets { get; } = new List<char>() { '(', '<', '[', '{' };
        private static List<char> RightBrackets { get; } = new List<char>() { ')', '>', ']', '}' };

        static void Main(string[] args)
        {
            // FILO - first in, last out
            var stack = new MyStack();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            var p = stack.Peek();
            var a = stack.Pop();

            var reversed = StringReverser("ruan");
            var balanced = IsBalanced("(1 + 2)>");
        }

        static string StringReverser (string input)
        {
            var stack = new Stack<char>();

            foreach (var letter in input)
                stack.Push(letter);

            var reversed = new StringBuilder();

            while (stack.Count() != 0)
                reversed.Append(stack.Pop());

            return reversed.ToString();
        }

        static bool IsBalanced(string input)
        {
            var stack = new Stack<char>();

            foreach (var ch in input)
            {
                if (IsLeftBracket(ch)) 
                    stack.Push(ch);

                if (IsRightBracket(ch))
                {
                    if (stack.Count() == 0) return false;

                    var top = stack.Pop();
                    if (!BracketsMatch(top, ch)) return false;
                }
            }

            return stack.Count() == 0;
        }

        static bool IsLeftBracket(char ch) => LeftBrackets.Contains(ch);

        static bool IsRightBracket(char ch) => RightBrackets.Contains(ch);

        static bool BracketsMatch(char left, char right)
        {
            return LeftBrackets.IndexOf(left) == RightBrackets.IndexOf(right);
        }
    }

    public class MyStack
    {
        int[] _items;
        int _size;

        public MyStack()
        {
            _items = new int[10];
        }

        public void Push(int value)
        {
            if(_size == _items.Length)
            {
                var newArray = new int[_items.Length * 2];
                _items.CopyTo(newArray, 0);

                _items = newArray;
            }

            _items[_size++] = value;
        }

        public int Pop()
        {
            if (_size == 0) return 0;

            var value = _items[_size - 1];

            _items[_size - 1] = 0;
            _size--;
            return value;
        }

        public int Peek()
        {
            if (_size == 0) return 0;

            return _items[_size - 1];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}
