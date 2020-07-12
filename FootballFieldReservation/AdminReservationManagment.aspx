<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="AdminReservationManagment.aspx.cs" Inherits="FootballFieldReservation.AdminReservationManagment" %>

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
                                     <asp:TextBox CssClass="form-control" ID="resvIDTextBox" runat="server" placeholder="Reservation ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Field ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="resvFieldIDTextBox" runat="server" placeholder="Field ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="resvUserIDTextBox" runat="server" placeholder="User ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="startCalendar" runat="server"></asp:Calendar>
                                    <asp:TextBox ID="startTextBox" runat="server" TextMode="Time" OnTextChanged="startTextBox_TextChanged"></asp:TextBox>
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
                            <asp:Label ID="dateVaildationLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:Button ID="searchButton" class="btn btn-lg btn-block btn-primary" runat="server" Text="Search" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="addButton" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="addButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="updateButton" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="deleteButton" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" />
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
                                <asp:GridView class="table table-striped table-bordered" ID="fieldsTable" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
