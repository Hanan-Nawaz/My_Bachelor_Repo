using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class dashboard : System.Web.UI.Page
    {
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry = "SELECT count(*) from benificary_table";
                SqlCommand cmd = new SqlCommand(qry, con);

                int RecordCount = Convert.ToInt32(cmd.ExecuteScalar());

                string benii = "Total Benificary : " + RecordCount.ToString();
                btn_ben.Text = benii;

                string qry_vol = "SELECT count(*) from login_table where accesslvl=2";
                SqlCommand cmd_vol = new SqlCommand(qry_vol, con);

                int RecordCount_ = Convert.ToInt32(cmd_vol.ExecuteScalar());

                string benii1 = "Total Volunteer : " + RecordCount_.ToString();
                btn_vol.Text = benii1;

                string qry_don = "SELECT count(*) from login_table where accesslvl=1";
                SqlCommand cmd_don = new SqlCommand(qry_don, con);

                int RecordCount_don = Convert.ToInt32(cmd_don.ExecuteScalar());
                string benii2 = "Total Donor : " + RecordCount_don.ToString();
                btn_donor.Text = benii2;

                string qry_both = "SELECT count(*) from login_table where accesslvl=3";
                SqlCommand cmd_both = new SqlCommand(qry_both, con);

                int RecordCount_both = Convert.ToInt32(cmd_both.ExecuteScalar());
                string benii3 = "Both Volunteer & Donor : " + RecordCount_both.ToString();
                btn_both.Text = benii3;


                /*  string qry_sch = "SELECT count(*) from school";
                  SqlCommand cmd_sch = new SqlCommand(qry_sch, con);

                  int RecordCount_sch = Convert.ToInt32(cmd_sch.ExecuteScalar());
                  string benii4 = "Total Schools : " + RecordCount_sch.ToString();
                  btn_sch.Text = benii4; */



            }
        }



        protected void btn_ben_Click(object sender, EventArgs e)
        {
            Response.Redirect("showbenificary.aspx");
        }

        protected void btn_both_Click(object sender, EventArgs e)
        {
            Response.Redirect("seelists.aspx");
        }

        protected void btn_donor_Click(object sender, EventArgs e)
        {

        }


    }
}