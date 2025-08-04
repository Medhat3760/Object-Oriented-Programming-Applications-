using MyLib;
namespace Bank_System
{
    internal class Program
    {

        static void ReadClientInfo(ref clsBankClient client)
        {

            Console.Write("\nEnter FirstName: ");
            client.FirstName = clsInputValidate.ReadString();

            Console.Write("\nEnter LastName: ");
            client.LastName = clsInputValidate.ReadString();

            Console.Write("\nEnter Email: ");
            client.Email = clsInputValidate.ReadString();

            Console.Write("\nEnter Phone: ");
            client.Phone = clsInputValidate.ReadString();

            Console.Write("\nEnter PinCode: ");
            client.PinCode = clsInputValidate.ReadString();

            Console.Write("\nEnter Account Balance: ");
            client.AccountBalance = clsInputValidate.ReadFloatNumber();

        }

        static void UpdateClient()
        {

            Console.Write("\nPlease enter client Account Number: ");
            string accountNumber = clsInputValidate.ReadString();

            while (!clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient client1 = clsBankClient.Find(accountNumber);
            client1.Print();

            Console.WriteLine("\nUpdate Client Info:");
            Console.WriteLine("________________________");

            ReadClientInfo(ref client1);

            clsBankClient.enSaveResult saveResult;
            saveResult = client1.Save();

            switch (saveResult)
            {

                case clsBankClient.enSaveResult.svSucceded:
                    Console.WriteLine("\nClient Updated Successfully :-)");
                    client1.Print();
                    break;

                case clsBankClient.enSaveResult.svFailedEmptyObject:
                    Console.WriteLine("\nError account was not saved because it's Empty");
                    break;

            }

        }

        static void Main(string[] args)
        {

            UpdateClient();

            Console.ReadKey();

        }
    }
}