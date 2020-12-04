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
            this.totalLabel = new System.Windows.Forms.Label();
            this.BankCheck = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.cost = new System.Windows.Forms.Label();
            this.WalletButton = new System.Windows.Forms.Button();
            this.CreditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FinalGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FinalGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(300, 118);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(43, 13);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "Total: $";
            // 
            // BankCheck
            // 
            this.BankCheck.Location = new System.Drawing.Point(453, 253);
            this.BankCheck.Name = "BankCheck";
            this.BankCheck.Size = new System.Drawing.Size(75, 23);
            this.BankCheck.TabIndex = 2;
            this.BankCheck.Text = "Bank Check";
            this.BankCheck.UseVisualStyleBackColor = true;
            this.BankCheck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BankCheckButton_MouseClick);
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
            this.cost.Location = new System.Drawing.Point(340, 118);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(28, 13);
            this.cost.TabIndex = 4;
            this.cost.Text = "0.00";
            // 
            // WalletButton
            // 
            this.WalletButton.Location = new System.Drawing.Point(453, 156);
            this.WalletButton.Name = "WalletButton";
            this.WalletButton.Size = new System.Drawing.Size(75, 23);
            this.WalletButton.TabIndex = 5;
            this.WalletButton.Text = "Checkout";
            this.WalletButton.UseVisualStyleBackColor = true;
            this.WalletButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WalletButton_MouseClick);
            // 
            // CreditButton
            // 
            this.CreditButton.Location = new System.Drawing.Point(453, 205);
            this.CreditButton.Name = "CreditButton";
            this.CreditButton.Size = new System.Drawing.Size(75, 23);
            this.CreditButton.TabIndex = 6;
            this.CreditButton.Text = "Credit Card";
            this.CreditButton.UseVisualStyleBackColor = true;
            this.CreditButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreditButton_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // FinalGridView
            // 
            this.FinalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.FinalGridView.Location = new System.Drawing.Point(112, 156);
            this.FinalGridView.Name = "FinalGridView";
            this.FinalGridView.Size = new System.Drawing.Size(335, 150);
            this.FinalGridView.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FinalGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreditButton);
            this.Controls.Add(this.WalletButton);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.BankCheck);
            this.Controls.Add(this.totalLabel);
            this.Name = "checkout";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FinalGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Button WalletButton;
        private System.Windows.Forms.Button CreditButton;
        private System.Windows.Forms.Button BankCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView FinalGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}