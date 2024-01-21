using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class addlocation : System.Web.UI.Page
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


                    ddl_county1.AppendDataBoundItems = true;
                    ddl_county1.Items.Clear();
                    ddl_county1.Items.Add("Select Country");



                    string count = "SELECT * from country";
                    SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
                    DataTable sqldatabase = new DataTable();
                    sqladpter.Fill(sqldatabase);
                    ddl_country.DataSource = sqldatabase;
                    ddl_country.DataTextField = "country";
                    ddl_country.DataValueField = "Id";
                    ddl_country.DataBind();

                    ddl_county1.DataSource = sqldatabase;
                    ddl_county1.DataTextField = "country";
                    ddl_county1.DataValueField = "Id";
                    ddl_county1.DataBind();


                }
            }
        }


        protected void ddl_county1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            ddl_province1.AppendDataBoundItems = true;
            ddl_province1.Items.Clear();
            ddl_province1.Items.Add("Select Province/State");

            string count = "select * from province where country_name =" + ddl_county1.SelectedValue;

            SqlDataAdapter sqladpter = new SqlDataAdapter(count, con);
            DataTable sqldatabase = new DataTable();
            sqladpter.Fill(sqldatabase);
            ddl_province1.DataSource = sqldatabase;
            ddl_province1.DataTextField = "province";
            ddl_province1.DataValueField = "Id";
            ddl_province1.DataBind();

        }



        protected void btn_save_province_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            if (ddl_country.SelectedIndex == 0 || tb_province.Text == null)
            {
                message.Style.Add("color", "red");
                message.Text = "Please select Country and Enter Province!";
            }
            else
            {
                try
                {
                    string prov = " insert into province (province,country_name) Values(@province,@country_name)";
                    SqlCommand cmd = new SqlCommand(prov, con);

                    cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@country_name", SqlDbType.Int));

                    cmd.Parameters["@province"].Value = tb_province.Text;
                    cmd.Parameters["@country_name"].Value = ddl_country.SelectedValue;

                    cmd.ExecuteNonQuery();

                    message.Text = "Province Inserted Succesfully";

                }
                catch (Exception ex)
                {
                    message.Text = ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
        }

        protected void btn_save_district_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            if (ddl_county1.SelectedIndex == 0 || ddl_province1.SelectedIndex == 0 || tb_district.Text == null)
            {
                message.Style.Add("color", "red");
                message.Text = "Please select Country, Select Province and Enter District!";
            }
            else
            {
                try
                {
                    string prov = " insert into district (province,district) Values(@province,@district)";
                    SqlCommand cmd = new SqlCommand(prov, con);

                    cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.Int));

                    cmd.Parameters["@district"].Value = tb_district.Text;
                    cmd.Parameters["@province"].Value = ddl_province1.SelectedValue;

                    cmd.ExecuteNonQuery();

                    message.Text = "District Inserted Succesfully";

                }
                catch (Exception ex)
                {
                    message.Text = ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
        }


    }
}
