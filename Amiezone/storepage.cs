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
            currentUser = newUser;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", currentUser.name, currentUser.address, currentUser.wallet);
            loadStores();
            InitializeComponent();
        }

        public storepage(User newUser, ShoppingCart cart)
        {
            currentUser = newUser;
            currentCart = cart;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", currentUser.name, currentUser.address, currentUser.wallet);
            loadStores();
            InitializeComponent();
        }
        //loads in stores from store folder
        public void loadStores()
        {
            StoreBox.Items.Clear();
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores");
            string[] directories = Directory.GetDirectories(filePath);
            currentStores.storelist = currentStores.rebuildStores();
            foreach (string x in directories)
            {
                StoreBox.Items.Add(x);
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
            if(Image.FromFile(finalPath) == null)
            {
                pic.Image = Image.FromFile(Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg"));
            }
            else
            {
                pic.Image = Image.FromFile(finalPath);
            }
        }

        // Loads in the selected item from the list into the description
        private void ItemBox_MouseClick(object sender, MouseEventArgs e)
        {
            // When user clicks will read file associated with item
            /* File Structure:
             * Item ID
             * Item Name
             * Item Cost
             * Item Desc
            */
            // File picture will be same name but with the extension difference
            
            descriptionBox.Text = ItemBox.SelectedItem.ToString();
            string x = ItemBox.SelectedItem.ToString();
            item addedItem = item.GetItem(x, storeLabel.Text);

            descriptionBox.Text = addedItem.name + " ";
            descriptionBox.Text += String.Format("({0})\n", addedItem.productID);
            descriptionBox.Text += String.Format("--------");
            descriptionBox.Text += String.Format("(Description: {0})\n", addedItem.description);
            descriptionBox.Text += String.Format("Cost: {0}", addedItem.cost);

            string imagePath = addedItem.name + ".jpg";
            LoadNewPict(itemPicture, imagePath);
        }
        // Functions to get the store through load
        private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {
            
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=netcore-3.1
            var content = string.Empty;
            var path = string.Empty;

            // Sets up default open file explorer browser
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\";
            openFile.Filter = "All files (*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                //https://stackoverflow.com/questions/5840443/how-to-read-all-files-inside-particular-folder
                // Clears item list
                ItemBox.Items.Clear();
                path = openFile.FileName;
                storeLabel.Text = "Current Store: " + path;

                foreach (string itemFile in Directory.EnumerateFiles(path, "*txt"))
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
            string x = ItemBox.SelectedItem.ToString();
            item addedItem = item.GetItem(x,storeLabel.Text);
            currentCart.itemsInCart.Add(addedItem);
            double cost = double.Parse(totalSoFarLabel.Text) + addedItem.cost;
            totalSoFarLabel.Text = cost.ToString();
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

        This bit is probably useless
        Application.Run(new Form { Controls = { label } } );
        */
    }


}
