using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsFindClientScreen : clsScreen
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

        public static void ShowFindClientScreen()
        {

            _DrawScreenHeader("\t   Find Client Screen");

            Console.Write("\nPlease enter Account Number? ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client1 = clsBankClient.Find(accountNumber);


            if (!client1.IsEmpty())
            {
                Console.WriteLine("\nClient is Found :-)");
            }
            else
            {
                Console.WriteLine("\nClient is Not Found :-(");
            }

            _PrintClient(client1);


        }

    }
}
