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
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.userInfoBox = new System.Windows.Forms.RichTextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.storeLabel = new System.Windows.Forms.Label();
            this.totalSoFarLabel = new System.Windows.Forms.Label();
            this.orderButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.cartTable = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.editDetailsButton = new System.Windows.Forms.Button();
            this.removeRowButton = new System.Windows.Forms.Button();
            this.storeNameLable = new System.Windows.Forms.Label();
            this.storeTable = new System.Windows.Forms.DataGridView();
            this.StoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTable = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreBox = new System.Windows.Forms.ListBox();
            this.CategoryBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTable)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPicture
            // 
            this.itemPicture.Location = new System.Drawing.Point(201, 157);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(341, 259);
            this.itemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.itemPicture.TabIndex = 3;
            this.itemPicture.TabStop = false;
            // 
            // ItemBox
            // 
            this.ItemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.ItemHeight = 15;
            this.ItemBox.Location = new System.Drawing.Point(553, 147);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(244, 169);
            this.ItemBox.TabIndex = 4;
            this.ItemBox.Visible = false;
            this.ItemBox.SelectedIndexChanged += new System.EventHandler(this.loadItem);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(31, 157);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(154, 259);
            this.descriptionBox.TabIndex = 7;
            this.descriptionBox.Text = "";
            // 
            // userInfoBox
            // 
            this.userInfoBox.Location = new System.Drawing.Point(31, 20);
            this.userInfoBox.Name = "userInfoBox";
            this.userInfoBox.ReadOnly = true;
            this.userInfoBox.Size = new System.Drawing.Size(154, 93);
            this.userInfoBox.TabIndex = 8;
            this.userInfoBox.Text = "";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(553, 18);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(112, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create Store/Item";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gotoCreateform);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(685, 18);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(112, 23);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load from file";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataLoadStore);
            // 
            // storeLabel
            // 
            this.storeLabel.AutoSize = true;
            this.storeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.storeLabel.Location = new System.Drawing.Point(548, 116);
            this.storeLabel.Name = "storeLabel";
            this.storeLabel.Size = new System.Drawing.Size(146, 25);
            this.storeLabel.TabIndex = 11;
            this.storeLabel.Text = "Current Store:";
            // 
            // totalSoFarLabel
            // 
            this.totalSoFarLabel.AutoSize = true;
            this.totalSoFarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSoFarLabel.Location = new System.Drawing.Point(599, 426);
            this.totalSoFarLabel.Name = "totalSoFarLabel";
            this.totalSoFarLabel.Size = new System.Drawing.Size(32, 16);
            this.totalSoFarLabel.TabIndex = 12;
            this.totalSoFarLabel.Text = "0.00";
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(553, 326);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(103, 40);
            this.orderButton.TabIndex = 13;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataOrderItem);
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(553, 376);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(244, 40);
            this.checkoutButton.TabIndex = 14;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gotoCheckout);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(550, 425);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(52, 16);
            this.totalLabel.TabIndex = 15;
            this.totalLabel.Text = "Total: $";
            // 
            // cartTable
            // 
            this.cartTable.AllowUserToAddRows = false;
            this.cartTable.AllowUserToDeleteRows = false;
            this.cartTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemCost,
            this.ItemAmount,
            this.StoreName});
            this.cartTable.Location = new System.Drawing.Point(201, 20);
            this.cartTable.MultiSelect = false;
            this.cartTable.Name = "cartTable";
            this.cartTable.ReadOnly = true;
            this.cartTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartTable.Size = new System.Drawing.Size(341, 131);
            this.cartTable.TabIndex = 16;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name:";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemCost
            // 
            this.ItemCost.HeaderText = "Price:";
            this.ItemCost.Name = "ItemCost";
            this.ItemCost.ReadOnly = true;
            // 
            // ItemAmount
            // 
            this.ItemAmount.HeaderText = "Quan:";
            this.ItemAmount.Name = "ItemAmount";
            this.ItemAmount.ReadOnly = true;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Store:";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(679, 326);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(49, 40);
            this.removeItemButton.TabIndex = 17;
            this.removeItemButton.Text = "Remove Item";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeoOne);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(31, 119);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(73, 32);
            this.logoutButton.TabIndex = 18;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logout);
            // 
            // editDetailsButton
            // 
            this.editDetailsButton.Location = new System.Drawing.Point(112, 119);
            this.editDetailsButton.Name = "editDetailsButton";
            this.editDetailsButton.Size = new System.Drawing.Size(73, 32);
            this.editDetailsButton.TabIndex = 19;
            this.editDetailsButton.Text = "Account";
            this.editDetailsButton.UseVisualStyleBackColor = true;
            this.editDetailsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gotoAccountDetails);
            // 
            // removeRowButton
            // 
            this.removeRowButton.Location = new System.Drawing.Point(748, 326);
            this.removeRowButton.Name = "removeRowButton";
            this.removeRowButton.Size = new System.Drawing.Size(49, 40);
            this.removeRowButton.TabIndex = 20;
            this.removeRowButton.Text = "Remove Row";
            this.removeRowButton.UseVisualStyleBackColor = true;
            this.removeRowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeAll);
            // 
            // storeNameLable
            // 
            this.storeNameLable.AutoSize = true;
            this.storeNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeNameLable.Location = new System.Drawing.Point(688, 117);
            this.storeNameLable.Name = "storeNameLable";
            this.storeNameLable.Size = new System.Drawing.Size(15, 24);
            this.storeNameLable.TabIndex = 21;
            this.storeNameLable.Text = " ";
            // 
            // storeTable
            // 
            this.storeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storeTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreColumn,
            this.StoreCategoryColumn});
            this.storeTable.Location = new System.Drawing.Point(553, 47);
            this.storeTable.MultiSelect = false;
            this.storeTable.Name = "storeTable";
            this.storeTable.ReadOnly = true;
            this.storeTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.storeTable.Size = new System.Drawing.Size(244, 69);
            this.storeTable.TabIndex = 22;
            this.storeTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataReinitializeProducts);
            // 
            // StoreColumn
            // 
            this.StoreColumn.HeaderText = "Store:";
            this.StoreColumn.Name = "StoreColumn";
            this.StoreColumn.ReadOnly = true;
            // 
            // StoreCategoryColumn
            // 
            this.StoreCategoryColumn.HeaderText = "Category:";
            this.StoreCategoryColumn.Name = "StoreCategoryColumn";
            this.StoreCategoryColumn.ReadOnly = true;
            // 
            // itemTable
            // 
            this.itemTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.ProductCost});
            this.itemTable.Location = new System.Drawing.Point(553, 144);
            this.itemTable.MultiSelect = false;
            this.itemTable.Name = "itemTable";
            this.itemTable.ReadOnly = true;
            this.itemTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemTable.Size = new System.Drawing.Size(244, 172);
            this.itemTable.TabIndex = 23;
            this.itemTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataLoadItem);
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Name:";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // ProductCost
            // 
            this.ProductCost.HeaderText = "Cost:";
            this.ProductCost.Name = "ProductCost";
            this.ProductCost.ReadOnly = true;
            // 
            // StoreBox
            // 
            this.StoreBox.FormattingEnabled = true;
            this.StoreBox.Location = new System.Drawing.Point(553, 47);
            this.StoreBox.Name = "StoreBox";
            this.StoreBox.Size = new System.Drawing.Size(244, 43);
            this.StoreBox.TabIndex = 5;
            this.StoreBox.Visible = false;
            this.StoreBox.SelectedIndexChanged += new System.EventHandler(this.reinitializeProducts);
            // 
            // CategoryBox
            // 
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(553, 96);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(244, 17);
            this.CategoryBox.TabIndex = 6;
            this.CategoryBox.Visible = false;
            // 
            // storepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.itemTable);
            this.Controls.Add(this.storeTable);
            this.Controls.Add(this.storeNameLable);
            this.Controls.Add(this.removeRowButton);
            this.Controls.Add(this.editDetailsButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.removeItemButton);
            this.Controls.Add(this.cartTable);
            this.Controls.Add(this.totalSoFarLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.orderButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox itemPicture;
        private System.Windows.Forms.ListBox ItemBox;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.RichTextBox userInfoBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label storeLabel;
        private System.Windows.Forms.Label totalSoFarLabel;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.DataGridView cartTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button editDetailsButton;
        private System.Windows.Forms.Button removeRowButton;
        private System.Windows.Forms.Label storeNameLable;
        private System.Windows.Forms.DataGridView storeTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCategoryColumn;
        private System.Windows.Forms.DataGridView itemTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCost;
        private System.Windows.Forms.ListBox StoreBox;
        private System.Windows.Forms.ListBox CategoryBox;
    }
}