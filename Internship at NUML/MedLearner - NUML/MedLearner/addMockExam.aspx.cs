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
    public partial class addMockExam : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Query;
        DataTable dtCourse, dtTag, dtCTag;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Exam - MedLearner";

            lblCourseName.InnerText = "Add Exam";
            txtTutorEmail.Text = Session["Email"].ToString();

            alertError.Visible = false;
            alertSuccess.Visible = false;

            dtCourse = new DataTable();
            dtCTag = new DataTable();
            dtTag = new DataTable();

            if (!Page.IsPostBack)
            {
                FillDropDownlist();
            }
        }

        protected void ddlPTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCTag.AppendDataBoundItems = true;
            ddlCTag.Items.Clear();
            ddlCTag.Items.Add("Select child Tag");

            string QueryTag = "select * from childTag where pTag='" + ddlPTag.SelectedValue + "'";
            SqlDataAdapter adpTag = new SqlDataAdapter(QueryTag, sqlConnection);
            adpTag.Fill(dtCTag);
            ddlCTag.DataSource = dtCTag;
            ddlCTag.DataTextField = "Tag";
            ddlCTag.DataValueField = "Id";
            ddlCTag.DataBind();
        }

        private void FillDropDownlist()
        {

            ddlCourse.AppendDataBoundItems = true;
            ddlCourse.Items.Clear();
            ddlCourse.Items.Add("Select Course");


            ddlPTag.AppendDataBoundItems = true;
            ddlPTag.Items.Clear();
            ddlPTag.Items.Add("Select Parent Tag");

            string Query = "select * from Courses where TutorEmail='" + Session["Email"].ToString() + "'";
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtCourse);
            ddlCourse.DataSource = dtCourse;
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataBind();

            string QueryTag = "select * from parentTag";
            SqlDataAdapter adpTag = new SqlDataAdapter(QueryTag, sqlConnection);
            adpTag.Fill(dtTag);
            ddlPTag.DataSource = dtTag;
            ddlPTag.DataTextField = "Tag";
            ddlPTag.DataValueField = "Id";
            ddlPTag.DataBind();
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            if (ddlCTag.SelectedItem.Text != "Select Child tag" && ddlPTag.SelectedItem.Text != "Select parent tag" && ddlCourse.SelectedItem.Text != "Select Course" &&
                ddlQuestionType.SelectedItem.Text != "Select Question Type" && ddlExamType.SelectedItem.Text != "Select Exam Type" 
                && ddlCurrency.SelectedItem.Text != "Select Currency")
            {
                alertError.Visible = false;
                alertSuccess.Visible = false;
                Query = "Insert into Exams values('" + txtName.Text + "', '" + txtTotalMarks.Text + "', '" + ddlQuestionType.SelectedItem.Text + "', '" + ddlCourse.SelectedItem.Text + "', '" + txtPassingScore.Text + "', '" + txtTimeDuration.Text + "' , '" + txtDInstruction.Text + "', '" + ddlExamType.SelectedItem.Text + "', '" + txtTutorEmail.Text + "' ,'" + txtPrice.Text + "', '" + ddlCurrency.SelectedItem.Text + "', '" + txtDiscountAmount.Text + "', '" + txtCCode.Text + "', '" + ddlPTag.SelectedItem.Text + "', '" + ddlCTag.SelectedItem.Text + "', '" + ddlCourse.SelectedValue + "')";

                SqlCommand command = new SqlCommand(Query, sqlConnection);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    txtDInstruction.Text = null;
                    txtPassingScore.Text = null;
                    txtTimeDuration.Text = null;
                    txtTotalMarks.Text = null;
                    txtName.Text = null;
                    ddlCourse.SelectedIndex = 0;
                    ddlExamType.SelectedIndex = 0;
                    ddlQuestionType.SelectedIndex = 0;
                    alertError.Visible = false;
                    alertSuccess.Visible = true;
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