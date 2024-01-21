using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class addCourse : System.Web.UI.Page
    {

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Course - MedLearner";

            if (!Page.IsPostBack)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Category", sqlConnection);
                DataTable dtCategory = new DataTable();
                sqlDataAdapter.Fill(dtCategory);
                ddlCategory.DataSource = dtCategory;
                ddlCategory.DataBind();
                ddlCategory.DataValueField = "Category";
                ddlCategory.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            string filename = Path.GetFileName(img_vid_Upload.PostedFile.FileName);
            string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
            string filePath =  _filename;
            img_vid_Upload.PostedFile.SaveAs(Server.MapPath("~/Thumbnails/" + filePath));

            string Query = "Insert into Courses values('" + txtName.Text + "', '" + txtDescription.Text + "', '" + ddlCategory.SelectedItem.Text + "', '" + ddlCourseType.SelectedItem.Text + "', '" + txtNumOfDays.Text + "', '" + txtExpiryDays.Text + "', '" + txtMainHeading.Text + "', '" +  filePath + "', '" + Session["Email"].ToString() + "', '" + Session["Name"].ToString() + "')";

            SqlCommand command = new SqlCommand(Query, sqlConnection);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                lblMessage.Text = "Course Added Successfully :)";
            }
            else
            {
                lblMessage.Text = "Un-expected Error! Try Again !!";
            }

        }
    }
}