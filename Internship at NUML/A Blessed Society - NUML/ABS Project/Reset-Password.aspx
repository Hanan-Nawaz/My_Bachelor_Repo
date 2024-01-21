<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="Reset-Password.aspx.cs" Inherits="ABS_Project.Reset_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Reset Password &#8211; ABS</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <div class=" page-holder d-flex align-items-center">
              <section class="main-title-section-wrapper breadcrumb-left">
                <div class="main-title-section-bg" style='background-image: url(wp-content/uploads/2021/05/pattern.jpg); background-position: left top; background-size: auto; background-repeat: no-repeat; background-attachment: fixed; background-color: #f9f9f9;'></div>
                <div class="container">
                    <div class="main-title-section">
                        <h1>Reset Password</h1>
                    </div>
                    <div class="breadcrumb"><a href="abs.aspx">Home </a><span class="current"><< Reset Password</span></div>
                </div>
            </section>
            <div class="container">
                <div class="row align-items-center py-5">
                                 <asp:Panel ID="ResetPwdPanel" runat="server" Visible="false" >

                    <div class="col-lg-5 px-lg-4">
                        <h1 class="text-base text-primary text-uppercase mb-4 text-center">Forgot Password</h1>
                        <h2 class="mb-4 text-center">Welcome Back!</h2>

                        <div class="form-group mb-4">
                            <asp:TextBox required="true" ID="tb_pass1" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" runat="server" placeholder="Password"></asp:TextBox>

                        </div>

                        <div style="margin-top:30px;" class="form-group mb-4">
                            <asp:TextBox required="true" ID="tb_pass2" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password" runat="server"></asp:TextBox>

                        </div>
                        
                        <asp:Button Text="Save" CssClass="btn btn-primary mb-4" Height="50px" Width="100%" runat="server" OnClick="btnlogin_Click" />

                        <div class="form-group mb-4">
                            <div>
                                <a Style="margin-left: 85%" CssClass="btn-block btn-dark" href=".aspx" runat="server" ></a>
                            </div>
                        </div>

                    </div>
                    </asp:Panel>
                    <div class="row">
                        <div class="col-md-12">
                            <center>
                                <asp:Label CssClass="text-center" ID="message" runat="server"></asp:Label>
                                </center>
                        </div>
                    </div>
                </div>


            </div>

        </div>

                  
</asp:Content>

