using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.MODEL
{
    public partial class Employee
    {
        /// <summary>
        /// 手写的 ToPOCO方法
        /// </summary>
        /// <param name="isSelf">没有任何意义，为了和T4模板生成的方法重载而已</param>
        /// <returns></returns>
        public Employee ToPOCO(bool isSelf)
        {
            return new Employee()
            {
                empId = this.empId,
                empDepId = this.empDepId,
                empCnName = this.empCnName,
                empLoginName = this.empLoginName,
                empLoginPwd = this.empLoginPwd,
                empSex = this.empSex,
                empAge = this.empAge,
                empCellPhone = this.empCellPhone,
                empPhone = this.empPhone,
                empAddress = this.empAddress,
                empIsDel = this.empIsDel,
                empAddTime = this.empAddTime,
                Department = this.Department.ToPOCO()
            };
        }
    }
}
