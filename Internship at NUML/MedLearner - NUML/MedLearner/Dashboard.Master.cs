using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedLearner
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int Status = Convert.ToInt32(Session["Status"]);
            if (Status == 1)
            {
                if (Convert.ToInt32(Session["Occupation"]) == 1)
                {
                    btnAddCategory.Visible = false;
                    btnUsers.Visible = false;
                    btnCourse.Visible = false;
                    btnTag.Visible = false;

                }
                else if (Convert.ToInt32(Session["Occupation"]) == 2)
                {
                    btnAddCategory.Visible = false;
                    btnUsers.Visible = false;
                    btnCourse.Visible = true;
                    btnTag.Visible = true;
                }
                else if (Convert.ToInt32(Session["Occupation"]) == 3)
                {
                    btnAddCategory.Visible = true;
                    btnUsers.Visible = true;
                    btnCourse.Visible = true;
                    btnTag.Visible = true;
                }
                btn_UserName.InnerText = Session["Name"].ToString();
            }
            else
            {
                Response.Redirect("/LandingPages/signin.aspx");
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["Name"] = "";
            Session.Clear();
            Response.Redirect("/LandingPages/signin.aspx");
        }
    }
}