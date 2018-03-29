<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditCategory.aspx.cs" Inherits="WebApp.Purchasing.AddEditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Categories</h1>
    </div>
    <div class="row">
        <div class="pull-right col-md-6">
            <fieldset><legend>Form Actions</legend></fieldset>
            <div class="form-inline">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Categories" AssociatedControlID="CurrentCategories"></asp:Label>
                    <asp:DropDownList ID="CurrentCategories" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:LinkButton ID="LookupCategory" runat="server" CssClass="btn btn-primary" CausesValidation="false" OnClick="LookupCategory_Click">Lookup Category</asp:LinkButton>
                </div>
            </div>
            <br />
            <div>
                <asp:LinkButton ID="AddCategory" runat="server" CssClass="btn btn-default" OnClick="AddCategory_Click">Add Category</asp:LinkButton>
                <asp:LinkButton ID="UpdateCategory" runat="server" CssClass="btn btn-default" OnClick="UpdateCategory_Click">Update Category</asp:LinkButton>
                <asp:LinkButton ID="DeleteCategory" runat="server" CssClass="btn btn-default" OnClick="DeleteCategory_Click">Delete Category</asp:LinkButton>
                <asp:LinkButton ID="ClearForm" runat="server" CssClass="btn btn-default" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
            </div>
            <br />
            <div>
                <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                </asp:Panel>
            </div>
        </div>
        <div class="col-md-6">
            <fieldset>
                <legend>
                    <asp:Literal ID="LegendTitle" runat="server" Text="Add Category Form" /></legend>
                <asp:Label ID="Label3" runat="server" Text="Category ID" AssociatedControlID="CategoryID"></asp:Label>
                <asp:TextBox ID="CategoryID" runat="server" Enabled="false"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Catgeory Name" AssociatedControlID="CategoryName"></asp:Label>
                <asp:TextBox ID="CategoryName" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Description" AssociatedControlID="Description"></asp:Label>
                <asp:TextBox ID="Description" runat="server"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" Text="Picture" AssociatedControlID="Picture"></asp:Label>
                <asp:Image ID="Picture" runat="server" ImageUrl="~/Images/NoImage_172x120.gif" />

                <asp:Label ID="Label7" runat="server" Text="Picture" AssociatedControlID="Picture"></asp:Label>
                <asp:CheckBox ID="DeletePicture" runat="server" 
                        Text="Check to delete picture" />

                <asp:Label ID="Label8" runat="server" Text="Image to Upload" AssociatedControlID="CategoryImageUpload"></asp:Label>
                <asp:FileUpload ID="CategoryImageUpload" runat="server" />
            </fieldset>
        </div>
    </div>

    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
    <style>
        select.form-control {
            width: auto;
        }
    </style>
</asp:Content>
