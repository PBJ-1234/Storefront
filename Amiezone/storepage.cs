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
        public storepage(string uName, string uAdd, int uID, double uWallet)
        {
            currentUser.name = uName;
            currentUser.address = uAdd;
            currentUser.ID = uID;
            currentUser.wallet = uWallet;
            userInfoBox.Text = String.Format("User: {0}\nAddress: {1}\nFunds{2}", uName, uAdd, uWallet);
            InitializeComponent();
        }

        //The shit below is for figuring out how to set pictures during run time
        private void LoadNewPict(PictureBox pic, string filename)
        {
            // The lines right below are also probably useless reformatted
            /* 
            // You should replace the bold image
            // in the sample below with an icon of your own choosing.  
            // Note the escape character used (@) when specifying the path.  
            pic.Image = Image.FromFile
            (System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal)
            + @"\Image.gif");
            */

            // This bit gets the directory of the main project t\Amiezone\Amiezone
            // or informally the dir with the bin, obj, properties, and the cs files
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Then get into the Stores dir, selectedStore, and then get the image file
            string store = storeLabel.Text;
            string finalPath = Path.Combine(projectDirectory, "Stores");
            finalPath = Path.Combine(finalPath, Path.GetDirectoryName(store));
            finalPath = Path.Combine(finalPath, Path.GetFileName(filename));
            pic.Image = Image.FromFile(finalPath);
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
            descriptionBox.Text = ItemBox.SelectedItem.ToString();
            
            /* This clears the memory of the image so that there isn't some mem leak or sometin
            
            private void deletePict(PictureBox pic)
            {
                if (pic.Image != null)
                {  
                    pic.Image.Dispose();  
                    pic.Image = null;  
                }
            }

            */
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
            makeItems createForm = new makeItems();

        }

        private void orderButton_MouseClick(object sender, MouseEventArgs e)
        {
            // Figure out formatting of items better
            // To do
            storeClasses.item addedItem = storeClasses.item.GetItem(ItemBox.SelectedItem, StoreBox.SelectedItem.ToString());
            currentCart.itemIDsInCart.Add(addedItem);
            double cost = double.Parse(totalSoFarLabel.Text) + addedItem.cost;
            totalSoFarLabel.Text = cost.ToString();
        }
        private void checkoutButton_MouseClick(object sender, MouseEventArgs e)
        {
            checkout check = new checkout(currentUser.name, currentUser.address, currentUser.ID, currentUser.wallet);
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
