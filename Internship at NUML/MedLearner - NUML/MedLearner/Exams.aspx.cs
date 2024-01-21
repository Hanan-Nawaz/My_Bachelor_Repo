using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class Exams : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Exams - MedLearner";

            if (!IsPostBack)
            {
                BindDataList();
            }
        }

        void BindDataList()
        {
            SqlCommand cmd = new SqlCommand("select * from Exams Join Courses ON Exams.CourseId = Courses.Id  ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtBrands = new DataTable();
            sda.Fill(dtBrands);
            RepeaterExams.DataSource = dtBrands;
            RepeaterExams.DataBind();

        }


        protected void ddlExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlExamType.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("select * from Courses Join Exams ON Courses.Id = Exams.CourseId where Exams.ExamType='Question Bank'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtBrands = new DataTable();
                sda.Fill(dtBrands);
                RepeaterExams.DataSource = dtBrands;
                RepeaterExams.DataBind();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Courses Join Exams ON Courses.Id = Exams.CourseId and Exams.ExamType='Mock Exam'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtBrands = new DataTable();
                sda.Fill(dtBrands);
                RepeaterExams.DataSource = dtBrands;
                RepeaterExams.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Courses Join Exams ON Courses.Id = Price.CourseId and  Exams.ExamType='" + ddlExamType.SelectedItem.Text + "' and Courses.Name like '%" + txtSearch.Text + "%'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtBrands = new DataTable();
            sda.Fill(dtBrands);
            RepeaterExams.DataSource = dtBrands;
            RepeaterExams.DataBind();
        }
    }
}