<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="addPrice.aspx.cs" Inherits="MedLearner.addPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Add Price</h1>
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
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="text-center text-primary">Already Added Price</h4>
                    </div>
                </div>
                <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                                    <asp:GridView ID="grdPrice" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" DataKeyNames="Id" EmptyDataText="There are no data records to display.">  
                                        <Columns>  
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"  />  
                                            <asp:BoundField DataField="Price" HeaderText="Price"  HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="Currency" HeaderText="Currency"  ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="CCode" HeaderText="Cupion Code"  HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="DiscountOnCCode" HeaderText="Discount On Cupion Code"  ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:TemplateField HeaderText="Edit Price">
                                                <ItemTemplate >
                                                    <asp:LinkButton ID="btnEdit" Width="100%" CssClass="btn btn-sm btn-primary" OnClick="btnEdit_Click" runat="server"> <i class="fas fa-edit"></i> Edit</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  
                                    </asp:GridView>  
                                </div>  
                                </div>
                            </div> 


                <div class="row card-body">
                     <div class="col-md-12">
                        <label>Course*</label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" required>
                                <asp:ListItem Value="0">Select Course </asp:ListItem>
                             </asp:DropDownList>                        
                        </div>
                     </div>
                  </div>

               <div class="card-body" id="inputForm" runat="server">
                     

                   
                  <div class="row">
                     <div class="col-md-6">
                        <label>Name of Plan*</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Course Name Here" required></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                            <label>Payment Plan*</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlPaymentPlan" runat="server" AutoPostBack="false" required>
                                     <asp:ListItem Value="0">Select Payment Plan</asp:ListItem>
                                     <asp:ListItem Value="1">Free</asp:ListItem>
                                     <asp:ListItem Value="2">Monthly</asp:ListItem>
                                     <asp:ListItem Value="3">One Time</asp:ListItem>
                                </asp:DropDownList>
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
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnAdd" runat="server" Text="Save Price" OnClick="btnAdd_Click"/>
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
