using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace NuWay
{
    public partial class LoginForm : Form
    {
        public bool isAuthentic { get; set; }
        public bool isAdministrator { get; set; }

        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;

        En_De_cryption cryptographer = new En_De_cryption();

        /// <summary>
        /// On Creation of Login Form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Call to En(De)cryption class to encrypt a text with a passphrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="passphrase"></param>
        /// <returns></returns>
        public string Encrypt(string text, string passphrase)
        {
            return cryptographer.EncryptString(text, passphrase);
        }

        /// <summary>
        /// Call to En(De)cryption class to decrypt a text with a passphrase
        /// </summary>
        /// <param name="text"></param>
        /// <param name="passphrase"></param>
        /// <returns></returns>
        public string Decrypt(string text, string passphrase)
        {
            return cryptographer.DecryptString(text, passphrase);
        }

        /// <summary>
        /// Return the role of the user if found
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string getRole(string user, string password)
        {
            string role = "";
            string selectString = "SELECT User, Password, Role FROM Roles WHERE User = '" + user + "' and Password = '" + password + "'";

            conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source= users.mdb;";

            try
            {
                conn.Open();

                cmd = new OleDbCommand(selectString, conn);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    role = reader["Role"].ToString();
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

            return role;
        }

        /// <summary>
        /// Check the Database to make sure user exists.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if exists, false if doesn't</returns>
        public bool Authenticate(string user, string password)
        {
            return (getRole(user, password) != "");
        }

        /// <summary>
        /// (Un)Check the checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAdmin_Click(object sender, EventArgs e)
        {
            if (cbAdmin.Checked == true)
            {
                lAdmin.Visible = true;
                tbKey.Visible = true;
                tbKey.Text = "";
            }
            else
            {
                lAdmin.Visible = false;
                tbKey.Visible = false;
            }
        }

        /// <summary>
        /// On loading of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            isAuthentic = false;
            isAdministrator = false;
            //AddUser au = new AddUser("Kentucky");
            //au.ShowDialog();        
        }

        /// <summary>
        /// Clicking the Sign in button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSignIn_Click(object sender, EventArgs e)
        {
            //normal user
            if(!cbAdmin.Checked)
            {
                if(tbUser.Text == "dave" && tbPass.Text == "pass")
                {
                    MessageBox.Show("User Signed in");
                    isAuthentic = true;
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
            //admin user
            else
            {
                if (tbUser.Text == "dave" && tbPass.Text == "pass")
                {
                    MessageBox.Show("Admin Signed in");
                    isAuthentic = true;
                    isAdministrator = true;
                }
                else
                {
                    MessageBox.Show("Invalid Admin Credentials");
                }
            }
        }
    }
}
