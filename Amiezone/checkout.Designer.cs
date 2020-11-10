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
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.cost = new System.Windows.Forms.Label();
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
            // CheckoutButton
            // 
            this.CheckoutButton.Location = new System.Drawing.Point(303, 304);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(75, 23);
            this.CheckoutButton.TabIndex = 2;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckoutButton_MouseClick);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(303, 369);
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
            // checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.CheckoutButton);
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
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label cost;
    }
}