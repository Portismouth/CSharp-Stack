using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai Ozzy = new Samurai("Ozzy");
            Samurai Jeannie = new Samurai("Ozzy");
            Human Mendel = new Human("Mendel");
            Human Jenny = new Human("Jenny");
            Mendel.Attack(Ozzy);
            Mendel.Attack(Ozzy);
            Mendel.Attack(Ozzy);
            Console.WriteLine(Ozzy.health);
            Ozzy.deathBlow(Mendel);
            Ozzy.displayHealth();
            Mendel.displayHealth();
            Ozzy.meditate();
            Ozzy.displayHealth();
            Ozzy.howMany();
            Human Priti = new Human("Priti");
            Wizard Priti = new Wizard("Priti");
        }
    }
}
