using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry_active = "SELECT count(*) from Accounts where Status='Active'";
                SqlCommand cmd = new SqlCommand(qry_active, con);

                int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

                string benii = "Active Accounts : " + RecordCount.ToString();
                btn_active.Text = benii;

                string qry_inactive = "SELECT count(*) from Accounts where Status='InActive'";
                SqlCommand cmd_vol = new SqlCommand(qry_inactive, con);

                int RecordCount_ = Convert.ToInt32(cmd_vol.ExecuteScalar());

                string benii1 = "InActive Accounts : " + RecordCount_.ToString();
                btn_inactive.Text = benii1;
   
            }
        }
    

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show-Accounts.aspx");
        }
    }
}