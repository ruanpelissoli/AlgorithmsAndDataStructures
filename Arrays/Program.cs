using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //fastest way to access by index O(1)
            //bad when need to resize O(n), good when we know the size O(1)

            var myArray = new MyArray<int>(1);

            myArray.Insert(10);
            myArray.Insert(20);
            myArray.Insert(30);
            myArray.Insert(40);

            Console.WriteLine(myArray.IndexOf(20));

            myArray.RemoveAt(2);

            myArray.Print();
            Console.ReadLine();
        }
    }

    class MyArray<T>
    {
        private T[] _items;
        private int _count;


        public MyArray(int size)
        {
            _items = new T[size];
        }

        public void Insert(T item)
        {
            if (_items.Length == _count)
            {
                T[] newItems = new T[_count * 2];

                for (int i = 0; i < _count; i++)
                    newItems[i] = _items[i];

                _items = newItems;
            }

            _items[_count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();

            for (int i = index; i < _count; i++)
            {
                if (i == _items.Length - 1)
                {
                    _items[^1] = default; break;
                }
                _items[i] = _items[i + 1];
            }

            _count--;
        }

        public int IndexOf(T value)
        {
            // O(n)
            for (int i = 0; i < _items.Length; i++)
                if (object.Equals(_items[i], value)) return i;

            return -1;
        }

        public void Print()
        {
            for (int i = 0; i < _count; i++)
                Console.WriteLine(_items[i]);
        }
    }
}
