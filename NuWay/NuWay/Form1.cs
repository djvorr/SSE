using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace NuWay
{
    public partial class NuWayOrderForm : Form
    {
        //collection holding items from db
        List<String> items = new List<String>();
        //collection for calculating the total using just the prices
        List<double> prices = new List<double>();

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataReader reader;
        Tokenizer token;

        string selectString = "SELECT Item, Description, Price FROM NuWay";

        public NuWayOrderForm()
        {
            InitializeComponent();
        }

        //get all the items from the db
        public void ConnectToAccess()
        {
            conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source= nuwaymenu.mdb;";

            try
            {
                conn.Open();

                cmd = new OleDbCommand(selectString, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string st = reader["Item"].ToString() + "-" + reader["Description"] + "  $" + reader["Price"];
                    items.Add(st);
                }

                fillBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }

        //filter the items from the db collection and assign to corresponding listbox
        public void fillBoxes()
        {
            foreach (String item in items)
            {
                if (items.IndexOf(item) < 31)
                    lbBreakfast.Items.Add(item);
                else if (items.IndexOf(item) < 86)
                    lbLD.Items.Add(item);
                else if (items.IndexOf(item) < 102)
                    lbDrinks.Items.Add(item);
                else
                    lbDessert.Items.Add(item);
            }
        }

        //get the total cost by adding up all the prices in the price collection
        public double getTotal()
        {
            double total = 0.00;

            foreach (double d in prices)
                total += d;

            return total;
        }

        //set the default selected item in each listbos to the first item in each one
        public void SelectedItems()
        {
            if (lbBreakfast.Items.Count > 0)
                lbBreakfast.SelectedIndex = 0;
            if (lbLD.Items.Count > 0)
                lbLD.SelectedIndex = 0;
            if (lbDrinks.Items.Count > 0)
                lbDrinks.SelectedIndex = 0;
            if (lbDessert.Items.Count > 0)
                lbDessert.SelectedIndex = 0;

            zeroOut();
        }

        //govern the values for the totals boxes in the bottom right of the window
        public void Total()
        {
            if (lbOrder.Items.Count < 1)
            {
                zeroOut();
            }
            else
            {
                lbOrder.SelectedIndex = 0;
                prices.Clear();

                foreach (String item in lbOrder.Items)
                {
                    token = new Tokenizer(item);
                    string value = token.tokenize('$');
                    prices.Add(Double.Parse(value));
                }

                double total = getTotal();

                tbSubtotal.Text = format(total.ToString());
                total = total + Math.Round(total * Double.Parse(tbTax.Text), 2);
                tbTotal.Text = format(total.ToString());
            }
        }

        //format the final values to look like prices: XXX.XX
        public String format(String amount)
        {
            //if amount not blank
            if(amount.Length > 0)
            {
                //if contains "."
                if (amount.Contains("."))
                {
                    //if no 0's
                    if (amount.IndexOf('.') == amount.Length - 1)
                        return amount += "00";
                    //if one 0
                    else if (amount.IndexOf('.') == amount.Length - 2)
                        return amount += "0";
                }
                else
                    return amount += ".00";
            }

            return amount;
        }

        //set the totals boxes in the bottom right of the window to 0.00
        public void zeroOut()
        {
            tbSubtotal.Text = "0.00";
            tbTax.Text = "0.06";
            tbTotal.Text = "0.00";
        }

        //on Add Breakfast Button click, add selected breakfast item to Order list
        private void bBreakfast_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbBreakfast.SelectedItem);
            Total();
        }

        //on Clear Button click, empty the contents of the Order list
        private void bClear_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Clear();
            Total();
        }

        //on Add Dessert Button click, add selected dessert item to Order list
        private void bDessert_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDessert.SelectedItem);
            Total();
        }

        //on Add Drink Button click, add selected drink item to Order list
        private void bDrinks_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDrinks.SelectedItem);
            Total();
        }

        //on Add Lunch/Dinner Button click, add selected Lunch/Dinner item to Order list
        private void bLD_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbLD.SelectedItem);
            Total();
        }

        //on Remove Button click, remove selected item from Order List
        private void bRemove_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Remove(lbOrder.SelectedItem);
            Total();
        }

        //on Total button click, show message box with final cost
        private void bTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your total comes to $" + tbTotal.Text);
        }

        //on First load of order form window
        private void NuWayOrderForm_Load(object sender, EventArgs e)
        {
            ConnectToAccess();
            SelectedItems();
            zeroOut();
        }

        public ListBox getListBox(String listBox)
        {
            if (listBox == "lbOrder")
                return lbOrder;
            else if (listBox == "lbBreakfast")
                return lbBreakfast;
            else if (listBox == "lbLD")
                return lbLD;
            else if (listBox == "lbDrinks")
                return lbDrinks;
            else if (listBox == "lbDessert")
                return lbDessert;
            else
                return null;
        }

        public TextBox getTextBox(String textBox)
        {
            if (textBox == "tbSubtotal")
                return tbSubtotal;
            else if (textBox == "tbTax")
                return tbTax;
            else if (textBox == "tbTotal")
                return tbTotal;
            else
                return null;
        }
    }
}
