namespace Amiezone
{
    partial class checkout
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
            this.finalItemList = new System.Windows.Forms.CheckedListBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.BankButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.cost = new System.Windows.Forms.Label();
            this.WalletButton = new System.Windows.Forms.Button();
            this.CreditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finalItemList
            // 
            this.finalItemList.FormattingEnabled = true;
            this.finalItemList.Location = new System.Drawing.Point(303, 173);
            this.finalItemList.Name = "finalItemList";
            this.finalItemList.Size = new System.Drawing.Size(120, 94);
            this.finalItemList.TabIndex = 0;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(300, 118);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(34, 13);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "Total:";
            // 
            // BankButton
            // 
            this.BankButton.Location = new System.Drawing.Point(453, 253);
            this.BankButton.Name = "BankButton";
            this.BankButton.Size = new System.Drawing.Size(75, 23);
            this.BankButton.TabIndex = 2;
            this.BankButton.Text = "Checkout";
            this.BankButton.UseVisualStyleBackColor = true;
            this.BankButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckoutButton_MouseClick);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(682, 415);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 3;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.returnButton_MouseClick);
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Location = new System.Drawing.Point(392, 118);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(34, 13);
            this.cost.TabIndex = 4;
            this.cost.Text = "0.00$";
            // 
            // WalletButton
            // 
            this.WalletButton.Location = new System.Drawing.Point(453, 156);
            this.WalletButton.Name = "WalletButton";
            this.WalletButton.Size = new System.Drawing.Size(75, 23);
            this.WalletButton.TabIndex = 5;
            this.WalletButton.Text = "Checkout";
            this.WalletButton.UseVisualStyleBackColor = true;
            // 
            // CreditButton
            // 
            this.CreditButton.Location = new System.Drawing.Point(453, 205);
            this.CreditButton.Name = "CreditButton";
            this.CreditButton.Size = new System.Drawing.Size(75, 23);
            this.CreditButton.TabIndex = 6;
            this.CreditButton.Text = "Credit Card";
            this.CreditButton.UseVisualStyleBackColor = true;
            // 
            // checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreditButton);
            this.Controls.Add(this.WalletButton);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.BankButton);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.finalItemList);
            this.Name = "checkout";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox finalItemList;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button BankButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Button CreditButton;
    }
}