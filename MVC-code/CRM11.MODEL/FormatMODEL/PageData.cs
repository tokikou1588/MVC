using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.MODEL.FormatMODEL
{
    /// <summary>
    /// 分页数据模型
    /// </summary>
    public class PageData<TEntity>
    {
        /// <summary>
        /// 总行数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        public List<TEntity> rows { get; set; }
    }
}
