using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Configuration;
namespace ITCON_Paid_Project
{
    public partial class viewcategory1 : System.Web.UI.Page
    {
        int totalamount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);
            if (acesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }
            Session.Timeout = 60;


            if (acesslvl == 1)
            {
                Response.Redirect("showsheets.aspx");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            if (!IsPostBack)
            {
                ddl_campus.AppendDataBoundItems = true;
                string camp = "Select campus_Id,campusname from campus";
                SqlDataAdapter adpt = new SqlDataAdapter(camp, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Open();
                ddl_campus.DataSource = dt;
                ddl_campus.DataValueField = "campus_Id";
                ddl_campus.DataTextField = "campusname";
                ddl_campus.DataBind();
                con.Close();
            }

        }

        private void BindGrid(string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            string minutesheet;

            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            minutesheet = "SELECT amount,category_list FROM amount join categ_list_table on [dbo].[amount].categ=[dbo].[categ_list_table].Id where campus=" + ddl_campus.SelectedValue;

            SqlCommand cmd = new SqlCommand(minutesheet, con);

            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);
            ViewState["myViewState"] = sqldatab;

            DataView dv = sqldatab.AsDataView();

            girdview.DataSource = sqldatab;

            girdview.DataBind();

        }

        protected void ddl_campus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void girdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = string.Format("{0:c}", totalamount);
            }
        }
    }
}