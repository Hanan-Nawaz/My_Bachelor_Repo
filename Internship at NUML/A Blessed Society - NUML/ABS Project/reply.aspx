<%@ Page Title="" Language="C#" MasterPageFile="~/abs.Master" AutoEventWireup="true" CodeBehind="reply.aspx.cs" Inherits="ABS_Project.reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <title>Reply &#8211; A Blessed Society</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      
         <div class="col-md-13">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                        <label style="color:blue; font-size: 20px; user-select: none;">Reply Contact Request</label>
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   
                  <div class="row">
                     <div class="col-md-6 mx-auto">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                   </div>

                   
                  <div class="row">
                     <div class="col-md-6 mx-auto">
                        <label>Subject</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_subject" runat="server" placeholder="Subject" required></asp:TextBox>
                        </div>
                     </div>
                    </div>

                    <div class="row">
                     <div class="col-md-6 mx-auto">
                        <label>Message</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tb_message" runat="server" placeholder="Message" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">

                        <div class="col-md-6 mt-5 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btn_reply" runat="server" Text="Send" OnClick="btn_reply_Click"/>
                           </div>
                        </center>
                     </div>
                </div>

                   <div class="row">
                     <div class="col-md-6 mx-auto">
                        <label id="message" runat="server" style="color: blue;"></label>               
                     </div>
                  </div>

            </div>
        </div>
    </div>
</div>
</asp:Content>
