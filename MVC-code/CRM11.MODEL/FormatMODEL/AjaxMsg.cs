using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM11.MODEL.FormatMODEL
{
    /// <summary>
    /// 返回给Ajax请求的 数据格式 模型
    /// </summary>
    public class AjaxMsg
    {
        public AjaxMsgStatu Status { get; set; }
        public string Msg { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// 因为easyUI的 datagrid组件 在对 非法请求时返回消息 对象 里 必须包含一个 rows属性
        /// </summary>
        public string rows
        {
            get
            {
                return "";
            }
        }
    }

    /// <summary>
    /// Ajax消息状态的 类型
    /// </summary>
    public enum AjaxMsgStatu
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Ok = 1,
        /// <summary>
        /// 操作失败
        /// </summary>
        NoOk = 2,
        /// <summary>
        /// 尚未登陆
        /// </summary>
        NoLogin = 3,
        /// <summary>
        /// 没有访问权限
        /// </summary>
        NoPermission = 4,
        /// <summary>
        /// 异常
        /// </summary>
        Error = 5
    }
}
