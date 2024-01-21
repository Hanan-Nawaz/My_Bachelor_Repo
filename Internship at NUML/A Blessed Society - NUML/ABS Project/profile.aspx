<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="ABS_Project.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>My Profile &#8211; A Blessed Society</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" />


         <div class=" page-holder d-flex align-items-center">
            <div class="container">
                <div class="row align-items-center py-5">
                    <div class="col-4 col-lg-4.7 mx-auto mb-5 mb-lg-0">

                        <div class="pr-lg-4">
                            <asp:Image runat="server"  ID="profilepic" alt="" class="img-fluid" />
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
                        <label style="color:blue; font-size: 20px; user-select: none;">Profile</label>
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
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                    
                       
                 

                
                     <div class="col-md-4">
                        <label>User Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_username" runat="server" placeholder="User Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_password" runat="server" placeholder="Password" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                <div class="row">
                     <div class="col-md-4">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_email" TextMode="Email" runat="server" placeholder="Email ID"  Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-4">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_contact" runat="server" placeholder="Contact No" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  

                  
                     <div class="col-md-4">
                        <label>Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic"  runat="server" placeholder="Cnic"  Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                     <div class="row">
                   <div class="col-md-4">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Address"  Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  

                    
                        <div class="col-md-4">
                            <label>Country</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="true"  Readonly="true">
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
                                        <asp:DropDownList CssClass="form-control" ID="ddl_province" runat="server" AutoPostBack="true"  Readonly="true">
                                            <asp:ListItem Value="0">Select Province/State</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-4">
                            <label>District</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_district" runat="server" AutoPostBack="true"  Readonly="true">
                                            <asp:ListItem Value="0">Select District</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

               <div class="col-md-4">
                            <label>Portfolio</label>
                            <div class="form-group">
                          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>

                           <asp:DropDownList ID="ddl_portfolio" CssClass="form-control" runat="server" AutoPostBack="true" Readonly="true">
                             <asp:ListItem Value="0">Select Portfolio</asp:ListItem> 
                             <asp:ListItem Value="1">Donor</asp:ListItem> 
                             <asp:ListItem Value="2">Volunteer</asp:ListItem> 
                             <asp:ListItem Value="3">Both Donor & Volunteer</asp:ListItem> 

                        </asp:DropDownList>
                            </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                                 



                    <div class="col-md-4">
                        <label></label>
                            <div class="form-group">
                                <center>
                        <asp:LinkButton CssClass="btn btn-primary mb-1 mt-1 mx-auto" ID="edit" runat="server" OnClick="edit_Click"><i class="fas fa-edit fa-fw me-3"></i>Edit Profile</asp:LinkButton>
              </center>
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
        
</asp:Content>