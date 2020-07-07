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
                            <input type="text" id="nameInputField" runat="server" class="form-control" placeholder="Your Name *" value="" />
                        </div>
                        <div class="form-group">
                            <input type="text" id="phoneInputField" runat="server" class="form-control" placeholder="Phone Number *" value="" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" id="passwordInputField" runat="server" class="form-control" placeholder="Your Password *" value="" />
                        </div>
                        <div class="form-group">
                            <input type="text" id="confirmPasswordInputField" runat="server" class="form-control" placeholder="Confirm Password *" value="" />
                        </div>
                    </div>
                </div>
                <button id="submitButton" runat="server" onserverclick="submitClicked" type="button" class="btnSubmit">Submit</button>
            </div>
        </div>
    </div>
</asp:Content>
