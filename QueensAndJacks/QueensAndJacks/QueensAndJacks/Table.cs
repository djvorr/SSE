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
        private List<Seat> turnOrder;
        public List<Card> field;

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


        public void updateField(Card card)
        {

        }

        /// <summary>
        /// Returns the player who just went.
        /// </summary>
        /// <returns></returns>
        public Seat getLast()
        {
            if (turn <= 0)
                return turnOrder[3];
            else
                return turnOrder[turn - 1];
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
    }
}