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
    public partial class CustomerInfo : Form //CustomerInfo form
    {
        Customer c1;
        public CustomerInfo() //Default Constructor
        {
            InitializeComponent();
        }

        public CustomerInfo(Customer c) // Constructor to receive the customer object
        {
            InitializeComponent();
            c1 = c;
        }

        private void CustomerInfo_Load(object sender, EventArgs e) //Event that executes when the form loads
        {
            label3.Text = c1.getCustFirstName();
            label5.Text = c1.getCustLastName();
            label7.Text = c1.getCustAddress();
            label9.Text = c1.getCustEmail();
        }

        private void button4_Click(object sender, EventArgs e) //Event that executes when the Logout button is clicked
        {
            // Dialogue box that asks if you want to log out
            string message = "Are you sure you want to Logout?";
            string title = "Logout!";

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

        private void button3_Click(object sender, EventArgs e) //Events when the ViewAccounts button is clicked
        {
            //Creates a DisplayAccounts object/form, passes the customer object to it and displays it
            DisplayAccounts d1 = new DisplayAccounts(c1);
            d1.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Events when the W/D button is clicked
        {
            //Creates a Transaction object/form, passes the customer object to it and displays it
            Transaction t1 = new Transaction(c1);
            t1.Show();
        }

        private void button1_Click(object sender, EventArgs e) //Event when the AddAccount button is clicked
        {
            //Creates a NewAccount object/form, passes the customer object to it and displays it
            NewAccount n1 = new NewAccount(c1);
            n1.Show();
        }
    }
}
