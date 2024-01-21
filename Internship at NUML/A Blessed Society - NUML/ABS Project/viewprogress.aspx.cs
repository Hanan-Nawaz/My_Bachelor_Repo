using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class viewprogress : System.Web.UI.Page
    {
        int accesslvl;
        string status;
        string updatequery;
        string status1;
        string tb_vol_name;
        string tb_name;
        string tb_contact;
        string tb_needs;
        int volid;
        int vol_id;
        int benid;
        int donid;
        string tb_vol_contact;
        string minutesheet;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["accesslvl"]);


            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }
            else
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
            string stt = "Active";
            SqlConnection con = new SqlConnection();


            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            if (Convert.ToString(Session["portfolio"]) == "Principal")
            {
                minutesheet = "SELECT * FROM link where district='" + Session["district"] + "' And school='" + Session["school"] + "' Or volid='" + Session["Id"] + "'";
            }
            else if (accesslvl == 2 || accesslvl == 3)
            {
                minutesheet = "SELECT * FROM link where district='" + Session["district"] + "' And volid='" + Session["Id"] + "'";
            }
            else if (accesslvl == 5)
            {
                minutesheet = "SELECT * FROM link where cnic='" + Session["cnic"] + "'";
            }
            else if (accesslvl == 1)
            {
                minutesheet = "SELECT * FROM link where donor_id=" + Convert.ToInt32(Session["Id"]);
            }
            else
            {
                minutesheet = "SELECT * FROM link";
            }

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
                girdview1.DataSource = dv;

            }
            else
            {

                girdview1.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview1.DataBind();

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

                    if (row["name"].ToString().ToLower().Contains(searchTerm) || row["status_donor"].ToString().ToLower().Contains(searchTerm) || row["gaurdianemail"].ToString().ToLower().Contains(searchTerm) || row["district"].ToString().ToLower().Contains(searchTerm) || row["school"].ToString().ToLower().Contains(searchTerm) || row["gaurdiancontact"].ToString().ToLower().Contains(searchTerm) || row["province"].ToString().ToLower().Contains(searchTerm) || row["needs"].ToString().ToLower().Contains(searchTerm) || row["cnic"].ToString().ToLower().Contains(searchTerm))
                    {

                        dtNew.Rows.Add(row.ItemArray);
                    }
                }


                girdview1.DataSource = dtNew;
                girdview1.DataBind();
            }
        }





        protected void girdview1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            girdview1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }


        protected void getImagePath(Object sender, DataGridItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {

                int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Id"));
                status = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "status_donor"));

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();



                string qry = "SELECT donor_id,volid from link WHERE Id=" + id;
                SqlCommand cmd1 = new SqlCommand(qry, con);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {

                    donid = Convert.ToInt32(reader["donor_id"]);
                    vol_id = Convert.ToInt32(reader["volid"]);

                    break;

                }

                LinkButton btn = (LinkButton)e.Item.Cells[0].FindControl("btn");
                LinkButton btnview = (LinkButton)e.Item.Cells[0].FindControl("view_btn");

                if (Convert.ToInt32(Session["Id"]) != vol_id && Convert.ToInt32(Session["Id"]) != donid)
                {
                    btnview.Visible = false;
                }

                if (Convert.ToInt32(Session["Id"]) == donid)
                {


                    if (status == "Cancelled")
                    {
                        btn.Visible = false;

                    }
                    else if (status == "Partial")
                    {
                        btn.Visible = false;

                    }
                    else if (status == "Completed")
                    {
                        btn.Visible = false;

                    }
                    else
                    {
                        btn.Visible = true;

                    }
                }
                else
                {
                    btn.Visible = false;
                }

                if (accesslvl == 2 || accesslvl == 3)
                {

                    if (Convert.ToInt32(Session["Id"]) == donid)
                    {
                        btnview.Text = "add";

                    }


                    else
                    {
                        btnview.Text = "add";
                    }

                }



            }

        }

        protected void girdview1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }

        protected void del_btn_Click(object sender, EventArgs e)
        {


            string[] arg = new string[1];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            int id = Convert.ToInt32(arg[0]);
            string stat = arg[1];

            updatequery = "Update link set status_donor=@status_donor where Id=" + id;


            status1 = "Cancelled";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status_donor", status1);

            cmd.ExecuteNonQuery();

            string qry = "SELECT * from link WHERE Id=" + id;
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {

                tb_name = Convert.ToString(reader["name"]);
                tb_contact = Convert.ToString(reader["gaurdianemail"]);
                tb_needs = Convert.ToString(reader["needs"]);
                volid = Convert.ToInt32(reader["volid"]);
                benid = Convert.ToInt32(reader["benid"]);
                break;

            }
            reader.Close();

            string qry1 = "SELECT * from login_table WHERE Id=" + volid;
            SqlCommand cmd4 = new SqlCommand(qry1, con);
            SqlDataReader reader1 = cmd4.ExecuteReader();
            while (reader1.Read())
            {
                tb_vol_name = Convert.ToString(reader1["name"]);
                tb_vol_contact = Convert.ToString(reader1["email"]);
                break;

            }

            reader1.Close();


            StringBuilder strBody = new StringBuilder();

            strBody.Append("Dear '" + Convert.ToString(Session["name"]) + "', \n\nYour donation to A Blessed Society is Cancelled. \n\nThank you for Your interest in ABS’s work. \n\nIf you have any queries, we would love to hear from you.Please email info@abs.edu.pk or call +92332-9555200. \n\nSincerely, \nThe ABS Team \nKhayaban-e-JoharH 9/4 H-9, Islamabad \nIslamabad Capital Territory 44000 \nTelephone: +923229555200 | info@abs.edu.pk ");

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(Convert.ToString(Session["sendingmail"]), Convert.ToString(Session["email"]), "Thank You for Your Recent Donation", strBody.ToString());

            System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@abs.edu.pk", "sultan999@abs.edu.pk");

            System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("www.abs.edu.pk");
            mailclient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            mailclient.UseDefaultCredentials = false;
            mailclient.Credentials = mailAuthenticaion;
            mailclient.Send(mail);


            StringBuilder strBody1 = new StringBuilder();

            strBody1.Append("Dear '" + tb_vol_name + "', \n\n Donation to Benificary You Registered Cancelled. \n\n Benificary Name: " + tb_name + " \n Benificary Contact: " + tb_contact + "\n Needs: " + tb_needs + " \n\n Donor Name: " + Convert.ToString(Session["name"]) + "\n Donor Email : " + Convert.ToString(Session["email"]) + "\n\n If you have any queries, we would love to hear from you.Please email info@abs.edu.pk or call +92332-9555200. \n\nSincerely, \nThe ABS Team \nKhayaban-e-JoharH 9/4 H-9, Islamabad \nIslamabad Capital Territory 44000 \nTelephone: +923229555200 | info@abs.edu.pk ");


            System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage(Convert.ToString(Session["sendingmail"]), tb_vol_contact, "Alert About Recent Donation Cancellation", strBody1.ToString());

            System.Net.NetworkCredential mailAuthenticaion1 = new System.Net.NetworkCredential("admin@abs.edu.pk", "sultan999@abs.edu.pk");

            System.Net.Mail.SmtpClient mailclient1 = new System.Net.Mail.SmtpClient("www.abs.edu.pk");
            mailclient1.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            mailclient1.UseDefaultCredentials = false;
            mailclient1.Credentials = mailAuthenticaion1;
            mailclient1.Send(mail1);

            string update = "Update benificary_table set status=@status where Id=" + benid;
            SqlCommand cmd2 = new SqlCommand(update, con);

            cmd2.Parameters.AddWithValue("@status", "Active");

            cmd2.ExecuteNonQuery();
            con.Close();


            {

                BindGrid();
            }
        }




        protected void view_btn_Click(object sender, EventArgs e)
        {
            int letterno = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Response.Redirect("progress.aspx?letter_no=" + letterno);

        }


    }
}