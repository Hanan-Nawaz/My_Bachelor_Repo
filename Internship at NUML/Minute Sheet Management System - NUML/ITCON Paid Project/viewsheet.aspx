<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="viewsheet.aspx.cs" Inherits="ITCON_Paid_Project.viewsheet1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>View Minutesheet - NUML Minute Sheet Management System</title>

    <style>
        .row {
            margin-top: 5px;
        }
    </style>

    <script>

         var obj = { status: false, ele: null };

         function confirmdel(stat) {

             if (obj.status) {
                 return true;
             }

             swal({
                 title: "Delete",
                 text: "Are you sure you want to Delete?",
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
                         obj.ele.click();
                         swal("Congratulation", "Deleted Successfully:)", "success");
                     }
                     else {



                         swal("Cancelled", "Minute Sheet not Deleted :)", "error");


                     }
                 });



             return false;
         };
    </script>
   
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
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-eye fa-fw " ></i> View MinuteSheet</label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Letter Number</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="letter_no" runat="server" placeholder="Letter Number" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Date</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="date" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Campus</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_campus" runat="server" AutoPostBack="true"   Readonly="true">
                                            <asp:ListItem Value="0">Select Faculty</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <label>Title</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="title" runat="server" placeholder="Full Title" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                            </div>
                        </div>
                    </div>


                       
                       


                    <div class="row">
                        <div class="col-md-12 mx-auto">
                            <center>

                                <div class="form-group">
                                    <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" ShowFooter="true" FooterStyle-CssClass="mydatagrid_footer" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowSorting="true" OnSorting="girdview_Sorting" AllowPaging="True" PageSize="10" OnPageIndexChanging="girdview_PageIndexChanging" OnRowDataBound="girdview_RowDataBound">


                                        <Columns>
                                            <asp:BoundField HeaderText="Letter Number" DataField="letter_no" SortExpression="letter_no"></asp:BoundField>
                                            <asp:BoundField DataField="faculty" HeaderText="Faculty" SortExpression="faculty" />
                                            <asp:BoundField DataField="dept" HeaderText="Department" SortExpression="dept" />
                                            <asp:BoundField DataField="category_list" HeaderText="Category" SortExpression="category_list" />
                                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />

                                            <asp:TemplateField ShowHeader="false">
                                                <ItemTemplate>
                                                    
                                                    <asp:LinkButton runat="server" ID="del_btn" CssClass="btn btn-danger btn-sm" OnClientClick="return confirmdel(this);"  ForeColor="White" OnClick="del_btn_Click" CommandArgument='<%# Eval("letter_no") + ";" + Eval("Id") + ";" + Eval("category") + ";" + Eval("amount") %>'>Delete</asp:LinkButton>
                                                </ItemTemplate>



                                            </asp:TemplateField>
                                        </Columns>


                                    </asp:GridView>

                                </div>
                            </center>

                        </div>
                    </div>




                    <div class="row">

                        <div class="col-md-4">
                            <label>Total Amount</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_amount" runat="server" placeholder="Total Amount"></asp:TextBox>
                                <asp:Label ID="total" Visible="false" Width="0px" Height="0px" runat="server"></asp:Label>

                            </div>
                        </div>

                        <div class="col-md-4">
                            <label>Approved by</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="approver_dl" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select Approver</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label>Apporval Date</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="tb_appdate" runat="server" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>

                    </div>





                    <div class="row">

                        <div class="col-md-12 mx-auto">
                            <center>

                                <label>Upload Picture</label>
                                <div class="form-group">
                                    <asp:Image ID="image_img"  CssClass="rounded mx-auto img-fluid" runat="server" /><br />
                                </div>

                            </center>
                        </div>



                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>