<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="LecturerWithdrawalRequest.aspx.cs" Inherits="ITP213.LecturerWithdrawalRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--************README: Hi, please change some of the following things below when you're coding your features. Thanks! -PS -->

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color: #D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Withdrawal Request</li>
        <!--1. Change the name!-->
    </ol>
    <style>
        .breadcrumb {
            background-color: #FFFFFF !important;
        }

            .breadcrumb > .breadcrumb-item {
                color: #031A82 !important;
            }

            .breadcrumb .breadcrumb-item + .breadcrumb-item::before {
                color: #D6D6D6;
            }
    </style>
    <!-- //Breadcrumbs end-->

    <!-- Page Content -->
    <h1>Withdrawal Request</h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <asp:Repeater ID="RepeaterWithdrawalRequest" runat="server" OnItemCommand="RepeaterWithdrawalRequest_ItemCommand">
            <ItemTemplate>
                <div class="list-group">
                    <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                        <div class="d-flex w-100 justify-content-between">
                            <h5 class="mb-1">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("withdrawTripRequestID") %>'
                                    Text='<%#Eval("tripNameAndTripType") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                    title='<%#"From "+Convert.ToDateTime(Eval("departureDate")).ToShortDateString() + " to "+ Convert.ToDateTime(Eval("arrivalDate")).ToShortDateString() %>'>
                                </asp:LinkButton>
                            </h5>
                            <small>
                                <!--(Convert.ToDateTime(Eval("soDateTo"))).ToShortDateString()-->
                                Posted on:
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                            </small>
                        </div>
                        <p class="mb-1">
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("withdrawalReason") %>'></asp:Label>
                        </p>
                        <small>Requested by:
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("adminNo") %>'></asp:Label></small>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!--If repeater is empty-->
        <asp:Panel ID="PanelEmptyWithdrawalRequest" runat="server" Visible="False">
            <div class="jumbotron jumbotron-fluid">
                <div class="container">
                    <h1 class="display-4">No withdrawal request</h1>
                    <p class="lead">Currently, no student has requested for any withdrawal request.</p>
                </div>
            </div>
        </asp:Panel>
        <!--//If repeater is empty-->
        <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>
    </p>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <!--//Page Content-->
</asp:Content>
