using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsDepositScreen : clsScreen
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

        public static void ShowDepositeScreen()
        {

            _DrawScreenHeader("\t     Deposit Screen");

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

            Console.Write("\nPlease enter Deposit Amount? ");
            double depositAmount = clsInputValidate.ReadPositiveDblNumber();

            Console.Write("\nAre you sure you want to perform this transaction (Y/N)? ");
            char confirm = char.Parse(Console.ReadLine());

            if (confirm == 'y' || confirm == 'Y')
            {

                client1.Deposit(depositAmount);
                Console.WriteLine("\nAmount Deposited Successfully.");
                Console.WriteLine("\nNew Balance is: " + client1.AccountBalance);

            }
            else
            {
                Console.WriteLine("\nOperation was cancelled.");
            }

        }

    }
}
