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
    public partial class DisplayAccounts : Form // DisplayAccounts class
    {
        //Initialize the properties of the class
        Customer c1;
        int count = 0;
        int tcount;
        public DisplayAccounts() //Default constructor
        {
            InitializeComponent();
        }

        public DisplayAccounts(Customer c) //Constructor that receives the customer object
        {
            InitializeComponent();
            c1 = c;
        }

        private void button3_Click(object sender, EventArgs e) //Event when the Exit button was clicked
        {
            //Dialogue box to ask if you are sure you want to exit
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

        private void DisplayAccounts_Load(object sender, EventArgs e) // Events that execute when the form loads
        {
            //Displays the customers account information in their various labels
            tcount = c1.acctList.count;
            label1.Text = "Customer " + c1.getCustID().ToString();
            label3.Text = c1.acctList.acc[count].getAcctNo().ToString();
            label5.Text = c1.acctList.acc[count].getType();
            label7.Text = "$" + c1.acctList.acc[count].getBalance().ToString();
            count++;
        }

        private void button2_Click(object sender, EventArgs e) //Events that execute when the Next button is clicked
        {
            if (count == 0 && tcount > 1) //Event if the count is at Zero and the total count is greater than 1
            {
                count++;
                label3.Text = c1.acctList.acc[count].getAcctNo().ToString();
                label5.Text = c1.acctList.acc[count].getType();
                label7.Text = "$" + c1.acctList.acc[count].getBalance().ToString();
            }
            else if (count < tcount) //Event if the count is still less than the  total amount of accounts
            {
                label3.Text = c1.acctList.acc[count].getAcctNo().ToString();
                label5.Text = c1.acctList.acc[count].getType();
                label7.Text = "$" + c1.acctList.acc[count].getBalance().ToString();
                count++;
            }
            else //If the count is equal to or greater than the total account
            {
                MessageBox.Show("There are no more Accounts available to view!");
            }
        }

        private void button1_Click(object sender, EventArgs e) //Events that execute when the Previous button is clicked
        {
            if (count == tcount && count > 1) //Event if the count is same as the total count and count is greater than 1
            {
                count = count - 2;
                label3.Text = c1.acctList.acc[count].getAcctNo().ToString();
                label5.Text = c1.acctList.acc[count].getType();
                label7.Text = "$" + c1.acctList.acc[count].getBalance().ToString();
            }
            else if (count > 0) //Event if the count is greater than 0
            {
                count--;
                label3.Text = c1.acctList.acc[count].getAcctNo().ToString();
                label5.Text = c1.acctList.acc[count].getType();
                label7.Text = "$" + c1.acctList.acc[count].getBalance().ToString();
            }
            else //If the count is equal to or less than 0
            {
                //Do nothing
            }
        }
    }
}
