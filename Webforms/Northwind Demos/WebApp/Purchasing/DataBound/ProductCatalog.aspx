<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCatalog.aspx.cs" Inherits="WebApp.Purchasing.DataBound.ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Products by Category</h1>

    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="CategoryDropDown" Text="Categories" />
            <asp:DropDownList ID="CategoryDropDown" runat="server"
                 DataSourceID="CategoryDataSource"
                 DataTextField="CategoryName"
                 DataValueField="CategoryID"
                 AppendDataBoundItems="true">
                <asp:ListItem Value="0" Text="[Select a category]" />
            </asp:DropDownList>
            <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCategories" TypeName="NorthwindSystem.BLL.InventoryPurchasingController"></asp:ObjectDataSource>
            <asp:LinkButton ID="SearchByCategory" runat="server" Text="Find Products by Category" />
        </div>
        <div class="col-md-9">
            <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsDataSource">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID"></asp:BoundField>
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder"></asp:BoundField>
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
                    <asp:BoundField DataField="ProductInfo" HeaderText="ProductInfo" ReadOnly="True" SortExpression="ProductInfo"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategory" TypeName="NorthwindSystem.BLL.InventoryPurchasingController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CategoryDropDown" PropertyName="SelectedValue" Name="searchId" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
