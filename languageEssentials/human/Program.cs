using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Ozzy = new Human("Ozzy");
            Console.WriteLine(Ozzy.strength);
            Human Mendel = new Human("Mendel");
            Human Jenny = new Human("Jenny");
            Console.WriteLine(Mendel.strength);
            Mendel.Attack(Ozzy);
            Console.WriteLine(Ozzy.health);
            Ozzy.Attack(5);
        }
    }
}
