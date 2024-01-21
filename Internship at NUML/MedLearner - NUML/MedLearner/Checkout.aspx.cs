using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MedLearner
{
    public partial class Checkout : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        string Id, currency , CourseName = "", details, query;
        long priceToPay;

        protected void btnManual_Click(object sender, EventArgs e)
        {
            Session["boughtCourse"] = Id;
            Session["boughtCourseName"] = CourseName;
            Session["boughtCoursePrice"] = priceToPay;
            Session["boughtCourseCurrency"] = currency;
            Session["boughtCoursepaymentMethod"] = "Card";
            Session["boughtType"] = Session["Type"];
            Session["payVerify"] = 1;
            Response.Redirect("manualPayment.aspx");
        }

        public string domainName = "https://localhost:44343/";
        protected void Page_Load(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            lblMessage.Visible = false;
            Page.Title = "Checkout - MedLearner";


            priceToPay = Convert.ToInt64(Session["Price_To_Pay"]);
            CourseName = Session["CourseName"].ToString();
            currency = Session["Currency"].ToString();
            Id = Session["Course_ID"].ToString();
            details = Session["Course_Details"].ToString();

            txtDetails.InnerText = details;
            txtName.InnerText = CourseName;
            lblCourseName.InnerText = CourseName;
            txtPrice.InnerText = currency + (priceToPay / 100).ToString();


            P2.InnerText = details;
            P1.InnerText = CourseName;
            H1.InnerText = currency + (priceToPay/100).ToString();

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

            // Create a new price object
            var options = new PriceCreateOptions
            {
                UnitAmount = Convert.ToInt64(Session["Price_To_Pay"]), // in cents
                Currency = currency,
                ProductData = new PriceProductDataOptions
                {
                    Name = CourseName
                }
            };

            var priceService = new PriceService();
            Price price = priceService.Create(options);

            // Create a new checkout session with the price as the line item
            var sessionOptions = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = price.Id,
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domainName + "succesPage.aspx",
                CancelUrl = domainName + "dashboard.aspx",
            };

            var sessionService = new SessionService();
            Session session = sessionService.Create(sessionOptions);


                Session["boughtCourse"] = Id;
                Session["boughtCoursePrice"] = priceToPay;
                Session["boughtCourseCurrency"] = currency;
                Session["boughtCoursepaymentMethod"] = "Card";
                Session["boughtType"] = Session["Type"];
                Session["boughtCourseName"] = CourseName;
            Response.Redirect(session.Url, true);

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            int result = 0;
            sqlConnection.Open();

            if(Session["Course_Details"].ToString().Equals("Purchasing Exam only"))
            {
                query = "Select DiscountOnCCode from Exams where CCode='" + txtCoupionCode.Text + "' and Id='" + Convert.ToInt32(Id) + "'";
            }
            else
            {
                query = "Select DiscountOnCCode from Price where CCode='" + txtCoupionCode.Text + "' and CousreId='" + Convert.ToInt32(Id) + "'";
            }

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    result = Convert.ToInt32(rdr["DiscountOnCCode"]) * 100;
                }
            }

            if(result != 0)
            {
                lblMessage.Visible = false;
                Session["Price_To_Pay"] = result;
                txtPrice.InnerText = currency + (result / 100).ToString();
                H1.InnerText = currency + (result / 100).ToString();
            }
            else
            {
                lblMessage.InnerText = "Coupion Code doesn't exist.";
                lblMessage.Visible = true;
            }
        }
    }
}