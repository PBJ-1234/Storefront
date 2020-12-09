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
            this.bankcheckButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.cost = new System.Windows.Forms.Label();
            this.cashButton = new System.Windows.Forms.Button();
            this.creditCardButton = new System.Windows.Forms.Button();
            this.FinalGridView = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FinalGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(108, 339);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(105, 31);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "Total: $";
            // 
            // bankcheckButton
            // 
            this.bankcheckButton.Location = new System.Drawing.Point(453, 253);
            this.bankcheckButton.Name = "bankcheckButton";
            this.bankcheckButton.Size = new System.Drawing.Size(75, 23);
            this.bankcheckButton.TabIndex = 2;
            this.bankcheckButton.Text = "Bank Check";
            this.bankcheckButton.UseVisualStyleBackColor = true;
            this.bankcheckButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.useBankCheck);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(682, 415);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 3;
            this.returnButton.Text = "Go Back";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.returnToStore);
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost.Location = new System.Drawing.Point(209, 339);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(67, 31);
            this.cost.TabIndex = 4;
            this.cost.Text = "0.00";
            // 
            // cashButton
            // 
            this.cashButton.Location = new System.Drawing.Point(453, 156);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(75, 23);
            this.cashButton.TabIndex = 5;
            this.cashButton.Text = "Checkout";
            this.cashButton.UseVisualStyleBackColor = true;
            this.cashButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.useWallet);
            // 
            // creditCardButton
            // 
            this.creditCardButton.Location = new System.Drawing.Point(453, 205);
            this.creditCardButton.Name = "creditCardButton";
            this.creditCardButton.Size = new System.Drawing.Size(75, 23);
            this.creditCardButton.TabIndex = 6;
            this.creditCardButton.Text = "Credit Card";
            this.creditCardButton.UseVisualStyleBackColor = true;
            this.creditCardButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.useCreditCard);
            // 
            // FinalGridView
            // 
            this.FinalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemCost,
            this.ItemAmount,
            this.StoreName});
            this.FinalGridView.Location = new System.Drawing.Point(112, 156);
            this.FinalGridView.Name = "FinalGridView";
            this.FinalGridView.Size = new System.Drawing.Size(335, 150);
            this.FinalGridView.TabIndex = 8;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name:";
            this.ItemName.Name = "ItemName";
            // 
            // ItemCost
            // 
            this.ItemCost.HeaderText = "Price:";
            this.ItemCost.Name = "ItemCost";
            // 
            // ItemAmount
            // 
            this.ItemAmount.HeaderText = "Quan:";
            this.ItemAmount.Name = "ItemAmount";
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Store";
            this.StoreName.Name = "StoreName";
            // 
            // checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FinalGridView);
            this.Controls.Add(this.creditCardButton);
            this.Controls.Add(this.cashButton);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.bankcheckButton);
            this.Controls.Add(this.totalLabel);
            this.Name = "checkout";
            this.Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)(this.FinalGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Button cashButton;
        private System.Windows.Forms.Button creditCardButton;
        private System.Windows.Forms.Button bankcheckButton;
        private System.Windows.Forms.DataGridView FinalGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
    }
}