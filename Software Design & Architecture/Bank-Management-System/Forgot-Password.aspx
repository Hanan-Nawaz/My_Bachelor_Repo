<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot-Password.aspx.cs" Inherits="SDA_Project.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Forgot Password - Bank of NUML  </title>



    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="#"/>
    <meta name="keywords" content="Admin , Responsive, Landing, Bootstrap, App, Template, Mobile, iOS, Android, apple, creative app"/>
    <meta name="author" content="#"/>
    <link rel="shortcut icon" href="favicon.ico" />
    <link rel="stylesheet" type="text/css" href="cs/style.css" />
    <link href="cs/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="cs/notifIt.css" rel="stylesheet" type="text/css" />
    <link href="cs/demo.css" rel="stylesheet" type="text/css" />
    <link rel="icon" href="files/assets/images/favicon.ico" type="image/x-icon"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,600,800" rel="stylesheet"/>
 
<!-- Font Awesome -->
<link
  href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"
  rel="stylesheet"
/>
<!-- Google Fonts -->
<link
  href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
  rel="stylesheet"
/>
<!-- MDB -->
<link
  href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/4.0.0/mdb.min.css"
  rel="stylesheet"
/>

<!-- MDB -->
<script
  type="text/javascript"
  src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/4.0.0/mdb.min.js"
></script>

    <style>
        body, html {
            height: 100%;
        }
        .login-2 {
            padding: 30px 0;
            margin: 0 auto;
            background: linear-gradient(to top right, #87ceeb 0%, #191970 100%);
            background-size: cover;
            min-height: 100vh;
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -webkit-box-align: center;
            -ms-flex-align: center;
            align-items: center
        }
        .forgot{
            color: #1f1e1e;
        }
        .forgot:hover{
    color: #52cfeb;
        }
    </style>
</head>
<body>

    <section class="login-2">
        <!-- Pre-loader start -->
        <div class="theme-loader">
            <div class="ball-scale">
                <div class='contain'>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                    <div class="ring">
                        <div class="frame"></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Pre-loader end -->
        <div class="container">

            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                      <form  runat="server">

                            
                  <section class="login-block">
                                <!-- Container-fluid starts -->
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-5 mx-auto">

                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="text-center">
                                                        <div class="col-md-12 mt-3">
                                                            <a href="http://www.numl.edu.pk">
                                                                <img class="img-50" width="180" height="180" src="photo/logo.png" alt="logo.png"></a>
                                                        </div>
                                                        <br />
                                                        <h5><strong>Bank of NUML</strong></h5>
                                                        <h5><strong>Forgot Password </strong></h5>

                                                        <br />
                                                    </div>
                                                    <div class="col-lg-14 mx-auto">
                                                    <div class="form-group form-primary mb-4 ">
                                                        <asp:TextBox  type="email"  runat="server"  ID="tb_email" CssClass="form-control" required="" placeholder="Please Enter Your Email" ></asp:TextBox>
                                                        <span class="form-bar"></span>
                                                    </div>
                                                  
                                                   
                                                </div>
                                                    <div class="row m-t-10">
                                                        <div class="col-md-10 mx-auto mb-4">
                                                            <asp:LinkButton  runat="server" ID="btnforgot" OnClick="btnforgot_Click" CssClass="btn btn-info btn-md btn-block waves-effect waves-light text-center m-b-20" >Submit</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                   
                                                    <div class="row">
                                                    <div class="col-md-12 text-center">
                                                       <centre>

                                                        <asp:label runat="server" id="message"></asp:label>
                                                       </centre>

                                                    </div>
                                                   </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <script type="text/javascript">
        $(function () {
            $(".showpassword").each(function (index, input) {
                var $input = $(input);
                $("<p class='opt'/>").append(
                    $("<input type='checkbox' class='showpasswordcheckbox' id='showPassword' />").click(function () {
                        var change = $(this).is(":checked") ? "text" : "password";
                        var rep = $("<input placeholder='Password' type='" + change + "' />")
                            .attr("id", $input.attr("id"))
                            .attr("name", $input.attr("name"))
                            .attr('class', $input.attr('class'))
                            .val($input.val())
                            .insertBefore($input);
                        $input.remove();
                        $input = rep;
                    })
                ).append($("<label for='showPassword'/>").text("Show password")).insertAfter($input.parent());
            });
            $('#showPassword').click(function () {
                if ($("#showPassword").is(":checked")) {
                    $('.icon-lock').addClass('icon-unlock');
                    $('.icon-unlock').removeClass('icon-lock');
                } else {
                    $('.icon-unlock').addClass('icon-lock');
                    $('.icon-lock').removeClass('icon-unlock');
                }
            });
        });
        $(document).ready(function () {
            toastr.options = {
                //'closeButton': true,
                //'debug': false,
                //'newestOnTop': false,
                //'progressBar': false,
                //'positionClass': 'toast-top-center',
                //'preventDuplicates': false,
                //'showDuration': '1000',
                //'hideDuration': '1000',
                //'timeOut': '5000',
                //'extendedTimeOut': '1000',
                //'showEasing': 'swing',
                //'hideEasing': 'linear',
                //'showMethod': 'fadeIn',
                //'hideMethod': 'fadeOut',
            }
        });
    </script>

    
</body>
</html>
