<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="contactrequests.aspx.cs" Inherits="ABS_Project.contactrequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Contact Request &#8211; A Blessed Society</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;">View Contact Requests</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                    
                   
                   <div class="row">

                        <div class="col-md-6 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_unreply" runat="server" Text="Un-Replied Messages" OnClick="btn_unreply_Click"/>
                           </div>
                        </center>
                     </div>

                       <div class="col-md-6 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_reply" runat="server" Text="Replied Messages" OnClick="btn_reply_Click"/>
                           </div>
                        </center>
                     </div>
                    </div>

                   
                   <div class="row">


                       <div class="col-md-16 ml-5 mt-2">
                        
                    <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" ShowFooter="true" FooterStyle-CssClass="mydatagrid_footer" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowSorting="true" OnSorting="girdview_Sorting" AllowPaging="True" PageSize="10" OnPageIndexChanging="girdview_PageIndexChanging" OnRowDataBound="girdview_RowDataBound">


                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="name" SortExpression="name"></asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                            <asp:BoundField DataField="message" HeaderText=" Message" SortExpression="message" />
                           
                      <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="view_btn" CssClass="btn btn-primary btn-block btn-lg" OnClick="view_btn_Click" ForeColor="blue" CommandArgument='<%# Eval("email") %>'>Reply</asp:LinkButton>

                                </ItemTemplate>


                                <FooterTemplate>
                                </FooterTemplate>

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
