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
    public partial class AddUser : Form
    {
        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;

        Key key;
        protected string sharedPrivateKey = "Louisville";

        UserDB db;
        En_De_cryption crypter;

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            db = new UserDB();
            crypter = new En_De_cryption();
            key = new Key();
        }

        /// <summary>
        /// saves encrypted info if not found
        /// </summary>
        /// <param name="encuser"></param>
        /// <param name="encpass"></param>
        /// <param name="encrole"></param>
        public void Save(string encuser, string encpass, string encrole)
        {
            if (!db.userExists(encuser, encpass) && !db.userTaken(encuser))
            {
                db.addUser(encuser, encpass, encrole);
                MessageBox.Show("Addition Successful");
            }
            else if (db.userExists(encuser, encpass))
                MessageBox.Show("You already have an account.");
            else if (db.userTaken(encuser))
                MessageBox.Show("Username already taken.");
            else
                MessageBox.Show("Error");
        }

        /// <summary>
        /// Save botton clicked. encrypts the info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSave_Click(object sender, EventArgs e)
        {
            //It is important to note that only encrypted vales are stored in variables. The unencrypted values are not stored anywhere.
            string enuser = crypter.EncryptString(tbUser.Text, crypter.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            string enpass = crypter.EncryptString(tbPass.Text, crypter.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            string enrole = crypter.EncryptString(tbRole.Text, crypter.DecryptString(key.EncryptedKey(), sharedPrivateKey));
            Save(enuser, enpass, enrole);
        }

        /// <summary>
        /// done button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDone_Click(object sender, EventArgs e)
        {
            db.writeDb();
            Close();
        }
    }
}
