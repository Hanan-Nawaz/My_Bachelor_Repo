<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="seehistory.aspx.cs" Inherits="ITCON_Paid_Project.seehistory1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>See Hitory - NUML Minute Sheet Management System</title>
            <link rel="stylesheet" href="CSS/girdview.css" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container-fluid">

        <div class="col-md-13">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-info fa-fw " ></i> See History</label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>



                    <div class="row ">

                        <div class="col-md-4">
                            <label>Search</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="searchBox" runat="server" placeholder="Search"></asp:TextBox>
                            </div>
                                                    </div>

                            <div class="col-md-2">
                                <label></label>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                                    </div>
                            </div>






                        <div class="col-md-2">
                            <label>From Date</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" TextMode="Date" ID="tb_fdate" runat="server" placeholder="Date"></asp:TextBox>
                            </div>

                           
                        </div>
                         <div class="col-md-2">
                                <label>To Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Date" ID="tb_todate" runat="server" placeholder="Date"></asp:TextBox>
                                </div>
                            </div>
                        <div class="col-md-2">
                            <label></label>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" />
                                </div>
                        </div>
                    </div>

                    <div class="row">
                        <center>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" ShowFooter="true" FooterStyle-CssClass="mydatagrid_footer" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowSorting="true" OnSorting="girdview_Sorting" AllowPaging="True" PageSize="10" OnPageIndexChanging="girdview_PageIndexChanging" OnRowDataBound="girdview_RowDataBound">


                                        <Columns>
                                            <asp:BoundField HeaderText="Adding Amount" DataField="adding_amount" SortExpression="adding_amount"></asp:BoundField>
                                            <asp:BoundField DataField="category_list" HeaderText="Category" SortExpression="category_list" />
                                            <asp:BoundField DataField="campusname" HeaderText="Campus" SortExpression="campusname" />
                                            <asp:BoundField DataField="exist_amount" HeaderText="Existing Amount" SortExpression="exist_amount" />
                                            <asp:BoundField DataField="new_total" HeaderText="New Total" SortExpression="new_total" />
                                            <asp:BoundField DataField="name" HeaderText="Approved By" SortExpression="name" />
                                            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />


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
