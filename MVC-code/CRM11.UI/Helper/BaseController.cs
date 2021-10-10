using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM11.UI.Helper
{
    public class BaseController : Controller
    {
        //public BaseController()
        //{
        //    //1.完成检查 Session 
        //    //2.检查 权限 
        //}

        public Helper.OperationContext OpeCur
        {
            get
            {
                return OperationContext.Current;
            }
        }
    }
}