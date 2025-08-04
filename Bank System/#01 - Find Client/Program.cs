using MyLib;
namespace Bank_System
{
    internal class Program
    {

        static void Main(string[] args)
        {

            clsBankClient client1 = clsBankClient.Find("A101");
            if (!client1.IsEmpty())
            {
                Console.WriteLine("\nClient Found :-)");
            }
            else
            {
                Console.WriteLine("\nClient was Not Found :-("); ;
            }

            client1.Print();

            clsBankClient client2 = clsBankClient.Find("A101", "1234");
            if (!client2.IsEmpty())
            {
                Console.WriteLine("\nClient Found :-)");
            }
            else
            {
                Console.WriteLine("\nClient was Not Found :-("); ;
            }

            client2.Print();

            Console.WriteLine("\nIs Client Exist? " + clsBankClient.IsClientExist("A101"));

            Console.ReadKey();

        }
    }
}