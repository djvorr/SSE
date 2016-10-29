using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueensAndJacks
{
    public class Game
    {
        private Player player = new Player();
        private CPU cpu1 = new CPU();
        private CPU cpu2 = new CPU();
        private CPU cpu3 = new CPU();
        private Table table = new Table();

        public void main()
        {
            StartGame();
        }

        public void deal()
        {
            Deck deck = new Deck();
            deck = deck.generateDeck();
            deck.shuffle();
            List<Hand> hands = deck.draw();

            player.hand = hands[0];
            cpu1.hand = hands[1];
            cpu2.hand = hands[2];
            cpu3.hand = hands[3];
        }

        public void StartGame()
        {
            deal();
            seatPlayers();
            gameLoop();
        }

        public void gameLoop()
        {
            int i = 0;
            while(!table.noMoreTurns())
            {
                Board b = new Board();

                Seat s = table.takeTurn();
                Player p;
                CPU cpu;
                if (s.GetType() == typeof(Player))
                {
                    b.drawHand(player.hand);
                    b.enableCards();
                    b.ShowDialog();
                    b.disenableCards();

                    p = (Player)s;
                    Card c = p.pickCard(b);
                    //MessageBox.Show(c.getPlain());
                    table.addToField(c);
                    b.drawBoard(table.getField());
                    //b.ShowDialog();
                    Hand h = p.hand;
                    h.removeCard(c.getSuit(), c.getFace());
                    p.pickAccepted(c);
                    table.turnOrder[table.getLast()].hand = h;

                }
                else
                {
                    cpu = (CPU)s;
                    Card c = cpu.pickCard(table.getHighest());
                    //MessageBox.Show(c.getPlain());
                    table.addToField(c);
                    b.drawBoard(table.getField());
                    //b.ShowDialog();
                    //System.Threading.Thread.Sleep(5000);
                    //b.Close();
                    //table.getLast().pickAccepted(c);
                    Hand h = cpu.hand;
                    h.removeCard(c.getSuit(), c.getFace());
                    cpu.pickAccepted(c);
                    table.turnOrder[table.getLast()].hand = h;
                }

                i++;

                if(i % 4 == 0)
                {
                    string str = "";
                    foreach(Card c in table.getField())
                    {
                        str = str + c.getPlain() + " ";
                    }

                    b.clearButtons();
                    b.disenableCards();
                    b.ShowDialog();

                    table.setField(new List<Card>());

                    //MessageBox.Show(str);
                }
            }
        }

        public void seatPlayers()
        {
            List<Seat> turns = new List<Seat>();
            turns.Add(player);
            turns.Add(cpu1);
            turns.Add(cpu2);
            turns.Add(cpu3);
            table.setOrder(turns);
        }

        public Table getTable()
        {
            return table;
        }
    }
}