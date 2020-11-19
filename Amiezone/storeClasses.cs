using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
    // Will need to adjust privacy of classes later
    public class storeClasses
    {
        //Links to Project\Amiezone\Amiezone
        public static string generalFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string getPath(string folder, string file)
        {
            string path = "sdf";
            return path;
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
                //return the file
            }

        }
        public class ShoppingCart
        {
            public List<item> itemIDsInCart = new List<item>();

            public void removeItem(int productID)
            {
                // May need to use int[][] 1st id: 2nd amount
                // Though can just use item lsit
                foreach(item curItem in itemIDsInCart)
                {
                    if(curItem.productID == productID)
                    {
                        itemIDsInCart.Remove(curItem);
                    }
                }
            }
        }

        // Stores and products
        
        public class item
        {
            public int productID;
            public string name;
            public double cost;
            public string description;

            public item()
            {
            }

            public static item GetItem(int id, string store)
            {
                string filePath = Path.Combine(generalFilePath, "Stores", store, id.ToString());
                string[] info = System.IO.File.ReadAllLines(filePath);

                item result = new item();
                int.TryParse(info[0], out result.productID);
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

            public store()
            {
            }

            // Updates/checks the list than returns the list
            public List<item> getItems()
            {
                int currentIndex = 0;
                string filePath = Path.Combine(generalFilePath, "Stores", storeName);
                foreach(string fileName in Directory.EnumerateFiles(filePath))
                {
                    string[] info = System.IO.File.ReadAllLines(fileName);
                    itemsAvailable[currentIndex].name = info[0];
                    double.TryParse(info[1], out itemsAvailable[currentIndex].cost);
                    itemsAvailable[currentIndex].description = info[2];
                }
                return itemsAvailable;
            }


        }
        public class Storefront
        {
            List<store> storelist;

            public Storefront()
            {
            }
            public List<store> listStores()
            {
                return storelist;
            }

        }
    }
}
