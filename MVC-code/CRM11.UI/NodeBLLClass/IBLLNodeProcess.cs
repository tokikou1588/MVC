using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.UI.NodeBLLClass
{
    /// <summary>
    /// 业务节点 处理接口
    /// </summary>
    public interface IBLLNodeProcess
    {
        /// <summary>
        /// 处理 申请单的内容，并返回结果
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool Process(object content);
    }
}
