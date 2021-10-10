using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.Respository
{
    public partial class DBSession:IRespository.IDBSession
    {
        /// <summary>
        /// 1.0 调用EF容器 批量 执行 sql语句
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            //从线程中获取EF容器对象
            return EFFatory.GetEFContext().SaveChanges();
        }
    }
}
