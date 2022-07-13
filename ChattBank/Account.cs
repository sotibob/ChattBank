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
    public class Account //Account class
    {
        //Initializing the properties of the class
        int acctNo;
        int cID;
        String type;
        double balance;

        public Account() //Default constructor
        {
            acctNo = 0;
            cID = 0;
            type = "";
            balance = 0.0;
        }

        public Account(int AcctNo, int Cid, String Type, double Balance) //Constructor wiith an argument
        {
            acctNo = AcctNo;
            cID = Cid;
            type = Type;
            balance = Balance;
        }

        //Get and Set methods
        public void setAcctNo(int AcctNo) { acctNo = AcctNo; }
        public int getAcctNo() { return acctNo; }

        public void setCid(int Cid) { cID = Cid; }
        public int getCid() { return cID; }

        public void setType(String Type) { type = Type; }
        public String getType() { return type; }

        public void setBalance(double Balance) { balance = Balance; }
        public double getBalance() { return balance; }

        public void Display() //Display Method
        {
            Console.WriteLine("Account No    : " + getAcctNo());
            Console.WriteLine("Customer ID    : " + getCid());
            Console.WriteLine("Account Type   : " + getType());
            Console.WriteLine("Balance : $" + getBalance());
            Console.WriteLine("==============================");
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

        public void DBSetup() //Database Setup Method
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

        public void selectDB(int AcctNo) //Select Method
        { //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
            DBSetup();
            cmd = "Select * from Accounts where AcctNo = '" + AcctNo + "'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                dr.Read();
                acctNo = int.Parse(dr.GetValue(0) + "");
                cID = int.Parse(dr.GetValue(1) + "");
                type = dr.GetValue(2) + "";
                balance = double.Parse(dr.GetValue(3) + "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        } //end SelectDB()

        public void insertDB() //Insert Method
        {
            // +++++++++++++++++++++++++++  INSERT +++++++++++++++++++++++++++++++

            DBSetup();
            cmd = "INSERT into Accounts values('" + acctNo + "', '" +
                                    cID + "', '" +
                                type + "', '" + balance + "')";

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

            cmd = "Update Accounts set Cid = '" + cID +
                         "', Type = '" + type + "', Balance = '" + balance +
                         "' where AcctNo = '" + acctNo + "'";

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

            cmd = "Delete from Accounts where AcctNo = '" + acctNo + "'";
            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Deleted");
                else
                    Console.WriteLine("ERROR: Deleting Data");
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
