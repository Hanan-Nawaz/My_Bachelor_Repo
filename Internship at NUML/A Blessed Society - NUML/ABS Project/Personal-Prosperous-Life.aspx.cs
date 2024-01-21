using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class Personal_Prosperous_Life : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid(null);
            }
        }

        void BindGrid(string Search)
        {
            string qry;
            GVContent.BackColor = Color.White;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            if(Search != null)
            {
               qry  = "select * from Content where Title = '" + Search + "'";
            }
            else
            {
                qry = "select * from Content";
            }
            string str = "";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                str = Convert.ToString(reader["ABSContent"]);
            }
            reader.Close();
            IEnumerable<string> words = str.Split().Take(10);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            GVContent.DataSource = dt;
            GVContent.DataBind();
            con.Close();
        }

        protected void GVContent_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                if (e.Item.ItemIndex == 0)
                {
                    e.Item.BackColor = System.Drawing.Color.White;
                }
                if (e.Item.ItemIndex == 2)
                {
                    e.Item.BackColor = System.Drawing.Color.White;
                }
                if (e.Item.ItemIndex == 3)
                {
                    e.Item.BackColor = System.Drawing.Color.White;
                }
                if (e.Item.ItemIndex == 4)
                {
                    e.Item.BackColor = System.Drawing.Color.White;
                }
            }
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(tbSearch.Text == "")
            {
                this.BindGrid(null);
            }
            else
            {
                this.BindGrid(tbSearch.Text);
            }
            
        }

        protected void knowMoreBtn_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString((sender as LinkButton).CommandArgument);
            Session["ID"] = id;
            Response.Redirect("View-Personal-Prosperous-Life.aspx");
        }
    }
}