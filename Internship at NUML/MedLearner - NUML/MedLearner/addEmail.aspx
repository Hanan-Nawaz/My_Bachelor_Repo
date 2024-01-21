<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addEmail.aspx.cs" Inherits="MedLearner.addEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Email</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Add Email</p>
            </div>
        </div>
    </div>

    <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">

                   <div class="row">
                     <div class="col-md-12">
                        <label>Course*</label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" AutoPostBack="false" required>
                                <asp:ListItem Value="0">Select Course </asp:ListItem>
                             </asp:DropDownList>                        
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-12">
                        <label>Course*</label>
                        <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlType" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="1">Welcome Email</asp:ListItem>
                                     <asp:ListItem Value="2">Manual Access Email</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-12">
                        <label>Subject*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtSubject" runat="server" placeholder="Subject Here" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-12">
                        <label>Body*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtBody" runat="server" Rows="5" TextMode="MultiLine" placeholder="Body Here" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Save Email" OnClick="btnAdd_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col">
                         <centre>
                        <asp:Label ID="lblMessage" runat="server" style="color: blue;"></asp:Label>
                         </centre>
                     </div>
                  </div>

                </div>
            </div>
        </div>
</div>
</asp:Content>
