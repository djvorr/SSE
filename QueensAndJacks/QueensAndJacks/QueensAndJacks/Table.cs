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

        public void setOrder(List<Seat> seats, int start)
        {
            turnOrder = seats;
            turn = start;
        }

        public void setOrder(List<Seat> seats)
        {
            turnOrder = seats;
        }

        public Seat nextTurn()
        {
            return turnOrder[turn];
        }

        public int getTurn()
        {
            return turn;
        }

        public void setHands(List<Hand> hands)
        {
            this.hands = hands;
        }

        public List<Hand> getHands()
        {
            return hands;
        }
    }
}