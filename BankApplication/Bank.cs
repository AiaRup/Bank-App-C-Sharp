using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    public static class Bank 
    { 
        internal static List<Customer> LCustomers = new List<Customer>();
        internal static List<Account> LAccounts = new List<Account>();

        /******************************************************************************************************/
        /**************************************Add New Customer************************************************/

        public static void AddNewCustomer(string customerId)
        {
            if (!CustomerExistenceCheck(customerId)) // Check for exsisting customer in the bank
            {
                Customer newCustomer = new Customer { Id = customerId };
                Console.Write("Please Enter Your First Name: ");
                newCustomer.FirstName = Console.ReadLine();
                Console.Write("Please Enter Your Last Name: ");
                newCustomer.LastName = Console.ReadLine();
                Console.Write("Please Enter Your Address: ");
                newCustomer.Address = Console.ReadLine();
                Console.Write("Please Enter Your Phone Number: ");
                newCustomer.PhoneNumber = Console.ReadLine();
                newCustomer.MyAccounts = new List<Account>();

                LCustomers.Add(newCustomer); 
                Console.WriteLine($"\nWelcome {newCustomer.FirstName} {newCustomer.LastName} To The A&B Bank!");

                CreateNewAccount(newCustomer.Id); // Create account for the new customer
            }
        }

        /******************************************************************************************************/
        /**************************************Customer Existence Check****************************************/

        private static bool CustomerExistenceCheck(string customerId)
        {
            foreach (var customer in LCustomers)
            {
                if (customer.Id != customerId.Trim()) continue;
                Console.WriteLine("\nYou are already our customer!\n");
                Console.WriteLine(customer.ToString());
                return true;
            }
            return false;
        }

        /******************************************************************************************************/
        /**************************************Account Customer Check******************************************/

        private static bool AccountCustomerCheck(string customerId, string checkAccount)
        {
            foreach (var customer in LCustomers)
            {
                if (customer.Id != customerId.Trim()) continue;
                if (customer.MyAccounts == null) return false;
                foreach (var account in customer.MyAccounts)
                {
                    if (account.AccountNumber == checkAccount)
                        return true;
                }
            }
            return false;
        }

        /******************************************************************************************************/
        /**************************************Create New Account**********************************************/

        public static void CreateNewAccount(string id)
        {
            if (LCustomers.Count == 0) // If the bank does not have customers yet
            {
                Console.WriteLine("\nYou need to register to be our customer first!\n" +
                                  "Choose option 1 in the Main Menu.");
                return;
            }

            foreach (var customer in LCustomers)
            {
                if (customer.Id == id.Trim())
                {
                    string accountNum = "";
                    Random rnd = new Random();

                    accountNum = Convert.ToString(rnd.Next(10000, 100000)); // Generate 5 digit account number
                    if (!AccountCustomerCheck(id, accountNum))
                    {
                        customer.MyAccounts.Add(new Account(accountNum));
                        LAccounts.Add(customer.MyAccounts.Last());
                        customer.MyAccounts.Last().MyCustomer = customer;
                    }
                    else
                    {
                        Console.WriteLine("The customer already has an account with the same number!");
                    }
                    
                    Console.WriteLine("Congratulations! Your account was created at {0:g}", DateTime.Now);
                    Console.WriteLine("\n" + LAccounts.Last());

                    Console.Write("Press 1 if you like to deposit any money: "); // Ask to deposit money
                    string answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        Console.Write("Please enter the Amount you would like to deposit: ");
                        Deposit(LAccounts.Last().AccountNumber, LAccounts.Last().MyCustomer.Id, Console.ReadLine());
                    }
                    return;
                }
            }
            Console.WriteLine("\nThe Id you entered is incorrect. We cannot open a new account for you.");
        }

        /******************************************************************************************************/
        /***************************************** Withdraw ***************************************************/

        public static void Withdraw(string accountNum, string idNum, string amount)
        {
            double amountValid = InputValidNumbers(amount); // Check that the input is a double number
            if (LAccounts.Count == 0) // If the bank does not have customers yet
            {
                Console.WriteLine("\nYou need to register to be our customer first!\n" +
                                  "Choose option 1 in the Main Menu.");
                return;
            }
            if (amountValid == 0) // If the customer wants to withdraw 0
            {
                Console.WriteLine("\nThe amount you entered is zero. Withdrawal cancelled...");
                return;
            }
            
            foreach (var account in LAccounts)
            {
                if (account.MyCustomer.Id == idNum.Trim() && account.AccountNumber == accountNum.Trim())
                {
                    amountValid = Math.Abs(amountValid); // If the input is a negative number make it positive
                    if (amountValid <= (account.AccountBalance + account.Credit)) 
                    {
                        account.AccountBalance -= amountValid; 
                        Console.WriteLine("The withdrawal was successful! Time of withdrawal: {0:g}\n" +
                                          "You withdraw: {1:c}\n" +
                                          "Your current balance is: ${2}", DateTime.Now,
                                          amountValid, account.AccountBalance);
                        return;

                    }
                    Console.WriteLine("You don't have enough balance for the withdrawal.");
                    return;
                }
            }
            Console.WriteLine("\nThe details are incorrect. Withdrawal cancelled..");
        }

        /******************************************************************************************************/
        /***************************************** Deposit ****************************************************/

        public static void Deposit(string accountNum, string idNum, string amount)
        {
            double amountValid = InputValidNumbers(amount);
            if (LCustomers.Count == 0) // If the bank does not have customers yet
            {
                Console.WriteLine("\nYou need to register to be our customer first!\n" +
                                  "Choose option 1 in the Main Menu.");
                return;
            }

            if (amountValid == 0) // If the customer wants to deposite 0
            {
                Console.WriteLine("\nThe amount you entered is zero. Deposit Cancelled..");
                return;
            }

            foreach (var account in LAccounts)
            {
                if (account.MyCustomer.Id == idNum.Trim() && account.AccountNumber == accountNum.Trim())
                {
                    account.AccountBalance += Math.Abs(amountValid); // If the input is a negative number make it positive
                    Console.WriteLine("\nThe deposit was successful.\n" +
                                      "Time of Deposit: {0:g}\n" +
                                      "Your current balance is: ${1}", DateTime.Now, account.AccountBalance);
                    return;
                }
            }
            Console.WriteLine("\nThe details are incorrect. Deposit Cancelled..");
        }

        /******************************************************************************************************/
        /***************************************** Input Check ************************************************/

        private static double InputValidNumbers(string digitNumber)
        {
            double i;
            while (!(double.TryParse(digitNumber, out i)))
            {
                Console.Write("Enter a valid Amount: ");
                digitNumber = Console.ReadLine();
            }
            return i;
        }
    }
}
