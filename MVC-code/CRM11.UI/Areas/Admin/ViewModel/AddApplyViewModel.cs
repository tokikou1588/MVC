using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM11.UI.Areas.Admin.ViewModel
{
    /// <summary>
    /// 新增申请单视图模型
    /// </summary>
    public class AddApplyViewModel
    {
        [DisplayName("所属工作流id")]
        public int wfaWFId { get; set; }

        [DisplayName("申请单标题"),Required(ErrorMessage="不能空")]
        public string wfaTitle { get; set; }
        [DisplayName("申请内容"), Required(ErrorMessage = "不能空")]
        public string wfaContent { get; set; }
        [DisplayName("申请理由"), Required(ErrorMessage = "不能空")]
        public string wfaRemark { get; set; }

        [DisplayName("申请优先级")]
        public short wfaPriority { get; set; }

        public MODEL.WorkFlowApply ToModel()
        {
            return new MODEL.WorkFlowApply()
            {
                wfaWFId = this.wfaWFId,
                wfaTitle = this.wfaTitle,
                wfaContent = this.wfaContent,
                wfaRemark = this.wfaRemark,
                wfaPriority = this.wfaPriority,
                wfaIsDel = false,
                wfaAddTime = DateTime.Now,
                wfaStatue = (short)Helper.EnumHelper.ApplyStatue.RUNING
            };
        }
    }
}