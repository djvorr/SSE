using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public abstract class CPU : Seat
    {
        public abstract Hand hand { get; set; }

        public abstract Hand getHand();
        public abstract void pickAccepted();
        public abstract Card pickCard();
    }
}