using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 过滤器.Filters
{
    public class MyFirstModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("这是AuthenticateRequest 中的 过滤器输出的文本 <br />");
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("这是BeginRequest 中的 过滤器输出的文本 <br />");
        }
    }
}