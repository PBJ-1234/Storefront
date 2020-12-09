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
    public partial class Register : Form
    {
        login loginPage;
        StorePage storefront;
        User viewingUser;
        public Register(login prevPage)
        {
            loginPage = prevPage;
            InitializeComponent();
        }
        public Register(StorePage prevPage, User vUser)
        {
            storefront = prevPage;
            viewingUser = vUser;
            InitializeComponent();
            editButton.Show();
            RegisterButton.Hide();

            UsernameBox.Text = viewingUser.name;
            PasswordBox.Text = viewingUser.password;
            FundsBox.Text = viewingUser.wallet.ToString();
            AddressBox.Text = viewingUser.address;

            UsernameBox.ReadOnly = true;
            PasswordBox.ReadOnly = true;
            FundsBox.ReadOnly = true;
            AddressBox.ReadOnly = true;
        }


        private void registerButton(object sender, EventArgs e)
        {
            Boolean exists = false;
            long n = DateTimeOffset.Now.ToUnixTimeSeconds();

            // Check that everything has been filled in
            if(UsernameBox.Text == "" || PasswordBox.Text == "" || FundsBox.Text == "" || AddressBox.Text == "")
            {
                MessageBox.Show("Please enter your information in every field");
                return;
            }
            // Turns user textbox into a filepath
            string user = Path.Combine(storeClasses.generalFilePath, "Users", UsernameBox.Text + ".txt");
            string pass = PasswordBox.Text;
            string projectPath = Path.Combine(storeClasses.generalFilePath, "Users");

            if(loginPage != null)
            {
                // Checks for file existance
                foreach (string itemFile in Directory.EnumerateFiles(projectPath))
                {
                    if (itemFile == user)
                    {
                        MessageBox.Show("User already exists");
                        exists = true;
                        return;
                    }
                }

                // Creates a file to write to if file doesn't already exist.
                if (exists == false)
                {
                    // Creates a file to write to.
                    StreamWriter create = File.CreateText(user);

                    string funds = FundsBox.Text;
                    string address = AddressBox.Text;
                    string[] data = { pass, n.ToString(), funds, address };

                    create.WriteLine(pass);
                    create.WriteLine(n);
                    create.WriteLine(funds);
                    create.WriteLine(address);
                    create.Close();

                    loginPage.Enabled = true;
                    this.Close();
                }
            }
            //Editing
            else if (storefront != null)
            {

                // Deletes file to then remake
                File.Delete(user);
                StreamWriter create = File.CreateText(user);

                string funds = FundsBox.Text;
                string address = AddressBox.Text;
                string[] data = { pass, n.ToString(), funds, address };

                create.WriteLine(pass);
                create.WriteLine(n);
                create.WriteLine(funds);
                create.WriteLine(address);
                create.Close();

                storefront.Enabled = true;
                this.Close();
                viewingUser.wallet = double.Parse(funds);
                viewingUser.address = address;
                storefront.reinitalizeUser();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            PasswordBox.ReadOnly = false;
            FundsBox.ReadOnly = false;
            AddressBox.ReadOnly = false;
            RegisterButton.Show();
        }

        private void exitRegister(object sender, EventArgs e)
        {
            if (loginPage != null)
            { 
                loginPage.Enabled = true;
                this.Close();
            }
            else if(storefront != null)
            {
                storefront.Enabled = true;
                this.Close();
            }
        }
    }
}
