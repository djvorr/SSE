using System;
using QueensAndJacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unit_Test_Suite_1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestStartGame()
        {
            Game.StartGame();
        }
/*
        [TestMethod]
        public void TestDeckShuffle()
        {
            Deck d1 = new Deck();
            d1 = d1.generateDeck();
            List<Card> ld1 = d1.getCards();
            
            Deck d2 = new Deck();
            d2 = d2.generateDeck();
            List<Card> ld2 = d2.getCards();

            Assert.AreEqual(ld1[0].compare(ld2[0]), 0, "First index not euqal.");
            Assert.AreEqual(ld1[5].compare(ld2[5]), 0, "Fifth index not euqal.");
            Assert.AreEqual(ld1[11].compare(ld2[11]), 0, "Eleventh index not euqal.");
            Assert.AreEqual(ld1[17].compare(ld2[17]), 0, "Seventeenth index not euqal.");
            Assert.AreEqual(ld1[23].compare(ld2[23]), 0, "Twenty-third index not euqal.");

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
*/      
    }
}
