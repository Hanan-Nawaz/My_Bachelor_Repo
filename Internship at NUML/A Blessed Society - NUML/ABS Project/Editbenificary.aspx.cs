using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ABS_Project
{
    public partial class Editbenificary : System.Web.UI.Page
    {
        int ID;
        string count;
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);



            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }

            else
            {
                if (accesslvl == 1 || accesslvl == 3 || accesslvl == 6)
                {
                    btn_save.Visible = true;
                }
                else
                {
                    btn_save.Visible = false;
                }

                if (!Page.IsPostBack)
                {
                    string id = Request.QueryString["ID"];
                    ID = Convert.ToInt32(id);
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

                    string qry = "SELECT * from benificary_table WHERE Id=" + ID;
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        tb_name.Text = Convert.ToString(reader["name"]);
                        tb_fathername.Text = Convert.ToString(reader["fathername"]);
                        tb_gaurdianname.Text = Convert.ToString(reader["gaurdianname"]);
                        tb_address.Text = Convert.ToString(reader["address"]);
                        tb_cnic.Text = Convert.ToString(reader["cnic"]);
                        tb_gaurdianemail.Text = Convert.ToString(reader["gaurdianemail"]);
                        tb_contact.Text = Convert.ToString(reader["gaurdiancontact"]);
                        //   ddl_tehsil.SelectedItem.Text = Convert.ToString(reader["tehsil"]);
                        ddl_country.SelectedItem.Text = Convert.ToString(reader["country"]);
                        ddl_province.SelectedItem.Text = Convert.ToString(reader["province"]);
                        ddl_district.SelectedItem.Text = Convert.ToString(reader["district"]);
                        // ddl_uc.SelectedItem.Text = Convert.ToString(reader["unioncouncil"]);
                        ddl_school.SelectedItem.Text = Convert.ToString(reader["school"]);
                        tb_needs.Text = Convert.ToString(reader["needs"]);
                        profilepic.ImageUrl = Convert.ToString(reader["profile"]);
                        death.ImageUrl = Convert.ToString(reader["deathcert"]);
                        uc_con.ImageUrl = Convert.ToString(reader["uccon"]);
                        prnl.ImageUrl = Convert.ToString(reader["prnl"]);
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

            count = "select * from province where country_name =" + ddl_country.SelectedValue;

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

            {
                count = "SELECT * FROM district where district='" + Session["district"] + "' And province='" + ddl_province.SelectedValue + "'";

            }

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

            ddl_school.AppendDataBoundItems = true;
            ddl_school.Items.Clear();
            ddl_school.Items.Add("Select School ");
            string count = "SELECT schoolname,Id from school where ucid=" + ddl_district.SelectedValue;
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
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string id = Request.QueryString["ID"];
            ID = Convert.ToInt32(id);
            try
            {

                string filename = Path.GetFileName(profile_upload.PostedFile.FileName);
                string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
                string filePath = _filename;
                profile_upload.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath));


                string filename1 = Path.GetFileName(death_upl.PostedFile.FileName);
                string _filename1 = DateTime.Now.ToString("hhmmssfff") + filename1;
                string filePath1 = _filename1;
                profile_upload.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath1));


                string filename2 = Path.GetFileName(uc_uplaoad.PostedFile.FileName);
                string _filename2 = DateTime.Now.ToString("hhmmssfff") + filename2;
                string filePath2 = _filename2;
                profile_upload.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath2));


                string filename3 = Path.GetFileName(prn_upload.PostedFile.FileName);
                string _filename3 = DateTime.Now.ToString("hhmmssfff") + filename3;
                string filePath3 = _filename3;
                profile_upload.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath3));

                SqlCommand cmd = new SqlCommand("Update benificary_table set name=@name ,fathername=@fathername,gaurdianname=@gaurdianname,address=@address,gaurdianemail=@gaurdianemail,gaurdiancontact=@gaurdiancontact,school=@school,country=@country,province=@province,district=@district,needs=@needs,status=@status,cnic=@cnic where Id=" + ID, con);

                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@fathername", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@gaurdianname", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 300));
                cmd.Parameters.Add(new SqlParameter("@gaurdianemail", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@gaurdiancontact", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                //   cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                //   cmd.Parameters.Add(new SqlParameter("@unioncouncil", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@needs", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@cnic", SqlDbType.VarChar, 50));

                cmd.Parameters["@name"].Value = tb_name.Text;
                cmd.Parameters["@fathername"].Value = tb_fathername.Text;
                cmd.Parameters["@gaurdianname"].Value = tb_gaurdianname.Text;
                cmd.Parameters["@address"].Value = tb_address.Text;
                cmd.Parameters["@gaurdianemail"].Value = tb_gaurdianemail.Text;
                cmd.Parameters["@gaurdiancontact"].Value = tb_contact.Text;
                cmd.Parameters["@school"].Value = ddl_school.SelectedItem.Text;
                cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                //  cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                //  cmd.Parameters["@unioncouncil"].Value = ddl_uc.SelectedItem.Text;
                cmd.Parameters["@needs"].Value = tb_needs.Text;
                cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                cmd.Parameters["@status"].Value = "Active";
                cmd.Parameters["@cnic"].Value = tb_cnic.Text;
                cmd.Parameters.AddWithValue("@profile", "~/images/" + filePath);

                cmd.Parameters.AddWithValue("@deathcert", "~/images/" + filePath1);
                cmd.Parameters.AddWithValue("@uccon", "~/images/" + filePath2);
                cmd.Parameters.AddWithValue("@prnl", "~/images/" + filePath3);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    message.Text = "Updated Successfully";
                }
                else
                {
                    message.Style.Add("color", "red");
                    message.Text = "Updated Successfully";
                }
                con.Close();

           

            }
            catch(Exception ex)
            {
                message.Text = ex.Message;
            }
        }
    }

}