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
    public partial class Admin : Form // Admin Form
    {
        public Admin() //Default Constructor
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) //Event when the Logout button is clicked
        {
            //Message box to ask if you are sure you want to log out
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Events when the Create radiobutton is clicked
        {
            label1.Text = "Create New Customer";
            button2.Text = "Create";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Events when the Delete radiobutton is clicked
        {
            label1.Text = "Delete Customer";
            button2.Text = "Delete";
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e) //Events when the Clear button clicked
        {
            label1.Text = "Customer";
            button2.Text = "Customer";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e) //Events when the Create or Delete button is clicked
        {
            if(radioButton1.Checked) //Events if the Create radiobutton is clicked before this event was to execute
            {
                try
                {
                    //Collecting data from the textboxes and inputing them into the custoer class
                    int Id = int.Parse(textBox1.Text);
                    int password = int.Parse(textBox2.Text);
                    String fn = textBox3.Text;
                    String ln = textBox4.Text;
                    String address = textBox5.Text;
                    String email = textBox6.Text;
                    Customer c1 = new Customer(Id, password, fn, ln, address, email);
                    if (!(Id == 0) && !(password == 0) && !(fn == "") && !(ln == "")) //If the key values are not left empty this event execute
                    {
                        //Message box to confirm if you want to insert this data and create a new customer
                        string message = "Are you sure you want to Create a new Customer?";
                        string title = "Create Customer!";

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                        DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                        if (result == DialogResult.Yes) //Yes button
                        {
                            c1.insertDB();
                        }
                        else
                        {
                            // Do nothing 
                        }
                    }
                    else //Event if the key values are left empty or is null
                    {
                        MessageBox.Show("Cannot leave the ID, Password, First Name, or Last Name empty!"); //Message box to remind you to input data
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(radioButton2.Checked) //Event if the Delete radiobutton was clicked before this event was executed
            {
                try
                {
                    //Collecting data from the textboxes and using them to pull the information about a customer
                    int Id = int.Parse(textBox1.Text);
                    Customer c1 = new Customer();
                    c1.selectDB(Id);
                    if(c1.getCustID() == Id) //Event if that data is in the database
                    {
                        //Dialogue box aasking if you really want to delete that customers information
                        string message = "Are you sure you want to Delete this Customer?";
                        string title = "Delete Customer!";

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                        DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                        if (result == DialogResult.Yes) //Yes button
                        {
                            c1.deleteDB();
                        }
                        else
                        {
                            // Do nothing 
                        }
                    }
                    else //Event if that information doesnt match any in the database
                    {
                        MessageBox.Show("Input a valid ID!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else //Event if no radiobutton is checked before trying to execute this event
            {
                MessageBox.Show("Choose one of the options; to Create or Delete a Customer!");
            }
        }

        private void Admin_Load(object sender, EventArgs e) // Event when this form loads
        {
            label1.Text = "Customer";
            button2.Text = "Customer";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
