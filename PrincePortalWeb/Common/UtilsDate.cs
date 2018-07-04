using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrincePortalWeb.Common
{
    public class UtilsDate
    {
        public static string LongDateFormat(DateTime theDate)
        {
            return string.Format("{0:dddd}, {1} {2:MMMM yyyy HH:mm}", theDate, ToOrdinal(theDate.Day), theDate);    
        }

        public static string FriendlyDateFormat(DateTime lastUpdateDate)
        {
            DateTime currentDate = DateTime.Now;

            TimeSpan delta = currentDate.Subtract(lastUpdateDate);
            if (delta.Days > 7)
                return lastUpdateDate.ToShortDateString();
            if (delta.Days > 1)
                return string.Format("{0} days ago", delta.Days);
            if (delta.Days == 1)
                return string.Format("Yesterday");
            if (delta.Hours > 1)
                return string.Format("{0} hours ago", delta.Hours);
            if (delta.Hours == 1)
                return string.Format("1 hour ago");
            if (delta.Minutes > 1)
                return string.Format("{0} minutes ago", delta.Minutes);
            if (delta.Minutes == 1)
                return string.Format("1 minute ago");
            return "A few seconds ago";
        }

        public static string ToOrdinal(int number)
        {
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return number.ToString() + "th";
            }

            switch (number % 10)
            {
                case 1:
                    return number.ToString() + "st";
                case 2:
                    return number.ToString() + "nd";
                case 3:
                    return number.ToString() + "rd";
                default:
                    return number.ToString() + "th";
            }
        }

        public static DateTime GetDate(DateTime? dateTime, Const.Dates dates)
        {
            DateTime sDate = DateTime.Now;
            if (dateTime.HasValue)
            {
                sDate = dateTime.Value;
            }

            switch (dates)
            {
                case Const.Dates.Start:
                    sDate = new DateTime(sDate.Year, sDate.Month, sDate.Day, 0, 0, 0, 0);
                    break;
                case Const.Dates.End:
                    sDate = new DateTime(sDate.Year, sDate.Month, sDate.Day, 23, 59, 59, 999);
                    break;
            }

            return sDate;
        }
    }
}
