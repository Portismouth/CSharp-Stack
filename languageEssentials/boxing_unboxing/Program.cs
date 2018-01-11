using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> someList = new List<object>();
            someList.Add(7);
            someList.Add(28);
            someList.Add(-1);
            someList.Add(true);
            someList.Add("chair");
            foreach (object value in someList)
            {
                Console.WriteLine(value);
            }
            int sum = 0;
            foreach (object value in someList)
            {
                if (value is int)
                {
                    sum = sum + (int)value; 
                }
            }
            Console.WriteLine(sum);
        }
    }
}
