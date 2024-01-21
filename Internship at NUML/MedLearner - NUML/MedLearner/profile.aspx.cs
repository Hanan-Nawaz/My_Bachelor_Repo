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
    public partial class prfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where Email='" + email + "'", con);
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();

            Page.Title = Session["Name"].ToString() + " - MedLearner";


            if (sqlDataReaderreader.HasRows)
            {
                while (sqlDataReaderreader.Read())
                {
                    txtEmail.Text = sqlDataReaderreader["Email"].ToString();
                    txtFirstName.Text = sqlDataReaderreader["FirstName"].ToString();
                    txtLastName.Text = sqlDataReaderreader["LastName"].ToString();
                    ddlOccupation.SelectedIndex = Convert.ToInt32(sqlDataReaderreader["Occupation"]);
                    txtPassword.Text = sqlDataReaderreader["Password"].ToString();
                    txtSNum.Text = sqlDataReaderreader["Street"].ToString();
                    txtAInfo.Text = sqlDataReaderreader["Additioninfo"].ToString();
                    txtZip.Text = sqlDataReaderreader["ZipCode"].ToString();
                    txtPlace.Text = sqlDataReaderreader["Place"].ToString();
                    txtCountry.Text = sqlDataReaderreader["Country"].ToString();
                    txtPhone.Text = sqlDataReaderreader["MobileNumber"].ToString();
                    //txtCode.Text = sqlDataReaderreader["MobileNumber"].ToString();
                   
                }
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }

        }
    }
}