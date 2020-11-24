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
            //For id just use date and convert to int or long
            DateTime date = new DateTime();
            long n = date.Ticks;
            string user = UsernameBox.Text + ".txt";
            string pass = PasswordBox.Text;
            string projectPath = storeClasses.generalFilePath;
            projectPath = Path.Combine(projectPath, "Users");
            foreach (string itemFile in Directory.EnumerateFiles(projectPath))
            {
                if (itemFile == user)
                {
                    MessageBox.Show("User already exists");
                    return;
                }
            }
            // Create a file to write to.

            string path = Path.Combine(projectPath, user);
            string funds = FundsBox.Text;
            string address = AddressBox.Text;
            string[] data = { pass, n.ToString(), funds, address };
            string x = pass + n.ToString() + funds + address;
            /*using (StreamWriter sw = File.CreateText(path))
            {
                    sw.WriteLine(pass);
                    sw.WriteLine(n);
                    sw.WriteLine(funds);
                    sw.WriteLine(address);
            }
            */
            System.IO.File.WriteAllLines(path, data);
            loginPage.Enabled = true;
            this.Close();
        }
    }
}
