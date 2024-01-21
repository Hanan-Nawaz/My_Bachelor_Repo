<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="addprogress.aspx.cs" Inherits="ABS_Project.addprogress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Approve Video &#8211; A Blessed Society</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;">Approve Videos</label>
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
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_unreply" runat="server" Text="Disapproved Videos" OnClick="btn_unreply_Click"/>
                           </div>
                        </center>
                     </div>

                       <div class="col-md-6 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_reply" runat="server" Text="Approved Videos" OnClick="btn_reply_Click"/>
                           </div>
                        </center>
                     </div>
                    </div>

                   <div class="row mt-2 mx-auto">
                       <div class="col mx-auto">
                    <asp:GridView ID="gird" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="header"   CssClass="mydatagrid"  ShowHeader="true" RowStyle-CssClass="rows">

                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Volunteer Name" />
                            <asp:BoundField DataField="gaurdianemail" HeaderText="Email" />
                            <asp:BoundField DataField="gaurdiancontact" HeaderText="Phone Number" />
                            <asp:BoundField DataField="district" HeaderText="District" />

                           <asp:TemplateField HeaderText=" Videos">  



                             <ItemTemplate> 
                            <iframe id="ytplayer" type="text/html" width="200" height="200"
                              src=<%# "https://www.youtube.com/embed/" + Eval("video")  %>
                              frameborder="0"></iframe>                
                            
                         </ItemTemplate>  
                    </asp:TemplateField>  

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="view_btn" CssClass="btn btn-primary btn-block btn-lg" OnClick="verify_Click" ForeColor="white" CommandArgument='<%# Eval("Id") %>'>Approve</asp:LinkButton>

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
