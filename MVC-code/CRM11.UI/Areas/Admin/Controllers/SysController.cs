using CRM11.UI.Helper;
using CRM11.Utility.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using CRM11.UI.Extension;

namespace CRM11.UI.Areas.Admin.Controllers
{
    public class SysController : BaseController
    {
        public ActionResult LoginOut()
        {
            //1.删除登录用户的Session
            Session.Abandon();
            //2.删除Cookie
            HttpCookie cookie = new HttpCookie(Helper.OperationContext.USERID_COOKIE_KEY, "");
            cookie.Expires = DateTime.Now.AddDays(-10);
            Response.Cookies.Add(cookie);
            return OpeCur.JsMsg("退出成功勒 ~~ 欢迎先生下回光临~~~~要给好评哦~~！","/admin/usr/login");
        }

    }
}
