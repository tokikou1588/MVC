//------------------------------------------------------------------------------
// <auto-generated>
// Author:JamesZou QQ:576948819
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM11.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkFlowNode:BaseService<MODEL.WorkFlowNode>,CRM11.IService.IWorkFlowNode
    {
    		//创建 对应的数据子类对象，因为 当前业务子类中 可能要访问 数据子类中的 增删改查(CRUD)之外的方法
    		IRespository.IWorkFlowNode iSonDal = null;
            public override void SetIDAL()
            {
                iSonDal = base.DBSession.WorkFlowNode;
    			base.iBaseDal = iSonDal;
            }
    }
}
