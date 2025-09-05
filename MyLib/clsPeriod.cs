using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyLib.clsDate;

namespace MyLib
{
    internal class clsPeriod
    {

        private clsDate _startDate;
        private clsDate _endDate;

        public clsPeriod(clsDate startDate, clsDate endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public clsDate StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public clsDate EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public void Print()
        {

            Console.WriteLine("Period Start: ");
            StartDate.Print();

            Console.WriteLine("Period End: ");
            EndDate.Print();

        }

        public static bool IsOverlapPeriods(clsPeriod period1, clsPeriod period2)
        {

            if (
               CompareDates(period2.EndDate, period1.StartDate) == enDateCompare.Before
               ||
               CompareDates(period2.StartDate, period1.EndDate) == enDateCompare.After
               )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool IsOverlapWith(clsPeriod period2)
        {

            return IsOverlapPeriods(this, period2);

        }

        public static int GetPeriodLengthInDays(clsPeriod period, bool includeEndDate = false)
        {

            return GetDifferenceInDays(period.StartDate, period.EndDate, includeEndDate);

        }

        public int GetPeriodLengthInDays(bool includeEndDate = false)
        {

            return GetPeriodLengthInDays(this, includeEndDate);

        }

        public static bool IsDateInPeriod(clsPeriod period, clsDate date)
        {

            return !(IsDate1BeforeDate2(date, period.StartDate) || IsDate1AfterDate2(date, period.EndDate));

        }

        public bool IsDateInPeriod(clsDate date)
        {

            return IsDateInPeriod(this, date);

        }

        public static int CountOverlapDays(clsPeriod period1, clsPeriod period2)
        {

            int overlapDaysCount = 0;

            int period1Length = GetPeriodLengthInDays(period1, true);
            int period2Length = GetPeriodLengthInDays(period2, true);

            if (!IsOverlapPeriods(period1, period2))
            {
                return 0;
            }

            if (period1Length < period2Length)
            {
                while (IsDate1BeforeDate2(period1.StartDate, period1.EndDate))
                {

                    if (IsDateInPeriod(period2, period1.StartDate))
                    {
                        overlapDaysCount++;
                    }

                    period1.StartDate = AddOneDay(period1.StartDate);

                }
            }
            else
            {
                while (IsDate1BeforeDate2(period2.StartDate, period2.EndDate))
                {

                    if (IsDateInPeriod(period1, period2.StartDate))
                    {
                        overlapDaysCount++;
                    }

                    period2.StartDate = AddOneDay(period2.StartDate);

                }
            }

            return overlapDaysCount;

        }

        public int CountOverlapDaysWith(clsPeriod period2)
        {
            return CountOverlapDays(this, period2);

        }

    }
}
