<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addQuestion.aspx.cs" Inherits="MedLearner.addQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Question</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
        </div>
    </div>
        <div class="container-fluid">
      

             <div id="alertError" runat="server" class="alert alert-danger">  
            <strong>Error!</strong> A problem has been occurred while adding Question. 
        </div>  

         <div id="alertSuccess" runat="server" class="alert alert-success">  
            <strong>Congrats!</strong> Question Saved Successfully. 
        </div>  

         <div class="col-md-13">
            <div class="card">
               <div class="card-body">

                   <div class="row">
                        <div class="col-md-12">
                            <label> Select Exam *</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlExam" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" required>
                                    <asp:ListItem Value="0">Select Exam </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>  
                   
                                          <div class="row">
                     <div class="col">
                        <asp:Label runat="server" ID="lbQ">Question*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtQuestion" runat="server" placeholder="Enter Question Here" TextMode="MultiLine" Rows="2" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">

                        <div class="col mx-auto">
                             <center>
                        <asp:Label runat="server" ID="lb12">Question Image if any</asp:Label>
                                <div class="form-group">
                                     <asp:FileUpload ID="imgQuestion" CssClass="form-control" AllowMultiple="false" Width="70px" runat="server"  />               
                                </div>
                            </center>
                        </div>                 
                    </div>

                   <div class="row">
                     <div class="col-md-6">
                                                 <asp:Label runat="server" ID="lb1">Option 1*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtOption1" runat="server" placeholder="Option 1 Here"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <asp:Label runat="server" ID="lb2">Option 2*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtOption2" runat="server" placeholder="Option 2 Here"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                        <asp:Label runat="server" ID="lb3">Option 3*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtOption3" runat="server" placeholder="Option 3 Here"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <asp:Label runat="server" ID="lb4">Option 4*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtOption4" runat="server" placeholder="Option 4 Here"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>


                   <div class="row">
                     <div class="col-md-12">
                        <asp:Label runat="server" ID="lbA">Answer*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtAnswer" runat="server" placeholder="Answer Here"  required></asp:TextBox>
                        </div>
                     </div>
                  
                  </div>

                       <div class="row">
                     <div class="col">
                        <asp:Label runat="server" ID="lbE">Explanation*</asp:Label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtExplanation" runat="server" placeholder="Enter Explanation Here" TextMode="MultiLine" Rows="5" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                    <div class="row">

                        <div class="col mx-auto">
                             <center>
                            <asp:Label runat="server" ID="lb13">Explanation Image if any</asp:Label>
                                <div class="form-group">
                                     <asp:FileUpload ID="imgExplanation" CssClass="form-control" AllowMultiple="false" Width="70px" runat="server"  />               
                                </div>
                            </center>
                        </div>                 
                    </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Add Question" OnClick="btnAdd_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>


                    <div class="row">
                     <div class="col-md-12">
                        <asp:Label ID="lblMessage" CssClass="text-center" runat="server" style="color: blue;"></asp:Label>
                     </div>
                  </div>

                </div>
            </div>
        </div>
</div>
</asp:Content>
