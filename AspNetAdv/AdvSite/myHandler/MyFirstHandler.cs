using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvSite.myHandler
{
    /// <summary>
    /// 一般处理程序类文件
    /// </summary>
    public class MyFirstHandler : IHttpHandler
    {
        int cout = 0;
        /// <summary>
        /// 如果 返回false,表示每次浏览器的请求都会新创建MyFirstHandler 类的对象  返回true,表示每次浏览器的请求都重用第一次创建的MyFirstHandler 类的对象
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            cout++;
            context.Response.Write("程序员可以自由编写逻辑代码 cout=" + cout);
        }
    }
}