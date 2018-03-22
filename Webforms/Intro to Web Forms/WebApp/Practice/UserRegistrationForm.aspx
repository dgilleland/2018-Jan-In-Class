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
            <asp:Label ID="MessageLabel" runat="server" />
            <div>
                <%--Validation Controls--%>
                <asp:ValidationSummary ID="ValidationSummary" runat="server"
                     CssClass="alert alert-warning alert-dismissible"
                     HeaderText="Please correct the following parts of the form:" />
                <asp:RequiredFieldValidator ID="ValidateFirstName" runat="server"
                     ControlToValidate="FirstName" Display="None"
                     ErrorMessage="You must supply your first name" />
                <asp:RequiredFieldValidator ID="ValidateLastName" runat="server"
                     ControlToValidate="LastName" Display="None"
                     ErrorMessage="You must supply your last name" />

                <asp:RequiredFieldValidator ID="ValidateUserName" runat="server"
                     ControlToValidate="UserName" Display="None"
                     ErrorMessage="You must supply a valid User Name" />
                <asp:RequiredFieldValidator ID="ValidateEmailRequired" runat="server"
                     ControlToValidate="Email" Display="None"
                     ErrorMessage="You must supply your email" />
                <asp:RequiredFieldValidator ID="ValidatePasswordRequired" runat="server"
                     ControlToValidate="Password" Display="None"
                     ErrorMessage="You must supply your own password" />

                <%-- Here, we are using CompareValidators to compare one control's
                value against another control's value. --%>
                <asp:CompareValidator ID="ValidatePassword" runat="server"
                     ControlToValidate="ConfirmPassword" Display="None"
                     ControlToCompare="Password"
                     Operator="Equal" Type="String"
                     ErrorMessage="Password and Confirm Password do not match" />
                <asp:CompareValidator ID="ValidateEmail" runat="server"
                     ControlToValidate="ConfirmEmail" Display="None"
                     ControlToCompare="Email"
                     Operator="Equal" Type="String"
                     ErrorMessage="Email and Confirm Email do not match" />

            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
