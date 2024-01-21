using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNetCore.Authorization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace ITCON_Paid_Project
{
    public partial class Resetpassword1 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 4;


            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                SqlCommand cmd = new SqlCommand();

                SqlDataReader dr;
                try
                {
                    cmd = new SqlCommand("select UserName,UniqueCode from user_table where UniqueCode=@uniqueCode and  UserName=@username", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["username"]));

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        ResetPwdPanel.Visible = true;
                    }
                    else
                    {
                        ResetPwdPanel.Visible = false;
                        MessageBox.Show("Reset password link has expired.It was for one time use only");
                        return;
                    }
                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    message.Text = "Error Occured: " + ex.Message.ToString();
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            SqlCommand cmd = new SqlCommand();

            if (tb_password.Text != tb_password_con.Text)
            {
                message.Text = " Passwords didn't match ";
            }
            else
            {
                try
                {   // Here we will update the new password and also set the unique code to null so that it can be used only for once.
                    cmd = new SqlCommand("update user_table set UniqueCode='', password=@password where UniqueCode=@uniqueCode and UserName=@username", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["username"]));
                    cmd.Parameters.AddWithValue("@password", tb_password.Text.Trim());
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    message.Text = "Your password has been updated successfully.";
                    tb_password.Text = string.Empty;
                    tb_password_con.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    message.Text = "Error Occured : " + ex.Message.ToString();
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }

        
    }
}