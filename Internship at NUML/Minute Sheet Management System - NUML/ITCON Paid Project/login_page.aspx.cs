using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ITCON_Paid_Project
{
    public partial class login_page : System.Web.UI.Page
    {

        string name = "";
        string campus = "";


        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

            int count = 0;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string qry = "SELECT * from user_table WHERE Username='" + tb_username.Text + "' AND password ='" + tb_password.Text + "'  COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Session["acesslvl"] = Convert.ToInt32(reader["acesslvl"]);
                name = reader["Name"].ToString();
                Session["ID"] = reader["Id"].ToString();
                campus = reader["campus"].ToString();

                count++;
                break;
            }


            if (count == 1)
            {
                Session["campus"] = campus;
                    Session["username"] = tb_username.Text;
                Session["Name"] = name;
                    Response.Redirect("dashboard.aspx");               

            }


            else
            {
                message.Style.Add("color", "red");
                message.Text = "Invalid Username/Password!";
            }

            

            



        }

       

        protected void link_forgot_pass_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpassword.aspx");
        }
    }
}