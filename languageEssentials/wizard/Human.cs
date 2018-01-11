using System;

namespace human
{
    public class Human
    {
        public string name { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }
        // human constructor
        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        // human constructor
        public Human(
            string person, 
            int str, 
            int intel, 
            int dex, 
            int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void Attack(object target)
        {
            if (target is Human)
            {
                Human enemy = target as Human;
                int attack = this.strength * 5;
                enemy.health -= attack;
                Console.WriteLine($"{this.name} attacked {enemy.name} and caused {attack} damage.");
            }
            else 
            {
                Console.WriteLine("You're attacking a rock. You're drunk, please go home.");
            }
        }
        public void displayHealth()
        {
            Console.WriteLine("{0}'s health is {1}", this.name, this.health);
        }
    }
}