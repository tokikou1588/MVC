using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace _03利用过滤器实现url重写
{
    /// <summary>
    /// HttpApplication 对象创建以后是会存在 【应用程序池】，下次浏览器再请求的时候，就会去应用程序池
    /// 中获取，如果则新创建
    /// 如果站点中有Global.asax文件，则在asp.net处理机制中实例化的是Global 的对象
    /// </summary>
    public class Global : System.Web.HttpApplication
    {

        #region 1.0 应用程序启动和停止的两个方法

        /// <summary>
        /// 在IIS启动后第一次请求被触发，以后就不会触发了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            // 开启网站的一个子线程
            //System.Threading.Thread th = new System.Threading.Thread();

            //存储的值在整个应用程序中任何动态页面中都可以访问到，意味着在应用程序整个生命周期中只有一个值
            Application["PV"] = 100;
        }

        /// <summary>
        /// 当IIS停止或者重启后会触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {
            //当IIS停止以后，手动停止在Application_Start 中开启的线程
        }

        #endregion

        #region 2.0 微软默认在管道事件上注册好的方法，程序员可以按照自己的逻辑正常使用而不需要配置web.config
        /// <summary>
        /// asp.net默认将Application_BeginRequest 注册到了 第一个管道事件BeginRequest上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("这是Application_BeginRequest 输出的内容");
            // 可以实现url的重写
        }

        /// <summary>
        /// asp.net默认将Application_AuthenticateRequest 注册到了 第二个管道事件AuthenticateRequest上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        #endregion

        #region 3.0 统一捕获当前站点中没有被try{}catch{}的异常错误

        protected void Application_Error(object sender, EventArgs e)
        {
            //1.0 获取当前http请求上下文中的最后一个错误实体
            Exception exp = HttpContext.Current.Server.GetLastError();
            //2.0 获取当前exp中的内部异常
            Exception innerExp = exp.InnerException;

            //3.0 将日志信息写入文件或者数据库
            //此写法不推荐在以后的项目中使用，一定要使用公司给你们的日志模块
            System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("/log.txt"), innerExp.ToString() + "\r\n");

        }

        #endregion


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }
    }
}