using System;

namespace human
{
    public class Enemy
    {
        public string name { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }
        public Enemy(string person)
        {
            name = person;
            strength = 10;
            intelligence = 5;
            dexterity = 3;
            health = 75;
        }
        public void Attack(object target)
        {
            if (target is Enemy)
            {
                Enemy enemy = target as Enemy;
                int attack = this.strength * 5;
                enemy.health -= attack;
                Console.WriteLine($"{this.name} attacked {enemy.name} and caused {attack} damage.");
            }
            else
            {
                Human enemy = target as Human;
                int attack = this.strength * 3;
                enemy.health -= attack;
                Console.WriteLine("You're attacking another Human. Be careful.");
            }
        }
    }
}