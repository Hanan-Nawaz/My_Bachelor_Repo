using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using System.Net.Mail;
using System.Net;

namespace MedLearner
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Dashboard - MedLearner";

            alertErrorCourse.Visible = false;
            alertErrorExam.Visible = false;

            if (!IsPostBack)
            {
                BindDataList();
            }
        }

        void BindDataList()
        {
            alertErrorCourse.Visible = false;
            alertErrorExam.Visible = false;
            
            string QueryCourse = "select * from EnrolledCourse, Courses, Price where EnrolledCourse.EId = Courses.Id and Uid='" + Session["Email"].ToString() + "' and EnrolledCourse.Type='" + "Course" + "'  and Courses.Id=Price.CousreId";

            SqlCommand cmd = new SqlCommand(QueryCourse, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtBrands = new DataTable();
            sda.Fill(dtBrands);

            for (int i = 0; i < dtBrands.Rows.Count; i++)
            {
                if (dtBrands.Rows[i][7].ToString() == "Not paid")
                {
                    //spanstatus.InnerText = "Fee Not Paid";
                    dtBrands.Rows[i][0] = 0;
                    
                }
                 if (dtBrands.Rows[i][26].ToString() == "Monthly")
                {
                    if((Convert.ToDateTime(dtBrands.Rows[i][2]) - DateTime.Now.Date) == TimeSpan.FromDays(5))
                    {
                        dtBrands.Rows[i][7] = "Please Pay Monthly Fee";
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("support@medskillz.com");
                        mailMessage.To.Add(dtBrands.Rows[i][8].ToString());
                        mailMessage.Subject = "Urgent Reminder - Monthly Course Fee Payment";
                        mailMessage.Body = "Dear User,\r\n\r\nI hope this email finds you well. We wanted to remind you that your monthly course fee payment is due in less than just 5 days. As a valued member of our community, we wanted to ensure that you have ample time to make the payment before the deadline.\r\n\r\nWe understand that life can get busy and payments can slip our minds, but we kindly request that you prioritize this payment to avoid any interruptions in your learning journey with MedLearner. We have invested a great deal of time and resources to provide you with the best possible educational experience and we wouldn't want you to miss out on any of the opportunities that come with it.\r\n\r\nIf you have already made the payment, please disregard this reminder. However, if you have any concerns or questions regarding the payment process, please do not hesitate to reach out to our support team at support@medskillz.com. We are here to assist you in any way we can.\r\n\r\nThank you for choosing MedLearner as your educational partner. We appreciate your continued support and look forward to seeing you in our classes.\r\n\r\nBest regards,\r\n\r\nMedLearner Team.";

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }

                    if ((Convert.ToDateTime(dtBrands.Rows[i][2]) - DateTime.Now.Date) == TimeSpan.FromDays(1))
                    {
                        dtBrands.Rows[i][7] = "Please Pay Monthly Fee";
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("support@medskillz.com");
                        mailMessage.To.Add(dtBrands.Rows[i][8].ToString());
                        mailMessage.Subject = "Urgent Reminder - Monthly Course Fee Payment";
                        mailMessage.Body = "Dear User,\r\n\r\nI hope this email finds you well. We wanted to remind you that your monthly course fee payment is due in just 1 day. As a valued member of our community, we wanted to ensure that you have ample time to make the payment before the deadline.\r\n\r\nWe understand that life can get busy and payments can slip our minds, but we kindly request that you prioritize this payment to avoid any interruptions in your learning journey with MedLearner. We have invested a great deal of time and resources to provide you with the best possible educational experience and we wouldn't want you to miss out on any of the opportunities that come with it.\r\n\r\nIf you have already made the payment, please disregard this reminder. However, if you have any concerns or questions regarding the payment process, please do not hesitate to reach out to our support team at support@medskillz.com. We are here to assist you in any way we can.\r\n\r\nThank you for choosing MedLearner as your educational partner. We appreciate your continued support and look forward to seeing you in our classes.\r\n\r\nBest regards,\r\n\r\nMedLearner Team.";

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    if ((Convert.ToDateTime(dtBrands.Rows[i][2]) == DateTime.Now.Date))
                    {
                        dtBrands.Rows[i][7] = "Please Pay Monthly Fee";
                        dtBrands.Rows[i][0] = 0;


                        dtBrands.Rows[i][7] = "Please Pay Monthly Fee";
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("support@medskillz.com");
                        mailMessage.To.Add(dtBrands.Rows[i][8].ToString());
                        mailMessage.Subject = "Termination of Course Access Due to Unpaid Monthly Course Fee";
                        mailMessage.Body = "We hope this email finds you well. It is with regret that we inform you that your access to our courses has been terminated due to non-payment of your monthly course fee. Our records indicate that your payment was due and despite our reminders, the payment remains outstanding.\r\n\r\nWe understand that life can get busy and financial situations can be unpredictable, but we kindly request that you prioritize this payment to avoid any interruptions in your learning journey with MedLearner. We have invested a great deal of time and resources to provide you with the best possible educational experience, and it is unfortunate that we had to terminate your access due to non-payment.\r\n\r\nWe encourage you to settle the outstanding payment as soon as possible to regain access to our courses and continue your learning journey. Once the payment is made, your access will be reinstated, and you will be able to resume your progress right where you left off.\r\n\r\nIf you have any concerns or questions regarding the payment process, please do not hesitate to reach out to our support team at support@medlearner.com. We are here to assist you in any way we can.\r\n\r\nThank you for choosing MedLearner as your educational partner. We hope to see you back in our courses soon.\r\n\r\nBest regards,\r\n\r\nMedLearner Team.";

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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
                }
            

            if (dtBrands.Rows.Count == 0)
            {
                alertErrorCourse.Visible = true;
            }
            else
            {
                alertErrorCourse.Visible = false;
            }
            Repeatercourses.DataSource = dtBrands;
            Repeatercourses.DataBind();


            string QueryExam = "select * from EnrolledCourse, Exams, Courses Where EnrolledCourse.EId = Exams.Id and Exams.CourseId = Courses.Id and Uid='" + Session["Email"].ToString() + "' and EnrolledCourse.Type='" + "Exam" + "'";
            SqlCommand cmd1 = new SqlCommand(QueryExam, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

            DataTable dtBrands1 = new DataTable();
            sda1.Fill(dtBrands1);


            for (int i = 0; i < dtBrands1.Rows.Count; i++)
            {
                if (dtBrands1.Rows[i][7].ToString() == "Not paid")
                {
                    dtBrands1.Rows[i][7] = "Fee Not Paid";
                    dtBrands1.Rows[i][0] = 0;

                }
                else
                {
                    dtBrands1.Rows[i][7] = "Enrolled";
                }
            }

            if (dtBrands1.Rows.Count == 0)
            {
                alertErrorExam.Visible = true;
            }
            else
            {
                alertErrorExam.Visible = false;
            }
            RepeaterExams.DataSource = dtBrands1;
            RepeaterExams.DataBind();
        }
    }
}