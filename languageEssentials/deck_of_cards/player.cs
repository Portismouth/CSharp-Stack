using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public Player(string n)
        {
            name = n;
        }
        public void read()
        {
            int count = 0;
            foreach (Card card in this.hand)
            {
                count++;
            }
            Console.WriteLine($"You have {count} cards in your hand. They are: ");
            foreach (Card card in this.hand)
            {
                Console.WriteLine($"The {card.stringVal} of {card.suit}");
            }
        }
        public void draw(Deck deck, int draws = 1)
        {
            for (int draw = 1; draw <= draws; draw++)
            {
                this.hand.Add(deck.deal());
            } 
        }
        public void discard(int card)
        {
            if (card < this.hand.Count)
            {
                this.hand.RemoveAt(card - 1);
            }
        }
    }
}