using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM11.UI.Areas.Admin.ViewModel
{
    /// <summary>
    /// 工作流 视图模型
    /// </summary>
    public class WorkFlow
    {
        public int wfId { get; set; }
        [DisplayName("工作流名称"), Required(ErrorMessage = "不能空")]
        public string wfName { get; set; }
        [DisplayName("表单模板路径")]
        public string wfHtmlSrc { get; set; }


        /// <summary>
        /// 将当前视图模型对象 转成 实体模型
        /// </summary>
        /// <returns></returns>
        public MODEL.WorkFLow ToModel()
        {
            return new MODEL.WorkFLow()
            {
                wfId = this.wfId,
                wfName = this.wfName,
                wfHtmlSrc = this.wfHtmlSrc,
                wfIsDel = false,
                wfAddtime = DateTime.Now
            };
        }
    }
}