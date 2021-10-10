using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.IService
{
     public partial interface IWorkFlowNode
    {
         /// <summary>
        /// 1.0 将 传入节点 的 后面的 节点的序号+1，同时，返回 传入节点 序号+1
         /// </summary>
        /// <param name="perNode">传入节点</param>
         /// <returns></returns>
         int ReSort(MODEL.WorkFlowNode perNode);

         /// <summary>
         /// 1.1 将工作流中所有节点序号 +1
         /// </summary>
         /// <param name="wfId">工作流id</param>
         /// <returns></returns>
         int ReSortAll(int wfId);
    }
}
