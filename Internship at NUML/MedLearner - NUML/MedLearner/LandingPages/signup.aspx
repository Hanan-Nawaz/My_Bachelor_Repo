<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="MedLearner.LandingPages.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	    <link href="../css/signup.css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="../css/montserrat-font.css">
	<link rel="stylesheet" type="text/css" href="../fonts/material-design-iconic-font/css/material-design-iconic-font.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header Start -->
    <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Join Us</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="home.aspx">Home</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Join Us</p>
            </div>
        </div>
    </div>
    <!-- Header End -->

                      	    <form runat="server">
  <div class=" text-center">
                        <asp:Label runat="server" ID="lblMessage" class="text-primary"></asp:Label>
                   </div>
			<section class="h-100 h-custom ">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-12">
        <div class="card card-registration card-registration-2" style="border-radius: 15px;">
          <div class="card-body p-0">

           <div id="alertError" runat="server" class="alert alert-danger">  
            <strong>Error!</strong> A problem has been occurred while SignUp. 
        </div>  

         <div id="alertSuccess" runat="server" class="alert alert-success">  
            <strong>Congrats!</strong> Account Created Successfully. 
        </div>  

            <div class="row g-0">
                
              <div class="col-lg-6">
                <div class="p-5">
                  <h3 class="fw-normal mb-5" style="color: #4835d4;">General Infomation</h3>



                  <div class="row">
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <asp:TextBox runat="server" type="text" ID="txtFirstName" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplev2">First name</label>
                      </div>

                    </div>
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <asp:TextBox runat="server" type="text" ID="txtLastName" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplev3">Last name</label>
                      </div>

                    </div>
                  </div>


                  <div class="mb-4 pb-2">
                    <select class="form-control form-control-lg" runat="server" id="ddlOccupation" required="required">
                      <option value="0">Select Occupation</option>
                      <option value="1">Student</option>
                      <option value="2">Teacher</option>
                      <option value="3">Admin</option>
                    </select>
                  </div>

                         <div class="mb-4">
                        <div class="form-outline form-white">
                            <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" class="form-control form-control-lg" required="true"></asp:TextBox>
                            <label class="form-label" for="form3Examplea9">Your Email</label>
                        </div>
                    </div>

                         <div class="mb-4">
                        <div class="form-outline form-white">
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" MinLength="8" class="form-control form-control-lg" required="true"></asp:TextBox>
                            <label class="form-label" for="form3Examplea9">Your Password</label>
                        </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 bg-indigo text-white">
                <div class="p-5">
                  <h3 class="fw-normal mb-5 text-white">Contact Details</h3>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" ID="txtSNum" class="form-control form-control-lg" required="true"></asp:TextBox>
                      <label class="form-label" for="form3Examplea2">Street + Nr</label>
                    </div>
                  </div>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" id="txtAInfo" class="form-control form-control-lg" ></asp:TextBox>
                      <label class="form-label" for="form3Examplea3">Additional Information</label>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-md-5 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server" type="text" id="txtZip" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplea4">Zip Code</label>
                      </div>

                    </div>
                    <div class="col-md-7 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server" type="text" ID="txtPlace" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplea5">Place</label>
                      </div>

                    </div>
                  </div>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" ID="txtCountry" class="form-control form-control-lg" required="true"></asp:TextBox>
                      <label class="form-label" for="form3Examplea6">Country</label>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-md-5 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox  type="text" runat="server" ID="txtCode" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplea7">Code +</label>
                      </div>

                    </div>
                    <div class="col-md-7 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server"  type="text" ID="txtPhone" class="form-control form-control-lg" required="true"></asp:TextBox>
                        <label class="form-label" for="form3Examplea8">Phone Number</label>
                      </div>

                    </div>
                  </div>

                  

                  <div class="form-check d-flex justify-content-start mb-4 pb-3">
                    <input class="form-check-input me-3" type="checkbox" value="" id="form2Example3c" required />
                    <label class="form-check-label text-white" for="form2Example3">
                      I do accept the <a href="#!" class="text-white"><u>Terms and Conditions</u></a> of your
                      site.
                    </label>
                  </div>

                  <asp:Button runat="server" ID="btnRegiste" OnClick="btnRegister_Click" class="btn btn-light btn-lg"
                    data-mdb-ripple-color="dark" Text="Register"></asp:Button>

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
