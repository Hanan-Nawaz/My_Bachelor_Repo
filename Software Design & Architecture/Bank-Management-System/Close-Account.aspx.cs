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
    public partial class Close_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["Accesslvl"]);

            if (Session["Email"] == null && accesslvl == 1)
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




            minutesheet = "SELECT * FROM CloseRequest where Status='Pending Close Account'";




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

                    if (row["AccountNumber"].ToString().ToLower().Contains(searchTerm) || row["Email"].ToString().ToLower().Contains(searchTerm) || row["Reason"].ToString().ToLower().Contains(searchTerm) || row["Status"].ToString().ToLower().Contains(searchTerm))
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

            string[] arg = new string[2];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            string AccountNumber = arg[0];
            int Id = Convert.ToInt32(arg[1]);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string sqlStmt = "update Accounts set Status=@Status  where Email='" + AccountNumber + "'";
            SqlCommand cmd;
            cmd = new SqlCommand(sqlStmt, con);

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd.Parameters["@Status"].Value = "Closed";



            int i = cmd.ExecuteNonQuery();



            string sqlStmt1 = "update CloseRequest set Status=@Status  where Email='" + AccountNumber + "' And Id='" + Id+ "'";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(sqlStmt1, con);

            cmd1.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd1.Parameters["@Status"].Value = "Accepted";
            int j =cmd1.ExecuteNonQuery();

            if (i > 0 && j > 0)
            {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear User\n\nYour Account at Bank of NUML is Deleted . We are thankful to you and Thanking you for working with Bank of NUML. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", AccountNumber, "Account Deleted", strBody.ToString());

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

        protected void rej_btn_Click(object sender, EventArgs e)
        {

            string[] arg = new string[2];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            string AccountNumber = arg[0];
            int Id = Convert.ToInt32(arg[1]);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string sqlStmt = "update Accounts set Status=@Status  where Email='" + AccountNumber + "'";
            SqlCommand cmd;
            cmd = new SqlCommand(sqlStmt, con);

            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd.Parameters["@Status"].Value = "Active";

            int i = cmd.ExecuteNonQuery();

            string sqlStmt1 = "update CloseRequest set Status=@Status  where Email='" + AccountNumber + "' And Id='" + Id + "'";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(sqlStmt1, con);

            cmd1.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd1.Parameters["@Status"].Value = "Rejected";
            int j = cmd1.ExecuteNonQuery();

            if (i > 0 && j > 0)
            {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear User\n\nYour Request for Deletion of Account at Bank of NUML is Rejected. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", AccountNumber, "Account Deletion Request Rejected", strBody.ToString());

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