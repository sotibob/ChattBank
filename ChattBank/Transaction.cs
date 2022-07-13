//Sotonte Bob-manuel
//Project 2
//I promise I wrote this code

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattBank
{
    public partial class Transaction : Form //Transaction class
    {
        Customer c1;
        public Transaction() //Default Constructor
        {
            InitializeComponent();
        }
        public Transaction(Customer c) //Constructor that receives data
        {
            InitializeComponent();
            c1 = c;
        }

        private void button3_Click(object sender, EventArgs e) //Event when the Exit button is clicked
        {
            //Dialogue box asking if youre surre you want to exit
            string message = "Are you sure you want to Exit?";
            string title = "Exit!";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
            DialogResult result = MessageBox.Show(message, title, buttons); //Message box

            if (result == DialogResult.Yes) //Yes button
            {
                this.Close(); //Close Applicatiion
            }
            else
            {
                // Do nothing 
            }
        }

        private void Transaction_Load(object sender, EventArgs e) //Event when the Transaction form loads
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button2.Text = "W/D";
            label1.Text = "W/D";
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e) //Event when the Clear button is clicked
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button2.Text = "W/D";
            label1.Text = "W/D";
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Event when the Deposit radiobutton is checked
        {
            button2.Text = "Deposit";
            label1.Text = "Deposit";
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Event when the Withdraw radiobutton is checked
        {
            button2.Text = "Withdraw";
            label1.Text = "Withdraw";
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e) //Event when the Deposit or Withdraw button is clicked
        {
            if(radioButton1.Checked) //Event when the Deposit radiobutton is checked before this evnt was executed
            {
                try
                {
                    //Data is passed from textboxes to variables
                    int acctNo = int.Parse(textBox1.Text);
                    double amount = double.Parse(textBox2.Text);
                    int tcount = c1.acctList.count;
                    int count = 0;
                    int acct = 0;
                    while (count < tcount) //Loops while count is less than the total count of account till it 
                        //finds the account in the database that matches or count is equal to or greater thaan the total count
                    {
                        acct = c1.acctList.acc[count].getAcctNo();
                        if(acct == acctNo)
                        {
                            break; //exits loop is an account number that matches the one inputed is found in the database
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if(acct == acctNo) // Event if an account that matches the one inputed is found in the database
                    {
                        //Dialogue box to ask if youre sure you want to deposit that amount
                        string message = "Are you sure you want to Deposit this amount in to your account?";
                        string title = "Deposit!";

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                        DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                        if (result == DialogResult.Yes) //Yes button
                        {
                            //Amount inputed is added to your original balance and updated
                            double total = c1.acctList.acc[count].getBalance() + amount;
                            c1.acctList.acc[count].setBalance(total);
                            c1.acctList.acc[count].updateDB();
                        }
                        else
                        {
                            // Do nothing
                        }
                    }
                    else //Event when no account in the database matches the one inputed
                    {
                        MessageBox.Show("Invalid Account Number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(radioButton2.Checked) //Event when the Withdraw radiobutton is checked
            {
                try
                {
                    //Data is passed from textboxes to variable
                    int acctNo = int.Parse(textBox1.Text);
                    double amount = double.Parse(textBox2.Text);
                    int tcount = c1.acctList.count;
                    int count = 0;
                    int acct = 0;
                    while (count < tcount)//Loops while count is less than the total count of account till it 
                    //finds the account in the database that matches or count is equal to or greater thaan the total count
                    {
                        acct = c1.acctList.acc[count].getAcctNo();
                        if (acct == acctNo)
                        {
                            break; //exits loop is an account number that matches the one inputed is found in the database
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (acct == acctNo) // Event if an account that matches the one inputed is found in the database
                    {
                        double balance = c1.acctList.acc[count].getBalance();
                        if (balance >= amount) //Event ff the balance is equal to or greater than amount inputed
                        {
                            //Dialogue box to ask if youre sure you want to deposit that amount
                            string message = "Are you sure you want to Withdraw this amount from your account?";
                            string title = "Withdraw!";

                            MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                            DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                            if (result == DialogResult.Yes) //Yes button
                            {
                                //Amount inputed is subtracted from the original balance and updated
                                double total = balance - amount;
                                c1.acctList.acc[count].setBalance(total);
                                c1.acctList.acc[count].updateDB();
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        else //Event if the balance is less than the amount inputed to be withdrawn
                        {
                            MessageBox.Show("Insufficient Funds!");
                        }
                    }
                    else //Event if the account number inputed doesnt match any on the database
                    {
                        MessageBox.Show("Invalid Account Number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else //Event when no radiobutton is checked before this event is executed
            {
                MessageBox.Show("Pick between Withdrawing and Depositing to continue!");
            }
        }
    }
}
