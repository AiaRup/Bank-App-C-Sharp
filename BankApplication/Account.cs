using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    class Account
    {
        public Customer MyCustomer { get; set; }

        public string AccountNumber { get; set; }

        public double AccountBalance { get; set; }

        public int Credit { get; set; }

        public Account() { }

        public Account(string account)
        {
            AccountNumber = account;
            AccountBalance = 0;
            Credit = 1000; 
        }

        public override string ToString()
        {
            return "Account details:\n" +
                   new string('\u2550', 18) + "\n" +
                   $"Customer name    :{MyCustomer.FirstName} {MyCustomer.LastName}\n" +
                   $"Account number   :{AccountNumber}\n" +
                   $"Balance          :{AccountBalance}$\n" +
                   $"Credit           :{Credit}$\n";
        }
    }
}
