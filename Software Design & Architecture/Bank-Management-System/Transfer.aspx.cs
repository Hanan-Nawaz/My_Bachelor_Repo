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

namespace SDA_Project
{
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();

                string Query = "select * from Accounts where AccountNumber=" + Convert.ToInt32(Session["AccountNumber"]);

                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    tb_Currentamount.Text = reader1["Amount"].ToString();
                    break;
                }


                reader1.Close();
            }
        }

        protected void Transfer_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

           

            if (Convert.ToInt32(tb_amount.Text) == 0)
            {
                message.Text = "Invalid Amount!";

            }
            else if(Convert.ToInt32(tb_amount.Text) > Convert.ToInt32(tb_Currentamount.Text))
            {
                message.Text = "Low Balance!";
            }
            else
            {
            string sqlStmt = "update Accounts set Amount=@Amount  where AccountNumber='" + Convert.ToInt32(Session["AccountNumber"]) + "'";
            SqlCommand cmd;
            cmd = new SqlCommand(sqlStmt, con);

            cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.VarChar, 50));

            int leftamount =   Convert.ToInt32(tb_Currentamount.Text) - Convert.ToInt32(tb_amount.Text);

            cmd.Parameters["@Amount"].Value = leftamount;



            int i = cmd.ExecuteNonQuery();

                string Query = "select * from Accounts where AccountNumber=" + tb_number.Text;

                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    Session["CurrentAmount"] = reader1["Amount"].ToString();
                    break;
                }

                int addamount = Convert.ToInt32(Session["CurrentAmount"]) +  Convert.ToInt32(tb_amount.Text);


                reader1.Close();

                string sqlStmt1 = "update Accounts set Amount=@Amount  where AccountNumber='" + tb_number.Text + "'";
                SqlCommand cmd2;
                cmd2 = new SqlCommand(sqlStmt1, con);

                cmd2.Parameters.Add(new SqlParameter("@Amount", SqlDbType.VarChar, 50));


                cmd2.Parameters["@Amount"].Value = addamount;



                int j = cmd2.ExecuteNonQuery();

                if (i > 0 && j > 0)
            {
                    message.Text = "Trancation Successfull!";

                    StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear '" + Session["Name"].ToString() + "'\n\n Pakistani Rupees '" + tb_amount.Text + "' have been withdrawn from your Account('" + Session["AccountNumber"].ToString()  + "'). For Any query related to Transcation. Please Contact US. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", Session["Email"].ToString(), "Transcation Alert!", strBody.ToString());

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


                    StringBuilder strBody1 = new StringBuilder();

                    strBody1.Append("Dear Customer\n\n Pakistani Rupees '" + tb_amount.Text + "' have been deposited to your Account('" + tb_number.Text + "'). For Any query related to Transcation. Please Contact US. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                    System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage("admin@hanannawaz.com", tb_email.Text , "Transcation Alert!", strBody.ToString());

                    System.Net.NetworkCredential mailAuthenticaion1 = new System.Net.NetworkCredential("admin@hanannawaz.com", "hanannawaz0@gmail.com");

                    System.Net.Mail.SmtpClient mailclient1 = new System.Net.Mail.SmtpClient("hanannawaz.com");
                    mailclient1.EnableSsl = true;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    mailclient1.UseDefaultCredentials = false;
                    mailclient1.Credentials = mailAuthenticaion1;
                    mailclient1.Send(mail1);
                }
            }
        }
    }
}