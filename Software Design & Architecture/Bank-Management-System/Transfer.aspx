<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="SDA_Project.Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transfer - Bank of NUML</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-minus fa-fw "></i>Transfer Amount</label>
                               <br />
                                <label style="color: red; font-size: 10px; user-select: none;">Working only for "Bank of NUML" Accounts </label>

                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Current Amount</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_Currentamount" runat="server" ReadOnly="true" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Amount</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_amount" runat="server" placeholder="" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                      <div class="row">
                        <div class="col-md-6">
                            <label>Benificary Account Number</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_number" runat="server" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Benificary Account Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" placeholder="" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mx-auto">
                            <label></label>
                            <centre>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg mx-auto" ID="Transferbtn" runat="server" Text="Transfer" OnClick="Transfer_Click" />
                                </div>
                            </centre>
                        </div>
                    </div>

                    <div class="row">
                        <div class="text-center">

                            <asp:Label runat="server" ID="message"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
