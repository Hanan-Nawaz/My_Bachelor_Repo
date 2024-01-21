using MedLearner.LandingPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MedLearner
{
    public partial class addQuestion : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        DataTable dtExam = new DataTable();
        string Query = "";
        int QuestionType;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Question - MedLearner";

            alertError.Visible = false;
            alertSuccess.Visible = false;

            lblCourseName.InnerText = "Add Question";

            lbQ.Visible = false;
            lb1.Visible = false;
            lb2.Visible = false;
            lb3.Visible = false;
            lb4.Visible = false;
            lbA.Visible = false;
            lbE.Visible = false;
            lb12.Visible = false;
            lb13.Visible = false;

            imgQuestion.Visible = false;
            imgExplanation.Visible = false;
            txtQuestion.Visible = false;
            txtOption1.Visible = false;
            txtOption2.Visible = false;
            txtOption3.Visible = false;
            txtOption4.Visible = false;
            txtAnswer.Visible = false;
            txtExplanation.Visible = false;

            getData();

            if (!Page.IsPostBack)
            {
                FillDropDownlist();
            }
        }

        private DataTable getData()
        {
            string Query = "select * from Exams where TutorEmail='" + Session["Email"].ToString() + "'";
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtExam);

            return dtExam;
        }

        private void FillDropDownlist()
        {
            ddlExam.AppendDataBoundItems = true;
            ddlExam.Items.Clear();
            ddlExam.Items.Add("Select Exam");


            ddlExam.DataSource = dtExam;
            ddlExam.DataTextField = "ExamName";
            ddlExam.DataValueField = "Id";
            ddlExam.DataBind();

        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] rslt = dtExam.Select("Id=" + ddlExam.SelectedValue);

            foreach (DataRow row in rslt)
            {
                if (row["QuestionType"].ToString() == "Mcqs")
                {
                    lbQ.Visible = true;
                    lb1.Visible = true;
                    lb2.Visible = true;
                    lb3.Visible = true;
                    lb4.Visible = true;
                    lbA.Visible = true;
                    lbE.Visible = true;

                    lb12.Visible = true;
                    lb13.Visible = true;
                    imgQuestion.Visible = true;
                    imgExplanation.Visible = true;
                    txtQuestion.Visible = true;
                    txtOption1.Visible = true;
                    txtOption2.Visible = true;
                    txtOption3.Visible = true;
                    txtOption4.Visible = true;
                    txtAnswer.Visible = true;
                    txtExplanation.Visible = true; 
                    Session["QuestionType"] = 1;
                }
                else if (row["QuestionType"].ToString() == "True/False")
                {
                    lbQ.Visible = true;
                    lb1.Visible = false;
                    lb2.Visible = false;
                    lb3.Visible = false;
                    lb4.Visible = false;
                    lbA.Visible = true;
                    lbE.Visible = true;

                    lb12.Visible = true;
                    lb13.Visible = true;
                    imgQuestion.Visible = true;
                    imgExplanation.Visible = true;
                    txtQuestion.Visible = true;
                    txtOption1.Visible = false;
                    txtOption2.Visible = false;
                    txtOption3.Visible = false;
                    txtOption4.Visible = false;
                    txtAnswer.Visible = true;
                    txtExplanation.Visible = true;
                    Session["QuestionType"] = 2;
                }
                else if (row["QuestionType"].ToString() == "SBA(Single Best Answer)")
                {
                    lbQ.Visible = true;
                    lb1.Visible = false;
                    lb2.Visible = false;
                    lb3.Visible = false;
                    lb4.Visible = false;
                    lbA.Visible = false;
                    lbE.Visible = true;

                    lb12.Visible = true;
                    lb13.Visible = true;
                    imgQuestion.Visible = true;
                    imgExplanation.Visible = true;
                    txtQuestion.Visible = true;
                    txtOption1.Visible = false;
                    txtOption2.Visible = false;
                    txtOption3.Visible = false;
                    txtOption4.Visible = false;
                    txtAnswer.Visible = false;
                    txtExplanation.Visible = true;
                    Session["QuestionType"] = 3;
                }
                else
                {
                    lbQ.Visible = true;
                    lb1.Visible = true;
                    lb2.Visible = true;
                    lb3.Visible = true;
                    lb4.Visible = true;
                    lbA.Visible = false;
                    lbE.Visible = true;

                    lb12.Visible = true;
                    lb13.Visible = true;
                    imgQuestion.Visible = true;
                    imgExplanation.Visible = true;
                    txtQuestion.Visible = true;
                    txtOption1.Visible = true;
                    txtOption2.Visible = true;
                    txtOption3.Visible = true;
                    txtOption4.Visible = true;
                    txtAnswer.Visible = true;
                    txtExplanation.Visible = true;
                    Session["QuestionType"] = 4;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            QuestionType = Convert.ToInt32(Session["QuestionType"]);
            sqlConnection.Open();

            if(ddlExam.SelectedItem.Text != "Select Exam")
            {

                string filenameE = Path.GetFileName(imgExplanation.PostedFile.FileName);
                string _filenameE = DateTime.Now.ToString("hhmmssfff") + filenameE;
                string filePathE = _filenameE;
                imgExplanation.PostedFile.SaveAs(Server.MapPath("~/Exams/" + filePathE));

                string filenameQ = Path.GetFileName(imgQuestion.PostedFile.FileName);
                string _filenameQ = DateTime.Now.ToString("hhmmssfff") + filenameQ;
                string filePathQ = _filenameQ;
                imgQuestion.PostedFile.SaveAs(Server.MapPath("~/Exams/" + filePathQ));

                if (QuestionType == 1)
                {
                    Query = "Insert into McqExam values('" + txtQuestion.Text + "', '" + txtOption1.Text + "', '" + txtOption2.Text + "', '" + txtOption3.Text + "', '" + txtOption4.Text + "', '" + txtAnswer.Text + "', '" + txtExplanation.Text + "', '" +  filePathQ + "', '" +  filePathE + "', '" + ddlExam.SelectedValue + "')";
                }
                else if (QuestionType == 4)
                {
                    Query = "Insert into EMQExam values('" + txtQuestion.Text + "', '" + txtOption1.Text + "', '" + txtOption2.Text + "', '" + txtOption3.Text + "', '" + txtOption4.Text + "', '" + txtAnswer.Text + "', '" + txtExplanation.Text + "', '" +  filePathQ + "', '" +  filePathE + "', '" + ddlExam.SelectedValue + "')";
                }
                else if (QuestionType == 2)
                {
                    Query = "Insert into TrueFalseExam values('" + txtQuestion.Text + "',  '" + txtAnswer.Text + "', '" + txtExplanation.Text + "', '" +  filePathQ + "', '" +  filePathE + "', '" + ddlExam.SelectedValue + "')";
                }
                else if (QuestionType == 3)
                {
                    Query = "Insert into SBAExam values('" + txtQuestion.Text + "', '" + txtExplanation.Text + "', '" +  filePathQ + "', '" +  filePathE + "', '" + ddlExam.SelectedValue + "')";
                }

                alertError.Visible = false;
                alertSuccess.Visible = false;

                SqlCommand command = new SqlCommand(Query, sqlConnection);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    alertError.Visible = false;
                    alertSuccess.Visible = true;
                    txtExplanation.Text = null;
                    txtOption1.Text = null;
                    txtOption2.Text = null;
                    txtOption3.Text = null;
                    txtOption4.Text = null;
                    txtQuestion.Text = null;
                    txtAnswer.Text = null;
                    ddlExam.SelectedIndex = 0;
                }
                else
                {
                    alertError.Visible = true;
                    alertSuccess.Visible = false;
                }
            }
            else
            {
                alertError.Visible = true;
                alertSuccess.Visible = false;
            }


        }
    }
}