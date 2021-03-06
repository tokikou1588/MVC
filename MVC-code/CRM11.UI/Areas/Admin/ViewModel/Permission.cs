using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM11.UI.Areas.Admin.ViewModel
{
    /// <summary>
    /// 权限 视图模型
    /// </summary>
    public class Permission
    {
        public int perId { get; set; }

        [DisplayName("权限名称"),Required(ErrorMessage="不能空")]
        public string perName { get; set; }
        [DisplayName("父权限")]
        public int perParent { get; set; }
        [DisplayName("备注"), Required(ErrorMessage = "不能空")]
        public string perRemark { get; set; }
        [DisplayName("区域名"), Required(ErrorMessage = "不能空")]
        public string perAreaName { get; set; }
        [DisplayName("控制器名"), Required(ErrorMessage = "不能空")]
        public string perControllerName { get; set; }
        [DisplayName("Action方法名"), Required(ErrorMessage = "不能空")]
        public string perActionName { get; set; }
        [DisplayName("请求方式")]
        public short perFormMethod { get; set; }
        [DisplayName("操作类型")]
        public short perOperationType { get; set; }
        [DisplayName("按钮JS方法名")]
        public string perJsMethodName { get; set; }
        [DisplayName("是否为链接")]
        public bool perIsLink { get; set; }
        [DisplayName("是否显示")]
        public bool perIsShow { get; set; }
        [DisplayName("序号"), Required(ErrorMessage = "不能空")]
        public int perOrder { get; set; }
        [DisplayName("图标"), Required(ErrorMessage = "不能空")]
        public string perIco { get; set; }

        /// <summary>
        /// 将视图模型 转成 对应的实体模型
        /// </summary>
        /// <returns></returns>
        public CRM11.MODEL.Permission ToPOCO()
        {
            return new MODEL.Permission() {
                perId = this.perId,
                perParent = this.perParent,
                perName = this.perName,
                perRemark = this.perRemark,
                perAreaName = this.perAreaName,
                perControllerName = this.perControllerName,
                perActionName = this.perActionName,
                perFormMethod = this.perFormMethod,
                perOperationType = this.perOperationType,
                perJsMethodName = this.perJsMethodName,
                perIco = this.perIco,
                perIsLink = this.perIsLink,
                perOrder = this.perOrder,
                perIsShow = this.perIsShow,
                perIsDel = false,
                perAddTime = DateTime.Now
            };
        }

        ///// <summary>
        ///// 将 权限实体模型 转成 权限视图模型
        ///// </summary>
        ///// <param name="poco"></param>
        ///// <returns></returns>
        //public static ViewModel.Permission ToViewModel(MODEL.Permission poco)
        //{
        //    return new ViewModel.Permission() {
        //        perId = poco.perId,
        //        perParent = poco.perParent,
        //        perName = poco.perName,
        //        perRemark = poco.perRemark,
        //        perAreaName = poco.perAreaName,
        //        perControllerName = poco.perControllerName,
        //        perActionName = poco.perActionName,
        //        perFormMethod = poco.perFormMethod,
        //        perOperationType = poco.perOperationType,
        //        perJsMethodName = poco.perJsMethodName,
        //        perIco = poco.perIco,
        //        perIsLink = poco.perIsLink,
        //        perOrder = poco.perOrder,
        //        perIsShow = poco.perIsShow
        //    };
        //}
    }
}