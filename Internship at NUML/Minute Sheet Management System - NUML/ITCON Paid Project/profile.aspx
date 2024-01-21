<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="ITCON_Paid_Project.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title> Edit Profile - NUML Minute Sheet Management System  </title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 30px; user-select: none;"><i class="fas fa-edit fa-fw " ></i> Edit Profile</label>
                   
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>




                      <div class="row mt-5">
                           
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:LinkButton class="btn btn-primary btn-block btn-lg"  ID="edit_profile1" runat="server" OnClick="edit_profile_Click"> <i class="fas fa-pencil fa-fw " ></i> Edit Profile</asp:LinkButton>
                                </div>
                        </div>

                              
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:LinkButton class="btn btn-primary btn-block btn-lg" ID="change_pass1"  runat="server"  OnClick="change_pass_Click" ><i class="fas fa-pencil fa-fw " ></i> Change Password</asp:LinkButton>
                                </div>
                        </div>


                    </div>



                     <div class="row">
                     <div class="col">
                        <center>
                        <label runat="server" id="edit_text" style="color:blue; font-size: 20px; user-select: none;"><i class="fas fa-edit fa-fw " ></i>  Edit Name</label>
                   
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div runat="server" id="edit" class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                        <div class="col-md-4">
                            <label runat="server" id="nam">Old Name</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name_old" runat="server" placeholder="Old Name"></asp:TextBox>
                        </div>
                        </div>
                        
                        <div class="col-md-4">
                            <label runat="server" id="nam1">New Name</label>
                             <div class="form-group">
                                 
                           <asp:TextBox CssClass="form-control" ID="tb_name_new" runat="server" placeholder="New Name"></asp:TextBox>
                       
                            </div>
                        </div>

                         <div class="col-md-4">
                            <label runat="server" id="nam2">Confirm New Name</label>
                             <div class="form-group">
                                 
                           <asp:TextBox CssClass="form-control" ID="tb_c_name" runat="server" placeholder="Confirm New Name"></asp:TextBox>
                       
                            </div>
                        </div>
   
                       

                    </div>


                   <div class="row">
                        <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg"  ID="savename" runat="server" Text="Save Name" OnClick="savename_Click" />
                                </div>
                        </div>
                   </div>

                     <div class="row">
                     <div class="col">
                        <center>
                        <label runat="server" id="pass" style="color:blue; font-size: 20px; user-select: none;"><i class="fas fa-edit fa-fw " ></i>  Edit Password</label>
                   
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div runat="server" id="pass_line" class="col">
                        <hr>
                     </div>
                  </div>
                   
                   <div class="row">
                        <div class="col-md-4">
                            <label runat="server" id="pas">Old Password</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_o_pass" runat="server" placeholder="Old Password"></asp:TextBox>
                        </div>
                        </div>
                        
                        <div class="col-md-4">
                            <label runat="server" id="pas1">New Password</label>
                             <div class="form-group">
                                 
                           <asp:TextBox CssClass="form-control" ID="tb_n_pass" runat="server" placeholder="New Password"></asp:TextBox>
                       
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label runat="server" id="pas2">Confirm Password</label>
                             <div class="form-group">
                                 
                           <asp:TextBox CssClass="form-control" ID="tb_cn_pass" runat="server" placeholder="Confirm New Password"></asp:TextBox>
                       
                            </div>
                        </div>
                         

                    </div>

                   <div class="row">
                          
                        <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg"  ID="save_pass" runat="server" Text="Save Password" OnClick="save_pass_Click" />
                                </div>
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
