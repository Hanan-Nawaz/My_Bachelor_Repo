using MedLearner.LandingPages;
using Stripe;
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
    public partial class addPrice : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Query;
        DataTable dtPrice, dtPriceCopy;
        DataTable dtCourse;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add Price for - MedLearner";

            lblCourseName.InnerText = "Add Price";

            dtPrice = new DataTable();
            dtPriceCopy = new DataTable();
            dtCourse = new DataTable();


            if (!Page.IsPostBack)
            {
                FillDropDownlist();
            }
        }

        void FillGridView()
        {
            grdPrice.DataSource = dtPrice;
            grdPrice.DataBind();
        }

        private void FillDropDownlist()
        {
            ddlCourse.AppendDataBoundItems = true;
            ddlCourse.Items.Clear();
            ddlCourse.Items.Add("Select Course");

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
            string Query = "select * from Price where CousreId=" + ddlCourse.SelectedItem.Value;
            SqlDataAdapter adp = new SqlDataAdapter(Query, sqlConnection);
            adp.Fill(dtPrice);

            return dtPrice;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            dtPrice = getData();

            if (dtPrice.Rows.Count > 0)
            {
                Query = "Update Price set Price='" + txtPrice.Text + "', PaymenyPlan='" + ddlPaymentPlan.SelectedItem.Text + "', Currency='" + ddlCurrency.SelectedItem.Text + "', DiscountOnCCode='" + txtDiscountAmount.Text + "', CCode='" + txtCCode.Text + "', PlanName='" + txtName.Text + "', Description='" + txtDescription.Text + "', CousreId='" + ddlCourse.SelectedValue + "'";
            }
            else
            {
                Query = "Insert into Price values('" + txtPrice.Text + "', '" + ddlPaymentPlan.SelectedItem.Text + "', '" + ddlCurrency.SelectedItem.Text + "', '" + txtDiscountAmount.Text + "', '" + txtCCode.Text + "', '" + txtName.Text + "', '" + txtDescription.Text + "', '" + ddlCourse.SelectedValue + "')";
            }

            SqlCommand command = new SqlCommand(Query, sqlConnection);
            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                if (dtPrice.Rows.Count > 0)
                {
                    lblMessage.Text = "Price Updated Successfully :)";
                }
                else
                {
                    lblMessage.Text = "Price Added Successfully :)";
                }
                dtPrice.Rows.Clear();
                dtPrice = getData();
                if (dtPrice.Rows.Count > 0)
                {
                    inputForm.Visible = false;
                }
                FillGridView();
            }
            else
            {
                lblMessage.Text = "Un-expected Error! Try Again !!";
            }

        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCourse.SelectedItem.Text != "Select Course")
            {
                dtPrice =  getData();

                if (dtPrice.Rows.Count > 0)
                {
                    inputForm.Visible = false;
                }

                FillGridView();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            dtPrice = getData();

            if (dtPrice.Rows.Count > 0)
            {
                inputForm.Visible = true;
                txtName.Text = dtPrice.Rows[0][6].ToString();
                txtDescription.Text = dtPrice.Rows[0][7].ToString();
                txtCCode.Text = dtPrice.Rows[0][5].ToString();
                txtDiscountAmount.Text = dtPrice.Rows[0][4].ToString();
                txtPrice.Text = dtPrice.Rows[0][1].ToString();
                ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText(dtPrice.Rows[0][3].ToString()));
                ddlPaymentPlan.SelectedIndex = ddlPaymentPlan.Items.IndexOf(ddlPaymentPlan.Items.FindByText(dtPrice.Rows[0][2].ToString()));
            }
            else
            {
                lblMessage.Text = "Un-expected Error! Try Again !!";
            }
        }
    }
}