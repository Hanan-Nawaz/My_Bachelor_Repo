using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class DeleteContent : System.Web.UI.Page
    {
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["accesslvl"]);
            Session.Timeout = 60;

            if (accesslvl == 6)
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            BindGrid();
        }

        private void BindGrid(string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            string minutesheet = "SELECT * FROM Content";

            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            SqlCommand cmd = new SqlCommand(minutesheet, con);

            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);
            ViewState["myViewState"] = sqldatab;
            
            {

                girdview1.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview1.DataBind();

        }

       



        protected void girdview1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            girdview1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument.ToString());
            
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString; con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Content where Id=" + id, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}