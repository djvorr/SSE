namespace NuWay
{
    partial class NuWayOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bClear = new System.Windows.Forms.Button();
            this.bTotal = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.bDessert = new System.Windows.Forms.Button();
            this.bDrinks = new System.Windows.Forms.Button();
            this.bLD = new System.Windows.Forms.Button();
            this.bBreakfast = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.tbTax = new System.Windows.Forms.TextBox();
            this.tbSubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDessert = new System.Windows.Forms.ListBox();
            this.lbDrinks = new System.Windows.Forms.ListBox();
            this.lbLD = new System.Windows.Forms.ListBox();
            this.lbBreakfast = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbBreakfast = new System.Windows.Forms.TextBox();
            this.tbDessert = new System.Windows.Forms.TextBox();
            this.tbDrink = new System.Windows.Forms.TextBox();
            this.tbLD = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.bMyMeals = new System.Windows.Forms.Button();
            this.bSaveMeal = new System.Windows.Forms.Button();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(473, 426);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(89, 20);
            this.bClear.TabIndex = 45;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bTotal
            // 
            this.bTotal.Location = new System.Drawing.Point(568, 426);
            this.bTotal.Name = "bTotal";
            this.bTotal.Size = new System.Drawing.Size(89, 20);
            this.bTotal.TabIndex = 44;
            this.bTotal.Text = "Order";
            this.bTotal.UseVisualStyleBackColor = true;
            this.bTotal.Click += new System.EventHandler(this.bTotal_Click);
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(378, 426);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(89, 20);
            this.bRemove.TabIndex = 43;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bDessert
            // 
            this.bDessert.Location = new System.Drawing.Point(568, 143);
            this.bDessert.Name = "bDessert";
            this.bDessert.Size = new System.Drawing.Size(89, 20);
            this.bDessert.TabIndex = 42;
            this.bDessert.Text = "Add";
            this.bDessert.UseVisualStyleBackColor = true;
            this.bDessert.Click += new System.EventHandler(this.bDessert_Click);
            // 
            // bDrinks
            // 
            this.bDrinks.Location = new System.Drawing.Point(243, 553);
            this.bDrinks.Name = "bDrinks";
            this.bDrinks.Size = new System.Drawing.Size(89, 20);
            this.bDrinks.TabIndex = 41;
            this.bDrinks.Text = "Add";
            this.bDrinks.UseVisualStyleBackColor = true;
            this.bDrinks.Click += new System.EventHandler(this.bDrinks_Click);
            // 
            // bLD
            // 
            this.bLD.Location = new System.Drawing.Point(243, 426);
            this.bLD.Name = "bLD";
            this.bLD.Size = new System.Drawing.Size(89, 20);
            this.bLD.TabIndex = 40;
            this.bLD.Text = "Add";
            this.bLD.UseVisualStyleBackColor = true;
            this.bLD.Click += new System.EventHandler(this.bLD_Click);
            // 
            // bBreakfast
            // 
            this.bBreakfast.Location = new System.Drawing.Point(243, 195);
            this.bBreakfast.Name = "bBreakfast";
            this.bBreakfast.Size = new System.Drawing.Size(89, 20);
            this.bBreakfast.TabIndex = 39;
            this.bBreakfast.Text = "Add";
            this.bBreakfast.UseVisualStyleBackColor = true;
            this.bBreakfast.Click += new System.EventHandler(this.bBreakfast_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 528);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Subtotal";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(507, 566);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(150, 20);
            this.tbTotal.TabIndex = 35;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTax
            // 
            this.tbTax.Location = new System.Drawing.Point(507, 525);
            this.tbTax.Name = "tbTax";
            this.tbTax.Size = new System.Drawing.Size(150, 20);
            this.tbTax.TabIndex = 34;
            this.tbTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSubtotal
            // 
            this.tbSubtotal.Location = new System.Drawing.Point(507, 485);
            this.tbSubtotal.Name = "tbSubtotal";
            this.tbSubtotal.Size = new System.Drawing.Size(150, 20);
            this.tbSubtotal.TabIndex = 33;
            this.tbSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Cart:";
            // 
            // lbOrder
            // 
            this.lbOrder.FormattingEnabled = true;
            this.lbOrder.Location = new System.Drawing.Point(378, 169);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(279, 251);
            this.lbOrder.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Dessert";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Drinks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Lunch/Dinner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Breakfast";
            // 
            // lbDessert
            // 
            this.lbDessert.FormattingEnabled = true;
            this.lbDessert.Location = new System.Drawing.Point(378, 58);
            this.lbDessert.Name = "lbDessert";
            this.lbDessert.Size = new System.Drawing.Size(279, 56);
            this.lbDessert.TabIndex = 26;
            this.lbDessert.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            this.lbDessert.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDessert_MouseDoubleClick);
            // 
            // lbDrinks
            // 
            this.lbDrinks.FormattingEnabled = true;
            this.lbDrinks.Location = new System.Drawing.Point(14, 452);
            this.lbDrinks.Name = "lbDrinks";
            this.lbDrinks.Size = new System.Drawing.Size(318, 69);
            this.lbDrinks.TabIndex = 25;
            this.lbDrinks.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            this.lbDrinks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDrinks_MouseDoubleClick);
            // 
            // lbLD
            // 
            this.lbLD.FormattingEnabled = true;
            this.lbLD.Location = new System.Drawing.Point(14, 221);
            this.lbLD.Name = "lbLD";
            this.lbLD.Size = new System.Drawing.Size(318, 173);
            this.lbLD.TabIndex = 24;
            this.lbLD.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            this.lbLD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLD_MouseDoubleClick);
            // 
            // lbBreakfast
            // 
            this.lbBreakfast.FormattingEnabled = true;
            this.lbBreakfast.Location = new System.Drawing.Point(14, 58);
            this.lbBreakfast.Name = "lbBreakfast";
            this.lbBreakfast.Size = new System.Drawing.Size(318, 108);
            this.lbBreakfast.TabIndex = 23;
            this.lbBreakfast.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            this.lbBreakfast.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbBreakfast_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.translateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.signInToolStripMenuItem.Text = "Sign In";
            this.signInToolStripMenuItem.Click += new System.EventHandler(this.signInToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem});
            this.adminToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.spanishToolStripMenuItem});
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            this.translateToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.translateToolStripMenuItem.Text = "Translate";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // tbBreakfast
            // 
            this.tbBreakfast.Location = new System.Drawing.Point(14, 169);
            this.tbBreakfast.Name = "tbBreakfast";
            this.tbBreakfast.ReadOnly = true;
            this.tbBreakfast.Size = new System.Drawing.Size(318, 20);
            this.tbBreakfast.TabIndex = 47;
            // 
            // tbDessert
            // 
            this.tbDessert.Location = new System.Drawing.Point(379, 117);
            this.tbDessert.Name = "tbDessert";
            this.tbDessert.ReadOnly = true;
            this.tbDessert.Size = new System.Drawing.Size(278, 20);
            this.tbDessert.TabIndex = 48;
            // 
            // tbDrink
            // 
            this.tbDrink.Location = new System.Drawing.Point(14, 527);
            this.tbDrink.Name = "tbDrink";
            this.tbDrink.ReadOnly = true;
            this.tbDrink.Size = new System.Drawing.Size(317, 20);
            this.tbDrink.TabIndex = 50;
            // 
            // tbLD
            // 
            this.tbLD.Location = new System.Drawing.Point(14, 398);
            this.tbLD.Name = "tbLD";
            this.tbLD.ReadOnly = true;
            this.tbLD.Size = new System.Drawing.Size(317, 20);
            this.tbLD.TabIndex = 51;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(451, 24);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(75, 13);
            this.LoginLabel.TabIndex = 52;
            this.LoginLabel.Text = "Not Logged In";
            // 
            // bMyMeals
            // 
            this.bMyMeals.Enabled = false;
            this.bMyMeals.Location = new System.Drawing.Point(582, 19);
            this.bMyMeals.Name = "bMyMeals";
            this.bMyMeals.Size = new System.Drawing.Size(75, 23);
            this.bMyMeals.TabIndex = 53;
            this.bMyMeals.Text = "My Meals";
            this.bMyMeals.UseVisualStyleBackColor = true;
            this.bMyMeals.Click += new System.EventHandler(this.bMyMeals_Click);
            // 
            // bSaveMeal
            // 
            this.bSaveMeal.Enabled = false;
            this.bSaveMeal.Location = new System.Drawing.Point(379, 452);
            this.bSaveMeal.Name = "bSaveMeal";
            this.bSaveMeal.Size = new System.Drawing.Size(278, 23);
            this.bSaveMeal.TabIndex = 54;
            this.bSaveMeal.Text = "Save Meal";
            this.bSaveMeal.UseVisualStyleBackColor = true;
            this.bSaveMeal.Click += new System.EventHandler(this.bSaveMeal_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // NuWayOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 598);
            this.Controls.Add(this.bSaveMeal);
            this.Controls.Add(this.bMyMeals);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.tbLD);
            this.Controls.Add(this.tbDrink);
            this.Controls.Add(this.tbDessert);
            this.Controls.Add(this.tbBreakfast);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bTotal);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bDessert);
            this.Controls.Add(this.bDrinks);
            this.Controls.Add(this.bLD);
            this.Controls.Add(this.bBreakfast);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.tbTax);
            this.Controls.Add(this.tbSubtotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDessert);
            this.Controls.Add(this.lbDrinks);
            this.Controls.Add(this.lbLD);
            this.Controls.Add(this.lbBreakfast);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NuWayOrderForm";
            this.Text = "NuWay Order Form";
            this.Load += new System.EventHandler(this.NuWayOrderForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bTotal;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bDessert;
        private System.Windows.Forms.Button bDrinks;
        private System.Windows.Forms.Button bLD;
        private System.Windows.Forms.Button bBreakfast;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.TextBox tbTax;
        private System.Windows.Forms.TextBox tbSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDessert;
        private System.Windows.Forms.ListBox lbDrinks;
        private System.Windows.Forms.ListBox lbLD;
        private System.Windows.Forms.ListBox lbBreakfast;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.TextBox tbBreakfast;
        private System.Windows.Forms.TextBox tbDessert;
        private System.Windows.Forms.TextBox tbDrink;
        private System.Windows.Forms.TextBox tbLD;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button bMyMeals;
        private System.Windows.Forms.Button bSaveMeal;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
    }
}

