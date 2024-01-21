<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="ABS_Project.addcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Add Category &#8211; A Blessed Society</title>
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
                                <label style="color: blue; font-size: 20px; user-select: none;">Add Category</label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>                   

                    <div class="row">
                        <div class="col-md-6 mx-auto">
                            <label>Category</label>
                            <div class="form-group">

                                <asp:TextBox CssClass="form-control" ID="tb_category" runat="server" placeholder="Category" required></asp:TextBox>

                            </div>
                        </div>
                    </div>


                    <div class="row mt-5">
                        <div class="col-4 mx-auto">
                            <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                                </div>
                            </center>
                        </div>
                    </div>






                    <div class="row">
                        <div class="col mx-auto">
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
