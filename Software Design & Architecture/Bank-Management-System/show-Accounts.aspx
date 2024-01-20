<%@ Page Title="" Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="show-Accounts.aspx.cs" Inherits="SDA_Project.show_Accounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Show Accounts - Bank of NUML</title>
       <link rel="stylesheet" href="CSS/girdview.css" type="text/css" />
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-list fa-fw " ></i> Show Accounts </label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>



                    <div class="row ">

                        <div class="col-md-6">
                            <label>Search</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="searchBox" runat="server" placeholder="Search"></asp:TextBox>
                            </div>
                                                    </div>

                            <div class="col-md-6">
                                <label></label>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                                    </div>
                            </div>






                       
                    </div>

                    <div class="row">
                        <center>

                            <div class="col-md-12 mx-auto">
                                <div class="form-group">
                                   <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" ShowFooter="true" FooterStyle-CssClass="mydatagrid_footer" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowSorting="true" OnSorting="girdview_Sorting" AllowPaging="True" PageSize="10" OnPageIndexChanging="girdview_PageIndexChanging" >


                        <Columns>
                            <asp:BoundField HeaderText="Account Number" DataField="AccountNumber" SortExpression="AccountNumber"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Cnic" HeaderText="Cnic" SortExpression="Cnic" ItemStyle-Width="60"/>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />

                            <asp:TemplateField ItemStyle-Width="140">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="view_btn" CssClass="btn btn-primary btn-sm ml-4"  OnClick="view_btn_Click" ForeColor="white" CommandArgument='<%# Eval("AccountNumber") %>'>View</asp:LinkButton>
                                </ItemTemplate>


                                <FooterTemplate>
                                </FooterTemplate>

                            </asp:TemplateField>
                        </Columns>


                    </asp:GridView>
                                </div>
                            </div>
                        </center>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
