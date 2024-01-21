<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="ABS_Project.Sign_UP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register &#8211; ABS </title>
    <script
  type="text/javascript"
  src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.11.0/mdb.min.js"
></script>
        <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>

     <script type="text/javascript">
         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=profilepic.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
                     <asp:ScriptManager ID="ScriptManager1" runat="server" />


         <div class=" page-holder d-flex align-items-center">
             <section class="main-title-section-wrapper breadcrumb-left">
                <div class="main-title-section-bg" style='background-image: url(wp-content/uploads/2021/05/pattern.jpg); background-position: left top; background-size: auto; background-repeat: no-repeat; background-attachment: fixed; background-color: #f9f9f9;'></div>
                <div class="container">
                    <div class="main-title-section">
                        <h1>Registration</h1>
                    </div>
                    <div class="breadcrumb"><a href="abs.aspx">Home </a> <span class="current"><< Registration</span></div>
                </div>
            </section>
            <div class="container">
                <div class="row align-items-center py-5">
                    <div class="col-4 col-lg-4.7 mx-auto mb-5 mb-lg-0">

                      

                            <div class="col-lg-8 px-lg-8">

         <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
<h1 class="text-base text-primary text-uppercase mb-4 text-center">Register </h1>
                        <h2 class="mb-4 text-center">Welcome!</h2>                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr/>
                     </div>
                  </div>

                   
                  <div class="row">
                     <div class="col mx-auto">
                         <center>

                        <label>Profile Picture*</label>
                        <div class="form-group">
                             <asp:Image ID="profilepic" Height="70px" Width="70px" runat="server" /><br />
                             <asp:FileUpload ID="profile_upload" CssClass="form-control" Width="70px" runat="server" onchange="ShowImagePreview(this);" />               
                        </div>

                             </center>
                     </div>
                    </div>

                    <div class="row">
                     <div class="col-md-4">
                        <label>Name*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Name" required="true"></asp:TextBox>
                        </div>
                     </div>
                    
                       
                 

                
                     <div class="col-md-4">
                        <label>User Name*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_username" runat="server" placeholder="User Name" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Password*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_password" TextMode="Password" runat="server" placeholder="Password" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                <div class="row">
                     <div class="col-md-4">
                        <label>Email ID*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_email" TextMode="Email" runat="server" placeholder="Email ID"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-4">
                        <label>Contact Number*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_contact" runat="server" placeholder="Contact No" required></asp:TextBox>
                        </div>
                     </div>
                  

                  
                     <div class="col-md-4">
                        <label>Cnic*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic"  runat="server" placeholder="Cnic"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                    <div class="row">
                   <div class="col-md-4">
                        <label>Address*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Address" required></asp:TextBox>
                        </div>
                     </div>
                  

                    
                        <div class="col-md-4">
                            <label>Country*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Province/State*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_province" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_province_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Province/State</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-3">
                            <label>District*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_district" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select District</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                      
               <div class="col-md-3">
                            <label>Portfolio*</label>
                            <div class="form-group">
                          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>

                           <asp:DropDownList ID="ddl_portfolio" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_portfolio_SelectedIndexChanged">
                             <asp:ListItem Value="0">Select Portfolio</asp:ListItem> 
                             <asp:ListItem Value="1">Donor</asp:ListItem> 
                             <asp:ListItem Value="2">Volunteer</asp:ListItem> 
                             <asp:ListItem Value="4">Principal</asp:ListItem> 
                             <asp:ListItem Value="3">Both Donor & Volunteer</asp:ListItem> 

                        </asp:DropDownList>
                            </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                          <div class="col-md-3">
                        <label runat="server" id="schlb">Select School(If Principal)</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_school" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select School</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                        <asp:LinkButton Height="20px" Width="10px" ID="add" runat="server" OnClick="add_Click">  <i class="fas fa-plus fa-fw me-3" ></i></asp:LinkButton>

                            </div>
                        </div>

                                                    <div class="col-md-3">

                           <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>

                        <label runat="server" id="lb_sch">Add School</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_school" runat="server" placeholder="School" required></asp:TextBox>
                                                    <asp:LinkButton Height="20px" Width="10px" ID="addbtn" runat="server" OnClick="addbtn_Click">  <span>&#10003;</span></asp:LinkButton>

                     </div>

                   </ContentTemplate>
                                </asp:UpdatePanel>
                                                                                </div>

                                 </div>

                       


                    
                        <asp:Button Text="Register" CssClass="btn btn-primary mb-1 mt-4" Height="50px" Width="100%" runat="server" OnClick="submit_Click" />
                    <div class="form-group mb-1">
                            <div>

                                <asp:LinkButton Text=" Login" Style=" margin-top: 2px; margin-left:80%; font-weight:bolder;" OnClick="login_btn_Click" runat="server" />
                            </div>
                        </div>
                    
                   </div>
                                    <div class="row">
                     <div class="col-md-12 mx-auto">
                        <asp:Label ID="message" runat="server" style="color: red;"></asp:Label>               
                     </div>
                  </div>

                </div>
            </div>
        </div>
    </div>
</div>
</div>
</div>
</asp:Content>
