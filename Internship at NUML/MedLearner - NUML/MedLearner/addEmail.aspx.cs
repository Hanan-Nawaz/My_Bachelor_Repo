using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MedLearner
{
    public partial class addEmail : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Query;
        DataTable dtCourse;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Email - MedLearner";

            dtCourse = new DataTable();


            if (!Page.IsPostBack)
            {
                FillDropDownlist();
            }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            Query = "Insert into Email values('" + txtSubject.Text + "',  '" + txtBody.Text + "', '" + ddlType.SelectedItem.Text + "','" + ddlCourse.SelectedValue + "')";


            SqlCommand command = new SqlCommand(Query, sqlConnection);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                lblMessage.Text = " Email Added Successfully :)";
                ddlCourse.SelectedIndex = 0;
            }
            else
            {
                lblMessage.Text = "Un-expected Error! Try Again !!";
            }
        }
    }
    }
