using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM11.UI.NodeBLLClass
{
    /// <summary>
    /// 组长审批 业务类名
    /// </summary>
    public class GroupMoneyProcess : IBLLNodeProcess
    {

        public bool Process(object content)
        {
            int money = Convert.ToInt32(content);
            return money < 100;
        }
    }
}