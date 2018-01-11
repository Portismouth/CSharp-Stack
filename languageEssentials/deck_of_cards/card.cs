using System;

namespace deck_of_cards
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string sv, string s, int v)
        {
            stringVal = sv;
            suit = s;
            val = v;
        }
    }
}