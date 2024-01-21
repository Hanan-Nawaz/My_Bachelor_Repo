<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="MedLearner.LandingPages.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	    <link href="../css/signup.css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="../css/montserrat-font.css">
	<link rel="stylesheet" type="text/css" href="../fonts/material-design-iconic-font/css/material-design-iconic-font.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Start -->
    <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Login</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="home.aspx">Home</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Login</p>
            </div>

        </div>
    </div>
    <!-- Header End -->

<form runat="server">
  <div class=" text-center">
                        <asp:Label runat="server" ID="lblMessage" class="text-danger"></asp:Label>
                   </div>
			<section class="h-100 h-custom ">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-12">
        <div class="card card-registration card-registration-2" style="border-radius: 15px;">
          <div class="card-body p-0">
            <div class="row g-0">
                
              <div class="col-lg-6">
                <div class="p-5">
                  <h3 class="fw-normal mb-5" style="color: #4835d4;">MedLearner</h3>
  
                </div>
              </div>
              <div class="col-lg-6 bg-indigo text-white">
                <div class="p-5">
                  <h3 class="fw-normal mb-5 text-white">Log In</h3>

                    <div class="mb-4">
                        <div class="form-outline form-white">
                            <asp:TextBox runat="server" type="text" ID="txtEmail" TextMode="Email" class="form-control form-control-lg" required="true"></asp:TextBox>
                            <label class="form-label" for="form3Examplea9">Your Email</label>
                        </div>
                    </div>

                         <div class="mb-4">
                        <div class="form-outline form-white">
                            <asp:TextBox runat="server" type="text" ID="txtPassword" MinLength="8" TextMode="Password" class="form-control form-control-lg" required="true"></asp:TextBox>
                            <label class="form-label" for="form3Examplea9">Your Password</label>
                        </div>
                  </div>

                  <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-light btn-lg"
                    data-mdb-ripple-color="dark" Text="Login"></asp:Button>
                </div>
              </div>   
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</form>
</asp:Content>
