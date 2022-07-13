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
    public partial class Form1 : Form //Form1 class
    {
        public Form1() //Default constructor
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)//Events when the exit button is clicked
        {
            //Dialogue box that asks if you actually want to exit
            string message = "Are you sure you want to exit?";
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

        private void button1_Click(object sender, EventArgs e) //Events when the Clear button is clicked
        {
            textBox1.Text = null;
            textBox2.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e) //Events when the Login button is clicked
        {
            if(radioButton1.Checked) //Event if the Customer radiobutton is checked before the Login button is clicked
            {
                try
                {
                    //Data is passed from the textboxes to a variable and customer object is created and is used to pull a customers information
                    int Id = int.Parse(textBox1.Text);
                    int password = int.Parse(textBox2.Text);
                    Customer c1 = new Customer();
                    c1.selectDB(Id);
                    if(c1.getCustID() == Id && c1.getCustPassword() == password) //Event if the data input matches the data in the database 
                    {
                        //CustomerInfo object/form is created and the customer object is passed to it and it is displayed
                        CustomerInfo cI1 = new CustomerInfo(c1);
                        cI1.Show();
                    }
                    else //Event when the password or Id inputed doesnt match any in the database
                    {
                        MessageBox.Show("Incorrect Customer ID and Password!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(radioButton2.Checked) //Event if the Admin radiobutton is checked before the Login button is clicked
            {
                try
                {
                    //Data is passed from the textboxes to a variable
                    String Id = textBox1.Text;
                    int password = int.Parse(textBox2.Text);
                    if (Id == "admin" || Id == "Admin" && password == 123) //Event if the Id is = admin or Admin and the password is = 123
                    {
                        //Admin object/form is created and diplayed
                        Admin a1 = new Admin();
                        a1.Show();
                    }
                    else //Event when the password or Id inputed doesnt match any in the database
                    {
                        MessageBox.Show("Incorrect Admin ID and Password!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else //Event when no radiobutton is checked
            {
                MessageBox.Show("Pick a User!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Events when the customer radiobutton is checked
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Events when the Admin radiobutton is checked
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e) //Events when the form loads
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = null;
            textBox2.Text = null;
        }
    } 
}
