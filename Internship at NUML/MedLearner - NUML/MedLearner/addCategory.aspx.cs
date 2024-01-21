using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class addCategory : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Category - MedLearner";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            string Query = "Insert into Category values('" + txtCategory.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);   
            int result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                lblMessage.Text = "Category Added Successfully :)";
            }
            else
            {
                lblMessage.Text = "Un-expected Error! Try Again !!";
            }
        }
    }
}