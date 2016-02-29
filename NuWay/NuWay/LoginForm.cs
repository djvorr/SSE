using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace NuWay
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// user exists in database
        /// </summary>
        public bool isAuthentic { get; set; }

        /// <summary>
        /// user has admin priviledges
        /// </summary>
        public bool isAdministrator { get; set; }

        /// <summary>
        /// encrypted role of currently signed in user
        /// </summary>
        public string currentRole { get; set; }

        public string CurrentUser { get; set; }

        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;

        En_De_cryption cryptographer = new En_De_cryption();
        Key key = new Key();

        protected string sharedPrivateKey = "Louisville";

        /// <summary>
        /// On Creation of Login Form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
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

            tbUser.Text = "";
            tbPass.Text = "";
        }

        /// <summary>
        /// Check the Database to make sure user exists.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if exists, false if doesn't</returns>
        public bool AuthenticateAdministrator(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            return db.userExists(encrypteduser, encryptedpassword);
        }

        /// <summary>
        /// Ensure the user has the adminstrator role
        /// </summary>
        /// <param name="encrypeduser"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns>True if user has admin role</returns>
        public bool AuthenticateAdminRole(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            //the encrypted role of the user == the encryption of "administrator" using the decryption of the stored encrypted key as the passphrase.
            return db.getRole(encrypteduser, encryptedpassword) == cryptographer.EncryptString("administrator", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
        }

        /// <summary>
        /// Check the Database to make sure user exists.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if exists, false if doesn't</returns>
        public bool AuthenticateUser(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            return db.userExists(encrypteduser, encryptedpassword);
        }

        /// <summary>
        /// Get the role of the user from the db
        /// </summary>
        /// <param name="encrypteduser"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns></returns>
        public string getRole(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            if (db.userExists(encrypteduser, encryptedpassword))
                return db.getRole(encrypteduser, encryptedpassword);
            return null;
        }

        /// <summary>
        /// Ensure the user has the freeuser role
        /// </summary>
        /// <param name="encrypeduser"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns>True if user has the role freeuser</returns>
        public bool AuthenticateFreeRole(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            //the encrypted role of the user == the encryption of "freeuser" using the decryption of the stored encrypted key as the passphrase.
            return db.getRole(encrypteduser, encryptedpassword) == cryptographer.EncryptString("freeuser", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
        }

        /// <summary>
        /// Ensure the user has the subscriber role
        /// </summary>
        /// <param name="encrypeduser"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns>True if user has the subscriber role</returns>
        public bool AuthenticateSubscribeRole(string encrypteduser, string encryptedpassword)
        {
            UserDB db = new UserDB();
            //the encrypted role of the user == the encryption of "administrator" using the decryption of the stored encrypted key as the passphrase.
            return db.getRole(encrypteduser, encryptedpassword) == cryptographer.EncryptString("administrator", cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
        }

        /// <summary>
        /// Clicking the Sign in button and authenticate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSignIn_Click(object sender, EventArgs e)
        {
            string encrypteduser = cryptographer.EncryptString(tbUser.Text, cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            string encryptedpass = cryptographer.EncryptString(tbPass.Text, cryptographer.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            CurrentUser = tbUser.Text;

            //normal user
            if (!cbAdmin.Checked)
            {
                if (AuthenticateUser(encrypteduser, encryptedpass))
                {
                    MessageBox.Show("User Signed in");
                    isAuthentic = true;
                    currentRole = getRole(encrypteduser, encryptedpass);
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                    CurrentUser = "";
                }
            }
            //admin user
            else
            {
                if (AuthenticateAdministrator(encrypteduser, encryptedpass) && AuthenticateAdminRole(encrypteduser, encryptedpass))
                {
                    MessageBox.Show("Admin Signed in");
                    isAuthentic = true;
                    isAdministrator = true;
                    currentRole = getRole(encrypteduser, encryptedpass);
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid Admin Credentials");
                    CurrentUser = "";
                }
            }
        }
    }
}
