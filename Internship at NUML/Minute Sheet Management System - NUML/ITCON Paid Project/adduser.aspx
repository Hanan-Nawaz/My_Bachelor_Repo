<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="ITCON_Paid_Project.adduser1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <title>Add User - NUML Minute Sheet Management System</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;"><i class="fas fa-plus fa-fw " ></i> Add User/Approver</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                
                      <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 15px; user-select: none;">Add User</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                <div class="row ">
                     
                      <div class="col-md-6">
                            <label>Campus *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_campus" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select Campus</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                   <div class="col-md-6">
                            <label>Email Id *</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" TextMode="Email" ID="tb_uname" placeholder="Must Like @numl.edu.pk" runat="server" ></asp:TextBox>
                        </div>
                        </div>
                  </div>
                  
                    <div class="row">
                        <div class="col-md-6">
                            <label>Password *</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_password" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                        </div>
                        
                        <div class="col-md-6">
                            <label>Name *</label>
                             <div class="form-group">
                                 
                           <asp:TextBox CssClass="form-control" ID="tb_users_name" runat="server" placeholder="Name"></asp:TextBox>
                       
                            </div>
                        </div>
                    </div>

                    <div class="row mt-5">
                     <div class="col-md-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_sub_user" runat="server" Text="Save" OnClick="btn_sub_user_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>
                  


                    <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 15px; user-select: none;">Add Approver</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                    
                       <div class="row ">
                      
                      <div class="col-md-6">
                            <label>Campus *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_campus_" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select Campus</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                   <div class="col-md-6">
                            <label>Approver Name *</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_app_name" Placeholder="Format Like Prof. Dr Ali" runat="server" ></asp:TextBox>
                        </div>
                        </div>
                  </div>



                 


                  <div class="row mt-5">
                     <div class="col-md-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_sub_approver" runat="server" Text="Save" OnClick="btn_sub_approver_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col">
                         <centre>
                        <asp:Label ID="message" runat="server" style="color: blue;"></asp:Label>
                         </centre>
                     </div>
                  </div>

                </div>
            </div>
        </div>
</div>
</asp:Content>

