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
    public class RoleController : BaseController
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
            var pageData = OpeCur.BLLSession.Role.WherePaged(pageIndex, pageSize, o => o.roleIsDel == false, o => o.roleId, true, "Department");
            pageData.rows = pageData.rows.Select(o => o.ToPOCO(true)).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);
        }
        #endregion

        [HttpGet]
        /// <summary>
        /// 2.0 加载 设置角色权限 视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetRolePer(int id)
        {
            CRM11.UI.Areas.Admin.ViewModel.SetRolePer model = new ViewModel.SetRolePer();
            model.RoleID = id;
            //1.需要查出 角色 已经设置的 权限集合
            model.AllPers = OpeCur.BLLSession.Permission.Where(o => o.perIsDel == false).ToList();
            //2.查询 所有的 权限集合 :
            //注意，EF生成连接查询： 1.直接使用Include方法 2.在EF的Select方法中 操作 实体类的导航属性
            model.RolePers = OpeCur.BLLSession.RolePerRelationship.Where(o => o.rprRoleId == id).Select(o => o.Permission).ToList();
            //3.加载视图
            return View(model);
        }

        [HttpPost]
        public ActionResult SetRolePer()
        {
            //1.获取被设置权限的 角色id
            int roleId = Request.Form["rid"].AsInt();
            //2.获取新设置的 权限id集合
            List<int> newPerIdList = Request.Form["newPerIds"].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(str=>str.AsInt()).ToList();
            //3.查询角色 原有的权限
            var oldPerList = OpeCur.BLLSession.RolePerRelationship.Where(o => o.rprRoleId == roleId).ToList();
            //4.从集合中循环并删除 相同的新老权限对象，新集合中剩下的权限 就要 新增到数据库；旧集合中剩下的权限 就要从数据库中删除
            //4.1循环
            for (int i = oldPerList.Count - 1; i >= 0; i--)
            { 
                var oldPer = oldPerList[i];
                if (newPerIdList.Contains(oldPer.rprPerId))
                {
                    newPerIdList.Remove(oldPer.rprPerId);
                    oldPerList.Remove(oldPer);
                }
            }
            //4.2新集合中剩下的权限 就要 新增到数据库
            newPerIdList.ForEach(newPerId => {
                OpeCur.BLLSession.RolePerRelationship.Add(new MODEL.RolePerRelationship() { rprRoleId = roleId, rprPerId = newPerId });
            });
            //4.3旧集合中剩下的权限 就要从数据库中删除
            oldPerList.ForEach(oldPer => {
                OpeCur.BLLSession.RolePerRelationship.Remove(oldPer);
            });
            OpeCur.BLLSession.SaveChange();
            return OpeCur.AjaxMsgOK();
        }
    }
}
