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
        public void TestFormat()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();

            //check
            Assert.IsTrue(form.format("").Length == 0, "if(length>0) failed.");
            Assert.IsTrue(form.format("1") == "1.00", "if(conains(.) failed.");
            Assert.AreEqual(form.format("1."), "1.00", "add two 0's failed.");
            Assert.AreEqual(form.format("1.1"), "1.10", "add one 0 failed.");
            Assert.AreEqual(form.format("1.00"), "1.00", "not formatting failed");
        }

        [TestMethod]
        public void TestLogin()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);
            //form.login.Show();
            //form.login.MessageBoxService = new TestBox() as IMessageBoxService;
            //form.login.tbPass.Text = "alf1";
            //form.login.tbUser.Text = "jalf"; 
            //form.login.bSignIn_Click(this, null);



            Assert.IsTrue(form.getListBox("lbBreakfast").Items.Count > 0, "lbBreakfast is empty.");
            Assert.IsTrue(form.getListBox("lbBreakfast").SelectedIndex == 0, "lbBreakfast selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbLD").Items.Count > 0, "lbLD is empty.");
            Assert.IsTrue(form.getListBox("lbLD").SelectedIndex == 0, "lbLD selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbDrinks").Items.Count > 0, "lbDrinks is empty.");
            Assert.IsTrue(form.getListBox("lbDrinks").SelectedIndex == 0, "lbDrinks selected index is not.");

            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDesserts is empty.");
            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDesserts selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 0, "lbOrder is not empty.");
        }

        [TestMethod]
        public void TestTokenizePrices()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);
            form.bBreakfast_Click(this, null);

            //action
            form.tokenizePrices();

            //check
            Assert.IsTrue(form.prices[0] == 2.99, "Price is not tokenized correctly.");
        }

        [TestMethod]
        public void TestClear()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);
            

            form.bBreakfast_Click(this, null);
            form.bDrinks_Click(this, null);
            form.bLD_Click(this, null);
            form.bDessert_Click(this, null);

            //baseline
            Assert.IsTrue(form.getTextBox("tbTotal").Text == "11.09", "tbTotal not accurate");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text == "10.46", "tbSubTotal not accurate.");
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 4, "4 Items not added.");
            Assert.IsTrue(form.prices.Count == 4, "prices not 4.");

            //action
            form.bClear_Click(this, null);

            //checks
            Assert.IsTrue(form.getTextBox("tbTotal").Text == "0.00", "tbTotal not 0.00.");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text == "0.00", "tbSubTotal not 0.00.");
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 0, "4 Items not added");
            Assert.IsTrue(form.prices.Count == 0, "prices not empty.");
        }

        [TestMethod]
        public void TestTotalNotEmpty()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //action
            form.bBreakfast_Click(this, null);
            form.bDrinks_Click(this, null);
            form.bLD_Click(this, null);
            form.bDessert_Click(this, null);

            //check
            Assert.IsTrue(form.getTextBox("tbTotal").Text == "11.09", "tbTotal not 0.00.");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text == "10.46", "tbSubTotal not 0.00.");
        }

        [TestMethod]
        public void TestTotalEmpty()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //check
            Assert.IsTrue(form.getTextBox("tbTotal").Text == "0.00", "tbTotal not 0.00.");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text == "0.00", "tbSubTotal not 0.00.");
        }

        [TestMethod]
        public void TestRemove()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            form.bBreakfast_Click(this, null);
            form.bBreakfast_Click(this, null);

            //baseline
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 2, "lbOrder count not 2");
            Assert.IsTrue(form.prices.Count == 2, "Prices count not 2");

            //action
            form.bRemove_Click(this, null);

            //check
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 1, "lbOrder count not 1");
            Assert.IsTrue(form.prices.Count == 1, "Prices count not 1");
        }

        [TestMethod]
        public void TestZeroOut()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            form.bBreakfast_Click(this, null);

            //baseline
            Assert.IsTrue(form.getTextBox("tbTotal").Text != "0.00", "tbTotal is 0.00.");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text != "0.00", "tbSubTotal is 0.00.");

            //action
            form.zeroOut();

            //check
            Assert.IsTrue(form.getTextBox("tbTotal").Text == "0.00", "tbTotal not 0.00.");
            Assert.IsTrue(form.getTextBox("tbSubtotal").Text == "0.00", "tbSubTotal not 0.00.");
            Assert.IsTrue(form.getTextBox("tbTax").Text == "0.06", "tbTax not 0.06.");
        }

        [TestMethod]
        public void TestGetTotal()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.prices.Clear();

            form.prices.Add(1.02);
            form.prices.Add(2.33);
            form.prices.Add(3.40);
            form.prices.Add(4.50);

            //action
            double total = form.getTotal();

            //check
            Assert.AreEqual(total, 11.25, "GetTotal method not adding correctly.");
        }

        [TestMethod]
        public void TestBreakfastAdd()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //baseline
            int count = form.getListBox("lbBreakfast").Items.Count;
            Assert.IsTrue(form.getListBox("lbBreakfast").Items.Count > 0, "lbBreakfast has no item.");
            Assert.IsTrue(form.getListBox("lbBreakfast").SelectedIndex == 0, "lbBreakfast selected item not zero.");

            //action
            form.bBreakfast_Click(this, null);

            //check
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count > 0, "lbOrder has no item.");
            Assert.IsTrue(form.getListBox("lbOrder").SelectedIndex == 0, "lbOrder selected item not 0.");
            Assert.AreEqual(form.getListBox("lbBreakfast").SelectedItem, form.getListBox("lbOrder").SelectedItem, "Selected item from lbBreakfast not moved to lbOrder.");
            Assert.AreEqual(form.getListBox("lbBreakfast").Items.Count, count, "Item removed from lbBreakfast");
            Assert.IsTrue(form.prices.Count == 1, "Prices empty");
        }

        [TestMethod]
        public void TestLDAdd()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //baseline
            int count = form.getListBox("lbLD").Items.Count;
            Assert.IsTrue(form.getListBox("lbLD").Items.Count > 0, "lbLD has no item.");
            Assert.IsTrue(form.getListBox("lbLD").SelectedIndex == 0, "lbLD selected index not 0.");

            //action
            form.bLD_Click(this, null);

            //check
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count > 0, "lbOrder has no item.");
            Assert.IsTrue(form.getListBox("lbOrder").SelectedIndex == 0, "lbOrder selected item not 0.");
            Assert.AreEqual(form.getListBox("lbLD").SelectedItem, form.getListBox("lbOrder").SelectedItem, "Selected item from lbLD not moved to lbOrder.");
            Assert.AreEqual(form.getListBox("lbLD").Items.Count, count, "Item removed from lbLD");
            Assert.IsTrue(form.prices.Count == 1, "Prices empty");
        }

        [TestMethod]
        public void TestDessertAdd()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //baseline
            int count = form.getListBox("lbDessert").Items.Count;
            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDessert has no item.");
            Assert.IsTrue(form.getListBox("lbDessert").SelectedIndex == 0, "lbDessert selected index not 0.");

            //action
            form.bDessert_Click(this, null);
            
            //check
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count > 0, "lbOrder has no item.");
            Assert.IsTrue(form.getListBox("lbOrder").SelectedIndex == 0, "lbOrder selected item not 0.");
            Assert.AreEqual(form.getListBox("lbDessert").SelectedItem, form.getListBox("lbOrder").SelectedItem, "Selected item from lbDessert not moved to lbOrder.");
            Assert.AreEqual(form.getListBox("lbDessert").Items.Count, count, "Item removed from lbDessert");
            Assert.IsTrue(form.prices.Count == 1, "Prices empty");
        }

        [TestMethod]
        public void TestDrinksAdd()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //baseline
            int count = form.getListBox("lbDrinks").Items.Count;
            Assert.IsTrue(form.getListBox("lbDrinks").Items.Count > 0, "lbDrinks has no item.");
            Assert.IsTrue(form.getListBox("lbDrinks").SelectedIndex == 0, "lbDrinks selected index not 0.");

            //action
            form.bDrinks_Click(this, null);

            //check
            Assert.IsTrue(form.getListBox("lbOrder").Items.Count > 0, "lbOrder has no item.");
            Assert.IsTrue(form.getListBox("lbOrder").SelectedIndex == 0, "lbOrder selected item not 0.");
            Assert.AreEqual(form.getListBox("lbDrinks").SelectedItem, form.getListBox("lbOrder").SelectedItem, "Selected item from lbDrinks not moved to lbOrder.");
            Assert.AreEqual(form.getListBox("lbDrinks").Items.Count, count, "Item removed from lbDrinks");
            Assert.IsTrue(form.prices.Count == 1, "Prices empty");
        }

        [TestMethod]
        public void ListBoxesLoad()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //check
            Assert.IsTrue(form.getListBox("lbBreakfast").Items.Count > 0, "lbBreakfast is empty.");
            Assert.IsTrue(form.getListBox("lbBreakfast").SelectedIndex == 0, "lbBreakfast selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbLD").Items.Count > 0, "lbLD is empty.");
            Assert.IsTrue(form.getListBox("lbLD").SelectedIndex == 0, "lbLD selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbDrinks").Items.Count > 0, "lbDrinks is empty.");
            Assert.IsTrue(form.getListBox("lbDrinks").SelectedIndex == 0, "lbDrinks selected index is not.");

            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDesserts is empty.");
            Assert.IsTrue(form.getListBox("lbDessert").Items.Count > 0, "lbDesserts selected index is not 0.");

            Assert.IsTrue(form.getListBox("lbOrder").Items.Count == 0, "lbOrder is not empty.");
        }

        [TestMethod]
        public void TestTextboxesLoad()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //check
            Assert.AreEqual(form.getTextBox("tbTotal").Text, "0.00", "Total not zeroed");
            Assert.AreEqual(form.getTextBox("tbTax").Text, "0.06", "Tax not zeroed");
            Assert.AreEqual(form.getTextBox("tbSubtotal").Text, "0.00", "SubTotal not zeroed");
            Assert.IsTrue(form.prices.Count == 0, "Prices not empty");
        }

        [TestMethod]
        public void TestTranslate()
        {
            //setup
            NuWayOrderForm form = new NuWayOrderForm();
            form.Show();
            form.LoginService = new TestBox();
            form.login.isAuthentic = true;
            form.signInToolStripMenuItem_Click(this, null);

            //Action
            form.spanishToolStripMenuItem_Click(this, null);

            //Check
            Assert.IsTrue(form.getListBox("lbDessert").Items[0].ToString().CompareTo("") == 0, "Did not translate");
            Assert.IsTrue(form.getListBox("lbDrinks").Items[0].ToString().CompareTo("") == 0, "Did not translate");
            Assert.IsTrue(form.getListBox("lbLD").Items[0].ToString().CompareTo("") == 0, "Did not translate");
            Assert.IsTrue(form.getListBox("lbBreakfast").Items[0].ToString().CompareTo("") == 0, "Did not translate");

        }
    }

    public class TestBox : IMessageBoxService
    {
        public void Show(string message)
        {
            
        }
    }
}
