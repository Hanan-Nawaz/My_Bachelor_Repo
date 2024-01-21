using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace ITCON_Paid_Project
{
    public partial class addcategory1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);
            if (acesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }
            else
            {

            
            if (acesslvl != 5)
            {
                Response.Redirect("showsheets.aspx");
            }
            }
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            string sqlStmt;
            SqlCommand cmd = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            if (tb_category.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Category is Empty!', 'warning')", true);

            }
            else
            {


                try
                {

                    sqlStmt = "insert into categ_list_table (category_list) Values (@category_list)  ";



                    cmd = new SqlCommand(sqlStmt, cn);
                    cn.Open();

                    cmd.Parameters.Add(new SqlParameter("@category_list", SqlDbType.VarChar, 50));

                    cmd.Parameters["@category_list"].Value = tb_category.Text;

                    int j = cmd.ExecuteNonQuery();

                    if (j > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'Category Added Successfully :)', 'success')", true);
                    }

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', " + ex.Message + ", 'warning')", true);
                }
                finally
                {
                    cn.Close();

                }

            }

        }

    }
}