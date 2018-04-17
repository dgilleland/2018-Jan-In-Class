<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sandbox.aspx.cs" Inherits="WebApp.AdHoc.Sandbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="CountryDropDown" runat="server" DataSourceID="CountryDataSource" DataTextField="Country" DataValueField="Country" AppendDataBoundItems="true">
        <asp:ListItem Value="">[Select a country]</asp:ListItem>
    </asp:DropDownList>
    <asp:ObjectDataSource runat="server" ID="CountryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCountries" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
</asp:Content>
