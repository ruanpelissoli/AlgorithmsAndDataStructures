using System;

namespace BigO
{
    class Program
    {
        static void Main(int[] numbers, string[] names)
        {
            //Big O is used to described performance of an algorithm
            //scales well with a very large input?

            ////////////////////
            // O(1) - size of input does not matter, constant time
            // CONSTANT
            Console.WriteLine(numbers); // O(1)

            ////////////////////
            // O(n) - input size matters, cost growns linearly in relation with the size of input
            // n = size of input
            // LINEAR
            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(numbers[i]);

            // O(1 + n + 1) = O(2 + n) = O(n)
            // O(1) dont impact
            Console.WriteLine(numbers); // O(1)
            for (int i = 0; i < numbers.Length; i++) // O(n)
                Console.WriteLine(numbers[i]);
            Console.WriteLine(numbers); // O(1)


            // O(n + n) = O(2n) = O(n)
            // still linear
            for (int i = 0; i < numbers.Length; i++) // O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < numbers.Length; i++) // O(n)
                Console.WriteLine(numbers[i]);

            // O(n + m) = O(n)
            // still linear
            for (int i = 0; i < numbers.Length; i++) // O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < names.Length; i++) // O(m)
                Console.WriteLine(numbers[i]);

            ////////////////////
            // O(n^2) - nested loops (n squared)
            // runs in quadract time
            // QUADRATIC
            for (int i = 0; i < numbers.Length; i++) // O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    Console.WriteLine(numbers[i]);

            // O(n + n^2) = O(n^2)
            // n^2 grows way faster than n
            for (int i = 0; i < names.Length; i++) // O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < numbers.Length; i++) // O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    Console.WriteLine(numbers[i]);

            // O(n + n^3) = O(n^3) (n cubed)
            // far slower than n^2
            for (int i = 0; i < numbers.Length; i++) // O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    for (int k = 0; k < numbers.Length; k++) // O(n)
                        Console.WriteLine(numbers[i]);

            ////////////////////
            // O(log n)
            // log = logarithmic
            // LOGARITHMIC
            // grows in same rate as linear, but slows down at some point
            // more efficient and more scalable than linear and quadratic
            // Binary Search - Look for the middle item in an array, is this item lower or higher than the item we are looking for? 
            // { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } We are looking for number 10
            // if we divid this array, we know we can look only in the right side of the array, 'cause 10 > 5
            // { 6, 7, 8, 9, 10 }
            // again we divide, 10 is higher than 8, so again we look only in the right side of the array, 'cause 10 > 8
            // Example, 1M items array / 19 comparisons (instead of searching for all 1M items like in linear way)

            ////////////////////
            // O(2^n)
            // EXPONENTIAL - opposite of logarithmic
            // slows down as input size growth
        }
    }
}
