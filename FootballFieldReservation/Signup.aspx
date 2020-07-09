<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FootballFieldReservation.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container register-form">
        <div class="form">
            <div class="note">
                <p>Welcome to the Sign up Page of Football Field Reservation.</p>
            </div>

            <div class="form-content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="nameInputField" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="nameInputField" ErrorMessage="Invalid" ValidationExpression="^([a-zA-Z]{2,}\s[a-zA-z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox id="nameInputField" runat="server" CssClass="form-control" placeholder="Your Name *" ></asp:TextBox>       
                        </div>
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ControlToValidate="idInputField" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorID" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="idInputField" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox id="idInputField" runat="server" CssClass="form-control" placeholder="ID Number *"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="passwordInputField" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox id="passwordInputField" runat="server" CssClass="form-control" placeholder="Your Password *" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidatorPasswordConfirm" runat="server" ControlToValidate="confirmPasswordInputField" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="confirmPasswordValidation" runat="server"></asp:Label>
                            <asp:TextBox id="confirmPasswordInputField" runat="server" CssClass="form-control" placeholder="Confirm Password *" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:button id="submitButton" runat="server" OnClick="submitClicked" CssClass="btnSubmit btn-block" Text="Submit" ValidateRequestMode="Enabled" ValidationGroup="1"/>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="test alert" />
            </div>
        </div>
    </div>
</asp:Content>
