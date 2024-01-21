<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="addprincipal.aspx.cs" Inherits="ABS_Project.addprincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Add Principal &#8211; A Blessed Society</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;">Register Principal</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-6">
                        <label>Principal Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Principal Name" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Principal's Cell Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cell" runat="server" placeholder="Principal's Cell Number" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-6">
                        <label>Principal's Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" placeholder="Principal's Email" required></asp:TextBox>
                        </div>
                        </div>
                      <div class="col-md-6">
                        <label>Principal's Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic" runat="server" placeholder="Principal's Cnic" required></asp:TextBox>
                        </div>
                     </div>
                    </div>

                     
                    <div class="row">
                        <div class="col-md-6">
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
                        <div class="col-md-6">
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
                        <div class="col-md-4">
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


                        <div class="col-md-4">
                            <label>Tehsil</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_tehsil" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Tehsil</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>UC</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_uc" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_uc_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select UC</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                   <div class="row" >
                    <div class="col-md-4">
                            <label>School Name</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_school" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select School</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                     <div class="col-md-6">
                        <label>UserName</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_user" runat="server" placeholder="UserName" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_pass" runat="server" placeholder="Password" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col">
                         <centre>
                        <asp:Label ID="message" runat="server" style="color: blue; text-align: centre;"></asp:Label>
                         </centre>
                     </div>
                  </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
