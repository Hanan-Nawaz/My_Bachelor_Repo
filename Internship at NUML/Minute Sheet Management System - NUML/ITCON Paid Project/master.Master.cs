using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCON_Paid_Project
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var acess = Session["acesslvl"];
            int acesslvl = Convert.ToInt32(acess);

            if(acesslvl == 0)
            {
                Response.Redirect("login_page.aspx");
            }
            else
            {

            
            if (acesslvl == 1)
            {
                
                see_history.Visible = false;
                add_user.Visible = false;
                view_cate.Visible = false;
            }
                if (acesslvl == 5)
                {

                    add_min.Visible = false;
                }

            }



        }


        protected void logout_btn_Click(object sender, EventArgs e)
        {

            
                Session["Username"] = "";
                Session["acesslvl"] = 0;
                Response.Redirect("login_page.aspx");
            
           
        }     
    }
}