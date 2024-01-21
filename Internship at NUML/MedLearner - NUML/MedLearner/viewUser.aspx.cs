using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class viewUser : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Session["ActiveDeactiveUser"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where Email='" + Id + "'", con);
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();

            Page.Title =  "View User - MedLearner";


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
                    if(sqlDataReaderreader["Status"].ToString() == "0")
                    {
                        txtStatus.Text = "Active";
                    }
                    else
                    {
                        txtStatus.Text = "DeActive";
                    }
                    //txtCode.Text = sqlDataReaderreader["MobileNumber"].ToString();
                }
            }

            sqlDataReaderreader.Close();
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            string query = "Update Users set Status=0 where Email='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();

            if(result > 0)
            {
                lblMessage.Text = "User's Account Activated Successfully :)";
                con.Close();
                Page_Load(sender, e);
            }
            else
            {
                lblMessage.Text = "Unknown Error! Try Again.";
            }
        }

        protected void btnDeActive_Click(object sender, EventArgs e)
        {
            string query = "Update Users set Status=1 where Email='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                lblMessage.Text = "User's Account DeActivated Successfully :)";
                con.Close();
                Page_Load(sender, e);
            }
            else
            {
                lblMessage.Text = "Unknown Error! Try Again.";
            }
        }
    }
}