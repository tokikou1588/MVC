using CRM11.UI.Helper;
using CRM11.Utility.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using CRM11.UI.Extension;
using CRM11.Utility;

namespace CRM11.UI.Areas.Admin.Controllers
{
    public class UsrController : BaseController
    {
        #region 1.1 加载 登录 视图 +Login()
        /// <summary>
        /// 1.1 加载 登录 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet, SkipLogin]
        public ActionResult Login()
        {
            return View();
        } 
        #endregion

        #region 1.2 接收登录数据 + Login(CRM11.UI.ViewModel.LoginModel usrLoginModel)
        /// <summary>
        /// 1.2 接收登录数据
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost, SkipLogin]
        public ActionResult Login(CRM11.UI.ViewModel.LoginModel usrLoginModel)
        {
            //a.做服务器端验证
            if (ModelState.IsValid)
            {
                //b.检查验证码
                if (Session[VCode.vCodeName] != null && usrLoginModel.LoginCode.IsSame(Session[VCode.vCodeName].ToString()))
                {
                    var usr = OpeCur.BLLSession.Employee.Where(o => o.empLoginName == usrLoginModel.LoginName).SingleOrDefault();
                    //c.1 登录名错误
                    if (usr == null)
                    {
                        return OpeCur.AjaxMsgNOOK("登录名错误~~！");
                    }
                    //c.2如果登录名没错，则验证密码是否正确
                    else
                    {
                        //d.1 如果密码相等，则登陆成功
                        if (usr.empLoginPwd.IsSame(usrLoginModel.LoginPwd.ToMD5()))
                        {
                            //e.1保存当前登陆用户对象到 Sessioin
                            OpeCur.UsrNow = usr.ToPOCO();//将EF查出来的 代理对象 转成 普通实体类对象保存 POCO
                            //e.2判断是否需要保存 Cookie
                            if (usrLoginModel.IsKeepLogin)
                            {
                                OpeCur.UsrId = usr.empId;
                            }
                            //f.1查询登录用户的权限集合 并存入 Session
                            OpeCur.UsrNowPers = OpeCur.BLLSession.Employee.GetUserPermission(usr.empId);

                            return OpeCur.AjaxMsgOK("登录成功了~", "/admin/manage/index");
                        }
                        //d.2 登录失败
                        else
                        {
                            return OpeCur.AjaxMsgNOOK("登录密码错误~~！");
                        }
                    }
                }
                //b.1验证码错误
                else
                {
                    return OpeCur.AjaxMsgNOOK("验证码输入错误~~~");
                }
            }
            return OpeCur.AjaxMsgNOOK("请不要关闭浏览器JS功能~~！");
        } 
        #endregion

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
            var pageData = OpeCur.BLLSession.Employee.WherePaged(pageIndex, pageSize, o => o.empIsDel == false, o => o.empId, true, "Department");
            pageData.rows = pageData.rows.Select(o => o.ToPOCO(true)).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);
        }
        #endregion

        #region 2.1 加载 设置用户角色视图 +SetUsrRole()
        /// <summary>
        /// 2.1 加载 设置用户角色视图
        /// </summary>
        /// <param name="id">要设置角色的用户id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SetUsrRole(int id)
        {
            //1.查询 部门集合
            ViewBag.depList = OpeCur.BLLSession.Department.Where(o => o.depIsDel == false);
            //2.根据 要设置角色的用户 查询 已经有的角色集合
            ViewBag.roleList = OpeCur.BLLSession.EmpRoleRelation.Where(o => o.erUId == id).Select(o => o.Role);
            return View();
        } 
        #endregion

        #region 3. 加载 部门角色 数据 +GetDepRoles()
        /// <summary>
        /// 2.1 加载 部门角色  数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepRoles()
        {
            //1.获取部门id
            int depId = Request.QueryString["depId"].AsInt();
            var roleList = OpeCur.BLLSession.Role.Where(o => o.roleDepId == depId).ToList().Select(o => o.ToPOCO());
            return OpeCur.AjaxMsgOK(data: roleList);//strMsg: null, 
        }
        #endregion
    }
}
