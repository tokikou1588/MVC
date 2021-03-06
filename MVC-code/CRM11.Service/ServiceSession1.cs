
 //------------------------------------------------------------------------------
// <auto-generated>
// 业务仓储接口，作用：
// 1.调用数据仓储 SaveChanges 批量 执行 sql语句
// 2.方便通过 子接口属性直接 获取 对应业务子接口对象
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM11.Service
{
    using System;
    public partial class ServiceSession:CRM11.IService.IServiceSession
    {
    	CRM11.IService.IDepartment _Department;
        public CRM11.IService.IDepartment Department 
        { 
        	get
        	{
                if (_Department == null)
                    _Department = new CRM11.Service.Department();
                return _Department;
        	}
        }
    
    	CRM11.IService.IEmployee _Employee;
        public CRM11.IService.IEmployee Employee 
        { 
        	get
        	{
                if (_Employee == null)
                    _Employee = new CRM11.Service.Employee();
                return _Employee;
        	}
        }
    
    	CRM11.IService.IEmpRoleRelation _EmpRoleRelation;
        public CRM11.IService.IEmpRoleRelation EmpRoleRelation 
        { 
        	get
        	{
                if (_EmpRoleRelation == null)
                    _EmpRoleRelation = new CRM11.Service.EmpRoleRelation();
                return _EmpRoleRelation;
        	}
        }
    
    	CRM11.IService.IPermission _Permission;
        public CRM11.IService.IPermission Permission 
        { 
        	get
        	{
                if (_Permission == null)
                    _Permission = new CRM11.Service.Permission();
                return _Permission;
        	}
        }
    
    	CRM11.IService.IRole _Role;
        public CRM11.IService.IRole Role 
        { 
        	get
        	{
                if (_Role == null)
                    _Role = new CRM11.Service.Role();
                return _Role;
        	}
        }
    
    	CRM11.IService.IRolePerRelationship _RolePerRelationship;
        public CRM11.IService.IRolePerRelationship RolePerRelationship 
        { 
        	get
        	{
                if (_RolePerRelationship == null)
                    _RolePerRelationship = new CRM11.Service.RolePerRelationship();
                return _RolePerRelationship;
        	}
        }
    
    	CRM11.IService.IVipPermssion _VipPermssion;
        public CRM11.IService.IVipPermssion VipPermssion 
        { 
        	get
        	{
                if (_VipPermssion == null)
                    _VipPermssion = new CRM11.Service.VipPermssion();
                return _VipPermssion;
        	}
        }
    
    	CRM11.IService.IWorkFLow _WorkFLow;
        public CRM11.IService.IWorkFLow WorkFLow 
        { 
        	get
        	{
                if (_WorkFLow == null)
                    _WorkFLow = new CRM11.Service.WorkFLow();
                return _WorkFLow;
        	}
        }
    
    	CRM11.IService.IWorkFlowApply _WorkFlowApply;
        public CRM11.IService.IWorkFlowApply WorkFlowApply 
        { 
        	get
        	{
                if (_WorkFlowApply == null)
                    _WorkFlowApply = new CRM11.Service.WorkFlowApply();
                return _WorkFlowApply;
        	}
        }
    
    	CRM11.IService.IWorkFlowApplyDetail _WorkFlowApplyDetail;
        public CRM11.IService.IWorkFlowApplyDetail WorkFlowApplyDetail 
        { 
        	get
        	{
                if (_WorkFlowApplyDetail == null)
                    _WorkFlowApplyDetail = new CRM11.Service.WorkFlowApplyDetail();
                return _WorkFlowApplyDetail;
        	}
        }
    
    	CRM11.IService.IWorkFlowNode _WorkFlowNode;
        public CRM11.IService.IWorkFlowNode WorkFlowNode 
        { 
        	get
        	{
                if (_WorkFlowNode == null)
                    _WorkFlowNode = new CRM11.Service.WorkFlowNode();
                return _WorkFlowNode;
        	}
        }
    
    	CRM11.IService.IWorkFlowNodeRole _WorkFlowNodeRole;
        public CRM11.IService.IWorkFlowNodeRole WorkFlowNodeRole 
        { 
        	get
        	{
                if (_WorkFlowNodeRole == null)
                    _WorkFlowNodeRole = new CRM11.Service.WorkFlowNodeRole();
                return _WorkFlowNodeRole;
        	}
        }
    
    	CRM11.IService.IWorkFlowBLLBranchNode _WorkFlowBLLBranchNode;
        public CRM11.IService.IWorkFlowBLLBranchNode WorkFlowBLLBranchNode 
        { 
        	get
        	{
                if (_WorkFlowBLLBranchNode == null)
                    _WorkFlowBLLBranchNode = new CRM11.Service.WorkFlowBLLBranchNode();
                return _WorkFlowBLLBranchNode;
        	}
        }
    
    }
}
