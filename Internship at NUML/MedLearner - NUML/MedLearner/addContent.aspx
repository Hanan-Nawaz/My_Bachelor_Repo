<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addContent.aspx.cs" Inherits="MedLearner.addContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Content</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="dashboard.aspx">Dashboard</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase" runat="server" id="lblCourseName" ></p>
            </div>
        </div>
    </div>

    <div class="container-fluid">

         <div class="col-md-13">
            <div class="card">
                           <div id="alertError" runat="server" class="alert alert-danger">  
            <strong>Error!</strong> A problem has been occurred while adding Content. 
        </div>  

         <div id="alertSuccess" runat="server" class="alert alert-success">  
            <strong>Congrats!</strong> Content Saved Successfully. 
        </div>  

                <div class="row">
                    <div class="col-md-12">
                        <h4 class="text-center text-primary">Already Added Viewable Content</h4>
                    </div>
                </div>
                <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="grdContent" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" DataKeyNames="Id" EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"  />  
                                            <asp:BoundField DataField="Title" HeaderText="Name"  HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />                                     
                                            <asp:TemplateField HeaderText="Edit/Delete Content">
                                               
                                            </asp:TemplateField>
                                        </Columns>  
                                    </asp:GridView>  
                                </div>  
                                </div>
                            </div> 
               <div class="card-body" id="inputForm" runat="server">
                     

                    <div class="row">
                     <div class="col-md-12">
                        <label>Course*</label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" required>
                                <asp:ListItem Value="0">Select Course </asp:ListItem>
                             </asp:DropDownList>                        
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-12">
                        <label>Name of Content*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Course Name Here" required></asp:TextBox>
                        </div>
                     </div>
                    </div>

                       <div class="row">
                     <div class="col">
                        <label>Description*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Course Description Here" TextMode="MultiLine" Rows="10" required></asp:TextBox>
                        </div>
                     </div>
                  </div>
             

                   
                              <div class="row">

                        <div class="col mx-auto">
                             <center>
                                <label>Videos*</label>
                                <div class="form-group">
                                     <asp:FileUpload ID="img_vid_Upload" CssClass="form-control" AllowMultiple="false" accept=".mp4" Width="270px" runat="server"  />               
                                </div>
                            </center>
                        </div>                 
                    </div>

                  <div class="row mt-5">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Save Viewable Content" OnClick="btnAdd_Click"/>
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
