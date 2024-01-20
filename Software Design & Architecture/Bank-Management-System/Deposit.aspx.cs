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
    public partial class Deposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int accesslvl = Convert.ToInt32(Session["Accesslvl"]);

            if (Session["Email"] == null && accesslvl == 1)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Depositbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();



            if (Convert.ToInt32(tb_amount.Text) == 0)
            {
                message.Text = "Invalid Amount!";

            }
            
            else
            {

                string Query = "select * from Accounts where AccountNumber=" + tb_account.Text;

                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    Session["CAmount"] = reader1["Amount"].ToString();

                    break;
                }


                reader1.Close();

                string sqlStmt = "update Accounts set Amount=@Amount  where AccountNumber='" + tb_account.Text + "'";
                SqlCommand cmd;
                cmd = new SqlCommand(sqlStmt, con);

                cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.VarChar, 50));

                int leftamount = Convert.ToInt32(Session["CAmount"]) + Convert.ToInt32(tb_amount.Text);

                cmd.Parameters["@Amount"].Value = leftamount;



                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    message.Text = "Trancation Successfull!";

                    StringBuilder strBody = new StringBuilder();

                    strBody.Append("Dear '" + tb_name.Text + "'\n\n Pakistani Rupees '" + tb_amount.Text + "' have been Deposited to your Account('" + tb_account.Text + "'). For Any query related to Transcation. Please Contact US. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", tb_email.Text , "Transcation Alert!", strBody.ToString());

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
                }
            }
        }
    }
}