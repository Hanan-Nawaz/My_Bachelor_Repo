using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCON_Paid_Project
{
    public partial class viewprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          int  accesslvl = Convert.ToInt32(Session["acesslvl"]);

            if (accesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }
            else
            {
                tb_name.Text = Session["name"].ToString();
                tb_username.Text = Session["username"].ToString();
            }
        }
    }
}