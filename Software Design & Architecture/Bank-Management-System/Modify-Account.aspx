<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="Modify-Account.aspx.cs" Inherits="SDA_Project.Modify_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modify Account - Bank of NUML</title>

    
     <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=sheetpic.ClientID%>').prop('src', e.target.result)
                        .width(390)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-edit fa-fw "></i>Modify Account</label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <label>Account Number</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_AccountNumber" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Cnic</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_cnic" runat="server" Readonly="false" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Father Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_fname" runat="server"  required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Job Type</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddl_jobtype" runat="server" AutoPostBack="true" required>
                                    <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                                    <asp:ListItem Value="1">Permanent Job</asp:ListItem>
                                    <asp:ListItem Value="2">Temporary Job</asp:ListItem>
                                </asp:DropDownList>
                                <span class="form-bar"></span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Salary</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_salary" runat="server" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Job Type</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddl_type" runat="server" AutoPostBack="true" required>
                                    <asp:ListItem Value="0">Select Type</asp:ListItem>
                                    <asp:ListItem Value="1">Current</asp:ListItem>
                                    <asp:ListItem Value="2">Saving</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </div>
                            <div class="col-md-6">
                                <label>Amount</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tb_amount" runat="server" placeholder="Full Title" required></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tb_password" Text="********" runat="server"  required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tb_address" runat="server"  required></asp:TextBox>
                                </div>
                            </div>
                        </div>







                        <div class="row">

                            <div class="col-md-12 mx-auto">
                                <center>

                                    <label>Upload Picture</label>
                                    <div class="form-group">
                                                    <asp:Image ID="sheetpic" Height="200px" Width="390px" CssClass="rounded mx-auto img-fluid" runat="server" /><br />
                                                          <asp:FileUpload ID="image_upload" CssClass="form-control" Width="383px" runat="server" onchange="ShowImagePreview(this);" />
                                                        <span class="form-bar"></span>                                    </div>

                                </center>
                            </div>

                            <div class="row">
                            <div class="col-md-6 mx-auto">
                                <label></label>
                                <centre>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg mx-auto" ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                                    </div>
                                    </centre>
                            </div>
                                </div>

                            <div class="row">
                                                    <div class="text-center">
                                                       
                                                        <asp:label runat="server" id="message"></asp:label>
                                                    </div>
                                                   </div>

                        </div>


                    </div>
                </div>
            </div>
        </div>
</asp:Content>
