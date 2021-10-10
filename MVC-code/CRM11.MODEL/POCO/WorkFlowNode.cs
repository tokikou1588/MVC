using System.Collections.Generic;
using System.Linq;
namespace CRM11.MODEL
{
    public partial class WorkFlowNode
    {
        /// <summary>
        /// 可以审批 节点 的 角色集合
        /// </summary>
        public List<MODEL.Role> Roles { get; set; }

        /// <summary>
        /// 手写的 ToPOCO方法
        /// </summary>
        /// <param name="isSelf">没有任何意义，为了和T4模板生成的方法重载而已</param>
        /// <returns></returns>
        public WorkFlowNode ToPOCO(bool isSelf)
        {
            return new WorkFlowNode()
            {
                wfnId = this.wfnId,
                wfnWFId = this.wfnWFId,
                wfnName = this.wfnName,
                wfnPrevNodeId = this.wfnPrevNodeId,
                wfnNextNodeId = this.wfnNextNodeId,
                wfnType = this.wfnType,
                wfnBLLClassName = this.wfnBLLClassName,
                wfnOrder = this.wfnOrder,
                wfnIsDel = this.wfnIsDel,
                wfnAddtime = this.wfnAddtime,

                //从 工作流节点的EF代理对象 的 Role属性中 获取 节点的 所有的角色
                Roles = this.WorkFlowNodeRole.Select(o => o.Role.ToPOCO()).ToList()
            };
        }
    }
}