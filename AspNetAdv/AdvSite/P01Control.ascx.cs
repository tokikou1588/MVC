using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvSite
{
    using System.Data.SqlClient;
    using System.Data;

    public partial class P01Control1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();
            }
        }

        public string GroupName
        {
            get
            {
                if (dpGroupInfo.Items.Count > 0)
                {
                    return dpGroupInfo.SelectedItem.Text;
                }
                return "";
            }
        }

        public string GroupValue
        {
            get
            {
                if (dpGroupInfo.Items.Count > 0)
                {
                    return dpGroupInfo.SelectedValue;
                }
                return "";
            }
        }

        public string ContactName
        {
            get
            {
                if (dpContactInfo.Items.Count > 0)
                {
                    return dpContactInfo.SelectedItem.Text;
                }
                return "";
            }
        }

        private void InitControls()
        {
            dpGroupInfo.DataSource = GetList("GroupInfo", "");
            dpGroupInfo.DataTextField = "GroupName";
            dpGroupInfo.DataValueField = "GroupId";
            dpGroupInfo.DataBind();
        }

        protected void dpGroupInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupid = dpGroupInfo.SelectedValue;
            dpContactInfo.DataSource = GetList("ContactInfo", " where GroupId = " + groupid);
            dpContactInfo.DataBind();
        }

        private DataTable GetList(string tablename, string where)
        {
            using (SqlConnection conn = new SqlConnection("server=.;database=phonebook;uid=sa;pwd=master"))
            {
                conn.Open();
                string sql = "select * from " + tablename + where;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable d = new DataTable();
                da.Fill(d);

                return d;
            }
        }
    }
}