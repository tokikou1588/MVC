using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03利用过滤器实现url重写
{
    public class UrlRewrite : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            //由于页面是在第8个事件要创建对象，所以应该在1-7个事件的任何一个上面注册自己的方法来实现url的重写
            context.BeginRequest += context_BeginRequest;

        }

        /// <summary>
        /// 负责将 http://localhost:4803/index/1/abc 重写成asp.net能够正常解析的http://localhost:4803/index.aspx?id=1&name=abc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void context_BeginRequest(object sender, EventArgs e)
        {
            //1.0 初始正则表达式的对象，它只能匹配以 /index开头 带两个参数
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("/index/(.*)/(.*)");

            //2.0 获取浏览器请求上来原始url的路径  /index/1/abc
            string urlpath = HttpContext.Current.Request.RawUrl;  // /index/1/abc

            // 3.0 利用正则表达式来匹配当前的url 如果成功匹配，则将url重写asp.net能够正常解析url
            if (reg.IsMatch(urlpath))
            {
                urlpath = reg.Replace(urlpath, "/index.aspx?id=$1&name=$2");  //index.aspx?id=1&name=abc

                // 4.0 将重写后的urlpath写回
                HttpContext.Current.RewritePath(urlpath);
            }
                       
        }
    }
}