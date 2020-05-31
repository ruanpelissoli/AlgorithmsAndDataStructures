using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hashtables = dictionaries
            // key - value
            // super fast lookup

            // maps: k -> v

            Console.WriteLine(FindFirstNonRepeatedCharacter("a green apple"));

            // sets: k
            // keys cannot repeat
            var set = new HashSet<int>();
            var numbers = new int[] { 1, 2, 3, 3, 2, 1, 4 };
            foreach (var n in numbers)
                set.Add(n);
            Console.WriteLine(string.Join(',', set));

            Console.WriteLine(FindFirstRepeatedCharacter("green apple"));

            // collision = same hash for differente values
            // how to handle? chaining, open addressing
        }


        static char FindFirstNonRepeatedCharacter(string input)
        {
            var dict = new Dictionary<char, int>();

            foreach (var ch in input)
            {
                if (dict.ContainsKey(ch)) dict[ch] += 1;
                else
                    dict.Add(ch, 1);
            }

            return dict.FirstOrDefault(w => w.Value == 1).Key;
        }

        static char FindFirstRepeatedCharacter(string input)
        {
            var set = new HashSet<char>();

            foreach (var ch in input)
            {
                if (set.Contains(ch)) return ch;
                set.Add(ch);
            }

            return char.MinValue;
        }
    }

    class MyHashTable
    {
        class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        LinkedList<Entry>[] Entries { get; set; } = new LinkedList<Entry>[5];

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value; return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);

            return entry?.Value;
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = Hash(key);
            var bucket = Entries[index];
            if (bucket == null)
                Entries[index] = new LinkedList<Entry>();

            return bucket;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null) throw new Exception();

            GetBucket(key).Remove(entry);
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            return Entries[Hash(key)];
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);

            if (bucket != null)
                foreach (var entry in bucket)
                    if (entry.Key == key)
                        return entry;

            return null;
        }

        private int Hash(int key)
        {
            return key % Entries.Length;
        }
    }
}
