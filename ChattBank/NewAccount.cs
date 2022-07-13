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
    public partial class NewAccount : Form //NetAccount class
    {
        Customer c1;
        public NewAccount() //Default Constructor
        {
            InitializeComponent();
        }

        public NewAccount(Customer c) //Constructor that receives data
        {
            InitializeComponent();
            c1 = c;
        }

        private void button3_Click(object sender, EventArgs e) //Event when the exit button is clicked 
        {
            //Dialogue box that asks if youre sure you want to exit
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Event when the Clear button is clicked
        {
            comboBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e) //Event when the AddAcount button is clicked
        {
            try
            {
                if (comboBox1.SelectedItem != null) //When an account type is selected
                {
                    //Dialogue box to ask if youre sure you want to create a new accoount
                    string message = "Are you sure you want to create this new Account?";
                    string title = "Create Account!";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                    DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                    if (result == DialogResult.Yes) //Yes button
                    {
                        //The total number of accounts is calculated and used to create a new account
                        //number and all the data collected and put together is used to create a new account 
                        c1.totalAccounts();
                        int acct = c1.acctList.count;
                        int newAcct = 90000 + acct;
                        int cid = c1.getCustID();
                        String type = comboBox1.Text;
                        Account a1 = new Account(newAcct, cid, type, 0.0);
                        a1.insertDB();
                        c1.selectDB(cid);
                    }
                    else
                    {
                        // Do nothing
                    }
                }
                else //When an account type isnt selected
                {
                    MessageBox.Show("Please select an account type!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
