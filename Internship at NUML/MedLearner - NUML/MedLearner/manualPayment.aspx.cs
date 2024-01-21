using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MedLearner
{
    public partial class manualPayment : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Id, currency, CourseName = "", details, query;

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("partialSuccess.aspx");
        }

        long priceToPay;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Checkout - MedLearner";

            CourseName = Session["CourseName"].ToString();

            lblCourseName.InnerText = CourseName;
        }
    }
}