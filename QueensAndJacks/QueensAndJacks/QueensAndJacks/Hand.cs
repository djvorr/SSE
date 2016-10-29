using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Hand
    {
        private List<Card> cards;

        /// <summary>
        /// Creates a new Hand instance.
        /// </summary>
        /// <param name="cards"></param>
        public Hand(List<Card> cards)
        {
            this.cards = cards;
        }

        /// <summary>
        /// Returns a list representation of the cards in the hand.
        /// </summary>
        /// <returns>List<Card> of cards</returns>
        public List<Card> getCards()
        {
            return cards;
        }

        /// <summary>
        /// Removes a specified card from the hand.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True if successful, False if not.</returns>
        public bool removeCard(Card card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
                return true;
            }

            return false;
        }

        public bool removeCard(char suit, string face)
        {
            foreach (Card c in cards)
            {
                if (c.getSuit() == suit && c.getFace() == face)
                {
                    cards.Remove(c);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Finds a card in the hand using the face and suit.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="face"></param>
        /// <returns>True if exists, false if not.</returns>
        public bool Find(char suit, string face)
        {
            foreach (Card c in cards)
            {
                if (c.getSuit().Equals(suit) && c.getFace().Equals(face))
                    return true;
            }

            return false;
        }
    }
}