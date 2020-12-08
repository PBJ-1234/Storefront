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
        storepage prev;
        public makeItems(storepage restore)
        {
            InitializeComponent();
            hideEverything();
            prev = restore;
        }

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
                itemPath = Path.Combine(itemPath, itemName.Text);
                //Check if item exists
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
                string storePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName.Text);
                //Check if store exists and is valid
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
        private void CreateStore(object sender, EventArgs e)
        {
            storeShow();
            itemHide();
        }
        private void CreateItem(object sender, EventArgs e)
        {
            itemShow();
            storeHide();
        }

        private void createButton_Click(object sender, EventArgs e)
        {

            if(itemOrStore == true && checkInputs() == true)
            {
                // Autogen product id based on date
                // Will need to convert ids and cut off bits and pieces of the long to convert to secs
                //https://stackoverflow.com/questions/4873493/how-can-i-convert-number-of-seconds-since-1970-to-datetime-in-c
                long unixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();

                // Creates File
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text, itemName.Text);
                string[] info = { unixSeconds.ToString(), itemName.Text, cost.Text, description.Text };
                System.IO.File.WriteAllLines(filePath + ".txt", info);

                // Copies image from path
                MessageBox.Show(imagePath.Text, filePath + Path.GetExtension(imagePath.Text));
                System.IO.File.Copy(imagePath.Text, filePath + Path.GetExtension(imagePath.Text));


            }
            else if(itemOrStore == false && checkInputs() == true)
            {
                //Create store die
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName.Text);
                Directory.CreateDirectory(filePath);
                //Creates folder with name of category
                filePath = Path.Combine(filePath, category.Text);
                Directory.CreateDirectory(filePath);
            }
        }

        private void selectPicture_Click(object sender, EventArgs e)
        {
            //Copies chosen file for pic
            string path;
            OpenFileDialog imageSearch = new OpenFileDialog();
            imageSearch.ShowDialog();
            imageSearch.InitialDirectory = @"C:\";
            imageSearch.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (imageSearch.ShowDialog() == DialogResult.OK)
            {
                path = imageSearch.FileName;
                imagePath.Text = path;
                if (File.Exists(imagePath.Text) == false || isImage(Path.GetExtension(imagePath.Text)) == false)
                {
                    MessageBox.Show(Path.GetExtension(imagePath.Text));
                    MessageBox.Show("File does not exist or not a valid image format: (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)");
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

        private bool isImage(string extension)
        {
            string[] exts = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
            if(exts.Contains(extension.ToLower()) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            prev.Show();
            //renables last form
            prev.Enabled = true;
            prev.loadStores();
            this.Close();
        }

    }
}
