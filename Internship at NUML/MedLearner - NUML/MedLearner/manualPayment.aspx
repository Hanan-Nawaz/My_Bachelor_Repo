<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="manualPayment.aspx.cs" Inherits="MedLearner.manualPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom">
        <div class="container text-center py-5">
            <h1 class="text-white display-1" runat="server" id="h1CourseName"> Manual Payment </h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
          <h6 class="text-white p" runat="server" id="h6TutorName"></h6>
          <h6 class="text-white p" runat="server" id="h6Money"></h6>
        </div>
    </div>

    <div class="col-md-13">
            <div class="card p-1 m-1">
                <p>
                    Dear User, <br /><br />

                    We are excited to hear that you have chosen to purchase our course! To complete your payment, please transfer the required amount to the following bank account:
                    <br /><br />
                    Bank Name: <b>Standard Chartered</b> <br />
                    Account Name: <b>Sheraz Tariq</b><br />
                    Account Number: <b>01185137401</b><br />
                    IBAN: <b>PK98SCBL0000001185137301</b><br />
                    <br />
                    Once you have made the payment, kindly send us a screenshot of the transaction confirmation page or receipt as proof of payment. You can upload it to our website by logging into your account.
                    <br /><br />
                    Please note that it may take some time for the payment to be processed, depending on your bank's policies and procedures. Once we have received confirmation of your payment, we will provide you with access to the course materials and resources.
                    <br /><br />
                    If you have any questions or concerns about the payment process, please do not hesitate to contact us. We are always here to help and support you.
                    <br /><br />
                    Thank you for your trust in our course, and we look forward to supporting you in your educational journey!
                    <br /><br />
                    Best regards,<br />
                    Team MedLearner
                </p>
            </div>

        <div class="card-body text-center">
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" class="btn btn-primary px-4 px-lg-5 p-3" OnClick="btnConfirm_Click" />
          </div>
   </div>
</asp:Content>
