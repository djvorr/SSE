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
            this.SuspendLayout();
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(473, 391);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(89, 20);
            this.bClear.TabIndex = 45;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bTotal
            // 
            this.bTotal.Location = new System.Drawing.Point(568, 391);
            this.bTotal.Name = "bTotal";
            this.bTotal.Size = new System.Drawing.Size(89, 20);
            this.bTotal.TabIndex = 44;
            this.bTotal.Text = "Finish";
            this.bTotal.UseVisualStyleBackColor = true;
            this.bTotal.Click += new System.EventHandler(this.bTotal_Click);
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(378, 391);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(89, 20);
            this.bRemove.TabIndex = 43;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bDessert
            // 
            this.bDessert.Location = new System.Drawing.Point(568, 108);
            this.bDessert.Name = "bDessert";
            this.bDessert.Size = new System.Drawing.Size(89, 20);
            this.bDessert.TabIndex = 42;
            this.bDessert.Text = "Add";
            this.bDessert.UseVisualStyleBackColor = true;
            this.bDessert.Click += new System.EventHandler(this.bDessert_Click);
            // 
            // bDrinks
            // 
            this.bDrinks.Location = new System.Drawing.Point(243, 518);
            this.bDrinks.Name = "bDrinks";
            this.bDrinks.Size = new System.Drawing.Size(89, 20);
            this.bDrinks.TabIndex = 41;
            this.bDrinks.Text = "Add";
            this.bDrinks.UseVisualStyleBackColor = true;
            this.bDrinks.Click += new System.EventHandler(this.bDrinks_Click);
            // 
            // bLD
            // 
            this.bLD.Location = new System.Drawing.Point(243, 391);
            this.bLD.Name = "bLD";
            this.bLD.Size = new System.Drawing.Size(89, 20);
            this.bLD.TabIndex = 40;
            this.bLD.Text = "Add";
            this.bLD.UseVisualStyleBackColor = true;
            this.bLD.Click += new System.EventHandler(this.bLD_Click);
            // 
            // bBreakfast
            // 
            this.bBreakfast.Location = new System.Drawing.Point(243, 160);
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
            this.label8.Location = new System.Drawing.Point(416, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Tax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Subtotal";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(507, 511);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(150, 20);
            this.tbTotal.TabIndex = 35;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTax
            // 
            this.tbTax.Location = new System.Drawing.Point(507, 470);
            this.tbTax.Name = "tbTax";
            this.tbTax.Size = new System.Drawing.Size(150, 20);
            this.tbTax.TabIndex = 34;
            this.tbTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSubtotal
            // 
            this.tbSubtotal.Location = new System.Drawing.Point(507, 430);
            this.tbSubtotal.Name = "tbSubtotal";
            this.tbSubtotal.Size = new System.Drawing.Size(150, 20);
            this.tbSubtotal.TabIndex = 33;
            this.tbSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Cart:";
            // 
            // lbOrder
            // 
            this.lbOrder.FormattingEnabled = true;
            this.lbOrder.Location = new System.Drawing.Point(378, 134);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(279, 238);
            this.lbOrder.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Dessert";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Drinks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Luch/Dinner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Breakfast";
            // 
            // lbDessert
            // 
            this.lbDessert.FormattingEnabled = true;
            this.lbDessert.Location = new System.Drawing.Point(378, 23);
            this.lbDessert.Name = "lbDessert";
            this.lbDessert.Size = new System.Drawing.Size(279, 82);
            this.lbDessert.TabIndex = 26;
            // 
            // lbDrinks
            // 
            this.lbDrinks.FormattingEnabled = true;
            this.lbDrinks.Location = new System.Drawing.Point(14, 417);
            this.lbDrinks.Name = "lbDrinks";
            this.lbDrinks.Size = new System.Drawing.Size(318, 95);
            this.lbDrinks.TabIndex = 25;
            // 
            // lbLD
            // 
            this.lbLD.FormattingEnabled = true;
            this.lbLD.Location = new System.Drawing.Point(14, 186);
            this.lbLD.Name = "lbLD";
            this.lbLD.Size = new System.Drawing.Size(318, 199);
            this.lbLD.TabIndex = 24;
            // 
            // lbBreakfast
            // 
            this.lbBreakfast.FormattingEnabled = true;
            this.lbBreakfast.Location = new System.Drawing.Point(14, 23);
            this.lbBreakfast.Name = "lbBreakfast";
            this.lbBreakfast.Size = new System.Drawing.Size(318, 134);
            this.lbBreakfast.TabIndex = 23;
            // 
            // NuWayOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 557);
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
            this.Name = "NuWayOrderForm";
            this.Text = "NuWay Order Form";
            this.Load += new System.EventHandler(this.NuWayOrderForm_Load);
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
    }
}

