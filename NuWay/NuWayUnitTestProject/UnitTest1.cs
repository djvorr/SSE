using System;
using NuWay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace NuWayUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();

        }

        [TestMethod]
        public void ListBoxesLoad()
        {
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();

            Assert.IsTrue(form.getListBox("lbBreakfast").Items.Count > 0, "lbBreakfast is empty.");
            Assert.IsTrue(form.getListBox("lbLD").Items.Count > 0, "lbLD is empty.");
            Assert.IsTrue(form.getListBox("lbDrinks").Items.Count > 0, "lbDrinks is empty.");
            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDesserts is empty.");
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 0, "lbOrder is not empty.");
        }

        [TestMethod]
        public void TestTextboxesLoad()
        {
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();

            TextBox tb = form.getTextBox("tbTotal");
            Assert.AreEqual(tb.Text, "0.00", "Total not zeroed");
            tb = form.getTextBox("tbTax");
            Assert.AreEqual(tb.Text, "0.06", "Tax not zeroed");
            tb = form.getTextBox("tbSubtotal");
            Assert.AreEqual(tb.Text, "0.00", "SubTotal not zeroed");
        }
    }
}
