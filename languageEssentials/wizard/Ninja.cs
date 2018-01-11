using System;
namespace human
{
    public class Ninja : Human
    {
        public Ninja(string person) : base(person)
        {
            dexterity = 175;
        }
        public void steal(Human target)
        {
            this.Attack(target);
            this.health += 10;
        }
        public void get_away()
        {
            this.health -= 15;
        }
    }
}