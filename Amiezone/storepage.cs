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
    public partial class storepage : Form
    {

        User currentUser;
        ShoppingCart currentCart;
        // CurrentStores likely unnecessary
        Storefront currentStores;
        public storepage(User newUser)
        {
            InitializeComponent();
            userInfoBox.Text = "asdf";
            currentUser = newUser;
            currentCart = new ShoppingCart();
            userInfoBox.Text = String.Format("User: {0}\n", currentUser.name);
            userInfoBox.Text += String.Format("Address: {0}\n", currentUser.address);
            userInfoBox.Text += String.Format("Funds: {0}\n", currentUser.wallet);
            loadStores();
        }

        public storepage(User newUser, ShoppingCart cart)
        {
            InitializeComponent();
            currentUser = newUser;
            currentCart = cart;
            currentUser = newUser;
            userInfoBox.Text = String.Format("User: {0}\n", currentUser.name);
            userInfoBox.Text += String.Format("Address: {0}\n", currentUser.address);
            userInfoBox.Text += String.Format("Funds: {0}\n", currentUser.wallet);
            loadStores();
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

        private void StoreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(StoreBox.SelectedItem == null)
            {
                return;
            }
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", StoreBox.SelectedItem.ToString());
            foreach (string itemFile in Directory.EnumerateFiles(filePath, "*.txt"))
            {
                ItemBox.Items.Clear();

                string contents = Path.GetFileNameWithoutExtension(itemFile).ToString();
                ItemBox.Items.Add(contents);
            }
        }

        // Loads a pic into the box when selecting a new item
        private void LoadNewPict(PictureBox pic, string filename)
        {
            
            // get into the Stores dir, selectedStore, and then get the image file
            string store = storeLabel.Text;
            string finalPath = Path.Combine(storeClasses.generalFilePath, "Stores");
            finalPath = Path.Combine(finalPath, Path.GetDirectoryName(store));
            finalPath = Path.Combine(finalPath, Path.GetFileName(filename));
            if(File.Exists(finalPath) == false)
            {
                string path = Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg");
                pic.Image = Image.FromFile(path);
            }
            else
            {
                pic.Image = Image.FromFile(finalPath);
            }
        }


        // Loads in the selected item from the list into the description
        private void ItemBox_MouseClick(object sender, EventArgs e)
        {
            // When user clicks will read file associated with item
            /* File Structure:
             * Item ID
             * Item Name
             * Item Cost
             * Item Desc
            */
            // File picture will be same name but with the extension difference

            if(ItemBox.SelectedItem == null)
            {
                return;
            }
            descriptionBox.Text = ItemBox.SelectedItem.ToString();
            string x = StoreBox.SelectedItem.ToString();
            string y = ItemBox.SelectedItem.ToString();
            item addedItem = item.GetItem(x, y);

            descriptionBox.Text = addedItem.name + " ";
            descriptionBox.Text += String.Format("({0})\n", addedItem.productID);
            descriptionBox.Text += String.Format("------------------------------\n");
            descriptionBox.Text += String.Format("(Description: {0})\n", addedItem.description);
            descriptionBox.Text += String.Format("Cost: {0}", addedItem.cost);

            string imagePath = addedItem.name + ".jpg";
            LoadNewPict(itemPicture, imagePath);
        }

        // Function to get the store through load
        private void loadButton_MouseClick(object sender, MouseEventArgs e)
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
                storeLabel.Text = "Current Store: " + storeName;

                foreach (string itemFile in Directory.EnumerateFiles(folderPath, "*txt"))
                {
                    string contents = itemFile.ToString();
                    ItemBox.Items.Add(contents);
                }
            }

        }

        private void createButton_MouseClick(object sender, MouseEventArgs e)
        {
            makeItems createForm = new makeItems(this);
            createForm.Show();
            // Make sure to reenable in makeItems close
            this.Enabled = false;
        }

        private void orderButton_MouseClick(object sender, MouseEventArgs e)
        {
            // User did select something
            if (ItemBox.SelectedIndex != null)
            {
                string x = StoreBox.SelectedItem.ToString();
                string y = ItemBox.SelectedItem.ToString();
                item addedItem = item.GetItem(x,y);
                currentCart.itemsInCart.Add(addedItem);
                double cost = double.Parse(totalSoFarLabel.Text) + addedItem.cost;
                totalSoFarLabel.Text = cost.ToString();
            }

        }
        private void checkoutButton_MouseClick(object sender, MouseEventArgs e)
        {
            checkout check = new checkout(currentUser, currentCart);
            this.Close();
            check.Show();
        }




        // Below is for making labels clickable
        // Likely have to make multiple labels/text boxes on the storefront
        /*
        Label label = new Label { Text = "Click me" };
        label.Click += delegate { label.Text = "Clicked"; };

        This bit is mostly  useless
        Application.Run(new Form { Controls = { label } } );
        */
    }


}
