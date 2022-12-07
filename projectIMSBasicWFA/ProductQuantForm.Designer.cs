namespace projectIMSBasicWFA
{
    partial class ProductQuantForm
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
            this.idLabel = new System.Windows.Forms.Label();
            this.addRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.offsetTextBox = new System.Windows.Forms.TextBox();
            this.subRadioButton = new System.Windows.Forms.RadioButton();
            this.applyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.unitsInStockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(24, 20);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(91, 24);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "current ID";
            // 
            // addRadioButton
            // 
            this.addRadioButton.AutoSize = true;
            this.addRadioButton.Checked = true;
            this.addRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRadioButton.Location = new System.Drawing.Point(35, 64);
            this.addRadioButton.Name = "addRadioButton";
            this.addRadioButton.Size = new System.Drawing.Size(63, 28);
            this.addRadioButton.TabIndex = 1;
            this.addRadioButton.TabStop = true;
            this.addRadioButton.Text = "Add";
            this.addRadioButton.UseVisualStyleBackColor = true;
            this.addRadioButton.CheckedChanged += new System.EventHandler(this.addRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "offset by";
            // 
            // offsetTextBox
            // 
            this.offsetTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetTextBox.Location = new System.Drawing.Point(169, 144);
            this.offsetTextBox.Name = "offsetTextBox";
            this.offsetTextBox.Size = new System.Drawing.Size(165, 29);
            this.offsetTextBox.TabIndex = 3;
            // 
            // subRadioButton
            // 
            this.subRadioButton.AutoSize = true;
            this.subRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subRadioButton.Location = new System.Drawing.Point(170, 64);
            this.subRadioButton.Name = "subRadioButton";
            this.subRadioButton.Size = new System.Drawing.Size(62, 28);
            this.subRadioButton.TabIndex = 4;
            this.subRadioButton.Text = "Sub";
            this.subRadioButton.UseVisualStyleBackColor = true;
            this.subRadioButton.CheckedChanged += new System.EventHandler(this.subRadioButton_CheckedChanged);
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(159, 194);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(175, 43);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current units in stock ";
            // 
            // unitsInStockLabel
            // 
            this.unitsInStockLabel.AutoSize = true;
            this.unitsInStockLabel.Location = new System.Drawing.Point(167, 117);
            this.unitsInStockLabel.Name = "unitsInStockLabel";
            this.unitsInStockLabel.Size = new System.Drawing.Size(35, 13);
            this.unitsInStockLabel.TabIndex = 7;
            this.unitsInStockLabel.Text = "label3";
            // 
            // ProductQuantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 268);
            this.Controls.Add(this.unitsInStockLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.subRadioButton);
            this.Controls.Add(this.offsetTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addRadioButton);
            this.Controls.Add(this.idLabel);
            this.Name = "ProductQuantForm";
            this.Text = "ProductQuantForm";
            this.Load += new System.EventHandler(this.ProductQuantForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.RadioButton addRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox offsetTextBox;
        private System.Windows.Forms.RadioButton subRadioButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label unitsInStockLabel;
    }
}