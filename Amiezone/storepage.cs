﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
    public partial class storepage : Form
    {

        User currentUser;
        ShoppingCart currentCart;
        Storefront currentStores;

        public static DataGridView passingGridTable;
        public static double runningFunds;
        public storepage(User newUser)
        {
            InitializeComponent();
            currentUser = newUser;
            currentCart = new ShoppingCart();
            reinitalizeUser();
            loadStores();
        }
        public storepage(User newUser, ShoppingCart cart)
        {
            InitializeComponent();
            currentUser = newUser;
            currentCart = cart;
            reinitalizeUser();
            loadStores();
        }
        // Adjusts userinfo when they checked out a cart or storepage is made
        public void reinitalizeUser()
        {
            string path = Path.Combine(storeClasses.generalFilePath, "Users", currentUser.name) + ".txt";
            string[] info = System.IO.File.ReadAllLines(path);
 
            currentUser.password = info[0];
            currentUser.ID = long.Parse(info[1]);
            currentUser.wallet = double.Parse(info[2]);
            currentUser.address = info[3];

            userInfoBox.Text = String.Format("User: {0}\n", currentUser.name);
            userInfoBox.Text += String.Format("Address: {0}\n", currentUser.address);
            userInfoBox.Text += String.Format("Funds: {0}\n", currentUser.wallet);
        }
        //loads in stores from store folder
        public void loadStores()
        {
            Storefront newFront = new Storefront();
            StoreBox.Items.Clear();
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores");
            string[] directories = Directory.GetDirectories(filePath);
            newFront.rebuildStores();
            currentStores = newFront;
            foreach (string x in directories)
            {
                StoreBox.Items.Add(Path.GetFileName(x));
                string[] info = Directory.GetDirectories(x);
                string categoryText = Path.GetFileNameWithoutExtension(info[0]);
                if(CategoryBox.Items.Contains(categoryText) == false)
                {
                    CategoryBox.Items.Add(categoryText);
                }
            }
        }

        // Loads in store items
        private void reinitializeProducts(object sender, EventArgs e)
        {
            if(StoreBox.SelectedItem == null)
            {
                return;
            }

            ItemBox.Items.Clear();
            storeNameLable.Text = StoreBox.SelectedItem.ToString();

            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", StoreBox.SelectedItem.ToString());
            foreach (string itemFile in Directory.EnumerateFiles(filePath, "*.txt"))
            {
                string contents = Path.GetFileNameWithoutExtension(itemFile).ToString();
                ItemBox.Items.Add(contents);
            }
        }

        // Loads a pic into the box when selecting a new item
        private void loadNewPic(PictureBox pic, string filename)
        {
            // get into the Stores dir, selectedStore, and then get the image file
            string[] exts = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
            string store = storeNameLable.Text;
            string finalPath = Path.Combine(storeClasses.generalFilePath, "Stores");
            finalPath = Path.Combine(finalPath, store);
            finalPath = Path.Combine(finalPath, Path.GetFileName(filename));
            foreach(string x in exts)
            {
                if (File.Exists(finalPath + x) == true)
                {
                    finalPath = finalPath + x;
                    pic.Image = Image.FromFile(finalPath);
                    return;
                }
            }
            MessageBox.Show("defaulted");
            // File doesn't exist so default
            string path = Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg");
            pic.Image = Image.FromFile(path);

        }


        // Loads in the selected item from the list into the description
        private void loadItem(object sender, EventArgs e)
        {
            // When user clicks will read file associated with item
            // File picture will be same name but with the extension difference

            if(ItemBox.SelectedItem == null)
            {
                return;
            }

            descriptionBox.Text = ItemBox.SelectedItem.ToString();
            string x = StoreBox.SelectedItem.ToString();
            string y = ItemBox.SelectedItem.ToString();
            Item addedItem = Item.GetItem(x, y);

            descriptionBox.Text = addedItem.name + " \n";
            descriptionBox.Text += String.Format("(Product ID: {0})\n", addedItem.productID);
            descriptionBox.Text += String.Format("------------------------------\n");
            descriptionBox.Text += String.Format("Description: {0}\n\n", addedItem.description);
            descriptionBox.Text += String.Format("Cost: ${0}", addedItem.cost);

            string imagePath = addedItem.name;
            loadNewPic(itemPicture, imagePath);
        }

        // Function to get the store through load
        private void loadStore(object sender, MouseEventArgs e)
        {
            string folderPath;
            string storeName;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = Path.Combine(storeClasses.generalFilePath, "Stores");
            
            // Second Condition checks if folder is in the project
            if(folderDialog.ShowDialog() == DialogResult.OK && folderDialog.SelectedPath.Contains(storeClasses.generalFilePath))
            {
                // Clears item list
                ItemBox.Items.Clear();
                folderPath = folderDialog.SelectedPath;

                storeName = Path.GetFileName(folderPath);
                storeNameLable.Text = storeName;

                foreach (string itemFile in Directory.EnumerateFiles(folderPath, "*txt"))
                {
                    string contents = itemFile.ToString();
                    ItemBox.Items.Add(contents);
                }
            }
        }

        private void gotoCreateform(object sender, MouseEventArgs e)
        {
            makeItems createForm = new makeItems(this);
            createForm.Show();
            // reenables in makeItems close
            this.Enabled = false;
        }

        //Adds item to cart and updates table
        private void orderItem(object sender, MouseEventArgs e)
        {
            // User did select an item
            if (ItemBox.SelectedItem != null)
            {
                string x = StoreBox.SelectedItem.ToString();
                string y = ItemBox.SelectedItem.ToString();
                Item addedItem = Item.GetItem(x,y);

                //Checks for item in Middle Table
                Boolean notFound = true;
                foreach(DataGridViewRow currentRow in dataGridView1.Rows)
                {
                    if(currentRow == null || currentRow.Cells[0].Value == null)
                    {
                        currentRow.Cells[0].Value = addedItem.name;
                        currentRow.Cells[1].Value = addedItem.cost;
                        currentRow.Cells[2].Value = 1;
                        currentRow.Cells[3].Value = storeNameLable.ToString();
                        MessageBox.Show(StoreBox.SelectedItem.ToString());
                        notFound = false;
                    }
                    else if ((string)currentRow.Cells[0].Value == addedItem.name)
                    {
                        // Casts Object->int
                        int cellQuanity = (int)currentRow.Cells[2].Value;
                        
                        currentRow.Cells[2].Value = cellQuanity + 1;
                        notFound = false;
                    }
                }
                if (notFound == true)
                {
                    dataGridView1.Rows.Add(addedItem.name, addedItem.cost, 1);
                }
                double cost = double.Parse(totalSoFarLabel.Text) + addedItem.cost;
                totalSoFarLabel.Text = cost.ToString(); 
            }
        }

        // Removes one of instance of the item at a time
        private void removeoOne(object sender, MouseEventArgs e)
        {
            if(dataGridView1.SelectedRows != null)
            {
                int val = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                if(val > 1)
                {
                    Item removeing = Item.GetItem(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    dataGridView1.SelectedRows[0].Cells[3].Value = val - 1;
                    currentCart.removeItem(removeing.productID);

                    double newValue = double.Parse(totalSoFarLabel.Text) - removeing.cost;
                    totalSoFarLabel.Text = newValue.ToString();
                }
                else
                {
                    Item removeing = Item.GetItem(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    currentCart.removeItem(removeing.productID);

                    double newValue = double.Parse(totalSoFarLabel.Text) - removeing.cost;
                    totalSoFarLabel.Text = newValue.ToString();
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
            }
        }

        // Removes the entire item row entry
        private void removeAll(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                Item removeing = Item.GetItem(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                currentCart.removeItem(removeing.productID);

                double newValue = double.Parse(totalSoFarLabel.Text) - ((double)dataGridView1.SelectedRows[0].Cells[1].Value * (int)dataGridView1.SelectedRows[0].Cells[2].Value);
                totalSoFarLabel.Text = newValue.ToString();
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }

        private void gotoCheckout(object sender, MouseEventArgs e)
        {
            double total = double.Parse(totalSoFarLabel.Text);
            passingGridTable = dataGridView1;
            checkout check = new checkout(currentUser, currentCart, this);
            this.Hide();
            this.Enabled = false;
            check.Show();
        }

        private void logout(object sender, MouseEventArgs e)
        {
            login newLogin = new login();
            newLogin.Show();
            this.Dispose();
        }

        private void gotoAccountDetails(object sender, MouseEventArgs e)
        {
            Register accountDetail = new Register(this, currentUser);
            this.Enabled = false;
            accountDetail.Show();
            reinitalizeUser();
        }
    }


}
