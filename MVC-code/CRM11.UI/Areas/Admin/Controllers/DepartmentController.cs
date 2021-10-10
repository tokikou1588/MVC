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
    public class DepartmentController : BaseController
    {
        #region 1.0 加载 列表 视图 +Index()
        /// <summary>
        /// 1.0 加载 列表 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 1.2 加载 列表 数据 +Index() +HttpPost
        /// <summary>
        /// 1.2 加载 列表 数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询数据集合
            var pageData = OpeCur.BLLSession.Department.WherePaged(pageIndex, pageSize, o => o.depIsDel == false, o => o.depId);
            pageData.rows = pageData.rows.Select(o => o.ToPOCO()).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);
        }
        #endregion
    }
}
