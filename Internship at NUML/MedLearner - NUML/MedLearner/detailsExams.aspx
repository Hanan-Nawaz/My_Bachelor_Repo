<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="detailsExams.aspx.cs" Inherits="MedLearner.detailsExams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style>
          
        .container{
            text-align: justify;
            text-justify: inter-word;
        }

        body {
          color: #333;
          background: #fcfcfc;
          overflow-x: hidden;
        }

        .faq-header{
          font-size: 42px;
          border-bottom: 1px dotted #ccc;
          padding: 24px;
        }

        .faq-content {
          margin: 0 auto;
        }

        .faq-question {
          padding: 20px 0;
          border-bottom: 1px dotted #ccc;
        }

        .panel-title {
          font-size: 24px;
          width: 100%;
          position: relative;
          margin: 0;
          padding: 10px 10px 0 48px;
          display: block;
          cursor: pointer;
        }

        .panel-content {
          font-size: 20px;
          padding: 0px 14px;
          margin: 0 40px;
          height: 0;
          overflow: hidden;
          z-index: -1;
          position: relative;
          opacity: 0;
          -webkit-transition: .4s ease;
          -moz-transition: .4s ease;
          -o-transition: .4s ease;
          transition: .4s ease;
        }

        .panel:checked ~ .panel-content{
          height: auto;
          opacity: 1;
          padding: 14px;
        }

        .plus {
          position: absolute;
          margin-left: 20px;
          margin-top: 4px;
          z-index: 5;
          font-size: 42px;
          line-height: 100%;
          -webkit-user-select: none;    
          -moz-user-select: none;
          -ms-user-select: none;
          -o-user-select: none;
          user-select: none;
          -webkit-transition: .2s ease;
          -moz-transition: .2s ease;
          -o-transition: .2s ease;
          transition: .2s ease;
        }

        .panel:checked ~ .plus {
          -webkit-transform: rotate(45deg);
          -moz-transform: rotate(45deg);
          -o-transform: rotate(45deg);
          transform: rotate(45deg);
        }

        .panel {
          display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom">
        <div class="container text-center py-5">
            <h1 class="text-white display-1" runat="server" id="h1CourseName"></h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
          <h6 class="text-white p" runat="server" id="h6TutorName"></h6>
          <h6 class="text-white p" runat="server" id="h6Money"></h6>
          <asp:LinkButton runat="server" ID="btnEnroll" OnClick="btnEnroll_Click" class="btn btn-primary px-4 px-lg-5 p-3">Buy & Take Exam</asp:LinkButton>

        </div>
    </div>

        <div class="container ">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title position-relative mb-4">
                        <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Description</h6>
                    </div>
                    <p runat="server" id="pDescription"></p>
                </div>
            </div>
                    </div>


            <div class="container py-5">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title position-relative mb-4">
                        <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Instruction</h6>
                    </div>
                    <p runat="server" id="pinstruction"></p>
                </div>
            </div>
                </div>

</asp:Content>
