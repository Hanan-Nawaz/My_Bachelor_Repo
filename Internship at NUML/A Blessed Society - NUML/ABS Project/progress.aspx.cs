using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ABS_Project
{
    public partial class progress : System.Web.UI.Page
    {
        int ID;
        int volid;
        int benid;
        int donorid;
        string status;
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);

            if (accesslvl == 1 || accesslvl == 4 || accesslvl == 6)
            {
                f_video.Visible = false;
                fu_image_uplaod.Visible = false;
                btn_image.Visible = false;
                btn_video.Visible = false;
                lbl_img.Visible = false;
                lbl_vid.Visible = false;
                verify.Visible = false;
                label.Visible = false;
                Image1.Visible = false;
            }
            else if (accesslvl == 5)
            {
                f_video.Visible = false;
                fu_image_uplaod.Visible = false;
                btn_image.Visible = false;
                btn_video.Visible = false;
                lbl_img.Visible = false;
                lbl_vid.Visible = false;
                verify.Visible = true;
                label.Visible = false;
                Image1.Visible = false;
            }
            else
            {
                f_video.Visible = true;
                fu_image_uplaod.Visible = true;
                btn_image.Visible = true;
                btn_video.Visible = true;
                lbl_img.Visible = true;
                lbl_vid.Visible = true;
                verify.Visible = false;
                label.Visible = true;
                Image1.Visible = true;
            }


            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }

            else if (accesslvl == 4)
            {
                Response.Redirect("login.aspx");
            }

            else
            {
                string id = Request.QueryString["letter_no"];
                ID = Convert.ToInt32(id);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                string qry1 = "SELECT donor_id,benid,status_donor,volid from link WHERE Id=" + ID;
                SqlCommand cmd1 = new SqlCommand(qry1, con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    benid = Convert.ToInt32(reader1["benid"]);
                    volid = Convert.ToInt32(reader1["volid"]);
                    donorid = Convert.ToInt32(reader1["donor_id"]);
                    status = Convert.ToString(reader1["status_donor"]);

                    break;
                }

                if (status == "Cancelled")
                {
                    f_video.Visible = false;
                    fu_image_uplaod.Visible = false;
                    btn_image.Visible = false;
                    btn_video.Visible = false;
                    lbl_img.Visible = false;
                    lbl_vid.Visible = false;
                    verify.Visible = false;
                    label.Visible = false;
                    Image1.Visible = false;
                }

                reader1.Close();

                string qry = "SELECT * from benificary_table WHERE Id=" + benid;
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    tb_name.Text = Convert.ToString(reader["name"]);
                    tb_fathername.Text = Convert.ToString(reader["fathername"]);
                    tb_gaurdianname.Text = Convert.ToString(reader["gaurdianname"]);
                    tb_address.Text = Convert.ToString(reader["address"]);
                    tb_cnic.Text = Convert.ToString(reader["cnic"]);
                    tb_gaurdianemail.Text = Convert.ToString(reader["gaurdianemail"]);
                    tb_contact.Text = Convert.ToString(reader["gaurdiancontact"]);
                    ddl_country.SelectedItem.Text = Convert.ToString(reader["country"]);
                    ddl_province.SelectedItem.Text = Convert.ToString(reader["province"]);
                    ddl_district.SelectedItem.Text = Convert.ToString(reader["district"]);
                    ddl_school.SelectedItem.Text = Convert.ToString(reader["school"]);
                    tb_needs.Text = Convert.ToString(reader["needs"]);
                    profilepic.ImageUrl = Convert.ToString(reader["profile"]);
                    death.ImageUrl = Convert.ToString(reader["deathcert"]);
                    uc_con.ImageUrl = Convert.ToString(reader["uccon"]);
                    prnl.ImageUrl = Convert.ToString(reader["prnl"]);
                    volid = Convert.ToInt32(reader["volid"]);
                    break;

                }
                reader.Close();

                string qry2 = "SELECT * from login_table WHERE Id=" + volid;
                SqlCommand cmd2 = new SqlCommand(qry2, con);
                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    tb_vol_name.Text = Convert.ToString(reader2["name"]);
                    tb_vol_contact.Text = Convert.ToString(reader2["email"]);
                    tb_number.Text = Convert.ToString(reader2["contact"]);
                    tb_cnic_vol.Text = Convert.ToString(reader2["cnic"]);
                    img_vol_pic.ImageUrl = Convert.ToString(reader2["image"]);
                    break;
                }
                reader2.Close();

                string qry3 = "SELECT * from login_table WHERE Id=" + donorid;
                SqlCommand cmd3 = new SqlCommand(qry3, con);
                SqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    tb_don_name.Text = Convert.ToString(reader3["name"]);
                    tb_don_email.Text = Convert.ToString(reader3["email"]);
                    tb_don_number.Text = Convert.ToString(reader3["contact"]);
                    tb_don_cnic.Text = Convert.ToString(reader3["cnic"]);
                    img_don.ImageUrl = Convert.ToString(reader3["image"]);
                    break;
                }


                ImageLoad();
                Videoload();
            }
        }

        private void ImageLoad()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string minutesheet = "SELECT image FROM imagedb WHERE link_id=" + ID;
            SqlCommand cmd = new SqlCommand(minutesheet, con);


            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);

            girdview.DataSource = sqldatab;



            girdview.DataBind();


        }

        private void Imageupload()
        {
            decimal size = Math.Round(((decimal)fu_image_uplaod.PostedFile.ContentLength / (decimal)1024), 2);
            //Limit size to approx 50kb for image
            if ((size > 100))
            {
                message.Text = "Please upload image of upto 100kb size only Go to https://imresizer.com/resize-image-to-100kb to Resize online ";
            }

            string updatequery = "Update link set status_donor=@status_donor where Id=" + ID;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status_donor", "Partial");

            cmd.ExecuteNonQuery();

            if (fu_image_uplaod.HasFile)
            {



                string filename = Path.GetFileName(fu_image_uplaod.PostedFile.FileName);
                string filePath = "~/images/" + filename;
                fu_image_uplaod.PostedFile.SaveAs(Server.MapPath(filePath));

                string query = "insert into imagedb (link_id,image) Values(@link_id,@image)";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.Add(new SqlParameter("@link_id", SqlDbType.Int));

                com.Parameters["@link_id"].Value = ID;
                com.Parameters.AddWithValue("@image", filePath);


                com.ExecuteNonQuery();
                ImageLoad();

            }
        }

        private void VideoUplaod()
        {

            string updatequery = "Update link set status_donor=@status_donor where Id=" + ID;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status_donor", "Partial");

            cmd.ExecuteNonQuery();

            if (f_video.Text != "")
            {

                string query = "insert into videodb (link_id,video) Values(@link_id,@video)";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.Add(new SqlParameter("@link_id", SqlDbType.Int));
                com.Parameters.Add(new SqlParameter("@video", SqlDbType.VarChar));


                com.Parameters["@link_id"].Value = ID;
                com.Parameters["@video"].Value = f_video.Text;


                com.ExecuteNonQuery();
                Videoload();
            }
        }

        protected void btn_image_Click(object sender, EventArgs e)
        {
            Imageupload();

        }

        private void Videoload()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            string minutesheet = "SELECT video,Id FROM videodb WHERE link_id='" + ID + "' And status=1";
            SqlCommand cmd = new SqlCommand(minutesheet, con);


            SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
            DataTable sqldatab = new DataTable();
            sqladp.Fill(sqldatab);

            gird.DataSource = sqldatab;



            gird.DataBind();
        }

        protected void btn_video_Click(object sender, EventArgs e)
        {
            VideoUplaod();
        }

        protected void verify_Click(object sender, EventArgs e)
        {

            string updatequery = "Update link set status_donor=@status_donor where Id=" + ID;



            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand(updatequery, con);
            cmd.Parameters.AddWithValue("@status_donor", "Completed");

            cmd.ExecuteNonQuery();

        }
    }
}