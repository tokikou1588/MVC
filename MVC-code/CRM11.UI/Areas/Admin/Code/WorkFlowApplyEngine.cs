using CRM11.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace CRM11.UI.Areas.Admin.Code
{
    /// <summary>
    /// “工作流引擎”类
    /// </summary>
    public class WorkFlowApplyEngine
    {
        #region 操作上下文对象
        /// <summary>
        /// 操作上下文对象
        /// </summary>
        Helper.OperationContext CurOpe = Helper.OperationContext.Current;
        private IService.IServiceSession bllSession;
        #endregion

        public WorkFlowApplyEngine()
        {
            bllSession = CurOpe.BLLSession;
        }

        #region 新增申请单 +void AddApply(MODEL.WorkFlowApply apply, int operatorId)
        /// <summary>
        /// 新增申请单
        /// </summary>
        /// <param name="apply">申请单对象</param>
        /// <param name="operatorId">提交人id</param>
        public void AddApply(MODEL.WorkFlowApply apply,int wfId, int operatorId)
        {
            //1.设置申请单提交人
            apply.wfaUserId = operatorId;
            //2.设置申请单工作流id
            apply.wfaWFId = wfId;
            //3.设置 申请单 的节点id
            var workflowFirstNode = bllSession.WorkFlowNode.Where(o => o.wfnWFId == wfId, o => o.wfnOrder).FirstOrDefault();
            if (workflowFirstNode == null) throw new Exception("提交的申请单 所在的工作流 没有任何节点！");
            apply.wfaCurNodeId = workflowFirstNode.wfnId;
            //4.保存申请单
            bllSession.WorkFlowApply.Add(apply);
            bllSession.SaveChange();
            //5.保存申请单明细
            AddApplyDetails(apply, operatorId, "提交申请单:"+apply.wfaTitle, EnumHelper.ApplyOperation.Submit);
            //6.自动进入下个节点
            ChangeCurNode(apply);
            AddApplyDetails(apply, 0, "自动进入下个节点", EnumHelper.ApplyOperation.Pass);
        }
        #endregion

        #region 审批申请单 +ApproveApply(int applyId, int operatorId, string content, int applyOperation)
        /// <summary>
        /// 审批申请单 状态：1-运行中 2-已通过 3-已拒绝
        /// </summary>
        /// <param name="applyId">申请单id</param>
        /// <param name="operatorId">审批人id</param>
        /// <param name="content">审批意见</param>
        /// <param name="applyOperation">审批操作</param>
        public void ApproveApply(int applyId, int operatorId, string content, int applyOperation)
        {
            //01.查询要审批的申请单
            var apply = bllSession.WorkFlowApply.Single(a => a.wfaId == applyId);
            switch (applyOperation)
            {
                #region 1.拒绝
                case EnumHelper.ApplyOperation.Refuse: //4.拒绝
                    {
                        //1.1把申请单 状态改成 已拒绝
                        apply.wfaStatue = EnumHelper.ApplyStatue.REFUSED;
                        bllSession.SaveChange();
                        //1.2记录明细
                        AddApplyDetails(apply, operatorId, content, applyOperation);
                        break;
                    }
                #endregion
                #region 2.驳回
                case EnumHelper.ApplyOperation.Reject: //3.驳回
                    {
                        //2.1获取申请单 当前节点 的 上一个节点id
                        var prevNode = GetPrevNodeByCurNodeId(apply.wfaCurNodeId, apply.wfaWFId);
                        //2.1.1如果上一个节点不存在，则已经是第一个节点了
                        if (prevNode == null)
                        {
                        }
                        //2.1.2如果有上一个节点，则将申请单的 当前节点 改为 上一个节点
                        else {
                            apply.wfaCurNodeId = prevNode.wfnId;
                        }
                        bllSession.SaveChange();
                        AddApplyDetails(apply, operatorId, content, applyOperation);
                        break;
                    }
                #endregion
                #region 3.通过
                case EnumHelper.ApplyOperation.Pass: //2.通过
                    {
                        //查询 申请单 当前所在节点对象
                        var curNode = bllSession.WorkFlowNode.Single(o => o.wfnId == apply.wfaCurNodeId);
                        //3.0判断申请单当前所在节点是否为 业务节点(type=1是普通节点，type=2是业务节点)
                        if (curNode.wfnType == 2)
                        {
                            //a.获取申请单所在节点的业务类名
                            string strClassName = "CRM11.UI.NodeBLLClass." + curNode.wfnBLLClassName;
                            //b.获取当前程序集 里 业务类的类型
                            Type bllClassType = this.GetType().Assembly.GetType(strClassName);//Assembly.GetExecutingAssembly()
                            //c.创建 业务类对象
                            UI.NodeBLLClass.IBLLNodeProcess obj = Activator.CreateInstance(bllClassType) as UI.NodeBLLClass.IBLLNodeProcess;
                            //d.调用 业务对象的 业务处理方法，返回 处理结果 bool
                            bool processResult = obj.Process(apply.wfaContent);
                            //e.根据处理结果 和 申请单所在 的节点id 查询分支节点
                            var branch = bllSession.WorkFlowBLLBranchNode.Single(o => o.bwfnParent == apply.wfaCurNodeId && o.bwfnResult == processResult);

                            //*****记录当前的 通过操作
                            AddApplyDetails(apply, operatorId, content, applyOperation);

                            //f.将分支节点的id设置给 申请单 当前节点
                            apply.wfaCurNodeId = branch.bwfnNextNode;
                            //g.大家自己做：判断分支节点  是否为最后一个节点，如果是，则直接结束
                            bllSession.SaveChange();
                            //*****记录 进入分支节点
                            AddApplyDetails(apply, 0, "业务处理进入下个节点", applyOperation);
                        }
                        else
                        {
                            //3.1.1如果已经是最后一个节点了，则标记为 已通过
                            if (GetNextNodeByCurNodeId(apply.wfaCurNodeId, apply.wfaWFId) == null)
                            {
                                apply.wfaStatue = EnumHelper.ApplyStatue.PASSED;
                                bllSession.SaveChange();
                                AddApplyDetails(apply, operatorId, content, applyOperation);
                            }
                            //3.1.2如果不是最后一个节点，则把后一个节点的Id 设置给 申请单当前所在节点id
                            else
                            {
                                ChangeCurNode(apply);
                                AddApplyDetails(apply, operatorId, content, applyOperation);
                            }
                        }
                        break;
                    } 
                #endregion
            }
        }
        #endregion

        #region 改变申请单 所在节点（将申请单 自动 流入所处工作流的下一个节点） -void ChangeCurNode(MODEL.WorkFlowApply apply)
        /// <summary>
        /// 改变申请单 所在节点（将申请单 自动 流入所处工作流的下一个节点）
        /// </summary>
        /// <param name="apply"></param>
        private void ChangeCurNode(MODEL.WorkFlowApply apply)
        {
            //1.获取下个节点
            var nextNode = GetNextNodeByCurNodeId(apply.wfaCurNodeId, apply.wfaWFId);
            if (nextNode != null)
            {
                //将申请单的 当前节点id 改成 下一个节点的id
                apply.wfaCurNodeId = nextNode.wfnId;
                bllSession.SaveChange();
            }
        }
        #endregion

        private MODEL.WorkFlowNode GetNextNodeByCurNodeId(int curNodeId,int wfId)
        {
            var curNode = bllSession.WorkFlowNode.Single(o => o.wfnId == curNodeId);
            return bllSession.WorkFlowNode.Where(o => o.wfnWFId == wfId && o.wfnOrder > curNode.wfnOrder, o => o.wfnOrder, true).FirstOrDefault();
        }

        private MODEL.WorkFlowNode GetPrevNodeByCurNodeId(int curNodeId,int wfId)
        {
            var curNode = bllSession.WorkFlowNode.Single(o => o.wfnId == curNodeId);
            return bllSession.WorkFlowNode.Where(o => o.wfnWFId == wfId && o.wfnOrder < curNode.wfnOrder, o => o.wfnOrder, false).FirstOrDefault();
        }


        #region 保存申请单操作明细 -void AddApplyDetails(MODEL.WorkFlowApply apply, int operatorId, string reason, ApplyOperation operation)
        /// <summary>
        /// 保存申请单操作明细
        /// </summary>
        /// <param name="apply">申请单</param>
        /// <param name="operatorId">操作人id</param>
        /// <param name="reason">操作原因</param>
        /// <param name="operation">操作类型</param>
        private void AddApplyDetails(MODEL.WorkFlowApply apply, int operatorId, string reason, int operation)
        {
            MODEL.WorkFlowApplyDetail detail = new MODEL.WorkFlowApplyDetail()
            {
                wfadApplyId = apply.wfaId,
                wfadUserId = operatorId,
                wfadCurNodeId = apply.wfaCurNodeId,
                wfadOperation = (short)operation,
                wfadContent = reason,
                wfadIsDel = false,
                wfadAddTime = DateTime.Now
            };
            //保存申请单明细
            bllSession.WorkFlowApplyDetail.Add(detail);
            bllSession.SaveChange();
        }
        #endregion
    }
}