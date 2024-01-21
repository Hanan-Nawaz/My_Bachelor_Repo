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
    public partial class seehistory1 : System.Web.UI.Page
    {
        int totalamount = 0;
        string his;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;

            if (Session["Username"] == null)
            {
                Response.Redirect("login_page.aspx");
            }

            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);
            if (acesslvl == 1)
            {
                Response.Redirect("showsheets.aspx");
            }

            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private void BindGrid(string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;



            
                his = "SELECT * FROM history JOIN categ_list_table ON history.category = categ_list_table.Id JOIN campus ON history.campus = campus.campus_Id JOIN user_table ON history.aprover = user_table.Id; ";
            

            SqlCommand cmd = new SqlCommand(his, con);

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
            totalamount = 0;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower();


            if (searchTerm.Length >= 3)
            {

                if (ViewState["myViewState"] == null)
                    return;


                DataTable dt = ViewState["myViewState"] as DataTable;


                DataTable dtNew = dt.Clone();


                foreach (DataRow row in dt.Rows)
                {

                    if (row["adding_amount"].ToString().ToLower().Contains(searchTerm) || row["category_list"].ToString().ToLower().Contains(searchTerm) || row["campusname"].ToString().ToLower().Contains(searchTerm) || row["exist_amount"].ToString().ToLower().Contains(searchTerm) || row["new_total"].ToString().ToLower().Contains(searchTerm) || row["name"].ToString().ToLower().Contains(searchTerm) || row["date"].ToString().ToLower().Contains(searchTerm))
                    {

                        dtNew.Rows.Add(row.ItemArray);
                    }
                }


                girdview.DataSource = dtNew;
                girdview.DataBind();
            }
        }

        protected void girdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "new_total"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = string.Format("{0:c}", "Total : " + totalamount);
            }
        }


        protected void girdview_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);

        }



        protected void girdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            girdview.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string his = "SELECT * FROM history JOIN categ_list_table ON history.category = categ_list_table.Id JOIN campus ON history.campus = campus.campus_Id JOIN user_table ON history.aprover = user_table.Id where date between '" + tb_fdate.Text + "' and '" + tb_todate.Text + "'";
            SqlCommand cmd = new SqlCommand(his, con);
            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();

            sqladp.Fill(sqldatab);
            girdview.DataSource = sqldatab;
            girdview.DataBind();
        }
    }
}