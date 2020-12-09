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
        User user;
        ShoppingCart currentCart;
        storepage prev;
        public checkout(User newUser, ShoppingCart cart, storepage store)
        {
            user = newUser;
            currentCart = cart;
            // https://stackoverflow.com/questions/11165537/passing-textboxs-text-to-another-form-in-c
            // https://www.youtube.com/watch?v=-4sedzHtsqs
            prev = store;
            InitializeComponent();
            CopyDataGridView(storepage.passingGridTable);
            cost.Text = getTotal().ToString();
        }

        // Copies store table to checkout 
        private void CopyDataGridView(DataGridView originalGrid)
        {
            if(originalGrid.Rows.Count > 0)
            {
                FinalGridView.Rows[0].Cells[0].Value = originalGrid.Rows[0].Cells[0].Value;
                FinalGridView.Rows[0].Cells[1].Value = originalGrid.Rows[0].Cells[1].Value;
                FinalGridView.Rows[0].Cells[2].Value = originalGrid.Rows[0].Cells[2].Value;
                FinalGridView.Rows[0].Cells[3].Value = originalGrid.Rows[0].Cells[3].Value;
            }
            // Adds a new row after first row is made
            for (int x = 1; x < originalGrid.Rows.Count; x++)
            {
                FinalGridView.Rows.Add(originalGrid.Rows[x].Cells[0].Value, originalGrid.Rows[x].Cells[1].Value, originalGrid.Rows[x].Cells[2].Value, originalGrid.Rows[x].Cells[3].Value);
            }
        }
        

        // Payment methods
        public abstract class payment
        {
            public double amount;
            public string filePath = Path.Combine(storeClasses.generalFilePath, "ReportsNReciepts", DateTime.Now.ToString("yyyy-MM-dd") + " Income") + ".txt";
            public string[] info;
            public void writePayments(string method, payment type)
            {   
                if(File.Exists(filePath) != true)
                {
                    StreamWriter report = File.AppendText(filePath);
                    report.WriteLine("----------------------------");
                    report.WriteLine("New Income Report: " + method);
                    report.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                    report.WriteLine("----------------------------");
                    report.WriteLine("$" + type.amount.ToString());
                    double total = type.amount;
                    report.WriteLine("Final:\n" + total.ToString());
                    report.Close();
                }
                else
                {
                    string lastLine = File.ReadLines(filePath).Last();
                    StreamWriter report = File.AppendText(filePath);
                    report.WriteLine("----------------------------");
                    report.WriteLine("New Income Report: " + method);
                    report.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                    report.WriteLine("----------------------------");
                    report.WriteLine("$" + type.amount.ToString());
                    double total = double.Parse(lastLine);
                    total = type.amount + total;
                    report.WriteLine("Final:\n" + total.ToString());
                    report.Close();
                }

            }
        }
        // Check
        public class check : payment
        {
            public long RoutingNumber { get; set; }
            public long AccountNumber { get; set; }

            public DateTime expDate;

            public Boolean Authorized(check daCheck)
            {
                if (DateTime.Now > expDate)
                {
                    return false;
                }
                else
                {
                    if(daCheck.RoutingNumber % 2 == 1 || daCheck.AccountNumber % 2 == 1)
                    {
                        return false;
                    }
                    writePayments("Check", daCheck);
                    return true;
                }
            }
        }
        public class bank : payment
        {
            public string name;
            public long bankID;

            public bank(string n, long id)
            {
                name = n;
                bankID = id;
            }

            public Boolean authorized(bank daBank)
            {
                if (bankID % 2 == 0)
                {
                    writePayments("Bank", daBank);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Hides checkout buttons so user can't double click or accidentally make more orders
        private void finishOrder()
        {
            foreach (Control lbl in Controls)
            {
                lbl.Hide();
            }
            label1.Show();
            returnButton.Show();
            FinalGridView.Rows.Clear();

            //Refresh storepage
            this.Close();
            prev.Show();
            prev.Enabled = true;
            prev.reinitalizeUser();
        }

        private void printReciept()
        {
            //Going to need to create the file for the recipet
            string filePath = storeClasses.generalFilePath;
            filePath = Path.Combine(filePath, "ReportsNReciepts", DateTime.Now.ToString("yyyy-MM-dd")) + ".txt";
            
            //Creates file
            if(File.Exists(filePath) != true)
            {
                StreamWriter create = File.CreateText(filePath);
                create.WriteLine("---------------------");
                create.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                create.WriteLine("---------------------");
                create.Close();
            }
            //Writes to file
            int index = 0;
            StreamWriter sw = File.AppendText(filePath);

            sw.WriteLine("User " + user.name + "'s Order on: " + DateTime.Now.ToString("HH:MM:ss:ff"));
            sw.WriteLine("----------------------------------------------------------");
            foreach(DataGridViewRow currentRow in FinalGridView.Rows)
            {
                Item currentItem = Item.getItem(currentRow.Cells[3].Value.ToString(), currentRow.Cells[0].Value.ToString());
                sw.WriteLine("Item #" + (index + 1) + ":");
                sw.WriteLine("Name: " + currentItem.name + " ID: " + currentItem.productID);
                sw.WriteLine("Quantity: " + currentRow.Cells[2].Value.ToString());
                sw.WriteLine("Cost: " + currentItem.cost.ToString() + "\nTotal Cost of Item: " + (currentItem.cost * (int)FinalGridView.Rows[index].Cells[2].Value));
                sw.WriteLine("Item Description: " + currentItem.description);
                sw.WriteLine("");
                index++;
            }
            sw.WriteLine("----------------------------------------------------------\nOrder Returned at: " + DateTime.Now.ToString("HH:MM:ss:ff"));
            sw.Close();
        }

        private double getTotal()
        {
            double cost = 0;
            foreach(DataGridViewRow currentRow in FinalGridView.Rows)
            {
                cost = cost + ((double)(currentRow.Cells[1].Value) * (int)(currentRow.Cells[2].Value));
            }
            return cost;
        }

        private void useBankCheck(object sender, MouseEventArgs e)
        {
            bank newCheck = new bank(user.name, user.ID);
            newCheck.amount = double.Parse(cost.Text);
            if (newCheck.authorized(newCheck) == true)
            {
                MessageBox.Show("Banked");
            }
            else
            {
                MessageBox.Show("Check Bounced");
                return;
            }
            printReciept();
            finishOrder();
        }

        private void useCreditCard(object sender, MouseEventArgs e)
        {
            check newCard = new check();
            newCard.AccountNumber = user.ID;
            newCard.RoutingNumber = user.ID / 2;
            newCard.amount = double.Parse(cost.Text);
            if(newCard.Authorized(newCard) == true)
            {

                MessageBox.Show("Card Accepted");
            }
            else
            {
                MessageBox.Show("Denied");
                return;
            }
            printReciept();
            finishOrder();
        }

        private void useWallet(object sender, MouseEventArgs e)
        {
            // Edit for getting just wallet line later
            if (user.wallet - double.Parse(cost.Text) >= 0)
            {
                user.wallet = user.wallet - (double.Parse(cost.Text));

                string projectPath = storeClasses.generalFilePath;
                projectPath = Path.Combine(projectPath, "Users", user.name) + ".txt";
                string[] info = System.IO.File.ReadAllLines(projectPath);

                user.password = info[0];
                user.ID = long.Parse(info[1]);
                user.address = info[3];

                //Rebuilds user file
                File.Delete(projectPath);
                StreamWriter create = File.CreateText(projectPath);

                create.WriteLine(user.password);
                create.WriteLine(user.ID);
                create.WriteLine(user.wallet);
                create.WriteLine(user.address);
                create.Close();
                prev.reinitalizeUser();
            }
            else
            {
                MessageBox.Show("Insufficient Funds");
                return;
            }
            printReciept();
            finishOrder();
        }
        private void returnToStore(object sender, MouseEventArgs e)
        {
            this.Close();
            prev.Show();
            prev.Enabled = true;
            prev.reinitalizeUser();
        }
    }
}
