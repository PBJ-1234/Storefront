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
            itemOrStore = true;
        }
        public void itemHide()
        {
            itemStore.Hide();
            itemName.Hide();
            cost.Hide();
            description.Hide();
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
                // Potentially put image load from browser or set default

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
                //autogen product id based on date
                //will need to convert ids and cut off bits and pieces of the long to convert to secs
                //https://stackoverflow.com/questions/4873493/how-can-i-convert-number-of-seconds-since-1970-to-datetime-in-c
                long unixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Could also enumerate through files checking for the most recent and adding 1
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text, itemName.Text) + ".txt";
                string[] info = { unixSeconds.ToString(), itemName.Text, cost.Text, description.Text };
                System.IO.File.WriteAllLines(filePath, info);

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
