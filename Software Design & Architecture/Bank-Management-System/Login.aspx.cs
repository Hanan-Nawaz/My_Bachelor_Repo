using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            
                int count = 0;

                int accesslvl = 0;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry = "SELECT * from Accounts WHERE Email='" + tb_username.Text + "' AND Password ='" + tb_password.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    accesslvl = Convert.ToInt32(reader["Accesslvl"]);
                    Session["Accesslvl"] = accesslvl;
                    Session["Email"] = Convert.ToString(reader["Email"]);
                    Session["AccountNumber"] = Convert.ToString(reader["AccountNumber"]);
                    Session["Name"] = Convert.ToString(reader["Name"]);
                    Session["Picture"] = Convert.ToString(reader["Picture"]);
                    Session["Status"] = Convert.ToString(reader["Status"]);

                    count++;
                    break;
                }


                if (count == 1)
                {
                    if (Convert.ToString(Session["status"]) == "Active")
                    {
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        message.Style.Add("color", "Red");
                        message.Text = "Account Inactive. Contact Support!";

                    }

                }


                else
                {
                    message.Style.Add("color", "Red");
                    message.Text = "Invalid Username/Password!";
                }
            
        }
    }
}