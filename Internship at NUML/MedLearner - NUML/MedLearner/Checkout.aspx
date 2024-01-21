<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="MedLearner.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom">
        <div class="container text-center py-5">
            <h1 class="text-white display-1" runat="server" id="h1CourseName"> Checkout </h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
          <h6 class="text-white p" runat="server" id="h6TutorName"></h6>
          <h6 class="text-white p" runat="server" id="h6Money"></h6>
        </div>
    </div>



            <div class="card mb-4">
          <div class="card-body p-4 d-flex flex-row">
            <div class="form-outline flex-fill">
                <div class="row">
                  <label>Coupion Code</label>
                    <div class="col-md-9">
                         <div class="form-group">
                            <asp:TextBox CssClass="form-control border border-dark text-dark" ID="txtCoupionCode" runat="server" placeholder="Coupion Code Here"></asp:TextBox>
                         </div>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnApply" runat="server" Text="Apply" class="btn btn-primary w-100" OnClick="btnApply_Click" />
                    </div>
                </div>
              <div class="row">
                  <div class="col-md-12 text-center">
                      <label runat="server" id="lblMessage" class="text-center text-danger"></label>
                  </div>
              </div>
            </div>
          </div>
        </div>

    <section class="h-100">
  <div class="container h-100 py-5">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-10">
        <div class="card rounded-3 mb-4">
          <div class="card-body p-4">
              <h2 class="text-primary"> Pay by Card</h2>
            <div class="row d-flex justify-content-between align-items-center">
              <div class="col-md-2 col-lg-2 col-xl-2">
              </div>
              <div class="col-md-3 col-lg-3 col-xl-3">
                <p class="lead fw-normal mb-2" runat="server" id="txtName">Basic T-shirt</p>
                <p runat="server" id="txtDetails">M</p>
              </div>
              <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                <h5 class="mb-0" runat="server" id="txtPrice">$499.00</h5>
              </div>
            </div>

          <div class="card-body text-center">
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" class="btn btn-primary px-4 px-lg-5 p-3" OnClick="btnCheckout_Click" />
          </div>
                        </div>

                    </div>

        </div>

    </div>
  </div>
</section>

    <h5 class="text-center">-- Or --</h5>
    
    <section class="h-100">
  <div class="container h-100 py-5">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-10">
        <div class="card rounded-3 mb-4">
          <div class="card-body p-4">
              <h2 class="text-primary">Pay Manually</h2>
            <div class="row d-flex justify-content-between align-items-center">
              <div class="col-md-2 col-lg-2 col-xl-2">
              </div>
              <div class="col-md-3 col-lg-3 col-xl-3">
                <p class="lead fw-normal mb-2" runat="server" id="P1">Basic T-shirt</p>
                <p runat="server" id="P2">M</p>
              </div>
              <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                <h5 class="mb-0" runat="server" id="H1">$499.00</h5>
              </div>
            </div>


          <div class="card-body text-center">
            <asp:Button ID="btnManual" runat="server" Text="Pay Manually" class="btn btn-primary px-4 px-lg-5 p-3" OnClick="btnManual_Click" />
          </div>
        </div>
        </div>

      </div>
    </div>
  </div>
</section>

</asp:Content>
