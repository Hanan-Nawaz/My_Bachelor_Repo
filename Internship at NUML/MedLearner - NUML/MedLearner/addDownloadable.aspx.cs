using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedLearner.LandingPages;

namespace MedLearner
{
    public partial class addDownloadable : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Query;
        DataTable dtDownloadable, dtCourse;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Downloadable Content  - MedLearner";

            lblCourseName.InnerText = "Add Downloadable Content ";

            dtDownloadable = new DataTable();
            dtCourse = new DataTable();

            alertError.Visible = false;
            alertSuccess.Visible = false;

            if (!Page.IsPostBack)
            {
                FillGridView();
                FillDropDownlist();
            }
        }

        void FillGridView()
        {
            grdDownloadable.DataSource = dtDownloadable;
            grdDownloadable.DataBind();
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
            string Query = "select * from Downloadable where CourseId=" + ddlCourse.SelectedValue;
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtDownloadable);

            return dtDownloadable;
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
            img_vid_Upload.PostedFile.SaveAs(Server.MapPath("~/DownloadableContent/" + filePath));


            Query = "Insert into Downloadable values('" + txtName.Text + "',  '" + txtDescription.Text + "', '" + filePath + "', '" + ddlCourse.SelectedValue + "')";


            SqlCommand command = new SqlCommand(Query, sqlConnection);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                alertError.Visible = false;
                alertSuccess.Visible = true;
                txtDescription.Text = null;
                txtName.Text = null;
                dtDownloadable.Rows.Clear();
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