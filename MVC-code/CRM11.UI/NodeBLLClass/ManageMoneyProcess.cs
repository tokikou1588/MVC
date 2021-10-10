using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM11.UI.NodeBLLClass
{
    public class ManageMoneyProcess:IBLLNodeProcess
    {
        public bool Process(object content)
        {
            int money = Convert.ToInt32(content);
            return money < 1000;
        }
    }
}