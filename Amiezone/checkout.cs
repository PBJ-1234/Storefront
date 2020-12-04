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

        // Rework cloing 
        private void CopyDataGridView(DataGridView originalGrid)
        {
            for (int x = 0; x < originalGrid.Rows.Count; x++)
            {
                FinalGridView.Rows[x].Cells[0].Value = originalGrid.Rows[x].Cells[0].Value;
                FinalGridView.Rows[x].Cells[1].Value = originalGrid.Rows[x].Cells[1].Value;
                FinalGridView.Rows[x].Cells[2].Value = originalGrid.Rows[x].Cells[2].Value;
                FinalGridView.Rows[x].Cells[3].Value = originalGrid.Rows[x].Cells[3].Value;
            }
        }
        

        // Payment methods
        public abstract class payment
        {
            public double amount;
        }
        public class check : payment
        {
            public int RoutingNumber { get; set; }
            public int AccountNumber { get; set; }

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

            public bank(string n, long id)
            {
                name = n;
                bankID = id;
            }

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
                create.WriteLine("----------------------");
                create.WriteLine(DateTime.Now.ToString());
                create.WriteLine("----------------------");
                create.Close();
            }

            //Writes to file
            int index = 0;
            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine("User " + user.name + " Order at" + DateTime.Now.ToString("HH-MM-ss-ff"));
            sw.WriteLine("----------------------------------------------------------");
            foreach(DataGridViewRow currentRow in FinalGridView.Rows)
            {
                Item currentItem = Item.GetItem(currentRow.Cells[3].Value.ToString(), currentRow.Cells[0].Value.ToString());
                sw.WriteLine(currentItem.name + " ( " + currentItem.productID + " )");
                sw.WriteLine("Quantity: " + FinalGridView.Rows[index].Cells[2].Value.ToString());
                sw.WriteLine("Cost: " + currentCart.itemsInCart[index].cost.ToString());
                sw.WriteLine("Desc: " + currentItem.description);
                sw.WriteLine("\n----------------------------------------------------------\nOrder Returned at: " + DateTime.Now.ToString("HH-MM-ss-ff"));
                index++;
            }
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

        private void BankCheckButton_MouseClick(object sender, MouseEventArgs e)
        {
            bank thing = new bank(user.name, user.ID);

            // Checks that it isn't done
            if (thing.authorized() == true)
            {
                MessageBox.Show("Banked");
            }
            else
            {
                MessageBox.Show("Bank account not valid");
                return;
            }
            printReciept();
            finishOrder();
        }

        private void CreditButton_MouseClick(object sender, MouseEventArgs e)
        {
            check newCheck = new check();
            newCheck.AccountNumber = user.ID;
            newCheck.RoutingNumber = user.ID / 2;

            if(newCheck.Authorized() == true)
            {
                MessageBox.Show("credited");
            }
            else
            {
                MessageBox.Show("Check Bounced");
                return;
            }
            printReciept();
            finishOrder();
        }
        private void WalletButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (user.wallet - double.Parse(cost.Text) >= 0)
            {
                user.wallet = user.wallet - (double.Parse(cost.Text));
            }
            else
            {
                MessageBox.Show("Insufficient Funds");
                return;
            }
            label1.Text = ("checked");
            printReciept();
            finishOrder();
        }
        private void returnButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            prev.Show();
            prev.Enabled = true;
            prev.reinitalizeUser();
        }
    }
}
