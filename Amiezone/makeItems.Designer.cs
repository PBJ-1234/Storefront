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
            this.button4 = new System.Windows.Forms.Button();
            this.itemStore = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.RichTextBox();
            this.storeNameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // storeName
            // 
            this.storeName.Location = new System.Drawing.Point(294, 124);
            this.storeName.Name = "storeName";
            this.storeName.Size = new System.Drawing.Size(100, 20);
            this.storeName.TabIndex = 0;
            // 
            // category
            // 
            this.category.Location = new System.Drawing.Point(294, 162);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(100, 20);
            this.category.TabIndex = 1;
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(483, 165);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(100, 20);
            this.itemName.TabIndex = 3;
            // 
            // cost
            // 
            this.cost.Location = new System.Drawing.Point(483, 200);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(100, 20);
            this.cost.TabIndex = 4;
            // 
            // storeButton
            // 
            this.storeButton.Location = new System.Drawing.Point(307, 66);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(75, 23);
            this.storeButton.TabIndex = 7;
            this.storeButton.Text = "Make Store";
            this.storeButton.UseVisualStyleBackColor = true;
            this.storeButton.Click += new System.EventHandler(this.CreateStore);
            // 
            // itemButton
            // 
            this.itemButton.Location = new System.Drawing.Point(497, 66);
            this.itemButton.Name = "itemButton";
            this.itemButton.Size = new System.Drawing.Size(75, 23);
            this.itemButton.TabIndex = 8;
            this.itemButton.Text = "Make Item";
            this.itemButton.UseVisualStyleBackColor = true;
            this.itemButton.Click += new System.EventHandler(this.CreateItem);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(398, 334);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 395);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Return";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // itemStore
            // 
            this.itemStore.Location = new System.Drawing.Point(483, 124);
            this.itemStore.Name = "itemStore";
            this.itemStore.Size = new System.Drawing.Size(100, 20);
            this.itemStore.TabIndex = 2;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(589, 124);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(100, 96);
            this.description.TabIndex = 11;
            this.description.Text = "";
            // 
            // storeNameLabel
            // 
            this.storeNameLabel.AutoSize = true;
            this.storeNameLabel.Location = new System.Drawing.Point(222, 127);
            this.storeNameLabel.Name = "storeNameLabel";
            this.storeNameLabel.Size = new System.Drawing.Size(66, 13);
            this.storeNameLabel.TabIndex = 12;
            this.storeNameLabel.Text = "Store Name:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(208, 165);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(80, 13);
            this.categoryLabel.TabIndex = 13;
            this.categoryLabel.Text = "Store Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Store Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Item Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cost:";
            // 
            // makeItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.storeNameLabel);
            this.Controls.Add(this.description);
            this.Controls.Add(this.button4);
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox itemStore;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label storeNameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}