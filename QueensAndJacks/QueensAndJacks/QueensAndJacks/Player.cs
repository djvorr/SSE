using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Player : Seat
    {
        public Hand hand { get; set; }

        /// <summary>
        /// Return the player's hand.
        /// </summary>
        /// <returns></returns>
        public Hand getHand()
        {
            return hand;
        }

        /// <summary>
        /// Removes the card from the player's hand.
        /// </summary>
        /// <param name="card"></param>
        public void pickAccepted(Card card)
        {
            hand.removeCard(card);
        }

        /// <summary>
        /// Returns the player's card pick.
        /// </summary>
        /// <returns></returns>
        public Card pickCard()
        {
            throw new System.NotImplementedException();
        }

        public Card pickCard(Board b)
        {
            //b.Show();

            while(!b.picked)
            {
                System.Threading.Thread.Sleep(500);
            }

            return b.getPickedCard();
        }
    }
}