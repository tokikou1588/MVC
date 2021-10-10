using CRM11.UI.Filters;
using System.Web;
using System.Web.Mvc;

namespace CRM11.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //注册全局 权限检查 过滤器
            filters.Add(new Filters.CheckPermissionAttribute());
            //注册 全局 异常 过滤器
            filters.Add(new GlobalExceptionAttribute());
        }
    }
}