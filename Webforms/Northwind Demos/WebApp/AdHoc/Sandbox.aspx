<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sandbox.aspx.cs" Inherits="WebApp.AdHoc.Sandbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Sandbox Samples of Object Data Source Controls</h1>
    <div class="row">
        <div class="col-md-12">
            <h2>Simple DropDown</h2>
            <asp:DropDownList ID="CountryDropDown" runat="server" DataSourceID="CountryDataSource" DataTextField="Country" DataValueField="Country" AppendDataBoundItems="true">
                <asp:ListItem Value="">[Select a country]</asp:ListItem>
            </asp:DropDownList>
            <asp:ObjectDataSource runat="server" ID="CountryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCountries" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
        </div>
    </div>
    <hr />

    <div class="row">
        <div class="col-md-12">
            <h2>GridView with Template Columns</h2>
            <asp:GridView ID="Products" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsDataSource"
                ItemType="NorthwindEntities.Product">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>

                    <asp:TemplateField HeaderText="SupplierID">
                        <ItemTemplate>
                            <asp:DropDownList ID="SupplierDropDown" runat="server" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue="<%# Item.SupplierID%>" AppendDataBoundItems="true">
                                <asp:ListItem Value="">[No supplier]</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="CategoryID">
                        <ItemTemplate>
                            <asp:DropDownList ID="CategoryDropDown" runat="server" DataSourceID="CategoryDataSource" DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue="<%# Item.CategoryID %>" AppendDataBoundItems="true">
                                <asp:ListItem Value="">[No Category]</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder"></asp:BoundField>
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
                    <asp:BoundField DataField="ProductInfo" HeaderText="ProductInfo" ReadOnly="True" SortExpression="ProductInfo"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllProducts" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server" ID="SupplierDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSuppliers" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server" ID="CategoryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCategories" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
