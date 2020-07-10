<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FootballFieldReservation.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container register-form">
        <div class="form">
            <div class="note">
                <p>Welcome to the Login Page of Football Field Reservation.</p>
            </div>

            <div class="form-content">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox ID="userNameTxt" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox ID="passwordTxt" runat="server" CssClass="form-control" placeholder="password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="loginButton" runat="server" CssClass="btnSubmit" Text="Login" OnClick="loginButton_Click" />
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="signupLink" runat="server" CausesValidation="False" PostBackUrl="~/Signup.aspx">Signup</asp:LinkButton>
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="ForgotPassCode" runat="server" OnClick="ForgotPassCode_Click">Forgot Password</asp:LinkButton>

                </div>
            </div>
        </div>
           
            
           
    </div>
</asp:Content>
