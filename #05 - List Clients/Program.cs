using MyLib;
namespace Bank_System
{
    internal class Program
    {

        static void PrintClientRecordLine(clsBankClient client)
        {

            Console.Write($"| {client.AccountNumber.PadRight(15)}");
            Console.Write($"| {client.getFullName.PadRight(20)}");
            Console.Write($"| {client.Phone.PadRight(12)}");
            Console.Write($"| {client.Email.PadRight(25)}");
            Console.Write($"| {client.PinCode.PadRight(9)}");
            Console.Write($"| {client.AccountBalance.ToString().PadRight(14)}");

        }

        static void ShowClientsList()
        {

            List<clsBankClient> lClients = clsBankClient.GetClientsList();

            Console.WriteLine($"\n{clsUtil.Tabs(5)}Client List ({lClients.Count}) Client(s).");

            Console.WriteLine("___________________________________________________________________________________________________________\n");

            Console.Write($"| {"Account Number".PadRight(15)}");
            Console.Write($"| {"Client Name".PadRight(20)}");
            Console.Write($"| {"Phone".PadRight(12)}");
            Console.Write($"| {"Email".PadRight(25)}");
            Console.Write($"| {"Pin Code".PadRight(9)}");
            Console.WriteLine($"| {"Balance".PadRight(14)}");

            Console.WriteLine("___________________________________________________________________________________________________________\n");


            if (lClients.Count == 0)
            {
                Console.WriteLine(clsUtil.Tabs(3) + "No Clients Available in The System!");
            }
            else
            {

                foreach (clsBankClient client in lClients)
                {

                    PrintClientRecordLine(client);
                    Console.WriteLine();

                }

            }

            Console.WriteLine("___________________________________________________________________________________________________________\n");

        }

        static void Main(string[] args)
        {

            ShowClientsList();

            Console.ReadKey();

        }
    }
}