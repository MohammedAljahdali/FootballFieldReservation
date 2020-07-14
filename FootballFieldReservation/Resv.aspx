<%@ Page Title="" Language="C#" MasterPageFile="~/FootballFieldReservationSite.Master" AutoEventWireup="true" CodeBehind="Resv.aspx.cs" Inherits="FootballFieldReservation.Resv" %>
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
                                <h4 class="text-center">Fields </h4>
                            </div>
                        </div>
                        <div class="row">
                           
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                               
                                <div class="form-group">
                                   <asp:GridView class="table table-striped table-bordered" ID="FieldsTable" runat="server"></asp:GridView>
                                </div>
                            </div>
                            <div class="col-md-6">
                               
                                <div class="form-group">
                              
                                </div>
                            </div>
                        </div>
                      
                          
                               

                        <div class="row">
                            <div class="col-3">
                                <asp:Button ID="RefreshFB" class="btn btn-lg btn-block btn-primary" runat="server" Text="Reload" OnClick="RefreshFB_Click"  />
                            </div>
                            <div class="col-3">
                              
                            </div>
                            <div class="col-3">
                                
                            </div>
                            <div class="col-3">
                           
                            </div>
                        </div>
                    </div>
                </div>
               
                <br>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h4 class="text-center">Reservations</h4>
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
                        <div class="row">
                            <div class="co3">
                          <asp:Button ID="RefreshB" class="btn btn-lg btn-block btn-primary" runat="server" Text="Reload" OnClick="RefreshB_Click"  />
                                  </div>
                </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
