<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="About-Developer.aspx.cs" Inherits="SDA_Project.About_Developer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <title>About Developer - Bank of NUML</title>
    
        <link href="ionicons/css/ionicons.min.css" rel="stylesheet">

    <style>
        .team {
    padding: 60px 0;
}

.team .section-header {
    margin-bottom: 15px;
}

.team .card {
    position: relative;
    border: none;
    border-radius: 0;
    overflow: hidden;
    transition: 0.3s;
}

.team .card:hover {
    box-shadow: 0px 0px 10px #999999;
}

.team .card img {
    width: 100%;
}

.team .card-title-wrap {
    padding: 15px 25px;
    position: relative;
    background-color: #f2f2f2;
}

.team .card:hover .card-title-wrap {
    background: #1dbf73;
}

.team .card-title-wrap .card-title,
.team .card-title-wrap .card-text {
    display: block;
    margin: 0;
}

.team .card-title-wrap .card-title {
    text-align: center;
    font-size: 18px;
    color: #353535;
}

.team .card-title-wrap .card-text {
    text-align: center;
    font-size: 14px;
    color: #666666;
}

.team .card:hover .card-title-wrap .card-title,
.team .card:hover .card-title-wrap .card-text {
    color: #ffffff;
}

.team .card .social-nav {
    position: relative;
    text-align: center;
}

.team .card .social-nav a {
    display: inline-block;
    color: #353535;
    font-size: 24px;
    margin: 5px;
}

.team .card:hover .social-nav a {
    color: #ffffff;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-info fa-fw "></i>About Developer</label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>


                     <section class="team">
            <div class="container">
                <header class="section-header">
                    <center>
                                                                    <h3 class="section-title">Meet our team</h3>
                        <p>
                    </p>
                    </center>
                    
                </header>

                <div class="row">
                    <div class="col-md-3 col-sm-6 mx-auto">
                        <div class="card card-block">
                            <a href="#"><img alt="" class="team-img" src="photo/hanan.jpg" /></a>
                                <div class="card-title-wrap">
                                    <span class="card-title">Abdul Hanan</span> <span class="card-text">Full Stack Developer</span>
                                    <div class="social-nav">
                                        <a href="https://hanannawaz.com/"><i class="fa fa-globe"></i></a>
                                        <a href="https://www.facebook.com/hannan.goraya.9"><i class="ion-logo-facebook"></i></a>
                                        <a href="https://www.linkedin.com/in/abdulhanan0"><i class="ion-logo-linkedin"></i></a>
                                        <a href="https://www.instagram.com/hanan__nawaz/"><i class="ion-logo-instagram"></i></a>
                                        <a href="https://github.com/Hanan-Nawaz"><i class="ion-logo-github"></i></a>

                                    </div>
                                </div>
                            
                        </div>
                    </div>

                     <div class="col-md-3 col-sm-6 mx-auto">
                        <div class="card card-block">
                            <a href="#"><img alt="" class="team-img" src="photo/waqas.jpg" /></a>
                                <div class="card-title-wrap">
                                    <span class="card-title">Waqas Khan</span> <span class="card-text">Architecture Expert</span>
                                    <div class="social-nav">
                                        <a href="https://github.com/Waqas-Faiz"><i class="ion-logo-github"></i></a>

                                    </div>
                                </div>
                            
                        </div>
                    </div>
                   
                </div>
            </div>
        </section>

                     <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;">To Get a Quote, Mail us at admin@hanannawaz.com or Visit us at www.hanannawaz.com</label>
                            </center>
                        </div>
                    </div>

                  </div>
                </div>
            </div>
        </div>
    
</asp:Content>
