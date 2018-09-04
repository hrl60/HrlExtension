using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrlExtentions
{
    public static class DateExtentions
    {
        /// <summary>
        /// Convert Date to Persian String Value
        /// </summary>
        /// <param name="Dt"></param>
        /// <returns></returns>
        public static string ToPersian(this DateTime Dt)
        {
            //string GregorianDate = "Thursday, October 24, 2013";
            //DateTime d = DateTime.Parse(GregorianDate);
            PersianCalendar pc = new PersianCalendar();
            string retVal = string.Format("{0:0000}/{1:00}/{2:00}", pc.GetYear(Dt), pc.GetMonth(Dt), pc.GetDayOfMonth(Dt));
            if (Dt.TimeOfDay > TimeSpan.Zero)
                retVal = retVal + " " + string.Format("{0:00}:{2:00}:{2:00}", Dt.TimeOfDay.Hours, Dt.TimeOfDay.Minutes, Dt.TimeOfDay.Seconds);
            return retVal;
        }
        /// <summary>
        /// Convert Date to Persian String Value
        /// </summary>
        /// <param name="Dt"></param>
        /// <returns></returns>
        public static string ToPersian(this DateTime? Dt)
        {
            string RetVa = (Dt == null ? "" : ((DateTime)Dt).ToPersian());
            return RetVa;
        }
    }
}
