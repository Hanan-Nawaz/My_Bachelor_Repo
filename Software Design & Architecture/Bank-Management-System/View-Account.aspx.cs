using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class View_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string Query;
                int AccountNumber = Convert.ToInt32(Request.QueryString["AccountNumber"]);

                if (AccountNumber == 0)
                {
                    Query = "Select * from Accounts where AccountNumber=" + Convert.ToInt32(Session["AccountNumber"]);
                }
                else
                {
                    Query = "Select * from Accounts where AccountNumber=" + AccountNumber;
                }

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                cn.Open();
                SqlCommand cmd1 = new SqlCommand(Query, cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    tb_AccountNumber.Text = reader1["AccountNumber"].ToString();
                    tb_name.Text = reader1["Name"].ToString();
                    tb_email.Text = reader1["Email"].ToString();
                    tb_cnic.Text = reader1["Cnic"].ToString();
                    tb_fname.Text = reader1["FatherName"].ToString();
                    ddl_jobtype.SelectedItem.Text = reader1["JobType"].ToString();
                    tb_salary.Text = reader1["Salary"].ToString();
                    ddl_type.SelectedItem.Text = reader1["Type"].ToString();
                    tb_amount.Text = reader1["Amount"].ToString();
                    image.ImageUrl = reader1["Picture"].ToString();
                    tb_address.Text = reader1["Address"].ToString();
                    break;
                }

                reader1.Close();
            }
        }
    }
}
