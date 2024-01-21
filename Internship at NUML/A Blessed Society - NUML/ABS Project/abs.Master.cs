using System;

namespace ABS_Project
{
    public partial class abs1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accesslvl = Convert.ToInt32(Session["accesslvl"]);
            ad_org.Visible = false;
            add_catg.Visible = false;
            add_blog.Visible = false;
            add_prn.Visible = false;
            btnAddContent.Visible = false;
            btnDelContent.Visible = false;


            if (accesslvl == 0)
            {
                Response.Redirect("login.aspx");
            }
            if (accesslvl == 1)
            {
                add_beni.Visible = false;
                add_prn.Visible = false;
                add_school.Visible = false;
                add_locat.Visible = false;
                add_prog.Visible = false;
                cont_req.Visible = false;
            }
            else if (accesslvl == 2)
            {

                add_beni.Visible = true;
                add_school.Visible = true;
                add_locat.Visible = false;
                add_prog.Visible = false;
                cont_req.Visible = false;

            }
            else if (accesslvl == 3)
            {

                add_beni.Visible = true;
                add_school.Visible = true;
                add_locat.Visible = false;
                add_prog.Visible = false;
                cont_req.Visible = false;

            }
            else if (accesslvl == 4)
            {

                add_beni.Visible = false;
                add_prn.Visible = false;
                add_school.Visible = false;
                add_locat.Visible = false;
                add_prog.Visible = false;
                cont_req.Visible = false;
                view_prog.Visible = false;

            }
            else if (accesslvl == 5)
            {

                add_beni.Visible = false;
                add_prn.Visible = false;
                add_school.Visible = false;
                add_locat.Visible = false;
                add_prog.Visible = false;
                cont_req.Visible = false;
                view_prog.Visible = true;

            }
            else if (accesslvl == 6)
            {

                add_beni.Visible = true;
                add_school.Visible = true;
                add_locat.Visible = true;
                add_prog.Visible = true;
                cont_req.Visible = true;
                view_prog.Visible = true;
                btnAddContent.Visible = true;
                btnDelContent.Visible = true;

            }

            string path = Convert.ToString(Session["pic"]);
            profilepict.Src = path;

        }

        protected void logout_click(object sender, EventArgs e)
        {
            Session["accesslvl"] = 0;
            Response.Redirect("login.aspx");
        }


    }
}