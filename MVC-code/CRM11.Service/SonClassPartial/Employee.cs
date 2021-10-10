using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.Service
{
    public partial class Employee:IService.IEmployee
    {
        #region 1.0 根据用户id查询用户权限集合 +List<MODEL.Permission> GetUserPermission(int uid)
        /// <summary>
        /// 1.0 根据用户id查询用户权限集合
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public List<MODEL.Permission> GetUserPermission(int uid)
        {
            //一、查询角色权限
            //1.根据用户id查询 角色id 集合
            List<int> listRoleIds = base.DBSession.EmpRoleRelation.Where(o => o.erUId == uid).Select(o => o.erRId).ToList();
            //2.根据角色id查询 权限id 集合
            List<int> listPerIds = base.DBSession.RolePerRelationship.Where(o => listRoleIds.Contains(o.rprRoleId)).Select(o => o.rprPerId).ToList();
            //二、查询特殊权限id 集合
            List<int> listVipIds = base.DBSession.VipPermssion.Where(o => o.vpUId == uid).Select(o => o.vpPId).ToList();
            //三、合并 特权和 角色权限
            listVipIds.ForEach(vipPerId =>
            {
                //如果 特权 在 角色权限中不存在，则添加到 角色权限中
                if (!listPerIds.Contains(vipPerId))
                {
                    listPerIds.Add(vipPerId);
                }
            });
            //查询出所有的 权限
            return base.DBSession.Permission.Where(o => listPerIds.Contains(o.perId)).ToList().Select(o => o.ToPOCO()).OrderBy(o => o.perOrder).ToList();
        } 
        #endregion
    }
}
