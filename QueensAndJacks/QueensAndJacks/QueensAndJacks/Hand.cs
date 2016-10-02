using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Hand
    {
        private List<Card> cards;

        public Hand(List<Card> cards)
        {
            this.cards = cards;
        }

        public List<Card> getCards()
        {
            return cards;
        }

        public bool removeCard(Card card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
                return true;
            }

            return false;
        }

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