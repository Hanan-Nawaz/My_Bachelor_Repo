<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="viewUser.aspx.cs" Inherits="MedLearner.viewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/signup.css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="../css/montserrat-font.css">
	<link rel="stylesheet" type="text/css" href="../fonts/material-design-iconic-font/css/material-design-iconic-font.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <!-- Header Start -->
    <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">User's Profile</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">User's Profile</p>
            </div>
        </div>
    </div>
    <!-- Header End -->

  <div class=" text-center">
                        <asp:Label runat="server" ID="lblMessage" class="text-primary"></asp:Label>
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
                  <h3 class="fw-normal mb-5" style="color: #4835d4;">General Infomation</h3>



                  <div class="row">
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <asp:TextBox runat="server" type="text" ID="txtFirstName" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <asp:TextBox runat="server" type="text" ID="txtLastName" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>
                  </div>


                  <div class="mb-4 pb-2">
                    <select class="form-control form-control-lg" runat="server" id="ddlOccupation" required ReadOnly="true">
                      <option value="0">Select Occupation</option>
                      <option value="1">Student</option>
                      <option value="2">Teacher</option>
                      <option value="3">Admin</option>
                    </select>
                  </div>

                         <div class="mb-4">
                        <div class="form-outline">
                            <asp:TextBox runat="server" type="text" ID="txtEmail" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                         <div class="mb-4">
                        <div class="form-outline">
                            <asp:TextBox runat="server" type="text" ID="txtPassword" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                        </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-6 bg-indigo text-white">
                <div class="p-5">
                  <h3 class="fw-normal mb-5 text-white">Contact Details</h3>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" ID="txtSNum" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                    </div>
                  </div>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" id="txtAInfo" class="form-control form-control-lg" ReadOnly="true"></asp:TextBox>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-md-5 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server" type="text" id="txtZip" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>
                    <div class="col-md-7 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server" type="text" ID="txtPlace" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>
                  </div>

                  <div class="mb-4 pb-2">
                    <div class="form-outline form-white">
                      <asp:TextBox runat="server" type="text" ID="txtCountry" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                    </div>
                  </div>

                  <div class="row">
                    
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server"  type="text" ID="txtPhone" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>

                       <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline form-white">
                        <asp:TextBox runat="server"  type="text" ID="txtStatus" class="form-control form-control-lg" required="true" ReadOnly="true"></asp:TextBox>
                      </div>

                    </div>
                  </div>
                 </div>
              </div>

                
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

                     <div class="row mt-5">
                     <div class="col-md-5 mr-5 ml-5">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnActive" runat="server" Text="Active" OnClick="btnActive_Click"/>
                           </div>
                        </center>
                     </div>
                         <div class="col-md-5 ml-5 mr-5">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnDeActive" runat="server" Text="DeActive" OnClick="btnDeActive_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>


                    <div class="row">
                     <div class="col-md-12">
                        <asp:Label ID="Label1" CssClass="text-center" runat="server" style="color: blue;"></asp:Label>
                     </div>
                  </div>
</asp:Content>
