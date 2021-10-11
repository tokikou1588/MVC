using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 过滤器
{
    /// <summary>
    /// index1 的摘要说明
    /// </summary>
    public class index1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}