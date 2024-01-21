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
    public partial class adduser1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;

            if (Session["Username"] == null)
            {
                Response.Redirect("login_page.aspx");
            }
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);
            if (acesslvl == 1)
            {
                Response.Redirect("showsheets.aspx");
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

           

            if (!IsPostBack)
            {
                ddl_campus.AppendDataBoundItems = true;
                ddl_campus_.AppendDataBoundItems = true;
                string camp = "Select campus_Id,campusname from campus";
                SqlDataAdapter adpt = new SqlDataAdapter(camp, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Open();

                tb_password.Text = "";
                tb_uname.Text = "";
                tb_users_name.Text = "";
                tb_app_name.Text = "";

                ddl_campus.DataSource = dt;
                ddl_campus.DataValueField = "campus_Id";
                ddl_campus.DataTextField = "campusname";
                ddl_campus.DataBind();

                ddl_campus_.DataSource = dt;
                ddl_campus_.DataValueField = "campus_Id";
                ddl_campus_.DataTextField = "campusname";
                ddl_campus_.DataBind();

                con.Close();
            }
        }

        

        protected void btn_sub_user_Click(object sender, EventArgs e)
        {
            string sqlStmt;
            string conString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlCommand cmd = null;

             if (Convert.ToInt32(ddl_campus.SelectedValue) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Campus is not Selected!', 'warning')", true);

            }

            else if(tb_uname.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'UserName is Empty!', 'warning')", true);
            }
            
            else if (tb_password.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Password is Empty!', 'warning')", true);
            }
            else if (tb_password.Text.Length < 8)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Password must contain atleast 8 characters!', 'warning')", true);
            }
            else if (tb_users_name.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Name is Empty!', 'warning')" , true);
            }
           
            else
            {
                try
                {



                    sqlStmt = "insert into user_table (Username,password,acesslvl,Name,campus) Values(@Username,@password,@acesslvl,@Name,@campus)";

                    cmd = new SqlCommand(sqlStmt, cn);

                    cn.Open();


                    cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@acesslvl", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@campus", SqlDbType.VarChar, 50));


                    cmd.Parameters["@Username"].Value = tb_uname.Text;
                    cmd.Parameters["@password"].Value = tb_password.Text;
                    cmd.Parameters["@acesslvl"].Value = 1;
                    cmd.Parameters["@Name"].Value = tb_users_name.Text;
                    cmd.Parameters["@campus"].Value = ddl_campus.SelectedValue;

                    int j = cmd.ExecuteNonQuery();


                    if (j > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'User Created Successfully :)', 'success')", true);
                    }
                    
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', "+ ex.Message+ ", 'warning')", true);
                }
                finally
                {
                    cn.Close();

                }
            }

        }

        protected void btn_sub_approver_Click(object sender, EventArgs e)
        {
            string sqlStmt;
            SqlCommand cmd = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            if (Convert.ToInt32(ddl_campus_.SelectedValue) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Campus is not Selected!', 'warning')", true);
            }
            else if (tb_app_name.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Approver Name is Empty!', 'warning')", true);
            }
            else
            {
                try
                {



                    sqlStmt = "insert into approvedby (approver,campus_id) Values(@approver,@campus_id) ";

                    cmd = new SqlCommand(sqlStmt, cn);

                    cn.Open();


                    cmd.Parameters.Add(new SqlParameter("@approver", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@campus_id", SqlDbType.Int));


                    cmd.Parameters["@approver"].Value = tb_app_name.Text;
                    cmd.Parameters["@campus_id"].Value = ddl_campus_.SelectedValue;


                    int j = cmd.ExecuteNonQuery();


                    if (j > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'Approver Added Successfully :)', 'success')", true);
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