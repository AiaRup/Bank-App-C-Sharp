using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace BankApplication
{
    class Customer
    {
        public List <Account> MyAccounts { get; set; }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = InputNumbers(value, 9); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = InputLetters(value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = InputLetters(value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = InputLetters(value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = InputNumbers(value, 10); }
        }

        public override string ToString()
        {
            return "Customer details:\n" +
                   new string('\u2550', 18) + "\n" +
                   $"Id              : {Id}\n" +
                   $"First Name	: {FirstName}\n" +
                   $"last Name	: {LastName}\n" +
                   $"Address         : {Address}\n" +
                   $"Phone Number    : {PhoneNumber}\n";
        }

        // Methods to check the input from the user
        private static string InputNumbers(string str, int digitNumber)
        {
            long i;
            while (!(long.TryParse(str, out i)) || str.Trim().Length < digitNumber || str.Trim().Length > digitNumber)
            {
                Console.Write($"Enter a valid Input of {digitNumber} digits: ");
                str = Console.ReadLine();
            }
            return str;
        }

        private static string InputLetters(string input)
        {
            string pattern = @"^[a-zA-Z ]+$"; 
            Regex regex = new Regex(pattern);

            while (!regex.IsMatch(input) || String.IsNullOrWhiteSpace(input))
            {
                Console.Write("Enter a valid input of letters and spaces: ");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
