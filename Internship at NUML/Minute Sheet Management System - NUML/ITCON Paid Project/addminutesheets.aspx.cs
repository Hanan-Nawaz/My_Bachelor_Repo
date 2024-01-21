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
    public partial class addminutesheets : System.Web.UI.Page
    {
        int cid;
            int totalamount;
            string del_amount = "";
            protected void Page_Load(object sender, EventArgs e)
            {
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);
            Session.Timeout = 60;
                if (acesslvl == 0)
                {
                    Response.Redirect("login_page.aspx");
                }
                else
                {

                e_amount.Text = "0";
                
                if (acesslvl == 5)
                {
                    Response.Redirect("showsheets.aspx");
                }



                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();

                Session["cid"] = Session["campus"];

                if (!IsPostBack)
                {

                    DateTime now = DateTime.Now;
                    string datetime = now.ToString();
                    date.Text = datetime;
                    app_date.Text = datetime;

                    approver_dl.AppendDataBoundItems = true;

                    string approvedby = "SELECT * from approvedby where campus_id='" + Convert.ToInt32(Session["cid"]) + "' OR campus_id='" + 1 + "'";
                    SqlDataAdapter sqladpter = new SqlDataAdapter(approvedby, con);
                    DataTable sqldatabase = new DataTable();
                    sqladpter.Fill(sqldatabase);
                    approver_dl.DataSource = sqldatabase;
                    approver_dl.DataTextField = "approver";
                    approver_dl.DataValueField = "ID";
                    approver_dl.DataBind();

                    ddl_faculty.AppendDataBoundItems = true;



                    SqlDataAdapter adp = new SqlDataAdapter("Select Id,faculty,campus_Id from faculty where campus_Id=" + Convert.ToInt32(Session["cid"]), con);
                    DataTable dtt = new DataTable();
                    adp.Fill(dtt);
                    ddl_faculty.DataSource = dtt;
                    ddl_faculty.DataTextField = "faculty";
                    ddl_faculty.DataValueField = "Id";
                    ddl_faculty.DataBind();


                    categ_list.AppendDataBoundItems = true;
                    string cateo = "Select * from categ_list_table";
                    SqlDataAdapter adpte = new SqlDataAdapter(cateo, con);
                    SqlCommand cmd = new SqlCommand(cateo, con);

                    DataTable databas = new DataTable();
                    adpte.Fill(databas);
                    categ_list.DataSource = databas;
                    categ_list.DataTextField = "category_list";
                    categ_list.DataValueField = "ID";
                    categ_list.DataBind();

                    con.Close();
                }
            }
        }

            protected void ddl_faculty_SelectedIndexChanged(object sender, EventArgs e)
            {

                dept.AppendDataBoundItems = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("Select Id,dept,faculty_Id from dept where faculty_Id=" + ddl_faculty.SelectedItem.Value, con);
                DataTable dtt = new DataTable();
                adp.Fill(dtt);
                dept.DataSource = dtt;
                dept.DataTextField = "dept";
                dept.DataValueField = "Id";
                dept.DataBind();
            }

           

           

            protected void categ_list_SelectedIndexChanged(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();

            
            string cateo = "SELECT amount FROM amount WHERE categ='" + categ_list.SelectedValue + "' And campus ='" + Convert.ToInt32(Session["campus"]) + "'";
                SqlCommand cmd = new SqlCommand(cateo, con);
            SqlDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                e_amount.Text = reader2["amount"].ToString();

                break;
            }
            reader2.Close();


                con.Close();
            }

            protected void add_btn_Click(object sender, EventArgs e)
            {
            int amt;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            cn.Open();


            

            string qry = "SELECT amount from amount WHERE categ='" + categ_list.SelectedValue + "' And campus='" + Convert.ToInt32(Session["campus"]) + "'";
            SqlCommand comd = new SqlCommand(qry, cn);
            SqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {

                Session["amt"] = Convert.ToInt32(reader["amount"].ToString());
                
                break;
            }
            
            
            {


               
                reader.Close();
                cn.Close();
              
                 if (Convert.ToInt32(ddl_faculty.SelectedValue) == 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Faculty is not Selected!', 'warning')", true);
                }
                else if (Convert.ToInt32(dept.SelectedValue) == 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Dept. is not Selected!', 'warning')", true);
                }
                else if (Convert.ToInt32(categ_list.SelectedValue) == 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Category is not Selected!', 'warning')", true);
                }

                else if (Convert.ToInt64(individual_amount_tb.Text) <= +0)
                {
                    sub_mess.Text = "Please Enter Valid Amount!";


                }

                else if (Convert.ToInt64(individual_amount_tb.Text) > Convert.ToInt64(Session["amt"]))
                {
                    sub_mess.Text = "Don't have enough Amount! Contact Admin.";


                }
                
                else if (Convert.ToInt64(Session["amt"]) <= 0)
                {
                    sub_mess.Text = "Don't have enough Amount! Contact Admin.";
                }
                else
                {
                    string sqlStmt;
                string update;
                SqlCommand cmd = null;
                SqlCommand command = null;
        
                var acess = Session["acesslvl"];
                int acesslvl = Convert.ToInt32(acess);


           
                    try
                    {




                        sqlStmt = "insert into minute_sheet_data (letter_no,Faculty_,Dept_,category,amount) Values(@letter_no,@Faculty_,@Dept_,@category,@amount)  ";

                        cmd = new SqlCommand(sqlStmt, cn);
                        cn.Open();

                    
                    cmd.Parameters.Add(new SqlParameter("@letter_no", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("@Faculty_", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@Dept_", SqlDbType.Int));
                        cmd.Parameters.Add(new SqlParameter("@category", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                    cmd.Parameters["@letter_no"].Value = letter_no.Text;
                        cmd.Parameters["@Faculty_"].Value = ddl_faculty.SelectedValue;
                        cmd.Parameters["@Dept_"].Value = dept.SelectedValue;
                        cmd.Parameters["@category"].Value = categ_list.SelectedValue;
                    cmd.Parameters["@amount"].Value = individual_amount_tb.Text;

                   int i = cmd.ExecuteNonQuery();
                        int a = Convert.ToInt32(Session["amt"]);
                        int b = Convert.ToInt32(individual_amount_tb.Text);
                        int amount_update = a - b;

                        e_amount.Text = amount_update.ToString();

                   

                    update = "UPDATE amount SET amount=@amount WHERE categ='" + categ_list.SelectedValue + "' And campus='" + Convert.ToInt32(Session["campus"]) + "'";
                        command = new SqlCommand(update, cn);

                        command.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                        command.Parameters["@amount"].Value = amount_update;

                        int j = command.ExecuteNonQuery();

                        BindGrid();

                        if (j > 0 && i > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'MinuteSheet Added Successfully :)', 'success')", true);
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

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private void BindGrid(string sortExpression = null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;



            string minutesheet = "SELECT * FROM minute_sheet_data JOIN faculty ON minute_sheet_data.Faculty_ = faculty.Id JOIN dept ON minute_sheet_data.Dept_ = dept.Id JOIN categ_list_table ON minute_sheet_data.category = categ_list_table.Id  WHERE letter_no='" + letter_no.Text + "'";
            SqlCommand cmd = new SqlCommand(minutesheet, con);

            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();

            sqladp.Fill(sqldatab);
            ViewState["myViewState"] = sqldatab;
            if (sortExpression != null)
            {

                DataView dv = sqldatab.AsDataView();
                this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                dv.Sort = sortExpression + " " + this.SortDirection;
                girdview.DataSource = dv;
            }
            else
            {

                girdview.DataSource = sqldatab;
            }


            // sqladp.Fill(sqldatab);
            // ViewState["myViewState"] = sqldatab;
            // girdview.DataSource = sqldatab;
            girdview.DataBind();
            totalamount = 0;
        }

        protected void girdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                totalamount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "amount"));
                total.Text = totalamount.ToString();
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = string.Format("{0:c}", totalamount);
            }
        }


        protected void girdview_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);

        }



        protected void girdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            girdview.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }


        protected void del_btn_Click(object sender, EventArgs e)
        {


            string[] arg = new string[3];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            Session["letter_no"] = arg[0];
            Session["minutesheet_Id"] = arg[1];
            Session["category"] = arg[2];
            Session["amount"] = arg[3];
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();



            string qry = "SELECT amount from amount WHERE campus='" + Convert.ToInt32(Session["campus"]) + "' AND categ ='" + Convert.ToInt32(Session["category"]) + "'";
            SqlCommand comd = new SqlCommand(qry, con);
            SqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {

                del_amount = reader["amount"].ToString();
                break;
            }

            reader.Close();

            
                string minutesheet = "DELETE FROM minute_sheet_data WHERE Id=" + Convert.ToInt32(Session["minutesheet_Id"]);
                SqlCommand cmd = new SqlCommand(minutesheet, con);
               int i =  cmd.ExecuteNonQuery();
                if(i> 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Congratulation', 'Deleted Successfully:)', 'success')", true);


                }
            BindGrid();

            int totalamount_ = Convert.ToInt32(Session["amount"]) + Convert.ToInt32(del_amount);


                string update = "UPDATE amount SET amount=@amount WHERE campus='" + Convert.ToInt32(Session["campus"]) + "' AND categ ='" + Convert.ToInt32(Session["category"]) + "'";
                SqlCommand command = new SqlCommand(update, con);

                command = new SqlCommand(update, con);

                command.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));

                command.Parameters["@amount"].Value = totalamount_;

                command.ExecuteNonQuery();

            
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            string sqlStmt;
            SqlCommand cmd = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;



            if (Convert.ToInt32(total.Text) != Convert.ToInt32(amount.Text))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Your Entered Total Amount is not equal to Amount you Entered in categories! Please check you might Miss a Category', 'warning')", true);
                amount.Text = "";
            }
            else if (Convert.ToInt32(approver_dl.SelectedValue) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', ' Approver is not Selected!', 'warning')", true);
            }
            else
            {

                try
                {



                    sqlStmt = "insert into minute_sheet (letter_no,date,title,campus,amount,approvedby,app_date,image) Values(@letter_no,@date,@title,@campus,@amount,@approvedby,@app_date,@image)  ";

                    cmd = new SqlCommand(sqlStmt, cn);
                    cn.Open();

                    string filename = Path.GetFileName(image_upload.PostedFile.FileName);
                    string filePath = "~/Image/" + filename;
                    image_upload.PostedFile.SaveAs(Server.MapPath(filePath));

                    var campus = Session["campus"];
                    string camp = campus.ToString();

                    cmd.Parameters.Add(new SqlParameter("@letter_no", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                    cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@campus", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@approvedby", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@app_date", SqlDbType.Date));

                    var acess = Session["acesslvl"];
                    int acesslvl = Convert.ToInt32(acess);

                    cmd.Parameters["@letter_no"].Value = letter_no.Text;
                    cmd.Parameters["@date"].Value = date.Text;
                    cmd.Parameters["@title"].Value = title.Text;
                    cmd.Parameters["@campus"].Value = Convert.ToInt32(Session["campus"]);
                    cmd.Parameters["@amount"].Value = amount.Text;
                    cmd.Parameters["@approvedby"].Value = approver_dl.SelectedValue;
                    cmd.Parameters["@app_date"].Value = app_date.Text;
                    cmd.Parameters.AddWithValue("@image", filePath);

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('congratulations', 'Minutesheet Inserted Succesfully :)', 'success')", true);
                    

                }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', '!', 'warning')", true);

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