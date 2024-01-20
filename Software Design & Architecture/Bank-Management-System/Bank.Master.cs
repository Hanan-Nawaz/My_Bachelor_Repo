using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDA_Project
{
    public partial class Bank : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                profilepict.Src = Convert.ToString(Session["Picture"]);
                int accesslvl = Convert.ToInt32(Session["Accesslvl"]);
                if(accesslvl == 1)
                {
                    CloseAccount.Visible = false;
                    Show.Visible = false;
                    Approve.Visible = false;
                    Deposit.Visible = false;
                }
                else
                {
                    Transfer.Visible = false;
                    Modify.Visible = false;
                    Close.Visible = false;
                }
            }
        }

        protected void logout_btn_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session["Email"] = "";
            Session["Acesslvl"] = 0;
            Response.Redirect("Login.aspx");


        }
    }
}