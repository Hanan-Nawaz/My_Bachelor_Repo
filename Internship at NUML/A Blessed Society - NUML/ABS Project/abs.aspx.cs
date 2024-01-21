using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ABS_Project
{
    public partial class abs : System.Web.UI.Page
    {
        int i = 0;
        int j = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = " ABS - A Blessed Society ";


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string qry = "SELECT TOP 3 name,image FROM login_table WHERE accesslvl=1 ORDER BY Id DESC";

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string name = Convert.ToString(reader["name"]);
                string path = Convert.ToString(reader["image"]);
                if (i == 0)
                {
                    image1.ImageUrl = path;
                    H1.InnerText = name;
                }
                else if (i == 1)
                {
                    image2.ImageUrl = path;
                    H2.InnerText = name;
                }

                else if (i == 2)
                {
                    image3.ImageUrl = path;
                    H3.InnerText = name;
                }

                i++;
            }
            reader.Close();

            string qry1 = "SELECT TOP 3 name,image FROM login_table WHERE accesslvl=2 ORDER BY Id DESC";
            SqlCommand cmd1 = new SqlCommand(qry1, con);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {

                string name = Convert.ToString(reader1["name"]);
                string path = Convert.ToString(reader1["image"]);
                if (j == 0)
                {
                    image4.ImageUrl = path;
                    H4.InnerText = name;
                }
                else if (j == 1)
                {
                    image5.ImageUrl = path;
                    H5.InnerText = name;
                }

                else if (j == 2)
                {
                    image6.ImageUrl = path;
                    H6.InnerText = name;
                }

                j++;
            }
        }
    }
}