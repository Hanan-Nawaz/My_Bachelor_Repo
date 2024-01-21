using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class addschool : System.Web.UI.Page
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            if (ddl_country.SelectedIndex == 0 || ddl_province.SelectedIndex == 0 || ddl_district.SelectedIndex == 0)
            {
                message.Style.Add("color", "red");
                message.Text = "Please Fill Full form";
            }
            else
            {
                try
                {

                    string sqlStmt = "insert into school (country,province,district,schoolname,ucid) Values(@country,@province,@district,@schoolname,@ucid)";
                    SqlCommand cmd = new SqlCommand(sqlStmt, con);
                    con.Open();

                    cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                    //    cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                    //    cmd.Parameters.Add(new SqlParameter("@uc", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@schoolname", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@ucid", SqlDbType.Int));

                    cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                    cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                    cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                    //   cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                    //   cmd.Parameters["@uc"].Value = ddl_uc.SelectedItem.Text;
                    cmd.Parameters["@schoolname"].Value = tb_schoolname.Text;
                    cmd.Parameters["@ucid"].Value = ddl_district.SelectedValue;

                    cmd.ExecuteNonQuery();

                    message.Text = "School added Successfully";
                }
                catch (Exception ex)
                {
                    message.Style.Add("color", "red");

                    message.Text = ex.Message;
                }
                finally
                {
                    con.Close();
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


    }
}