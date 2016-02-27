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

        private string key;

        UserDB db = new UserDB();
        En_De_cryption crypter = new En_De_cryption();

        public AddUser(string key)
        {
            this.key = key;
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// saves encrypted info if not found
        /// </summary>
        /// <param name="encuser"></param>
        /// <param name="encpass"></param>
        /// <param name="encrole"></param>
        public void Save(string encuser, string encpass, string encrole)
        {
            if (!db.userExists(encuser, encpass))
                db.addUser(encuser, encpass, encrole);
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
            Save(crypter.EncryptString(tbUser.Text, key), crypter.EncryptString(tbPass.Text, key), crypter.EncryptString(tbRole.Text, key));
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
