<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="FootballFieldReservation.logIn" %>
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
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox ID="passwordTxt" runat="server" CssClass="form-control" placeholder="password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                        </div>
                    </div>
                </div>
                <asp:Button ID="loginButton" runat="server" CssClass="btnSubmit" Text="Login" OnClick="loginButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
