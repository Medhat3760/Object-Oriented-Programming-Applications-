using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsCurrency
    {

        private enum enMode { EmptyMode = 1, UpdateMode = 2 };

        private enMode _mode;
        private string _country;
        private string _currencyCode;
        private string _currencyName;
        private double _Rate;

        private static clsCurrency _ConvertLineToCurrencyObject(string line, string separator = "#//#")
        {

            List<string> lCurrencyData = clsString.Split(line, separator);

            return new clsCurrency(lCurrencyData[0], lCurrencyData[1], lCurrencyData[2], double.Parse(lCurrencyData[3]));

        }

        private static List<clsCurrency> _LoadCurrenciesDataFromFile()
        {

            List<clsCurrency> lCurrencies = new List<clsCurrency>();    

            if (File.Exists("Currencies.txt"))
            {

                using(StreamReader myFile = new StreamReader("Currencies.txt"))
                {

                    string line;

                    while ((line = myFile.ReadLine())!= null)
                    {

                        clsCurrency currency = _ConvertLineToCurrencyObject(line);

                        lCurrencies.Add(currency);

                    }

                }

            }

            return lCurrencies;

        }

        private static string _ConvertCurrencyObjectToLine(clsCurrency currency, string separator = "#//#")
        {

            string line = currency.Country + separator
                + currency.CurrencyCode + separator
                + currency.CurrencyName + separator
                + currency.Rate.ToString();

            return line;

        }

        private static void _SaveCurrenciesToFile(List<clsCurrency> lCurrencies)
        {


            if (File.Exists("Currencies.txt"))
            {

                using (StreamWriter myFile = new StreamWriter("Currencies.txt"))
                {

                    foreach(clsCurrency currency in lCurrencies)
                    {

                        myFile.WriteLine(_ConvertCurrencyObjectToLine(currency));    

                    }

                }

            }


        }

        private void _Update()
        {

            List<clsCurrency> lCurrencies = _LoadCurrenciesDataFromFile();
           
            for(int i =0; i< lCurrencies.Count; i++)
            {
           
                if (lCurrencies[i].CurrencyCode == CurrencyCode)
                {
           
                    lCurrencies[i] = this;
                    break;
           
                }
           
            }
           
            _SaveCurrenciesToFile(lCurrencies);

        }

        private static clsCurrency _GetEmptyCurrencyObject()
        {

            return new clsCurrency(enMode.EmptyMode, "", "", "", 0);

        }

        private clsCurrency(enMode mode, string country, string currencyCode, string currencyName, double rate)
        {

            _mode = mode;
            _country = country;
            _currencyCode = currencyCode;
            _currencyName = currencyName;
            _Rate = rate;

        }

        public clsCurrency(string country, string currencyCode, string currencyName, double rate)
            : this(enMode.UpdateMode, country, currencyCode, currencyName, rate) { }

        public bool IsEmpty()
        {
            return _mode == enMode.EmptyMode;
        }

        public string Country
        {
            get { return _country; }
        }

        public string CurrencyCode
        {
            get { return _currencyCode; }
        }

        public string CurrencyName
        {
            get { return _currencyName; }
        }

        public bool UpdateRate(double newRate)
        {

            _Rate = newRate;

            _Update();

            return true;

        }

        public double Rate
        {
            get { return _Rate; }           
        }

        public static clsCurrency FindByCode(string currencyCode)
        {

            currencyCode = clsString.UpperAllString(currencyCode);

            if(File.Exists("Currencies.txt"))
            {

                using(StreamReader myFile = new StreamReader("Currencies.txt"))
                {

                    string line;

                    while((line =myFile.ReadLine()) != null)
                    {

                        clsCurrency currency = _ConvertLineToCurrencyObject(line);

                        if(currency.CurrencyCode == currencyCode)
                        {

                            return currency;

                        }

                    }

                }

            }

            return _GetEmptyCurrencyObject();

        }
        
        public static clsCurrency FindByCountry(string country)
        {

            country = clsString.UpperAllString(country);

            if(File.Exists("Currencies.txt"))
            {

                using(StreamReader myFile = new StreamReader("Currencies.txt"))
                {

                    string line;

                    while((line =myFile.ReadLine()) != null)
                    {

                        clsCurrency currency = _ConvertLineToCurrencyObject(line);

                        if(clsString.UpperAllString(currency.Country) == country)
                        {

                            return currency;

                        }

                    }

                }

            }

            return _GetEmptyCurrencyObject();

        }

        public static bool IsCurrencyExist(string currencyCode)
        {

            return !FindByCode(currencyCode).IsEmpty();

        }

        public static List<clsCurrency> GetCurrenciesList()
        {

            return _LoadCurrenciesDataFromFile();

        }

    }
}
