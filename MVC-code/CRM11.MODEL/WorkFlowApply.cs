//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM11.MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkFlowApply
    {
        public WorkFlowApply()
        {
            this.WorkFlowApplyDetail = new HashSet<WorkFlowApplyDetail>();
        }
    
        public int wfaId { get; set; }
        public int wfaWFId { get; set; }
        public int wfaCurNodeId { get; set; }
        public int wfaUserId { get; set; }
        public string wfaTitle { get; set; }
        public string wfaContent { get; set; }
        public string wfaRemark { get; set; }
        public short wfaPriority { get; set; }
        public short wfaStatue { get; set; }
        public System.DateTime wfaAddTime { get; set; }
        public bool wfaIsDel { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual WorkFLow WorkFLow { get; set; }
        public virtual WorkFlowNode WorkFlowNode { get; set; }
        public virtual ICollection<WorkFlowApplyDetail> WorkFlowApplyDetail { get; set; }
    }
}
