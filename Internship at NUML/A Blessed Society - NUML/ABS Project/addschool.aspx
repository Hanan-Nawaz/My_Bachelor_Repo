<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="addschool.aspx.cs" Inherits="ABS_Project.addschool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Add School &#8211; A Blessed Society</title>

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
                                <label style="color: blue; font-size: 20px; user-select: none;">Add School</label>
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
                        <div class="col-md-6">
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
                        <div class="col-md-6">
                            <label>District*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_district" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select District</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                                                </div>

                             <div class="col-md-6">
                            <label>School Name*</label>
                            <div class="form-group">

                                <asp:TextBox CssClass="form-control" ID="tb_schoolname" runat="server" placeholder="School Name" required></asp:TextBox>

                            </div>
                        </div>
                        </div>

                      
                    <div class="row">
                       


                    <div class="row mt-5">
                        <div class="col-8 mx-auto">
                            <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                                </div>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <centre>
                                <asp:Label ID="message" runat="server" Style="color: blue; text-align: center;"></asp:Label>
                            </centre>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
