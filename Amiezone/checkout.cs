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
        StorePage prev;
        public checkout(User newUser, ShoppingCart cart, StorePage store)
        {
            user = newUser;
            currentCart = cart;
            prev = store;
            InitializeComponent();
            CopyDataGridView(StorePage.passingGridTable);
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
        public abstract class Payment
        {
            public double amount;
            public string filePath = Path.Combine(storeClasses.generalFilePath, "ReportsNReciepts", DateTime.Now.ToString("yyyy-MM-dd") + " Income") + ".txt";
            public string[] info;
            public void writePayments(string method, Payment type)
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
        // Card
        public class Card : Payment
        {
            public long RoutingNumber { get; set; }
            public long AccountNumber { get; set; }
            public DateTime expDate;

            public Card(long r, long a)
            {
                this.RoutingNumber = r;
                this.AccountNumber = a;
            }

            public Boolean Authorized(Card daCheck)
            {
                if (DateTime.Now < expDate)
                {
                    return false;
                }
                else
                {
                    if(daCheck.RoutingNumber % 2 == 1 || daCheck.AccountNumber % 2 == 1)
                    {
                        return false;
                    }
                    writePayments("Card", daCheck);
                    return true;
                }
            }
        }
        //Wallet
        public class Wallet : Payment
        {
            // Authorizes then edits file if true
            public Boolean Authorized(User user, double cost, Wallet daWallet)
            {
                if (user.wallet - cost >= 0)
                {
                    user.wallet = user.wallet - cost;

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
                    writePayments("Wallet", daWallet);
                    return true;
                }
                else
                {
                    MessageBox.Show("Insufficient Funds");
                    return false;
                }
            }
        }
        //Bank Check
        public class Bank : Payment
        {
            public string name;
            public long bankID;

            public Bank(string n, long id)
            {
                name = n;
                bankID = id;
            }

            public Boolean Authorized(Bank daBank)
            {
                if (bankID % 2 == 0)
                {
                    writePayments("Check", daBank);
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
            returnButton.Show();
            FinalGridView.Rows.Clear();

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
        private void useWallet(object sender, MouseEventArgs e)
        {
            // Edit for getting just wallet line later
            Wallet newWallet = new Wallet();
            if (newWallet.Authorized(user, double.Parse(cost.Text), newWallet) == true)
            {
                printReciept();
                finishOrder();
            }
            else
            {
                MessageBox.Show("Insufficient Funds");
                return;
            }

        }
        private void useCreditCard(object sender, MouseEventArgs e)
        {
            Card newCard = new Card(user.ID, user.ID / 2);

            newCard.amount = double.Parse(cost.Text);
            if(newCard.Authorized(newCard) == true)
            {

                MessageBox.Show("Card Accepted");
                printReciept();
                finishOrder();
            }
            else
            {
                MessageBox.Show("Denied");
                return;
            }

        }
        private void useBankCheck(object sender, MouseEventArgs e)
        {
            Bank newCheck = new Bank(user.name, user.ID);
            newCheck.amount = double.Parse(cost.Text);
            if (newCheck.Authorized(newCheck) == true)
            {
                MessageBox.Show("Banked");
                printReciept();
                finishOrder();
            }
            else
            {
                MessageBox.Show("Check Bounced");
                return;
            }

        }

        // Opens and refreshes storepage
        private void returnToStore(object sender, MouseEventArgs e)
        {
            this.Close();
            prev.Show();
            prev.Enabled = true;
            prev.reinitalizeUser();
        }
    }
}
