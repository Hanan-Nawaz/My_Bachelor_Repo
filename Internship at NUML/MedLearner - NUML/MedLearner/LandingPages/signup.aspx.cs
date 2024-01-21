using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner.LandingPages
{
    public partial class signup : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Join us - MedLearner";
            alertError.Visible = false;
            alertSuccess.Visible = false;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            alertError.Visible = false;
            alertSuccess.Visible = false;
            sqlConnection.Open();
            string Query = "Insert into Users values('" + txtEmail.Text + "', '" + txtPassword.Text + "', '" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + ddlOccupation.SelectedIndex + "', '" + txtSNum.Text + "', '" + txtAInfo.Text + "', '" + txtZip.Text + "', '" + txtPlace.Text + "', '" + txtCountry.Text + "' , '" + txtCode.Text + txtPhone.Text + "', '" + 0 + "')";
            SqlCommand sqlCommand= new SqlCommand(Query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();

            if(result > 0)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("support@medskillz.com");
                mailMessage.To.Add(txtEmail.Text);
                mailMessage.Subject = "Welcome to MedLearner - Your Medical Learning Partner!";
                mailMessage.Body = "Dear '" + txtFirstName.Text + " " + txtLastName.Text + "',\r\n\r\nWe would like to extend a warm welcome to you and thank you for choosing MedLearner as your medical learning partner. We are thrilled to have you as a part of our community of healthcare professionals and learners.\r\n\r\nMedLearner is a comprehensive online platform designed to provide you with access to the latest medical education resources, courses, and learning tools. Our aim is to help you stay up-to-date with the latest advancements in the medical field, expand your knowledge and skills, and achieve your professional goals.\r\n\r\nWe understand that being a healthcare professional is not an easy task, and we believe that continuous learning and skill-building are essential for providing quality patient care. With MedLearner, you can access a wide range of resources and courses that cater to your unique needs and preferences. Our platform is user-friendly, and our content is developed and curated by leading experts in the healthcare industry.\r\n\r\nAs a new user, we encourage you to explore our platform and make the most of our resources. You can access our courses and exams from anywhere, at any time, and on any device. We are confident that our platform will be an invaluable resource for you throughout your career.\r\n\r\nIf you have any questions, comments, or suggestions, please do not hesitate to contact our customer support team. We are always here to help you.\r\n\r\nOnce again, welcome to MedLearner. We look forward to working with you and supporting your professional growth.\r\n\r\nBest regards,\r\nThe MedLearner Team";

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
                    lblMessage.Text = ex.Message;
                }
                alertError.Visible = false;
                alertSuccess.Visible = true;
            }
            else
            {
                alertError.Visible = true;
                alertSuccess.Visible = false;
            }
        }
    }
}