<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="AdminFieldsManagment.aspx.cs" Inherits="FootballFieldReservation.AdminFieldsManagment" %>
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
                                <p class="text-center">Add, Update and Delete Fields</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Field ID</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fieldIDTextBox" ErrorMessage="*" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="fieldIDTextBox" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ControlToValidate="fieldIDTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorID" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="fieldIDTextBox" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:TextBox CssClass="form-control" ID="fieldIDTextBox" runat="server" placeholder="Field ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Field Name</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="fieldNameTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="fieldNameTextBox" ErrorMessage="Invalid" ValidationExpression="([A-Z][a-zA-Z]*)" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:TextBox CssClass="form-control" ID="fieldNameTextBox" runat="server" placeholder="Field Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Field Address</label>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fieldAddressTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="form-control" ID="fieldAddressTextBox" runat="server" placeholder="Field Address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Field Capacity</label>
                                <div class="form-group">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid" ValidationExpression="^[0-9]*$" ControlToValidate="fieldCapacityTextBox" ForeColor="Red"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fieldCapacityTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox CssClass="form-control" ID="fieldCapacityTextBox" runat="server" placeholder="Field Capacity"></asp:TextBox>
                                </div>
                            </div>
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
                                <asp:GridView class="table table-striped table-bordered" ID="fieldsTable" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
