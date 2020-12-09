using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
 
    //Mainly used for file pathfinding
    public class storeClasses
    {
        // Paths to Project\Amiezone\Amiezone
        public static string generalFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        // Image extensiosn allowed;
        public static string[] exts = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
        public static string imageFilter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

    }
        
    // User and Cart
    public class User
    {
        internal string name;
        internal long ID;
        internal double wallet;
        internal string address;
        internal string password;

        //return the file's contents
        private string[] viewAccountInfo()
        {
            string userPath = Path.Combine(storeClasses.generalFilePath, "Users", name);
            string[] info = System.IO.File.ReadAllLines(userPath);
            return info;
        }
    }

    
    public class ShoppingCart
    {
        public List<Item> itemsInCart = new List<Item>();
        public void removeItem(long productID)
        {
            foreach(Item curItem in itemsInCart)
            {
                if(curItem.productID == productID)
                {
                    itemsInCart.Remove(curItem);
                }
            }
        }
    }

    // Stores and products
            
    /* File Structure:
     * [Name of file is item name]
     * Item ID
     * Item Name
     * Item Cost
     * Item Description
    */        
    public class Item
    {
        public long productID;
        public string name;
        public double cost;
        public string description;
        public string itemFilePath;

        public static Item getItem(string store, string name)
        {
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", store, name) + ".txt";
            string[] info = System.IO.File.ReadAllLines(filePath);

            Item result = new Item();
            result.itemFilePath = filePath;
            long.TryParse(info[0], out result.productID);
            result.name = info[1];
            double.TryParse(info[2], out result.cost);
            result.description = info[3];

            return result;
        }
        public string getItemPic(string filePath)
        {
            string imagePath = filePath + ".png";
            return imagePath;
        }
    }
    
    /* Directory Structure
     *
     * [Folder Name]
     * -> [Folder with name of Store Category]
     * file1.txt
     * file1.jpg
     * file2.txt
     * file2.png
     * ...
    */
    public class Store
    {
        public List<Item> itemsAvailable = new List<Item>();
        public string category;
        public string storeName;

        // Updates/checks the list than returns the list
        public void getAllItems()
        {
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores", storeName);
            string[] files = System.IO.Directory.GetFiles(filePath, "*.txt");

            foreach(string file in files)
            {
                Item newItem = new Item();
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
        //Null referance kinda fixed with intialization
        public List<Store> storelist = new List<Store> { };

        //Potential problem with discovering filepathing
        public void rebuildStores()
        {
            string filePath = Path.Combine(storeClasses.generalFilePath, "Stores");
            string[] directories = Directory.GetDirectories(filePath);
            foreach (string x in directories)
            {
                Store newStore = new Store();
                newStore.storeName = Path.GetFileName(x);

                //May need to fix up problems with finding and reading file
                string storePath = Path.Combine(filePath, x);
                string[] info = Directory.GetDirectories(storePath);
                newStore.category = Path.GetFileNameWithoutExtension(info[0]);

                storelist.Add(newStore);
            }
        }
    }
}
