using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM11.UI.Areas.Admin.ViewModel
{
    /// <summary>
    /// 为角色 分配 权限 视图模型
    /// </summary>
    public class SetRolePer
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID;
        /// <summary>
        /// 所有权限集合
        /// </summary>
        public List<MODEL.Permission> AllPers;
        /// <summary>
        /// 角色权限集合
        /// </summary>
        public List<MODEL.Permission> RolePers;
    }
}