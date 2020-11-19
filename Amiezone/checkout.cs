using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Amiezone
{
    public partial class checkout : Form
    {
        storeClasses.User user;
        storeClasses.ShoppingCart currentCart;
        
        //Again figure out problems with addressing or just pass the list of the cart
        public checkout(string name, string address, int ID, double wallet, storeClasses.ShoppingCart cartie)
        {
            user.name = name;
            user.address = address;
            user.ID = ID;
            user.wallet = wallet;
            currentCart = cartie;
            InitializeComponent();
        }
        public checkout(storeClasses.User newUser, storeClasses.ShoppingCart cart)
        {
            user = newUser;
            currentCart = cart;
        }

        // Payment methods
        public abstract class payment
        {
            public double amount;
        }
        // likely useless class, since user already has it
        // Figure out or just call the users info through the storepage form
        /*
        public class wallet : payment
        {
            public double useCash()
            {
                throw new NotImplementedException();
            }
        }
        */
        public class check : payment
        {
            private int routingNumber, accountNumber;
            public int RoutingNumber
            {
                get { return routingNumber; }
                set { value = routingNumber; }
            }
            public int AccountNumber
            {
                get { return accountNumber; }
                set { value = accountNumber; }
            }
            public DateTime expDate;

            public Boolean Authorized()
            {
                if (DateTime.Now > expDate)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public class bank : payment
        {
            public string name;
            public long bankID;

            public Boolean authorized()
            {
                if (bankID % 2 == 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public void printReciept()
        {
            //Going to need to create the file for the recipet
            string filePath = storeClasses.generalFilePath;
            filePath = Path.Combine(filePath, "ReportsNReciepts", DateTime.Now.ToString());

            //Creates file
            StreamWriter create = File.CreateText(filePath);
            create.WriteLine(DateTime.Now.ToString());

            //Writes to file
            int index = 0;
            StreamWriter sw = File.AppendText(filePath);
            while (index <= currentCart.itemIDsInCart.Count())
            {
                string[] text;
                //text[0] = currentCart.itemIDsInCart[index].productID.ToString());

                sw.WriteLine(currentCart.itemIDsInCart[index].productID.ToString());
                sw.WriteLine(currentCart.itemIDsInCart[index].name);
                sw.WriteLine(currentCart.itemIDsInCart[index].cost.ToString());
                sw.WriteLine(currentCart.itemIDsInCart[index].description);
                index++;
            }
        }

        private void CheckoutButton_MouseClick(object sender, MouseEventArgs e)
        {
            user.wallet = user.wallet - (Convert.ToDouble(cost.Text));
            printReciept();
        }

        private void returnButton_MouseClick(object sender, MouseEventArgs e)
        {
            //storepage store = new storepage(user.name, user.address, user.ID, user.wallet, currentCart);
            storepage store = new storepage(user, currentCart);
            this.Close();
            store.Show();
        }
    }
}
