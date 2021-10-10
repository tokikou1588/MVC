using System.Linq;
namespace CRM11.MODEL
{
    public partial class WorkFLow
    {
        /// <summary>
        /// 手写的 ToPOCO方法
        /// </summary>
        /// <param name="isSelf">没有任何意义，为了和T4模板生成的方法重载而已</param>
        /// <returns></returns>
        public WorkFLow ToPOCO(bool isSelf)
        {
            return new WorkFLow()
            {
                wfId = this.wfId,
                wfName = this.wfName,
                wfHtmlSrc = this.wfHtmlSrc,
                wfIsDel = this.wfIsDel,
                wfAddtime = this.wfAddtime,
                WorkFlowNode = this.WorkFlowNode.Select(node => node.ToPOCO()).OrderBy(o=>o.wfnOrder).ToList()
            };
        }
    }
}
