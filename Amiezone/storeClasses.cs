using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
    class storeClasses
    {
        //Really need a static file getter

        public static string getPath(string folder, string file)
        {
            string path = "sdf";
            return path;
        }
        // Payment methods
        public abstract class payment
        {
            public double amount;
        }
        public class wallet : payment
        {
            public double useCash()
            {
                throw new NotImplementedException();
            }
        }
        public class card : payment
        {
            public int number;
            public int type;
            public DateTime expDate;

            public Boolean authorized()
            {
                return true;
            }
        }
        public class cash : payment
        {
            public double cashTendered;
        }
        public class bank : payment
        {
            public string name;
            public long bankID;

            public Boolean authorized()
            {
                throw new NotImplementedException();
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

            public void addFunds()
            {

            }
            public void modifyAccountInfo()
            {

            }
            private void viewAccountInfo()
            {

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
            public double cost;
            public string description;

            public item()
            {

            }

            public static item GetItem(int id, string store)
            {
                string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                filePath = Path.Combine(filePath, "Stores", store, id.ToString());
                // Read file
                item result = new item();
                string[] info = System.IO.File.ReadAllLines(filePath);
                result.productID = int.Parse(info[0]);
                result.cost = double.Parse(info[1]);
                result.description = info[2];
                return result;
            }
        }
        public class store
        {
            List<item> itemsAvailable;
            public string category;
            public string storeName;

            public void addItems()
            {
                /// asdfsadfsdfasdf
                string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                filePath = Path.Combine(filePath, "Stores");
                foreach(File filename in filePath)
                {

                }
            }

        }
        public class Storefront
        {
            List<store> storelist;

            public List<store> listStores()
            {
                return storelist;
            }

        }
    }
}
