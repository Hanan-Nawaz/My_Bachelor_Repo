<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addTag.aspx.cs" Inherits="MedLearner.addTag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Tag</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Add Tag</p>
            </div>
        </div>
    </div>

    <div class="container-fluid">
      
           <div id="alertError" runat="server" class="alert alert-danger">  
            <strong>Error!</strong> A problem has been occurred while adding Tag. 
        </div>  

         <div id="alertSuccess" runat="server" class="alert alert-success">  
            <strong>Congrats!</strong> Tag Saved Successfully. 
        </div>  

         <div class="col-md-13">
            <div class="card">
               <div class="card-body">

                  <div class="row">
                     <div class="col-md-12">
                        <label>Name of Tag*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtTag" runat="server" placeholder="Tag Here" required="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Save Tag" OnClick="btnAdd_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>

                    

                </div>
            </div>
        </div>
</div>
</asp:Content>
