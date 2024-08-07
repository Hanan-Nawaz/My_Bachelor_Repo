﻿<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="viewprogress.aspx.cs" Inherits="ABS_Project.viewprogress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <title>View Progress &#8211; A Blessed Society</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;">View Progress</label>
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
                    <Label>Search</Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="searchBox" runat="server" placeholder="Search by Keyword " required></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-3 ml-1 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="searchButton" runat="server" Text="search" OnClick="searchButton_Click"/>
                           </div>
                        </center>
                     </div>

              </div>
                  
                    <div class="row">


                       <div class="col-md-12 mt-5 mx-auto">
                        
                    <asp:DataGrid ID="girdview1" runat="server" PageSize="10" OnItemDataBound="getImagePath" OnSortCommand="girdview1_SortCommand" OnPageIndexChanged="girdview1_PageIndexChanged" AutoGenerateColumns="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" AllowPaging="true" AllowSorting="true" PagerStyle-CssClass="mydatagrid_footer">

                        <Columns>
                            <asp:BoundColumn  HeaderText="Full Name" DataField="name" SortExpression="name" ItemStyle-Width="100"></asp:BoundColumn>
                            <asp:BoundColumn DataField="gaurdianemail" HeaderText="Email" SortExpression="gaurdianemail" ItemStyle-Width="100" ></asp:BoundColumn>
                            <asp:BoundColumn DataField="gaurdiancontact" HeaderText=" Contact" SortExpression="gaurdiancontact" ItemStyle-Width="100" ></asp:BoundColumn>
                            <asp:BoundColumn DataField="province" HeaderText=" Province" SortExpression="province" ItemStyle-Width="100"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="district" HeaderText=" District" SortExpression="district" ItemStyle-Width="100" />
                            <asp:BoundColumn  DataField="school" HeaderText=" School" SortExpression="school" ItemStyle-Width="100"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="needs" HeaderText=" Needs" SortExpression="needs" ItemStyle-Width="100"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="status_donor" HeaderText=" Status" SortExpression="status_donor" ItemStyle-Width="100"></asp:BoundColumn>

                             
                           
                             <asp:TemplateColumn>

                                  <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="view_btn" CssClass="btn btn-primary btn-block btn-lg" OnClick="view_btn_Click" ForeColor="white" Text="View" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="btn" CssClass="btn btn-primary btn-block btn-lg" ForeColor="red" Text="Cancel" OnClick="del_btn_Click" CommandArgument='<%# Eval("Id") + ";" + Eval("status_donor") %>'></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateColumn>


                            </Columns>


                    </asp:DataGrid>

                           </div>
                   </div>

                    
                  
        </div>
    </div>
</div>
        
        
    </div>

</asp:Content>
