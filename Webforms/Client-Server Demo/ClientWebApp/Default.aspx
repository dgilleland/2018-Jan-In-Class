<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Code Demos</h2>
            <asp:GridView ID="CodeDemoGridView" runat="server" CssClass="table" >
                <EmptyDataTemplate><i>No data available.</i></EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <h2>Add Code Demo</h2>
            <fieldset>
                <asp:Label id="Label1" runat="server"
                     Text="Demo Name" AssociatedControlID="DemoName" />
                <asp:TextBox ID="DemoName" runat="server" />

                <asp:Label id="Label2" runat="server"
                     Text="Description" AssociatedControlID="Description" />
                <asp:TextBox ID="Description" runat="server"
                     TextMode="MultiLine" />
            </fieldset>
            <asp:LinkButton ID="AddDemo" runat="server"
                 OnClick="AddDemo_Click" CssClass="btn btn-primary">
                <i class="glyphicon glyphicon-plus"></i> Add Demo
            </asp:LinkButton>
        </div>
        <div class="col-md-4">
            <h2>Feedback</h2>
            <asp:Label ID="MessageLabel" runat="server" />
        </div>
    </div>
    <script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>
