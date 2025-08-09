using MyLib;
namespace Bank_System
{
    internal class Program
    {

        static void PrintClientRecordBalanceLine(clsBankClient client)
        {

            Console.Write($"| {client.AccountNumber.PadRight(15)}");
            Console.Write($"| {client.getFullName.PadRight(40)}");
            Console.Write($"| {client.AccountBalance.ToString().PadRight(16)}");

        }

        static void ShowTotalBalances()
        {

            List<clsBankClient> lClients = clsBankClient.GetClientsList();

            Console.WriteLine($"\n{clsUtil.Tabs(5)}List Balances ({lClients.Count}) Client(s)");

            Console.WriteLine("___________________________________________________________________________________________________________\n");

            Console.Write($"| {"Account Number".PadRight(15)}");
            Console.Write($"| {"Client Name".PadRight(40)}");
            Console.WriteLine($"| {"Balance".PadRight(16)}");

            Console.WriteLine("___________________________________________________________________________________________________________\n");

            double totalBalances = clsBankClient.GetTotalBalances();

            if(lClients.Count == 0)
            {
                Console.WriteLine(clsUtil.Tabs(5)+ "No Clients Available in the System!");
            }
            else
            {

                foreach(clsBankClient client in lClients)
                {

                    PrintClientRecordBalanceLine(client);
                    Console.WriteLine();

                }

            }

            Console.WriteLine("___________________________________________________________________________________________________________\n");

            Console.WriteLine(clsUtil.Tabs(5)+ "Total Balances = "  + totalBalances);
            Console.WriteLine($"{clsUtil.Tabs(5)}( {clsUtil.NumberToText((long)totalBalances)})");
            
        }

        static void Main(string[] args)
        {

            ShowTotalBalances();

            Console.ReadKey();

        }
    }
}