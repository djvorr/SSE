using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Game
    {
        private Player player = new Player();
        private CPU cpu1 = new CPU();
        private CPU cpu2 = new CPU();
        private CPU cpu3 = new CPU();
        private Table table = new Table();

        public void deal()
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            setup();

        }

        public void setup()
        {
            Deck deck = new Deck();
            deck = deck.generateDeck();
            List<Hand> hands = deck.draw();

            player.hand = hands[0];
            cpu1.hand = hands[1];
            cpu2.hand = hands[2];
            cpu3.hand = hands[3];

            List<Seat> turns = new List<Seat>();
            turns.Add(player);
            turns.Add(cpu1);
            turns.Add(cpu2);
            turns.Add(cpu3);
            table.setOrder(turns);
        }
    }
}