using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03利用过滤器实现url重写
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            throw new Exception("自定义异常。。。。");
            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];

            int ap = int.Parse(Application["PV"].ToString());
            ap = ap + 1;
            Application["PV"] = ap.ToString();

            Response.Write("id = " + id + "   ,name=" + name + "  Application['PV'] =" + Application["PV"]);
        }
    }
}