<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="View-Account.aspx.cs" Inherits="SDA_Project.View_Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <title>View Account - Bank of NUML</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-eye fa-fw " ></i> View Account</label>
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
                                <asp:TextBox CssClass="form-control" ID="tb_AccountNumber" runat="server" placeholder="Letter Number" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                        </div>

                    <div class="row">
                       
                        <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>  
                        <div class="col-md-6">
                            <label>Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>                       
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Cnic</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_cnic" runat="server" placeholder="Full Title" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Father Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_fname" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-6">
                            <label>Job Type</label>
                            <div class="form-group">
                                                            <asp:DropDownList CssClass="form-control" ID="ddl_jobtype" runat="server" ReadOnly="true" AutoPostBack="true" required>
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
                                <asp:TextBox CssClass="form-control" ID="tb_salary" runat="server"  ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                    </div>
                       
                    <div class="row">
                        <div class="col-md-6">
                            <label>Job Type</label>
                            <div class="form-group">
                                                             <asp:DropDownList CssClass="form-control" ID="ddl_type" runat="server" AutoPostBack="true" ReadOnly="true" required>
                                                                <asp:ListItem Value="0">Select Type</asp:ListItem>
                                                                <asp:ListItem Value="1">Current</asp:ListItem>
                                                                <asp:ListItem Value="2">Saving</asp:ListItem>
                                                            </asp:DropDownList>                       
                        </div>
                            </div>
                        <div class="col-md-6">
                            <label>Amount</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_amount" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                        </div>
                       
                        <div class="row">
                        <div class="col-md-6">
                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_password" Text="********" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    



                    

                    <div class="row">

                        <div class="col-md-12 mx-auto">
                            <center>

                                <label>Upload Picture</label>
                                <div class="form-group">
                                  <asp:Image ID="image" Height="200px" Width="390px" CssClass="rounded mx-auto img-fluid" runat="server" /><br />
                                </div>

                            </center>
                        </div>



                    </div>


                </div>
            </div>
        </div>
    </div>
   

</asp:Content>