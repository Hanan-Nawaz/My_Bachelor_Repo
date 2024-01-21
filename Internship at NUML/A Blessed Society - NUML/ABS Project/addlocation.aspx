<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="addlocation.aspx.cs" Inherits="ABS_Project.addlocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>Add Location &#8211; A Blessed Society</title>

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
                        <label style="color:blue; font-size: 20px; user-select: none;">Add Location</label>
                        </center>
                     </div>
                   </div>
                   
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Add Province</label>
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
                            <label>Country</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="true" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                          <div class="col-md-4">
                        <label>Province/State</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_province" runat="server" placeholder="Province/State" ></asp:TextBox>
                        </div>
                     </div>

                             
                        <div class="col-md-4 mt-3 mb-4">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save_province" runat="server" Text="Save" OnClick="btn_save_province_Click"/>
                           </div>
                        </center>
                     </div>
                </div>



                   <div class="row">
                       <div class="col">
                         <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Add District</label>
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
                            <label>Country</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_county1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_county1_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Province/State</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_province1" runat="server" AutoPostBack="true" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                         <div class="col-md-4">
                        <label>District</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_district" runat="server" placeholder="District" ></asp:TextBox>
                        </div>
                     </div>

                   </div>
                   
                   <div class="row">
                        <div class="col-md-4 mt-2 mb-4 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save_district" runat="server" Text="Save" OnClick="btn_save_district_Click"/>
                           </div>
                        </center>
                     </div>
                   </div>


                   <div class="row">
                        <div class="col-md-3 mt-3 mx-auto">
                         <centre>
                        <asp:Label ID="message" runat="server" style="color: blue; text-align: center;"></asp:Label>
                         </centre>
                     </div>
                       </div>
                      

                        
                        </div>


                   
                    

            </div>
        </div>
    </div>
</asp:Content>
