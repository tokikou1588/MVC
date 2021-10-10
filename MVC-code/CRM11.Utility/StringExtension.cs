using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.Utility
{
    public static class StringExtension
    {
        #region 1.0 比较字符串是否相等（忽略大小写） + bool IsSame(this string strOri, string strCompare)
        /// <summary>
        /// 1.0 比较字符串是否相等（忽略大小写）
        /// </summary>
        /// <param name="strOri">源字符串</param>
        /// <param name="strCompare">待比较字符串</param>
        /// <returns></returns>
        public static bool IsSame(this string strOri, string strCompare)
        {
            if (string.IsNullOrEmpty(strOri) || string.IsNullOrEmpty(strCompare))
                return false;

            return string.Equals(strOri, strCompare, StringComparison.CurrentCultureIgnoreCase);

        } 
        #endregion

        #region 2.0 将字符串转成 MD5值 +string ToMD5(this string strOri)
        /// <summary>
        /// 2.0 将字符串转成 MD5值
        /// </summary>
        /// <param name="strOri"></param>
        /// <returns></returns>
        public static string ToMD5(this string strOri)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strOri));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        #endregion

        #region 3.0 判断当前字符串是否为空 + bool IsNullOrEmpty(this string strOri)
        /// <summary>
        /// 3.0 判断当前字符串是否为空
        /// </summary>
        /// <param name="strOri">源字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string strOri)
        {
            return string.IsNullOrEmpty(strOri);
        }
        #endregion

    }
}
