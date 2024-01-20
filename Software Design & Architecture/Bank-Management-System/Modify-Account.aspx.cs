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

namespace SDA_Project
{
    public partial class Modify_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string Query;

                {
                    Query = "Select * from Accounts where AccountNumber=" + Convert.ToInt32(Session["AccountNumber"]);
                }

                if (!Page.IsPostBack)
                {

                

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                cn.Open();
                SqlCommand cmd1 = new SqlCommand(Query, cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    tb_AccountNumber.Text = reader1["AccountNumber"].ToString();
                    tb_name.Text = reader1["Name"].ToString();
                    tb_email.Text = reader1["Email"].ToString();
                    tb_cnic.Text = reader1["Cnic"].ToString();
                    tb_fname.Text = reader1["FatherName"].ToString();
                    ddl_jobtype.SelectedItem.Text = reader1["JobType"].ToString();
                    tb_salary.Text = reader1["Salary"].ToString();
                    ddl_type.SelectedItem.Text = reader1["Type"].ToString();
                    tb_amount.Text = reader1["Amount"].ToString();
                    sheetpic.ImageUrl = reader1["Picture"].ToString();
                    tb_address.Text = reader1["Address"].ToString();
                    tb_password.Text = reader1["Password"].ToString();

                        break;
                }

                reader1.Close();

                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string sqlStmt = "update Accounts set AccountNumber=@AccountNumber,Email=@Email,Name=@Name,Cnic=@Cnic,FatherName=@FatherName,JobType=@JobType,Salary=@Salary,Type=@Type,Amount=@Amount,Picture=@Picture,Password=@Password,Status=@Status,Address=@Address where AccountNumber=" + Convert.ToInt32(Session["AccountNumber"]);
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

           

            cmd.Parameters["@AccountNumber"].Value = tb_AccountNumber.Text;
            cmd.Parameters["@Email"].Value = tb_email.Text;
            cmd.Parameters["@Name"].Value = tb_name.Text;
            cmd.Parameters["@Cnic"].Value = tb_cnic.Text;
            cmd.Parameters["@FatherName"].Value = tb_fname.Text;
            cmd.Parameters["@JobType"].Value = ddl_jobtype.SelectedItem.Text;
            cmd.Parameters["@Salary"].Value = tb_salary.Text;
            cmd.Parameters["@Type"].Value = ddl_type.SelectedItem.Text;
            cmd.Parameters["@Amount"].Value = tb_amount.Text;
            cmd.Parameters.AddWithValue("@Picture", filePath);
            cmd.Parameters["@Password"].Value = tb_password.Text;
            cmd.Parameters["@Status"].Value = "Updated";
            cmd.Parameters["@Address"].Value = tb_address.Text;

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                message.Text = "Account Updated Successfully";

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear'" + tb_name.Text + "'\n\nYour Account at Bank of NUML is Updated . We are thankful to you and Thanking you for Choosing Bank of NUML. We Receive millions of Updation request daily. We will reach you within 1-7 working days with our decision after reviewing your Request. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");
                 



                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", tb_email.Text, "Account Updation Request", strBody.ToString());

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

                Session["Email"] = null;
                Response.Redirect("Login.aspx");
            }
        }
    }
}