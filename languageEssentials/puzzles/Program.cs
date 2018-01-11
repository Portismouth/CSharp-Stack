using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        
        public static void randomArray()
        {
            Random rnd = new Random();
            int sum = 0;
            int [] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(5, 25);
                Console.WriteLine(arr[i]);
                sum += arr[i];
            }
            Console.WriteLine("The sum is {0}", sum);
            int min = arr[0];
            int max = arr[0];
            foreach (var num in arr)
            {
                if (num < min)
                {
                    min = num;
                }
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
        static void coinFlip()
        {
            Console.WriteLine("Tossing a coin...");
            Random rnd = new Random();
            int side = rnd.Next(2);
            Console.WriteLine(side);
            if (side == 0)
            {
                Console.WriteLine("Heads");
            }
            else
            {
                Console.WriteLine("Tails");
            }
        }
        static void multiFlip(int flips)
        {
            Random rnd = new Random();
            int headCount = 0;
            int totalCount = 0;
            while (flips > 0)
            {
                int side = rnd.Next(2);
                totalCount += 1;
                if (side == 0)
                {
                    headCount += 1;
                    Console.WriteLine("Heads");
                }
                else
                {
                    Console.WriteLine("Tails");
                }
                flips -= 1;
            }
            float ratio = (float)headCount/(float)totalCount;
            Console.WriteLine($"Heads:Total ratio is {ratio}");
        }
        static void shuffleNames(string [] arr)
        {
            foreach (var val in arr)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("=========");
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int newIdx = rnd.Next(arr.Length);
                string temp = arr[i];
                arr[i] = arr[newIdx];
                arr[newIdx] = temp;
            }
            foreach (var val in arr)
            {
                Console.WriteLine(val);
            }
        }
        static void longerThan5(string[] arr)
        {
            foreach (string name in arr)
            {
                if (name.Length > 5)
                {
                    Console.WriteLine(name);
                }
            }
        }
        static void Main(string[] args)
        {
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            multiFlip(10);
        }
    }
}
