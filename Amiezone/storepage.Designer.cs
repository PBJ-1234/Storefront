namespace Amiezone
{
    partial class storepage
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
            this.itemPicture = new System.Windows.Forms.PictureBox();
            this.ItemBox = new System.Windows.Forms.ListBox();
            this.StoreBox = new System.Windows.Forms.ListBox();
            this.CategoryBox = new System.Windows.Forms.ListBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.userInfoBox = new System.Windows.Forms.RichTextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.storeLabel = new System.Windows.Forms.Label();
            this.totalSoFarLabel = new System.Windows.Forms.Label();
            this.orderButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPicture
            // 
            this.itemPicture.Location = new System.Drawing.Point(62, 146);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(107, 212);
            this.itemPicture.TabIndex = 3;
            this.itemPicture.TabStop = false;
            // 
            // ItemBox
            // 
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.Items.AddRange(new object[] {
            "thing one",
            "thing two",
            "gointo data items to edit"});
            this.ItemBox.Location = new System.Drawing.Point(469, 146);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(258, 212);
            this.ItemBox.TabIndex = 4;
            this.ItemBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemBox_MouseClick);
            // 
            // StoreBox
            // 
            this.StoreBox.FormattingEnabled = true;
            this.StoreBox.Location = new System.Drawing.Point(469, 96);
            this.StoreBox.Name = "StoreBox";
            this.StoreBox.Size = new System.Drawing.Size(258, 17);
            this.StoreBox.TabIndex = 5;
            // 
            // CategoryBox
            // 
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(469, 47);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(258, 43);
            this.CategoryBox.TabIndex = 6;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(206, 146);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(181, 212);
            this.descriptionBox.TabIndex = 7;
            this.descriptionBox.Text = "";
            // 
            // userInfoBox
            // 
            this.userInfoBox.Location = new System.Drawing.Point(62, 27);
            this.userInfoBox.Name = "userInfoBox";
            this.userInfoBox.Size = new System.Drawing.Size(154, 98);
            this.userInfoBox.TabIndex = 8;
            this.userInfoBox.Text = "";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(469, 18);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(126, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create Store";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.createButton_MouseClick);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(601, 18);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(126, 23);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load from file";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadButton_MouseClick);
            // 
            // storeLabel
            // 
            this.storeLabel.AutoSize = true;
            this.storeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.storeLabel.Location = new System.Drawing.Point(464, 116);
            this.storeLabel.Name = "storeLabel";
            this.storeLabel.Size = new System.Drawing.Size(146, 25);
            this.storeLabel.TabIndex = 11;
            this.storeLabel.Text = "Current Store:";
            // 
            // totalSoFarLabel
            // 
            this.totalSoFarLabel.AutoSize = true;
            this.totalSoFarLabel.Location = new System.Drawing.Point(466, 428);
            this.totalSoFarLabel.Name = "totalSoFarLabel";
            this.totalSoFarLabel.Size = new System.Drawing.Size(64, 13);
            this.totalSoFarLabel.TabIndex = 12;
            this.totalSoFarLabel.Text = "Total: $0.00";
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(469, 364);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(258, 23);
            this.orderButton.TabIndex = 13;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.orderButton_MouseClick);
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(469, 393);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(258, 23);
            this.checkoutButton.TabIndex = 14;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkoutButton_MouseClick);
            // 
            // storepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.totalSoFarLabel);
            this.Controls.Add(this.storeLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.itemPicture);
            this.Controls.Add(this.userInfoBox);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.StoreBox);
            this.Controls.Add(this.ItemBox);
            this.Name = "storepage";
            this.Text = "Storefront";
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox itemPicture;
        private System.Windows.Forms.ListBox ItemBox;
        private System.Windows.Forms.ListBox StoreBox;
        private System.Windows.Forms.ListBox CategoryBox;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.RichTextBox userInfoBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label storeLabel;
        private System.Windows.Forms.Label totalSoFarLabel;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button checkoutButton;
    }
}