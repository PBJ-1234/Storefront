namespace Amiezone
{
    partial class makeItems
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
            this.storeName = new System.Windows.Forms.TextBox();
            this.category = new System.Windows.Forms.TextBox();
            this.itemName = new System.Windows.Forms.TextBox();
            this.cost = new System.Windows.Forms.TextBox();
            this.storeButton = new System.Windows.Forms.Button();
            this.itemButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.itemStore = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.RichTextBox();
            this.storeNameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.itemStoreNameLabel = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.imagePathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // storeName
            // 
            this.storeName.Location = new System.Drawing.Point(174, 188);
            this.storeName.Name = "storeName";
            this.storeName.Size = new System.Drawing.Size(100, 20);
            this.storeName.TabIndex = 0;
            // 
            // category
            // 
            this.category.Location = new System.Drawing.Point(174, 222);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(100, 20);
            this.category.TabIndex = 1;
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(363, 188);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(100, 20);
            this.itemName.TabIndex = 3;
            // 
            // cost
            // 
            this.cost.Location = new System.Drawing.Point(363, 222);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(100, 20);
            this.cost.TabIndex = 4;
            // 
            // storeButton
            // 
            this.storeButton.Location = new System.Drawing.Point(90, 87);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(184, 49);
            this.storeButton.TabIndex = 7;
            this.storeButton.Text = "Make Store";
            this.storeButton.UseVisualStyleBackColor = true;
            this.storeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.createStore);
            // 
            // itemButton
            // 
            this.itemButton.Location = new System.Drawing.Point(294, 87);
            this.itemButton.Name = "itemButton";
            this.itemButton.Size = new System.Drawing.Size(169, 49);
            this.itemButton.TabIndex = 8;
            this.itemButton.Text = "Make Item";
            this.itemButton.UseVisualStyleBackColor = true;
            this.itemButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.createItem);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(91, 327);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(372, 36);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.createObject);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(481, 327);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(229, 36);
            this.returnButton.TabIndex = 10;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.returnPage);
            // 
            // itemStore
            // 
            this.itemStore.Location = new System.Drawing.Point(363, 156);
            this.itemStore.Name = "itemStore";
            this.itemStore.Size = new System.Drawing.Size(100, 20);
            this.itemStore.TabIndex = 2;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(481, 87);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(229, 89);
            this.description.TabIndex = 11;
            this.description.Text = "";
            // 
            // storeNameLabel
            // 
            this.storeNameLabel.AutoSize = true;
            this.storeNameLabel.Location = new System.Drawing.Point(102, 191);
            this.storeNameLabel.Name = "storeNameLabel";
            this.storeNameLabel.Size = new System.Drawing.Size(66, 13);
            this.storeNameLabel.TabIndex = 12;
            this.storeNameLabel.Text = "Store Name:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(88, 225);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(80, 13);
            this.categoryLabel.TabIndex = 13;
            this.categoryLabel.Text = "Store Category:";
            // 
            // itemStoreNameLabel
            // 
            this.itemStoreNameLabel.AutoSize = true;
            this.itemStoreNameLabel.Location = new System.Drawing.Point(280, 159);
            this.itemStoreNameLabel.Name = "itemStoreNameLabel";
            this.itemStoreNameLabel.Size = new System.Drawing.Size(66, 13);
            this.itemStoreNameLabel.TabIndex = 14;
            this.itemStoreNameLabel.Text = "Store Name:";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Location = new System.Drawing.Point(285, 191);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(61, 13);
            this.itemNameLabel.TabIndex = 14;
            this.itemNameLabel.Text = "Item Name:";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(315, 229);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(31, 13);
            this.costLabel.TabIndex = 15;
            this.costLabel.Text = "Cost:";
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(481, 188);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(229, 133);
            this.picturePreview.TabIndex = 16;
            this.picturePreview.TabStop = false;
            // 
            // imagePath
            // 
            this.imagePath.Location = new System.Drawing.Point(363, 256);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(100, 20);
            this.imagePath.TabIndex = 17;
            // 
            // imagePathLabel
            // 
            this.imagePathLabel.AutoSize = true;
            this.imagePathLabel.Location = new System.Drawing.Point(282, 259);
            this.imagePathLabel.Name = "imagePathLabel";
            this.imagePathLabel.Size = new System.Drawing.Size(64, 13);
            this.imagePathLabel.TabIndex = 18;
            this.imagePathLabel.Text = "Image Path:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(377, 290);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 19;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectPicture);
            // 
            // makeItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 450);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePathLabel);
            this.Controls.Add(this.imagePath);
            this.Controls.Add(this.picturePreview);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.itemStoreNameLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.storeNameLabel);
            this.Controls.Add(this.description);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.itemButton);
            this.Controls.Add(this.storeButton);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.itemStore);
            this.Controls.Add(this.category);
            this.Controls.Add(this.storeName);
            this.Name = "makeItems";
            this.Text = "Create Items/Stores";
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox storeName;
        private System.Windows.Forms.TextBox category;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.TextBox cost;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.Button itemButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.TextBox itemStore;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label storeNameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label itemStoreNameLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Label imagePathLabel;
        private System.Windows.Forms.Button browseButton;
    }
}