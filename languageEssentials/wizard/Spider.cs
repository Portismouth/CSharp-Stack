using System;
namespace human 
{
    public class Spider : Enemy
    {
        public Spider(string person) : base(person)
        {
            strength = 8;
            intelligence = 10;
        }
        public void bite(Human target)
        {
            
        }
    }
}