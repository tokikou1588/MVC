using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.Service
{
    public partial class Department : CRM11.IService.IDepartment
    {
        public void A()
        {
            DBSession.Department.Add(null);
            DBSession.Department.Add(null);
            DBSession.Employee.Add(null);
            DBSession.Permission.Add(null);
            //如果 new 一个数据子类对象，其中 就已经包含了 数据父类的成员了！
            this.iSonDal.A();
        }
    }
}
