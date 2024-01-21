<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ITCON_Paid_Project.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                       <title>Dashboard - NUML Minute Sheet Management System</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 30px; user-select: none;"><i class="fas fa-tachometer-alt fa-fw " ></i>  Dashboard</label>
                   
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
                                    <asp:Button class="btn btn-primary btn-block btn-lg" Height="70px" ID="btn_isl" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                              
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" Height="70px" ID="btn_rwp" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                                 
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block btn-lg" Height="70px" ID="btn_lahore" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>


                                 
                        

                    </div>

                     <div class="row mt-2">
                           
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block btn-lg" Height="70px" ID="btn_gaw" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                              
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-info btn-block btn-lg" Height="70px" ID="btn_khi" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                                 
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-secondary btn-block btn-lg" Height="70px" ID="btn_mlt" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>


                                 
                        

                    </div>

                   <div class="row mt-2">
                           
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" Height="70px" ID="btn_hydr" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                              
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" Height="70px" ID="btn_queta" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                                 
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block btn-lg" Height="70px" ID="btn_pesh" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>


                                 
                        

                    </div>

                   <div class="row mt-2">
                           
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block btn-lg" Height="70px" ID="btn_fsd" Font-Size="20px" runat="server" Text="Save" OnClick="btn_fsd_Click" />
                                </div>
                        </div>

                              
                       

                                 
                        

                    </div>

            </div>
        </div>
    </div>
</div>

    </asp:content>
