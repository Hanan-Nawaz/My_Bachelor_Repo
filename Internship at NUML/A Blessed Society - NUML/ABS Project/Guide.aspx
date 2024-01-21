<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="Guide.aspx.cs" Inherits="ABS_Project.Guide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Guide &#8211; ABS</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" page-holder d-flex align-items-center">
                             <section class="main-title-section-wrapper breadcrumb-left">
                <div class="main-title-section-bg" style='background-image: url(wp-content/uploads/2021/05/pattern.jpg); background-position: left top; background-size: auto; background-repeat: no-repeat; background-attachment: fixed; background-color: #f9f9f9;'></div>
                <div class="container">
                    <div class="main-title-section">
                        <h1>Guide</h1>
                    </div>
                    <div class="breadcrumb"><a href="abs.aspx">Home </a><span class="current"><< Guide</span></div>
                </div>
            </section>
            <div class="container">
                <div class="row align-items-center py-5">

                    <div class="col-lg-5 px-lg-4">
                        <h1 class="text-base text-primary text-uppercase mb-4 text-center">Guide ABS</h1>
                        <h2 class="mb-4 text-center">Welcome!</h2>

                      <div class="row">
                        <div class="col-md-12">
                            <center>
                                <asp:Label ID="message1" CssClass="text-center" Text="Registered Successfully!" runat="server"></asp:Label>
                                </center>
                        </div>
                    </div>


                        <div style="margin-top: 40px;" class="row">
                        <div class="col">
                                                                                        <label>Donor Guide</label>

                            <div class="embed-responsive embed-responsive-16by9">
                            <center>

                                 <iframe id="don" class="embed-responsive-item"  runat="server" type="text/html" 
                              src="https://www.youtube.com/embed/vZ9fFmDZ6as"
                              frameborder="0" allowfullscreen></iframe>                
                            
                                </center></div>
                            </div>

                             <div class="col">
                                                            <label>Volunteer Guide</label>
                                     
                            <div class="embed-responsive embed-responsive-16by9">
                            <center>

                                 <iframe id="vol" class="embed-responsive-item"  runat="server" type="text/html" 
                              src="https://www.youtube.com/embed/X2ZjlrJ_1Sg"
                              frameborder="0" allowfullscreen></iframe>                
                            
                                </center></div>
                            </div>
                            </div>

                        
                        <asp:Button Text="LOGIN" CssClass="btn btn-primary mb-4" Height="50px" Width="100%" runat="server" OnClick="login_Click" />

                                                    <label style="margin-top: 30px">.</label>


                    </div>

                    
                </div>


            </div>

        </div>
</asp:Content>
