//Sotonte Bob-manuel
//Project 2
//I promise I wrote this code

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattBank
{
    public class Customer // Customer Class
    {
        //Initializing all the properties for this class
        public int cID;
        public int cPassword;
        String cFirstName;
        String cLastName;
        String cAddress;
        String cEmail;
        public AccountList acctList;

        public Customer() //Defaul constructor
        {
            cID = 0;
            cPassword = 0;
            cFirstName = "";
            cLastName = "";
            cAddress = "";
            cEmail = "";
            acctList = new AccountList();
        }

        public Customer(int CustID, int CustPassword, String CustFirstName, String CustLastName, String CustAddress, String CustEmail) //Constructor to collect data
        {
            cID = CustID;
            cPassword = CustPassword;
            cFirstName = CustFirstName;
            cLastName = CustLastName;
            cAddress = CustAddress;
            cEmail = CustEmail;
        }

        //Set and Get methods
        public void setCustID(int CustID) { cID = CustID; }
        public int getCustID() { return cID; }

        public void setCustPassword(int CustPassword) { cPassword = CustPassword; }
        public int getCustPassword() { return cPassword; }

        public void setCustFirstName(String CustFirstName) { cFirstName = CustFirstName; }
        public String getCustFirstName() { return cFirstName; }

        public void setCustLastName(String CustLastName) { cLastName = CustLastName; }
        public String getCustLastName() { return cLastName; }

        public void setCustAddress(String CustAddress) { cAddress = CustAddress; }
        public String getCustAddress() { return cAddress; }

        public void setCustEmail(String CustEmail) { cEmail = CustEmail; }
        public String getCustEmail() { return cEmail; }

        public void totalAccounts() //Method to get the total of all accounts
        {
            cmd = "Select AcctNo from Accounts";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                int an;
                Account a1;
                acctList.count = 0;

                while (dr.Read())
                {
                    a1 = new Account();
                    an = Int32.Parse(dr.GetValue(0) + "");
                    a1.selectDB(an);
                    acctList.addAccount(a1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }

        public void getAccounts() //Method get all the accounts of a customer
        {
            cmd = "Select AcctNo from Accounts where Cid = '" + cID + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
                int an;
                Account a1;

                while (dr.Read())
                {
                    a1 = new Account();
                    an = Int32.Parse(dr.GetValue(0) + "");
                    a1.selectDB(an);
                    acctList.addAccount(a1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }

        public void Display() //Display Method
        {
            Console.WriteLine("Customer ID    : " + getCustID());
            Console.WriteLine("Customer Password    : " + getCustPassword());
            Console.WriteLine("Customer FirstName  : " + getCustFirstName());
            Console.WriteLine("Customer LastName  : " + getCustLastName());
            Console.WriteLine("Customer Address   : " + getCustAddress());
            Console.WriteLine("Customer Email : " + getCustEmail());
            Console.WriteLine("==============================");
            acctList.Display();
        }

        //=============================  BEHAVIORS =========================
        //++++++++++++++++  DATABASE Data Elements +++++++++++++++++
        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public string cmd;

        public void DBSetup() //Database Setup
        {
            // +++++++++++++++++++++++++++  DBSetup function +++++++++++++++++++++++++++++++
            OleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
            OleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbConnection2 = new System.Data.OleDb.OleDbConnection();

            //OleDbDataAdapter1
            OleDbDataAdapter2.DeleteCommand = OleDbDeleteCommand2;
            OleDbDataAdapter2.InsertCommand = OleDbInsertCommand2;
            OleDbDataAdapter2.SelectCommand = OleDbSelectCommand2;
            OleDbDataAdapter2.UpdateCommand = OleDbUpdateCommand2;

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" +
            "ocking Mode=1;Data Source=c:\\Users\\Sotonte Bob-manuel\\OneDrive\\Documents\\Java DB\\ChattBankMDB.mdb;J" +
            "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
            "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
            "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
            "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
            "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
        }  //end DBSetup()

        public void selectDB(int CustID) //Select Method
        { //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
            DBSetup();
            cmd = "Select * from Customers where CustID = '" + CustID + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                dr.Read();
                cID = int.Parse(dr.GetValue(0) + "");
                cPassword = int.Parse(dr.GetValue(1) + "");
                cFirstName = dr.GetValue(2) + "";
                cLastName = dr.GetValue(3) + "";
                cAddress = dr.GetValue(4) + "";
                cEmail = dr.GetValue(5) + "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
            getAccounts();
        } //end SelectDB()

        public void insertDB() //Insert Method
        {
            // +++++++++++++++++++++++++++  INSERT +++++++++++++++++++++++++++++++

            DBSetup();
            cmd = "INSERT into Customers values('" + cID + "', '" +
                                    cPassword + "', '" + cFirstName + "', '" + cLastName 
                                    + "', '" + cAddress + "', '" + cEmail + "')";

            OleDbDataAdapter2.InsertCommand.CommandText = cmd;
            OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Inserted");
                else
                    Console.WriteLine("ERROR: Inserting Data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        } //end InsertDB()

        public void updateDB() //Update Method
        {
            //++++++++++++++++++++++++++  UPDATE  +++++++++++++++++++++++++

            cmd = "Update Customers set CustPassword = '" + cPassword +
                         "', CustFirstName = '" + cFirstName + "', CustLastName = '" + cLastName +
                         "', CustAddress = '" + cAddress + "', CustEmail = '" + cEmail + "' where CustID = '" + cID + "'";

            OleDbDataAdapter2.UpdateCommand.CommandText = cmd;
            OleDbDataAdapter2.UpdateCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.UpdateCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Updated");
                else
                    Console.WriteLine("ERROR: Updating Data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        } //end UpdateDB()

        public void deleteDB() //Delete Method
        {
            //++++++++++++++++++++++++++  DELETE  +++++++++++++++++++++++++

            cmd = "Delete from Customers where CustID = '" + cID + "'";
            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Data Deleted");
                }
                else
                {
                    Console.WriteLine("ERROR: Deleting Data");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        } //end DelectDB()
    }
}
