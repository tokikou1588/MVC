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
    public class UserWorkFlowController : BaseController
    {
        //---------------------------查看可提交申请单的 工作流列表
        #region 1.0 加载列表视图 +ActionResult AddApplyList() -get
        /// <summary>
        /// 1.0 加载列表视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddApplyList()
        {
            return View();
        }
        #endregion

        #region 1.1 加载列表数据 +ActionResult AddApplyList() -post
        /// <summary>
        /// 1.1 加载列表数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddApplyList(FormCollection form)
        {
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询数据集合
            var pageData = OpeCur.BLLSession.WorkFLow.WherePaged(pageIndex, pageSize, o => o.wfIsDel == false && o.wfId > 0, o => o.wfId, true, "WorkFlowNode");
            pageData.rows = pageData.rows.Select(o => o.ToPOCO(true)).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);

        }
        #endregion
        //---------------------------新增申请单
        #region 2.0 加载 新增申请单 视图 +AddApply(int id)
        /// <summary>
        /// 2.0 加载 新增申请单 视图
        /// </summary>
        /// <param name="id">工作流id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddApply(int id)
        {
            ViewBag.wfId = id;

            return View();
        } 
        #endregion

        #region 2.1 保存 新增申请单 数据 +AddApply(ViewModel.AddApplyViewModel viewApplyModel)
        /// <summary>
        /// 2.1 保存 新增申请单 数据
        /// </summary>
        /// <param name="id">工作流id</param>
        /// <param name="viewApplyModel">申请单数据模型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddApply(int id,ViewModel.AddApplyViewModel viewApplyModel)
        {
            if (ModelState.IsValid)
            {
                //1.创建工作流引擎
                Code.WorkFlowApplyEngine engine = new Code.WorkFlowApplyEngine();
                engine.AddApply(viewApplyModel.ToModel(), id, OpeCur.UsrNow.empDepId.Value);
                return OpeCur.AjaxMsgOK();
            }
            else
            {
                return OpeCur.AjaxMsgNoValid();
            }
        }
        #endregion


        //---------------------------查看自己的申请单列表
        #region 3.1 加载 自己提交申请单列表 视图 +ViewSelfApplyList()
        /// <summary>
        /// 3.1 加载 自己提交申请单列表 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewSelfApplyList()
        {
            return View();
        } 
        #endregion

        #region 3.2 加载 自己提交申请单列表 数据 +ViewSelfApplyList()
        /// <summary>
        /// 3.2 加载 自己提交申请单列表 数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ViewSelfApplyList(FormCollection form)
        {
            //1.根据Session里的登录用户id 查询申请单列表
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询数据集合
            var pageData = OpeCur.BLLSession.WorkFlowApply.WherePaged(pageIndex, pageSize, o => o.wfaIsDel == false && o.wfaUserId == OpeCur.UsrNow.empId, o => o.wfaAddTime, true, "WorkFLow", "WorkFlowNode");
            pageData.rows = pageData.rows.Select(o => {
                var poco = o.ToPOCO(true);
                poco.StatuName = EnumHelper.ApplyStatue.DDLData.Single(c => c.Value == poco.wfaStatue.ToString()).Text;
                poco.PriorityName = EnumHelper.ApplyPriority.DDLData.Single(c => c.Value == poco.wfaPriority.ToString()).Text;
                return poco;
            }).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);
        }
        #endregion
        //---------------------------查看自己的某个申请单
        #region 3.3 查看指定的申请单 +ViewApply(int id)
        /// <summary>
        /// 3.3 查看指定的申请单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewApply(int id)
        {
            //1.根据id 查询 申请单(注意：需要同时根据登录用户的id查询，防止查看其它人的申请单)
            var apply = OpeCur.BLLSession.WorkFlowApply.Single(a => a.wfaId == id && a.wfaUserId == OpeCur.UsrNow.empId);
            //2.查询 申请单 当前所在的 工作流的 第一个节点，并判断 申请单所在的节点id 是否为 第一个节点
            ViewBag.isInFirstNode = OpeCur.BLLSession.WorkFlowNode.Where(o => o.wfnWFId == apply.wfaWFId, o => o.wfnOrder).FirstOrDefault().wfnId == apply.wfaCurNodeId;
            return View(apply);
        }
        #endregion


        //---------------------------查看自己可审批的申请单列表
        #region 4.1 加载 自己 可审批 申请单列表 视图 +ApproveApplyList()
        /// <summary>
        ///4 .1 加载 自己 可审批 申请单列表 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApproveApplyList()
        {
            return View();
        } 
        #endregion

        #region 4.2 加载 自己 可审批 申请单列表 数据 +ApproveApplyList()
        /// <summary>
        /// 4.2 加载 自己 可审批 申请单列表 数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApproveApplyList(FormCollection form)
        {
            //1.根据登录用户id查询角色id们
            var roleIds = OpeCur.BLLSession.EmpRoleRelation.Where(o => o.erUId == OpeCur.UsrNow.empId).Select(o => o.erRId).ToList();
            //2.根据角色id们，查询 对应的 节点id们
            var nodeIds = OpeCur.BLLSession.WorkFlowNodeRole.Where(o => roleIds.Contains(o.wfnrRoleId)).Select(o => o.wfnrNodeId).ToList();

            //3.根据节点id们，查询 处于 这些节点 的 申请单数据
            //1.根据Session里的登录用户id 查询申请单列表
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询数据集合
            var pageData = OpeCur.BLLSession.WorkFlowApply.WherePaged(pageIndex, pageSize, o => nodeIds.Contains(o.wfaCurNodeId), o => o.wfaAddTime, true, "WorkFLow", "WorkFlowNode");
            pageData.rows = pageData.rows.Select(o =>
            {
                var poco = o.ToPOCO(true);
                poco.StatuName = EnumHelper.ApplyStatue.DDLData.Single(c => c.Value == poco.wfaStatue.ToString()).Text;
                poco.PriorityName = EnumHelper.ApplyPriority.DDLData.Single(c => c.Value == poco.wfaPriority.ToString()).Text;
                return poco;
            }).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);
        } 
        #endregion
        //---------------------------审批申请单
        #region 4.0 查看指定的申请单 +ApproveApply(int id)
        /// <summary>
        /// 4.0 查看指定的申请单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApproveApply(int id)
        {
            var model = OpeCur.BLLSession.WorkFlowApply.Single(o => o.wfaId == id);
            return View(model);
        }
        #endregion

        #region 4.1 接收 并保存 审批数据！！ +ApproveApply(FormCollection form)
        /// <summary>
        /// 接收 并保存 审批数据！！
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApproveApply(FormCollection form)
        {
            string strContent = form["txtContent"];
            int opeType = form["opeType"].AsInt();
            int applyId = form["applyId"].AsInt();
            int operatorId = OpeCur.UsrNow.empId;

            Code.WorkFlowApplyEngine engin = new Code.WorkFlowApplyEngine();
            engin.ApproveApply(applyId, operatorId, strContent, opeType);
            return OpeCur.AjaxMsgOK();
        }
        #endregion
    }
}
