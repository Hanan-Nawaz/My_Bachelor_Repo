using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Windows;

namespace SDA_Project
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnforgot_Click(object sender, EventArgs e)
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

                cmd = new SqlCommand("select * from Accounts where Email=@Email", con);

                cmd.Parameters.AddWithValue("@Email", Convert.ToString(tb_email.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();

                    uniqueCode = Convert.ToString(System.Guid.NewGuid());

                    cmd = new SqlCommand("update Accounts set Uniquecode=@Uniquecode where Email=@Email", con);
                    cmd.Parameters.AddWithValue("@Uniquecode", uniqueCode);
                    cmd.Parameters.AddWithValue("@Email", tb_email.Text.Trim());

                    StringBuilder strBody = new StringBuilder();

                    strBody.Append("Bank of NUML \nPassword Reset Link \n<a href=http://msms.numl.edu.pk/Reset-password.aspx?username=" + tb_email.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a> \n\nRegards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nbankofnuml@gmail.com");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", dr["Email"].ToString(), "Reset your Password", strBody.ToString());

                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@hanannawaz.com", "hanannawaz0@gmail.com");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("hanannawaz.com");
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
                    tb_email.Text = string.Empty;
                }
                else
                {
                    message.Style.Add("color", "red");
                    message.Text = "Please enter valid Email address ";
                    tb_email.Text = string.Empty;
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