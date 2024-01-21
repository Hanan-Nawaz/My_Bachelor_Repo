using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class addprincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl == 1 || accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }
            else
            {



                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                con.Open();


                if (!IsPostBack)
                {
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

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_tehsil.AppendDataBoundItems = true;
            ddl_tehsil.Items.Clear();
            ddl_tehsil.Items.Add("Select Tehsil");
            string count = "SELECT * from tehsil where district=" + ddl_district.SelectedValue;
            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_tehsil.DataSource = sqldatabase;
            ddl_tehsil.DataTextField = "tehsil";
            ddl_tehsil.DataValueField = "Id";
            ddl_tehsil.DataBind();
        }

        protected void ddl_tehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_uc.AppendDataBoundItems = true;
            ddl_uc.Items.Clear();
            ddl_uc.Items.Add("Select UC");
            string count = "SELECT * from unionc where tehsil='" + ddl_tehsil.SelectedValue + "' AND uc= '" + Convert.ToString(Session["unioncouncil"] + "'");
            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_uc.DataSource = sqldatabase;
            ddl_uc.DataTextField = "uc";
            ddl_uc.DataValueField = "Id";
            ddl_uc.DataBind();
        }

        protected void ddl_uc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_school.AppendDataBoundItems = true;
            ddl_school.Items.Clear();
            ddl_school.Items.Add("Select School ");
            string count = "SELECT schoolname,Id from school where ucid=" + ddl_uc.SelectedValue;
            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_school.DataSource = sqldatabase;
            ddl_school.DataTextField = "schoolname";
            ddl_school.DataValueField = "Id";
            ddl_school.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();

            if (ddl_uc.SelectedIndex == 0 || ddl_country.SelectedIndex == 0 || ddl_province.SelectedIndex == 0 || ddl_district.SelectedIndex == 0 || ddl_tehsil.SelectedIndex == 0 || ddl_school.SelectedIndex == 0)
            {
                message.Style.Add("color", "red");
                message.Text = "Please Fill Full Form!!";
            }
            else
            {


                try
                {
                    sqlStmt = "insert into login_table (username,password,cnic,email,contact,province,district,tehsil,address,unioncouncil,country,accesslvl,school,schoolid,name,portfolio) Values(@username,@password,@cnic,@email,@contact,@province,@address,@district,@tehsil,@unioncouncil,@country,@accesslvl,@school,@schoolid,@name,@portfolio)  ";

                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    cmd = new SqlCommand(sqlStmt, cn);
                    cn.Open();

                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@cnic", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@contact", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@unioncouncil", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@accesslvl", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@schoolid", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@portfolio", SqlDbType.VarChar, 50));


                    cmd.Parameters["@username"].Value = tb_user.Text;
                    cmd.Parameters["@password"].Value = tb_pass.Text;
                    cmd.Parameters["@cnic"].Value = tb_cnic.Text;
                    cmd.Parameters["@email"].Value = tb_email.Text;
                    cmd.Parameters["@address"].Value = ddl_tehsil.SelectedItem.Text;
                    cmd.Parameters["@contact"].Value = tb_cell.Text;
                    cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                    cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                    cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                    cmd.Parameters["@unioncouncil"].Value = ddl_uc.SelectedItem.Text;
                    cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                    cmd.Parameters["@accesslvl"].Value = 4;
                    cmd.Parameters["@school"].Value = ddl_school.SelectedItem.Text;
                    cmd.Parameters["@schoolid"].Value = ddl_school.SelectedValue;
                    cmd.Parameters["@name"].Value = tb_name.Text;
                    cmd.Parameters["@portfolio"].Value = "Principal";


                    cmd.ExecuteNonQuery();

                    message.Text = "Record Inserted Succesfully";
                }
                catch (Exception ex)
                {
                    message.Text = ex.Message;
                }
                finally
                {
                    cn.Close();

                }
            }
        }


    }
}