using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using MedLearner.LandingPages;

namespace MedLearner
{
    public partial class addContent : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Query;
        DataTable dtContent, dtCourse;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Content - MedLearner";

            lblCourseName.InnerText = "Add Content ";
            alertError.Visible = false;
            alertSuccess.Visible = false;


            dtContent = new DataTable();
            dtCourse = new DataTable();



            if (!Page.IsPostBack)
            {
                FillGridView();
                FillDropDownlist();
            }
        }

        void FillGridView()
        {
            grdContent.DataSource = dtContent;
            grdContent.DataBind();
        }

        private void FillDropDownlist()
        {
            string Query = "select * from Courses where TutorEmail='" + Session["Email"].ToString() + "'";
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtCourse);
            ddlCourse.DataSource = dtCourse;
            ddlCourse.DataTextField = "Name";
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataBind();
        }
        DataTable getData()
        {
            string Query = "select * from Content where CourseId=" + ddlCourse.SelectedValue;
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtContent);

            return dtContent;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            alertError.Visible = false;
            alertSuccess.Visible = false;

            string filename = Path.GetFileName(img_vid_Upload.PostedFile.FileName);
            string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
            string filePath = _filename;
            img_vid_Upload.PostedFile.SaveAs(Server.MapPath("~/Videos/" + filePath));

           
           string query = "Insert into Content values('" + txtName.Text + "',  '" + txtDescription.Text + "', '" + filePath + "', '" + ddlCourse.SelectedItem.Value + "')";
            

            SqlCommand command = new SqlCommand(query, sqlConnection);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                
                alertError.Visible = false;
                alertSuccess.Visible = true;

                txtDescription.Text = null;
                txtName.Text = null;
                dtContent.Rows.Clear();
                getData();
                FillGridView();
            }
            else
            {
                alertError.Visible = true;
                alertSuccess.Visible = false;

            }

        }
    }
}