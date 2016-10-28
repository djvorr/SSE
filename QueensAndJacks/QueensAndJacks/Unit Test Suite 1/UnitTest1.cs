using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueensAndJacks;
using System.Collections.Generic;

namespace Unit_Test_Suite_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCard()
        {
            Card card = new Card('H', "10");

            //Test for getter methods
            Assert.IsTrue(card.getFace() == "10", "Card.GetFace() error");
            Assert.IsTrue(card.getSuit() == 'H', "Card.GetSuit() error");

            //Test for compare for non-trump suits
            Assert.IsTrue(card.compare(new Card('H', "A")) < 0, "Card.Compare incorrect for greater than.");
            Assert.IsTrue(card.compare(new Card('C', "9")) > 0, "Card.Compare incorrect for lesser than.");
            Assert.IsTrue(card.compare(new Card('D', "10")) == 0, "Card.Compare incorrect for equivalent.");
            Assert.IsTrue(card.compare(new Card('H', "K")) > 0, "Card.Compare incorrect for greater than K.");

            //Test for trump suits compared to a non-trump suit
            Assert.IsTrue(card.compare(new Card('S', "10")) < 0, "Card.Compare incorrect for equivalent trump.");
            Assert.IsTrue(card.compare(new Card('S', "9")) < 0, "Card.Compare incorrect for smaller trump.");
            Assert.IsTrue(card.compare(new Card('S', "A")) < 0, "Card.Compare incorrect for greater trump.");
        }

        [TestMethod]
        public void TestHand()
        {
            List<Card> cards = new List<Card>();
            Card c = new Card('H', "10");
            cards.Add(c);
            Card c1 = new Card('A', "9");
            cards.Add(c1);
            Card c2 = new Card('D', "K");
            cards.Add(c2);
            Hand hand = new Hand(cards);

            //Test to make sure all cards made it into the hand.
            Assert.IsTrue(hand.getCards().Contains(c), "Hand.GetCards.Contains failed for first card.");
            Assert.IsTrue(hand.getCards().Contains(c1), "Hand.GetCards.Contains failed for second card.");
            Assert.IsTrue(hand.getCards().Contains(c2), "Hand.GetCards.Contains failed for third card.");

            //Test to make sure a removed item no longer exists, but the others still do.
            hand.removeCard(c);
            Assert.IsTrue(hand.getCards().Contains(c) == false, "Hand.GetCards.Contains failed for removed card.");
            Assert.IsTrue(hand.getCards().Contains(c1), "Hand.GetCards.Contains failed for first remaining card.");
            Assert.IsTrue(hand.getCards().Contains(c2), "Hand.GetCards.Contains failed for second remaining card.");
        }

        [TestMethod]
        public void TestTable()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card('H', "10"));
            cards.Add(new Card('A', "9"));
            cards.Add(new Card('D', "K"));
            Hand hand = new Hand(cards);

            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card('H', "9"));
            cards2.Add(new Card('A', "K"));
            cards2.Add(new Card('D', "9"));
            Hand hand2 = new Hand(cards);

            List<Seat> seats = new List<Seat>();
            seats.Add(new Player());
            CPU cpu = new CPU();
            cpu.hand = hand;
            seats.Add(cpu);

            Table table = new Table();
            table.setOrder(seats);

            List<Hand> hands = new List<Hand>();
            hands.Add(hand2);
            table.setHands(hands);

            //Try to get the current turn value, the person who should go next
            Assert.IsTrue(table.getTurn() == 0, "Table.GetTurn failed");
            Assert.IsTrue(table.nextTurn().GetType() == (new Player()).GetType(), "Table.NextTurn failed");

            //Test an increament of turn counter.
            table.turn += 1;
            Assert.IsTrue(table.getTurn() == 1, "Table.GetTurn error with incremented.");

            //Try and get the CPU hand just for fun.
            Assert.IsTrue(table.nextTurn().getHand().Find('H', "10"), "Table.GetTurn error getting CPU hand.");

            //Test to make sure the hand was added to the table
            Assert.IsTrue(table.getHands().Contains(hand2), "Error adding a hand to the table.");

        }

        [TestMethod]
        public void TestDeck()
        {
            Deck deck = new Deck();
            deck = deck.generateDeck();

            //Test to make sure all edge cases made it into the deck
            Assert.IsTrue(deck.Find('S', "9"), "Deck.GetCards failed for S9.");
            Assert.IsTrue(deck.Find('S', "A"), "Deck.GetCards failed for SA.");
            Assert.IsTrue(deck.Find('D', "9"), "Deck.GetCards failed for D9.");
            Assert.IsTrue(deck.Find('D', "A"), "Deck.GetCards failed for DA.");
            Assert.IsTrue(deck.Find('H', "9"), "Deck.GetCards failed for H9.");
            Assert.IsTrue(deck.Find('H', "A"), "Deck.GetCards failed for HA.");
            Assert.IsTrue(deck.Find('C', "9"), "Deck.GetCards failed for C9.");
            Assert.IsTrue(deck.Find('C', "A"), "Deck.GetCards failed for CA.");

            //Test to make sure the cards were evenly divided into hands.
            List<Hand> hands = deck.draw();

            Assert.IsTrue(hands[0].Find('S', "9"), "Deck.Draw failed for S9.");
            Assert.IsTrue(hands[0].Find('C', "Q"), "Deck.Draw failed for SA.");

            Assert.IsTrue(hands[1].Find('S', "A"), "Deck.Draw failed for D9.");
            Assert.IsTrue(hands[1].Find('C', "K"), "Deck.Draw failed for DA.");

            Assert.IsTrue(hands[2].Find('H', "9"), "Deck.Draw failed for H9.");
            Assert.IsTrue(hands[2].Find('C', "10"), "Deck.Draw failed for HA.");

            Assert.IsTrue(hands[3].Find('H', "J"), "Deck.Draw failed for C9.");
            Assert.IsTrue(hands[3].Find('C', "A"), "Deck.Draw failed for CA.");
        }

        [TestMethod]
        public void TestSeat()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card('H', "10"));
            cards.Add(new Card('A', "9"));
            cards.Add(new Card('D', "K"));
            Hand hand = new Hand(cards);

            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card('H', "9"));
            cards2.Add(new Card('A', "K"));
            cards2.Add(new Card('D', "9"));
            Hand hand2 = new Hand(cards);

            Player player = new Player();
            player.hand = hand;

            CPU cpu = new CPU();
            cpu.hand = hand2;

            //Test to ensure wrong hands were not assigned.
            Assert.IsFalse(player.getHand() == hand2, "Player.GetHand returned invalid hand.");
            Assert.IsFalse(cpu.getHand() == hand, "CPU.GetHand returned invalid hand.");

            //Test to ensure correct hands were assigned.
            Assert.IsTrue(player.getHand() == hand, "Player.GetHand failed return hand.");
            Assert.IsTrue(cpu.getHand() == hand2, "CPU.GetHand failed return hand.");
        }


    }
}
