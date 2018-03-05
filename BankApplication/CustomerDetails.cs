using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    class CustomerDetails
    {
        public static void PrintDetails(string customerId, string accountNum)
        {
            foreach (var account in Bank.LAccounts)
            {
                if (account.MyCustomer.Id == customerId.Trim() && account.AccountNumber == accountNum.Trim())
                {
                    Console.Write("If you want to print only details of the account you entered press 1,\n" +
                                  "If you want to print all your accounts details press 2: ");
                    string result = Console.ReadLine();
                    Console.WriteLine();

                    switch (result)
                    {
                        case "1":
                            Console.WriteLine(account.MyCustomer.ToString());
                            Console.WriteLine(account.ToString());
                            break;
                        case "2":
                            Console.WriteLine(account.MyCustomer.ToString());
                            foreach (var accountNumber in account.MyCustomer.MyAccounts)
                            {
                                Console.WriteLine(accountNumber.ToString());
                            }
                            break;
                        default:
                            Console.WriteLine("OPERATION INVALID.");
                            break;
                    }
                    return;
                }
            }
            Console.WriteLine("The details you entered are incorrect!\n" +
                              "Try another ID or another Account number.");
        }

        public static void PrintAllCustomers(string employeeId) // Method for employees only
        {
            if (employeeId == "1")
            {
                if (Bank.LCustomers.Count == 0) // If the bank does not have customers yet
                    Console.WriteLine("The bank does not have customers yet!");
                else
                {
                    for (int i = 0; i < Bank.LCustomers.Count; i++)
                    {
                        Console.WriteLine($"CUSTOMER NUMBER {i + 1}:\n" +
                                          "-----------------");
                        Console.WriteLine(Bank.LCustomers[i].ToString());
                        foreach (var account in Bank.LCustomers[i].MyAccounts)
                            Console.WriteLine(account.ToString());
                    }
                }
            }
            else
                Console.WriteLine("You don't have access to this type of information!");
        }
    }
}
