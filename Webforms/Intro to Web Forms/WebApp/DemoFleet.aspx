<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoFleet.aspx.cs" Inherits="WebApp.DemoFleet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Star Trek Fleet</h1>
    <div class="row">
        <div class="col-md-6">
            <fieldset>
                <legend>Create Ship</legend>
                <asp:Label ID="Label1" runat="server" Text="Registry Name" AssociatedControlID="Registry" />
                <asp:TextBox ID="Registry" runat="server" placeholder="e.g.: NCC-1517" />

                <asp:Label ID="Label2" runat="server" Text="Class" AssociatedControlID="ShipClass" />
                <asp:DropDownList ID="ShipClass" runat="server">
                    <asp:ListItem>Excelsior</asp:ListItem>
                    <asp:ListItem>Constitution</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label3" runat="server" Text="Max Power" AssociatedControlID="Power" />
                <asp:TextBox ID="Power" runat="server" TextMode="Range" min="500" max="2000" Text="1000" step="50" />
            </fieldset>
            <asp:LinkButton ID="AddShip" runat="server" OnClick="AddShip_Click">Add Ship</asp:LinkButton>
            <asp:LinkButton ID="ClearForm" runat="server" CausesValidation="false" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
        </div>
        <div class="col-md-6">
            <asp:Label ID="MessageLabel" runat="server" />
            <asp:GridView ID="FleetGrid" runat="server"></asp:GridView>
        </div>
    </div>
    <script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>
