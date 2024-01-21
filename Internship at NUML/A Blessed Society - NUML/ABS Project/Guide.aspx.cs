using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS_Project
{
    public partial class Guide : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["id"];
            int accesslvl = Convert.ToInt32(Id);

            if (accesslvl > 0)
            {
                message1.Visible = true;
            }
            else
            {
                message1.Visible = false;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}