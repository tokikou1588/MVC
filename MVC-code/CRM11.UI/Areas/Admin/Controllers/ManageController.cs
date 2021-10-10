using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM11.Utility;
using CRM11.UI.Helper;

namespace CRM11.UI.Areas.Admin.Controllers
{
    public class ManageController:BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenu()
        {
            //1.从登录用户的 Session中 查询 菜单类型的权限集合
            var menuList = OpeCur.UsrNowPers.FindAll(o => o.perOperationType == 1 && o.perIsShow == true);
            //2.将 菜单权限集合 转成 TreeNode 节点 树结构
            //2.1创建根节点
            MODEL.FormatMODEL.TreeNode rootNode = OpeCur.BLLSession.Permission.Where(o => o.perParent == 0).SingleOrDefault().ToNode();
            //2.2根据根节点 对应 的 权限id，查询其所有的子节点
            rootNode.children = FillSonNodes(menuList, rootNode.id);
            return Content("[" + OpeCur.ToJson(rootNode) + "]");
        }

        #region 递归 生成 子节点 集合
        /// <summary>
        /// 递归 生成 子节点 集合
        /// </summary>
        /// <param name="listPer"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<MODEL.FormatMODEL.TreeNode> FillSonNodes(List<MODEL.Permission> listPer, int parentId)
        {
            List<MODEL.FormatMODEL.TreeNode> sonNodes = null;
            //循环权限集合 查找 子权限
            foreach (MODEL.Permission per in listPer)
            {
                //查找到子权限
                if (per.perParent == parentId)
                {
                    //实例化 子节点集合
                    if (sonNodes == null) sonNodes = new List<MODEL.FormatMODEL.TreeNode>();
                    //将子权限 转成 子节点
                    MODEL.FormatMODEL.TreeNode sonNode = per.ToNode();
                    //将子节点 加入 子节点集合
                    sonNodes.Add(sonNode);
                    //递归为 子节点 查找 子节点集合
                    sonNode.children = FillSonNodes(listPer, sonNode.id);
                }
            }
            return sonNodes;
        } 
        #endregion
    }
}