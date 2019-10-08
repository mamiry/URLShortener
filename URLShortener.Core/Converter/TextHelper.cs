using System;
using System.Linq;

namespace URLShortener.Core.Converter
{
    /// <summary>
    /// ابزار های متن
    /// </summary>
    public static class TextHelper
    {
        /// <summary>
        /// تبدیل به کاراکترهای کوچک و حذف اسپیس های ابتدا و انتها
        /// </summary>
        /// <param name="value">متن یا رشته </param>
        /// <returns>رشته فیکس شده</returns>
        public static string ToFix(this string value)
        {
            return value.Trim().ToLower();
        }
        /// <summary>
        /// تبدیل لینک به لینک کوتا
        /// </summary>
        /// <param name="length">طول لینک ساخته شده</param>
        /// <param name="url">لینک</param>
        /// <returns>رشته کوتاه شده</returns>
        public static string ToShortUrl(int length, string url)
        {
            ///لینک اصلی سایت
            string result = string.Empty;

            ///بررسی کوتاه بودن لینک اطلی و استفاده از آن
            if (!string.IsNullOrEmpty(url))
            {
                var lastPart = url.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).LastOrDefault();
                if (!string.IsNullOrEmpty(lastPart) && lastPart.Length > 0 && lastPart.Length <= length)
                { 
                    result += lastPart;
                }
                else
                {
                    url = string.Empty;
                }
            }
            /// در صورت کوتاه نبود یا مناسب نبودن لینک این بخش اجرا میشود
            if (string.IsNullOrEmpty(url))
            {
                ///ساخت لینک کوتاه بر اساس فرمول زیر
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                result += new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            return result;
        }

        /// <summary>
        /// بررسی لینک بودن متن یا رشته
        /// </summary>
        /// <param name="url">لینک یا رشته</param>
        /// <returns>بلی/خیر</returns>
        public static bool UrlChecker(this string url)
        {
            bool result = false;

            Uri uriResult;
            result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}
