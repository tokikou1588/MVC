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
    /// <summary>
    /// 权限管理 控制器
    /// </summary>
    public class PermissionController : BaseController
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

        #region 1.1 加载 子权限列表 视图 +SonIndex()
        /// <summary>
        /// 1.1 加载 子权限列表 视图
        /// </summary>
        /// <param name="id">父权限id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SonIndex(int id)
        {
            ViewBag.pid = id;
            return View();
        }
        #endregion

        #region 1.2 加载 列表 数据 +Index() +HttpPost
        /// <summary>
        /// 1.2 加载 列表 数据
        /// </summary>
        /// <param name="id">要查询的子权限集合 的 父权限id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int id)
        {
            //MODEL.FormatMODEL.PageData<MODEL.Permission> page
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询所有的权限列表
            var pers = OpeCur.BLLSession.Permission.WherePaged(pageIndex, pageSize, o => o.perIsDel == false && o.perParent == id, o => o.perOrder); //.Where(o => o.perIsDel == false).OrderBy(o => o.perOrder).ToList().Select(o=>o.ToPOCO());
            pers.rows = pers.rows.Select(o => o.ToPOCO()).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pers);
            return Content(strJson);
        } 
        #endregion

        #region 2.0 加载 新增 视图 + Add()
        /// <summary>
        /// 2.0 加载 新增 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            //1.准备 父权限 下拉框 o.perParent <= 1 &&
            var parPers = OpeCur.BLLSession.Permission.Where(o =>  o.perIsDel == false && o.perIsShow == true, o => o.perOrder).ToList().Select(o => new SelectListItem()
            {
                Text = o.perParent == 0 ? o.perName : "--" + o.perName,
                Value = o.perId.ToString()
            });
            ViewBag.parPers = parPers;
            return View();
        } 
        #endregion

        #region 2.1 保存 新增 数据 +Add(ViewModel.Permission viewModel)
        /// <summary>
        /// 2.1 保存 新增 数据
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(ViewModel.Permission viewModel)
        {
            if (ModelState.IsValid)
            {
                OpeCur.BLLSession.Permission.Add(viewModel.ToPOCO());
                OpeCur.BLLSession.SaveChange();
                return OpeCur.AjaxMsgOK();
            }
            else
            {
                return OpeCur.AjaxMsgNOOK("请不要禁用浏览器js~~!");
            }
        } 
        #endregion

        #region 2.2 查找 父权限 下 子权限的 最大序号，然后+1 返回 +string LoadOrderNumber()
        [HttpPost]
        /// <summary>
        /// 2.2 查找 父权限 下 子权限的 最大序号，然后+1 返回
        /// </summary>
        /// <returns></returns>
        public string LoadOrderNumber()
        {
            int newOrderNo = -1;
            //1.获取父权限id
            int pid = Request.Form["pId"].AsInt();
            //1.1查询父权限
            var parentPer = OpeCur.BLLSession.Permission.Single(o => o.perId == pid);
            //2.查询 父权限下的 最大序号子权限
            var maxOrderSonPer = OpeCur.BLLSession.Permission.Where(o => o.perParent == pid).OrderByDescending(o => o.perOrder).FirstOrDefault();

            //序号增长量
            int seed = 1;
            //3.判断是否添加的为 顶级权限下的 一级子权限（父权限）
            if (parentPer.perParent == 0)
            {
                seed = 100000;//如果是一级子权限，则设置 序号 增长量 为 100000，否则默认为 1
            }
            //4.判断 父权限下 是否存在子权限
            //  如果不存在，则根据父权限的序号生成第一个子节点的序号
            if (maxOrderSonPer == null)
            {
                newOrderNo = parentPer.perOrder + seed;
            }
            //2.2如果有序号最大子权限，则在根据最大序号+seed，生成新序号
            else
            {
                newOrderNo = maxOrderSonPer.perOrder + seed;
            }

            return newOrderNo.ToString();
        } 
        #endregion

        #region 3.0 加载 修改 视图 +Modify(int id)
        /// <summary>
        /// 3.0 加载 修改 视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Modify(int id)
        {
            //1.查询要修改的 权限 实体对象
            var modifyData = OpeCur.BLLSession.Permission.Single(o => o.perId == id);
            if (modifyData == null) { throw new Exception("找不到要修改的权限~~~~~~~！"); }

            //2.准备 父权限 下拉框
            var parPers = OpeCur.BLLSession.Permission.Where(o => o.perParent <= 1 && o.perIsDel == false && o.perIsShow == true, o => o.perOrder).ToList().Select(o => new SelectListItem()
            {
                Text = o.perParent == 0 ? o.perName : "--" + o.perName,
                Value = o.perId.ToString()
            });
            ViewBag.parPers = parPers;

            //3.将 实体对象 转成 视图模型对象 传给 视图
            return View(modifyData.ToViewModel());
        } 
        #endregion

        [HttpPost]
        /// <summary>
        /// 3.1 保存 修改 数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Modify(int id, ViewModel.Permission viewmodel)
        {
            if (ModelState.IsValid)
            {
                //1.从url参数中 获取 要修改的 对象的 id
                viewmodel.perId = id;
                //2.修改权限
                OpeCur.BLLSession.Permission.Modify(viewmodel.ToPOCO(), "perParent", "perName", "perRemark", "perAreaName", "perControllerName", "perActionName", "perFormMethod", "perOperationType", "perJsMethodName", "perIco", "perIsLink", "perOrder", "perIsShow");
                OpeCur.BLLSession.SaveChange();
                return OpeCur.AjaxMsgOK();
            }
            return OpeCur.AjaxMsgNOOK("请不要禁用浏览器js~~~");
        }
    }
}
