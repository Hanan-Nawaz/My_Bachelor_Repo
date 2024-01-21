<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="Personal-Prosperous-Life.aspx.cs" Inherits="ABS_Project.Personal_Prosperous_Life" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Personal Prosperous Life &#8211; ABS</title>
    <style>
        #DLContent {
            background-color: white;
        }
    </style>

    <script runat="server">

        protected string GetWordsFromString(string text, int wordCount)

        {

            int wordCountIndex = -1;

            for (int index = 0; index < wordCount; index++)

            {

                wordCountIndex = text.IndexOf(" ", wordCountIndex + 1);

                if (wordCountIndex < 0)

                    break;

            }

            if (wordCountIndex > 0)

            {

                if (wordCountIndex < text.Length)

                    return text.Substring(0, wordCountIndex) + "...";

                else

                    return text;

            }

            else

                return text;

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="main-title-section-wrapper breadcrumb-left">
        <div class="main-title-section-bg" style='background-image: url(wp-content/uploads/2021/05/pattern.jpg); background-position: left top; background-size: auto; background-repeat: no-repeat; background-attachment: fixed; background-color: #f9f9f9;'></div>
        <div class="container">
            <div class="main-title-section">
                <h1 style="font-family: Roboto;">Personal Prosperous Life</h1>
            </div>
            <div class="breadcrumb">
                <a href="abs.aspx">Home  </a>
                <span class="current"><< Personal Prosperous Life</span>
            </div>
        </div>
    </section>
    <!-- ** Breadcrumb End ** -->
    <!-- ** Header Wrapper - End ** -->
    <!-- **Main** -->
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
                                    <h2>Personal Prosperous Life</h2>
                                    <span>
                                        <img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript>
                                        </noscript>
                                    </span>
                                </div>
                                <div id="1527248651419-23d6697c-39b0" class="dt-sc-empty-space"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- #post-228 -->
        </section>
            </div>

    <div class="container">


        <div class="row mb-5">
             <div class="col-md-5">
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbSearch" runat="server" placeholder="Search" OnTextChanged="tbSearch_TextChanged"></asp:TextBox>
                            </div>
                        </div>
        </div>

              <div class="row">

        <asp:DataList BackColor="#ffffff" ID="GVContent" runat="server" BorderWidth="0" RepeatColumns="2" CellSpacing="2"
           OnItemDataBound="GVContent_ItemDataBound" >
            <ItemTemplate>
                <center>
                <div class="col">
                    

                    
                    <div class="card" style="max-width: 18rem; border: 1px solid black; padding:2px; padding-top:5px; padding-bottom: 10px; border-radius: 20px;">
                    <asp:Image class="card-img-top" Width="230px" Height="200px" ImageUrl='<%# Eval("ImageContent")%>' runat="server" alt="Image" /><br />
                  <div class="card-body">
                    <h5 class=" text-black font-weight-bold card-title "><%# Eval("Title")%></h5>
                    <p class="card-text"><%# GetWordsFromString( Eval("ABSContent").ToString(), 10) %></p>
                     </p>
                  <asp:LinkButton runat="server" ID="knowMoreBtn" class='dt-sc-button   small   bordered  ' CommandArgument='<%# Eval("Id") %>' OnClick="knowMoreBtn_Click">
                                                                Know More 
                                                        </asp:LinkButton>
                  </div>
                </div>
                </div>
                </center>
            </ItemTemplate>
        </asp:DataList>
            </div>
                        </div>

       


</asp:Content>
