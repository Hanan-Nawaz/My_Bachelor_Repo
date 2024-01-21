<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="viewcategory.aspx.cs" Inherits="ITCON_Paid_Project.viewcategory1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link rel="stylesheet" href="CSS/girdview.css" type="text/css" />
                       <title>View Account Head - NUML Minute Sheet Management System</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;"><i class="fas fa-eye fa-fw " ></i> View Account Head</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                
                    

                <div class="row ">
                     
                     <div class="col-md-4 mx-auto">
                            <label>Campus</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_campus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_campus_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Campus</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        


                    </div>

                                   <div class="row">
                     <div class="col-md-12 mx-auto">
                         <center>
                                                     <div class="form-group">
                                                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                    <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" ShowFooter="true" FooterStyle-CssClass="mydatagrid_footer" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnRowDataBound="girdview_RowDataBound">


                        <Columns>
                            <asp:BoundField DataField="category_list" HeaderText="Category" />
                            <asp:BoundField DataField="amount" HeaderText="Total Amount" />

                        </Columns>


                    </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                                                         </div>
                             </center>
                         </div>
                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
