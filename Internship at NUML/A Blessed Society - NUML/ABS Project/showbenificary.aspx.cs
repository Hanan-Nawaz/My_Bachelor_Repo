using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class showbenificary : System.Web.UI.Page
    {

        string status;
        string updatequery;
        string status1;

        int accesslvl;
        string minutesheet;

        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["accesslvl"]);
            Session.Timeout = 60;

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }



            BindGrid();



        }

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private void BindGrid(string sortExpression = null)
        {
            string stt = "Active";
            SqlConnection con = new SqlConnection();


            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            if (Convert.ToString(Session["portfolio"]) == "Principal")
            {
                minutesheet = "SELECT * FROM benificary_table where district='" + Session["district"] + "' And school='" + Session["school"] + "' Or volid='" + Session["Id"] + "'";
            }

            else if (accesslvl == 2 || accesslvl == 3)
            {
                minutesheet = "SELECT * FROM benificary_table where district='" + Session["district"] + "' And volid='" + Session["Id"] + "'";
            }
            else if (accesslvl == 5)
            {
                minutesheet = "SELECT * FROM benificary_table where cnic=" + Session["cnic"];
            }
            else if (accesslvl == 1)
            {
                minutesheet = "SELECT * FROM benificary_table where status='" + stt + "'";
            }
            else
            {
                minutesheet = "SELECT * FROM benificary_table";
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
                girdview1.DataSource = dv;

            }
            else
            {

                girdview1.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview1.DataBind();

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

                    if (row["name"].ToString().ToLower().Contains(searchTerm) || row["status"].ToString().ToLower().Contains(searchTerm) || row["gaurdianemail"].ToString().ToLower().Contains(searchTerm) || row["district"].ToString().ToLower().Contains(searchTerm) || row["school"].ToString().ToLower().Contains(searchTerm) || row["gaurdiancontact"].ToString().ToLower().Contains(searchTerm) || row["province"].ToString().ToLower().Contains(searchTerm) || row["needs"].ToString().ToLower().Contains(searchTerm) || row["cnic"].ToString().ToLower().Contains(searchTerm))
                    {

                        dtNew.Rows.Add(row.ItemArray);
                    }
                }


                girdview1.DataSource = dtNew;
                girdview1.DataBind();
            }
        }





        protected void girdview1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            girdview1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }


        protected void getImagePath(Object sender, DataGridItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string imgPath = DataBinder.Eval(e.Item.DataItem, "profile").ToString();
                {

                    Image imgProduct = (Image)e.Item.Cells[0].FindControl("imgProduct");
                    imgProduct.ImageUrl = imgPath;

                }
                status = DataBinder.Eval(e.Item.DataItem, "status").ToString();
                Label status_label = (Label)e.Item.Cells[0].FindControl("status_label");
                LinkButton btn = (LinkButton)e.Item.Cells[0].FindControl("btn");
                LinkButton btn_ = (LinkButton)e.Item.Cells[0].FindControl("edit_btn");

                if (accesslvl == 6 || accesslvl == 2 || accesslvl == 3)
                {
                    btn.Visible = true;
                    btn_.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                    btn_.Visible = false;
                }

                if (status == "Active")
                {
                    status_label.Text = "Active";
                    btn.Text = "InActive";
                }
                else
                {
                    status_label.Text = "InActive";
                    btn.Text = "Active";
                }


            }

        }

        protected void girdview1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }

        protected void del_btn_Click(object sender, EventArgs e)
        {
            string[] arg = new string[1];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            int id = Convert.ToInt32(arg[0]);
            string stat = arg[1];
            if (stat == "Active")
            {
                updatequery = "Update benificary_table set status=@status where Id=" + id;
                status1 = "InActive";
            }
            else
            {
                updatequery = "Update benificary_table set status=@status where Id=" + id;
                status1 = "Active";

            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString; con.Open();
            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status", status1);

            cmd.ExecuteNonQuery();
            con.Close();

            {

                BindGrid();
            }
        }








        protected void view_btn_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Response.Redirect("viewbenificary.aspx?ID=" + ID);

        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Response.Redirect("Editbenificary.aspx?ID=" + ID);
        }
    }
}