using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM11.UI.Areas.Admin.ViewModel
{
    /// <summary>
    /// 工作流 视图模型
    /// </summary>
    public class AddSonNode
    {
        public int wfId { get; set; }
        [DisplayName("节点名称"), Required(ErrorMessage = "不能空")]
        public string NodeName { get; set; }
        [DisplayName("上个节点")]
        public int PrevNodeId { get; set; }
        [DisplayName("业务类型")]
        public int NodeType { get; set; }
        [DisplayName("业务类名")]
        public string BLLClassName { get; set; }

        [DisplayName("Ture分支节点")]
        public int TrueNode { get; set; }
        [DisplayName("False分支节点")]
        public int FalseNode { get; set; }


        /// <summary>
        /// 将当前视图模型对象 转成 实体模型
        /// </summary>
        /// <returns></returns>
        public MODEL.WorkFlowNode ToModel()
        {
            return new MODEL.WorkFlowNode()
            {
                wfnName = this.NodeName,
                wfnPrevNodeId = this.PrevNodeId,
                wfnType = (short)this.NodeType,
                wfnBLLClassName = this.BLLClassName,
                wfnIsDel = false,
                wfnAddtime = DateTime.Now
            };
        }
    }
}