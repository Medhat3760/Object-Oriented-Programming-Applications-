using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyLib;
using static Bank_System.clsBankClient;
namespace Bank_System
{

    public class clsBankClient : clsPerson
    {

        public enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 }

        private enMode _mode;
        private string _accountNumber;
        private string _pinCode;
        private float _accountBalance;
        private bool _markForDelete = false;

        private static clsBankClient _ConvertLineToClientObject(string line, string separator = "#//#")
        {

            List<string> clientData = clsString.Split(line, separator);

            return new clsBankClient(enMode.UpdateMode, clientData[0], clientData[1], clientData[2], clientData[3], clientData[4],
                clientData[5], float.Parse(clientData[6]));

        }

        private static clsBankClient _GetEmptyClientObject()
        {

            return new clsBankClient(enMode.EmptyMode, "", "", "", "", "", "", 0);

        }

        private static List<clsBankClient> _LoadClientsDataFromFile()
        {

            List<clsBankClient> lClients = new List<clsBankClient>();

            if (File.Exists("Clients.txt"))
            {

                using (StreamReader myFile = new StreamReader("Clients.txt"))
                {

                    string dataLine = "";

                    while ((dataLine = myFile.ReadLine()) != null)
                    {

                        clsBankClient c = _ConvertLineToClientObject(dataLine);
                        lClients.Add(c);

                    }

                }

            }

            return lClients;

        }

        private static string _ConvertClientObjectToLine(clsBankClient client, string separator = "#//#")
        {

            string clientRecord = client.FirstName + separator
                + client.LastName + separator
                + client.Email + separator
                + client.Phone + separator
                + client.AccountNumber + separator
                + client.PinCode + separator
                + client.AccountBalance.ToString();

            return clientRecord;

        }

        private static void _SaveClientsDataToFile(List<clsBankClient> lClients)
        {

            if (File.Exists("Clients.txt"))
            {

                using (StreamWriter myFile = new StreamWriter("Clients.txt"))
                {

                    string dataLine = "";

                    foreach (clsBankClient c in lClients)
                    {
                        if (!c._markForDelete)
                        {

                            dataLine = _ConvertClientObjectToLine(c);

                            myFile.WriteLine(dataLine);

                        }
                    }

                }

            }

        }

        private void _Update()
        {

            List<clsBankClient> lClients = _LoadClientsDataFromFile();

            for (int i = 0; i < lClients.Count; i++)
            {

                if (lClients[i].AccountNumber == AccountNumber)
                {

                    lClients[i] = this;
                    break;

                }

            }

            _SaveClientsDataToFile(lClients);

        }

        private void _AddDataLineToFile(string line)
        {

            if (File.Exists("Clients.txt"))
            {

                using (StreamWriter myFile = new StreamWriter("Clients.txt", append: true))
                {

                    myFile.WriteLine(line);

                }

            }

        }

        private void _AddNew()
        {

            _AddDataLineToFile(_ConvertClientObjectToLine(this));

        }

        private void _Clear()
        {

            // نفرغ خصائص clsPerson 
            FirstName = LastName = Email = Phone = "";

            // نفرغ خصائص clsBankClient
            _mode = enMode.EmptyMode;
            _accountNumber = string.Empty;
            PinCode = string.Empty;
            _accountBalance = 0;
            _markForDelete = false;

        }

        public clsBankClient(enMode mode, string firstName, string lastName, string email, string phone, string accountNumber,
            string pinCode, float accountBalance) : base(firstName, lastName, email, phone)
        {
            _mode = mode;
            _accountNumber = accountNumber;
            _pinCode = pinCode;
            _accountBalance = accountBalance;
        }

        public bool IsEmpty()
        {
            return _mode == enMode.EmptyMode;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
        }

        public string PinCode
        {
            get { return _pinCode; }
            set { _pinCode = value; }
        }

        public float AccountBalance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }

        /*         
        No UI Related code iside object.
         
        public void Print()
        {

            Console.WriteLine("\nClient Card:");
            Console.WriteLine("________________________________");
            Console.WriteLine($"First Name  : {FirstName}");
            Console.WriteLine($"Last Name   : {LastName}");
            Console.WriteLine($"Full Name   : {getFullName}");
            Console.WriteLine($"Email       : {Email}");
            Console.WriteLine($"Phone       : {Phone}");
            Console.WriteLine($"Acc. Number : {_accountNumber}");
            Console.WriteLine($"Password    : {_pinCode}");
            Console.WriteLine($"Balance     : {_accountBalance}");
            Console.WriteLine("________________________________");

        }
        */

        public static clsBankClient Find(string accountNumber)
        {

            if (File.Exists("Clients.txt"))
            {

                using (StreamReader myFile = new StreamReader("Clients.txt"))
                {

                    string line = "";

                    while ((line = myFile.ReadLine()) != null)
                    {

                        clsBankClient client = _ConvertLineToClientObject(line);

                        if (client.AccountNumber == accountNumber)
                        {

                            return client;

                        }

                    }

                }

            }

            return _GetEmptyClientObject();

        }

        public static clsBankClient Find(string accountNumber, string pinCode)
        {

            if (File.Exists("Clients.txt"))
            {

                using (StreamReader myFile = new StreamReader("Clients.txt"))
                {

                    string line = "";

                    while ((line = myFile.ReadLine()) != null)
                    {

                        clsBankClient client = _ConvertLineToClientObject(line);

                        if (client.AccountNumber == accountNumber && client.PinCode == pinCode)
                        {

                            return client;

                        }

                    }

                }

            }

            return _GetEmptyClientObject();

        }

        public static bool IsClientExist(string accountNumber)
        {
            return !Find(accountNumber).IsEmpty();
        }

        public static clsBankClient GetAddNewClientObject(string accountNumber)
        {

            return new clsBankClient(enMode.AddNewMode, "", "", "", "", accountNumber, "", 0);

        }

        public static List<clsBankClient> GetClientsList()
        {

            return _LoadClientsDataFromFile();

        }

        public static double GetTotalBalances()
        {

            double totalBalances = 0;

            List<clsBankClient> lClients = GetClientsList();

            foreach (clsBankClient client in lClients)
            {
                totalBalances += client.AccountBalance;
            }

            return totalBalances;

        }

        public enum enSaveResult { svFailedEmptyObject = 0, svSucceded = 1, svFailedAccountNumberExists = 2 }

        public enSaveResult Save()
        {

            switch (_mode)
            {

                case enMode.EmptyMode:
                    return enSaveResult.svFailedEmptyObject;

                case enMode.UpdateMode:
                    _Update();
                    return enSaveResult.svSucceded;

                case enMode.AddNewMode:
                    if (IsClientExist(AccountNumber))
                    {
                        return enSaveResult.svFailedAccountNumberExists;
                    }
                    else
                    {
                        _AddNew();
                        //We need to set the mode to update after add new
                        _mode = enMode.UpdateMode;
                        return enSaveResult.svSucceded;
                    }

                default:
                    return enSaveResult.svFailedEmptyObject;

            }

        }

        public bool Delete()
        {

            List<clsBankClient> lClients = _LoadClientsDataFromFile();

            for (int i = 0; i < lClients.Count; i++)
            {

                if (lClients[i].AccountNumber == AccountNumber)
                {
                    lClients[i]._markForDelete = true;
                    break;
                }

            }

            _SaveClientsDataToFile(lClients);

            _Clear();

            return true;

        }




    }
}
