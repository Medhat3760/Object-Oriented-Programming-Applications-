using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsUpdateClientScreen : clsScreen
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

        public static void ShowUpdateClientScreen()
        {

            if (!_CheckAccessRights(clsUser.enPermissions.pShowClientList))
            {
                return; // this will exit the function and it will not continue
            }

            _DrawScreenHeader("\t  Update Client Screen");

            Console.Write("\nPlease enter Account Number? ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("Account Number not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client = clsBankClient.Find(accountNumber);

            _PrintClient(client);

            Console.Write("\nAre you sure you want to update this client (Y/N)? ");
            char answer = char.Parse(Console.ReadLine());

            if (answer == 'Y' || answer == 'y')
            {

                Console.WriteLine("\nUpdate Client Info:");
                Console.WriteLine("_________________________");

                _ReadClientInfo(ref client);

                clsBankClient.enSaveResult saveResult;

                saveResult = client.Save();

                switch (saveResult)
                {

                    case clsBankClient.enSaveResult.svSucceded:
                        Console.WriteLine("\nClient Updated Successfully :-)");
                        _PrintClient(client);
                        break;

                    case clsBankClient.enSaveResult.svFailedEmptyObject:
                        Console.WriteLine("\nError account was not saved because it's Empty");
                        break;

                }

            }


        }

    }
}
