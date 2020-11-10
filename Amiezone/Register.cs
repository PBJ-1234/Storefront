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
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //For id just use date and convert to int or long
            DateTime date = new DateTime();
            long n = long.Parse(date.ToString("yyyyMMddHHmmss"));
            string user = UsernameBox.Text, pass = PasswordBox.Text;
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            projectPath = Path.Combine(projectPath, "Users");
            foreach (string itemFile in Directory.EnumerateFiles(projectPath))
            {
                if (itemFile == user)
                {
                    MessageBox.Show("User already exists");
                    return;
                }
            }
            string path = Path.Combine(projectPath, user);
            string funds = FundsBox.Text, address = AddressBox.Text;
            string[] data = { pass, n.ToString(), funds, address };
            System.IO.File.WriteAllLines(path, data);
        }
    }
}
