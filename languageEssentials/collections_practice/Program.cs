using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // three basic arrays
            int [] numArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string [] names = {"Tim", "Martin", "Nikki", "Sara"};
            Boolean [] boolArray2 = new bool[10];
            for (int idx = 0; idx < boolArray2.Length; idx++)
            {
                if ( idx % 2 == 0)
                {
                    boolArray2[idx] = true;
                }
                else 
                {
                    boolArray2[idx] = false;
                }
            }
            // foreach (Boolean value in boolArray2)
            // {
            //     Console.WriteLine(value);
            // }
            // multi-dimensional arrays built manually 
            int [,] multTableArr = new int[10, 10]
            {
                { 1,2,3,4,5,6,7,8,9,10 },
                { 2,4,6,8,10,12,14,16,18,20 },
                { 3,6,9,12,15,18,21,24,27,30 },
                { 4,8,12,16,20,24,28,32,36,40 },
                { 5,10,15,20,25,30,35,40,45,50 },
                { 6,12,18,24,30,36,42,48,54,60 },
                { 7,14,21,28,35,42,49,56,63,70 },
                { 8,16,24,32,40,48,56,64,72,80 },
                { 9,18,27,36,45,54,63,72,81,90 },
                { 10,20,30,40,50,60,70,80,90,100 },
            };
            // build it with loops
            const int extent = 10; //or 100, or 1000 or ...
            int[,] multiplicationTable = new int[extent, extent];
            for (int x = 1; x < extent + 1; x++)
                for (int y = 1; y < extent + 1; y++)
                    multiplicationTable[x - 1, y - 1] = x * y;
            // list of three flavors
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Vanilla");
            // output length
            // Console.WriteLine(flavors.Count);
            // Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            // Console.WriteLine(flavors.Count);
            flavors.Add("Vanilla");
            for(int i = 0; i < flavors.Count; i++)
            {
                // Console.WriteLine(flavors[i]);
            }
            // create new dict
            Dictionary<string,string> iceCream = new Dictionary<string,string>();
            // assigns each flavor in previous list as key 
            foreach (string name in names)
            {
                iceCream.Add(name, null);
            }
            // instatiating random
            Random rnd = new Random();
            // assigning each name a random flavor
            foreach (string name in names)
            {
                iceCream[name] = flavors[rnd.Next(flavors.Count)];
            }
            // output key/value pairs
            foreach (KeyValuePair<string,string> name in iceCream)
            {
                Console.WriteLine(name.Key + "'s fav flavor is " + name.Value);    
            }
        }
    }
}
