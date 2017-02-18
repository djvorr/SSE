using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyAlgorithm;

namespace FuzzyTests
{
    [TestClass]
    public class TestMembershipCalculator
    {
        MembershipCalculator mc = new MembershipCalculator();

        [TestMethod]
        public void TestCalculatePlateauProfile_Low()
        {
            //low is about 1 -> 10

            float val = 0;
            float left_low = 1.0f;
            float left_high = 1.0f;
            float right_high = 5.0f;
            float right_low = 10.0f;

            /*     ___________
             *                \
             *                 \__________
            */
            val = 1;
            float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Low1 failed.");

            val = 3;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Low2 failed.");

            val = 5;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Low3 failed.");

            val = 7.5f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(delta(0.5f, ret), "Low4 failed.");

            val = 10;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Low5 failed.");

            val = 10.1f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Low6 failed.");
        }


        [TestMethod]
        public void TestCalculatePlateauProfile_Mid()
        {
            float val = 0;
            float left_low = 5.0f;
            float left_high = 10.0f;
            float right_high = 20.0f;
            float right_low = 25.0f;

            /*              ___________
             *             /           \
             *    ________/             \__________
            */
            val = 4.9f;
            float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Mid1 failed.");

            val = 5;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Mid2 failed.");

            val = 7.5f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(delta(0.5f, ret), "Mid3 failed.");

            val = 10;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Mid4 failed.");

            val = 15;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Mid5 failed.");

            val = 20;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "Mid6 failed.");

            val = 22.5f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(delta(0.5f, ret), "Mid7 failed.");

            val = 25;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Mid8 failed.");

            val = 25.1f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "Mid9 failed.");
        }

        [TestMethod]
        public void TestCalculatePlateauProfile_High()
        {
            float val = 0;
            float left_low = 20.0f;
            float left_high = 25.0f;
            float right_high = 30.0f;
            float right_low = 30.0f;

            /*              ___________
             *             /           
             *    ________/             
            */
            val = 19.9f;
            float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "High1 failed.");

            val = 20;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 0, "High2 failed.");

            val = 22.5f;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(delta(ret, 0.5f), "High3 failed.");

            val = 25;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "High4 failed.");

            val = 30;
            ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);

            Assert.IsTrue(ret == 1, "High5 failed.");
        }

        private bool delta(float a, float b)
        {
            return Math.Abs((a - b)) <= 0.01f;
        }
    }
}
