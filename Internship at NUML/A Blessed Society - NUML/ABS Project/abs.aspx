<%@ Page Title="" Language="C#" MasterPageFile="~/absmain.Master" AutoEventWireup="true" CodeBehind="abs.aspx.cs" Inherits="ABS_Project.abs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ABS &#8211; A Blessed Society</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="wrapper" style="margin-top: -40px;">

        <!-- ** Inner Wrapper ** -->
        <div class="inner-wrapper">
            <!-- ** Header Wrapper ** -->
            <div id="header-wrapper" class="header-top-relative">
   <div id="slider">
                    <div id="dt-sc-rev-slider" class="dt-sc-main-slider">
                        <!-- START Home REVOLUTION SLIDER 6.4.8 -->
                        <p class="rs-p-wp-fix"></p>
                        <rs-module-wrap id="rev_slider_1_1_wrapper" data-source="gallery" style="background:transparent;padding:0;margin:0px auto;margin-top:0;margin-bottom:0;">
                            <rs-module id="rev_slider_1_1" style="" data-version="6.4.8">
                                <rs-slides>
                                    <rs-slide data-key="rs-2" data-title="Slide" data-thumb="pictures/pic0.jpg" data-anim="p:dark;" data-in="o:0;" data-out="o:0;">
                                        <img src="pictures/pic0.jpg" title="MPM" width="1203" height="650" class="rev-slidebg tp-rs-img" data-panzoom="d:20000;ss:100;se:115;" data-no-retina>
                                        <!---->
                                    </rs-slide>
                                    <rs-slide data-key="rs-1" data-title="Slide" data-thumb="pictures/pic.jpg"" data-anim="p:dark;" data-in="o:0;" data-out="o:0;">
                                        <img src="pictures/pic.jpg" title="people-2557399_1280" width="1280" height="853" class="rev-slidebg tp-rs-img" data-panzoom="d:20000;ss:100;se:115;" data-no-retina>
                                        <!---->
                                    </rs-slide>
                                    <rs-slide data-key="rs-3" data-title="Slide" data-thumb="pictures/img1.png" data-anim="p:dark;" data-in="o:0;" data-out="o:0;">
                                        <img src="pictures/img1.png" title="Scholarships-in-Pakistan-Cover-06-08" width="1440" height="625" class="rev-slidebg tp-rs-img" data-panzoom="d:20000;ss:100;se:115;" data-no-retina>
                                        <!--
                                        -->
                                        <rs-layer id="slider-1-slide-3-layer-0" data-type="shape" data-rsp_ch="on" data-xy="x:c;y:c;" data-text="w:normal;" data-dim="w:100%;h:100%;" data-basealign="slide" data-frame_999="o:0;st:w;sp:50;sR:290;" style="z-index:8;background-color:rgba(0,0,0,0.5);">
                                        </rs-layer>
                                        <!--
                                        -->
                                    </rs-slide>
                                    <rs-slide data-key="rs-4" data-title="Slide" data-thumb="pictures/img.png" data-anim="p:dark;" data-in="o:0;" data-out="o:0;">
                                        <img src="pictures/img.png" title="1064806716_0_192_3054_1909_1200x0_80_0_1_66aefbb4966bd146a544ec2dc29b8446" width="1200" height="675" class="rev-slidebg tp-rs-img"
                                             data-panzoom="d:20000;ss:100;se:115;" data-no-retina>
                                        <!---->
                                    </rs-slide>
                                </rs-slides>
                            </rs-module>
                            <script type="text/javascript">
                                setREVStartSize({
                                    c: 'rev_slider_1_1',
                                    rl: [1240, 1024, 778, 480],
                                    el: [650],
                                    gw: [1240],
                                    gh: [650],
                                    type: 'standard',
                                    justify: '',
                                    layout: 'fullwidth',
                                    mh: "0"
                                });
                                var revapi1,
                                    tpj;

                                function revinit_revslider11() {
                                    jQuery(function () {
                                        tpj = jQuery;
                                        revapi1 = tpj("#rev_slider_1_1");
                                        if (revapi1 == undefined || revapi1.revolution == undefined) {
                                            revslider_showDoubleJqueryError("rev_slider_1_1");
                                        } else {
                                            revapi1.revolution({
                                                DPR: "dpr",
                                                sliderLayout: "fullwidth",
                                                visibilityLevels: "1240,1024,778,480",
                                                gridwidth: 1240,
                                                gridheight: 650,
                                                spinner: "spinner3",
                                                perspective: 600,
                                                perspectiveType: "local",
                                                editorheight: "650,768,960,720",
                                                responsiveLevels: "1240,1024,778,480",
                                                progressBar: {
                                                    disableProgressBar: true
                                                },
                                                navigation: {
                                                    mouseScrollNavigation: false,
                                                    wheelCallDelay: 1000,
                                                    onHoverStop: false,
                                                    arrows: {
                                                        enable: true,
                                                        style: "uranus",
                                                        hide_onleave: true,
                                                        left: {

                                                        },
                                                        right: {

                                                        }
                                                    },
                                                    bullets: {
                                                        enable: true,
                                                        tmp: "",
                                                        style: "hermes",
                                                        hide_onleave: true
                                                    }
                                                },
                                                fallbacks: {
                                                    allowHTML5AutoPlayOnAndroid: true
                                                },
                                            });
                                        }

                                    });
                                } // End of RevInitScript
                                var once_revslider11 = false;
                                if (document.readyState === "loading") {
                                    document.addEventListener('readystatechange', function () {
                                        if ((document.readyState === "interactive" || document.readyState === "complete") && !once_revslider11) {
                                            once_revslider11 = true;
                                            revinit_revslider11();
                                        }
                                    });
                                } else {
                                    once_revslider11 = true;
                                    revinit_revslider11();
                                }
                            </script>
                            <script>
                                var htmlDivCss = unescape("%23rev_slider_1_1_wrapper%20rs-loader.spinner3%20div%20%7B%20background-color%3A%20rgba%282%2C%202%2C%202%2C%200.39%29%20%21important%3B%20%7D");
                                var htmlDiv = document.getElementById('rs-plugin-settings-inline-css');
                                if (htmlDiv) {
                                    htmlDiv.innerHTML = htmlDiv.innerHTML + htmlDivCss;
                                } else {
                                    var htmlDiv = document.createElement('div');
                                    htmlDiv.innerHTML = '<style>' + htmlDivCss + '</style>';
                                    document.getElementsByTagName('head')[0].appendChild(htmlDiv.childNodes[0]);
                                }
                            </script>
                            <script>
                                var htmlDivCss = unescape("%23rev_slider_1_1_wrapper%20.uranus.tparrows%20%7B%0A%20%20width%3A50px%3B%0A%20%20height%3A50px%3B%0A%20%20background%3Argba%28255%2C255%2C255%2C0%29%3B%0A%20%7D%0A%20%23rev_slider_1_1_wrapper%20.uranus.tparrows%3Abefore%20%7B%0A%20width%3A50px%3B%0A%20height%3A50px%3B%0A%20line-height%3A50px%3B%0A%20font-size%3A40px%3B%0A%20transition%3Aall%200.3s%3B%0A-webkit-transition%3Aall%200.3s%3B%0A%20%7D%0A%20%0A%20%20%23rev_slider_1_1_wrapper%20.uranus.tparrows%3Ahover%3Abefore%20%7B%0A%20%20%20%20opacity%3A0.75%3B%0A%20%20%7D%0A%23rev_slider_1_1_wrapper%20.hermes.tp-bullets%20%7B%0A%7D%0A%0A%23rev_slider_1_1_wrapper%20.hermes%20.tp-bullet%20%7B%0A%20%20%20%20overflow%3Ahidden%3B%0A%20%20%20%20border-radius%3A50%25%3B%0A%20%20%20%20width%3A16px%3B%0A%20%20%20%20height%3A16px%3B%0A%20%20%20%20background-color%3A%20rgba%280%2C%200%2C%200%2C%200%29%3B%0A%20%20%20%20box-shadow%3A%20inset%200%200%200%202px%20rgba%28255%2C%20255%2C%20255%2C%200.55%29%3B%0A%20%20%20%20-webkit-transition%3A%20background%200.3s%20ease%3B%0A%20%20%20%20transition%3A%20background%200.3s%20ease%3B%0A%20%20%20%20position%3Aabsolute%3B%0A%7D%0A%0A%23rev_slider_1_1_wrapper%20.hermes%20.tp-bullet%3Ahover%20%7B%0A%09%20%20background-color%3A%20rgba%28255%2C%20255%2C%20255%2C%200.98%29%3B%0A%7D%0A%23rev_slider_1_1_wrapper%20.hermes%20.tp-bullet%3Aafter%20%7B%0A%20%20content%3A%20%27%20%27%3B%0A%20%20position%3A%20absolute%3B%0A%20%20bottom%3A%200%3B%0A%20%20height%3A%200%3B%0A%20%20left%3A%200%3B%0A%20%20width%3A%20100%25%3B%0A%20%20background-color%3A%20rgba%28255%2C%20255%2C%20255%2C%200.55%29%3B%0A%20%20box-shadow%3A%200%200%201px%20rgba%28255%2C%20255%2C%20255%2C%200.55%29%3B%0A%20%20-webkit-transition%3A%20height%200.3s%20ease%3B%0A%20%20transition%3A%20height%200.3s%20ease%3B%0A%7D%0A%23rev_slider_1_1_wrapper%20.hermes%20.tp-bullet.selected%3Aafter%20%7B%0A%20%20height%3A100%25%3B%0A%7D%0A%0A");
                                var htmlDiv = document.getElementById('rs-plugin-settings-inline-css');
                                if (htmlDiv) {
                                    htmlDiv.innerHTML = htmlDiv.innerHTML + htmlDivCss;
                                } else {
                                    var htmlDiv = document.createElement('div');
                                    htmlDiv.innerHTML = '<style>' + htmlDivCss + '</style>';
                                    document.getElementsByTagName('head')[0].appendChild(htmlDiv.childNodes[0]);
                                }
                            </script>
                            <script>
                                var htmlDivCss = unescape("%0A%0A%0A%0A%0A%0A%0A%0A");
                                var htmlDiv = document.getElementById('rs-plugin-settings-inline-css');
                                if (htmlDiv) {
                                    htmlDiv.innerHTML = htmlDiv.innerHTML + htmlDivCss;
                                } else {
                                    var htmlDiv = document.createElement('div');
                                    htmlDiv.innerHTML = '<style>' + htmlDivCss + '</style>';
                                    document.getElementsByTagName('head')[0].appendChild(htmlDiv.childNodes[0]);
                                }
                            </script>
                        </rs-module-wrap>
                        <!-- END REVOLUTION SLIDER -->
                    </div>
                </div>
                <!-- ** Slider End ** -->
                <!-- ** Breadcrumb ** -->
                <!-- ** Breadcrumb End ** -->
            </div>
            <!-- ** Header Wrapper - End ** -->
            <!-- **Main** -->
            <div id="main">

                <!-- ** Container ** -->
                <div class="container">
                    <!-- Primary -->
                    <section id="primary" class="content-full-width">
                        <!-- #post-21 -->
                        <div id="post-21" class="post-21 page type-page status-publish hentry">
                            <div class="vc_row wpb_row vc_row-fluid vc_custom_1634155779080">
                                <div class="wpb_column vc_column_container vc_col-sm-12">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class="dt-sc-title with-image dt-sc-online-learning-title aligncenter">
                                         
                                                <h5><img style="margin-top: 10px;" width="221" height="144" alt="" data-srcset="wp-content/uploads/2021/05/abs4-removebg-preview.png 621w, wp-content/uploads/2021/05/abs4-removebg-preview-500x116.png 500w, wp-content/uploads/2021/05/abs4-removebg-preview-300x70.png 300w, wp-content/uploads/2021/05/abs4-removebg-preview-540x125.png 540w"data-src="wp-content/uploads/2021/05/abs4-removebg-preview.png" data-sizes="(max-width: 621px) 100vw, 621px" class="aligncenter attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="621" height="144" src="wp-content/uploads/2021/05/abs4-removebg-preview.png" class="aligncenter attachment-full" alt="" srcset="wp-content/uploads/2021/05/abs4-removebg-preview.png 621w, wp-content/uploads/2021/05/abs4-removebg-preview-500x116.png 500w, wp-content/uploads/2021/05/abs4-removebg-preview-300x70.png 300w, wp-content/uploads/2021/05/abs4-removebg-preview-540x125.png 540w" sizes="(max-width: 621px) 100vw, 621px" /></noscript></h5>
                                                
                                                <span style="margin-right: auto; margin-left:auto;"><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript></noscript></noscript></span>

                                                <h6 style="margin-top: -25px;"><em><br />Welcomes you to be <b style="color:darkgreen;"> <br />Allah Almighty’s Blessed Friend by supporting Underprivileged Segment of the Society </b><br /> alongside discovering yourself, envisioning purpose of your life and developing a detailed roadmap of your prosperous life <br />thus  </em></h6>

                                                 <h2 style="margin-top: 30px;">Be Architect of Your Personal Prosperous Life</h2><span><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript></noscript></noscript></span>
                                                <h6><em> learn how to accrue optimal outcome of your efforts through vision / goal setting and pursuing their realization </em></h6>
                                                 <a style="background-color:darkred; color: white;" href='Personal-Prosperous-Life.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a> 



                                                <h2 style="margin-top: 50px;">Support Underprivileged Segment of Society </h2>
                                                <span><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript></noscript></noscript></span>
                                                <h6><em> Holy Prophet (ﷺ) has been narrated as saying that, a person looking after an orphan would be as closer to Him (ﷺ) in the Paradise as the index and middle fingers </em></h6>
                                            </div>
                                            <div id="1526284513550-47a7ffb5-5c0b" class="dt-sc-empty-space"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-notebook'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'> Desires</a></h4>
                                                    <p> Protection and all-encompassing prosperity (personal   & loved ones’) in worldly life  
                                                    <a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a> </p>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-notebook'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'> Fulfilment</a></h4>
                                                    <p>
                                                        Allah declares you friend 100 times in Quran if you exhibit sympathy, empathy & compassion,
                                                        <a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-user'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'>Challenges</a></h4>
                                                    <p>
                                                         Donors’ trust deficit in NGOs and fear of their donations’ wastage / abuse, Missing 
                                                        <a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-user'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'>Solution</a></h4>
                                                    <p>
                                                        No financial transactions to NGOs or beneficiaries; only donations of need-based items in kind
                                                        <a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-user'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'>System</a></h4>
                                                    <p>Establishing connectivity between all stakeholders; that, donors, volunteers and beneficiaries</p>
                                                    <p><a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-4">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div class='dt-sc-icon-box type7 aligncenter all-border'>
                                                <div class="icon-wrapper"><span class='icon icon-calculator'> </span></div>
                                                <div class="icon-content">
                                                    <h4><a href='about-us.aspx' title='LEARN MORE' target='_self'>Implementation</a></h4>
                                                    <p>Scrutiny and registration / retention of most deserving beneficiaries. Opportunity</p>
                                                    <p><a href='about-us.aspx' target='_self' title='' class='dt-sc-button   small   bordered  '> Know More </a></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="rs_col-sm-6 wpb_column vc_column_container vc_col-sm-12">
                                    <div class="vc_column-inner ">
                                        <div class="wpb_wrapper">
                                            <div id="1508836778583-46e51a3f-d2be" class="dt-sc-empty-space"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Row Backgrounds -->
                            <div class="upb_grad" data-grad="background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #E3F4FF), color-stop(100%, #F5F5F5));background: -moz-linear-gradient(left,#E3F4FF 0%,#F5F5F5 100%);background: -webkit-linear-gradient(left,#E3F4FF 0%,#F5F5F5 100%);background: -o-linear-gradient(left,#E3F4FF 0%,#F5F5F5 100%);background: -ms-linear-gradient(left,#E3F4FF 0%,#F5F5F5 100%);background: linear-gradient(left,#E3F4FF 0%,#F5F5F5 100%);"
                                 data-bg-override="ex-full" data-upb-overlay-color="" data-upb-bg-animation="" data-fadeout="" data-fadeout-percentage="30" data-parallax-content="" data-parallax-content-sense="30" data-row-effect-mobile-disable="true" data-img-parallax-mobile-disable="true"
                                 data-rtl="false" data-custom-vc-row="" data-vc="6.6.0" data-is_old_vc="" data-theme-support="" data-overlay="false" data-overlay-color="" data-overlay-pattern="" data-overlay-pattern-opacity="" data-overlay-pattern-size=""></div>
                           
                         
                    <!-- Primary End -->
                </div>
                <!-- ** Container End ** -->
            </section>

            <div data-vc-full-width="true" data-vc-full-width-init="false" class="vc_row wpb_row vc_row-fluid secondary-skin-bg wpb_animate_when_almost_visible wpb_fadeInUp fadeInUp">
                            <div class="wpb_column vc_column_container vc_col-sm-12">
                                <div class="vc_column-inner ">
                                    <div class="wpb_wrapper">
                                        <div  class="dt-sc-empty-space"></div>
                                        <div class="dt-sc-title with-image dt-sc-online-learning-title">
                                            <h2 style="margin-top: 50px;">Featured Donors</h2><span><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript></noscript></noscript></span>
                                            <h6> Donors aggressively involved in development of Orphans <em>(Brothers and Sisters)</em></h6>
                                        </div>
                                        <div id="1526370943391-f702f9ed-3bd1" class="dt-sc-empty-space"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="wpb_column vc_column_container vc_col-sm-4">
                                <div class="vc_column-inner ">
                                    <div class="wpb_wrapper">
                                        <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.7" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                            <div class='dt-sc-team  simple-rounded aligncenter'>
                                                <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image2" Width="150px" Height="150px"   class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H2" runat="server"></h4>
                                            <p></p>
                                    </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="wpb_column vc_column_container vc_col-sm-4">
                            <div class="vc_column-inner ">
                                <div class="wpb_wrapper">
                                    <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.7" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                        <div class='dt-sc-team  simple-rounded aligncenter'>
                                             <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image1" Width="150px" Height="150px"  class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H1" runat="server"></h4>
                                            <p></p>
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="wpb_column vc_column_container vc_col-sm-4">
                        <div class="vc_column-inner ">
                            <div class="wpb_wrapper">
                                <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.9" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                    <div class='dt-sc-team  simple-rounded aligncenter'>
                                        <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image3" Width="150px" Height="150px" class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H3" runat="server"></h4>
                                            <p></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
           
    
       
        
    
                            <div class="wpb_column vc_column_container vc_col-sm-12">
                                <div class="vc_column-inner ">
                                    <div class="wpb_wrapper">
                                        <div  class="dt-sc-empty-space"></div>
                                        <div class="dt-sc-title with-image dt-sc-online-learning-title">
                                            <h2 style="margin-top: 50px;">Featured Volunteers</h2>
                                            <span><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43"   alt="onliine-learning-title-img" data-src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full lazyload" src="data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==" /><noscript><img width="19" height="43" src="wp-content/uploads/2018/05/onliine-learning-title-img.png" class="attachment-full" alt="onliine-learning-title-img" /></noscript></noscript></noscript></span>
                                            <h6 style="margin-bottom: 40px;"> Volunteers aggressively involved in development of Orphans <em>(Brothers and Sisters)</em></h6>
                                        </div>
                                        <div  class="dt-sc-empty-space"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="wpb_column vc_column_container vc_col-sm-4">
                                <div class="vc_column-inner ">
                                    <div class="wpb_wrapper">
                                        <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.7" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                            <div class='dt-sc-team  simple-rounded aligncenter'>
                                                <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image4" Width="150px" Height="150px"   class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H4" runat="server"></h4>
                                            <p></p>
                                    </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="wpb_column vc_column_container vc_col-sm-4">
                            <div class="vc_column-inner ">
                                <div class="wpb_wrapper">
                                    <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.7" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                        <div class='dt-sc-team  simple-rounded aligncenter'>
                                             <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image5" Width="150px" Height="150px"  class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H5" runat="server"></h4>
                                            <p></p>
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="wpb_column vc_column_container vc_col-sm-4">
                        <div class="vc_column-inner ">
                            <div class="wpb_wrapper">
                                <div class="ult-animation  ult-animate-viewport  ult-no-mobile " data-animate="flipInY" data-animation-delay="0.9" data-animation-duration="0" data-animation-iteration="1" style="opacity:0;" data-opacity_start_effect="">
                                    <div class='dt-sc-team  simple-rounded aligncenter'>
                                        <div class='dt-sc-team-thumb'><asp:Image runat="server" ID="image6" Width="150px" Height="150px" class="attachment-full" alt="" sizes="(max-width: 1080px) 100vw, 1080px" /></div>
                                        <div
                                            class='dt-sc-team-details'>
                                            <h4 id="H6" runat="server"></h4>
                                            <p></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
             <div  class="wpb_column vc_column_container vc_col-sm-12">
                <div class="vc_column-inner ">
                    <div class="wpb_wrapper">
                        <div id="1526370789232-1a498785-788f" class="dt-sc-empty-space"></div>
                    </div>
                </div>
            </div>
        </div>

 <div  class="vc_row-full-width vc_clearfix"></div>

              <div   class="upb_bg_img" data-ultimate-bg="url(wp-content/uploads/2021/10/Background-White-e1468511345535.jpg)" data-image-id="id^12245|url^wp-content/uploads/2021/10/Background-White-e1468511345535.jpg|caption^Business people walking in the office corridor|alt^null|title^People in office|description^null"
            data-ultimate-bg-style="vcpb-vz-jquery" data-bg-img-repeat="repeat" data-bg-img-size="cover" data-bg-img-position="" data-parallx_sense="30" data-bg-override="0" data-bg_img_attach="scroll" data-upb-overlay-color="" data-upb-bg-animation="" data-fadeout=""
            data-bg-animation="left-animation" data-bg-animation-type="h" data-animation-repeat="repeat" data-fadeout-percentage="30" data-parallax-content="" data-parallax-content-sense="30" data-row-effect-mobile-disable="true" data-img-parallax-mobile-disable="true"
            data-rtl="false" data-custom-vc-row="" data-vc="6.6.0" data-is_old_vc="" data-theme-support="" data-overlay="false" data-overlay-color="" data-overlay-pattern="" data-overlay-pattern-opacity="" data-overlay-pattern-size=""></div>
       
                    
                </div>
    

        

    </div>
    </div>
</div>

</asp:Content>
