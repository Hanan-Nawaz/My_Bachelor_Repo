using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class seelists : System.Web.UI.Page
    {

        string status;
        string updatequery;
        string status1;
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["accesslvl"]);
            Session.Timeout = 60;

            if (accesslvl != 0)
            {
            }
            else
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
            SqlConnection con = new SqlConnection();
            string minutesheet = "SELECT * FROM login_table where accesslvl!=6";

            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

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

                    if (row["name"].ToString().ToLower().Contains(searchTerm) || row["status"].ToString().ToLower().Contains(searchTerm) || row["email"].ToString().ToLower().Contains(searchTerm) || row["district"].ToString().ToLower().Contains(searchTerm) || row["country"].ToString().ToLower().Contains(searchTerm) || row["contact"].ToString().ToLower().Contains(searchTerm) || row["province"].ToString().ToLower().Contains(searchTerm) || row["portfolio"].ToString().ToLower().Contains(searchTerm) || row["cnic"].ToString().ToLower().Contains(searchTerm))
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
                string imgPath = DataBinder.Eval(e.Item.DataItem, "image").ToString();
                {

                    Image imgProduct = (Image)e.Item.Cells[0].FindControl("imgProduct");
                    imgProduct.ImageUrl = imgPath;

                }
                status = DataBinder.Eval(e.Item.DataItem, "status").ToString();
                Label status_label = (Label)e.Item.Cells[0].FindControl("status_label");
                LinkButton btn = (LinkButton)e.Item.Cells[0].FindControl("btn");

                if (accesslvl != 6)
                {
                    btn.Visible = false;
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
            string[] arg = new string[2];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            int id = Convert.ToInt32(arg[0]);
            string stat = arg[1];
            string cnic = arg[2];

            if (stat == "Active")
            {
                updatequery = "Update login_table set status=@status where Id='" + id + "' And cnic='" + cnic +"'";
                status1 = "InActive";
            }
            else
            {
                updatequery = "Update login_table set status=@status where Id='" + id + "' And cnic='" + cnic + "'";
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
    }
}