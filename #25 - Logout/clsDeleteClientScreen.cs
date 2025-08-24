using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
namespace Bank_System
{
    public class clsDeleteClientScreen : clsScreen
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

        public static void ShowDeleteClientScreen()
        {

            _DrawScreenHeader("\t Delete Client Screen");

            Console.Write("\nPlease enter Account Number: ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client = clsBankClient.Find(accountNumber);
            _PrintClient(client);

            Console.Write("\nAre you sure you want to delete this client (Y/N)? ");
            char answer = char.Parse(Console.ReadLine());

            if (answer == 'Y' || answer == 'y')
            {

                if (client.Delete())
                {

                    Console.WriteLine("\nClient Deleted Successfully :-)");
                    _PrintClient(client);

                }
                else
                {
                    Console.WriteLine("\nError Client Was Not Deleted.");
                }

            }

        }

    }
}
