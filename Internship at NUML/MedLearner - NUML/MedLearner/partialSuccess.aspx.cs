using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class partialSuccess : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                Id = Convert.ToInt32(Session["boughtCourse"]);
                Price = Session["boughtCoursePrice"].ToString();
                Currency = Session["boughtCourseCurrency"].ToString();
                paymentMethod = Session["boughtCoursepaymentMethod"].ToString();
                Type = Session["boughtType"].ToString();

                payVerify = Convert.ToInt32(Session["payVerify"]);
                if (payVerify == 0)
                {
                    PayVerify = "paid";
                }
                else
                {
                    PayVerify = "Not paid";
                }

                sqlConnection.Open();
                String Query = "Insert into EnrolledCourse values('" + Id + "',  '" + DateTime.Now + "', '" + Price + "','" + Currency + "', '" + paymentMethod + "', '" + Type + "', '" + PayVerify + "', '" + Session["Email"].ToString() + "')";


                SqlCommand command = new SqlCommand(Query, sqlConnection);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("support@medskillz.com");
                    mailMessage.To.Add(Session["Email"].ToString());
                    mailMessage.Subject = "Complete Your Payment to Start Learning with MedLearner";
                    mailMessage.Body = "Dear '" + Session["Name"].ToString() + "',\r\n\r\nWe hope this email finds you well. We wanted to remind you that you have purchased the '" + Session["boughtCourseName"].ToString() + "'  course on MedLearner, but we have yet to receive the full payment for the course.\r\n\r\nWe are thrilled that you have chosen MedLearner as your medical learning partner, and we look forward to helping you achieve your professional goals through our courses. To get started with the '" + Session["boughtCourseName"].ToString() + "'  course, we request you to complete the payment as soon as possible.\r\n\r\nOnce we receive the full payment for the course, we will enroll you in the course, and you can start learning right away. The  '" + Session["boughtCourseName"].ToString() + "'  is designed to provide you with a comprehensive understanding. Our team of experts has developed the course content, which includes interactive lessons, quizzes, case studies, and assessments. The course is designed to be self-paced, and you can access it from anywhere, at any time, and on any device.\r\n\r\nIf you have any questions or concerns about the payment process or the course, please do not hesitate to contact our customer support team. We are always here to help you.\r\n\r\nWe hope to receive your payment soon so that you can start your learning journey with MedLearner.\r\n\r\nBest regards,\r\nThe MedLearner Team";
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

                    Session["boughtCourse"] = null;
                    Session["boughtCoursePrice"] = null;
                    Session["boughtCourseCurrency"] = null;
                    Session["boughtCoursepaymentMethod"] = null;
                    Session["boughtType"] = null;
                }
                else
                {
                    Page_Load(sender, e);
                }
            }

        }
    }
}