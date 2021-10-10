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
    public class WorkFlowController : BaseController
    {

        #region 1.0 加载列表视图 +ActionResult Index() -get
        /// <summary>
        /// 1.0 加载列表视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 1.1 加载列表数据 +ActionResult Index() -post
        /// <summary>
        /// 1.1 加载列表数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
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


        #region 2.0 加载 新增视图 +ActionResult Add() -get
        /// <summary>
        /// 2.0 加载 新增视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        #endregion

        #region 2.0 加载 新增视图 +ActionResult Add() -post
        /// <summary>
        /// 2.0 加载 新增视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(ViewModel.WorkFlow perViewModel)
        {
            //1.在服务器端 根据 视图模型类 属性上 定义的 验证注解 再次验证
            if (ModelState.IsValid)
            {
                try
                {
                    //2.新增
                    OpeCur.BLLSession.WorkFLow.Add(perViewModel.ToModel());
                    OpeCur.BLLSession.SaveChange();
                    return OpeCur.AjaxMsgOK();
                }
                catch (Exception ex)
                {
                    return OpeCur.AjaxMsgError(ex.Message);
                }
            }
            return OpeCur.AjaxMsgNOOK("您提交的数据有误！请不要禁用浏览器JS功能或伪造报文提交~~~！");
        }
        #endregion

        #region 3.0 加载 工作流节点列表 视图 +ActionResult Index() -get
        /// <summary>
        /// 3.0 加载 工作流节点 列表视图
        /// </summary>
        /// <param name="id">工作流id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewSonNode(int id)
        {
            ViewBag.wfId = id;
            return View();
        }
        #endregion

        #region 3.1 加载 工作流节点列表 数据 +ActionResult Index() -post
        /// <summary>
        /// 3.1 加载 工作流节点列表 数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ViewSonNode(int id,FormCollection form)
        {
            int pageIndex = Request.Form["page"].AsInt();
            int pageSize = Request.Form["rows"].AsInt();
            //1.查询数据集合
            var pageData = OpeCur.BLLSession.WorkFlowNode.WherePaged(pageIndex, pageSize, o => o.wfnIsDel == false && o.wfnWFId==id, o => o.wfnId, true);
            pageData.rows = pageData.rows.Select(o => o.ToPOCO(true)).OrderBy(o => o.wfnOrder).ToList();
            //2.转成json格式字符串
            var strJson = OpeCur.ToJson(pageData);
            return Content(strJson);

        }
        #endregion

        #region 4.0加载 新增工作流的子节点 视图 +AddSon(int id)
        /// <summary>
        /// 4.0加载 新增工作流的子节点 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddSon(int id)
        {
            //4.1工作流已有节点集合
            ViewBag.otherSonNodes = new SelectList(OpeCur.BLLSession.WorkFlowNode.Where(o => o.wfnWFId == id && o.wfnIsDel == false, o => o.wfnOrder), "wfnId", "wfnName");
            //4.2节点类型
            ViewBag.nodeType = new List<SelectListItem>() { new SelectListItem() { Text = "普通节点", Value = "1" }, new SelectListItem() { Text = "IF业务节点", Value = "2" } };
            return PartialView();
        } 
        #endregion

        #region  4.1执行 新增工作流子节点 业务，并保存到数据库 +AddSon(int id, ViewModel.AddSonNode viewModel)
        /// <summary>
        /// 4.1执行 新增工作流子节点 业务，并保存到数据库
        /// </summary>
        /// <param name="id">工作流id</param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSon(int id, ViewModel.AddSonNode viewModel)
        {
            if (ModelState.IsValid)
            {
                var nodeModel = viewModel.ToModel();
                nodeModel.wfnWFId = id;//设置节点所在 工作流id
                //1.如果是普通节点，则只要保存节点数据，并且，不需要保存 业务类名
                //1.0如果 新增节点 要设置为 首节点，则需要，将整个工作流的其它节点的序号都+1
                if (viewModel.PrevNodeId == -1)
                {
                    nodeModel.wfnOrder = OpeCur.BLLSession.WorkFlowNode.ReSortAll(id);
                }
                else
                {
                    // 1.1如果 上个节点存在，则需要 将新节点的 序号设置到 上个节点之后，并且，把原来上个节点后面的 序号都 +1
                    var preNode = OpeCur.BLLSession.WorkFlowNode.Single(o => o.wfnId == viewModel.PrevNodeId);
                    // 1.2重拍工作流节点之后的其它节点的 序号，并将新的序号 赋值给 新节点
                    nodeModel.wfnOrder = OpeCur.BLLSession.WorkFlowNode.ReSort(preNode);
                }
                //在新增节点前 判断如果是 普通节点，要确保 业务类名 为空
                if (viewModel.NodeType == 1) {
                    nodeModel.wfnBLLClassName = "";
                }
                // 1.4保存新增节点
                OpeCur.BLLSession.WorkFlowNode.Add(nodeModel);
                OpeCur.BLLSession.SaveChange();

                //2.如果是业务节点，则需要保存节点数据和业务类型，并且 需要 保存 分支节点
                #region 业务节点
                if (viewModel.NodeType == 2)
                {
                    OpeCur.BLLSession.WorkFlowBLLBranchNode.Add(new MODEL.WorkFlowBLLBranchNode()
                    {
                        bwfnParent = nodeModel.wfnId,
                        bwfnResult = true,
                        bwfnNextNode = viewModel.TrueNode,
                        bwfnIsDel = false,
                        bwfnAddtinme = DateTime.Now
                    });
                    OpeCur.BLLSession.WorkFlowBLLBranchNode.Add(new MODEL.WorkFlowBLLBranchNode()
                    {
                        bwfnParent = nodeModel.wfnId,
                        bwfnResult = false,
                        bwfnNextNode = viewModel.FalseNode,
                        bwfnIsDel = false,
                        bwfnAddtinme = DateTime.Now
                    });
                    OpeCur.BLLSession.SaveChange();
                }
                #endregion
                return OpeCur.AjaxMsgOK();
            }
            return OpeCur.AjaxMsgNoValid();
        } 
        #endregion
    }
}
