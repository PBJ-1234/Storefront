using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amiezone
{
    public partial class checkout : Form
    {
        storeClasses.User user;
        public checkout(string name, string address, int ID, double wallet)
        {
            user.name = name;
            user.address = address;
            user.ID = ID;
            user.wallet = wallet;
            InitializeComponent();
        }


        public void printReciept()
        {
            //Going to need to create the file for the recipet
            //TO DO: Create folders for reciepts

        }

        private void CheckoutButton_MouseClick(object sender, MouseEventArgs e)
        {
            user.wallet = user.wallet - (Convert.ToDouble(cost.Text));
            printReciept();
        }

        private void returnButton_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
