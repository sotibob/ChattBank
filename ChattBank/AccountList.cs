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
    public class AccountList //AccountList class for holding multiple Account objects
    {
        //Initializing the account properties
        public int count = 0;
        public Account[] acc = new Account[100];

        public AccountList() //Default Constructor
        {
            acc[count] = new Account();
            count = 0;
        }

        public void addAccount(Account a) //Add account method used to add an account object to the array
        {
            acc[count] = a;
            count++;
        }

        public void Display() //Display methhod
        {
            for (int i = 0; i < count; i++) //Looping through the account objects in the array and displaying them
            {
                acc[i].Display();
            }
        }
    }
}
