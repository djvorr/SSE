namespace NuWay
{
    partial class SaveMealForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbMealSelect = new System.Windows.Forms.ListBox();
            this.tbMeal = new System.Windows.Forms.TextBox();
            this.bSelect = new System.Windows.Forms.Button();
            this.tbCurrentMeal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overwrite which meal?";
            // 
            // lbMealSelect
            // 
            this.lbMealSelect.FormattingEnabled = true;
            this.lbMealSelect.Location = new System.Drawing.Point(191, 27);
            this.lbMealSelect.Name = "lbMealSelect";
            this.lbMealSelect.Size = new System.Drawing.Size(74, 160);
            this.lbMealSelect.TabIndex = 1;
            this.lbMealSelect.SelectedIndexChanged += new System.EventHandler(this.lbMealSelect_SelectedIndexChanged);
            // 
            // tbMeal
            // 
            this.tbMeal.Location = new System.Drawing.Point(271, 27);
            this.tbMeal.Multiline = true;
            this.tbMeal.Name = "tbMeal";
            this.tbMeal.ReadOnly = true;
            this.tbMeal.Size = new System.Drawing.Size(232, 137);
            this.tbMeal.TabIndex = 2;
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(403, 170);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(100, 23);
            this.bSelect.TabIndex = 3;
            this.bSelect.Text = "Overwrite";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // tbCurrentMeal
            // 
            this.tbCurrentMeal.Location = new System.Drawing.Point(8, 12);
            this.tbCurrentMeal.Multiline = true;
            this.tbCurrentMeal.Name = "tbCurrentMeal";
            this.tbCurrentMeal.ReadOnly = true;
            this.tbCurrentMeal.Size = new System.Drawing.Size(177, 175);
            this.tbCurrentMeal.TabIndex = 4;
            // 
            // SaveMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 199);
            this.Controls.Add(this.tbCurrentMeal);
            this.Controls.Add(this.bSelect);
            this.Controls.Add(this.tbMeal);
            this.Controls.Add(this.lbMealSelect);
            this.Controls.Add(this.label1);
            this.Name = "SaveMealForm";
            this.Text = "SaveMealForm";
            this.Load += new System.EventHandler(this.SaveMealForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbMealSelect;
        private System.Windows.Forms.TextBox tbMeal;
        private System.Windows.Forms.Button bSelect;
        private System.Windows.Forms.TextBox tbCurrentMeal;
    }
}