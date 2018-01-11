using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void print255()
        {
            for (int n = 1; n <= 255; n++)
            {
                System.Console.WriteLine(n);
            }
        }
        static void printOdd255()
        {
            for (int n = 1; n <= 255; n++)
            {
                if (n % 2 != 0)
                {
                    System.Console.WriteLine(n);
                }
            }
        }
        static void printSum()
        {
            int sum = 0;
            for (int n = 0; n <= 255; n++)
            {
                sum += n;
                System.Console.WriteLine("Sum: "+sum);
            }
        }
        public static void iterateArray(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }
        static void findMax(int [] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            System.Console.WriteLine(max);
        }
        static void average(int [] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int avg = sum/arr.Length;
            Console.WriteLine(avg);
        }
        static void oddArray()
        {
            List<int> y = new List<int>();
            for (int n = 1; n <= 255; n++)
            {
                if (n % 2 != 0)
                {
                    y.Add(n);
                }
            }
            System.Console.WriteLine(y.ToArray());
        }
        static void greaterThanY(int[] arr, int y)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static void doseyDo(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= arr[i];
                Console.WriteLine(arr[i]);
            }
        }
        static void zeroNegs(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < (int)0)
                {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
        }
        static void minMaxAvg(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            float avg = (float)sum / (float)arr.Length;
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(String.Format("{0:0.00}", avg));
        }
        static void shiftArray(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i+1];
            }
            arr[arr.Length-1] = 0;
            iterateArray(arr);
        }
        static void numToString(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is int)
                { 
                    if ((int)arr[i] < 0)
                    {
                        arr[i] = "Dojo";
                    }
                }
            }
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            oddArray();
            print255();
            printSum();
        }
    }
}
