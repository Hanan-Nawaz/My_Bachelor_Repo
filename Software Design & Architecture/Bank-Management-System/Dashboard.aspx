<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SDA_Project.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <title>Dashboard - Bank of NUML</title>

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
                           
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" Height="70px" ID="btn_active" Font-Size="20px" runat="server" Text="Save" OnClick="btn_view_Click" />
                                </div>
                        </div>

                              
                        <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" Height="70px" ID="btn_inactive" Font-Size="20px" runat="server" Text="Save" OnClick="btn_view_Click" />
                                </div>
                        </div>

                                 
                       
                          </div>

                                 
                        

                   

            </div>
        </div>
    </div>
</div>

    </asp:content>
