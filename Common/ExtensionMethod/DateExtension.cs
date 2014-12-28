using System;
using System.Globalization;

namespace Common.ExtensionMethod
{
    public static class DateExtension
    {
        /// <summary>
        /// get datetime day month year format
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>string format of date</returns>
        public static string DayMonthYear(this DateTime date)
        {
            return String.Format("{0:MM/dd/yyyy}", date);
        }
        /// <summary>
        /// get datetime day month year format
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>string format of date</returns>
        public static string DaysMonthsDayYear(this DateTime date)
        {
            return String.Format("{0:ddd, MMM d, yyyy}", date);
        }
        /// <summary>
        /// get the week number of datetime
        /// </summary>
        /// <param name="value">datetime</param>
        /// <returns>number order of week</returns>
        public static int WeekNumber(this DateTime value)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }
    }
}