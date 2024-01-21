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
    public partial class addtotal1 : System.Web.UI.Page
    {
        int check = 0;
        string sqlStmt;
        int total;
            protected void Page_Load(object sender, EventArgs e)
            {
                Session.Timeout = 60;
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

                if (acesslvl == 0)
                {
                    Response.Redirect("login_page.aspx");
                }



                DateTime now = DateTime.Now;
                tb_date.Text = now.ToString();

                var name = Session["Name"];
                tb_name.Text = name.ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            if (!IsPostBack)
            {

            
            ddl_categ_list.AppendDataBoundItems = true;

            string cateo = "Select * from categ_list_table";
            SqlDataAdapter adpte = new SqlDataAdapter(cateo, con);
            DataTable databas = new DataTable();
            adpte.Fill(databas);
            ddl_categ_list.DataSource = databas;
            ddl_categ_list.DataValueField = "Id";
            ddl_categ_list.DataTextField = "category_list";
            ddl_categ_list.DataBind();
            }

        }


            protected void ddl_categ_list_SelectedIndexChanged(object sender, EventArgs e)
            {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();


            


            string cateo = "SELECT amount FROM amount WHERE categ='" + ddl_categ_list.SelectedValue + "' And campus='" + Convert.ToInt32(Session["campus"]) + "'";
            SqlCommand cmd2 = new SqlCommand(cateo, con);
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                tb_examount.Text = reader["amount"].ToString();
                check++;
                break;
            }
            reader.Close();
            con.Close();

            if (check == 0)
            {
                tb_examount.Text = "0";
            }
        }

            protected void submit_Click(object sender, EventArgs e)
            {

           
            string sqlhis;
                SqlCommand cmd = null;
                SqlCommand comd = null;
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            
            if (Convert.ToInt32(ddl_categ_list.SelectedValue) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Category is not Selected!', 'warning')", true);
            }
            else if (tb_amount.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'New Amount is Empty!', 'warning')", true);
            }

            else
                {
                    try
                    {



                    if (check == 0)
                    {
                        sqlStmt = "insert into amount (categ,campus,amount) values(@categ,@campus,@amount)";

                        cmd = new SqlCommand(sqlStmt, cn);

                        cn.Open();

                        cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@campus", SqlDbType.Int));

                        cmd.Parameters.Add(new SqlParameter("@categ", SqlDbType.Int));
                        string totalamount = tb_amount.Text;
                        int amountt = Convert.ToInt32(totalamount);
                        string amounttt = tb_examount.Text;
                        int int_amountt = Convert.ToInt32(amounttt);
                        total = int_amountt + amountt;
                        cmd.Parameters["@amount"].Value = total;
                        cmd.Parameters["@amount"].Value = tb_amount.Text;
                        cmd.Parameters["@campus"].Value = Convert.ToInt32(Session["campus"]);
                        cmd.Parameters["@categ"].Value = ddl_categ_list.SelectedValue;

                         cmd.ExecuteNonQuery();
                       
                    }
                    else
                    {
                        sqlStmt = "UPDATE amount SET amount=@amount WHERE categ='" + ddl_categ_list.SelectedValue + "' And campus='" + Convert.ToInt32(Session["cid"]) + "'";

                        cmd = new SqlCommand(sqlStmt, cn);

                        cn.Open();


                        cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                        string totalamount = tb_amount.Text;
                        int amountt = Convert.ToInt32(totalamount);
                        string amounttt = tb_examount.Text;
                        int int_amountt = Convert.ToInt32(amounttt);
                         total = int_amountt + amountt;
                        cmd.Parameters["@amount"].Value = total;

                        cmd.ExecuteNonQuery();
                    }


                        sqlhis = "insert into history (adding_amount,category,campus,exist_amount,new_total,aprover,date) VALUES(@adding_amount,@category,@campus,@exist_amount,@new_total,@aprover,@date) ";

                        comd = new SqlCommand(sqlhis, cn);

                        comd.Parameters.Add(new SqlParameter("@adding_amount", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@category", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@campus", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@exist_amount", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@new_total", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@aprover", SqlDbType.Int));
                        comd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));

                        DateTime now = DateTime.Now;

                        comd.Parameters["@adding_amount"].Value = tb_amount.Text;
                        comd.Parameters["@category"].Value = ddl_categ_list.SelectedValue;
                        comd.Parameters["@campus"].Value = Convert.ToInt32(Session["campus"]);
                        comd.Parameters["@exist_amount"].Value = tb_examount.Text;
                        comd.Parameters["@new_total"].Value = total;
                        comd.Parameters["@aprover"].Value = Convert.ToInt32(Session["ID"]);
                        comd.Parameters["@date"].Value = now.ToString();



                       int j = comd.ExecuteNonQuery();


                    if (j > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'Amount Added Successfully :)', 'success')", true);
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

