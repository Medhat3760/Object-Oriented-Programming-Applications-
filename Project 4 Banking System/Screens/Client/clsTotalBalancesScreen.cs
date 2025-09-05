using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using Bank_System.Core;

namespace Bank_System.Screens.Client
{
    public class clsTotalBalancesScreen : clsScreen
    {

        private static void _PrintClientRecordBalanceLine(clsBankClient client)
        {

            Console.Write("".PadLeft(25) + "| " + client.AccountNumber.PadRight(15));
            Console.Write("| " + client.getFullName.PadRight(40));
            Console.Write("| " + client.AccountBalance.ToString().PadRight(15));

        }

        public static void ShowTotalBalancesScreen()
        {

            List<clsBankClient> lClients = clsBankClient.GetClientsList();

            string title = "\t  Balances List Screen";
            string subTitle = $"\t    ({lClients.Count}) Client(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n" + "".PadLeft(10) + new string('_', 100) + "\n");

            Console.Write("".PadLeft(25) + "| " + "Account Number".PadRight(15));
            Console.Write("| " + "Client Name".PadRight(40));
            Console.Write("| " + "Balance".PadRight(15));

            Console.WriteLine("\n" + "".PadLeft(10) + new string('_', 100) + "\n");


            if (lClients.Count == 0)
            {
                Console.WriteLine($"\n\n{clsUtil.Tabs(5)}No Clients Available in the System!");
            }
            else
            {

                foreach (clsBankClient client in lClients)
                {

                    _PrintClientRecordBalanceLine(client);
                    Console.WriteLine();
                }

            }

            Console.WriteLine("\n" + "".PadLeft(10) + new string('_', 100) + "\n");

            double totalBalances = clsBankClient.GetTotalBalances();

            Console.WriteLine($"{clsUtil.Tabs(6)}Total Balances is: {totalBalances}");
            Console.WriteLine($"{clsUtil.Tabs(4)}( {clsUtil.NumberToText((long)totalBalances)})");

        }

    }
}
