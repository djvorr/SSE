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

        /// <summary>
        /// Creates a deck instance, but does NOT fill it with cards.
        /// </summary>
        public Deck()
        { }

        /// <summary>
        /// Creates a deck based on the provided list of cards.
        /// </summary>
        /// <param name="cards"></param>
        public Deck(List<Card> cards)
        {
            this.cards = cards;
        }

        /// <summary>
        /// Generates an unsorted list of cards and returns it.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Splits the deck into four hands based on position in the deck.
        /// </summary>
        /// <returns>List<Hand> of hands.</returns>
        public List<Hand> draw()
        {
            List<Hand> hands = new List<Hand>();
            List<Card> h1 = new List<Card>();
            List<Card> h2 = new List<Card>();
            List<Card> h3 = new List<Card>();
            List<Card> h4 = new List<Card>();

            for (int i=1; i<=cards.Count(); i++)
            {
                try
                {
                    if (i % 4 == 1)
                        h1.Add(cards[i - 1]);
                    else if (i % 4 == 2)
                        h2.Add(cards[i - 1]);
                    else if (i % 4 == 3)
                        h3.Add(cards[i - 1]);
                    else
                        h4.Add(cards[i - 1]);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            hands.Add(new Hand(h1));
            hands.Add(new Hand(h2));
            hands.Add(new Hand(h3));
            hands.Add(new Hand(h4));

            return hands;
        }

        /// <summary>
        /// Grabs the cards in the hand.
        /// </summary>
        /// <returns>Returns a list of the cards.</returns>
        public List<Card> getCards()
        {
            return cards;
        }

        /// <summary>
        /// Finds a card in the deck using the face and suit.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="face"></param>
        /// <returns>Returns true if found, false if not.</returns>
        public bool Find(char suit, string face)
        {
            foreach (Card c in cards)
            {
                try
                {
                    if (c.getSuit().Equals(suit) && c.getFace().Equals(face))
                        return true;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return false;
        }

        /// <summary>
        /// Shuffles the cards in the deck by randomly removing a card and adding it to the end of the deck.
        /// </summary>
        public void shuffle()
        {
            Random r = new Random();

            int n = cards.Count;
            for (int i = 0; i<1024; i++)
            {
                for (int j=0; j<n; j++)
                {
                    r = new Random(Guid.NewGuid().GetHashCode());
                    Card c = cards[r.Next(n)];
                    cards.Remove(c);
                    cards.Add(c);
                }
            }
        }
    }
}