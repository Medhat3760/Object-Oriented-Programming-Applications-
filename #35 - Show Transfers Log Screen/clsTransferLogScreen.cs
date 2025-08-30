using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class clsTransferLogScreen : clsScreen
    {

        private static void _PrintTransferLogRecordLine(clsBankClient.stTransferLogRecord transferLogRecord)
        {

            Console.Write($"{"".PadLeft(10)}| {transferLogRecord.dateTime.PadRight(22)}");
            Console.Write($"| {transferLogRecord.sourceAccountNumber.PadRight(10)}");
            Console.Write($"| {transferLogRecord.destinationAccountNumber.PadRight(10)}");
            Console.Write($"| {transferLogRecord.amount.ToString().PadRight(12)}");
            Console.Write($"| {transferLogRecord.sourceBalanceAfter.ToString().PadRight(12)}");
            Console.Write($"| {transferLogRecord.destinationBalanceAfter.ToString().PadRight(12)}");
            Console.Write($"| {transferLogRecord.userName.PadRight(10)}");

        }

        public static void ShowTransferLogScreen()
        {

            List<clsBankClient.stTransferLogRecord> listTransferLogRecord = clsBankClient.GetTransferLogList();

            string title = "\t Transfer Log List Screen";
            string subTitle = $"\t      ({listTransferLogRecord.Count}) Record(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_',100)}\n");

            Console.Write($"{"".PadLeft(10)}| {"DateTime".PadRight(22)}");
            Console.Write($"| {"s.Acc".PadRight(10)}");
            Console.Write($"| {"d.Acc".PadRight(10)}");
            Console.Write($"| {"Amount".PadRight(12)}");
            Console.Write($"| {"s.Balance".PadRight(12)}");
            Console.Write($"| {"d.Balance".PadRight(12)}");
            Console.Write($"| {"User".PadRight(10)}");

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

            if(listTransferLogRecord.Count == 0)
            {

                Console.WriteLine("\n\t\t\t\t\tNo Transfers Available in The System!");

            }
            else
            {

                foreach(clsBankClient.stTransferLogRecord record in listTransferLogRecord)
                {

                    _PrintTransferLogRecordLine(record);
                    Console.WriteLine();

                }

            }

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

        }

    }
}
