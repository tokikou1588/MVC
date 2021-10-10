using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM11.Utility;

namespace CRM11.UI.Extension
{
    public static class HtmlHelperExtension
    {
        #region 1.0 获取 当前登录用户 拥有的受访页面的 按钮
        /// <summary>
        /// 1.0 获取 当前登录用户 拥有的受访页面的 按钮
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static System.Web.Mvc.MvcHtmlString GetSonBtnJs(this System.Web.Mvc.HtmlHelper htmlHelper)
        {

            System.Text.StringBuilder sbBtnJs = new System.Text.StringBuilder(1000);
            foreach (var btn in htmlHelper.ViewBag.sonBtns as List<CRM11.MODEL.Permission>)
            {
                sbBtnJs.Append("{");
                sbBtnJs.Append("iconCls:'" + btn.perIco + "',");
                sbBtnJs.Append("text:'" + btn.perName + "',");
                sbBtnJs.Append("handler:" + btn.perJsMethodName + "");
                sbBtnJs.Append("},'-',");
            }
            System.Web.Mvc.MvcHtmlString mvcStr = new System.Web.Mvc.MvcHtmlString(sbBtnJs.ToString());
            return mvcStr;
        } 
        #endregion

        #region 2.0 判断登录用户 是否拥有 绑定 指定JS方法名 的 按钮 +bool IsBtnExist(this System.Web.Mvc.HtmlHelper htmlHelper, string strJsMethodName)
        /// <summary>
        /// 2.0 判断登录用户 是否拥有 绑定 指定JS方法名 的 按钮
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="strJsMethodName">要查找的按钮绑定的JS方法名</param>
        /// <returns></returns>
        public static bool IsBtnExist(this System.Web.Mvc.HtmlHelper htmlHelper, string strJsMethodName)
        {
            var btn = (htmlHelper.ViewBag.sonBtns as List<CRM11.MODEL.Permission>).FirstOrDefault(o => o.perJsMethodName.IsSame(strJsMethodName));

            return btn != null;
        } 
        #endregion
    }
}