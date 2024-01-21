<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="allUsers.aspx.cs" Inherits="MedLearner.allUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Users</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" >Users</p>
            </div>
        </div>
    </div>

     <div class="container-fluid">

         <div class="col-md-13">
            <div class="card">
                <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="grdUser" runat="server" Width="100%" OnRowCommand="grdUser_RowCommand" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" DataKeyNames="Email" EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
            <ItemTemplate>
                <asp:label ID="txtName" runat="server" Text='<%# Eval("Email") %>' />
            </ItemTemplate>
        </asp:TemplateField>
                                            <asp:BoundField DataField="Firstname" HeaderText="Name"  HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number"  HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="Country" HeaderText="Country"  ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:TemplateField HeaderText="View User">
                                                <ItemTemplate >
                                                        <asp:Button Text="View" runat="server" CssClass="btn btn-primary" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  
                                    </asp:GridView>  
                                </div>  
                                </div>
                            </div> 
            </div>
        </div>
        </div>

</asp:Content>
