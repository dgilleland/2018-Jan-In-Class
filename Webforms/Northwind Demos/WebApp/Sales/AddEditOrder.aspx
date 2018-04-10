<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditOrder.aspx.cs" Inherits="WebApp.Sales.AddEditOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Add/Edit Orders</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-inline">
                        <asp:Label ID="Label16" runat="server" CssClass="control-label"
                            Text="Customers" AssociatedControlID="CurrentCustomersDropDown" />
                        <asp:DropDownList ID="CurrentCustomersDropDown" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:LinkButton ID="SelectOrdersForCustomer" runat="server" CausesValidation="false"
                            CssClass="btn btn-primary" OnClick="SelectOrdersForCustomer_Click">
                            List Customer Orders&nbsp;<i class="glyphicon glyphicon-search"></i>
                        </asp:LinkButton>
                    </div>
                    <div class="form-inline" id="OrderSelectionDiv" runat="server">
                        <asp:Label ID="Label1" runat="server" CssClass="control-label"
                            Text="Orders" AssociatedControlID="CustomerOrdersDropDown" />
                        <asp:DropDownList ID="CustomerOrdersDropDown" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:LinkButton ID="ShowOrderDetails" runat="server" CausesValidation="false"
                            CssClass="btn btn-primary" OnClick="ShowOrderDetails_Click">
                            Show Order Details&nbsp;<i class="glyphicon glyphicon-search"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="col-sm-6 text-center">
                    <asp:LinkButton ID="AddOrder" runat="server"
                        CssClass="btn btn-default" OnClick="AddOrder_Click">Add Order</asp:LinkButton>
                    <asp:LinkButton ID="UpdateOrder" runat="server"
                        CssClass="btn btn-default" OnClick="UpdateOrder_Click">Update Order</asp:LinkButton>
                    <asp:LinkButton ID="DeleteOrder" runat="server"
                        CssClass="btn btn-default" OnClick="DeleteOrder_Click">Delete Order</asp:LinkButton>
                    <asp:LinkButton ID="ClearForm" runat="server" CausesValidation="false"
                        CssClass="btn btn-default" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
                </div>
            </div>
        </div>
        <hr />
        <div class="col-md-12">
            <br />
            <asp:Panel ID="MessagePanel" runat="server" Visible="false" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="MessageLabel" runat="server" />
            </asp:Panel>
        </div>
        <div class="col-md-12">
            <fieldset>
                <legend>Order Details</legend>
                <asp:Label ID="Label3" runat="server" Text="Order ID" AssociatedControlID="OrderID" />
                <asp:TextBox ID="OrderID" runat="server" Enabled="false" />

                <asp:Label ID="Label4" runat="server" Text="Customer" AssociatedControlID="CustomerDropDown"></asp:Label>
                <asp:DropDownList ID="CustomerDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label5" runat="server" Text="Employee" AssociatedControlID="EmployeeDropDown"></asp:Label>
                <asp:DropDownList ID="EmployeeDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label12" runat="server" Text="Shipper" AssociatedControlID="ShipperDropDown"></asp:Label>
                <asp:DropDownList ID="ShipperDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label2" runat="server" Text="Order Date" AssociatedControlID="OrderDate" />
                <asp:TextBox ID="OrderDate" runat="server" TextMode="Date" />

                <asp:Label ID="Label13" runat="server" Text="Required Date" AssociatedControlID="RequiredDate" />
                <asp:TextBox ID="RequiredDate" runat="server" TextMode="Date" />

                <asp:Label ID="Label14" runat="server" Text="Shipped Date" AssociatedControlID="ShipDate" />
                <asp:TextBox ID="ShipDate" runat="server" TextMode="Date" />

                <asp:Label ID="Label6" runat="server" Text="Freight Charge" AssociatedControlID="FreightCharge"></asp:Label>
                <asp:TextBox ID="FreightCharge" runat="server"></asp:TextBox>
            </fieldset>

            <fieldset>
                <legend>Shipping Address</legend>
                <asp:Label ID="Label7" runat="server" Text="Name (Attn:)" AssociatedControlID="ShipToName"></asp:Label>
                <asp:TextBox ID="ShipToName" runat="server"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Text="Address" AssociatedControlID="ShipToAddress"></asp:Label>
                <asp:TextBox ID="ShipToAddress" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="City" AssociatedControlID="ShipToCity"></asp:Label>
                <asp:TextBox ID="ShipToCity" runat="server"></asp:TextBox>

                <asp:Label ID="Label10" runat="server" Text="Region" AssociatedControlID="ShipToRegion"></asp:Label>
                <asp:TextBox ID="ShipToRegion" runat="server"></asp:TextBox>

                <asp:Label ID="Label11" runat="server" Text="Postal Code" AssociatedControlID="ShipToPostalCode"></asp:Label>
                <asp:TextBox ID="ShipToPostalCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label15" runat="server" Text="Country" AssociatedControlID="ShipToCountry"></asp:Label>
                <asp:DropDownList ID="ShipToCountry" runat="server"></asp:DropDownList>
            </fieldset>
        </div>
    </div>
    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
    <style>
        select.form-control, input[type=date] {
            width: auto;
        }
    </style>
</asp:Content>
