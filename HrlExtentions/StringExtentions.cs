using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrlExtentions
{
    public static class StringExtentions
    {
        /// <summary>
        /// Convert Persian String Value to Date
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDate(this string str)
        {
            try
            {
                DateTime retVal;
                string persianDate = str.Substring(0, 10);
                //CultureInfo persianCulture = new CultureInfo("fa-IR");
                //DateTime persianDateTime = DateTime.ParseExact(persianDate,
                //    "yyyy/MM/dd", persianCulture);
                DateTime persianDateTime = new DateTime(int.Parse(str.Substring(0, 4)), int.Parse(str.Substring(5, 2)), int.Parse(str.Substring(8, 2)), new PersianCalendar());
                if (str.Length > 10)
                {
                    var tm = str.Substring(11).ToLower().Replace("ق.ظ", "").Replace("ب.ظ", "").Replace("am", "").Replace("pm", "").Trim();
                    var tk = TimeSpan.Parse(tm);
                    if (str.Contains("pm") || str.Contains("ب.ظ"))
                        tk = tk.Add(new TimeSpan(12, 0, 0));
                    persianDateTime = persianDateTime.AddSeconds(tk.TotalSeconds);
                }
                retVal = persianDateTime;
                return retVal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static long ToInt16(this string value)
        {
            Int16 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int16.TryParse(value, out result);

            return result;
        }

        public static long ToInt32(this string value)
        {
            Int32 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int32.TryParse(value, out result);

            return result;
        }
        public static int ToInt(this string value)
        {
            int result = 0;

            if (!string.IsNullOrEmpty(value))
                int.TryParse(value, out result);

            return result;
        }

        public static long ToInt64(this string value)
        {
            Int64 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int64.TryParse(value, out result);

            return result;
        }
        public static long ToLong(this string value)
        {
            long result = 0;

            if (!string.IsNullOrEmpty(value))
                long.TryParse(value, out result);

            return result;
        }
    }
}
