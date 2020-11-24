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
                //open up box or form to change file

            }
            private void viewAccountInfo()
            {
                string userPath = Path.Combine(storeClasses.generalFilePath, "Users", name);
                string[] info = System.IO.File.ReadAllLines(userPath);
                MessageBox.Show(String.Format("Name: {0}\nCurrent Funds{1}\n", info[0], info[1], info[2], info[3], info[4]));
            }
            //return the file
        }

    
        public class ShoppingCart
        {
            public List<item> itemsInCart = new List<item>();

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

            public static item GetItem(string name, string store)
            {
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", store, name);
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
            List<item> itemsAvailable;
            public string category;
            public string storeName;

            // Updates/checks the list than returns the list
            public List<item> getItems()
            {
                int currentIndex = 0;
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName);
                string[] files = System.IO.Directory.GetFiles(filePath, "*.txt");

                foreach(string file in files)
                {
                    string[] info = System.IO.File.ReadAllLines(file);
                    itemsAvailable[currentIndex].productID = long.Parse(info[0]);
                    itemsAvailable[currentIndex].name = info[1];
                    double.TryParse(info[2], out itemsAvailable[currentIndex].cost);
                    itemsAvailable[currentIndex].description = info[3];
                    currentIndex++;
                }

                return itemsAvailable;
            }


        }
        public class Storefront
        {
            public List<store> storelist;

            //Potential problem with discovering filepathing
            public List<store> rebuildStores()
            {
                string filePath = Path.Combine(storeClasses.generalFilePath, "Stores");
                string[] directories = Directory.GetDirectories(filePath);
                foreach (string x in directories)
                {
                    filePath = Path.Combine(filePath, x, "Category");
                    store newStore = new store();
                    newStore.storeName = x;

                    string[] catFile = Directory.GetFiles(filePath);
                    newStore.category = catFile[0];
                    storelist.Add(newStore);
                }

                return storelist;
            }

        }
    
}
