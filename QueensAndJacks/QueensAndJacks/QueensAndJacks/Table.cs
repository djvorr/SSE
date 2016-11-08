using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Table
    {
        private List<Hand> hands;
        public int turn = 0;
        public List<Seat> turnOrder;
        public List<Card> field = new List<Card>();

        private static Table instance = null;
        private static readonly object padlock = new object();

        
        private void Singleton()
        {
        }

        public static Table Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Table();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Sets the order of turns according to position of Seats and starting index.
        /// </summary>
        /// <param name="seats"></param>
        /// <param name="start"></param>
        public void setOrder(List<Seat> seats, int start)
        {
            turnOrder = seats;
            turn = start;
        }

        /// <summary>
        /// Sets the order of turns according to position of Seats. Turn order starts at 0.
        /// </summary>
        /// <param name="seats"></param>
        public void setOrder(List<Seat> seats)
        {
            turnOrder = seats;
        }

        /// <summary>
        /// Returns the player who is next in turn.
        /// </summary>
        /// <returns>Returns Seat according to turn order.</returns>
        public Seat nextTurn()
        {
            if (turnOrder.Count() > 0)
            {
                return turnOrder[turn % 4];
            }

            return null;
        }

        /// <summary>
        /// Gets turn index.
        /// </summary>
        /// <returns></returns>
        public int getTurn()
        {
            return turn;
        }

        /// <summary>
        /// Sets the hands on the table.
        /// </summary>
        /// <param name="hands"></param>
        public void setHands(List<Hand> hands)
        {
            this.hands = hands;
        }

        /// <summary>
        /// Gets hands values.
        /// </summary>
        /// <returns>List<Hands></returns>
        public List<Hand> getHands()
        {
            return hands;
        }


        public void addToField(Card card)
        {
            field.Add(card);
        }

        public void setField(List<Card> cards)
        {
            field = cards;
        }

        public List<Card> getField()
        {
            return field;
        }

        /// <summary>
        /// Returns the player index who just went.
        /// </summary>
        /// <returns></returns>
        public int getLast()
        {
            if (turn <= 0)
                return 3;
            else
                return turn - 1;
        }

        /// <summary>
        /// Returns player whose turn it is. Increments the turn order.
        /// </summary>
        /// <returns></returns>
        public Seat takeTurn()
        {
            Seat player = turnOrder[turn];
            turn = (turn + 1) % 4;
            return player;
        }

        /// <summary>
        /// Returns true when all players have 0 cards. False if any has at least 1 card.
        /// </summary>
        /// <returns></returns>
        public bool noMoreTurns()
        {
            foreach(Seat s in turnOrder)
            {
                if(s.getHand().getCards().Count > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public Card getHighest()
        {
            if (field.Count == 0)
                return null;
            else
            {
                Card max = field[0];
                foreach (Card c in field)
                {
                    if (max.compare(c) < 0)
                        max = c;
                }

                return max;
            }
        }
    }
}