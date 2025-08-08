using MyLib;
namespace Bank_System
{
    internal class Program
    {

        static void DeleteClient()
        {

            Console.Write("\nPlease enter Account Number: ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client1 = clsBankClient.Find(accountNumber);
            client1.Print();

            Console.Write("\nAre you sure you want to delete this client? (Y/N)? ");
            char confirm = char.Parse(Console.ReadLine());

            if (confirm == 'Y' || confirm == 'y')
            {

                if (client1.Delete())
                {

                    Console.WriteLine("\nClient Deleted Successfully :-)");
                    client1.Print();

                }
                else
                {
                    Console.WriteLine("\nError Client Was Not Deleted");
                }

            }

        }

        static void Main(string[] args)
        {

            DeleteClient();

            Console.ReadKey();

        }
    }
}