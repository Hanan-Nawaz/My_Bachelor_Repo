<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ABS_Project.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Dashboard &#8211; A Blessed Society</title>

      <link rel="stylesheet" href="CSS/showbenificary.css" type="text/css" />
      
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 30px; user-select: none;"><i class="fas fa-tachometer-alt fa-fw " ></i>  DASHBOARD</label>
                   
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>


                      <div class="row mt-5">
                           
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" Height="70px" ID="btn_ben" Font-Size="20px" runat="server" Text="Save" OnClick="btn_ben_Click" />
                                </div>
                        </div>

                              
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" Height="70px" ID="btn_vol" Font-Size="20px" runat="server" Text="Save" OnClick="btn_both_Click" />
                                </div>
                        </div>

                                 
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block btn-lg" Height="70px" ID="btn_both" Font-Size="20px" runat="server" Text="Save" OnClick="btn_both_Click" />
                                </div>
                        </div>


                                 
                        

                    </div>

                   <div class="row mt-1">
                        <div class="col-md-4">
                            <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block btn-lg" Height="70px" ID="btn_donor" Font-Size="20px" runat="server" Text="Save" OnClick="btn_both_Click" />
                                </div>
                            </center>
                        </div>

                      
                   </div>
                   


            </div>
        </div>
    </div>
</div>

</asp:Content>
