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
    public partial class Courses : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Dashboard - MedLearner";

            if (!IsPostBack)
            {
                BindDataList();
            }
        }

        void BindDataList()
        {
            SqlCommand cmd = new SqlCommand("select * from Courses Join Price ON Courses.Id = Price.CousreId", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtBrands = new DataTable();
            sda.Fill(dtBrands);
            Repeatercourses.DataSource = dtBrands;
            Repeatercourses.DataBind();

            SqlDataAdapter adapter = new SqlDataAdapter("select Category from Category", con);
            DataTable dtCategory = new DataTable();
            adapter.Fill(dtCategory);
            ddlCategory.DataSource = dtCategory;
            ddlCategory.DataBind();
            ddlCategory.DataValueField = "Category";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("All", "0"));

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedItem.Text.Equals("All"))
            {
                BindDataList();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Courses Join Price ON Courses.Id = Price.CousreId and  Courses.Category='" + ddlCategory.SelectedItem.Text + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtBrands = new DataTable();
                sda.Fill(dtBrands);
                Repeatercourses.DataSource = dtBrands;
                Repeatercourses.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Courses Join Price ON Courses.Id = Price.CousreId and  Courses.Category='" + ddlCategory.SelectedItem.Text + "' and Courses.Name like '%" + txtSearch.Text + "%'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dtBrands = new DataTable();
            sda.Fill(dtBrands);
            Repeatercourses.DataSource = dtBrands;
            Repeatercourses.DataBind();
        }
    }
}