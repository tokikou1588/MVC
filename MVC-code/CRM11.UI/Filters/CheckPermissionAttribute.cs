﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM11.UI.Filters
{
    /// <summary>
    /// 自定义授权过滤器
    /// </summary>
    public class CheckPermissionAttribute:System.Web.Mvc.AuthorizeAttribute
    {
        //操作上下文对象
        private Helper.OperationContext opeCur = new Helper.OperationContext();

        /// <summary>
        /// 区域黑名单
        /// </summary>
        List<string> blackAreaNames = new List<string>() { "admin" };

        /// <summary>
        /// 授权方法-在此检查权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //判断当前请求的 url中是否 有区域名
            if (filterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                //0.2获取当前请求的区域名
                string strCurAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                //如果 当前请求的 区域 在检查黑名单中，则 检查登陆和权限
                if (blackAreaNames.Contains(strCurAreaName))
                {
                    //0.1 判断 当前访问的 控制器 或 方法上 是否有 贴【SkipLogin】标签，如果有，则不需要检查登录和权限
                    if (!IsDefind<CRM11.Utility.Attrs.SkipLoginAttribute>(filterContext))
                    {
                        //1.检查是否登录
                        if (IsLogin())
                        {

                            LoadMenuBtns(filterContext);
                            //1.1判断 当前访问的 控制器 或方法上 是否有贴 [SkipPermission]标签，如果有，则不需要检查权限
                            if (!IsDefind<CRM11.Utility.Attrs.SkipPermissionAttribute>(filterContext))
                            {
                                //2.检查登录用户是否有 访问当前url的权限
                                if (!opeCur.HasPermission(strCurAreaName,
                                     filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                     filterContext.ActionDescriptor.ActionName,
                                     opeCur.Request.HttpMethod))
                                {
                                    filterContext.Result = SendMsg("您没有进行此项操作的权限~~~", "/admin/usr/login");
                                }
                                //如果有权限
                                else
                                {
                                    //LoadMenuBtns(filterContext);
                                }
                            }
                            //跳过权限检查后
                            else 
                            {
                                //LoadMenuBtns(filterContext);
                            }
                        }
                        //没有登录
                        else
                        {
                            filterContext.Result = SendMsg("您尚未登录~~~", "/admin/usr/login");
                        }
                    }
                }
            }

        }

        #region 1.0 判断当前访问用户 是否登录 -bool IsLogin()
        /// <summary>
        /// 判断当前访问用户 是否登录
        ///     如果没有Session，但是有Cookie，则自动登录
        /// </summary>
        /// <returns></returns>
        private bool IsLogin()
        {
            //1.先判断是否有Session
            if (opeCur.UsrNow == null)
            {
                //1.1如果没有，则检查登录Cookie是否存在
                //1.1.1如果没有 登录Cookie，则代表用户没有登录，直接返回false
                if (opeCur.UsrId <= -1)
                {
                    return false;
                }
                //1.1.2如果有cookie，则根据cookie里的登录用户id，重新查询 登录用户实体，并存入 Session
                else
                {
                    var usrId = opeCur.UsrId;
                    //根据cookie里的用户id重新查询用户，并存入Session 【自动登录】
                    opeCur.UsrNow = opeCur.BLLSession.Employee.Where(o => o.empId == usrId).SingleOrDefault().ToPOCO();
                    //f.1查询登录用户的权限集合 并存入 Session
                    opeCur.UsrNowPers = opeCur.BLLSession.Employee.GetUserPermission(usrId);
                }
            }
            return true;
        } 
        #endregion

        #region 2.0 检查 过滤器上下文 中的当前被请求的方法 和 控制器 是否有贴标签 -bool IsDefind<AttrType>(System.Web.Mvc.AuthorizationContext filterContext)
        /// <summary>
        /// 检查 过滤器上下文 中的当前被请求的方法 和 控制器 是否有贴标签
        /// </summary>
        /// <typeparam name="AttrType">要检查的标签类型</typeparam>
        /// <param name="filterContext">过滤器上下文</param>
        /// <returns></returns>
        bool IsDefind<AttrType>(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //获取要检查的标签 的 类型对象
            Type attrTypeObj = typeof(AttrType);
            //分别检查 被请求的方法 和 控制器上 是否有贴 指定的标签，如果任意贴了，则返回true
            return filterContext.ActionDescriptor.IsDefined(attrTypeObj, false)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(attrTypeObj, false);
        } 
        #endregion

        #region 3.0 根据是否为异步请求 返回不同的消息 +ActionResult SendMsg(string strMsg, string strBackUrl)
        /// <summary>
        /// 3.0 根据是否为异步请求 返回不同的消息
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strBackUrl"></param>
        /// <returns></returns>
        System.Web.Mvc.ActionResult SendMsg(string strMsg, string strBackUrl)
        {
            //1.判断请求报文中是否包含 X-Requested-With: XMLHttpRequest
            //1.1如果包含，则代表是 浏览器端通过 jquery异步方法 创建的 异步对象请求的
            if (opeCur.Request.Headers.AllKeys.Contains("X-Requested-With"))
            {
                return opeCur.AjaxMsgNOOK(strMsg, strBackUrl);
            }
            //1.2如果不包含，则代表是浏览器直接请求的
            else
            {
                return opeCur.JsMsg(strMsg, strBackUrl);
            }
        } 
        #endregion

        #region 4.0 根据当前访问的页面 查找 登录用户的 子按钮权限 +void LoadMenuBtns(System.Web.Mvc.AuthorizationContext filterContext)
        /// <summary>
        /// 根据当前访问的页面 查找 登录用户的 子按钮权限
        /// </summary>
        void LoadMenuBtns(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //1.获取当前请求url数据
            string strCurAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
            string strControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string strActionName = filterContext.ActionDescriptor.ActionName;
            //1.1根据当前访问url找到 登录用户的 菜单权限（到登录用户的Session中存放的权限集合中）
            MODEL.Permission menuPer = opeCur.GetUsrPermission(strCurAreaName, strControllerName, strActionName, opeCur.Request.HttpMethod);
            //1.2如果存在此权限在，则加载用户 在此页面的 按钮集合
            if (menuPer != null)
            {
                //2.再根据菜单权限 去 当前登录用户Session的 权限集合中 查找 子按钮权限集合
                var sonBtns = opeCur.UsrNowPers.Where(o => o.perParent == menuPer.perId && o.perOperationType == Helper.EnumHelper.OperationType.BUTTON && o.perIsDel == false).OrderBy(o=>o.perOrder).ToList();
                //4.如果 登录用户 没有任何 该页面的  子按钮权限，就设置一个空的权限集合
                if (sonBtns == null)
                    filterContext.Controller.ViewBag.sonBtns = emptyBtns;
                else
                    //5.存入 ViewBag
                    filterContext.Controller.ViewBag.sonBtns = sonBtns;
            }
            else {
                filterContext.Controller.ViewBag.sonBtns = emptyBtns;
            }
        }
        #endregion

        static List<MODEL.Permission> emptyBtns = new List<MODEL.Permission>();
    }
}