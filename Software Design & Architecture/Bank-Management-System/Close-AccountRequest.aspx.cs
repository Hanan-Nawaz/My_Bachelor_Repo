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
    public partial class Close_AccountRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                tb_AccountNumber.Text = Session["AccountNumber"].ToString();
                tb_email.Text = Session["Email"].ToString();

                if (!Page.IsPostBack)
                {
                    BindGrid();

                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string sqlStmt = "insert into CloseRequest (AccountNumber,Email,Reason,Status) Values(@AccountNumber,@Email,@Reason,@Status)  ";
            SqlCommand cmd;
            cmd = new SqlCommand(sqlStmt, con);

            cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@Reason", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd.Parameters["@AccountNumber"].Value = tb_AccountNumber.Text;
            cmd.Parameters["@Email"].Value = tb_email.Text;
            cmd.Parameters["@Reason"].Value = tb_reason.Text;
            cmd.Parameters["@Status"].Value = "Pending Close Account";

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                message.Text = "Your Request for  Account Deletion at Bank of Numl is Received";

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear'" + Session["Name"].ToString() + "'\n\nYour Account Deletion Request have been received at Bank of NUML. We are sad and in shock as you Choose to close your Account at Bank of NUML. Our represenataive will contact you soon. We Receive millions of request daily. We will reach you within 1-7 working days with our decision after reviewing your Request. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", tb_email.Text, "Account Deletion Request", strBody.ToString());

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




            minutesheet = "SELECT * FROM CloseRequest";




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
           

            string sqlStmt1 = "update CloseRequest set Status=@Status  where Email='" + AccountNumber + "' And Id='"+ Id+ "'" ;
            SqlCommand cmd1;
            cmd1 = new SqlCommand(sqlStmt1, con);

            cmd1.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50));

            cmd1.Parameters["@Status"].Value = "Cancelled";
            int j = cmd1.ExecuteNonQuery();

            if (j > 0)
            {

                StringBuilder strBody = new StringBuilder();

                strBody.Append("Dear User\n\nYour Request for Deletion of Account at Bank of NUML is Cancelled. \n\nThanks & Regards \nBank of NUML \nH - 9 Islamabad, Pakistan \n+ 923447818962 \nBankofNUML@gamil.com");




                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@hanannawaz.com", AccountNumber, "Account Deletion Request Cancelled", strBody.ToString());

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

                BindGrid();
            }
        }
    }
}