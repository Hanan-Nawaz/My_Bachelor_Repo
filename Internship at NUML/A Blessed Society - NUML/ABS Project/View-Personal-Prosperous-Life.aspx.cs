using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class View_Personal_Prosperous_Life : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["ID"].ToString();
            if(id == null)
            {
                Response.Redirect("Personal-Prosperous-Life.aspx");
            }
            else
            {
               if (!Page.IsPostBack)
                {
                    BindGrid(id);
                }
            }
           
        }

        void BindGrid(string Id)
        {
            string qry;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            qry = "select * from Content where Id = '" + Convert.ToInt32(Id)  + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                title.InnerText = Convert.ToString(reader["Title"]);
                tbBack.InnerText = Convert.ToString(reader["Title"]);
                MainHead.InnerText = Convert.ToString(reader["Title"]);
                descBox.Text = Convert.ToString(reader["ABSContent"]);
                Image.ImageUrl = Convert.ToString(reader["ImageContent"]);
                var binary = Convert.ToString(reader["PDF"]);

                if(binary == "")
                {
                    btnDownload.Visible = false;
                }
            }
            reader.Close();
            con.Close();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from Content where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["PDF"];
                        fileName = sdr["Title"].ToString();
                        contentType = sdr["ContentType"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}