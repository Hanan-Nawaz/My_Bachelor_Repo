using MedLearner.LandingPages;
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
    public partial class addChildTag : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Child Tag - MedLearner";
            alertError.Visible = false;
            alertSuccess.Visible = false;

            if (!Page.IsPostBack)
            {
                FillDropDownlist();
            }
        }

        private void FillDropDownlist()
        {
            ddlTag.AppendDataBoundItems = true;
            ddlTag.Items.Clear();
            ddlTag.Items.Add("Select Parent Tag");

            string Query = "select * from parentTag";
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            DataTable dtTag = new DataTable();
            adp.Fill(dtTag);

            ddlTag.DataSource = dtTag;
            ddlTag.DataTextField = "Tag";
            ddlTag.DataValueField = "Id";
            ddlTag.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            if(ddlTag.SelectedItem.Text == "Select Parent Tag")
            {
                alertError.Visible = true;
                alertSuccess.Visible = false;
            }
            else
            {
                alertError.Visible = false;
                alertSuccess.Visible = false;

                string Query = "Insert into childTag values('" + txtTag.Text + "', '" + ddlTag.SelectedValue + "')";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();

                if (result > 0)
                {
                    alertError.Visible = false;
                    alertSuccess.Visible = true;
                }
                else
                {
                    alertError.Visible = true;
                    alertSuccess.Visible = false;
                }
            }
        }
    }
}