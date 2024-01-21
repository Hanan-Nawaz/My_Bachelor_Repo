using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ABS_Project
{
    public partial class viewbenificary : System.Web.UI.Page
    {
        int ID;
        int volid;
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

                string id = Request.QueryString["ID"];
                ID = Convert.ToInt32(id);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
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
                    volid = Convert.ToInt32(reader["volid"]);
                    break;

                }
                reader.Close();

                string qry1 = "SELECT * from login_table WHERE Id=" + volid;
                SqlCommand cmd1 = new SqlCommand(qry1, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    tb_vol_name.Text = Convert.ToString(reader1["name"]);
                    tb_vol_contact.Text = Convert.ToString(reader1["email"]);
                    tb_number.Text = Convert.ToString(reader1["contact"]);
                    tb_cnic_vol.Text = Convert.ToString(reader1["cnic"]);
                    img_vol_pic.ImageUrl = Convert.ToString(reader1["image"]);
                    break;
                }
            }

        }




        protected void btn_save_Click(object sender, EventArgs e)
        {


            int donorid = Convert.ToInt32(Session["Id"]);


            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();


            try
            {
                sqlStmt = "insert into link (donor_id,name,fathername,gaurdianname,address,gaurdianemail,gaurdiancontact,school,country,province,district,needs,volid,benid,cnic) Values(@donor_id,@name,@fathername,@gaurdianname,@address,@gaurdianemail,@gaurdiancontact,@school,@country,@province,@district,@needs,@volid,@benid,@cnic)";

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                cmd = new SqlCommand(sqlStmt, cn);
                cn.Open();

                cmd.Parameters.Add(new SqlParameter("@donor_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@fathername", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@gaurdianname", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 300));
                cmd.Parameters.Add(new SqlParameter("@gaurdianemail", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@gaurdiancontact", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@province", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 50));
                // cmd.Parameters.Add(new SqlParameter("@tehsil", SqlDbType.VarChar, 50));
                //  cmd.Parameters.Add(new SqlParameter("@unioncouncil", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@needs", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@volid", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@benid", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@cnic", SqlDbType.VarChar, 50));


                cmd.Parameters["@donor_id"].Value = Convert.ToInt32(Session["Id"]);
                cmd.Parameters["@name"].Value = tb_name.Text;
                cmd.Parameters["@fathername"].Value = tb_fathername.Text;
                cmd.Parameters["@gaurdianname"].Value = tb_gaurdianname.Text;
                cmd.Parameters["@country"].Value = ddl_country.SelectedItem.Text;
                cmd.Parameters["@address"].Value = tb_address.Text;
                cmd.Parameters["@gaurdianemail"].Value = tb_gaurdianemail.Text;
                cmd.Parameters["@gaurdiancontact"].Value = tb_contact.Text;
                cmd.Parameters["@school"].Value = ddl_school.SelectedItem.Text;
                cmd.Parameters["@province"].Value = ddl_province.SelectedItem.Text;
                cmd.Parameters["@district"].Value = ddl_district.SelectedItem.Text;
                //   cmd.Parameters["@tehsil"].Value = ddl_tehsil.SelectedItem.Text;
                //   cmd.Parameters["@unioncouncil"].Value = ddl_uc.SelectedItem.Text;
                cmd.Parameters["@needs"].Value = tb_needs.Text;
                cmd.Parameters["@volid"].Value = volid;
                cmd.Parameters["@benid"].Value = ID;
                cmd.Parameters["@cnic"].Value = tb_cnic.Text;

                int i = cmd.ExecuteNonQuery();

                if( i > 0)
                {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear '" + Convert.ToString(Session["name"]) + "', \n\nThank you for your invalueable Donation. \n\nMay Allah Almighty reward you for your Contribution. \n\nIf you have any queries, please email info@abs.edu.pk or call +92332-9555200. \n\nRemain Always Blessed, \nThe ABS Team \nKhayaban-e-Johar H 9/4 H-9, Islamabad \nIslamabad Capital Territory 44000 \nTelephone: +923229555200 | info@abs.edu.pk ");

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(Convert.ToString(Session["sendingmail"]), Convert.ToString(Session["email"]), "Thank You for Your Recent Donation", strBody.ToString());

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


                StringBuilder strBody1 = new StringBuilder();

                strBody1.Append("Dear '" + tb_vol_name.Text + "', \n\n Donation to Benificary You Registered. \n\n Benificary Name: " + tb_name.Text + " \n Benificary Contact: " + tb_contact.Text + "\n Needs: " + tb_needs.Text + " \n\n Donor Name: " + Convert.ToString(Session["name"]) + "\n Donor Email : " + Convert.ToString(Session["email"]) + "\n\n For more details, Contact Donor. \n\nFor Queries(If any), please email info@abs.edu.pk or call +92332-9555200. \n\nSincerely, \nThe ABS Team \nKhayaban-e-JoharH 9/4 H-9, Islamabad \nIslamabad Capital Territory 44000 \nTelephone: +923229555200 | info@abs.edu.pk ");


                System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage(Convert.ToString(Session["sendingmail"]), tb_vol_contact.Text, "Alert About Recent Donation", strBody1.ToString());

                System.Net.NetworkCredential mailAuthenticaion1 = new System.Net.NetworkCredential("admin@abs.edu.pk", "sultan999@abs.edu.pk");

                System.Net.Mail.SmtpClient mailclient1 = new System.Net.Mail.SmtpClient("www.abs.edu.pk");
                mailclient1.EnableSsl = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                mailclient1.UseDefaultCredentials = false;
                mailclient1.Credentials = mailAuthenticaion1;
                mailclient1.Send(mail1);

                string update = "Update benificary_table set status=@status where Id=" + ID;
                SqlCommand cmd1 = new SqlCommand(update, cn);

                cmd1.Parameters.AddWithValue("@status", "InActive");

                cmd1.ExecuteNonQuery();
                cn.Close();

                message.Text = "Linked Succesfully";
                }
                else
                {
                    message.Style.Add("color", "red");
                    message.Text = "Error! Try Again";

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