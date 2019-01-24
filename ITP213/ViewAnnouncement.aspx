<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewAnnouncement.aspx.cs" Inherits="ITP213.ViewAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet' href='Content/mdb.min.css' />
    <style>
        .tabs {
            position: relative;
            top: 1px;
            left: 10px;
        }

        .tab {
            border: solid 1px black;
            background-color: #F5F6FA;
            padding: 5px 10px;
        }

        .selectedTab {
            background-color: white;
            border-bottom: solid 1px white;
        }

        .tabContents {
            border: solid 1px black;
            padding: 10px;
            background-color: white;
        }
    </style>
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color: #D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">View Announcements</li>
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
    <h1>View Announcements</h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <script>
            $(function () {
                $("#tabs").tabs();
            });
        </script>
        <% String currentAccountType = Session["accountType"].ToString();%>
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">Study Trips</a></li>
                <li><a href="#tabs-2">Immersion Trips</a></li>
                <li><a href="#tabs-3">Internships</a></li>
                <% if (currentAccountType == "lecturer")
                    {%>
                <li><a href="#tabs-4">Withdrawal Request</a></li>
                <%} %>
            </ul>
            <div id="tabs-1">
                <p>
                    <asp:Repeater ID="RepeaterStudyTrips" runat="server" OnItemCommand="RepeaterStudyTrips_ItemCommand" OnItemDataBound="RepeaterStudyTrips_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-12 col-sm-12">
                                    <div class="list-group">
                                        <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                            <div class="d-flex w-100 justify-content-between">
                                                <small>Trip Name:
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName") %>'></asp:Label>
                                                </small>
                                                <small>
                                                    <asp:CheckBox ID="cbRead" runat="server" Text='Mark as read' AutoPostBack="True" OnCheckedChanged="cbRead_CheckedChanged1" CommandName='<%# Eval("announcementID") %>' Visible='<%#Eval("announcementVisible") %>' />
                                                </small>
                                            </div>
                                            <div class="d-flex w-100 justify-content-between">
                                                <h5 class="mb-1">

                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                        Text='<%#Eval("announcementTitle") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                                        title='<%#"Stop showing on "+Eval("timeDue") %>'>
                                                    </asp:LinkButton>
                                                </h5>
                                                <small>
                                                    <asp:Label ID="lblStaffIDForEditAndDeleteBtn" runat="server" Text='<%# Eval("staffID").ToString()%>' Visible="false"></asp:Label>
                                                    <asp:Button ID="btnStudyTripsEdit" runat="server" Class="btn btn-warning btn-sm" Text="Edit Announcement" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnEditTrip_Command" Visible="false" />
                                                    <asp:Button ID="btnStudyTripsDelete" runat="server" Class="btn btn-danger btn-sm" Text="Delete" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnStudyTrips_Command" Visible="false" />
                                                </small>

                                            </div>
                                            <p class="mb-1">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("announcementMessage") %>'></asp:Label>
                                            </p>
                                            <small>By:
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("staffName")%>'></asp:Label>
                                            </small>
                                            <small class="float-right">Posted on:
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                                            </small>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <!--If repeater is empty-->
                    <asp:Panel ID="PanelStudyTrips" runat="server" Visible="False">
                        <div class="jumbotron jumbotron-fluid">
                            <div class="container">
                                <h1 class="display-4">You have no announcements.</h1>
                            </div>
                        </div>
                    </asp:Panel>
                    <!--//If repeater is empty-->
                </p>
            </div>
            <div id="tabs-2">
                <p>
                    <asp:Repeater ID="RepeaterImmersionTrips" runat="server" OnItemCommand="RepeaterImmersionTrips_ItemCommand" OnItemDataBound="RepeaterImmersionTrips_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-12 col-sm-12">
                                    <div class="list-group">
                                        <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                            <small>Trip Name:
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName") %>'></asp:Label></small>
                                            <div class="d-flex w-100 justify-content-between">
                                                <h5 class="mb-1">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("announcementTitle") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                                        title='<%#"Stop showing on "+Eval("timeDue") %>'>
                                                    </asp:LinkButton>
                                                </h5>
                                                <small>
                                                    <asp:Label ID="lblStaffIDForEditAndDeleteBtn" runat="server" Text='<%# Eval("staffID").ToString()%>' Visible="false"></asp:Label>
                                                    <asp:Button ID="btnImmersionTripsEdit" runat="server" Class="btn btn-warning btn-sm" Text="Edit Announcement" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnEditTrip_Command" Visible="false" />
                                                    <asp:Button ID="btnImmersionTripsDelete" runat="server" Class="btn btn-danger btn-sm" Text="Delete" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnStudyTrips_Command" Visible="false" />
                                                </small>

                                            </div>
                                            <p class="mb-1">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("announcementMessage") %>'></asp:Label>
                                            </p>
                                            <small>By:
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("staffName")%>'></asp:Label>
                                            </small>
                                            <small class="float-right">Posted on:
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                                            </small>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <br />

                    <!--If repeater is empty-->
                    <asp:Panel ID="PanelImmersionTrips" runat="server" Visible="False">
                        <div class="jumbotron jumbotron-fluid">
                            <div class="container">
                                <h1 class="display-4">You have no announcements.</h1>
                            </div>
                        </div>
                    </asp:Panel>
                    <!--//If repeater is empty-->
                </p>
            </div>
            <div id="tabs-3">
                <!--If repeater is empty-->
                    <asp:Panel ID="Panel1" runat="server" Visible="True">
                        <div class="jumbotron jumbotron-fluid">
                            <div class="container">
                                <h1 class="display-4">You have no announcements.</h1>
                            </div>
                        </div>
                    </asp:Panel>
                <!--//If repeater is empty-->
            </div>
            <% if (currentAccountType == "lecturer")
                {%>
            <div id="tabs-4">
                <p>
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
                                            <button data-toggle="modal" data-target="#centralModalLGInfoDemo<%# Eval("withdrawTripRequestID") %>" type="button" class="btn btn-warning btn-sm mt-2">
                                                View Withdrawal Request
                                            </button>

                                        </small>
                                    </div>
                                    <div class="d-flex w-100 justify-content-between">
                                        <p class="mb-1">
                                            <!--<asp:Label ID="Label3" runat="server" Text='<%# Eval("withdrawalReason") %>'></asp:Label>-->
                                            Requested by:
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("adminNo") %>'></asp:Label>
                                        </p>
                                        <small>
                                            <!--(Convert.ToDateTime(Eval("soDateTo"))).ToShortDateString()-->
                                            Posted on:
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                                        </small>
                                    </div>
                                </div>
                            </div>
                            <!-- Central Modal Large Info-->
                            <div class="modal fade" id="centralModalLGInfoDemo<%# Eval("withdrawTripRequestID") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-notify modal-warning modal-top" role="document">
                                    <!--Content-->
                                    <div class="modal-content">
                                        <!--Header-->
                                        <div class="modal-header">
                                            <p class="heading lead text-white">
                                                <asp:Label ID="Label6" runat="server" Text='Withdrawal Request'></asp:Label>
                                            </p>

                                            <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true" class="white-text">&times;</span>
                                            </button>
                                        </div>

                                        <!--Body-->
                                        <div class="modal-body">
                                            <div class="text-center">
                                                <i class="fas fa-file-alt fa-4x mb-3 animated rotateIn" style="color: #FF941A"></i>
                                                <p>
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <table style="border: 0;" class="text-left table borderless" style="border: none; background-color: rgba(210,130,240, 0.3) !important;">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Reasons:
                                                                    </div>
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("withdrawalReason") %>'></asp:Label>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </p>
                                            </div>
                                        </div>

                                        <!--Footer-->
                                        <div class="modal-footer">
                                            <asp:Button ID="btnApproved" runat="server" Text="Approve" class="btn btn-success btn-sm" OnClick="btnApproved_Click" CommandName="trips_Click" CommandArgument='<%# Eval("withdrawTripRequestID") %>' OnCommand="btnApproved_Command" />
                                            <asp:Button ID="btnRejected" runat="server" Text="Reject" class="btn btn-danger btn-sm" OnClick="btnRejected_Click" CommandName="trips_Click" CommandArgument='<%# Eval("withdrawTripRequestID") %>' OnCommand="btnRejected_Command" />
                                            <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary-modal waves-effect btn-sm" data-dismiss="modal" Text="Close" />
                                        </div>
                                    </div>
                                    <!--/.Content-->
                                </div>
                            </div>
                            <!-- Central Modal Large Info-->
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
                </p>
            </div>
            <% }%>
        </div>
        <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>


    </p>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <style>
        .HiddenText label {
            display: none;
        }
    </style>

    <!--//Page Content-->
</asp:Content>
