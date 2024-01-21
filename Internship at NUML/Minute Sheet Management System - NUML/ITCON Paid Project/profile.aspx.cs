using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNetCore.Authorization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Configuration;

namespace ITCON_Paid_Project
{
    public partial class profile : System.Web.UI.Page
    {
        int accesslvl;
        protected void Page_Load(object sender, EventArgs e)
        {
            accesslvl = Convert.ToInt32(Session["acesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }

            edit.Visible = false;
            edit_text.Visible = false;
            tb_name_new.Visible = false;
            tb_name_old.Visible = false;
            savename.Visible = false;
            tb_c_name.Visible = false;
            nam.Visible = false;
            nam1.Visible = false;
            nam2.Visible = false;


            pass.Visible = false;
            pass_line.Visible = false;
            tb_n_pass.Visible = false;
            tb_o_pass.Visible = false;
            tb_cn_pass.Visible = false;
            save_pass.Visible = false;
            pas.Visible = false;
            pas1.Visible = false;
            pas2.Visible = false;

        }

        protected void change_pass_Click(object sender, EventArgs e)
        {
            pass.Visible = true;
            pass_line.Visible = true;
            tb_n_pass.Visible = true;
            tb_o_pass.Visible = true;
            tb_cn_pass.Visible = true;
            save_pass.Visible = true;
            pas.Visible = true;
            pas1.Visible = true;
            pas2.Visible = true;
        }

        protected void edit_profile_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            edit_text.Visible = true;
            tb_name_new.Visible = true;
            tb_name_old.Visible = true;
            tb_c_name.Visible = true;
            savename.Visible = true;
            nam.Visible = true;
            nam1.Visible = true;
            nam2.Visible = true;
        }

        protected void savename_Click(object sender, EventArgs e)
        {
            if(tb_name_new.Text == "" ||  tb_c_name.Text =="" || tb_name_old.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Name is empty!', 'error')", true);

            }
            else
            {

            
            if(tb_name_new.Text == tb_c_name.Text)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                cn.Open();

                string update = "UPDATE user_table SET Name=@Name WHERE Username='" + Convert.ToString(Session["username"]) + "'";
                SqlCommand command = new SqlCommand(update, cn);

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar , 50));

                command.Parameters["@Name"].Value = tb_name_new.Text;

                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Congratulation', 'Name Updated Succesfully :)', 'success')", true);

                }

            }
            else
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'New Name and Confirm Name Not Matched!', 'error')", true);

                tb_name_new.Text = "";
                tb_c_name.Text = "";

            }
            }
        }

        protected void save_pass_Click(object sender, EventArgs e)
        {
            if (tb_n_pass.Text == "" || tb_cn_pass.Text == "" || tb_o_pass.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Password is empty!', 'error')", true);

            }
            else
            {

                if (tb_n_pass.Text.Length < 8 || tb_cn_pass.Text.Length < 8)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'New Password and Confirm Password must have 8 characters!', 'error')", true);

                }
                else
                {



                    if (tb_n_pass.Text == tb_cn_pass.Text)
                    {
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                        cn.Open();

                        string update = "UPDATE user_table SET password=@password WHERE Username='" + Convert.ToString(Session["username"]) + "' And password='" + tb_o_pass.Text + "'";
                        SqlCommand command = new SqlCommand(update, cn);

                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));

                        command.Parameters["@password"].Value = tb_cn_pass.Text;

                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Congratulation', 'Password Changed Succesfully :)', 'success')", true);

                        }

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'New Password and Confirm Password Not Matched!', 'error')", true);

                        tb_name_new.Text = "";
                        tb_c_name.Text = "";

                    }
                }
            }
        }
    }
}