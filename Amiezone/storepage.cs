using System;
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
    public partial class StorePage : Form
    {
        internal User currentUser;
        ShoppingCart currentCart;
        //Didn't see much use, kinda forgot about it
        Storefront currentStores;

        public static DataGridView passingGridTable;
        public static double runningFunds;

        //Behavior when logging in
        public StorePage(User newUser)
        {
            InitializeComponent();
            currentUser = newUser;
            currentCart = new ShoppingCart();
            reinitalizeUser();
            loadStores();
        }

        //Behavior when returning to page
        public StorePage(User curUser, ShoppingCart cart)
        {
            InitializeComponent();
            currentUser = curUser;
            currentCart = cart;
            reinitalizeUser();
            loadStores();
        }

        // Returns user to login page
        private void logout(object sender, MouseEventArgs e)
        {
            login newLogin = new login();
            newLogin.Show();
            this.Dispose();
        }

        // Opens up edited version of register page
        private void gotoAccountDetails(object sender, MouseEventArgs e)
        {
            Register accountDetail = new Register(this, currentUser);
            this.Enabled = false;
            accountDetail.Show();
            reinitalizeUser();
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
            Storefront dataFront = new Storefront();
            storeTable.Rows.Clear();


            string dataFilePath = Path.Combine(storeClasses.generalFilePath, "Stores");
            string[] dataDirectories = Directory.GetDirectories(dataFilePath);
            dataFront.rebuildStores();
            currentStores = dataFront;

            foreach(string x in dataDirectories)
            {
                //Does initial case then normal case
                string[] info = Directory.GetDirectories(x);
                if(storeTable.Rows[0].Cells[0].Value == null)
                {
                    storeTable.Rows[0].SetValues(Path.GetFileName(x), Path.GetFileNameWithoutExtension(info[0]));
                }
                else
                {
                    storeTable.Rows.Add(Path.GetFileName(x), Path.GetFileNameWithoutExtension(info[0]));
                }
            }
        }

        // Loads in store items
        private void dataReinitializeProducts(object sender, DataGridViewCellEventArgs e)
        {
            if (storeTable.SelectedRows == null)
            {
                return;
            }
            itemTable.Rows.Clear();
            storeNameLable.Text = storeTable.SelectedRows[0].Cells[0].Value.ToString();
            
            string dataPath = Path.Combine(storeClasses.generalFilePath, "Stores", storeNameLable.Text);
            foreach (string itemFile in Directory.EnumerateFiles(dataPath, "*.txt"))
            {
                string contents = Path.GetFileNameWithoutExtension(itemFile).ToString();
                Item newItem = Item.getItem(storeNameLable.Text, contents);
                itemTable.Rows.Add(newItem.name, newItem.cost);
            }
           
        }


        // Loads a pic into the box when selecting a new item
        private void loadNewPic(PictureBox pic, string filename)
        {
            // get into the Stores dir, selectedStore, and then get the image file
            string store = storeNameLable.Text;
            string finalPath = Path.Combine(storeClasses.generalFilePath, "Stores");
            finalPath = Path.Combine(finalPath, store);
            finalPath = Path.Combine(finalPath, Path.GetFileName(filename));
            foreach(string x in storeClasses.exts)
            {
                if (File.Exists(finalPath + x) == true)
                {
                    finalPath = finalPath + x;
                    pic.Image = Image.FromFile(finalPath);
                    return;
                }
            }
            // File doesn't exist so default
            string path = Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg");
            pic.Image = Image.FromFile(path);
        }


        // Loads in the selected item from the list into the description
        private void dataLoadItem(object sender, DataGridViewCellEventArgs e)
        {
            if (itemTable.SelectedRows == null || itemTable.SelectedRows[0].Cells[0].Value == null)
            {
                return;
            }

            string x = storeTable.SelectedRows[0].Cells[0].Value.ToString();
            string y = itemTable.SelectedRows[0].Cells[0].Value.ToString();
            Item addedItem = Item.getItem(x, y);

            descriptionBox.Text = addedItem.name + " \n";
            descriptionBox.Text += String.Format("(Product ID: {0})\n", addedItem.productID);
            descriptionBox.Text += String.Format("------------------------------\n");
            descriptionBox.Text += String.Format("Description: {0}\n\n", addedItem.description);
            descriptionBox.Text += String.Format("Cost: ${0}", addedItem.cost);

            string imagePath = addedItem.name;
            loadNewPic(itemPicture, imagePath);
        }

        // Function to get the store through load button
        private void dataLoadStore(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = Path.Combine(storeClasses.generalFilePath, "Stores");

            // Second Condition checks if folder is in the project
            if (folderDialog.ShowDialog() == DialogResult.OK && folderDialog.SelectedPath.Contains(storeClasses.generalFilePath))
            {
                // Clears item list then rebuilds
                itemTable.Rows.Clear();
                storeNameLable.Text = storeTable.SelectedRows[0].Cells[0].Value.ToString();

                //Builds table
                string dataPath = Path.Combine(storeClasses.generalFilePath, "Stores", storeNameLable.Text);
                foreach (string itemFile in Directory.EnumerateFiles(dataPath, "*.txt"))
                {
                    string contents = Path.GetFileNameWithoutExtension(itemFile).ToString();
                    Item newItem = Item.getItem(storeNameLable.Text, contents);
                    itemTable.Rows.Add(newItem.name, newItem.cost);
                }
            }
        }

        // Opens up makeItems form
        private void gotoCreateform(object sender, MouseEventArgs e)
        {
            makeItems createForm = new makeItems(this);
            createForm.Show();
            // reenables in makeItems close
            this.Enabled = false;
        }

        // Adds item to cart and updates table
        private void dataOrderItem(object sender, MouseEventArgs e)
        {
            // User did select an item
            if (itemTable.SelectedRows != null && storeTable.SelectedRows != null)
            {
                string x = storeNameLable.Text;
                string y = itemTable.SelectedRows[0].Cells[0].Value.ToString();
                Item addedItem = Item.getItem(x, y);

                //Checks for item in Table
                Boolean notFound = true;
                foreach (DataGridViewRow currentRow in cartTable.Rows)
                {

                    if (currentRow == null || currentRow.Cells[0].Value == null)
                    {
                        MessageBox.Show(itemTable.SelectedRows[0].Cells[0].Value.ToString());
                        currentRow.Cells[0].Value = addedItem.name;
                        currentRow.Cells[1].Value = addedItem.cost;
                        currentRow.Cells[2].Value = 1;
                        currentRow.Cells[3].Value = storeNameLable.Text;
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
                    cartTable.Rows.Add(addedItem.name, addedItem.cost, 1, storeNameLable.Text);
                }
                double cost = double.Parse(totalSoFarLabel.Text) + addedItem.cost;
                totalSoFarLabel.Text = cost.ToString();
            }
        }

        // Removes one of instance of the item at a time
        private void removeoOne(object sender, MouseEventArgs e)
        {
            if(cartTable.SelectedRows != null)
            {
                int val = (int)cartTable.SelectedRows[0].Cells[2].Value;
                if(val > 1)
                {
                    Item removeing = Item.getItem(cartTable.SelectedRows[0].Cells[3].Value.ToString(), cartTable.SelectedRows[0].Cells[0].Value.ToString());
                    cartTable.SelectedRows[0].Cells[2].Value = val - 1;
                    currentCart.removeItem(removeing.productID);

                    double newValue = double.Parse(totalSoFarLabel.Text) - removeing.cost;
                    totalSoFarLabel.Text = newValue.ToString();
                }
                else
                {
                    Item removeing = Item.getItem(cartTable.SelectedRows[0].Cells[3].Value.ToString(), cartTable.SelectedRows[0].Cells[0].Value.ToString());
                    currentCart.removeItem(removeing.productID);

                    double newValue = double.Parse(totalSoFarLabel.Text) - removeing.cost;
                    totalSoFarLabel.Text = newValue.ToString();
                    cartTable.Rows.Remove(cartTable.SelectedRows[0]);
                }
            }
        }

        // Removes the entire item row entry
        private void removeAll(object sender, MouseEventArgs e)
        {
            if (cartTable.SelectedRows != null)
            {
                Item removeing = Item.getItem(cartTable.SelectedRows[0].Cells[3].Value.ToString(), cartTable.SelectedRows[0].Cells[0].Value.ToString());
                currentCart.removeItem(removeing.productID);

                double newValue = double.Parse(totalSoFarLabel.Text) - ((double)cartTable.SelectedRows[0].Cells[1].Value * (int)cartTable.SelectedRows[0].Cells[2].Value);
                totalSoFarLabel.Text = newValue.ToString();
                cartTable.Rows.Remove(cartTable.SelectedRows[0]);
            }
        }

        private void gotoCheckout(object sender, MouseEventArgs e)
        {
            double total = double.Parse(totalSoFarLabel.Text);
            passingGridTable = cartTable;
            checkout check = new checkout(currentUser, currentCart, this);
            this.Hide();
            this.Enabled = false;
            check.Show();
        }
    }
}
