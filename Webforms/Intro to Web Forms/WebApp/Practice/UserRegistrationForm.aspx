<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistrationForm.aspx.cs" Inherits="WebApp.Practice.UserRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="page-header">User Registration</h1>

    <div class="row">
        <div class="col-md-6">
            <p>Please fill in the form below and click submit. After submitting the form, you will receive an email with a link to confirm your registration. By clicking on that link, you will complete the registration process.</p>
            <fieldset>
                <asp:Label ID="Label" runat="server"
                     AssociatedControlID="FirstName"
                     Text="First Name" />
                <asp:TextBox ID="FirstName" runat="server" />

                <asp:Label ID="Label1" runat="server"
                     AssociatedControlID="LastName"
                     Text="Last Name" />
                <asp:TextBox ID="LastName" runat="server" />

                <asp:Label ID="Label2" runat="server"
                     AssociatedControlID="UserName"
                     Text="User Name" />
                <asp:TextBox ID="UserName" runat="server" />

                <asp:Label ID="Label3" runat="server"
                     AssociatedControlID="Email"
                     Text="Email Address" />
                <asp:TextBox ID="Email" runat="server" />

                <asp:Label ID="Label4" runat="server"
                     AssociatedControlID="ConfirmEmail"
                     Text="Confirm Email" />
                <asp:TextBox ID="ConfirmEmail" runat="server" />

                <asp:Label ID="Label5" runat="server"
                     AssociatedControlID="Password"
                     Text="Password" />
                <asp:TextBox ID="Password" runat="server" />

                <asp:Label ID="Label6" runat="server"
                     AssociatedControlID="ConfirmPassword"
                     Text="Confirm Password" />
                <asp:TextBox ID="ConfirmPassword" runat="server" />

                <asp:CheckBox ID="AgreeToTerms" runat="server"
                     Text="I agree to the terms of this site" />
            </fieldset>

            <asp:LinkButton ID="SubmitRegistration" runat="server"
                 Text="Submit Registration" CssClass="btn btn-primary"
                 OnClick="SubmitRegistration_Click"></asp:LinkButton>
        </div>
        <div class="col-md-6">

        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
