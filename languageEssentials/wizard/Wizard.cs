using System;
namespace human 
{
    public class Wizard : Human
    {
        public Wizard(string person) : base(person)
        {
            intelligence = 25;
            health = 50;
        }
        public void heal()
        {
            this.health += 10*this.intelligence;
        }
        public void fireball(Human target)
        {
            Random points = new Random();
            int damage = points.Next(20, 51);
            target.health -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} and caused {damage} damage.");
        }
    }
}