<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditSupplier.aspx.cs" Inherits="WebApp.Purchasing.AddEditSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Supplier</h1>
    </div>
    <div class="row">
        <div class="col-sm-6 form-inline">
            <h4>Actions:</h4>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Company Name" AssociatedControlID="SupplierDropDownList"></asp:Label>
                <asp:DropDownList ID="SupplierDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:LinkButton ID="LookupSupplier" runat="server" CssClass="btn btn-primary" CausesValidation="false" OnClick="LookupSupplier_Click">Lookup Supplier</asp:LinkButton>
            </div>
            <br /><br />
            <div>
                <asp:LinkButton ID="AddSupplier" runat="server" CssClass="btn btn-default" OnClick="AddSupplier_Click">Add Supplier</asp:LinkButton>
                <asp:LinkButton ID="UpdateSupplier" runat="server" CssClass="btn btn-default" OnClick="UpdateSupplier_Click">Update Supplier</asp:LinkButton>
                <asp:LinkButton ID="DeleteSupplier" runat="server" CssClass="btn btn-default" OnClick="DeleteSupplier_Click">Delete Supplier</asp:LinkButton>
                <asp:LinkButton ID="ClearForm" runat="server" CssClass="btn btn-default" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
            </div>
        </div>
        <div class="col-sm-6">
            <h4>Notes:</h4>
            <ul>
                <li>About the HomePage Data Format (see <a href="http://support.microsoft.com/kb/164773" target="_blank">this KB article</a>)
                    <ul>
                        <li>This database was originally a MS Access database. Microsoft Access Hyperlink 
                    fields consist of the following three sections separated by number signs (#): 
                    the Displaytext, the Address, and the Subaddress. The Northwind database has been changed to better suit this course.</li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div>
                <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Supplier Details</legend>
                <asp:Label ID="Label3" runat="server" Text="Supplier ID" AssociatedControlID="CurrentSupplier"></asp:Label>
                <asp:TextBox ID="CurrentSupplier" runat="server" Enabled="false"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Catgeory Name" AssociatedControlID="CompanyName"></asp:Label>
                <asp:TextBox ID="CompanyName" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Contact name" AssociatedControlID="ContactName"></asp:Label>
                <asp:TextBox ID="ContactName" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Contact Title" AssociatedControlID="ContactTitle"></asp:Label>
                <asp:TextBox ID="ContactTitle" runat="server"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" Text="Address" AssociatedControlID="Address"></asp:Label>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="City" AssociatedControlID="City"></asp:Label>
                <asp:TextBox ID="City" runat="server"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Text="Region" AssociatedControlID="Region"></asp:Label>
                <asp:TextBox ID="Region" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="Postal Code" AssociatedControlID="PostalCode"></asp:Label>
                <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label10" runat="server" Text="Country" AssociatedControlID="CountryDropDown"></asp:Label>
                <asp:DropDownList ID="CountryDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label11" runat="server" Text="Phone" AssociatedControlID="Phone"></asp:Label>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>

                <asp:Label ID="Label12" runat="server" Text="Fax" AssociatedControlID="FAx"></asp:Label>
                <asp:TextBox ID="Fax" runat="server"></asp:TextBox>


                <asp:Label ID="Label13" runat="server" Text="Home Page Text" AssociatedControlID="HomePageTitle"></asp:Label>
                <asp:TextBox ID="HomePageTitle" runat="server" Width="250px" CssClass="form-control"
                    ToolTip="The Display Text is the title of the home page as it appears in the browser's tab."></asp:TextBox>

                <asp:Label ID="Label14" runat="server" Text="Home Page" AssociatedControlID="WebAddress"></asp:Label>
                <asp:TextBox ID="WebAddress" runat="server" Width="250px" CssClass="form-control"
                    ToolTip="The Web Address is any valid URL" TextMode="Url"></asp:TextBox>
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
