using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace ABS_Project
{
    public partial class contactrequests : System.Web.UI.Page
    {
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {

            int accesslvl = Convert.ToInt32(Session["accesslvl"]);
            Session.Timeout = 60;

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl == 1 || accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btn_unreply_Click(object sender, EventArgs e)
        {

            query = "SELECT * FROM contact where replystatus=0";
            BindGrid(query, 0);
        }

        protected void btn_reply_Click(object sender, EventArgs e)
        {

            query = "SELECT * FROM contact where replystatus=1";
            int accesslvl = 1;
            BindGrid(query, accesslvl);

        }


        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private void BindGrid(string query, int accesslvl, string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            SqlCommand cmd = new SqlCommand(query, con);


            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);

            ViewState["myViewState"] = sqldatab;
            if (sortExpression != null)
            {

                DataView dv = sqldatab.AsDataView();
                this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                dv.Sort = sortExpression + " " + this.SortDirection;
                girdview.DataSource = dv;
            }
            else
            {

                girdview.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview.DataBind();

        }

        protected void girdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
            }
        }


        protected void girdview_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression, 0);

        }



        protected void girdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            girdview.PageIndex = e.NewPageIndex;
            this.BindGrid(null, 0);
        }

        protected void view_btn_Click(object sender, EventArgs e)
        {
            string reply = ((sender as LinkButton).CommandArgument);
            Response.Redirect("reply.aspx?email=" + reply);

        }

    }
}