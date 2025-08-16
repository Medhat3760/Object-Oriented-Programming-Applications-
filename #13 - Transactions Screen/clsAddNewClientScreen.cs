using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MyLib;
namespace Bank_System
{
    public class clsAddNewClientScreen : clsScreen
    {

        private static void _ReadClientInfo(ref clsBankClient client)
        {

            Console.Write("\nEnter First Name: ");
            client.FirstName = clsInputValidate.ReadString();

            Console.Write("\nEnter Last Name: ");
            client.LastName = clsInputValidate.ReadString();

            Console.Write("\nEnter Email: ");
            client.Email = clsInputValidate.ReadString();

            Console.Write("\nEnter Phone: ");
            client.Phone = clsInputValidate.ReadString();

            Console.Write("\nEnter Pin Code: ");
            client.PinCode = clsInputValidate.ReadString();

            Console.Write("\nEnter Account Balance: ");
            client.AccountBalance = clsInputValidate.ReadFloatNumber();

        }

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

        public static void ShowAddNewClientScreen()
        {

            _DrawScreenHeader("\tAdd New Client Screen");

            Console.Write("\nPlease enter Account Number: ");
            string accountNumber = clsInputValidate.ReadString();

            while (clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number is already used, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient newClient = clsBankClient.GetAddNewClientObject(accountNumber);

            _ReadClientInfo(ref newClient);

            clsBankClient.enSaveResult saveResult;

            saveResult = newClient.Save();

            switch (saveResult)
            {

                case clsBankClient.enSaveResult.svSucceded:
                    Console.WriteLine("\nAccount Added Successfully :-)");
                    _PrintClient(newClient);
                    break;

                case clsBankClient.enSaveResult.svFailedEmptyObject:
                    Console.WriteLine("\nError account was not saved because it's Empty");
                    break;

                case clsBankClient.enSaveResult.svFailedAccountNumberExists:
                    Console.WriteLine("\nError account was not saved because account number is used!");
                    break;

            }

        }

    }
}
