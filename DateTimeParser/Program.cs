using System;

namespace DateTimeParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Program businessHourCalculator = new Program();
            string test1Start = "2021-06-21 08:00:00";
            string test1End = "2021-06-25 17:00:00";
            Console.WriteLine("Should be 40: " + businessHourCalculator.BusinessHours(test1Start, test1End));
        }

        public Program()
        {

        }

        public int Businesshours(string s, string e)
        {
            DateTime start = DateTime.Parse(s);
            DateTime end = DateTime.Parse(e);

            TimeSpan reset = new TimeSpan(0, 0, 0);

            DayOfWeek startDayOfWeek = start.DayOfWeek;
            int daysInFirstWeek = 0;
            int hoursInFirstDay = 0;
            int hoursInFirstWeek = 0;

            if (startDayOfWeek == DayOfWeek.Saturday)
            {
                daysInFirstWeek = 0;
                hoursInFirstDay = 0;
                hoursInFirstWeek = 0;
            }
            else if(startDayOfWeek == DayOfWeek.Sunday)
            {
                daysInFirstWeek = 5;
                hoursInFirstDay = 8;
                hoursInFirstWeek = 40;
            }
            else
            {
                daysInFirstWeek = DayOfWeek.Saturday - startDayOfWeek -  1;
                if (start.Hour > 9 && start.Hour < 17)
                {
                    hoursInFirstDay = 17 - start.Hour;
                }
                else if(start.Hour <= 9)
                {
                    hoursInFirstDay = 0;
                }
                else
                {
                    hoursInFirstDay = 8;
                }
                hoursInFirstWeek = daysInFirstWeek * 8 + hoursInFirstDay;
                start = start.AddDays(daysInFirstWeek+2);
                start = start.Date + reset;

            }

            DayOfWeek endDayOfWeek = end.DayOfWeek;
            int daysInLastWeek = 0;
            int hoursInLastDay = 0;
            int hoursInLastWeek = 0;

            if (endDayOfWeek == DayOfWeek.Sunday)
            {
                daysInLastWeek = 0;
                hoursInLastDay = 0;
                hoursInLastWeek = 0;
            }
            else if(endDayOfWeek == DayOfWeek.Saturday)
            {
                daysInLastWeek = 5;
                hoursInLastDay = 8;
                hoursInLastWeek = 40;
            }
            else
            {
                daysInLastWeek = end.DayOfWeek - DayOfWeek.Monday;
                if(end.Hour >= 9 && end.Hour < 17)
                {
                    hoursInLastDay = end.Hour - 9;
                }
                else if(end.Hour < 9)
                {
                    hoursInLastDay = 0;
                }
                else
                {
                    hoursInLastDay = 8;
                }
            }

            return 0;
        }
    }
}
