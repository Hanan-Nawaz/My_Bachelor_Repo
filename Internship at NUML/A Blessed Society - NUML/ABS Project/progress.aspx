<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="progress.aspx.cs" Inherits="ABS_Project.progress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <title>View Progress &#8211; A Blessed Society</title>

              <link rel="stylesheet" href="CSS/showbenificary.css" type="text/css" />
      <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>

     <script type="text/javascript">
         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=Image1.ClientID%>').prop('src', e.target.result)
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
                        <label style="color:blue; font-size: 20px; user-select: none;">Progress</label>
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
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_name" runat="server" placeholder="Full Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Father's Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_fathername" runat="server" placeholder="Father's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Guardian's Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_gaurdianname" runat="server" placeholder="Guardian's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Benificary Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic" runat="server" placeholder="Benificary Cnic" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                    </div>
                       <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                <div class="row">
                     <div class="col-md-6">
                        <label>Gaurdian's Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_gaurdianemail" runat="server" placeholder="Email ID"  Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <label>Gaurdian's Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_contact" runat="server" placeholder="Gaurdian's Contact No" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                    <div class="row">
                        <div class="col-md-6">
                            <label>Country</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="true" Readonly="true">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Province/State</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_province" runat="server" AutoPostBack="true"  Readonly="true">
                                            <asp:ListItem Value="0">Select Province/State</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>District</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_district" runat="server" AutoPostBack="true"  Readonly="true">
                                            <asp:ListItem Value="0">Select District</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>



                    <div class="col-md-6">
                            <label>School Name</label>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="form-control" ID="ddl_school" runat="server" AutoPostBack="true" Readonly="true">
                                            <asp:ListItem Value="0">Select School</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>



                  <div class="row">
                     <div class="col">
                        <label>Needs</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_needs" runat="server" placeholder="Needs" TextMode="MultiLine" Rows="2" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 
                   
               
                  

                   <div class="row">

                        <div class="col mx-auto">
                         <center>

                        <label>Benificary Picture</label>
                        <div class="form-group">
                             <asp:Image ID="profilepic" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>

                     <div class="col mx-auto">
                         <center>

                        <label>Death Certificate</label>
                        <div class="form-group">
                             <asp:Image ID="death" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>

                                            <div class="col mx-auto">
                         <center>

                        <label>Uc Confirmation</label>
                        <div class="form-group">
                             <asp:Image ID="uc_con" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>

                                            <div class="col mx-auto">
                         <center>

                        <label>Principal Letter</label>
                        <div class="form-group">
                             <asp:Image ID="prnl" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>
                    </div>


                   

                     <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Volunteer</label>
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
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_vol_name" runat="server" placeholder="Full Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_vol_contact" runat="server" placeholder="Father's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_number" runat="server" placeholder="Guardian's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label> Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_cnic_vol" runat="server" placeholder="Benificary Cnic" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                    </div>
                 
                 <div class="row" >
                     
                                            <div class="col mx-auto">
                         <center>

                        <label>Volunteer</label>
                        <div class="form-group">
                             <asp:Image ID="img_vol_pic" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>
                    </div>

                    <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Donor</label>
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
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_don_name" runat="server" placeholder="Full Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_don_email" runat="server" placeholder="Father's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_don_number" runat="server" placeholder="Guardian's Name" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label> Cnic</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_don_cnic" runat="server" placeholder="Benificary Cnic" Readonly="true"></asp:TextBox>
                        </div>
                     </div>
                    </div>
                 
                 <div class="row" >
                     
                                            <div class="col mx-auto">
                         <center>

                        <label>Donor</label>
                        <div class="form-group">
                             <asp:Image ID="img_don" Height="100px" Width="100px" runat="server" />
                        </div>

                             </center>
                     </div>
                    </div>




                      <div class="row mt-5">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 17px; user-select: none;">Images</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                    <div class="row mt-2">
                       <div class="col mx-auto">
                    <asp:GridView ID="girdview" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" ShowHeader="false" RowStyle-CssClass="rows">

                        <Columns>          
                                    <asp:ImageField DataImageUrlField="image" ControlStyle-Width="100%" ControlStyle-Height="400px"/>
                            
                                </Columns>
                            </asp:GridView>
                       </div>
                   </div>

                   <div class="row mt-5">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 17px; user-select: none;">Videos</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                    <div class="row mt-2">
                       <div class="col mx-auto">
                    <asp:GridView ID="gird" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" ShowHeader="false" RowStyle-CssClass="rows">

                        <Columns>
                           <asp:TemplateField HeaderText="Videos">  

                             <ItemTemplate> 
                                                             <div class="embed-responsive embed-responsive-16by9">

<iframe id="ytplayer" type="text/html" 
  src=<%# "https://www.youtube.com/embed/" + Eval("video")  %>
  frameborder="0"></iframe>                
                            </div>
                         </ItemTemplate>  
                    </asp:TemplateField>  

                            </Columns>
                        
                        
                       

                            </asp:GridView>
                       </div>
                   </div>
                   
                 
                   <div class="row mt-5" >
                    
                 
                    <div class="col-md-6">
                            <asp:label runat="server" Id="lbl_img">Upload Image</asp:label>
                            <div class="form-group">
                              <asp:Image ID="Image1" Height="70px" Width="70px" runat="server" /><br />
                              <asp:FileUpload CssClass="form-control" ID="fu_image_uplaod" onchange="ShowImagePreview(this);" runat="server"></asp:FileUpload>
                              
                            </div>
                        </div>

                    
                     <div class="col-6 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_image" runat="server" Text="Image Upload" OnClick="btn_image_Click"/>
                           </div>
                        </center>
                     </div>
                    </div>


                     <div class="row mt-5" >
                    
                    

                    
                     <div class="col-12 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Label ID="label" runat="server"> Please Enter link after v= like take an example https://www.youtube.com/watch?v=6hUjX6DQTVQ [v=] So, Enter only 6hUjX6DQTVQ Thanks"
</asp:Label>
                           </div>
                        </center>
                     </div>
                    </div>

                   <div class="row mt-5" >
                    
                    <div class="col-md-6">
                            <asp:label  runat="server" Id="lbl_vid">Upload Video</asp:label>
                            <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="f_video" runat="server" Placeholder="Enter Link"  Required></asp:TextBox>
                              
                            </div>
                        </div>

                    
                     <div class="col-6 mt-3">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_video" runat="server" Text="Video Upload" OnClick="btn_video_Click"/>
                           </div>
                        </center>
                     </div>
                    </div>

                   
                    <div class="row">
                     <div class="col mx-auto">
                         <centre>
                        <asp:Label ID="message" runat="server" style="color: blue;"></asp:Label>
                         </centre>
                     </div>
                  </div>
                  
                      <div class="row">
                     <div class="col-md-6 mx-auto">
                         <centre>
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="verify" runat="server" Text="Verify by Gaurdian" OnClick="verify_Click"/>
                         </centre>
                     </div>
                  </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
