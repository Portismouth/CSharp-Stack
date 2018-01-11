using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        string [] stringVals = new string []{"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string [] suits = new string []{"Clubs", "Diamonds", "Hearts", "Spades"};
        public Deck()
        {
            foreach (string suit in suits)
            {
                int num = 1;
                foreach (string stringVal in stringVals)
                {
                    Card card = new Card(stringVal, suit, num);
                    this.cards.Add(card);
                    num++; 
                }
            }
        }
        public void readDeck()
        {
            foreach (Card card in this.cards)
            {
                System.Console.WriteLine("{0} of {1}", card.stringVal, card.suit);
            }
        }
        public Card deal()
        {
            Card dealtCard = cards[0];
            cards.Remove(dealtCard);
            return dealtCard;
        }
        public void reset()
        {
            this.cards = new List<Card>();
            foreach (string suit in suits)
            {
                int num = 1;
                foreach (string stringVal in stringVals)
                {
                    Card card = new Card(stringVal, suit, num);
                    this.cards.Add(card);
                    num++;
                }
            }
        }
        public void shuffle()
        {
            Random rand = new Random();
            for (int idx = 0; idx < this.cards.Count; idx++)
            {
                int newIdx = rand.Next(this.cards.Count);
                Card temp = cards[idx];
                cards[idx] = cards[newIdx];
                cards[newIdx] = temp;
            }
        }
    }
}