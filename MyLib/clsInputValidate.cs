using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class clsInputValidate
    {
        public static string ReadString()
        {

            string s1;

            s1 = Console.ReadLine().Trim();

            return s1;

        }

        public static bool IsNumberBetween<T>(T number, T from, T to) where T : IComparable<T>
        {

            return number.CompareTo(from) >= 0 && number.CompareTo(to) <= 0;

        }

        public static bool IsDateBetween(clsDate date, clsDate dateFrom, clsDate dateTo)
        {

            if (!clsDate.IsDate1BeforeDate2(dateFrom, dateTo))
            {
                clsUtil.Swap(ref dateFrom, ref dateTo);
            }

            return !(clsDate.IsDate1BeforeDate2(date, dateFrom) || clsDate.IsDate1AfterDate2(date, dateTo));

        }

        public static short ReadShortNumber(string errorMessage = "Invalid Number, Enter again? ")
        {

            short number;

            while (!short.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static short ReadShortNumberBetween(short from, short to, string errorMessage = "Number is not Within range, Enter again: ")
        {

            short number = ReadShortNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);
                number = ReadShortNumber();

            }

            return number;

        }

        public static int ReadIntNumber(string errorMessage = "Invalid Number, Enter again? ")
        {

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static int ReadIntNumberBetween(int from, int to, string errorMessage = "Number is not Within range, Enter again: ")
        {
            int number = ReadIntNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);
                number = ReadIntNumber();

            }
            return number;
        }

        public static float ReadFloatNumber(string errorMessage = "Invalid Number, Enter again? ")
        {

            float number;

            while (!float.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static float ReadFloatNumberBetween(float from, float to, string errorMessage = "Number is not Within range, Enter again: ")
        {

            float number = ReadFloatNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);
                number = ReadFloatNumber();

            }

            return number;

        }

        public static double ReadDblNumber(string errorMessage = "Invalid Number, Enter again? ")
        {

            double number;

            while (!double.TryParse(Console.ReadLine(), out number) /*|| number == (int)number*/)
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static double ReadDblNumberBetween(double from, double to, string errorMessage = "Number is not Within range, Enter again: ")
        {

            double number = ReadDblNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);

                number = ReadDblNumber();

            }

            return number;

        }

        public static int ReadPositiveIntNumber(string errorMessage = "Number is not a positive, Enter again: ")
        {

            int number;

            do
            {

                number = ReadIntNumber();

                if (!(number > 0))
                {
                    Console.WriteLine(errorMessage);
                }

            } while (number <= 0);

            return number;

        }

        public static double ReadPositiveDblNumber(string errorMessage = "Number is not a positive, Enter again: ")
        {

            double number = ReadDblNumber();

            while (number <= 0)
            {

                Console.WriteLine(errorMessage);
                number = ReadDblNumber();

            }

            return number;

        }

        public static char ReadChar(string errorMessage = "Please enter exactly one character, Enter again: ")
        {

            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || input.Length != 1)
            {

                Console.Write(errorMessage);
                input = Console.ReadLine();

            }

            return input[0];

        }

        public static bool ReadYesOrNo(string prompt, string errorMessage = "Invalid answer, Enter: (Y/N)? ")
        {

            Console.Write(prompt);
            char answer = ReadChar(errorMessage);

            while (char.ToLower(answer) != 'y' && char.ToLower(answer) != 'n')
            {

                Console.Write(errorMessage);
                answer = ReadChar(errorMessage);

            }

            return char.ToLower(answer) == 'y';

        }

        public static bool IsValidDate(clsDate date)
        {

            return date.IsValidDate();

        }

    }
}
