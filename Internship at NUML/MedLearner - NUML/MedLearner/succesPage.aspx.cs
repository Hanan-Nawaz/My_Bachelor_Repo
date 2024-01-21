using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class succesPage : System.Web.UI.Page
    {
        int Id, payVerify = 0;
        string Price, Currency, paymentMethod, Type, PayVerify;

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Id = Convert.ToInt32(Session["boughtCourse"]);
                Price = Session["boughtCoursePrice"].ToString();
                Currency = Session["boughtCourseCurrency"].ToString();
                paymentMethod = Session["boughtCoursepaymentMethod"].ToString();
                Type = Session["boughtType"].ToString();

                 payVerify = Convert.ToInt32(Session["payVerify"]);
                if(payVerify == 0)
                {
                    PayVerify = "paid";
                }
                else
                {
                    PayVerify = "Not paid";
                }

                sqlConnection.Open();
                String Query = "Insert into EnrolledCourse values('" + Id + "',  '" + DateTime.Now.Date.AddDays(30) + "', '" + Price + "','" + Currency + "', '" + paymentMethod + "', '" + Type  + "', '" + PayVerify + "', '" + Session["Email"].ToString() + "')";


                SqlCommand command = new SqlCommand(Query, sqlConnection);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("support@medskillz.com");
                    mailMessage.To.Add(Session["Email"].ToString());
                    mailMessage.Subject = "Get Started with Your Course on MedLearner";
                    mailMessage.Body = "Dear '" + Session["Name"].ToString() + "',\r\n\r\nThank you for choosing MedLearner as your medical learning partner. We hope this email finds you well. We wanted to take this opportunity to remind you that you have purchased the '" + Session["boughtCourseName"].ToString() + "' course and are now enrolled in it.\r\n\r\nThe '" + Session["boughtCourseName"].ToString() + "' course is designed to provide you with a comprehensive understanding. Our team of experts has developed the course content, which includes interactive lessons, quizzes, case studies, and assessments. The course is designed to be self-paced, and you can access it from anywhere, at any time, and on any device.\r\n\r\nTo get started with your course, please follow these steps:\r\n\r\nLog in to your MedLearner account using your username and password.\r\nNavigate to the \"My Courses\" section.\r\nClick on the '" + Session["boughtCourseName"].ToString() + "'  course to access the course dashboard.\r\nStart with the first module, and work your way through the course content.\r\nWe recommend that you set aside dedicated time for learning, and complete the course at a pace that works for you. We encourage you to take advantage of the interactive lessons, quizzes, and case studies, and engage with other learners in the discussion forums.\r\n\r\nIf you have any questions or concerns, please do not hesitate to contact our customer support team. We are always here to help you.\r\n\r\nWe hope you enjoy the '" + Session["boughtCourseName"].ToString() + "'  course and find it valuable for your professional growth and development.\r\n\r\nBest regards,\r\nThe MedLearner Team";

                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("support@medskillz.com", "medlearner123");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("www.medskillz.com");
                    mailclient.EnableSsl = true;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = mailAuthenticaion;

                    try
                    {
                        mailclient.Send(mailMessage);
                        Console.WriteLine("Email Sent Successfully.");
                        Session["boughtCourse"] = null;
                        Session["boughtCoursePrice"] = null;
                        Session["boughtCourseCurrency"] = null;
                        Session["boughtCoursepaymentMethod"] = null;
                        Session["boughtType"] = null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }
                else
                {
                    Page_Load(sender, e);
                }
            }
          
        }
    }
}