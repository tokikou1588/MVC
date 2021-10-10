using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM11.UI.Filters
{
    public class GlobalExceptionAttribute:System.Web.Mvc.HandleErrorAttribute
    {
        //操作上下文对象
        private Helper.OperationContext opeCur = new Helper.OperationContext();
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            //设置异常消息
            filterContext.Result = SendMsg(filterContext.Exception, "/admin/usr/login");
            //告诉asp.net mvc框架 异常已经被处理了，不需要再由框架 生成 错误页面了！
            filterContext.ExceptionHandled = true;
        }

        #region 3.0 根据是否为异步请求 返回不同的消息 +ActionResult SendMsg(string strMsg, string strBackUrl)
        /// <summary>
        /// 3.0 根据是否为异步请求 返回不同的消息
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strBackUrl"></param>
        /// <returns></returns>
        System.Web.Mvc.ActionResult SendMsg(Exception ex, string strBackUrl)
        {
            //1.判断请求报文中是否包含 X-Requested-With: XMLHttpRequest
            //1.1如果包含，则代表是 浏览器端通过 jquery异步方法 创建的 异步对象请求的
            if (opeCur.Request.Headers.AllKeys.Contains("X-Requested-With"))
            {
                return opeCur.AjaxMsgError(ex, strBackUrl);
            }
            //1.2如果不包含，则代表是浏览器直接请求的
            else
            {
                return opeCur.JsMsg(ex.Message, strBackUrl);
            }
        }
        #endregion

    }
}