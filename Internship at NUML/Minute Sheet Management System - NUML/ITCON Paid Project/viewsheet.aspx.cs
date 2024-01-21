using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNetCore.Authorization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace ITCON_Paid_Project
{
    public partial class viewsheet1 : System.Web.UI.Page
    {
        int int_letterno = 0;
        string campus = "";
        string approver = "";
        int totalamount;
        string del_amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;


            if (Session["Username"] == null)
            {
                Response.Redirect("login_page.aspx");
            }

            string letterno = Request.QueryString["letter_no"];

            if (!IsPostBack)
            {
                var acess = Session["acesslvl"];
                int ace = Convert.ToInt32(acess);








                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string minutesheet = "SELECT * FROM minute_sheet join campus on minute_sheet.campus = campus.campus_id join approvedby on minute_sheet.approvedby = approvedby.Id WHERE letter_no='" + letterno + "'";
                SqlCommand cmd = new SqlCommand(minutesheet, con);

                SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
                DataTable sqldatab = new DataTable();

                sqladp.Fill(sqldatab);


                letter_no.Text = letterno.ToString();
                letter_no.ReadOnly = true;

                date.Text = sqldatab.Rows[0]["date"].ToString();
                date.ReadOnly = true;

                title.Text = sqldatab.Rows[0]["title"].ToString();
                title.ReadOnly = true;

                campus = sqldatab.Rows[0]["campusname"].ToString();
                ddl_campus.Items.Insert(0, new ListItem(campus, campus));
                ddl_campus.Enabled = false;
                BindGrid();


                tb_amount.Text = sqldatab.Rows[0]["amount"].ToString();
                tb_amount.ReadOnly = true;

                approver = sqldatab.Rows[0]["approver"].ToString();
                approver_dl.Items.Insert(0, new ListItem(approver, approver));
                approver_dl.Enabled = false;

                tb_appdate.Text = sqldatab.Rows[0]["app_date"].ToString();
                tb_appdate.ReadOnly = true;
                image_img.ImageUrl = sqldatab.Rows[0]["image"].ToString();



            }

        }

        protected void del_btn_Click(object sender, EventArgs e)
        {

            string[] arg = new string[3];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            Session["letter_no"] = arg[0];
            Session["minutesheet_Id"] = arg[1];
            Session["category"] = arg[2];
            Session["amount"] = arg[3];
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();



            string qry = "SELECT amount from amount WHERE campus='" + Convert.ToInt32(Session["campus"]) + "' AND categ ='" + Convert.ToInt32(Session["category"]) + "'";
            SqlCommand comd = new SqlCommand(qry, con);
            SqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {

                del_amount = reader["amount"].ToString();
                break;
            }

            reader.Close();
            con.Close();

            if (acesslvl == 5)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Warning', 'Only Users Can Edit or Delete! Admin don't have rights.', 'warning')", true);
            }
            else if (acesslvl != 5)
            {
                con.Open();
                string minutesheet = "DELETE FROM minute_sheet_data WHERE letter_no='" + Session["letter_no"].ToString() + "' and Id='" + Convert.ToInt32(Session["minutesheet_Id"]) + "'";
                SqlCommand cmd = new SqlCommand(minutesheet, con);
                cmd.ExecuteNonQuery();
                BindGrid();

                int totalamount_ = Convert.ToInt32(Session["amount"]) + Convert.ToInt32(del_amount);


                string update = "UPDATE amount SET amount=@amount WHERE campus='" + Convert.ToInt32(Session["campus"]) + "' AND categ ='" + Convert.ToInt32(Session["category"]) + "'";
                SqlCommand command = new SqlCommand(update, con);

                command = new SqlCommand(update, con);

                command.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                command.Parameters["@amount"].Value = totalamount_;

                command.ExecuteNonQuery();

                string qry1 = "select amount from minute_sheet  WHERE letter_no='" + Convert.ToString(Session["letter_no"]) +"'" ;
                SqlCommand comd1 = new SqlCommand(qry1, con);
                SqlDataReader reader1 = comd1.ExecuteReader();
                while (reader1.Read())
                {

                    Session["Amou"] = reader1["amount"].ToString();
                    break;
                }
                reader1.Close();

                string update1 = "UPDATE minute_sheet SET amount=@amount WHERE letter_no='" + Convert.ToString(Session["letter_no"]) +"'";
                SqlCommand command1 = new SqlCommand(update1, con);


                command1.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                int total = Convert.ToInt32(Session["Amou"]) - Convert.ToInt32(Session["amount"]);

                command1.Parameters["@amount"].Value = total;

                command1.ExecuteNonQuery();
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



            string minutesheet = "SELECT * FROM minute_sheet_data JOIN faculty ON minute_sheet_data.Faculty_ = faculty.Id JOIN dept ON minute_sheet_data.Dept_ = dept.Id JOIN categ_list_table ON minute_sheet_data.category = categ_list_table.Id  WHERE letter_no='" + letter_no.Text + "'";
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

        protected void girdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = string.Format("{0:c}", totalamount);
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


    }
}