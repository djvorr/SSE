using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class CPU : Seat
    {
        public Hand hand { get; set; }

        /// <summary>
        /// Returns the CPU's hand.
        /// </summary>
        /// <returns></returns>
        public Hand getHand()
        {
            return hand;
        }

        /// <summary>
        /// Removes the card from the CPU's hand.
        /// </summary>
        /// <param name="card"></param>
        public void pickAccepted(Card card)
        {
            hand.removeCard(card);
        }

        /// <summary>
        /// Picks a card from the CPU's hand.
        /// </summary>
        /// <returns>Returns the first card.</returns>
        public Card pickCard()
        {
            return hand.getCards()[0];
        }

        /// <summary>
        /// Picks a card from the CPU's hand. Picks based on ability to beat specified card, then trump, then suit.
        /// </summary>
        /// <param name="highest"></param>
        /// <returns>Returns an acceptable card from the CPU's hand.</returns>
        public Card pickCard(Card highest)
        {
            foreach (Card c in hand.getCards())
            {
                if (c.getSuit() == highest.getSuit())
                {
                    if (c.compare(highest) > 0)
                        return c;
                }
            }

            foreach (Card c in hand.getCards())
            {
                if (c.compare(highest) > 0)
                    return c;
            }

            foreach (Card c in hand.getCards())
            {
                if (c.getSuit() == highest.getSuit())
                    return c;
            }

            return hand.getCards()[0];
        }

    }
}