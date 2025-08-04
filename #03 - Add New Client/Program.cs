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

        static void AddNewClient()
        {

            Console.Write("\nPlease Enter Account Number: ");
            string accountNumber = clsInputValidate.ReadString();

            while (clsBankClient.IsClientExist(accountNumber))
            {

                Console.Write("\nAccount Number Is Already Used, Choose another one: ");
                accountNumber = clsInputValidate.ReadString();

            }

            clsBankClient newClient = clsBankClient.GetAddNewClientObject(accountNumber);

            ReadClientInfo(ref newClient);

            clsBankClient.enSaveResult saveResult;

            saveResult = newClient.Save();

            switch (saveResult)
            {

                case clsBankClient.enSaveResult.svSucceded:
                    Console.WriteLine("\nAccount Added Successfuly :-) ");
                    newClient.Print();
                    break;

                case clsBankClient.enSaveResult.svFailedEmptyObject:
                    Console.WriteLine("\nError account was not saved because it's Empty");
                    break;

                case clsBankClient.enSaveResult.svFailedAccountNumberExists:
                    Console.WriteLine("\nError account was not saved because account number is used!");
                    break;

            }

        }

        static void Main(string[] args)
        {

            AddNewClient();

            Console.ReadKey();

        }
    }
}