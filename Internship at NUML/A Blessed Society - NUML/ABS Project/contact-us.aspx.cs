
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace ABS_Project
{
    public partial class contact_us1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = " Contact Us - ABS";
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            StringBuilder strBody = new StringBuilder();

            strBody.Append("ABS Support Email From User. \n Email From: " + email_tb.Text + " \n Name is:  " + name_tb.Text + " \n Message is: " + message_tb.Text + "\n Regards : " + name_tb.Text);

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@abs.edu.pk", "admin@abs.edu.pk", "Customer Query", strBody.ToString());

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


            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();
            try
            {
                sqlStmt = "insert into contact (email,name,message,replystatus) Values (@email,@name,@message,@replystatus)";

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                cmd = new SqlCommand(sqlStmt, cn);
                cn.Open();

                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.VarChar, 5000));
                cmd.Parameters.Add(new SqlParameter("@replystatus", SqlDbType.Int));


                cmd.Parameters["@email"].Value = email_tb.Text;
                cmd.Parameters["@name"].Value = name_tb.Text;
                cmd.Parameters["@message"].Value = message_tb.Text;
                cmd.Parameters["@replystatus"].Value = 0;



                cmd.ExecuteNonQuery();

                message.Text = "Mail Sent Succesfully";
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