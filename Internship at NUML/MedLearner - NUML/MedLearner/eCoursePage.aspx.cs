using Stripe;
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
    public partial class eCoursePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string TutorEmail = "";
        string CourseName = "";
        string Id;
        public string domainName = "https://localhost:44343/";
        protected void Page_Load(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";


            Id = Request.QueryString["CId"];
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Courses, EnrolledCourse where EnrolledCourse.ID='" + Convert.ToInt32(Id) + "' and EnrolledCourse.Eid = Courses.Id", con);
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();

            if (sqlDataReaderreader.HasRows)
            {
                while (sqlDataReaderreader.Read())
                {
                    h1CourseName.InnerText = sqlDataReaderreader["Name"].ToString();
                    lblCourseName.InnerText = sqlDataReaderreader["Name"].ToString();
                    CourseName = sqlDataReaderreader["Name"].ToString();
                    h6TutorName.InnerText = "Taught by : " + sqlDataReaderreader["TutorName"].ToString();
                    pDescription.InnerText = sqlDataReaderreader["Description"].ToString();
                    TutorEmail = sqlDataReaderreader["TutorEmail"].ToString();
                }
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }

            sqlDataReaderreader.Close();

            

            Page.Title = CourseName + " - MedLearner";


            if (!IsPostBack)
            {
                BindDataListViewable();
                BindDataListDownloadable();
                BindDataListExam();
            }
        }

        void BindDataListViewable()
        {
            SqlCommand cmd = new SqlCommand("select * from Content,EnrolledCourse where EnrolledCourse.Id='" + Convert.ToInt32(Id) + "' and EnrolledCourse.Eid=Content.CourseId" , con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtContent = new DataTable();
            sda.Fill(dtContent);
            Repeatercourses.DataSource = dtContent;
            Repeatercourses.DataBind();
        }

        void BindDataListDownloadable()
        {
            SqlCommand cmd = new SqlCommand("select * from Downloadable ,EnrolledCourse where EnrolledCourse.Id='" + Convert.ToInt32(Id) + "' and EnrolledCourse.Eid=Downloadable.CourseId", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtDownloadable = new DataTable();
            sda.Fill(dtDownloadable);
            RepeaterDownloadable.DataSource = dtDownloadable;
            RepeaterDownloadable.DataBind();
        }

        void BindDataListExam()
        {
            SqlCommand cmd = new SqlCommand("select * from Exams ,EnrolledCourse where EnrolledCourse.Id='" + Convert.ToInt32(Id) + "' and EnrolledCourse.Eid=Exams.CourseId", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtExam = new DataTable();
            sda.Fill(dtExam);
            RepeaterExam.DataSource = dtExam;
            RepeaterExam.DataBind();
        }


     

    }
}