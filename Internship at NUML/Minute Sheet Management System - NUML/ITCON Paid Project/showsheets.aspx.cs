using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Windows;

namespace ITCON_Paid_Project
{
    public partial class showsheets1 : System.Web.UI.Page
    {
        public int count;
        int totalamount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("login_page.aspx");
            }
            Session.Timeout = 60;

            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

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
            string minutesheet;

            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            if (acesslvl == 1)
            {
                minutesheet = "SELECT minute_sheet.letter_no,minute_sheet.date,minute_sheet.title,minute_sheet.title,campus.campusname,minute_sheet.app_date,minute_sheet.amount,minute_sheet.image,approvedby.approver FROM minute_sheet JOIN campus ON minute_sheet.campus = campus.campus_Id JOIN approvedby ON minute_sheet.approvedby = approvedby.Id WHERE minute_sheet.campus='" + Session["campus"] + "'";
            }

            else
            {
                minutesheet = "SELECT minute_sheet.letter_no,minute_sheet.date,minute_sheet.title,minute_sheet.title,campus.campusname,minute_sheet.app_date,minute_sheet.amount,minute_sheet.image,approvedby.approver FROM minute_sheet JOIN campus ON minute_sheet.campus = campus.campus_Id JOIN approvedby ON minute_sheet.approvedby = approvedby.Id";
            }

            SqlCommand cmd = new SqlCommand(minutesheet, con);

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

                    if (row["letter_no"].ToString().ToLower().Contains(searchTerm) || row["title"].ToString().ToLower().Contains(searchTerm) || row["date"].ToString().ToLower().Contains(searchTerm) || row["title"].ToString().ToLower().Contains(searchTerm) || row["campusname"].ToString().ToLower().Contains(searchTerm) || row["amount"].ToString().ToLower().Contains(searchTerm) || row["approver"].ToString().ToLower().Contains(searchTerm) || row["app_date"].ToString().ToLower().Contains(searchTerm))
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

                totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "amount"));
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

        protected void view_btn_Click(object sender, EventArgs e)
        {
            string letterno = Convert.ToString((sender as LinkButton).CommandArgument);

            Response.Redirect("viewsheet.aspx?letter_no=" + letterno);

        }

        protected void del_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString; con.Open();

           

            string letter_no = Convert.ToString((sender as LinkButton).CommandArgument);
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            string qry = "select * FROM minute_sheet_data WHERE letter_no='" + letter_no + "'";
            SqlCommand cmd2 = new SqlCommand(qry, con);
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                count++;
                break;
            }
            reader.Close();

            if(count == 0)
            {

          
            
            {

            
            if (acesslvl == 5)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Warning', 'Only Users Can Edit or Delete! Admin don't have rights.', 'warning')", true);
            }       
            else
            {
              
                string minutesheet = "DELETE FROM minute_sheet WHERE letter_no='" + letter_no +"'";
                string minutesheet1 = "DELETE FROM minute_sheet_data WHERE letter_no='" + letter_no +"'";
                SqlCommand cmd1 = new SqlCommand(minutesheet1, con);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand(minutesheet, con);
                cmd.ExecuteNonQuery();
                con.Close();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Congratulation', 'Deleted Successfully:)', 'success')", true);

                    BindGrid();
            }
            }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Warning', 'Please Delete Sub Minute Sheets First :)', 'warning')", true);

            }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string minutesheet = "SELECT minute_sheet.letter_no,minute_sheet.date,minute_sheet.title,minute_sheet.title,campus.campusname,minute_sheet.app_date,minute_sheet.amount,minute_sheet.image,approvedby.approver FROM minute_sheet JOIN campus ON minute_sheet.campus = campus.campus_Id JOIN approvedby ON minute_sheet.approvedby = approvedby.Id where app_date between '" + tb_fdate.Text + "' and '" + tb_todate.Text + "'";
            SqlCommand cmd = new SqlCommand(minutesheet, con);
            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();

            sqladp.Fill(sqldatab);
            girdview.DataSource = sqldatab;
            girdview.DataBind();
        }

    }
}