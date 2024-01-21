using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class Home1 : System.Web.UI.Page
    {
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Home - MedLearner";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            con.Open();
            string qry = "SELECT TOP 3 * FROM Courses ORDER BY Id DESC";

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string name = Convert.ToString(reader["TutorName"]);
                string path = Convert.ToString(reader["Thumbnail"]);
                string CName = Convert.ToString(reader["Name"]);
                if (i == 0)
                {
                    image1.ImageUrl = "~/Thumbnails/" + path;
                    label1.Text = name.ToString();
                    title1.InnerText = CName.ToString();
                }
                
                else if(i == 1)
                {
                    image2.ImageUrl = "~/Thumbnails/" + path;
                    label2.Text = name.ToString();
                    H1.InnerText = CName.ToString();
                }

                else if (i == 2)
                {
                    image3.ImageUrl = "~/Thumbnails/" + path;
                    label3.Text = name.ToString();
                    H2.InnerText = CName.ToString();
                }

                else if (i == 3)
                {
                    image4.ImageUrl = "~/Thumbnails/" + path;
                    label4.Text = name.ToString();
                    H3.InnerText = CName.ToString();
                }

                else if (i == 4)
                {
                    image5.ImageUrl = "~/Thumbnails/" + path;
                    label5.Text = name.ToString();
                    H4.InnerText = CName.ToString();
                }

                else if (i == 5)
                {
                    image6.ImageUrl = "~/Thumbnails/" + path;
                    label6.Text = name.ToString();
                    H5.InnerText = CName.ToString();
                }

               
                i++;
            }
            reader.Close();
        }
    }
}