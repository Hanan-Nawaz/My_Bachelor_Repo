using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ITCON_Paid_Project
{
    public partial class dashboard : System.Web.UI.Page
    {
        int accesslvl;
        string minutesheet;
        string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["acesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry = "SELECT count(*) from minute_sheet where campus=1";
                SqlCommand cmd = new SqlCommand(qry, con);

                int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

                string benii = "Islamabad : " + RecordCount.ToString();
                btn_isl.Text = benii;

                string qry_vol = "SELECT count(*) from minute_sheet where campus=2";
                SqlCommand cmd_vol = new SqlCommand(qry_vol, con);

                int RecordCount_ = Convert.ToInt32(cmd_vol.ExecuteScalar());

                string benii1 = "Rawalpindi : " + RecordCount_.ToString();
                btn_rwp.Text = benii1;

                string qry_don = "SELECT count(*) from minute_sheet where campus=3";
                SqlCommand cmd_don = new SqlCommand(qry_don, con);

                int RecordCount_don = Convert.ToInt32(cmd_don.ExecuteScalar());
                string benii2 = "Lahore : " + RecordCount_don.ToString();
                btn_lahore.Text = benii2;

                string qry_both = "SELECT count(*) from minute_sheet where campus=4";
                SqlCommand cmd_both = new SqlCommand(qry_both, con);

                int RecordCount_both = Convert.ToInt32(cmd_both.ExecuteScalar());
                string benii3 = "Gawadar : " + RecordCount_both.ToString();
                btn_gaw.Text = benii3;


                string qry1 = "SELECT count(*) from minute_sheet where campus=5";
                SqlCommand cmd1 = new SqlCommand(qry1, con);

                int RecordCount1 = Convert.ToInt32(cmd1.ExecuteScalar());

                string benii4 = "Karachi : " + RecordCount1.ToString();
                btn_khi.Text = benii4;

                string qry_vol1 = "SELECT count(*) from minute_sheet where campus=6";
                SqlCommand cmd_vol1 = new SqlCommand(qry_vol1, con);

                int RecordCount_1 = Convert.ToInt32(cmd_vol1.ExecuteScalar());

                string benii12 = "Multan : " + RecordCount_1.ToString();
                btn_mlt.Text = benii12;

                string qry_don1 = "SELECT count(*) from minute_sheet where campus=7";
                SqlCommand cmd_don1 = new SqlCommand(qry_don1, con);

                int RecordCount_don1 = Convert.ToInt32(cmd_don.ExecuteScalar());
                string benii22 = "Hyderabad : " + RecordCount_don1.ToString();
                btn_hydr.Text = benii22;

                string qry_both2 = "SELECT count(*) from minute_sheet where campus=8";
                SqlCommand cmd_both2 = new SqlCommand(qry_both2, con);

                int RecordCount_both2 = Convert.ToInt32(cmd_both2.ExecuteScalar());
                string benii32 = "Quetta : " + RecordCount_both2.ToString();
                btn_queta.Text = benii32;

                string qry_vol12 = "SELECT count(*) from minute_sheet where campus=9";
                SqlCommand cmd_vol12 = new SqlCommand(qry_vol12, con);

                int RecordCount_12 = Convert.ToInt32(cmd_vol12.ExecuteScalar());

                string benii13 = "Faisalabad : " + RecordCount_12.ToString();
                btn_fsd.Text = benii13;

                string qry_don13 = "SELECT count(*) from minute_sheet where campus=10";
                SqlCommand cmd_don13 = new SqlCommand(qry_don13, con);

                int RecordCount_don13 = Convert.ToInt32(cmd_don13.ExecuteScalar());
                string benii223 = "Peshawar : " + RecordCount_don13.ToString();
                btn_pesh.Text = benii223;
            
                /*
                string qry_both21 = "SELECT count(*) from minute_sheet where campus='Quetta'";
                SqlCommand cmd_both21 = new SqlCommand(qry_both21, con);

                int RecordCount_both21 = Convert.ToInt32(cmd_both21.ExecuteScalar());
                string benii31 = "Quetta : " + RecordCount_both21.ToString();
                btn_mlt.Text = benii31;

                */
            }
        }
        protected void btn_fsd_Click(object sender, EventArgs e)
        {
            Response.Redirect("showsheets.aspx");
        }
    }
}