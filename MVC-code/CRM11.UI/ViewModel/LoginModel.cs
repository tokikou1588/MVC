using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM11.UI.ViewModel
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginModel
    {
        [DisplayName("登录名"), Required(ErrorMessage = "登录名不能为空")]
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        [DisplayName("登录密码"), Required(ErrorMessage = "登录密码不能为空")]
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        [DisplayName("验证码"), Required(ErrorMessage = "验证码不能为空")]
        /// <summary>
        /// 验证码
        /// </summary>
        public string LoginCode { get; set; }

        /// <summary>
        /// 是否保存登陆状态（用Cookie）
        /// </summary>
        public bool IsKeepLogin { get; set; }
    }
}