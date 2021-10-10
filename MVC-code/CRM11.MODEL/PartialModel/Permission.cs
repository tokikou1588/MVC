using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.MODEL
{
    public partial class Permission
    {
        /// <summary>
        /// 将 权限 转成 节点对象
        /// </summary>
        /// <returns></returns>
        public FormatMODEL.TreeNode ToNode()
        {
            return new FormatMODEL.TreeNode()
            {
                id = this.perId,
                text = this.perName,
                attributes = new
                {
                    url = "/" + this.perAreaName + "/" + this.perControllerName + "/" + this.perActionName,
                    isLink=this.perIsLink
                },
                @checked = false,
                state = "open"
            };
        }


    }
}
