using IronPython.Hosting;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NuWay
{

    public partial class NuWayOrderForm : Form
    {
        //collection holding items from db
        public List<NuWayMenuItem> items = new List<NuWayMenuItem>();
        //collection for calculating the total using just the prices
        public List<double> prices = new List<double>();

        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;
        Tokenizer token;
        LoginForm login = new LoginForm();
        MyMealForm mealform = new MyMealForm();
        SaveMealForm saveMeal = new SaveMealForm();

        UserDB db;
        Key key = new Key();
        protected string sharedPrivateKey = "Louisville";
        En_De_cryption cryptographer = new En_De_cryption();

        public static string selectString = "SELECT Item, Description, Price FROM NuWay";
        public string currentLang = "en";

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
                    //string st = reader["Item"].ToString() + "-" + reader["Description"] + "  $" + reader["Price"];
                    NuWayMenuItem nwmi = new NuWayMenuItem(reader["Item"].ToString(), reader["Description"].ToString(), "$" + reader["Price"]);
                    items.Add(nwmi);
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
            foreach (NuWayMenuItem item in items)
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
            {
                lbBreakfast.SelectedIndex = 0;
                tbBreakfast.Text = (lbBreakfast.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbLD.Items.Count > 0)
            {
                lbLD.SelectedIndex = 0;
                tbLD.Text = (lbLD.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbDrinks.Items.Count > 0)
            { 
                lbDrinks.SelectedIndex = 0;
                tbDrink.Text = (lbDrinks.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbDessert.Items.Count > 0)
            {
                lbDessert.SelectedIndex = 0;
                tbDessert.Text = (lbDessert.SelectedItem as NuWayMenuItem).ItemDesc;
            }

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
            foreach (NuWayMenuItem item in lbOrder.Items)
            {
                token = new Tokenizer(item.ToString());
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
        /// on Total button click, show order form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bTotal_Click(object sender, EventArgs e)
        {
            string encryptedAdminrole = cryptographer.EncryptString("administrator", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            string encryptedSubrole = cryptographer.EncryptString("subscriber", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));

            if (login.currentRole != null && login.currentRole != "")
            {
                if (encryptedAdminrole == login.currentRole || encryptedSubrole == login.currentRole)
                {
                    PlaceOrderForm place = new PlaceOrderForm(tbTotal.Text);
                    place.ShowDialog();
                }
                else
                    MessageBox.Show("Free Users do not have access to this service. Subscribe today!");
            }
            else
                MessageBox.Show("Must be signed in as a subscriber to use this function.");
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
            login.ShowDialog();

            if (login.isAdministrator)
            {
                //MessageBox.Show("is Admin");
                adminToolStripMenuItem.Enabled = true;
                LoginLabel.Text = "Logged in as " + login.CurrentUser + " (Admin)";
                mealform.CurrentUser = login.CurrentUser;
                saveMeal.CurrentUser = login.CurrentUser;
            }
            else if (login.isAuthentic)
            {
                //MessageBox.Show("is Authentic");
                adminToolStripMenuItem.Enabled = false;
                enableButtons();
                ConnectToAccess();
                fillBoxes();
                SelectedItems();
                zeroOut();
                LoginLabel.Text = "Logged in as " + login.CurrentUser;
                mealform.CurrentUser = login.CurrentUser;
                saveMeal.CurrentUser = login.CurrentUser;
                bMyMeals.Enabled = true;
                bSaveMeal.Enabled = true;
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
            AddUser add = new AddUser();
            add.ShowDialog();
        }


        /// <summary>
        /// Double clicking a record automatically adds the record to the order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbBreakfast_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbBreakfast.SelectedItem);
            Total();
        }

        private void lbLD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbLD.SelectedItem);
            Total();
        }

        private void lbDrinks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbDrinks.SelectedItem);
            Total();
        }

        private void lbDessert_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbDessert.SelectedItem);
            Total();
        }

        
        /// <summary>
        /// If the lb changes for any meal, updates the description displayed below the lb.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_SelectedIndexChanged(object sender, EventArgs e )
        {
            if (sender.Equals(lbDessert))
            {
                tbDessert.Text = (lbDessert.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbBreakfast))
            {
                tbBreakfast.Text = (lbBreakfast.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbLD))
            {
                tbLD.Text = (lbLD.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbDrinks))
            {
                tbDrink.Text = (lbDrinks.SelectedItem as NuWayMenuItem).ItemDesc;
            }
        }


        /// <summary>
        /// Opens the my meal dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMyMeals_Click(object sender, EventArgs e)
        {
            mealform.ShowDialog();
            Regex regex = new Regex(";");
            if (mealform.MealSelect.CompareTo("") != 0)
            {
                string[] foodItems = regex.Split(mealform.MealSelect);
                foreach (string item in foodItems)
                {
                    foreach (NuWayMenuItem menuItem in items)
                    {
                        if (menuItem.ToString().Equals(item))
                        {
                            lbOrder.Items.Add(menuItem);
                            break;
                        }
                    }
                }
            }
            Total();
        }

=======
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NuWay
{

    public partial class NuWayOrderForm : Form
    {
        //collection holding items from db
        public List<NuWayMenuItem> items = new List<NuWayMenuItem>();
        //collection for calculating the total using just the prices
        public List<double> prices = new List<double>();

        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;
        Tokenizer token;
        public LoginForm login = new LoginForm();
        MyMealForm mealform = new MyMealForm();
        SaveMealForm saveMeal = new SaveMealForm();

        public IMessageBoxService LoginService { get; set; }

        UserDB db;
        Key key = new Key();
        protected string sharedPrivateKey = "Louisville";
        En_De_cryption cryptographer = new En_De_cryption();

        public static string selectString = "SELECT Item, Description, Price FROM NuWay";
        public string currentLang = "en";
        public double exchange = 17.56;

        public NuWayOrderForm()
        {
            InitializeComponent();
            LoginService = new LoginDialogService(login);
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
                    //string st = reader["Item"].ToString() + "-" + reader["Description"] + "  $" + reader["Price"];
                    NuWayMenuItem nwmi = new NuWayMenuItem(reader["Item"].ToString(), reader["Description"].ToString(), "$" + reader["Price"]);
                    items.Add(nwmi);
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
            foreach (NuWayMenuItem item in items)
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
            {
                lbBreakfast.SelectedIndex = 0;
                tbBreakfast.Text = (lbBreakfast.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbLD.Items.Count > 0)
            {
                lbLD.SelectedIndex = 0;
                tbLD.Text = (lbLD.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbDrinks.Items.Count > 0)
            { 
                lbDrinks.SelectedIndex = 0;
                tbDrink.Text = (lbDrinks.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            if (lbDessert.Items.Count > 0)
            {
                lbDessert.SelectedIndex = 0;
                tbDessert.Text = (lbDessert.SelectedItem as NuWayMenuItem).ItemDesc;
            }

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
            foreach (NuWayMenuItem item in lbOrder.Items)
            {
                token = new Tokenizer(item.ToString());
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
        /// on Total button click, show order form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bTotal_Click(object sender, EventArgs e)
        {
            string encryptedAdminrole = cryptographer.EncryptString("administrator", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            string encryptedSubrole = cryptographer.EncryptString("subscriber", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));

            if (login.currentRole != null && login.currentRole != "")
            {
                if (encryptedAdminrole == login.currentRole || encryptedSubrole == login.currentRole)
                {
                    PlaceOrderForm place = new PlaceOrderForm(tbTotal.Text);
                    place.ShowDialog();
                }
                else
                    MessageBox.Show("Free Users do not have access to this service. Subscribe today!");
            }
            else
                MessageBox.Show("Must be signed in as a subscriber to use this function.");
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
        public void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //login.ShowDialog();
            LoginService.Show("");

            if (login.isAdministrator)
            {
                //MessageBox.Show("is Admin");
                adminToolStripMenuItem.Enabled = true;
                LoginLabel.Text = "Logged in as " + login.CurrentUser + " (Admin)";
                mealform.CurrentUser = login.CurrentUser;
                saveMeal.CurrentUser = login.CurrentUser;
            }
            else if (login.isAuthentic)
            {
                //MessageBox.Show("is Authentic");
                adminToolStripMenuItem.Enabled = false;
                enableButtons();
                ConnectToAccess();
                fillBoxes();
                SelectedItems();
                zeroOut();
                LoginLabel.Text = "Logged in as " + login.CurrentUser;
                mealform.CurrentUser = login.CurrentUser;
                saveMeal.CurrentUser = login.CurrentUser;
                bMyMeals.Enabled = true;
                bSaveMeal.Enabled = true;
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
            AddUser add = new AddUser();
            add.ShowDialog();
        }


        /// <summary>
        /// Double clicking a record automatically adds the record to the order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbBreakfast_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbBreakfast.SelectedItem);
            Total();
        }

        private void lbLD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbLD.SelectedItem);
            Total();
        }

        private void lbDrinks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbDrinks.SelectedItem);
            Total();
        }

        private void lbDessert_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbOrder.Items.Add(lbDessert.SelectedItem);
            Total();
        }

        
        /// <summary>
        /// If the lb changes for any meal, updates the description displayed below the lb.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_SelectedIndexChanged(object sender, EventArgs e )
        {
            if (sender.Equals(lbDessert))
            {
                if (lbDessert.SelectedIndex < 0)
                    return;
                tbDessert.Text = (lbDessert.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbBreakfast))
            {
                if (lbBreakfast.SelectedIndex < 0)
                    return;
                tbBreakfast.Text = (lbBreakfast.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbLD))
            {
                if (lbLD.SelectedIndex < 0)
                    return;
                tbLD.Text = (lbLD.SelectedItem as NuWayMenuItem).ItemDesc;
            }
            else if (sender.Equals(lbDrinks))
            {
                if (lbDrinks.SelectedIndex < 0)
                    return;
                tbDrink.Text = (lbDrinks.SelectedItem as NuWayMenuItem).ItemDesc;
            }
        }


        /// <summary>
        /// Opens the my meal dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMyMeals_Click(object sender, EventArgs e)
        {
            mealform.ShowDialog();
            Regex regex = new Regex(";");
            if (mealform.MealSelect.CompareTo("") != 0)
            {
                string[] foodItems = regex.Split(mealform.MealSelect);
                foreach (string item in foodItems)
                {
                    foreach (NuWayMenuItem menuItem in items)
                    {
                        if (menuItem.ToString().Equals(item))
                        {
                            lbOrder.Items.Add(menuItem);
                            break;
                        }
                    }
                }
            }
            Total();
        }

>>>>>>> 3fb699f304410aeeda84a8ad68574a6dd60f8514
        /// <summary>
        /// used to get just the words half
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public List<String> getWords(List<Pair> pairs)
        {
            List<String> lefts = new List<string>();

            foreach (Pair p in pairs)
            {
                lefts.Add(p.a);
            }

            return lefts;
        }

        /// <summary>
        /// divides all listbox items into text and cost pairs
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Pair> enPair(ListBox list)
        {
            List<Pair> ret = new List<Pair>();

            for(int i=0; i<list.Items.Count; i++)
            {
                string s = list.Items[i].ToString();
                int ind = s.IndexOf("$");
                ret.Add(new Pair(s.Substring(0, ind-1), s.Substring(ind)));
            }
            return ret;
        }

        /// <summary>
        /// Translate all text from the current language to the selected language.
        /// </summary>
        /// <param name="lang"></param>
        public void goslate(string lang, ListBox lb)
        {
            List<Pair> pairs = enPair(lb);
            List<String> lefts = getWords(pairs);
            string script;

            if (lang == "ge")
                script = "toGerm.py";
            else if (lang == "sp")
                script = "toSpan.py";
            else if (lang == "fr")
                script = "toFren.py";
            else
                script = "toEng.py";


            var scriptRuntime = Python.CreateRuntime();
            var pythEng = scriptRuntime.GetEngine("Python");
            var source = pythEng.CreateScriptSourceFromFile(script);
            var scope = pythEng.CreateScope();


            scope.SetVariable("l", lefts);
            source.Execute(scope);
            lb.Items.Clear();
            List<string> trans = scope.GetVariable("ret");

            for (int i = 0; i < trans.Count; i++)
                lb.Items.Add(trans[i] + " " + pairs[i].b);

        }

        /*
        var scriptRuntime = Python.CreateRuntime();
        var pythEng = scriptRuntime.GetEngine("Python");
        var source = pythEng.CreateScriptSourceFromFile(script);
        var scope = pythEng.CreateScope();

        scope.SetVariable("l", 17.65);
        scope.SetVariable("l", rights);
        source.Execute(scope);

        List<string> cost = scope.GetVariable("l");

        for (int i = 0; i < cost.Count; i++)
            lb.Items.Add(cost[i] + " " + pairs[i].b);
    
        */

        public void translate(string lang, ListBox lb)
        {
            List<Pair> pairs = enPair(lb);
            List<String> lefts = getWords(pairs);
            string script;

            if (lang == "sp")
                script = "toSp.py";
            else
                script = "toEn.py";


            var scriptRuntime = Python.CreateRuntime();
            var pythEng = scriptRuntime.GetEngine("Python");
            var source = pythEng.CreateScriptSourceFromFile(script);
            var scope = pythEng.CreateScope();


            scope.SetVariable("l", lefts);
            //scope.SetVariable("amt", Convert.ToDecimal(textBox2.Text));
            source.Execute(scope);
<<<<<<< HEAD
            lb.Items.Clear();

            List<string> trans = scope.GetVariable("l");

            for(int i=0; i< trans.Count; i++)
                lb.Items.Add(trans[i] + " " + pairs[i].b);


            currentLang = lang;
        }

        /// <summary>
        /// Opens the save meal dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSaveMeal_Click(object sender, EventArgs e)
        {
            //Must have at least one item to create a savemeal.
            if (lbOrder.Items.Count > 0)
            {
                string currentMeal = "";
                foreach (NuWayMenuItem item in lbOrder.Items)
                {
                    currentMeal += item.ToString() + ";";
                }
                saveMeal.MealSelect = currentMeal;
                saveMeal.ShowDialog();
            }
            else
            {
                MessageBox.Show("No meal to save.");
            }
            
=======
            //lb.Items.Clear();
            
            List<string> spans = scope.GetVariable("l");
            lb.BeginUpdate();
            try
            {
                double price;
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    lb.SelectedIndex = i;
                    price = double.Parse((lb.Items[i] as NuWayMenuItem).ItemPrice.Substring(1));
                    if (currentLang.CompareTo(lang)!= 0)
                    {
                        if (currentLang.CompareTo("en") == 0)
                            price = price * exchange;
                        else
                            price = price / exchange;
                    }
                    NuWayMenuItem tempNMI = new NuWayMenuItem(spans[i], (lb.Items[i] as NuWayMenuItem).ItemDesc, "$" + price);
                    lb.ClearSelected();
                    lb.SelectedIndex = i;
                    lb.Items[i] = tempNMI;
                }
            }
            finally
            {
                lb.EndUpdate();
                lb.Refresh();
            }
            if (lb.Items.Count > 0)
                lb.SelectedIndex = 0;
            //for(int i=0; i<spans.Count; i++)
             //   lb.Items.Add(spans[i] + "" + pairs[i].b);

        }

        /// <summary>
        /// Opens the save meal dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSaveMeal_Click(object sender, EventArgs e)
        {
            //Must have at least one item to create a savemeal.
            if (lbOrder.Items.Count > 0)
            {
                string currentMeal = "";
                foreach (NuWayMenuItem item in lbOrder.Items)
                {
                    currentMeal += item.ToString() + ";";
                }
                saveMeal.MealSelect = currentMeal;
                saveMeal.ShowDialog();
            }
            else
            {
                MessageBox.Show("No meal to save.");
            }
            
>>>>>>> 3fb699f304410aeeda84a8ad68574a6dd60f8514
        }

        public void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            translate("sp", lbBreakfast);
            translate("sp", lbDessert);
            translate("sp", lbDrinks);
            translate("sp", lbLD);
            translate("sp", lbOrder);
            currentLang = "sp";
            Total();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            translate("en", lbBreakfast);
            translate("en", lbDessert);
            translate("en", lbDrinks);
            translate("en", lbLD);
            translate("en", lbOrder);
            currentLang = "en";
            Total();
        }
<<<<<<< HEAD
    }


    /// <summary>
    /// Helper class for displaying descriptions.
    /// </summary>
    public class NuWayMenuItem
    {
        string itemName;
        string itemDesc;
        string itemPrice;

        public NuWayMenuItem(string itemName, string itemDesc, string itemPrice)
        {
            this.itemName = itemName;
            this.itemDesc = itemDesc;
            this.itemPrice = itemPrice;
        }

        public override string ToString()
        {
            return itemName + " " + itemPrice;
        }

        public string ItemDesc { get { return itemDesc; } }
        public string ItemName { get { return itemName; } }
    }

=======
    }


    /// <summary>
    /// Helper class for displaying descriptions.
    /// </summary>
    public class NuWayMenuItem
    {
        string itemName;
        string itemDesc;
        string itemPrice;

        public NuWayMenuItem(string itemName, string itemDesc, string itemPrice)
        {
            this.itemName = itemName;
            this.itemDesc = itemDesc;
            this.itemPrice = itemPrice;
        }

        public override string ToString()
        {
            return itemName + " " + format(itemPrice);
        }

        public String format(String amount)
        {
            //if amount not blank
            if (amount.Length > 0)
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
                    else if (amount.IndexOf('.') < amount.Length - 3)
                        return amount.Substring(0, amount.IndexOf('.') + 3);
                }
                else
                    return amount += ".00";
            }

            return amount;
        }

        public string ItemDesc { get { return itemDesc; } }
        public string ItemName { get { return itemName; }
            set { itemName = value; }
        }
        public string ItemPrice { get { return itemPrice; } }
    }

>>>>>>> 3fb699f304410aeeda84a8ad68574a6dd60f8514
    public class Pair
    {
        public string a { get; set; }
        public string b { get; set; }

        public Pair(string a, string b)
        {
            this.a = a;
            this.b = b;
        }
<<<<<<< HEAD
    }

}
=======
    }

    public class LoginDialogService : IMessageBoxService
    {
        LoginForm login;

        public LoginDialogService(LoginForm login)
        {
            this.login = login;
        }

        public void Show(string message)
        {
            login.ShowDialog();
        }
    }
}
>>>>>>> 3fb699f304410aeeda84a8ad68574a6dd60f8514
