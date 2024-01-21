using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class detailsExams : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string TutorEmail = "";
        string CourseName = "";
        string Id;
        long priceToPay;
        string currency;
        public string domainName = "https://localhost:44343/";
        protected void Page_Load(object sender, EventArgs e)
        {


            Id = Request.QueryString["CId"];
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Courses inner join Exams on Exams.ID='" + Convert.ToInt32(Id) + "' and Courses.Id=Exams.CourseId", con);
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();

            if (sqlDataReaderreader.HasRows)
            {
                while (sqlDataReaderreader.Read())
                {
                    h1CourseName.InnerText = sqlDataReaderreader["Name"].ToString();
                    lblCourseName.InnerText = sqlDataReaderreader["Name"].ToString();
                    CourseName = sqlDataReaderreader["Name"].ToString();
                    h6TutorName.InnerText = "Taught by : " + sqlDataReaderreader["TutorName"].ToString();
                    h6Money.InnerText = "Price : " + sqlDataReaderreader["Price"].ToString() + " " + sqlDataReaderreader["Currency"].ToString();
                    priceToPay = Convert.ToInt64(sqlDataReaderreader["Price"]) * 100;
                    currency = sqlDataReaderreader["Currency"].ToString();
                    pDescription.InnerText = sqlDataReaderreader["Description"].ToString();
                    TutorEmail = sqlDataReaderreader["TutorEmail"].ToString();
                    pinstruction.InnerText = sqlDataReaderreader["Instructions"].ToString();
                }
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }

            Page.Title = CourseName + " - MedLearner";

            
            sqlDataReaderreader.Close();

           
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Session["Price_To_Pay"] = priceToPay;
            Session["CourseName"] = CourseName;
            Session["Currency"] = currency;
            Session["Course_ID"] = Id;
            Session["Course_Details"] = "Purchasing Exam only";
            Session["Type"] = "Exam";
            Response.Redirect("/Checkout.aspx");
        }
    }
}