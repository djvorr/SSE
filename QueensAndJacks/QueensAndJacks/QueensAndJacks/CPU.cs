using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class CPU : Seat
    {
        public Hand hand { get; set; }

        public Hand getHand()
        {
            return hand;
        }
        public void pickAccepted()
        {
            throw new System.NotImplementedException();
        }
        public Card pickCard()
        {
            throw new System.NotImplementedException();
        }
    }
}