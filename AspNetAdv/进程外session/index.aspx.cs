using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 进程外session
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uinfo"] != null)
            {
                Response.Write("欢迎【" + Session["uinfo"] + "】登录");
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}