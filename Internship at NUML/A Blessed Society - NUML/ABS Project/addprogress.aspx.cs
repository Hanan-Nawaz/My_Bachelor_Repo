using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class addprogress : System.Web.UI.Page
    {
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);


            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl != 6)
            {
                Response.Redirect("login.aspx");
            }


        }

        protected void btn_unreply_Click(object sender, EventArgs e)
        {

            query = "SELECT name,gaurdianemail,gaurdiancontact,district,status,videodb.Id,video FROM  link join  videodb on link.Id=videodb.link_id where status=0";
            Videoload();
        }

        protected void btn_reply_Click(object sender, EventArgs e)
        {

            query = "SELECT name,gaurdianemail,gaurdiancontact,district,status,videodb.Id,video FROM  link join  videodb on link.Id=videodb.link_id where status=1";
            Videoload();
        }

        private void Videoload()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);


            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);

            gird.DataSource = sqldatab;



            gird.DataBind();
        }

        protected void verify_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            string updatequery = "Update videodb set status=@status where Id=" + ID;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status", 1);

            cmd.ExecuteNonQuery();

        }
    }
}