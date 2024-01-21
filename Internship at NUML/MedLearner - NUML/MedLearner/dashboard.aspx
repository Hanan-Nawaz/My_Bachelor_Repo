<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="MedLearner.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px; margin-right: 0px; margin-left:0px;">
        <div class="container text-center">
            <h1 class="text-white display-1">Dashboard</h1>
        </div>
    </div>



    <div class="container-fluid mr-0">

 <div class="col-md-13">
            <div class="card">
                <div class="row">
                    <div class="col-md-12">
                        <h2 class="text-center text-primary border-bottom border-1 m-2">Enrolled Courses</h2>
                    </div>
                </div>
                         <div id="alertErrorCourse" runat="server" class="alert alert-danger">  
            <strong>OOPs!</strong> You are not Enrolled in any Course. 
        </div>  
        <div class="row row-cols-1 row-cols-md-3">




            <asp:Repeater ID="Repeatercourses" runat="server">
                <ItemTemplate>
                    <a  style="text-decoration: none;" href="eCoursePage.aspx?CID=<%# Eval("Id") %>">
                  <div class="col mb-4">
                    <div class="card hover-shadow">
                      <img src="Thumbnails/<%#Eval("Thumbnail") %>" height="250" class="card-img-top" alt="...">
                      <div class="card-body">
                        <h5 class="card-title"><%#Eval("Name") %></h5>
                        <p class="card-text"><i class="fa fa-user mr-2"></i></span><%#Eval("TutorName") %> <asp:Label runat="server" ID="Clbl" CssClass="float-right"><%#Eval("PayVerify") %></asp:Label> </p>
                      </div>
                    </div>
                  </div> 
                        </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div>
</div>

 
     <div class="container-fluid mr-0  mt-5">

 <div class="col-md-13">
            <div class="card">
                <div class="row">
                    <div class="col-md-12">
                        <h2 class="text-center text-primary border-bottom border-1 m-2">Enrolled Exams</h2>
                    </div>
                </div>
                 <div id="alertErrorExam" runat="server" class="alert alert-danger">  
            <strong>OOPs!</strong> You are not Enrolled in any Exam. 
        </div>
        <div class="row row-cols-1 row-cols-md-3">

         


            <asp:Repeater ID="RepeaterExams" runat="server">
                <ItemTemplate>
                    <a  style="text-decoration: none;" href="detailsExams.aspx?CID=<%# Eval("Id") %>">
                  <div class="col mb-4">
                    <div class="card hover-shadow">
                      <img src="Thumbnails/<%#Eval("Thumbnail") %>" height="250" class="card-img-top" alt="...">
                      <div class="card-body">
                        <h5 class="card-title"><%#Eval("Name") %></h5>
                        <p class="card-text"><i class="fa fa-user mr-2"></i></span><%#Eval("TutorName") %>   <asp:Label runat="server" ID="spanstatus" class="float-right"> <%#Eval("PayVerify") %></asp:Label> </p> 
                      </div>
                    </div>
                  </div> 
                        </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
         </div>
</div>
</asp:Content>
