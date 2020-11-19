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
        // Work on passing in the user into the form constructor
        // rather than just mashing it in there piece by piece
        storeClasses.User currentUser;
        storeClasses.ShoppingCart currentCart;
        storeClasses.store currentStore;
        
        /* older version for testing later
        public storepage(string uName, string uAdd, int uID, double uWallet)
        {
            currentUser.name = uName;
            currentUser.address = uAdd;
            currentUser.ID = uID;
            currentUser.wallet = uWallet;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", uName, uAdd, uWallet);
            InitializeComponent();
        } 
        */
        public storepage(storeClasses.User newUser)
        {
            currentUser = newUser;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", currentUser.name, currentUser.address, currentUser.wallet);
            InitializeComponent();
        }
        /* older version for testing later
        public storepage(string uName, string uAdd, int uID, double uWallet, storeClasses.ShoppingCart cart)
        {
            currentUser.name = uName;
            currentUser.address = uAdd;
            currentUser.ID = uID;
            currentUser.wallet = uWallet;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", uName, uAdd, uWallet);
            InitializeComponent();
        }
        */
        public storepage(storeClasses.User newUser, storeClasses.ShoppingCart cart)
        {
            currentUser = newUser;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", currentUser.name, currentUser.address, currentUser.wallet);
            InitializeComponent();
        }
        //The shit below is for figuring out how to set pictures during run time
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
            // TO DO: add sample/default picture if no picture
            
            // Make generic method for four lines
            // Included in item mouse and order mouse
            descriptionBox.Text = ItemBox.SelectedItem.ToString();
            string x = ItemBox.SelectedItem.ToString();
            int y = int.Parse(x);
            storeClasses.item addedItem = storeClasses.item.GetItem(y, storeLabel.Text);

            descriptionBox.Text = addedItem.name + " ";
            descriptionBox.Text += String.Format("({0})\n", addedItem.productID);
            descriptionBox.Text += String.Format("--------");
            descriptionBox.Text += String.Format("(Description: {0})\n", addedItem.description);
            descriptionBox.Text += String.Format("Cost: {0}", addedItem.cost);

            string imagePath = addedItem.name + ".jpg";
            LoadNewPict(itemPicture, imagePath);

            // This clears the memory of the image so that there isn't some mem leak or sometin
            //itemPicture.Image.Dispose();

        }

        private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {
            /*
             * https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=netcore-3.1
             */
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
            // Potentially open up a new window/form for it or create a panel
            // Potentially split into two opitions when clicked, IE make store or make item
            /*
             * Structure:
             * New Store Name:
             * Store Category:
             * 
             * Structure:
             * Item ID:
             * 
             * 
            */
            // Make constructor to get previous storefront form 
            // or make special page for easy go back page
            makeItems createForm = new makeItems(this);
            createForm.Show();
            // Make sure to reenable in makeItems close
            this.Enabled = false;
        }

        private void orderButton_MouseClick(object sender, MouseEventArgs e)
        {
            // Make generic method for four lines
            // I
            string x = ItemBox.SelectedItem.ToString();
            int y = int.Parse(x);
            storeClasses.item addedItem = storeClasses.item.GetItem(y,storeLabel.Text);
            currentCart.itemIDsInCart.Add(addedItem);
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
