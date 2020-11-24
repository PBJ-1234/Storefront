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
        public Register(login prevPage)
        {
            loginPage = prevPage;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Need to figure out how to get ticks in right
            Boolean exists = false;
            DateTime date = new DateTime();
            long n = date.Ticks;

            // Check that everything has been filled in
            if(UsernameBox.Text == "" || PasswordBox.Text == "" || FundsBox.Text == "" || AddressBox.Text == "")
            {
                MessageBox.Show("Please enter your information in every field");
                return;
            }
            // Turns user textbox into a filepath
            string user = Path.Combine(storeClasses.generalFilePath, "Users", UsernameBox.Text + ".txt");
            string pass = PasswordBox.Text;
            string projectPath = storeClasses.generalFilePath;
            projectPath = Path.Combine(projectPath, "Users");

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
                string path = Path.Combine(projectPath, user);
                string funds = FundsBox.Text;
                string address = AddressBox.Text;
                string[] data = { pass, n.ToString(), funds, address };

                System.IO.File.WriteAllLines(path, data);
                loginPage.Enabled = true;
                this.Close();
            }

        }
        private void exitRegister(object sender, EventArgs e)
        {
            loginPage.Enabled = true;
            this.Close();
        }
    }
}
