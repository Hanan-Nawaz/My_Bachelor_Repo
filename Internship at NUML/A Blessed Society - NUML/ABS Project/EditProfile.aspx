<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ABS_Project.EditProfile" %>
    <asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
      <title>Edit Profile &#8211; A Blessed Society</title>

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
                     $('#<%=picture.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }
     </script>
        </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" />


         <div class=" page-holder d-flex align-items-center">
            <div class="container">
                <div class="row align-items-center py-5">
                    <div class="col-4 col-lg-4.7 mx-auto mb-5 mb-lg-0">

                        <div class="pr-lg-4">
                            <asp:Image runat="server" id="picture" Width="150px" Height="300px" alt="" class="img-fluid" />
                        </div>
                    </div>

                            <div class="col-lg-8 px-lg-8">

         <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Edit Profile</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr/>
                     </div>
                  </div>

                   
               
                    <div class="row">
                     <div class="col-md-4">
                        <label>Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Name" required="true"></asp:TextBox>
                        </div>
                     </div>
                    
                       
                 

                
                     <div class="col-md-4">
                        <label>User Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_username" runat="server" placeholder="User Name" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_password" runat="server" placeholder="Password" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                <div class="row">
                     <div class="col-md-4">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_email" TextMode="Email" runat="server" placeholder="Email ID"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-4">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_contact" runat="server" placeholder="Contact No" required></asp:TextBox>
                        </div>
                     </div>
                  

                  
                     <div class="col-md-4">
                        <label>Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic"  runat="server" placeholder="Cnic"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                    <div class="row">
                   <div class="col-md-4">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Address" required></asp:TextBox>
                        </div>
                     </div>
                  

                        <div class="col-md-4">
                            <label>Country</label>
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
                            <label>Province/State</label>
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
                            <label>District</label>
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
                            <label>Portfolio</label>
                            <div class="form-group">
                          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>

                           <asp:DropDownList ID="ddl_portfolio" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_portfolio_SelectedIndexChanged">
                             <asp:ListItem >Select Portfolio</asp:ListItem> 
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
                        <label runat="server" id="schlb">School(if Principal)</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_school" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select School</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                                 <div class="col-md-3">

                        <label>Profile Picture</label>
                        <div class="form-group">
                             <asp:FileUpload ID="profile_upload" CssClass="form-control" Width="70px" runat="server" onchange="ShowImagePreview(this);" />               
                        </div>

                     </div>                
                                 </div>
                     
                    
                        <asp:Button Text="Update" CssClass="btn btn-primary mb-1 mt-4" Height="50px" ID="update" Width="100%" runat="server" OnClick="update_Click" />
                   
                    
                   </div>
                                    <div class="row">
                     <div class="col-md-12 mx-auto">
                        <asp:Label ID="message" runat="server"></asp:Label>               
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