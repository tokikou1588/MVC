using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.Service
{
    public partial class WorkFlowNode:IService.IWorkFlowNode
    {
        /// <summary>
        /// 1.0 将 传入节点 的 后面的 节点的序号+1，同时，返回 传入节点 序号+1
        /// </summary>
        /// <param name="perNode">传入节点</param>
        /// <returns></returns>
        public int ReSort(MODEL.WorkFlowNode perNode)
        {
            //1.获取当前节点所在工作流 中 当前节点之后的 所有其他节点
            var nodeBehindList = base.iBaseDal.Where(o => o.wfnWFId == perNode.wfnWFId && o.wfnOrder > perNode.wfnOrder).ToList();
            //2.将 后面节点 序号都+1
            nodeBehindList.ForEach(o => o.wfnOrder++);
            base.DBSession.SaveChanges();
            //3.返回 当前节点的序号 +1 给新节点使用
            return perNode.wfnOrder + 1;
        }

        /// <summary>
        /// 1.1 将工作流中所有节点序号 +1
        /// </summary>
        /// <param name="wfId">工作流id</param>
        /// <returns></returns>
        public int ReSortAll(int wfId)
        {
            //1.获取当前节点所在工作流 中 当前节点之后的 所有其他节点
            var nodeBehindList = base.iBaseDal.Where(o => o.wfnWFId == wfId).ToList();
            //2.将 后面节点 序号都+1
            nodeBehindList.ForEach(o => o.wfnOrder++);
            base.DBSession.SaveChanges();
            //3.返回 序号 1 给新节点使用
            return 1;
        }
    }
}
