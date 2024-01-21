using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class Sign_UP : System.Web.UI.Page
    {
        string status = "Active";
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;



            if (!IsPostBack)
            {
                addbtn.Visible = false;
                tb_school.Visible = false;
                lb_sch.Visible = false;
                schlb.Visible = false;
                ddl_school.Visible = false;
                add.Visible = false;

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



        protected void submit_Click(object sender, EventArgs e)
        {

            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();

            if (ddl_portfolio.SelectedItem.Text != "Principal")
            {
                sqlStmt = "insert into login_table (username,password,address,email,contact,province,district,portfolio,accesslvl,cnic,country,name,image,status) Values(@username,@password,@address,@email,@contact,@province,@district,@portfolio,@accesslvl,@cnic,@country,@name,@image,@status)  ";

            }
            else
            {
                sqlStmt = "insert into login_table (username,password,address,email,contact,province,district,portfolio,accesslvl,cnic,country,name,image,status,school) Values(@username,@password,@address,@email,@contact,@province,@district,@portfolio,@accesslvl,@cnic,@country,@name,@image,@status,@school)  ";

            }

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
                    /* if(ddl_portfolio.SelectedIndex == 1)
                     {
                         status = "Active";
                     }

                     else
                     {
                         status = "InActive";
                     }

                     */
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
                        //    cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
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
                        cmd.Parameters["@status"].Value = status;
                        cmd.Parameters["@school"].Value = ddl_school.SelectedItem.Text;


                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            message.Text = "Thanks For Registration! Registration Succesfully";
                            StringBuilder strBody = new StringBuilder();

                            strBody.Append("Dear '" + tb_name.Text + "', \n\nThank you for your Registration as " + ddl_portfolio.SelectedItem.Text + " on A Blessed Society. \n\nYour invaluable contribution will help us provide long - term support to our Orphan Brothers and Sisters. \n\nFor Queries(If any), please email info@abs.edu.pk or call +92332-9555200. \n\nSincerely, \nThe ABS Team \nKhayaban-e-JoharH 9/4 H-9, Islamabad \nIslamabad Capital Territory 44000 \nTelephone: +923229555200 | info@abs.edu.pk ");

                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@abs.edu.pk", tb_email.Text, "Thank You for Registration on ABS", strBody.ToString());

                            System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@abs.edu.pk", "sultan999@abs.edu.pk");

                            System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("www.abs.edu.pk");
                            mailclient.EnableSsl = true;
                            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                            {
                                return true;
                            };
                            mailclient.UseDefaultCredentials = false;
                            mailclient.Credentials = mailAuthenticaion;
                            mailclient.Send(mail);

                            Response.Redirect("Guide.aspx?id=1");
                        }
                        else
                        {
                            message.Style.Add("color", "red");
                            message.Text = "Error! Try Again";

                        }

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

        protected void login_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }

        protected void ddl_portfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_portfolio.SelectedItem.Text == "Principal")
            {

                addbtn.Visible = false;
                tb_school.Visible = false;
                lb_sch.Visible = false;
                schlb.Visible = true;
                ddl_school.Visible = true;
                add.Visible = true;
            }
            else
            {
                addbtn.Visible = false;
                tb_school.Visible = false;
                lb_sch.Visible = false;
                schlb.Visible = false;
                ddl_school.Visible = false;
                add.Visible = false;
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

        protected void add_Click(object sender, EventArgs e)
        {
            addbtn.Visible = true;
            tb_school.Visible = true;
            lb_sch.Visible = true;
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            cn.Open();
            string sqlStmt1 = "insert into school (country,province,district,schoolname,ucid) Values(@country,@province,@district,@schoolname,@ucid)";
            SqlCommand cmd1 = new SqlCommand(sqlStmt1, cn);

            cmd1.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
            cmd1.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
            cmd1.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
            //   cmd1.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
            //   cmd1.Parameters.Add(new SqlParameter("@uc", SqlDbType.VarChar, 50));
            cmd1.Parameters.Add(new SqlParameter("@schoolname", SqlDbType.VarChar, 50));
            cmd1.Parameters.Add(new SqlParameter("@ucid", SqlDbType.Int));

            cmd1.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
            cmd1.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
            cmd1.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
            //     cmd1.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
            //     cmd1.Parameters["@uc"].Value = ddl_uc.SelectedItem.Text;
            cmd1.Parameters["@schoolname"].Value = tb_school.Text;
            cmd1.Parameters["@ucid"].Value = ddl_district.SelectedValue;

            cmd1.ExecuteNonQuery();

            message.Text = "School Inserted Succesfully";
        }
    }
}