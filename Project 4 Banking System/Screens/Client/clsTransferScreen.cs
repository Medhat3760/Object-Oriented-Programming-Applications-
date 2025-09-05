using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using static Bank_System.Globals;
using Bank_System.Core;

namespace Bank_System.Screens.Client
{
    public class clsTransferScreen : clsScreen
    {

        private static string _ReadAccountNumber(string message)
        {

            Console.Write(message);
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            return accountNumber;
        }

        private static void _PrintClient(clsBankClient client)
        {

            Console.WriteLine("\nClient Card:");
            Console.WriteLine("_________________________\n");

            Console.WriteLine("Full Name   : " + client.getFullName);
            Console.WriteLine("Acc. Number : " + client.AccountNumber);
            Console.WriteLine("Balance     : " + client.AccountBalance.ToString());

            Console.WriteLine("_________________________\n");

        }

        private static double _ReadAmount(clsBankClient sourceClient)
        {
            return clsInputValidate.ReadDblNumberBetween(1, sourceClient.AccountBalance, "Amount exceeds the available balance, Enter another Amount? ");
        }

        public static void ShowTrasferScreen()
        {

            _DrawScreenHeader("\t      Transfer Screen");

            clsBankClient sourceClient = clsBankClient.Find(_ReadAccountNumber("\nPlease enter The Account Number to transfer From? "));

            _PrintClient(sourceClient);

            clsBankClient destinationClient = clsBankClient.Find(_ReadAccountNumber("\nPlease enter The Account Number to transfer To? "));

            _PrintClient(destinationClient);

            Console.Write("\nEnter Transfer Amount? ");
            double amount = _ReadAmount(sourceClient);

            if (clsInputValidate.ReadYesOrNo("\nAre you sure you want to perform this operation? (Y/N)? "))
            {

                if (sourceClient.Transfer(amount, ref destinationClient, currentUser.UserName))
                {
                    Console.WriteLine("\nTransfer Done Successfully.");
                }
                else
                {
                    Console.WriteLine("\nTransfer Failed.");
                }

                _PrintClient(sourceClient);

                _PrintClient(destinationClient);

            }

        }

    }
}
