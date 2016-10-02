using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Card
    {
        private string[] vals = {"9", "J", "Q", "K", "10", "A"};

        private char suit;
        private string face;
   
        public Card(char suit, string face)
        {
            this.suit = suit;
            this.face = face;
        }

        public string getFace()
        {
            return face;
        }

        public int compare(Card card)
        {
            if (suit.Equals('S') && !card.suit.Equals('S'))
                return 1;
            else if (!suit.Equals('S') && card.suit.Equals('S'))
                return -1;
            else
            {
                return indexOf(face) - indexOf(card.face);
            }
        }

        public char getSuit()
        {
            return suit;
        }

        private int indexOf(string item)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i].Equals(item))
                    return i;
            }

            return -1;
        }
    }
}