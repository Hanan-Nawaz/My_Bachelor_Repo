<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="ITCON_Paid_Project.addcategory1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                   <title>Add Category - NUML Minute Sheet Management System</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;"><i class="fas fa-plus fa-fw " ></i> Add Category</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                

                   <div class="row" >
                     
                    <div class="col-md-6 mx-auto">
                            <label> Category *</label>
                           <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_category" runat="server" placeholder="Category" Required="true" ></asp:TextBox>

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
