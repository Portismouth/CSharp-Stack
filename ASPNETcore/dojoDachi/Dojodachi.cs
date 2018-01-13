using System;
namespace dojoDachi
{
    public class Dojodachi
    {
        private static Random rand = new Random();
        public string designation { get; set; }
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
        public Dojodachi(string name)
        {
            designation = name;
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }
        public void feed()
        {
            this.meals--;
            this.fullness += rand.Next(5, 11);
        }
        public void play()
        {
            this.energy -= 5;
            this.happiness += rand.Next(5,11);
        }
        public void work()
        {
            this.energy -= 15;
            this.meals += rand.Next(1, 4);
        }
        public void sleep()
        {
            this.energy += 15;
            this.fullness -= 5;
            this.happiness -= 5;
        }
    }

}