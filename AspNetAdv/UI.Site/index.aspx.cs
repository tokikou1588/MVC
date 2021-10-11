using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Site
{
    using PB.BusinessLogicLayer;

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GridView1.DataSource = GroupInfo_BLLSub.Get_GroupInfoAll();
                GridView1.DataBind();
            }
        }
    }
}