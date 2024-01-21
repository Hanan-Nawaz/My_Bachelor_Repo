using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class allUsers : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Users  - MedLearner";

            lblCourseName.InnerText = "Users";

            if (!Page.IsPostBack)
            {
                bindGridView();
            }
        }

        private void bindGridView()
        {
            string Query = "select * from Users";
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            DataTable dtUser = new DataTable();
            adp.Fill(dtUser);
            grdUser.DataSource = dtUser;
            grdUser.DataBind();
        }


        protected void grdUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = grdUser.Rows[rowIndex];

                //Fetch value of Name.
                string Id = (row.FindControl("txtName") as Label).Text;

                //Fetch value of Country

                Session["ActiveDeactiveUser"] = Id;
                Response.Redirect("viewUser.aspx");
            }
        }
    }
}