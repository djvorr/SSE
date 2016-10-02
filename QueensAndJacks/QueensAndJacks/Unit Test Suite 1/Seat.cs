using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public interface Seat
    {
        Hand hand { get; set; }

        Hand getHand();
        Card pickCard();
        void pickAccepted();
    }
}