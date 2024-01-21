using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace MedLearner
{
    public partial class details : System.Web.UI.Page
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
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";


            Id = Request.QueryString["CId"];
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Courses join Price on Courses.ID='" + Convert.ToInt32(Id) +  "' and Courses.Id=Price.CousreId", con);
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();

            if(sqlDataReaderreader.HasRows)
            {
                while(sqlDataReaderreader.Read())
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
                }
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }

            sqlDataReaderreader.Close();

            SqlCommand cmd1 = new SqlCommand("Select * from EnrolledCourse where Uid='" + Session["Email"].ToString() + "'", con);
            SqlDataReader sqlDataReaderreader1 = cmd1.ExecuteReader();

            if (sqlDataReaderreader1.HasRows)
            {
                while (sqlDataReaderreader1.Read())
                {
                    if (Convert.ToInt32(sqlDataReaderreader1["Eid"]) == Convert.ToInt32(Id))
                    {
                        btnEnroll.Text = "Enrolled";
                        btnEnroll.Enabled = false;
                    }
                }
            }

            Page.Title = CourseName + " - MedLearner";

            sqlDataReaderreader1.Close();        

            if (!IsPostBack)
            {
                BindDataListViewable();
                BindDataListDownloadable();
                BindDataListExam();
            }
        }

        void BindDataListViewable()
        {
            SqlCommand cmd = new SqlCommand("select * from Content where CourseId=" + Convert.ToInt32(Id), con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtContent = new DataTable();
            sda.Fill(dtContent);
            Repeatercourses.DataSource = dtContent;
            Repeatercourses.DataBind();
        }

        void BindDataListDownloadable()
        {
            SqlCommand cmd = new SqlCommand("select * from Downloadable where CourseId=" + Convert.ToInt32(Id), con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtDownloadable = new DataTable();
            sda.Fill(dtDownloadable);
            RepeaterDownloadable.DataSource = dtDownloadable;
            RepeaterDownloadable.DataBind();
        }

        void BindDataListExam()
        {
            SqlCommand cmd = new SqlCommand("select * from Exams where CourseId=" + Convert.ToInt32(Id), con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtExam = new DataTable();
            sda.Fill(dtExam);
            RepeaterExam.DataSource = dtExam;
            RepeaterExam.DataBind();
        }


        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Session["Price_To_Pay"] = priceToPay;
            Session["CourseName"] = CourseName;
            Session["Currency"] = currency;
            Session["Course_ID"] = Id;
            Session["Course_Details"] = "Purchasing Full Course";
            Session["Type"] = "Course";
            Response.Redirect("/Checkout.aspx");
        }


    }
}