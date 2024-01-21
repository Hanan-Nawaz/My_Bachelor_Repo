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
    public partial class addTag : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Tag - MedLearner";
            alertError.Visible = false;
            alertSuccess.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            alertError.Visible = false;
            alertSuccess.Visible = false;

            string Query = "Insert into parentTag values('" + txtTag.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                alertError.Visible = false;
                alertSuccess.Visible = true;
            }
            else
            {
                alertError.Visible = true;
                alertSuccess.Visible = false;
            }
        }
    }
}