using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.IRespository
{
    /// <summary>
    /// 数据仓储接口，作用：
    /// 1.调用EF容器 批量 执行 sql语句
    /// 2.方便通过 子接口属性直接 获取 对应数据表的操作接口对象
    /// </summary>
    public partial interface IDBSession
    {
        /// <summary>
        /// 1.0 调用EF容器 批量 执行 sql语句
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
