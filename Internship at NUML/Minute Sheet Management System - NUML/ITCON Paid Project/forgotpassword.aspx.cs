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

namespace ITCON_Paid_Project
{
    public partial class forgotpassword1 : System.Web.UI.Page
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

                cmd = new SqlCommand("select * from user_table where UserName=@username", con);

                cmd.Parameters.AddWithValue("@username", Convert.ToString(tb_email.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();

                    uniqueCode = Convert.ToString(System.Guid.NewGuid());

                    cmd = new SqlCommand("update user_table set UniqueCode=@uniqueCode where UserName=@username", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", uniqueCode);
                    cmd.Parameters.AddWithValue("@username", tb_email.Text.Trim());

                    StringBuilder strBody = new StringBuilder();

                    strBody.Append( "\nA Request have been received to change your Account Password. \n   <a href=http://msms.numl.edu.pk/Resetpassword.aspx?username=" + tb_email.Text + "&uCode=" + uniqueCode + ">Reset</a> \n\nRegards \nNational University of Modern Languages \nH - 9 Islamabad, Pakistan \n+ 92 - 51 - 9265100 \ninfo@numl.edu.pk");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("mms-noreply@numl.edu.pk", dr["username"].ToString(), "NUML MSMS Reset Your Password", strBody.ToString());
                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("mms-noreply@numl.edu.pk", "numl@22@02");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("www.numl.edu.pk");
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
                MessageBox.Show(ex.Message);

            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}