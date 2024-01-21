using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MedLearner.LandingPages
{
    public partial class signin : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Login - MedLearner";

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string Query = "Select * from Users where Email='" + txtEmail.Text + "' and Password='" + txtPassword.Text + "' and Status=0";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            if (sqlDataReader.HasRows) 
            {
                while (sqlDataReader.Read())
                {
                    string FisrtName = sqlDataReader["FirstName"].ToString().Trim();
                    string LastName = sqlDataReader["LastName"].ToString().Trim();
                    string Email = sqlDataReader["Email"].ToString().Trim();
                    int Occupation = Convert.ToInt32(sqlDataReader["Occupation"]);

                    Session["Name"] = FisrtName + LastName;
                    Session["Email"] = Email;
                    Session["Occupation"] = Occupation;
                    Session["Status"] = 1;
                }
                Response.Redirect("/dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Wrong Email or Password or Account is not Active!!";
            }

        }
    }
}