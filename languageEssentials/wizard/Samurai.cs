using System;

namespace human
{
    public class Samurai : Human
    {
        public static int count = 0;
        public Samurai(string person) : base(person)
        {
            health = 200;
            count++;
        }
        public void deathBlow(Human target)
        {
            if(target.health < 50)
            {
                target.health = 0;
                Console.WriteLine($"{this.name} struck {target.name} a death blow. {target.name}'s dead.");
            }
            else
            {
                this.Attack(target);
            }
        }
        public void meditate()
        {
            this.health = 200;
        }
        public void howMany()
        {
            Console.WriteLine("Number of samurai is " + count);
        }
    }
}