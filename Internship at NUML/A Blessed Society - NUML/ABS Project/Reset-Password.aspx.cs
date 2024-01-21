using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class Reset_Password : System.Web.UI.Page
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
                    cmd = new SqlCommand("select email,uniqueCode,cnic from login_table where uniqueCode=@uniqueCode and  email=@email and cnic=@cnic", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@email", Convert.ToString(Request.QueryString["email"]));
                    cmd.Parameters.AddWithValue("@cnic", Convert.ToString(Request.QueryString["cnic"]));


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
                        message.Text = "Reset password link has expired.It was for one time use only";
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

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            SqlCommand cmd = new SqlCommand();

            if (tb_pass1.Text != tb_pass2.Text)
            {
                message.Text = " Passwords didn't match ";
            }
            else
            {
                try
                {   // Here we will update the new password and also set the unique code to null so that it can be used only for once.
                    cmd = new SqlCommand("update login_table set uniqueCode='', password=@password where uniqueCode=@uniqueCode and email=@email and cnic=@cnic", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@email", Convert.ToString(Request.QueryString["email"]));
                    cmd.Parameters.AddWithValue("@cnic", Convert.ToString(Request.QueryString["cnic"]));
                    cmd.Parameters.AddWithValue("@password", tb_pass2.Text.Trim());
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    message.Style.Add("color", "black");
                    message.Text = "Your password has been updated successfully.";
                    tb_pass2.Text = string.Empty;
                    tb_pass1.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    message.Style.Add("color", "red");
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