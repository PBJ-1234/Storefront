using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Amiezone
{
    public partial class makeItems : Form
    {
        // True: item being made
        // False: store being made
        private Boolean itemOrStore;
        StorePage prev;
        public makeItems(StorePage restore)
        {
            InitializeComponent();
            hideEverything();
            prev = restore;
        }
        // Just a bunch of mini methods to selectively choose what to hide/show
        public void itemShow()
        {
            itemStore.Show();
            itemName.Show();
            cost.Show();
            description.Show();
            createButton.Show();
            imagePath.Show();
            picturePreview.Show();
            browseButton.Show();
            itemOrStore = true;
        }
        public void itemHide()
        {
            itemStore.Hide();
            itemName.Hide();
            cost.Hide();
            description.Hide();
            imagePath.Hide();
            picturePreview.Hide();
            browseButton.Hide();
        }

        public void storeShow()
        {
            storeName.Show();
            category.Show();
            createButton.Show();
            itemOrStore = false;
        }
        public void storeHide()
        {
            storeName.Hide();
            category.Hide();
        }

        public void hideEverything()
        {
            itemHide();
            storeHide();
            createButton.Hide();
        }

        private void createStore(object sender, MouseEventArgs e)
        {
            storeShow();
            itemHide();
        }
        private void createItem(object sender, MouseEventArgs e)
        {
            itemShow();
            storeHide();
        }
        // Checks itemstore state then drills down each check to confirm order
        public Boolean checkInputs()
        {
            
            if(itemOrStore == true)
            {
                //Check if store exists
                string itemPath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text);
                if (Directory.Exists(itemPath) == false)
                {
                    MessageBox.Show("Store does not exist");
                    return false;
                }
                //Check if item exists
                itemPath = Path.Combine(itemPath, itemName.Text) + ".txt";
                if (File.Exists(itemPath) == true)
                {
                    MessageBox.Show("Please do not reuse item names");
                    return false;
                }
                //Check if price is valid
                double cost;
                bool res = double.TryParse(this.cost.Text, out cost);
                if (res == false)
                {
                    MessageBox.Show("Invalid Number");
                    return false;
                }
                //Check if desc is valid
                if (description.Text == "")
                {
                    MessageBox.Show("Please Enter a description");
                    return false;
                }
                //Check if image path exists, defaults ifit doesn't
                if (File.Exists(imagePath.Text) == false || isImage(Path.GetExtension(imagePath.Text)) == false)
                {
                    imagePath.Text = Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg");
                }

                return true;
            }
            else
            {
                //Check if store exists and is valid
                string storePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName.Text);
                if (Directory.Exists(storePath) == true)
                {
                    return false;
                }
                //Create category is valid
                if (category.Text == "")
                {
                    return false;
                }
                
                return true;
            }
        }

        // Actual function that creates file
        private void createObject(object sender, MouseEventArgs e)
        {

            if(itemOrStore == true && checkInputs() == true)
            {
                // Autogen product id based on date
                long unixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Rounds cost for proper entry
                decimal costEdit = decimal.Parse(cost.Text);
                costEdit = Math.Round(costEdit, 2);
                // Creates File
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text, itemName.Text);
                string[] info = { unixSeconds.ToString(), itemName.Text, costEdit.ToString(), description.Text };
                System.IO.File.WriteAllLines(filePath + ".txt", info);
                // Copies image from path chosen
                System.IO.File.Copy(imagePath.Text, filePath + Path.GetExtension(imagePath.Text));


            }
            else if(itemOrStore == false && checkInputs() == true)
            {
                //Create store directory
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName.Text);
                Directory.CreateDirectory(filePath);
                //Creates folder with name of category
                filePath = Path.Combine(filePath, category.Text);
                Directory.CreateDirectory(filePath);
            }
        }
        // Opens up file browser for user to search for image then copies to items location
        private void selectPicture(object sender, MouseEventArgs e)
        {
            string path;
            OpenFileDialog imageSearch = new OpenFileDialog();
            imageSearch.ShowDialog();
            imageSearch.InitialDirectory = @"C:\";
            imageSearch.Filter = storeClasses.imageFilter;

            if (imageSearch.ShowDialog() == DialogResult.OK)
            {
                path = imageSearch.FileName;
                imagePath.Text = path;
                if (File.Exists(imagePath.Text) == false || isImage(Path.GetExtension(imagePath.Text)) == false)
                {
                    MessageBox.Show(Path.GetExtension(imagePath.Text));
                    MessageBox.Show("File does not exist or not a valid image format: " + '(' + storeClasses.exts + ')');
                    string defaultPath = Path.Combine(storeClasses.generalFilePath, "Stores", "defaultImage.jpg");
                    picturePreview.Image = Image.FromFile(defaultPath);
                }
                else
                {
                    imagePath.Text = path;
                    picturePreview.Image = Image.FromFile(path);
                }
            }
        }
        // Helper for selectPicture to see if has valid extension, (check storeClasses for exts list)
        private bool isImage(string extension)
        {
            if(storeClasses.exts.Contains(extension.ToLower()) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Returns to store
        private void returnPage(object sender, MouseEventArgs e)
        {
            prev.Show();
            prev.Enabled = true;
            prev.loadStores();
            this.Close();
        }

    }
}
