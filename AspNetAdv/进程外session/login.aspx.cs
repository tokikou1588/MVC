using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 进程外session
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin" && txtpwd.Text == "123")
            {
                Session["uinfo"] = txtusername.Text;
                Response.Redirect("/index.aspx");
            }
            else
            {
                base.ClientScript.RegisterStartupScript(this.GetType(), "tip", "alert('用户名或者密码不正常')", true);
            }
        }
    }
}