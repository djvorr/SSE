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
        Scoreboard scoring = new Scoreboard();

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
            string response;
            do
            {
                List<int> scores = scoring.getScore();
                Console.Write("Player\tCPU 1\tCPU 2\tCPU 3\n");
                Console.Write("------\t-----\t-----\t-----\n");
                foreach (int a in scores)
                {
                    Console.Write(a);
                    Console.Write("\t");
                }
                Console.Write("\n");

                deal();
                seatPlayers();
                gameLoop();
                Console.Write("Play another round?");
                Console.WriteLine();
                response = Console.ReadLine();
            }
            while (response.Equals("yes", StringComparison.InvariantCultureIgnoreCase));
        }

        public void gameLoop()
        {
            int i = 0;
            List<Card> playedCards = new List<Card>();

            while (!table.noMoreTurns())
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
                    playedCards.Add(c);
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
                    playedCards.Add(c);
                }

                i++;

                if (i % 4 == 0)
                {
                    Card high = table.getHighest();
                    int winner = -1;
                    for (int j = 0; j < playedCards.Count(); j++)
                    {
                        if (high == playedCards.ElementAt(j))
                            winner = j;
                    }
                    Console.Write("Winner: " + winner);
                    playedCards.Clear();

                    string str = "";
                    foreach (Card c in table.getField())
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