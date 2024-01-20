using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class Open_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_open_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string sqlStmt = "insert into Accounts (AccountNumber,Email,Name,Cnic,FatherName,JobType,Salary,Type,Amount,Picture,Password,Status,Address) Values(@AccountNumber,@Email,@Name,@Cnic,@FatherName,@JobType,@Salary,@Type,@Amount,@Picture,@Password,@Status,@Address)  ";
            SqlCommand cmd;
            cmd = new SqlCommand(sqlStmt, con);

            string filename = Path.GetFileName(image_upload.PostedFile.FileName);
            string filePath = "~/Images/" + filename;
            image_upload.PostedFile.SaveAs(Server.MapPath(filePath));

            cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Cnic", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@JobType", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Salary", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 50));

            Random random = new Random();
            int num = random.Next(1, 1000000);

            cmd.Parameters["@AccountNumber"].Value = num;
            cmd.Parameters["@Email"].Value = tb_username.Text;
            cmd.Parameters["@Name"].Value = tb_name.Text;
            cmd.Parameters["@Cnic"].Value = tb_cnic.Text;
            cmd.Parameters["@FatherName"].Value = tb_fname.Text;
            cmd.Parameters["@JobType"].Value = ddl_jobtype.SelectedItem.Text;
            cmd.Parameters["@Salary"].Value = tb_salary.Text;
            cmd.Parameters["@Type"].Value = ddl_type.SelectedItem.Text;
            cmd.Parameters["@Amount"].Value = tb_amount.Text;
            cmd.Parameters.AddWithValue("@Picture", filePath);
            cmd.Parameters["@Password"].Value = tb_password.Text;
            cmd.Parameters["@Status"].Value = "InActive";
            cmd.Parameters["@Address"].Value = tb_address.Text;

            int i =  cmd.ExecuteNonQuery();

            if (i > 0)
            {
                message.Text = "Your Request for Opening Account in Bank of Numl Received";

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear'" + tb_name.Text + "'\n\nYour Account Opening Request have been received at Bank of NUML. We are thankful to you and Thanking you for Choosing Bank of NUML. We Receive millions of request daily. We will reach you within 1-7 working days with our decision after reviewing your Request. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", tb_username.Text, "Account Opening Request", strBody.ToString());

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