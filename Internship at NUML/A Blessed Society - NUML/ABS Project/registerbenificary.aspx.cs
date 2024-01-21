using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ABS_Project
{
    public partial class registerbenificary : System.Web.UI.Page
    {
        int accesslvl;
        string count;
        protected void Page_Load(object sender, EventArgs e)
        {

            accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl == 1 || accesslvl == 4 || accesslvl == 5)
            {
                Response.Redirect("login.aspx");
            }
            else
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

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
            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();


            try
            {

                decimal size = Math.Round(((decimal)profile_upload.PostedFile.ContentLength / (decimal)1024), 2);
                decimal size1 = Math.Round(((decimal)death_upl.PostedFile.ContentLength / (decimal)1024), 2);
                decimal size2 = Math.Round(((decimal)uc_uplaoad.PostedFile.ContentLength / (decimal)1024), 2);
                decimal size3 = Math.Round(((decimal)prn_upload.PostedFile.ContentLength / (decimal)1024), 2);

                //Limit size to approx 50kb for image
                if (size > 100 /*&& size1 > 100 && size2 > 100 && size3 > 100 */)
                {
                    message.Text = "Please upload image of upto 100kb size only Go to https://imresizer.com/resize-image-to-100kb to Resize online ";
                }
                else
                {

                    sqlStmt = "insert into benificary_table (name,fathername,gaurdianname,address,gaurdianemail,gaurdiancontact,school,country,province,district,needs,status,cnic,profile,volid) Values(@name,@fathername,@gaurdianname,@address,@gaurdianemail,@gaurdiancontact,@school,@country,@province,@district,@needs,@status,@cnic,@profile,@volid)";

                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    cmd = new SqlCommand(sqlStmt, cn);
                    cn.Open();



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
                    cmd.Parameters.Add(new SqlParameter("@volid", SqlDbType.Int));



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
                    cmd.Parameters["@volid"].Value = Convert.ToInt32(Session["Id"]);


                    cmd.ExecuteNonQuery();



                    sqlStmt = "insert into login_table (username,password,address,email,contact,province,district,portfolio,accesslvl,cnic,country,name,image,status,beniid) Values(@username,@password,@address,@email,@contact,@province,@district,@portfolio,@accesslvl,@cnic,@country,@name,@image,@status,@beniid)  ";

                    cmd = new SqlCommand(sqlStmt, cn);

                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@contact", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                    //   cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                    //   cmd.Parameters.Add(new SqlParameter("@unioncouncil", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@portfolio", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@accesslvl", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@cnic", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@beniid", SqlDbType.VarChar, 50));


                    cmd.Parameters["@username"].Value = tb_username.Text;
                    cmd.Parameters["@password"].Value = tb_password.Text;
                    cmd.Parameters["@address"].Value = tb_address.Text;
                    cmd.Parameters["@email"].Value = tb_username.Text;
                    cmd.Parameters["@contact"].Value = tb_contact.Text;
                    cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                    cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                    //    cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                    //      cmd.Parameters["@unioncouncil"].Value = ddl_uc.SelectedItem.Text;
                    cmd.Parameters["@portfolio"].Value = "Gaurdian";
                    cmd.Parameters["@accesslvl"].Value = 5;
                    cmd.Parameters["@cnic"].Value = tb_cnic.Text;
                    cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                    cmd.Parameters["@name"].Value = tb_name.Text;
                    cmd.Parameters.AddWithValue("@image", "~/images/" + filePath);
                    cmd.Parameters["@status"].Value = "Active";
                    cmd.Parameters["@beniid"].Value = tb_cnic.Text;


                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        message.Text = "Benificary Inserted Succesfully";
                    }
                    else
                    {
                        message.Style.Add("color", "red");
                        message.Text = "Error Detected! Try Again";

                    }
                }
            }

            catch (Exception ex)
            {
                message.Style.Add("color", "red");
                message.Text = ex.Message;
            }
            finally
            {
                cn.Close();

            }

        }
    }

}


