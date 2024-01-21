<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="Editbenificary.aspx.cs" Inherits="ABS_Project.Editbenificary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Edit Benificary &#8211; A Blessed Society</title>

          <link rel="stylesheet" href="CSS/showbenificary.css" type="text/css" />
    
       <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>

     <script type="text/javascript">

         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=profilepic.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }

         }
     </script>

    
     <script type="text/javascript">

         function showdeathcert(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=death.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }

         }


     </script>

     <script type="text/javascript">

         function showuc(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=uc_con.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }

         }


     </script>

     <script type="text/javascript">

         function showprnl(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=prnl.ClientID%>').prop('src', e.target.result)
                         .width(70)
                         .height(70);
                 };
                 reader.readAsDataURL(input.files[0]);
             }

         }


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
                        <label style="color:blue; font-size: 20px; user-select: none;">Edit Benificary</label>
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
                        <label>Full Name*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Full Name" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Father's Name*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_fathername" runat="server" placeholder="Father's Name" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Guardian's Name*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_gaurdianname" runat="server" placeholder="Guardian's Name" required></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Benificary Cnic*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic" runat="server" placeholder="Benificary Cnic" required></asp:TextBox>
                        </div>
                     </div>
                    </div>
                       <div class="row">
                     <div class="col">
                        <label>Full Address*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                <div class="row">
                     <div class="col-md-6">
                        <label>Gaurdian's Email ID*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_gaurdianemail" runat="server" placeholder="Email ID"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <label>Gaurdian's Contact No*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_contact" runat="server" placeholder="Gaurdian's Contact No" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                    <div class="row">
                        <div class="col-md-6">
                            <label>Country*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Province/State*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_province" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_province_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select Province/State</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>District*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_district" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" required>
                                            <asp:ListItem Value="0">Select District</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                       

                     
                    <div class="col-md-6">
                            <label>School Name*</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_school" runat="server" AutoPostBack="true" required>
                                            <asp:ListItem Value="0">Select School</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>



                  <div class="row">
                     <div class="col">
                        <label>Needs*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_needs" runat="server" placeholder="Needs" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 
                   
                

                   <div class="row">

                        <div class="col mx-auto">
                         <center>

                        <label>Benificary Picture*</label>
                        <div class="form-group">
                             <asp:Image ID="profilepic" Height="70px" Width="70px" runat="server" /><br />
                             <asp:FileUpload ID="profile_upload" CssClass="form-control" Width="70px" runat="server" onchange="ShowImagePreview(this);" />               
                        </div>

                             </center>
                     </div>

                     <div class="col mx-auto">
                         <center>

                        <label>Death Certificate</label>
                        <div class="form-group">
                             <asp:Image ID="death" Height="70px" Width="70px" runat="server" /><br />
                             <asp:FileUpload ID="death_upl" CssClass="form-control" Width="70px" runat="server" onchange="showdeathcert(this);" />               
                        </div>

                             </center>
                     </div>

                                            <div class="col mx-auto">
                         <center>

                        <label>Uc Confirmation</label>
                        <div class="form-group">
                             <asp:Image ID="uc_con" Height="70px" Width="70px" runat="server" /><br />
                             <asp:FileUpload ID="uc_uplaoad" CssClass="form-control" Width="70px" runat="server" onchange="showuc(this);" />               
                        </div>

                             </center>
                     </div>

                                            <div class="col mx-auto">
                         <center>

                        <label>Principal Letter</label>
                        <div class="form-group">
                             <asp:Image ID="prnl" Height="70px" Width="70px" runat="server" /><br />
                             <asp:FileUpload ID="prn_upload" CssClass="form-control" Width="70px" runat="server" onchange="showprnl(this);" />               
                        </div>

                             </center>
                     </div>
                    </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col">
                         <centre>
                        <asp:Label ID="message" runat="server" style="color: blue;"></asp:Label>
                         </centre>
                     </div>
                  </div>

                </div>
            </div>
        </div>
</div>
        
</asp:Content>
