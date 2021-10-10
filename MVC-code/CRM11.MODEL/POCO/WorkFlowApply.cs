using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.MODEL
{
    public partial class WorkFlowApply
    {
        /// <summary>
        /// 状态名字
        /// </summary>
        public string StatuName { get; set; }
        /// <summary>
        /// 优先级名字
        /// </summary>
        public string PriorityName { get; set; }

        public WorkFlowApply ToPOCO(bool isSelf)
        {
            return new WorkFlowApply()
            {
                wfaId = this.wfaId,
                wfaWFId = this.wfaWFId,
                wfaCurNodeId = this.wfaCurNodeId,
                wfaUserId = this.wfaUserId,
                wfaTitle = this.wfaTitle,
                wfaContent = this.wfaContent,
                wfaRemark = this.wfaRemark,
                wfaPriority = this.wfaPriority,
                wfaStatue = this.wfaStatue,
                wfaAddTime = this.wfaAddTime,
                wfaIsDel = this.wfaIsDel,

                WorkFLow=this.WorkFLow.ToPOCO(),
                WorkFlowNode=this.WorkFlowNode.ToPOCO()
            };
        }
    }
}