<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="FootballFieldReservation.user" %>
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
                                <h4 class="text-center">Welcome Back 
                                    <asp:Label ID="Label1" runat="server" Text="userName"></asp:Label>
                                </h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <p class="text-center">Edit your Reservations</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Field ID</label><asp:RegularExpressionValidator ID="onlyNum" runat="server" ControlToValidate="fieldIdTextBox" ErrorMessage="*" ForeColor="#FF3300" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
&nbsp;<div class="form-group">
   
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="fieldIdTextBox" runat="server" placeholder="User id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Field Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="fielNameTextBox" runat="server" placeholder="Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                Start Date <div class="form-group">
                                    <div class="input-group">
                                     <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Time"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date </label>
                               <div class="form-group">
                                  <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:Button ID="searchB" class="btn btn-lg btn-block btn-primary" runat="server" Text="Search" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="addB" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="addB_Click" />
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
                                <h4 class="text-center">
                                   Reservations
                                   
                                </h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="resvTable"  runat="server"  >
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>lNGU</script>
</asp:Content>