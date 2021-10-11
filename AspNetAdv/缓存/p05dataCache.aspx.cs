using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 缓存
{
    public partial class p05dataCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 1.0 绝对过期时间使缓存失效
            //object obj = HttpRuntime.Cache["time"];
            //if (obj == null)
            //{
            //    obj = DateTime.Now;
            //    HttpRuntime.Cache.Add(
            //        "time"  //缓存的 key
            //        , obj,  // 缓存的值
            //        null  // 缓存依赖项（文件依赖和数据库依赖）
            //        , DateTime.Now.AddSeconds(10)   //将缓存设置成当前时间10秒以后过期（绝对过期时间）
            //        , System.Web.Caching.Cache.NoSlidingExpiration  // 不使用相对过期时间( 因为设置了过期时间 所以此处一定是设置NoSlidingExpiration)
            //        , System.Web.Caching.CacheItemPriority.Normal  // 表示缓存过期以后被asp.net处理机制移除的优先级别,越高的将会被最后移除，越低的则优先被移除

            //        , null  // 当前此缓存被移时触发的回调函数
            //        );
            //}

            //Response.Write(obj);
            #endregion

            #region 2.0 相对过期时间使缓存失效

            object obj = HttpRuntime.Cache["time1"];
            if (obj == null)
            {
                obj = DateTime.Now;
                HttpRuntime.Cache.Add(
                    "time1"  //缓存的 key
                    , obj  // 缓存的值     
                    ,null
                    , System.Web.Caching.Cache.NoAbsoluteExpiration   //不设置绝对过期时间
                    , new TimeSpan(0, 0, 10)  // 将当前缓存过期设置为相对10以后
                    , System.Web.Caching.CacheItemPriority.Normal  // 表示缓存过期以后被asp.net处理机制移除的优先级别,越高的将会被最后移除，越低的则优先被移除

                    , null  // 当前此缓存被移时触发的回调函数
                    );
            }

            Response.Write(obj);

            #endregion
        }
    }
}