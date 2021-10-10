using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.IService
{
    public partial interface IEmployee
    {
        /// <summary>
        /// 1.0 根据用户id查询用户权限集合
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        List<MODEL.Permission> GetUserPermission(int uid);
    }
}
