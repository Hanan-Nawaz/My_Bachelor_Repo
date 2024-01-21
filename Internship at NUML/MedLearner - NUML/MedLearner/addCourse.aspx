<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addCourse.aspx.cs" Inherits="MedLearner.addCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Course</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Add Course</p>
            </div>
        </div>
    </div>

    <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">

                  <div class="row">
                     <div class="col-md-6">
                        <label>Name of Course*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Course Name Here" required></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>Main Heading*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtMainHeading" runat="server" placeholder="Main Heading Here"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                       <div class="row">
                     <div class="col">
                        <label>Description*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Course Description Here" TextMode="MultiLine" Rows="10" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                    <div class="row">
                        <div class="col-md-6">
                            <label>Category*</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlCategory" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="0">Select category</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Course Type*</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlCourseType" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="0">Select Course Type</asp:ListItem>
                                     <asp:ListItem Value="1">Live</asp:ListItem>
                                     <asp:ListItem Value="2">Recorded</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>             
                   
                <div class="row">
                     <div class="col-md-6">
                        <label>No. of Days*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtNumOfDays" runat="server" placeholder="Number of Days Here"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <label>Expiry Days*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtExpiryDays" runat="server" placeholder="Expiry Days Here" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                   <div class="row">

                        <div class="col mx-auto">
                             <center>
                                <label>Picture*</label>
                                <div class="form-group">
                                     <asp:FileUpload ID="img_vid_Upload" CssClass="form-control" AllowMultiple="true" Width="70px" runat="server"  />               
                                </div>
                            </center>
                        </div>                 
                    </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Save Course" OnClick="btnAdd_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>


                    <div class="row">
                     <div class="col-md-12">
                        <asp:Label ID="lblMessage" CssClass="text-center" runat="server" style="color: blue;"></asp:Label>
                     </div>
                  </div>

                </div>
            </div>
        </div>
</div>
</asp:Content>
