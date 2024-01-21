<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ABS_Project.AddContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Content &#8211; A Blessed Society</title>

     <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.js" integrity="sha512-MqEDqB7me8klOYxXXQlB4LaNf9V9S0+sG1i8LtPOYmHqICuEZ9ZLbyV3qIfADg2UJcLyCm4fawNiFvnYbcBJ1w==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha512-f8gN/IhfI+0E9Fc/LKtjVq4ywfhYAVeMGKsECzDUHcFJ5teVwvKTqizm+5a84FINhfrgdvjX8hEJbem2io1iTA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha512-XVz1P4Cymt04puwm5OITPm5gylyyj5vkahvf64T8xlt/ybeTpz4oHqJVIeDtDoF5kSrXMOUmdYewE4JS/4RWAA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.css" integrity="sha512-hwwdtOTYkQwW2sedIsbuP1h0mWeJe/hFOfsvNKpRB3CkRxq8EW7QMheec1Sgd8prYxGm1OM9OZcGW7/GUud5Fw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://unpkg.com/alpinejs@3.10.3/dist/cdn.min.js"></script>

    <script
        type="text/javascript"
        src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.11.0/mdb.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ContentImage.ClientID%>').prop('src', e.target.result)
                        .width(70)
                        .height(70);
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
                                <label style="color: blue; font-size: 20px; user-select: none;">Add Content</label>
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
                            <label>Title *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tbTitle" runat="server" placeholder="Title" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-2">
                        <label>Content <bold class="text-warning"></bold> *</label>
                        <div class="col-md">
                            <div class="form-outline">
                                <asp:TextBox ID="taContent" class="form-control border border-1 border-primary" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mx-auto">
                            <center>
                                <label>Picture *</label>
                                <div class="form-group">
                                    <asp:Image ID="ContentImage" Height="100px" Width="100px" runat="server" /><br />
                                    <asp:FileUpload ID="ImgContent" CssClass="form-control" Width="100px" runat="server" onchange="ShowImagePreview(this);" />
                                </div>
                            </center>
                        </div>

                        <div class="col-md-6 mx-auto">
                            <center>
                                <label>PDF (optional)</label>
                                <div class="form-group">
                                    <asp:FileUpload ID="pdfUpload" runat="server" ToolTip="Select Only PDF File" />
                                </div>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="row mt-5">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
