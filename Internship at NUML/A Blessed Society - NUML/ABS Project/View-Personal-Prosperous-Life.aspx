<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="View-Personal-Prosperous-Life.aspx.cs" Inherits="ABS_Project.View_Personal_Prosperous_Life" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Personal Prosperous Life &#8211; A Blessed Society</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="main-title-section-wrapper breadcrumb-left">
        <div class="main-title-section-bg" runat="server" style='background-image: url(wp-content/uploads/2021/05/pattern.jpg); background-position: left top; background-size: auto; background-repeat: no-repeat; background-attachment: fixed; background-color: #f9f9f9;'></div>
        <div class="container">
            <div class="main-title-section">
                <h1 id="title" runat="server" style="font-family: Roboto;"></h1>
            </div>
            <div class="breadcrumb">
                <a href="Personal-Prosperous-Life.aspx">Personal Prosperous Life  </a> <<
                <span id="tbBack" runat="server" class="current"> Personal Prosperous Life</span>
            </div>
        </div>
    </section>
    <!-- ** Breadcrumb End ** -->
    <!-- ** Header Wrapper - End ** -->
    <!-- **Main** -->
     <div id="main">

                <!-- ** Container ** -->
                <div class="container">
                    <!-- Primary -->
                    <section id="primary" class="content-full-width">
                        <!-- #post-228 -->
                        <div id="post-228" class="post-228 page type-page status-publish hentry">
                            <div class="vc_row wpb_row vc_row-fluid vc_row-o-equal-height vc_row-flex">
                                <div class="wpb_column vc_column_container vc_col-sm-12">
                        <div class="vc_column-inner ">
                            <div class="wpb_wrapper">
                                <div id="1512545111455-7f072856-28db" class="dt-sc-empty-space"></div>
                                <div class="dt-sc-title with-image dt-sc-online-learning-title">
                                    <h2 id="MainHead" runat="server"></h2>
                                    <span>
                                        <img width="19" height="43" alt="onliine-learning-title-img" id="ImgBack" runat="server" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" id="imgBacks" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript>
                                        </noscript>
                                    </span>


                                </div>
                                <div id="1527248651419-23d6697c-39b0" class="dt-sc-empty-space"></div>

                            </div>
                          
                            
                           
                        </div>
                    </div>
                                  <div class="wpb_column vc_column_container vc_col-sm-6">
                                    <div class="vc_column-inner vc_custom_1528195265713">
                                        <div class="wpb_wrapper">
                                                                                                                                                    <asp:Image runat="server" ID="Image" Height="300px" />
</div>
                                    </div>
                                </div>
                                <div class="wpb_column vc_column_container vc_col-sm-6">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class="wpb_text_column wpb_content_element  vc_custom_1620727477419">
                                                <div class="wpb_wrapper">
                                                    <asp:TextBox id="descBox" class="text-dark border-0" runat="server" TextMode="MultiLine" Rows="50" ForeColor="Black" BorderWidth="0" BorderStyle="None" BorderColor="White" BackColor="White" ReadOnly="True">
                                                        ABS (A Blessed Society) is a forum managed by young volunteers from all over the world for the development of the youth. All its members are fully committed to help each other in the identification of their
                                                        challenges and overcome those through mutual cooperation, collaboration and positive peer pressure; thus, bringing prosperity in each youngster’s life.
                                                    </asp:TextBox>
                                                     

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                   
                </div>

                             <div class="row mb-5" style="margin-top: 0px; margin-bottom: 100px; margin-left: auto; margin-right: auto;">
                            <div class="col">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnDownload" runat="server" Text="Download Slides" OnClick="btnDownload_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>


                       <div class="row mt-5" >
         <div class="col">
             <center>
                                    <div class="form-group">
              <img src="pictures/admin.jpg" width="100px" height="100px"/> <br /> <h6>by Dr. Sultan</h6>
                                    </div>
                                </center>
         </div>
                                       </div>
            </div>
           
    
            <!-- #post-228 -->
        </section>
                </div>
         </div>        
  
</asp:Content>
