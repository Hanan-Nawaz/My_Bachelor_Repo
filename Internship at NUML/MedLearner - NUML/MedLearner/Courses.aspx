<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="MedLearner.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style>
        
/*products.aspx*/
.probrand {
    font-size: 15px;
    font-weight: 600;
    line-height: 15px;
    text-transform: uppercase;
    font-family: sans-serif;
}

.proName {
    font-size: 13px;
    line-height: 17px;
    font-family: sans-serif;
}

.proPrice {
    font-size: 14px;
    line-height: 17px;
    font-family: sans-serif;
    font-weight: 600;
}

.proOgPrice {
    font-size: 13px;
    font-family: sans-serif;
    font-weight: 400;
    text-decoration: line-through;
    color: gray;
}

.proPriceDiscount {
    font-size: 13px;
    font-family: sans-serif;
    font-weight: 400;
    color: deeppink;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px; margin-right: 0px; margin-left:0px;">
        <div class="container text-center">
            <h1 class="text-white display-1">Courses</h1>
            <div class="mx-auto mb-5" style="width: 100%; max-width: 600px;">
                <div class="input-group">
                    <asp:DropDownList runat="server" ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" CssClass="btn btn-outline-light bg-white text-body px-4 w-25" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="txtSearch" type="text" class="form-control border-light" style="padding: 30px 25px;" placeholder="Keyword"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:LinkButton runat="server" ID="btnsearch" OnClick="btnsearch_Click" class="btn btn-primary px-4 px-lg-5 p-3">Search</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mr-0">
        <div class="row row-cols-1 row-cols-md-3">
            <asp:Repeater ID="Repeatercourses" runat="server">
                <ItemTemplate>
                    <a style="text-decoration: none;" href="details.aspx?CID=<%# Eval("Id") %>">
                  <div class="col mb-4">
                    <div class="card hover-shadow">
                      <img src="Thumbnails/<%#Eval("Thumbnail") %>" height="250" class="card-img-top" alt="...">
                      <div class="card-body">
                        <h5 class="card-title"><%#Eval("Name") %></h5>
                        <p class="card-text"><i class="fa fa-user mr-2"></i></span><%#Eval("TutorName") %> <span class="float-right"><i class="fa fa-money-bill mr-2"></i> <%#Eval("Price") + " " + Eval("Currency") %></span>  </p>
                      </div>
                    </div>
                  </div> 
                        </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
