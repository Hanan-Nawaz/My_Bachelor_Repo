using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ABS_Project
{
    public partial class EditProfile : System.Web.UI.Page
    {
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);

            

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }

            else
            {
                if (!Page.IsPostBack)
                {

                    ddl_school.Visible = false;

                    string id = Convert.ToString(Session["Id"]);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                    ddl_country.AppendDataBoundItems = true;
                    ddl_country.Items.Clear();
                    ddl_country.Items.Add("Select Country");
                    string count = "SELECT * from country";
                    SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
                    DataTable sqldatabase = new DataTable();
                    sqladpter.Fill(sqldatabase);
                    ddl_country.DataSource = sqldatabase;
                    ddl_country.DataTextField = "country";
                    ddl_country.DataValueField = "Id";
                    ddl_country.DataBind();
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
                    picture.ImageUrl = Convert.ToString(reader["image"]);
                    ddl_school.SelectedItem.Text = Convert.ToString(reader["school"]);
                    break;
                   
                }
                reader.Close();

               

                }

            }
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_province.AppendDataBoundItems = true;
            ddl_province.Items.Clear();
            ddl_province.Items.Add("Select Province/State");

            string count = "select * from province where country_name =" + ddl_country.SelectedValue;

            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_province.DataSource = sqldatabase;
            ddl_province.DataTextField = "province";
            ddl_province.DataValueField = "Id";
            ddl_province.DataBind();
        }

        protected void ddl_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_district.AppendDataBoundItems = true;
            ddl_district.Items.Clear();
            ddl_district.Items.Add("Select District");
            string count = "SELECT * from district where province=" + ddl_province.SelectedValue;
            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_district.DataSource = sqldatabase;
            ddl_district.DataTextField = "District";
            ddl_district.DataValueField = "Id";
            ddl_district.DataBind();
        }


        protected void update_Click(object sender, EventArgs e)
        {

            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();

            string id = Convert.ToString(Session["Id"]);
            sqlStmt = "Update login_table set username=@username,password=@password,address=@address,email=@email,contact=@contact,province=@province,district=@district,portfolio=@portfolio,accesslvl=@accesslvl,cnic=@cnic,country=@country,name=@name,image=@image,status=@status where Id=" + Convert.ToInt32(id);


            
            if (ddl_portfolio.SelectedIndex == 0)
            {
                message.Text = "Please Select Portfolio!!";
            }
            else
            {

                decimal size = Math.Round(((decimal)profile_upload.PostedFile.ContentLength / (decimal)1024), 2);
                //Limit size to approx 50kb for image
                if ((size > 100))
                {
                    message.Text = "Please upload image of upto 100kb size only Go to https://imresizer.com/resize-image-to-100kb to Resize online ";
                }
                else
                {

                    try
                    {

                        cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        cmd = new SqlCommand(sqlStmt, cn);
                        cn.Open();

                        string filename = Path.GetFileName(profile_upload.PostedFile.FileName);
                        string filePath = filename;
                        profile_upload.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath));


                        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@contact", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                        //    cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                        //   cmd.Parameters.Add(new SqlParameter("@unioncouncil", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@portfolio", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@accesslvl", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@cnic", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar));


                        cmd.Parameters["@username"].Value = tb_username.Text;
                        cmd.Parameters["@password"].Value = tb_password.Text;
                        cmd.Parameters["@address"].Value = tb_address.Text;
                        cmd.Parameters["@email"].Value = tb_email.Text;
                        cmd.Parameters["@contact"].Value = tb_contact.Text;
                        cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                        cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                        //   cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                        //   cmd.Parameters["@unioncouncil"].Value = ddl_uc.SelectedItem.Text;
                        cmd.Parameters["@portfolio"].Value = ddl_portfolio.SelectedItem.Text;
                        if (ddl_portfolio.SelectedItem.Text == "Donor")
                        {
                            accesslvl = 1;
                        }
                        else if (ddl_portfolio.SelectedItem.Text == "Volunteer")
                        {
                            accesslvl = 2;
                        }
                        else if (ddl_portfolio.SelectedItem.Text == "Principal")
                        {
                            accesslvl = 2;
                        }
                        else if (ddl_portfolio.SelectedItem.Text == "Both Donor & Volunteer")
                        {
                            accesslvl = 3;
                        }

                        cmd.Parameters["@accesslvl"].Value = accesslvl;
                        cmd.Parameters["@cnic"].Value = tb_cnic.Text;
                        cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                        cmd.Parameters["@name"].Value = tb_name.Text;
                        cmd.Parameters.AddWithValue("@image", "~/images/" + filePath);
                        cmd.Parameters["@status"].Value = "InActive";
                        cmd.Parameters["@school"].Value = ddl_school.SelectedItem.Text;


                        int i =cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            message.Text = "Update Successfully";
                        }
                        else
                        {
                            message.Text = "Error! Try Again";
                        }
                    }
                    catch (Exception ex)
                    {
                        message.Text = ex.Message;
                    }
                }
            }
        }

        protected void ddl_portfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_portfolio.SelectedItem.Text == "Principal")
            {
                ddl_school.Visible = true;
                schlb.Visible = true;

            }
            
        }

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_school.AppendDataBoundItems = true;
            ddl_school.Items.Clear();
            ddl_school.Items.Add("Select School");
            string count = "SELECT * from school where ucid=" + ddl_district.SelectedValue;
            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_school.DataSource = sqldatabase;
            ddl_school.DataTextField = "schoolname";
            ddl_school.DataValueField = "Id";
            ddl_school.DataBind();
        }
    }
}