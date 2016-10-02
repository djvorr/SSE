using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Deck
    {
        public int deckSize = 24;
        private List<Card> cards = new List<Card>();
        private List<int> priority;
        private char[] suits = {'S', 'H', 'D', 'C'};
        private string[] faces = { "9", "J", "Q", "K", "10", "A" };

        public Deck()
        { }

        public Deck(List<Card> cards)
        {
            this.cards = cards;
        }

        public Deck generateDeck()
        {
            foreach (char c in suits)
            {
                foreach (string s in faces)
                {
                    cards.Add(new Card(c, s));
                }
            }

            return new Deck(cards);
        }

        public List<Hand> draw()
        {
            List<Hand> hands = new List<Hand>();
            List<Card> h1 = new List<Card>();
            List<Card> h2 = new List<Card>();
            List<Card> h3 = new List<Card>();
            List<Card> h4 = new List<Card>();

            for (int i=1; i<=cards.Count(); i++)
            {
                if (i % 4 == 1)
                    h1.Add(cards[i-1]);
                else if (i % 4 == 2)
                    h2.Add(cards[i-1]);
                else if (i % 4 == 3)
                    h3.Add(cards[i-1]);
                else
                    h4.Add(cards[i-1]);
            }

            hands.Add(new Hand(h1));
            hands.Add(new Hand(h2));
            hands.Add(new Hand(h3));
            hands.Add(new Hand(h4));

            return hands;
        }

        public List<Card> getCards()
        {
            return cards;
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