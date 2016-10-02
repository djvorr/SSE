using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Table
    {
        private List<Hand> hands;
        private int turn;
        private List<Seat> turnOrder;
        private int field;

        public void setOrder(List<Seat> seats)
        {
            throw new System.NotImplementedException();
        }

        public Seat nextTurn()
        {
            throw new System.NotImplementedException();
        }

        public int getTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}