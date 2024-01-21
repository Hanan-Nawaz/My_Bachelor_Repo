using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);



            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }

            else
            {


                string id = Convert.ToString(Session["Id"]);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry = "select * from login_table where Id=" + Convert.ToInt32(id);
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    tb_name.Text = Convert.ToString(reader["name"]);
                    tb_username.Text = Convert.ToString(reader["username"]);
                    tb_password.Text = Convert.ToString(reader["password"]);
                    tb_address.Text = Convert.ToString(reader["address"]);
                    tb_cnic.Text = Convert.ToString(reader["cnic"]);
                    tb_email.Text = Convert.ToString(reader["email"]);
                    tb_contact.Text = Convert.ToString(reader["contact"]);
                    ddl_country.SelectedItem.Text = Convert.ToString(reader["country"]);
                    ddl_province.SelectedItem.Text = Convert.ToString(reader["province"]);
                    ddl_district.SelectedItem.Text = Convert.ToString(reader["district"]);
                    ddl_portfolio.SelectedItem.Text = Convert.ToString(reader["portfolio"]);
                      profilepic.ImageUrl = Convert.ToString(reader["image"]);

                }




            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx?id=" + Convert.ToInt32(Session["Id"]));
        }
    }
}