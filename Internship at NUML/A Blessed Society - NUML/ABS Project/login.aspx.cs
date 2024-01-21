using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = " Login Us - ABS";
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int count = 0;

            int accesslvl = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string qry = "SELECT * from login_table WHERE username='" + tb_username1.Text + "' AND password ='" + tb_password1.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                accesslvl = Convert.ToInt32(reader["accesslvl"]);
                Session["accesslvl"] = accesslvl;
                Session["district"] = Convert.ToString(reader["district"]);
                Session["email"] = Convert.ToString(reader["email"]);
                Session["cnic"] = Convert.ToString(reader["beniid"]);
                Session["name"] = Convert.ToString(reader["name"]);
                Session["pic"] = Convert.ToString(reader["image"]);
                Session["portfolio"] = Convert.ToString(reader["portfolio"]);
                Session["school"] = Convert.ToString(reader["school"]);
                Session["sendingmail"] = "admin@abs.edu.pk";
                int id = Convert.ToInt32(reader["Id"]);
                Session["Id"] = id;
                Session["status"] = Convert.ToString(reader["status"]);

                count++;
                break;
            }


            if (count == 1)
            {
                if (Convert.ToString(Session["status"]) == "Active")
                {
                    Session["username"] = tb_username1.Text;

                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    message1.Style.Add("color", "Red");
                    message1.Text = "Account Inactive. Contact Support!";

                }

            }


            else
            {
                message1.Style.Add("color", "Red");
                message1.Text = "Invalid Username/Password!";
            }
        }

        protected void link_forgot_pass_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forgot-Password.aspx");

        }

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }
    }
}