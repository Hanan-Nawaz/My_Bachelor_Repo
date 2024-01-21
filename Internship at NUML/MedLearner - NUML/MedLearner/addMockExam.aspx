<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addMockExam.aspx.cs" Inherits="MedLearner.addMockExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Exams</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
        </div>
    </div>
        <div class="container-fluid">
      
            
             <div id="alertError" runat="server" class="alert alert-danger">  
            <strong>Error!</strong> A problem has been occurred while adding Exam. 
        </div>  

         <div id="alertSuccess" runat="server" class="alert alert-success">  
            <strong>Congrats!</strong> Exam Saved Successfully. 
        </div>  


         <div class="col-md-13">
            <div class="card">
               <div class="card-body">


                                      <div class="row">
                        <div class="col-md-6">
                            <label>Parent Tag*</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlPTag" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPTag_SelectedIndexChanged" required="true">
                                    <asp:ListItem Value="0">Select Tag </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label> Child Tag *</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlCTag" runat="server" required="true">
                                    <asp:ListItem Value="0">Select Tag </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                  <div class="row">
                     <div class="col-md-6">
                        <label>Name of Exam*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Name of Exam Here" required></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>Total Marks*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtTotalMarks" runat="server" placeholder="Total Marks Here"  required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                        <div class="col-md-6">
                            <label>Question Type*</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlQuestionType" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="0">Select Question Type</asp:ListItem>
                                     <asp:ListItem Value="1">Mcqs</asp:ListItem>
                                     <asp:ListItem Value="2">True/False</asp:ListItem>
                                     <asp:ListItem Value="3">SBA(Single Best Answer)</asp:ListItem>                                
                                     <asp:ListItem Value="4">EMQ's(Extended Matching Question)</asp:ListItem>                                
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label> Course *</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" AutoPostBack="false" required>
                                    <asp:ListItem Value="0">Select Course </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>        

                   <div class="row">
                     <div class="col-md-6">
                        <label>Passing Score*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPassingScore" runat="server" placeholder="Passing Score Here"  required></asp:TextBox>
                        </div>
                     </div>
                  

                   <div class="col-md-6">
                        <label>Duration in Minutes*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtTimeDuration" runat="server" placeholder="Duration in Minutes Here" required></asp:TextBox>
                        </div>
                     </div>
                  </div>

                       <div class="row">
                     <div class="col">
                        <label>Instructions*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtDInstruction" runat="server" placeholder="Exam Instructions Here" TextMode="MultiLine" Rows="10" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                         
                   
                
                  

                   <div class="row">

                        <div class="col-md-6">
                            <label> Exam Type *</label>
                            <div class="form-group"> 
                                <asp:DropDownList CssClass="form-control" ID="ddlExamType" runat="server" AutoPostBack="false" required>
                                    <asp:ListItem Value="0">Select Exam Type </asp:ListItem>
                                    <asp:ListItem Value="1">Mock Exam </asp:ListItem>
                                    <asp:ListItem Value="2">Question Bank </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>   
                        <div class="col-md-6">
                        <label>Tutor Email*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtTutorEmail" runat="server" ReadOnly="true" placeholder="Duration in Minutes Here" required></asp:TextBox>
                        </div>
                     </div>
                    </div>

                   <div class="row">
                     <div class="col-md-6">
                        <label>Price*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" placeholder="Enter Price Here" required></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                            <label>Currency *</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlCurrency" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="0">Select Currency </asp:ListItem>
                                     <asp:ListItem Value="1">USD</asp:ListItem>
                                     <asp:ListItem Value="2">PKR</asp:ListItem>
                                     <asp:ListItem Value="3">Pound</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>       
                    </div>
                   
                   <div class="row">
                     <div class="col-md-6">
                        <label>Coupion Code*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtCCode" runat="server" placeholder="Enter Coupion Code Here" required></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                            <label>Amount After Discount *</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtDiscountAmount" runat="server" placeholder="Enter Discount Amount Here" required></asp:TextBox>
                            </div>
                        </div>       
                    </div>

                  <div class="row mt-5"> 
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Create Exam" OnClick="btnAdd_Click"/>
                           </div>
                        </center>
                     </div>                  </div>


                   

                </div>
            </div>
        </div>
</div>

</asp:Content>
