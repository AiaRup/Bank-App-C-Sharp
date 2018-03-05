/*
Programmers Name: Boris Fleer and Aia Rupsom
Bank Application
(Password for option 6 is 1)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args) 
        {
            string operation = "";
            do 
            {
                Console.Write("HELLO, What Would You Like To Do Today: \n" +
                              "\n1. Register to be a new customer of the bank and open a new account - SELECT 1\n" +
                              "2. Make a Withdrawal - SELECT 2\n" +
                              "3. Make a Deposit - SELECT 3\n" +
                              "4. Print your customer and account/s details - SELECT 4\n" +
                              "5. Create a new account (for registered customers)- SELECT 5\n" +
                              "6. FOR EMPLOYEES ONLY: Print All Customers and their accounts Details - PRESS 6\n" +
                              "YOUR ANSWER:  ");

                string choice = Console.ReadLine();
                string idNumber = " ";
                string accountNum = " ";
                string amount = " ";

                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Please Enter Your ID number (9 Digits): ");
                            idNumber = Console.ReadLine();
                            Bank.AddNewCustomer(idNumber);
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Please enter your ID Number: ");
                            idNumber = Console.ReadLine();
                            Console.Write("Please enter your Account Number: ");
                            accountNum = Console.ReadLine();
                            Console.Write("Please enter the Amount you would like to withdraw: ");
                            amount = (Console.ReadLine());
                            Bank.Withdraw(accountNum, idNumber, amount);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Please enter your ID Number: ");
                            idNumber = Console.ReadLine();
                            Console.Write("Please enter your Account Number: ");
                            accountNum = Console.ReadLine();
                            Console.Write("Please enter the Amount you would like to deposit: ");
                            amount = (Console.ReadLine());
                            Bank.Deposit(accountNum, idNumber, amount);
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Please enter your ID Number: ");
                            idNumber = Console.ReadLine();
                            Console.Write("Please enter your Account Number: ");
                            accountNum = Console.ReadLine();
                            Console.WriteLine();
                            CustomerDetails.PrintDetails(idNumber, accountNum);
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Please enter your ID Number: ");
                            idNumber = Console.ReadLine();
                            Bank.CreateNewAccount(idNumber);
                            break;
                        }
                    case "6":
                        {
                            Console.Write("Enter your Password: ");
                            idNumber = Console.ReadLine();
                            Console.WriteLine();
                            CustomerDetails.PrintAllCustomers(idNumber);
                            break;
                        }
                    default:
                        Console.WriteLine("OPERATION INVALID. Please select a valid operation from the main menu.");
                        break;
                }

                Console.WriteLine();
                Console.Write("If You want to do another operation press ENTER: ");
                operation = Console.ReadLine();
                Console.Clear();

            } while (String.IsNullOrWhiteSpace(operation));

            Console.WriteLine("Bye Bye, Thank you for using our Bank Application!");
        }
    }
}
