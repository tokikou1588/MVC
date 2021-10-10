using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CRM11.UI.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 1.0 将字符串加密
        /// </summary>
        /// <param name="strOri"></param>
        /// <returns></returns>
        public static string ToEncyptString(this string strOri)
        {
            //1.创建 授权票据对象，将 要加密的字符串 传入
            FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, "aa", DateTime.Now, DateTime.Now.AddMinutes(60), true, strOri);
            //2.调用加密方法，将票据 转成 加密字符串返回
            return FormsAuthentication.Encrypt(ticket);
        }

        /// <summary>
        /// 2.0 解密字符串
        /// </summary>
        /// <param name="strOri"></param>
        /// <returns></returns>
        public static string ToDecyptString(this string strOri)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(strOri);
            return ticket.UserData;
        }
    }
}