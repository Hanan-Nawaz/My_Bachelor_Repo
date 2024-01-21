<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="viewprofile.aspx.cs" Inherits="ITCON_Paid_Project.viewprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile - NUML Minute Sheet Management System  </title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" page-holder d-flex align-items-center">
        <div class="container">
            <div class="row align-items-center py-5">
                <div class="col-4 col-lg-4.7 mx-auto mb-5 mb-lg-0">

                    <div class="pr-lg-4">
                        <img src="photo/img_avatar.png" alt="" class="img-fluid" />
                    </div>
                </div>

                <div class="col-lg-8 px-lg-8">

                    <div class="container-fluid">

                        <div class="col-md-13">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-user fa-fw " ></i>  Profile</label>
                                            </center>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <hr />
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12">
                                            <label>User Name</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="tb_username" runat="server" placeholder="User Name" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-md-12">
                                            <label>Password</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="tb_password" runat="server" Text="********" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-6 mx-auto">
                                            <div class="form-group">
                                                <asp:LinkButton class="btn btn-primary btn-block btn-lg" ID="savename" runat="server"  href="profile.aspx"><i class="fas fa-pencil fa-fw " ></i> Edit Profile</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>