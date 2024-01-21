using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ABS_Project
{
    public partial class addcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            else if (accesslvl == 1 || accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }


        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            try
            {

                string sqlStmt = "insert into category (category) Values(@category)";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                con.Open();

                cmd.Parameters.Add(new SqlParameter("@category", SqlDbType.VarChar, 50));

                cmd.Parameters["@category"].Value = tb_category.Text;

                cmd.ExecuteNonQuery();

                message.Text = "Category added Successfully";
            }
            catch (Exception ex)
            {
                message.Style.Add("color", "red");

                message.Text = ex.Message;
            }
            finally
            {
                con.Close();

            }

        }


    }
}