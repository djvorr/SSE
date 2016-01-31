using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuWay
{
    public partial class NuWayOrderForm : Form
    {

        List<String> items = new List<String>();
        List<double> prices = new List<double>();

        public NuWayOrderForm()
        {
            InitializeComponent();
        }

        public void ConnectToAccess()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source= nuwaymenu.mdb;";

            try
            {
                conn.Open();

                string selectString = "SELECT Item, Description, Price FROM NuWay";

                OleDbCommand cmd = new OleDbCommand(selectString, conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string st = reader["Item"].ToString() + "-" + reader["Description"] + "  $" + reader["Price"];
                    items.Add(st);
                }

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
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }

        public double getTotal()
        {
            double total = 0.00;

            foreach (double d in prices)
                total += d;

            return total;
        }

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

        public void Total()
        {
            if (lbOrder.Items.Count < 1)
            {
                zeroOut();
            }
            else
            {
                lbOrder.SelectedIndex = 0;
                Tokenizer token;
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

        public void zeroOut()
        {
            tbSubtotal.Text = "0.00";
            tbTax.Text = "0.06";
            tbTotal.Text = "0.00";
        }

        private void bBreakfast_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbBreakfast.SelectedItem);
            Total();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Clear();
            Total();
        }

        private void bDessert_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDessert.SelectedItem);
            Total();
        }

        private void bDrinks_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbDrinks.SelectedItem);
            Total();
        }

        private void bLD_Click(object sender, EventArgs e)
        {
            lbOrder.Items.Add(lbLD.SelectedItem);
            Total();
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (lbOrder.Items.Count > 0)
                lbOrder.Items.Remove(lbOrder.SelectedItem);
            Total();
        }

        private void bTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your total comes to $" + tbTotal.Text);
        }

        private void NuWayOrderForm_Load(object sender, EventArgs e)
        {
            ConnectToAccess();
            SelectedItems();
            tbTax.Text = "0.06";
        }
    }
}
