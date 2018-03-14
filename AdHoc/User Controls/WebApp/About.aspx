<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<%@ Register Src="~/UserControls/CaptionedInput.ascx" TagPrefix="uc1" TagName="CaptionedInput" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <uc1:CaptionedInput runat="server" id="CaptionedInput">
        <MessageTemplate>
            <i></i>
        </MessageTemplate>
    </uc1:CaptionedInput>
</asp:Content>
