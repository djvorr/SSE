namespace NuWay
{
    partial class MyMealForm
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
            this.lbMealNum = new System.Windows.Forms.ListBox();
            this.tbMeal = new System.Windows.Forms.TextBox();
            this.bSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMealNum
            // 
            this.lbMealNum.FormattingEnabled = true;
            this.lbMealNum.Location = new System.Drawing.Point(16, 10);
            this.lbMealNum.Name = "lbMealNum";
            this.lbMealNum.Size = new System.Drawing.Size(84, 186);
            this.lbMealNum.TabIndex = 0;
            this.lbMealNum.SelectedIndexChanged += new System.EventHandler(this.lbMealNum_SelectedIndexChanged);
            // 
            // tbMeal
            // 
            this.tbMeal.Location = new System.Drawing.Point(106, 10);
            this.tbMeal.Multiline = true;
            this.tbMeal.Name = "tbMeal";
            this.tbMeal.Size = new System.Drawing.Size(251, 160);
            this.tbMeal.TabIndex = 1;
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(282, 176);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(75, 23);
            this.bSelect.TabIndex = 2;
            this.bSelect.Text = "Select";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // MyMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 203);
            this.Controls.Add(this.bSelect);
            this.Controls.Add(this.tbMeal);
            this.Controls.Add(this.lbMealNum);
            this.Name = "MyMealForm";
            this.Text = "My Meals";
            this.Load += new System.EventHandler(this.MyMealForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMealNum;
        private System.Windows.Forms.TextBox tbMeal;
        private System.Windows.Forms.Button bSelect;
    }
}