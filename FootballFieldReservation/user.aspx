<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="FootballFieldReservation.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h4 class="text-center">Fields Mangament</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <p class="text-center">Add, Update and Delete Reservations</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Reservation ID</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="resvIDTextBox" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="resvIDTextBox" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ControlToValidate="resvIDTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorID" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="resvIDTextBox" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:TextBox CssClass="form-control" ID="resvIDTextBox" runat="server" placeholder="Reservation ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Field ID</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="resvFieldIDTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="resvFieldIDTextBox" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:TextBox CssClass="form-control" ID="resvFieldIDTextBox" runat="server" placeholder="Field ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="startCalendar" runat="server"></asp:Calendar>
                                    <asp:TextBox ID="startTextBox" runat="server" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="endCalendar" runat="server"></asp:Calendar>
                                    <asp:TextBox ID="endTextBox" runat="server" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Label ID="dateVaildationLabel" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:Button ID="searchButton" class="btn btn-lg btn-block btn-primary" runat="server" Text="Search" OnClick="searchButton_Click" ValidationGroup="1" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="addButton" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="addButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="updateButton" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="updateButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="deleteButton" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="deleteButton_Click" CausesValidation="False" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a><br>
                <br>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h4 class="text-center">Fields</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="ReservationTable" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>