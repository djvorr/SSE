using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyAlgorithm;

namespace FuzzyTests
{
    [TestClass]
    public class TestFuzzyOperator
    {
        FuzzyOperator fop = new FuzzyOperator();

        [TestMethod]
        public void TestMin()
        {
            Assert.AreEqual(fop.min(0.0f, 0.0f), 0.0f, "min(0.0f, 0.0f) failed.");
            Assert.AreEqual(fop.min(1.0f, 0.0f), 0.0f, "min(1.0f, 0.0f) failed.");
            Assert.AreEqual(fop.min(0.0f, 1.0f), 0.0f, "min(0.0f, 1.0f) failed.");
            Assert.AreEqual(fop.min(0.3f, 0.5f), 0.3f, "min(0.3f, 0.5f) failed.");
            Assert.AreEqual(fop.min(-0.5f, 0.5f), -0.5f, "min(-0.5f, 0.5f) failed.");
            Assert.AreEqual(fop.min(-0.1f, -1.0f), -1.0f, "min(-0.1f, -1.0f) failed.");
        }

        [TestMethod]
        public void TestMax()
        {
            Assert.AreEqual(fop.max(0.0f, 0.0f), 0.0f, "max(0.0f, 0.0f) failed.");
            Assert.AreEqual(fop.max(1.0f, 0.0f), 1.0f, "max(1.0f, 0.0f) failed.");
            Assert.AreEqual(fop.max(0.0f, 1.0f), 1.0f, "max(0.0f, 1.0f) failed.");
            Assert.AreEqual(fop.max(0.3f, 0.5f), 0.5f, "max(0.3f, 0.5f) failed.");
            Assert.AreEqual(fop.max(-0.5f, 0.5f), 0.5f, "max(-0.5f, 0.5f) failed.");
            Assert.AreEqual(fop.max(-0.1f, -1.0f), -0.1f, "max(-0.1f, -1.0f) failed.");
        }

        [TestMethod]
        public void TestAnd()
        {
            Assert.AreEqual(fop.and(0.0f, 0.0f), 0.0f, "and(0.0f, 0.0f) failed.");
            Assert.AreEqual(fop.and(1.0f, 0.0f), 0.0f, "and(1.0f, 0.0f) failed.");
            Assert.AreEqual(fop.and(0.0f, 1.0f), 0.0f, "and(0.0f, 1.0f) failed.");
            Assert.AreEqual(fop.and(0.3f, 0.5f), 0.3f, "and(0.3f, 0.5f) failed.");
            Assert.AreEqual(fop.and(-0.5f, 0.5f), -0.5f, "and(-0.5f, 0.5f) failed.");
            Assert.AreEqual(fop.and(-0.1f, -1.0f), -1.0f, "and(-0.1f, -1.0f) failed.");
        }

        [TestMethod]
        public void TestOr()
        {
            Assert.AreEqual(fop.or(0.0f, 0.0f), 0.0f, "or(0.0f, 0.0f) failed.");
            Assert.AreEqual(fop.or(1.0f, 0.0f), 1.0f, "or(1.0f, 0.0f) failed.");
            Assert.AreEqual(fop.or(0.0f, 1.0f), 1.0f, "or(0.0f, 1.0f) failed.");
            Assert.AreEqual(fop.or(0.3f, 0.5f), 0.5f, "or(0.3f, 0.5f) failed.");
            Assert.AreEqual(fop.or(-0.5f, 0.5f), 0.5f, "or(-0.5f, 0.5f) failed.");
            Assert.AreEqual(fop.or(-0.1f, -1.0f), -0.1f, "or(-0.1f, -1.0f) failed.");
        }

        [TestMethod]
        public void TestNot()
        {
            Assert.AreEqual(fop.not(0.0f), 1.0f, "not(0.0f) failed.");
            Assert.AreEqual(fop.not(1.0f), 0.0f, "not(1.0f) failed.");
            Assert.AreEqual(fop.not(-0.5f), 1.5f, "not(-0.5f) failed.");
            Assert.AreEqual(fop.not(0.3f), 0.7f, "not(0.3f) failed.");
            Assert.AreEqual(fop.not(-1.0f), 2.0f, "not(-1.0f) failed.");
            Assert.AreEqual(fop.not(2.0f), -1.0f, "not(2.0f) failed.");
        }
    }
}
