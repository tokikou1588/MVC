using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 缓存
{
    public partial class P07DataBaseDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = HttpRuntime.Cache["time"];
            if (obj == null)
            {
                //1.0 实例化依赖的对象实例                
                System.Web.Caching.SqlCacheDependency dep = new System.Web.Caching.SqlCacheDependency("cachedbtest1", "test1");

                //将obj 设置为当前时间，同时存入缓存中
                obj = DateTime.Now;
                HttpRuntime.Cache.Add("time"
                    , obj
                    , dep
                    , System.Web.Caching.Cache.NoAbsoluteExpiration
                    , System.Web.Caching.Cache.NoSlidingExpiration
                    , System.Web.Caching.CacheItemPriority.Normal
                     , null
                    );
            }

            Response.Write(obj);
        }
    }
}