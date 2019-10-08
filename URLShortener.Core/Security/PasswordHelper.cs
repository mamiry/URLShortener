using System;
using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Core.Security
{
    /// <summary>
    /// ابزار های رمز عبور و امنیتی
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// کد کردن (هش ) کردن رمز عبور
        /// </summary>
        /// <param name="pass">متن / رشته رمز عبور</param>
        /// <returns></returns>
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5   
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }

    }
}
