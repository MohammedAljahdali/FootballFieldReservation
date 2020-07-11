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
                                <label>User ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="userIdTextBox" runat="server" placeholder="User id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="userNameTextBox" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                Password
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="userPasswordText" runat="server" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Confirm password </label>
                                &nbsp;<div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="userConfiemPasswordTextBox" runat="server" placeholder="Confirm Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                  <asp:Button ID="updateB" class="btn btn-lg btn-block btn-success" Width="230" runat="server" Text="Update" OnClick="updateB_Click" />
                            </div>
                            <div class="col-3">
                               
                            </div>
                            <div class="col-3">
                              <asp:Button ID="deleteB" class="btn btn-lg btn-block btn-danger" runat="server" Width="230" Text="Delete Account" OnClick="deleteB_Click"  />
                            </div>
                            <div class="col-3">
                               
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
                                <h4 class="text-center">User Reservations</h4>
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

</asp:Content>