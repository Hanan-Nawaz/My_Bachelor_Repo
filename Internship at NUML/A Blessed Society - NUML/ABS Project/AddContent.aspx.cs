using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class AddContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl != 6)
            {
                Response.Redirect("dashboard.aspx");
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            string filename1 = Path.GetFileName(pdfUpload.PostedFile.FileName);
            string contentType1 = pdfUpload.PostedFile.ContentType;
            Stream fs = pdfUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            if (ImgContent.PostedFile.FileName.Length < 0 || tbTitle.Text == "" || taContent.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Please Fill all Fields :)', 'error')", true);

            }
            else
            {
                    try
                    {
                        string filename = Path.GetFileName(ImgContent.PostedFile.FileName);
                        string filePath = filename;
                        ImgContent.PostedFile.SaveAs(Server.MapPath("~/images/" + filePath));

                        string sqlStmt = "insert into Content (Title,ABSContent,ImageContent,PDF,ContentType) Values(@Title,@ABSContent,@ImageContent,@PDF,@ContentType)";
                        SqlCommand cmd = new SqlCommand(sqlStmt, con);
                        con.Open();

                        cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("@ABSContent", SqlDbType.VarChar));

                        cmd.Parameters["@Title"].Value = tbTitle.Text;
                        cmd.Parameters["@ABSContent"].Value = taContent.Text;
                        cmd.Parameters.AddWithValue("@ImageContent", "~/images/" + filePath);
                        cmd.Parameters.AddWithValue("@PDF", bytes);
                        cmd.Parameters.AddWithValue("@ContentType", contentType1);

                    int i = cmd.ExecuteNonQuery();

                        if(i > 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Congratulations', 'Content Added Successfully :)', 'success')", true);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Unknown Error! Try Again :)', 'error')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        taContent.Text = ex.Message;
                    }
                    finally
                    {
                        con.Close();

                    }
                
            }
        }
    }
}
