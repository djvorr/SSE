using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueensAndJacks
{
    public partial class Board : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;

        List<Button> hand = new List<Button>();
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        List<Button> board = new List<Button>();

        public bool picked = false;
        private TextBox textBox4;
        Card card;

        public Board()
        {
            InitializeComponent();
            disenableCards();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 81);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(230, 233);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 81);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(290, 233);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 81);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(350, 233);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 81);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(178, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(178, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // Board
            // 
            this.ClientSize = new System.Drawing.Size(481, 395);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Board";
            this.Load += new System.EventHandler(this.Board_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Board_Load_1(object sender, EventArgs e)
        {

        }

        public void enableCards()
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Enabled = true;
            }
        }

        public void disenableCards()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Enabled = false;
            }
        }

        public Card getPickedCard()
        {
            picked = false;
            return card;
        }

        public void clearButtons()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Text = "";
            }
        }



        /*
        /// <summary>
        /// Assigns all the buttons to collection for processing.
        /// </summary>
        public void mountButtons()
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    board.Add((Button)c);
                }
            }

            
            hand.Add(button1);
            hand.Add(button2);
            hand.Add(button3);
            hand.Add(button4);
            hand.Add(button5);
            hand.Add(button6);

            board.Add(button7);
            board.Add(button8);
            board.Add(button9);
        }
    */

        public void drawBoard(List<Card> cards)
        {
            int i = 0;
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (i < cards.Count)
                    {
                        c.Text = cards[i].getSuit() + cards[i].getFace();
                        i += 1;
                    }
                    else
                        c.Text = "";
                }
            }
        }

        /// <summary>
        /// Draws the card suit and face on the respective button.
        /// </summary>
        /// <param name="h"></param>
        public void drawHand(Hand h)
        {
            List<Card> cards = h.getCards();

            //button1.Text = "derp";
            /*
            for (int i = 0; i < hand.Count; i++)
            {
                if (i < cards.Count)
                {
                    ((Button)hand[i]).Text = cards[i].getSuit() + cards[i].getFace();
                    ((Button)hand[i]).Enabled = true;
                }
                else
                {
                    ((Button)hand[i]).Text = "";
                    ((Button)hand[i]).Enabled = false;
                }
            }*/

            int i = 0;

            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    if (i < h.getCards().Count)
                    {
                        if (cards[i].getFace().Length > 0)
                        {
                            ((Button)c).Text = cards[i].getSuit() + cards[i].getFace();
                            i++;
                        }
                    }
                    else
                        ((Button)c).Text = "";
                }
            }
        }

        /// <summary>
        /// Returns the button list for the hand.
        /// </summary>
        /// <returns></returns>
        public List<Button> getHand()
        {
            hand.Clear();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    hand.Add((Button)c);
                }
            }
            return hand;
        }

        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Length > 0)
            {
                if (button1.Text.Length == 3)
                    card = new Card(button1.Text[0], button1.Text[1].ToString() + button1.Text[2].ToString());
                else
                    card = new Card(button1.Text[0], button1.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Length > 0)
            {
                if (button2.Text.Length == 3)
                    card = new Card(button2.Text[0], button2.Text[1].ToString() + button2.Text[2].ToString());
                else
                    card = new Card(button2.Text[0], button2.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text.Length > 0)
            {
                if (button3.Text.Length == 3)
                    card = new Card(button3.Text[0], button3.Text[1].ToString() + button3.Text[2].ToString());
                else
                    card = new Card(button3.Text[0], button3.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text.Length > 0)
            {
                if (button4.Text.Length == 3)
                    card = new Card(button4.Text[0], button4.Text[1].ToString() + button4.Text[2].ToString());
                else
                    card = new Card(button4.Text[0], button4.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Length > 0)
            {
                if (button5.Text.Length == 3)
                    card = new Card(button5.Text[0], button5.Text[1].ToString() + button5.Text[2].ToString());
                else
                    card = new Card(button5.Text[0], button5.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text.Length > 0)
            {
                if (button6.Text.Length == 3)
                    card = new Card(button6.Text[0], button6.Text[1].ToString() + button6.Text[2].ToString());
                else
                    card = new Card(button6.Text[0], button6.Text[1].ToString());

                picked = true;
                disenableCards();
                this.Close();
            }
        }

        #endregion
    }
}
