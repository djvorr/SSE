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
   
        /// <summary>
        /// Creates a new card with provided suit and face.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="face"></param>
        public Card(char suit, string face)
        {
            this.suit = suit;
            this.face = face;
        }

        /// <summary>
        /// Returns the face of the card.
        /// </summary>
        /// <returns></returns>
        public string getFace()
        {
            return face;
        }

        /// <summary>
        /// Compares the card to another card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Returns -1 if smaller than card, 0 if equal to card, and 1 if greater than card. Takes into account trump suit 'S'</returns>
        public int compare(Card card)
        {
            if (suit.Equals('S') && !card.suit.Equals('S'))
                return 1;
            else if (!suit.Equals('S') && card.suit.Equals('S'))
                return -1;
            else
            {
                try
                {
                    return indexOf(face) - indexOf(card.face);
                }
                catch(Exception e)
                {
                    throw new Exception("Index Error");
                }
            }
        }

        /// <summary>
        /// Returns the suit of the card.
        /// </summary>
        /// <returns></returns>
        public char getSuit()
        {
            return suit;
        }

        /// <summary>
        /// Returns the item index of the value to use as a numerical weight.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int indexOf(string item)
        {

            for (int i = 0; i < vals.Length; i++)
            {
                try
                {
                    if (vals[i].Equals(item))
                        return i;
                }
                catch (Exception e)
                { break; }
            }

            return -1;

        }

        public string getPlain()
        {
            return getSuit().ToString() + getFace().ToString();
        }
    }
}