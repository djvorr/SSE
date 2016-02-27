using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace NuWay
{
    public partial class NuWayOrderForm : Form
    {
        //collection holding items from db
        public List<String> items = new List<String>();
        //collection for calculating the total using just the prices
        public List<double> prices = new List<double>();

        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;
        Tokenizer token;

        public static string selectString = "SELECT Item, Description, Price FROM NuWay";

        public NuWayOrderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// get all the items from the db
        /// </summary>
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

        /// <summary>
        /// filter the items from the db collection and assign to corresponding listbox
        /// </summary>
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

        /// <summary>
        /// get the total cost by adding up all the prices in the price collection
        /// </summary>
        /// <returns>double total</returns>
        public double getTotal()
        {
            double total = 0.00;

            foreach (double d in prices)
                total += d;

            return total;
        }

        /// <summary>
        /// set the default selected item in each listbos to the first item in each one
        /// </summary>
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

        /// <summary>
        /// govern the values for the totals boxes in the bottom right of the window
        /// </summary>
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

                tokenizePrices();

                double total = getTotal();

                tbSubtotal.Text = format(total.ToString());
                total = total + Math.Round(total * Double.Parse(tbTax.Text), 2);
                tbTotal.Text = format(total.ToString());
            }
        }

        /// <summary>
        /// Tokenize all prices into a collection
        /// </summary>
        public void tokenizePrices()
        {
            foreach (String item in lbOrder.Items)
            {
                token = new Tokenizer(item);
                string value = token.tokenize('$');
                prices.Add(Double.Parse(value));
            }
        }

        /// <summary>
        /// format the final values to look like prices: XXX.XX
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>formatted cost: String amount</returns>
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

        /// <summary>
        /// set the totals boxes in the bottom right of the window to 0.00
        /// </summary>
        public void zeroOut()
        {
            tbSubtotal.Text = "0.00";
            tbTax.Text = "0.06";
            tbTotal.Text = "0.00";
        }

        /// <summary>
        /// on Add Breakfast Button click, add selected breakfast item to Order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bBreakfast_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbBreakfast.SelectedItem);
            Total();
        }

        /// <summary>
        /// on Clear Button click, empty the contents of the Order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bClear_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Clear();
            Total();
            prices.Clear();
        }

        /// <summary>
        /// on Add Dessert Button click, add selected dessert item to Order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bDessert_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDessert.SelectedItem);
            Total();
        }

        /// <summary>
        /// on Add Drink Button click, add selected drink item to Order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bDrinks_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDrinks.SelectedItem);
            Total();
        }

        /// <summary>
        /// on Add Lunch/Dinner Button click, add selected Lunch/Dinner item to Order list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bLD_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbLD.SelectedItem);
            Total();
        }

        /// <summary>
        /// on Remove Button click, remove selected item from Order List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bRemove_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Remove(lbOrder.SelectedItem);
            Total();
        }

        /// <summary>
        /// on Total button click, show message box with final cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your total comes to $" + tbTotal.Text);
        }

        /// <summary>
        /// on First load of order form window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NuWayOrderForm_Load(object sender, EventArgs e)
        {
            disableButtons();
        }

        /// <summary>
        /// method for obtaining the listboxes for unit testing
        /// </summary>
        /// <param name="listBox"></param>
        /// <returns>ListBox listBox</returns>
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

        /// <summary>
        /// method for obtaining the textboxes for unit testing
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Click to Sign in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            if (login.isAdministrator)
            {
                //MessageBox.Show("is Admin");
                adminToolStripMenuItem.Enabled = true;
            }
            else if (login.isAuthentic)
            {
                MessageBox.Show("is Authentic");
                enableButtons();
                ConnectToAccess();
                fillBoxes();
                SelectedItems();
                zeroOut();
            }
        }

        /// <summary>
        /// Disable App functionality
        /// </summary>
        public void disableButtons()
        {
            bBreakfast.Enabled = false;
            bLD.Enabled = false;
            bDessert.Enabled = false;
            bDrinks.Enabled = false;
            bClear.Enabled = false;
            bRemove.Enabled = false;
            bTotal.Enabled = false;
        }

        /// <summary>
        /// Enable App Functionality
        /// </summary>
        public void enableButtons()
        {
            bBreakfast.Enabled = true;
            bLD.Enabled = true;
            bDessert.Enabled = true;
            bDrinks.Enabled = true;
            bClear.Enabled = true;
            bRemove.Enabled = true;
            bTotal.Enabled = true;
        }

        /// <summary>
        /// CLick add user under the admin tab on the menu ribbon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser add = new AddUser("Kentucky");
            add.ShowDialog();
        }
    }
}
