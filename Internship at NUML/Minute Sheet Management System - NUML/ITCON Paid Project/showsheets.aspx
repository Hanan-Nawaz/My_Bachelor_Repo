<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="showsheets.aspx.cs" Inherits="ITCON_Paid_Project.showsheets1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>Show Sheets - NUML Minute Sheet Management System</title>
            <link rel="stylesheet" href="CSS/girdview.css" type="text/css" />
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


     <script>

         var obj = { status: false, ele: null };

         function fnConfirmDelete(stat) {


                 if (obj.status) {
                     return true;
                 }

                 swal({
                     title: "Delete",
                     text: "Are you sure you want to Delete? \nPlease Delete Sub Minute Sheets First :)",
                     type: "warning",
                     showCancelButton: true,
                     closeOnConfirm: false,
                     closeOnCancel: false,
                     confirmButtonClass: "btn-danger",
                 },
                     function (isConfirm) {
                         if (isConfirm) {
                             obj.status = true;
                             obj.ele = stat;
                             obj.ele.onclick();
                             swal("Congratulation", "Deleted Successfully:)", "success");
                         }
                         else {



                             swal("Cancelled", "Minute Sheet not Deleted:)", "error");


                         }
                     });

             }

             
         
             return false;

             
         };
     </script>
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
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-info fa-fw " ></i> Show Sheets </label>
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
                            <asp:BoundField HeaderText="Letter Number" DataField="letter_no" SortExpression="letter_no"></asp:BoundField>
                            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                            <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" ItemStyle-Width="100"/>
                            <asp:BoundField DataField="campusname" HeaderText="Campus" SortExpression="campusname" />
                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                            <asp:BoundField DataField="approver" HeaderText="Approved By" SortExpression="approver" />
                            <asp:BoundField DataField="app_date" HeaderText="Approval Date" SortExpression="app_date" />
                            <asp:ImageField DataImageUrlField="image" HeaderText="Image" ControlStyle-Width="70px" ControlStyle-Height="70px" SortExpression="image" />

                            <asp:TemplateField ItemStyle-Width="140">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="view_btn" CssClass="btn btn-primary btn-sm" OnClick="view_btn_Click" ForeColor="white" CommandArgument='<%# Eval("letter_no") %>'>View</asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="del_btn" CssClass="btn btn-danger btn-sm" OnClientClick="return fnConfirmDelete(this);" OnClick="del_btn_Click" ForeColor="white" CommandArgument='<%# Eval("letter_no") %>'>Delete</asp:LinkButton>
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
