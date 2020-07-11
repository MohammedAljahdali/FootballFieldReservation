﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="AdminUserMangament.aspx.cs" Inherits="FootballFieldReservation.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 25%;
            flex: 0 0 25%;
            max-width: 25%;
            left: 0px;
            top: -426px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h4 class="text-center">User Mangament</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <p class="text-center">Add, Update and Delete Users</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="userIDTextBox" runat="server" placeholder="User ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="userNameTextBox" runat="server" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User Role</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="userRoleTextBox" runat="server" placeholder="User Role"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>User Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="userPasswordTextBox" runat="server" placeholder="User Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="auto-style1">
                                <asp:Button ID="searchButton" class="btn btn-lg btn-block btn-primary" runat="server" Text="Search" OnClick="searchButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="addButton" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="addButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="updateButton" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="updateButton_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="deleteButton" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="deleteButton_Click" />
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
                                <center>
                           <h4>Users</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="usersTable" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
