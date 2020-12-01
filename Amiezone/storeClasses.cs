using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
    /*
     Classes and their components​​
    Inheritance
    Encapsulation
    Polymorphism
    Abstraction

    More Advanced Topics:
    (up to 10% possible)
    (extra credit opportunity)
    Code Organization
    Interfaces (object-orieted meaning)
    Multiple Inheritance / Interfaces
    Clean, Maintanable Code
    SOLID Principles
    Automated Unit Testing
    https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
     */

    // Will need to adjust privacy of classes later
    public class storeClasses
    {
        //Paths to Project\Amiezone\Amiezone
        public static string generalFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public static string getPath(string folder, string file)
        {
            string path = "sdf";
            return path;
        }
    }
        // User and Cart
        
        public class User
        {
            public string name;
            public int ID;
            public double wallet;
            public string address;
            public string password;

            public void modifyFunds(double funds)
            {
                wallet = wallet + funds;
            }
            public void modifyAccountInfo()
            {
                string userPath = Path.Combine(storeClasses.generalFilePath, "Users", name);
                //TO DO: Rework register page to allow for use or create another form entirely
                //open up box or form to change file

            }
            //return the file
            private void viewAccountInfo()
            {
                string userPath = Path.Combine(storeClasses.generalFilePath, "Users", name);
                string[] info = System.IO.File.ReadAllLines(userPath);
                MessageBox.Show(String.Format( info[0] + info[1] + info[2] + info[3] + info[4]));
            }
        }

    
        public class ShoppingCart
        {
            public List<item> itemsInCart = new List<item> { };

            public void removeItem(int productID)
            {
                // May need to use int[][] 1st id: 2nd amount
                // Though can just use item lsit
                foreach(item curItem in itemsInCart)
                {
                    if(curItem.productID == productID)
                    {
                        itemsInCart.Remove(curItem);
                    }
                }
            }
        }

        // Stores and products
        
        public class item
        {
            public long productID;
            public string name;
            public double cost;
            public string description;
            public string  itemFilePath;

            public static item GetItem(string store, string name)
            {
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", store, name) + ".txt";
                string[] info = System.IO.File.ReadAllLines(filePath);

                item result = new item();
                long.TryParse(info[0], out result.productID);
                result.name = info[1];
                double.TryParse(info[2], out result.cost);
                result.description = info[3];

                return result;
            }
            public string GetItemPic(string filePath)
            {
                string imagePath = filePath + ".png";
                return imagePath;
            }
        }
        public class store
        {
            List<item> itemsAvailable = new List<item>();
            public string category;
            public string storeName;

            // Updates/checks the list than returns the list
            public void getItems()
            {
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName);
                string[] files = System.IO.Directory.GetFiles(filePath, "*.txt");

                foreach(string file in files)
                {
                    item newItem = new item();
                    string[] info = System.IO.File.ReadAllLines(file);
                    newItem.productID = long.Parse(info[0]);
                    newItem.name = info[1];
                    double.TryParse(info[2], out newItem.cost);
                    newItem.description = info[3];

                    itemsAvailable.Add(newItem);
                }

            }


        }
        public class Storefront
        {
            //Null referance fix with intialization or implementation as own class
            public List<store> storelist = new List<store> { };


            //Potential problem with discovering filepathing
            public void rebuildStores()
            {
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores");
                string[] directories = Directory.GetDirectories(filePath);
                foreach (string x in directories)
                {
                    store newStore = new store();
                    newStore.storeName = Path.GetFileName(x);

                    //May need to fix up problems with finding and reading file
                    //might just read file for the category, seems inefficient
                    string storePath = Path.Combine(filePath, x);
                    string[] info = Directory.GetDirectories(storePath);
                    newStore.category = Path.GetFileNameWithoutExtension(info[0]);

                    storelist.Add(newStore);
                }
            }
        }
    
}
