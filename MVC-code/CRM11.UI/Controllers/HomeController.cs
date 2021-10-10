using CRM11.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM11.UI.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        /// <summary>
        /// Action 方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return Redirect("/admin/");
        }

    }
}
