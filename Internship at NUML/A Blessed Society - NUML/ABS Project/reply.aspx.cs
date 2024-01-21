using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace ABS_Project
{
    public partial class reply : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            string email = Request.QueryString["email"];
            tb_email.Text = email;

            int accesslvl = Convert.ToInt32(Session["accesslvl"]);
            Session.Timeout = 60;

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");




            }
            else if (accesslvl == 1 || accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btn_reply_Click(object sender, EventArgs e)
        {


            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();
            try
            {
                sqlStmt = "update contact set replystatus=1 where email='" + tb_email.Text + "' and replystatus=0";

                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                cmd = new SqlCommand(sqlStmt, cn);
                cn.Open();


                StringBuilder strBody = new StringBuilder();

                strBody.Append(tb_message.Text);

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(Convert.ToString(Session["sendingmail"]), tb_email.Text, tb_subject.Text, strBody.ToString());

                System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential(Convert.ToString(Session["sendingmail"]), "F4D1FAA6");

                System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.UseDefaultCredentials = false;
                mailclient.Credentials = mailAuthenticaion;
                mailclient.Send(mail);

                cmd.ExecuteNonQuery();

                message.InnerText = "Mail Sent Succesfully";
            }
            catch (Exception ex)
            {
                message.InnerText = ex.Message;
            }
            finally
            {
                cn.Close();

            }




        }
    }
}