using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class Approve_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["Accesslvl"]);
            
                if (Session["Email"] == null && accesslvl==1)
            {
                Response.Redirect("Login.aspx");
            }
            Session.Timeout = 60;



            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private void BindGrid(string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string minutesheet;




            minutesheet = "SELECT * FROM Accounts where Accesslvl!=2";




            SqlCommand cmd = new SqlCommand(minutesheet, con);

            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);
            ViewState["myViewState"] = sqldatab;
            if (sortExpression != null)
            {


                DataView dv = sqldatab.AsDataView();
                this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                dv.Sort = sortExpression + " " + this.SortDirection;
                girdview.DataSource = dv;
            }
            else
            {

                girdview.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview.DataBind();

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower();


            if (searchTerm.Length >= 3)
            {

                if (ViewState["myViewState"] == null)
                    return;


                DataTable dt = ViewState["myViewState"] as DataTable;


                DataTable dtNew = dt.Clone();


                foreach (DataRow row in dt.Rows)
                {

                    if (row["AccountNumber"].ToString().ToLower().Contains(searchTerm) || row["Email"].ToString().ToLower().Contains(searchTerm) || row["Status"].ToString().ToLower().Contains(searchTerm))
                    {

                        dtNew.Rows.Add(row.ItemArray);
                    }
                }


                girdview.DataSource = dtNew;
                girdview.DataBind();
            }
        }




        protected void girdview_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);

        }



        protected void girdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            girdview.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void view_btn_Click(object sender, EventArgs e)
        {
            int AccountNumber = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Response.Redirect("View-Account.aspx?AccountNumber=" + AccountNumber);

        }
        protected void approeve_Click(object sender, EventArgs e)
        {

            string[] arg = new string[2];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            Session["Account_Number"] = arg[0];
            Session["E-Mail"] = arg[1];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();


            string sqlStmt1 = "update Accounts set Status=@Status  where AccountNumber='" + Convert.ToInt32(Session["Account_Number"]) + "'";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(sqlStmt1, con);

            cmd1.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd1.Parameters["@Status"].Value = "Active";
            int j = cmd1.ExecuteNonQuery();

            if (j > 0)
            {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear Customer\n\nYour Account Opening Request have been Accepted at Bank of NUML. We are thankful to you and Thanking you for Choosing Bank of NUML. Your Account Number is '" + Convert.ToInt32(Session["Account_Number"]) + "'. Please open our website and start Transcations. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", Convert.ToString(Session["E-Mail"]), "Account Opening Request Accepted", strBody.ToString());

                System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@hanannawaz.com", "hanannawaz0@gmail.com");

                System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("hanannawaz.com");
                mailclient.EnableSsl = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                mailclient.UseDefaultCredentials = false;
                mailclient.Credentials = mailAuthenticaion;
                mailclient.Send(mail);

            }
        }

        protected void rej_Click(object sender, EventArgs e)
        {

            string[] arg = new string[7];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            Session["Account_Number"] = arg[0];
            Session["E-Mail"] = arg[1];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();


            string sqlStmt1 = "update Accounts set Status=@Status  where AccountNumber='" + Convert.ToInt32(Session["Account_Number"]) + "'";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(sqlStmt1, con);

            cmd1.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd1.Parameters["@Status"].Value = "Rejected";
            int j = cmd1.ExecuteNonQuery();

            if (j > 0)
            {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear Customer\n\nYour Account Opening Request have been Rejected at Bank of NUML. We are thankful to you and Thanking you for Choosing Bank of NUML.  \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", Convert.ToString(Session["E-Mail"]), "Account Opening Request Rejected", strBody.ToString());

                System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@hanannawaz.com", "hanannawaz0@gmail.com");

                System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("hanannawaz.com");
                mailclient.EnableSsl = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                mailclient.UseDefaultCredentials = false;
                mailclient.Credentials = mailAuthenticaion;
                mailclient.Send(mail);

            }
        }
    }
}