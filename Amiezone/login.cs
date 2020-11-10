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
    public partial class login : Form
    {
        public login()
        {

            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool exists = false;
            storeClasses.User currentUser = new storeClasses.User();
            string user = UsernameBox.Text, pass = PasswordBox.Text;
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            projectPath = Path.Combine(projectPath, "Users");
            foreach (string itemFile in Directory.EnumerateFiles(projectPath))
            {
                if(itemFile == user)
                {
                    //Setup:
                    /* 
                     * Password
                     * ID
                     * Wallet/Cash
                     * Address
                    */
                    string[] info = System.IO.File.ReadAllLines(itemFile);
                    if(info[0] == pass)
                    {
                        currentUser.password = info[0];
                        currentUser.ID = int.Parse(info[1]);
                        currentUser.wallet = double.Parse(info[2]);
                        currentUser.address = info[3];
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password, please retry login.");
                        return;
                    }
                }
            }
            if(exists == false)
            {
                MessageBox.Show("User does not exist, please retry login.");
                return;
            }
            this.Hide();
            // Will have to figure out how to transfer/ make constructor of form class
            storepage store = new storepage(currentUser.name, currentUser.address, currentUser.ID,
                currentUser.wallet);
            store.Show();
            //modal shows one of those popup boxes like for whitelisting a site on adblock
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register regPage = new Register();
            //Hides login
            this.Close();
            regPage.Show();
        }
    }
    //When accessing files get into Directory.getCurrentDirectory
}
