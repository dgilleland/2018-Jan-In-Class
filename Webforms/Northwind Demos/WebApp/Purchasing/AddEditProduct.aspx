<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditProduct.aspx.cs" Inherits="WebApp.Purchasing.AddEditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Products</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-inline">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label"
                            Text="Products" AssociatedControlID="CurrentProducts" />
                        <asp:DropDownList ID="CurrentProducts" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:LinkButton ID="ShowProductDetails" runat="server" CausesValidation="false"
                            CssClass="btn btn-primary" OnClick="ShowProductDetails_Click">
                            Show Product Details <i class="glyphicon glyphicon-search"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="col-sm-6">
                    <%--buttons...--%>
                </div>
            </div>
        </div>
        <hr />
        <div class="col-md-12">
            <asp:Label ID="MessageLabel" runat="server" />
        </div>
        <div class="col-md-12">
            <div class="row">
                <fieldset>
                    <legend>Product Details</legend>
                    <asp:Label ID="Label3" runat="server" Text="Product ID" AssociatedControlID="ProductID" />
                    <asp:TextBox ID="ProductID" runat="server" Enabled="false" />

                    <asp:Label ID="Label2" runat="server" Text="Product Name" AssociatedControlID="ProductName" />
                    <asp:TextBox ID="ProductName" runat="server" />

                    <asp:Label ID="Label4" runat="server" Text="Supplier" AssociatedControlID="SupplierDropDown"></asp:Label>
                    <asp:DropDownList ID="SupplierDropDown" runat="server"></asp:DropDownList>

                    <asp:Label ID="Label5" runat="server" Text="Category" AssociatedControlID="CategoryDropDown"></asp:Label>
                    <asp:DropDownList ID="CategoryDropDown" runat="server"></asp:DropDownList>
                </fieldset>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
