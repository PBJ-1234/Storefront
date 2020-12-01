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
            User currentUser = new User();
            string user = Path.Combine(storeClasses.generalFilePath, "Users", UsernameBox.Text + ".txt");
            string pass = PasswordBox.Text;

            string projectPath = storeClasses.generalFilePath;
            projectPath = Path.Combine(projectPath, "Users");

            foreach (string itemFile in Directory.EnumerateFiles(projectPath))
            {
                if(itemFile == user)
                {
                    exists = true;
                    string[] info = System.IO.File.ReadAllLines(itemFile);
                    if(info[0] == pass)
                    {
                        currentUser.name = UsernameBox.Text;
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
            storepage store = new storepage(currentUser);
            store.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register regPage = new Register(this);
            //closes login
            regPage.Show();
            this.Enabled = false;
        }
    }
}
