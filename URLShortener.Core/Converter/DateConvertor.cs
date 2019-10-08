using System;
using System.Globalization;

namespace URLShortener.Core.Converter
{
    /// <summary>
    /// ابزار های تاریخ
    /// </summary>
    public static class DateConvertor
    {
        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="value">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی به صورت 1398/01/01</returns>
        public static string ToShamsi(this DateTime value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/"
                                     + pc.GetMonth(value).ToString("00") + "/" +
                                     pc.GetDayOfMonth(value).ToString("00");
        }
        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="value">تاریخ شمسی 1398/01/01</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime ToGregorian(this string value)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(5, 2)), int.Parse(value.Substring(8, 2)), pc);
        }
    }
}
