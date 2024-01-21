<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="addminutesheets.aspx.cs" Inherits="ITCON_Paid_Project.addminutesheets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Add Minutesheet - NUML Minute Sheet Management System</title>

    <style>
        .row {
            margin-top: 5px;
        }
    </style>


    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=sheetpic.ClientID%>').prop('src', e.target.result)
                        .width(140)
                        .height(140);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

       
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
                                <label style="color: blue; font-size: 20px; user-select: none;"><i class="fas fa-plus fa-fw "></i>Add MinuteSheet</label>
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
                            <label>Letter Number *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="letter_no" runat="server" placeholder="Letter Number" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Date *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="date" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Available Amount *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox CssClass="form-control" ID="e_amount" runat="server" ReadOnly="true"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <label>Title *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="title" runat="server" placeholder="Full Title" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <label>Faculty *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_faculty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_faculty_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Faculty</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                        <div class="col-md-4">
                            <label>Department *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="dept" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select Department</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label>Category *</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="categ_list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="categ_list_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Category</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <label>Amount *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="individual_amount_tb" runat="server" placeholder="Amount" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label class=""></label>
                            <div class="form-group">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="add_btn" runat="server" Text="Add" OnClick="add_btn_Click" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label class="text-danger">Important</label>
                            <div class="form-group">
                                <label>If Don't find your desired Category. Contact Admin</label>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col">
                            <center>
                                <asp:Label ID="sub_mess" runat="server" Style="color: red;"></asp:Label>
                            </center>
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
                                                    
                                                    <asp:LinkButton runat="server" ID="del_btn" CssClass="btn btn-danger btn-sm" ForeColor="White" OnClick="del_btn_Click" CommandArgument='<%# Eval("letter_no") + ";" + Eval("Id") + ";" + Eval("category") + ";" + Eval("amount") %>'>Delete</asp:LinkButton>
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
                            <label>Total Amount *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="amount" TextMode="Number" runat="server" placeholder="Total Amount"></asp:TextBox>
                                <asp:Label ID="total" Visible="false" Width="0px" Height="0px" runat="server"></asp:Label>

                            </div>
                        </div>

                        <div class="col-md-4">
                            <label>Approved by *</label>
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
                            <label>Apporval Date *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="app_date" runat="server" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>

                    </div>





                    <div class="row">

                        <div class="col mx-auto">
                            <center>

                                <label>Upload Picture *</label>
                                <div class="form-group">
                                    <asp:Image ID="sheetpic" Height="140px" Width="140px" CssClass="rounded mx-auto img-fluid" runat="server" /><br />
                                    <asp:FileUpload ID="image_upload" CssClass="form-control" Width="70px" runat="server" onchange="ShowImagePreview(this);" />
                                </div>

                            </center>
                        </div>



                    </div>

                    <div class="row mt-5">
                        <div class="col-md-8 mx-auto">
                            <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="submit" runat="server" Text="Save" OnClick="submit_Click" />
                                </div>
                            </center>
                        </div>
                    </div>

                   

                </div>
            </div>
        </div>
    </div>





</asp:Content>
