using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class clsClientListScreen : clsScreen
    {

        private static void _PrintClientRecordLine(clsBankClient client)
        {

            Console.Write("".PadLeft(10) + "| " + client.AccountNumber.PadRight(15));
            Console.Write("| " + client.getFullName.PadRight(25));
            Console.Write("| " + client.Phone.PadRight(12));
            Console.Write("| " + client.Email.PadRight(20));
            Console.Write("| " + client.PinCode.PadRight(9));
            Console.Write("| " + client.AccountBalance.ToString().PadRight(15));

        }

        public static void ShowClientsList()
        {

            if (!_CheckAccessRights(clsUser.enPermissions.pShowClientList))
            {
                return; // this will exit the function and it will not continue
            }

            List<clsBankClient> lClients = clsBankClient.GetClientsList();

            string title = "\t   Client List Screen";
            string subTitle = $"\t     ({lClients.Count}) Client(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");

            Console.Write("".PadLeft(10) + "| " + "Account Number".PadRight(15));
            Console.Write("| " + "Client Name".PadRight(25));
            Console.Write("| " + "Phone".PadRight(12));
            Console.Write("| " + "Email".PadRight(20));
            Console.Write("| " + "Pin Code".PadRight(9));
            Console.Write("| " + "Balance".PadRight(14));

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");

            if (lClients.Count == 0)
            {
                Console.WriteLine("\n\t\t\t\tNo Clients Available in the System!");
            }
            else
            {

                foreach (clsBankClient client in lClients)
                {

                    _PrintClientRecordLine(client);
                    Console.WriteLine();
                }

            }

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");

        }

    }
}
