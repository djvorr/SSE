using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuWay
{
    public partial class PlaceOrderForm : Form
    {
        public PlaceOrderForm(string total)
        {
            InitializeComponent();
            tbTotal.Text = total;
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// click on the place button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bPlace_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
                MessageBox.Show("Name is Required.");
            else
            {
                MessageBox.Show("Thanks, " + tbName.Text + ". Pick up is at " + dtTime.Text + ". The total is " + tbTotal.Text + ". See you soon!");
                Close();
            }
        }
    }
}
