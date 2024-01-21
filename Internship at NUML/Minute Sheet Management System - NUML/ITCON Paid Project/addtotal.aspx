<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="addtotal.aspx.cs" Inherits="ITCON_Paid_Project.addtotal1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <title>Account Head - NUML Minute Sheet Management System</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;"> <i class="fas fa-plus fa-fw " ></i> Account Head</label>
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
                            <label>Category *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_categ_list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_categ_list_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Category</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    <div class="col-md-6">
                            <label class=""></label>
                           <div class="form-group">
                              <asp:LinkButton class="btn btn-primary btn-block btn-lg" ID="ad_btn" runat="server" Text="+" href="addcategory.aspx"/>
                           </div>
                        </div>
                  </div>
                  
                    <div class="row">
                        <div class="col-md-6">
                            <label>Date *</label>
                            <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_date" runat="server" placeholder="" Readonly="true"></asp:TextBox>
                        </div>
                        </div>
                        
                        <div class="col-md-6">
                            <label>Existing Amount *</label>
                             <div class="form-group">
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                           <asp:TextBox CssClass="form-control" ID="tb_examount" runat="server" placeholder="Amount" Readonly="true"></asp:TextBox>
                       </ContentTemplate>
                          </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                  

                    

                   <div class="row" >
                     
                    <div class="col-md-6">
                            <label> New Amount *</label>
                           <div class="form-group">
                           <asp:TextBox CssClass="form-control" TextMode="Number" ID="tb_amount" runat="server" placeholder="New Amount"  ></asp:TextBox>

                           </div>
                        </div>
                       
                      

                        <div class="col-md-6">
                            <label>Name *</label>
                           <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server"  Readonly="true"></asp:TextBox>

                           </div>
                        </div>

                    </div>



                 


                  <div class="row mt-5">
                     <div class="col-md-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="submit" runat="server" Text="Save" OnClick="submit_Click"/>
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
