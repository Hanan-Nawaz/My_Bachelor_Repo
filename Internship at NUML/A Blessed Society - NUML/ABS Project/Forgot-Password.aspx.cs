using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class forgorpassw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string uniqueCode = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("select * from login_table where email=@email And cnic=@cnic", con);

                cmd.Parameters.AddWithValue("@email", Convert.ToString(tb_username.Text.Trim()));
                cmd.Parameters.AddWithValue("@cnic", Convert.ToString(tb_cnic.Text.Trim()));

                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();

                    uniqueCode = Convert.ToString(System.Guid.NewGuid());

                    cmd = new SqlCommand("update login_table set uniqueCode=@uniqueCode where email=@email And cnic=@cnic", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", uniqueCode);
                    cmd.Parameters.AddWithValue("@email", tb_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@cnic", tb_cnic.Text.Trim());

                    StringBuilder strBody = new StringBuilder();

                    strBody.Append("Dear User \n\nYour Password Reset Link is \n\n<a href=https://abs.edu.pk/Reset-password.aspx?email=" + tb_username.Text + "&cnic=" + tb_cnic.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a> \n\nRegards ABS");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@abs.edu.pk", dr["email"].ToString(), "Reset Your Password", strBody.ToString());
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
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    con.Close();
                    message.Text = "Reset password link has been sent to your email address";
                    tb_username.Text = string.Empty;
                }
                else
                {
                    message.Style.Add("color", "red");
                    message.Text = "Please enter valid Email address and Cnic";
                    tb_username.Text = string.Empty;
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                message.Text = "Error Occured: " + ex.Message.ToString();

            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}