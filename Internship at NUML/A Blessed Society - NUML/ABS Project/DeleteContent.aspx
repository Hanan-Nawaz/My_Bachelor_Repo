<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="DeleteContent.aspx.cs" Inherits="ABS_Project.DeleteContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delete Content &#8211; A Blessed Society</title>
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
                        <label style="color:blue; font-size: 20px; user-select: none;">Delete Content</label>
                        </center>
                     </div>
                   </div>

                    <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>



                   <div class="row">


                       <div class="col-md-12 mt-5 mx-auto">
                        
                    <asp:DataGrid ID="girdview1" runat="server" PageSize="10"  OnPageIndexChanged="girdview1_PageIndexChanged" AutoGenerateColumns="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" AllowPaging="true" PagerStyle-CssClass="mydatagrid_footer">

                        <Columns>
                            <asp:BoundColumn  DataField="Title" HeaderText="Title" ItemStyle-Width="90%" ItemStyle-CssClass="center"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Id" HeaderText="Id" Visible="false"></asp:BoundColumn>
                             

                             <asp:TemplateColumn>

                                  <ItemTemplate>

                                    <asp:LinkButton runat="server" ID="btn" CssClass="btn btn-danger btn-block btn-lg" ForeColor="white" Text="Delete" OnClick="btn_Click" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
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
