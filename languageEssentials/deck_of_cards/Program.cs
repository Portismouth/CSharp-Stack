using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Ozzy = new Player("Ozzy");
            Deck deck1 = new Deck();
            deck1.shuffle();
            Ozzy.draw(deck1);
            Ozzy.draw(deck1, 5);
            Ozzy.read();
            Ozzy.discard(5);
            Ozzy.read();
            Ozzy.discard(5);
            Ozzy.read();
        }
    }
}
