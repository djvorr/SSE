using System;
using QueensAndJacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unit_Test_Suite_1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestDeckShuffle()
        {
            Deck d1 = new Deck();
            d1 = d1.generateDeck();
            List<Card> ld1 = d1.getCards();
            
            Deck d2 = new Deck();
            d2 = d2.generateDeck();
            List<Card> ld2 = d2.getCards();
            
            //Assert.AreEqual(new Card('C', "A").compare(ld1[23]), 0, "Bust");

            Assert.AreEqual(ld1[0].compare(ld2[0]), 0, "First index not euqal.");
            Assert.AreEqual(ld1[5].compare(ld2[5]), 0, "Fifth index not euqal.");
            Assert.AreEqual(ld1[11].compare(ld2[11]), 0, "Eleventh index not euqal.");
            Assert.AreEqual(ld1[17].compare(ld2[17]), 0, "Seventeenth index not euqal.");
            Assert.AreEqual(ld1[23].compare(ld2[23]), 0, "Twenty-third index not euqal.");

            /*
            d1.shuffle();
            ld2 = d1.getCards();

            Assert.AreNotEqual(ld1[0].compare(ld2[0]), 0, "First index euqal.");
            Assert.AreNotEqual(ld1[5].compare(ld2[5]), 0, "Fifth index euqal.");
            Assert.AreNotEqual(ld1[11].compare(ld2[11]), 0, "Eleventh index euqal.");
            Assert.AreNotEqual(ld1[17].compare(ld2[17]), 0, "Seventeenth index euqal.");
            Assert.AreNotEqual(ld1[23].compare(ld2[23]), 0, "Twenty-third index euqal.");
            */

            d2.shuffle();
            ld2 = d2.getCards();

            int n = ld1.Count;
            int sum = 0;
            int acceptability = 15;
            for (int i=0; i<n; i++)
            {
                if (ld1[i].compare(ld2[i]) != 0)
                    sum += 1;
            }

            Assert.IsTrue(sum >= acceptability, "Shuffled places below acceptability.");
        }

        [TestMethod]
        public void TestCPUPick()
        {
            List<Card> cards = new List<Card>();
            Card c = new Card('H', "10");
            cards.Add(c);
            Card c1 = new Card('C', "K");
            cards.Add(c1);
            Card c2 = new Card('D', "K");
            cards.Add(c2);
            Card c3 = new Card('S', "9");
            cards.Add(c3);

            Hand hand = new Hand(cards);
            CPU cpu = new CPU();
            cpu.hand = hand;

            Assert.AreEqual(cpu.pickCard().compare(c), 0, "Pick() not default to index 0.");

            Assert.AreEqual(cpu.pickCard(new Card('H', "9")), c, "Pick(higher) not correct for H9.");
            Assert.AreEqual(cpu.pickCard(new Card('C', "J")), c1, "Pick(higher) not correct for CJ.");
            Assert.AreEqual(cpu.pickCard(new Card('S', "K")), c3, "Pick(higher) not correct for SK.");
            Assert.AreEqual(cpu.pickCard(new Card('C', "A")), c3, "Pick(higher) not correct for CA.");

            cpu.hand.removeCard(c3);
            cpu.hand.removeCard(c2);

            Assert.AreEqual(cpu.pickCard(new Card('D', "9")), c, "Pick(higher) not correct for D9.");
        }

        [TestMethod]
        public void TestTableMore()
        {
            List<Seat> seats = new List<Seat>();
            Table table = new Table();

            table.turn = 0;
            seats.Clear();

            List<Card> cards = new List<Card>();

            Hand hand = new Hand(cards);
            Player p = new Player();
            p.hand = hand;
            CPU cpu1 = new CPU();
            cpu1.hand = hand;
            CPU cpu2 = new CPU();
            cpu2.hand = hand;
            CPU cpu3 = new CPU();
            cpu3.hand = hand;

            seats.Add(p);
            seats.Add(cpu1);
            seats.Add(cpu2);
            seats.Add(cpu3);
            table.setOrder(seats);

            Seat s = table.takeTurn();
            Assert.AreEqual(table.turn, 1, "TakeTurn not working for turn = 1.");
            Assert.AreEqual(s.GetType(), typeof(Player), "TakeTurn not working for turn = 1 type.");
            Assert.AreEqual(s.GetType(), table.getLast().GetType(), "GetLast not equal for turn = 1.");

            table.turn = 3;
 
            s = table.takeTurn();
            Assert.AreEqual(table.turn, 0, "TakeTurn not working for turn = 0.");
            Assert.AreEqual(s.GetType(), typeof(CPU), "TakeTurn not working for turn = 0 type.");
            Assert.AreEqual(s.GetType(), table.getLast().GetType(), "GetLast not equal for turn = 0.");

            s = table.takeTurn();
            Assert.AreEqual(table.turn, 1, "TakeTurn not working for turn = 1.2.");
            Assert.AreEqual(s.GetType(), typeof(Player), "TakeTurn not working for turn = 1.2 type.");
            Assert.AreEqual(s.GetType(), table.getLast().GetType(), "GetLast not equal for turn = 1.2.");

            Assert.IsTrue(table.noMoreTurns(), "Detected at least one card.");
        }

        [TestMethod]
        public void TestGame()
        {
            Game game = new Game();

            game.deal();
            game.seatPlayers();

            Table table = game.getTable();

            Seat s = table.takeTurn();
            Assert.AreEqual(s.GetType(), typeof(Player), "Player not loaded into seat.");
            Assert.IsTrue(s.hand.getCards().Count > 1, "Player cards not loaded.");
            Assert.IsFalse(table.noMoreTurns(), "Detected no more turns.");

            s = table.takeTurn();
            Assert.AreEqual(s.GetType(), typeof(CPU), "CPU not loaded into seat.");
            Assert.IsTrue(s.hand.getCards().Count > 1, "CPU cards not loaded.");
        }

        [TestMethod]
        public void TestDrawHand()
        {
            List<Card> cards = new List<Card>();
            Card c = new Card('H', "10");
            cards.Add(c);
            Card c1 = new Card('C', "K");
            cards.Add(c1);
            Card c2 = new Card('D', "K");
            cards.Add(c2);
            Card c3 = new Card('S', "9");
            cards.Add(c3);

            Hand hand = new Hand(cards);
            Board board = new Board();
            board.clearButtons();
            board.drawHand(hand);
            
            List<Button> buttons = board.getHand();

            Assert.IsTrue(buttons[0].Text.Length > 0, "Button 0 card not loaded.");
            Assert.IsTrue(buttons[1].Text.Length > 0, "Button 1 card not loaded.");
            Assert.IsTrue(buttons[2].Text.Length > 0, "Button 2 card not loaded.");
            Assert.IsTrue(buttons[3].Text.Length > 0, "Button 3 card not loaded.");
            Assert.IsTrue(buttons[4].Text.Length == 0, "Button 4 card loaded.");
            Assert.IsTrue(buttons[5].Text.Length == 0, "Button 5 card loaded.");

            cards.Add(c3);
            cards.Add(c3);

            hand = new Hand(cards);
            board.drawHand(hand);
            buttons = board.getHand();

            Assert.IsTrue(buttons[5].Text.Length > 0, "Button 5 card not loaded.");

            cards.Clear();

            hand = new Hand(cards);
            board.drawHand(hand);
            buttons = board.getHand();

            Assert.IsTrue(buttons[0].Text.Length == 0, "Button 0 wrongly loaded.");
            Assert.IsTrue(buttons[5].Text.Length == 0, "Button 5 wrongly loaded.");
            
        }
    }
}
