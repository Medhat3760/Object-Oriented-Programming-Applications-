using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsWithdrawScreen : clsScreen
    {

        private static void _PrintClient(clsBankClient client)
        {

            Console.WriteLine("\nClient Card:");
            Console.WriteLine("________________________________");
            Console.WriteLine($"First Name  : {client.FirstName}");
            Console.WriteLine($"Last Name   : {client.LastName}");
            Console.WriteLine($"Full Name   : {client.getFullName}");
            Console.WriteLine($"Email       : {client.Email}");
            Console.WriteLine($"Phone       : {client.Phone}");
            Console.WriteLine($"Acc. Number : {client.AccountNumber}");
            Console.WriteLine($"Password    : {client.PinCode}");
            Console.WriteLine($"Balance     : {client.AccountBalance}");
            Console.WriteLine("________________________________");

        }

        public static void ShowWithdrawScreen()
        {

            _DrawScreenHeader("\t     Withdraw Screen");

            Console.Write("\nPlease enter Account Number? ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.WriteLine($"\nClient with account number [{accountNumber}] does not exist.");

                Console.Write("\nPlease enter Account Number? ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client1 = clsBankClient.Find(accountNumber);
            _PrintClient(client1);

            Console.Write("\nPlease enter Withdraw Amount? ");
            double withdrawAmount = clsInputValidate.ReadPositiveDblNumber();

            Console.Write("\nAre you sure you want to perform this transaction (Y/N)? ");
            char answer = char.Parse(Console.ReadLine());

            if (answer == 'y' || answer == 'Y')
            {

                if (client1.Withdraw(withdrawAmount))
                {

                    Console.WriteLine("\nAmount Withdraw Successfully.");
                    Console.WriteLine("\nNew Balance is: " + client1.AccountBalance);

                }
                else
                {

                    Console.WriteLine("\nCannot Withdraw, Insuffecient Balance!");
                    Console.WriteLine("\nAmout to Withdraw is: " + withdrawAmount);
                    Console.WriteLine("Your Balance is: " + client1.AccountBalance);

                }

            }
            else
            {
                Console.WriteLine("\nOperation was cancelled.");
            }


        }

    }
}
