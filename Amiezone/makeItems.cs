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
            description.Hide();
            createButton.Show();
            itemOrStore = true;
        }
        public void storeShow()
        {
            storeName.Show();
            category.Show();
            createButton.Show();
            itemOrStore = false;
        }
        public void hideEverything()
        {
            description.Hide();
            storeName.Hide();
            category.Hide();
            itemStore.Hide();
            itemName.Hide();
            cost.Hide();
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
                    return false;
                }
                itemPath = Path.Combine(itemPath, itemName.Text);
                //Check if item exists
                if (File.Exists(itemPath) == false)
                {
                    return false;
                }
                //Check if price is valid
                double cost;
                bool res = double.TryParse(this.cost.Text, out cost);
                if (res == false)
                {
                    return false;
                }
                //Check if desc is valid
                if (description.Text == "")
                {
                    return false;
                }
                // Potentially put image load from browser or set default
                return true;
            }
            else
            {
                string storePath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text);
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
        private void button1_Click(object sender, EventArgs e)
        {
            storeShow();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            itemShow();
        }       
        private void createButton_Click(object sender, EventArgs e)
        {
            if(itemOrStore == true && checkInputs() == true)
            {
                //autogen product id based on date
                //will need to convert ids and cut off bits and pieces of the long to convert to secs
                long unixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
                // Could also enumerate through files checking for the most recent and adding 1

                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", itemStore.Text);
                string[] info = { unixSeconds.ToString(), itemName.Text, cost.Text, description.Text};
                System.IO.File.WriteAllLines(filePath, info);

            }
            else if(itemOrStore == false && checkInputs() == true)
            {
                //Create store die
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName.Text);
                Directory.CreateDirectory(filePath);
                //Creates bin/ini/file with filename of category
                filePath = Path.Combine(filePath, "Category");
                Directory.CreateDirectory(filePath);
                System.IO.File.WriteAllText(filePath, category.Text);

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            prev.Show();
            //renables last form
            prev.Enabled = true;
            prev.loadStores();

        }

    }
}
