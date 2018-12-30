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
        
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">Study Trips</a></li>
                <li><a href="#tabs-2">Immersion Trips</a></li>
                <li><a href="#tabs-3">Internships</a></li>
            </ul>
            <div id="tabs-1">
                <p>
                    <asp:Repeater ID="RepeaterStudyTrips" runat="server" OnItemCommand="RepeaterStudyTrips_ItemCommand">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-12 col-sm-12">
                                    <div class="list-group">
                                        <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                            <small>Trip Name:
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName") %>'></asp:Label></small>
                                            <div class="d-flex w-100 justify-content-between">
                                                <h5 class="mb-1">

                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                        Text='<%#Eval("announcementTitle") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                                        title='<%#"Stop showing on "+Eval("timeDue") %>'>
                                                    </asp:LinkButton>
                                                </h5>
                                                <small>
                                                    <!--(Convert.ToDateTime(Eval("soDateTo"))).ToShortDateString()-->
                                                    <% if (Session["accountType"].ToString() == "lecturer")
                                                        {%>
                                                    <%# (Eval("staffID").ToString() == Session["staffID"].ToString())?
                                                            Session["identity"]=true:
                                                            Session["identity"]=false
                                                    %>
                                                    <% if (Convert.ToBoolean(Session["identity"]) == true)
                                                        {%>
                                                    <asp:Button ID="btnStudyTripsEdit" runat="server" Class="btn btn-warning btn-sm" Text="Edit Announcement" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnEditTrip_Command" />
                                                    <asp:Button ID="btnStudyTripsDelete" runat="server" Class="btn btn-danger btn-sm" Text="Delete" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnStudyTrips_Command" />
                                                    <%} %>
                                                    <% } %>
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
                    <center>
                        <button type="button" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#PastStudyTrip">
                            View Past Announcements
                        </button>
                    </center>
                    <!--Central Modal Large Warning-->
                    <div class="modal fade" id="PastStudyTrip" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg modal-notify modal-warning" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="heading lead">Past Announcements</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="white-text">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <!-- Display a list of announcements-->
                                    <asp:Repeater ID="RepeaterStudyTripsPastAnnouncement" runat="server" OnItemCommand="RepeaterStudyTrips_ItemCommand">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-12 col-sm-12">
                                                    <div class="list-group">
                                                        <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                                            <small>Trip Name:
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName") %>'></asp:Label></small>
                                                            <div class="d-flex w-100 justify-content-between">
                                                                <h5 class="mb-1">

                                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                                        Text='<%#Eval("announcementTitle") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                                                        title='<%#"Stop showing on "+Eval("timeDue") %>'>
                                                                    </asp:LinkButton>
                                                                </h5>
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
                                    <!--//Display a list of announcements-->
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-outline-secondary-modal waves-effect btn-sm" data-dismiss="modal">
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--//Central Modal Large Warning-->

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
                    <asp:Repeater ID="RepeaterImmersionTrips" runat="server" OnItemCommand="RepeaterImmersionTrips_ItemCommand">
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
                                                    <!--(Convert.ToDateTime(Eval("soDateTo"))).ToShortDateString()-->
                                                    <% if (Session["accountType"].ToString() == "lecturer")
                                                        {%>
                                                    <%# (Eval("staffID").ToString() == Session["staffID"].ToString())?
                                                            Session["identity"]=true:
                                                            Session["identity"]=false
                                                    %>
                                                    <% if (Convert.ToBoolean(Session["identity"]) == true)
                                                        {%>
                                                    <asp:Button ID="btnImmersionTripsEdit" runat="server" Class="btn btn-warning btn-sm" Text="Edit Announcement" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnEditTrip_Command" />
                                                    <asp:Button ID="btnImmersionTripsDelete" runat="server" Class="btn btn-danger btn-sm" Text="Delete" CommandName="trips_Click" CommandArgument='<%# Eval("announcementID") %>' OnCommand="btnStudyTrips_Command" />
                                                    <%} %>

                                                    <% } %>
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
                    <center>
                        <button type="button" class="btn btn-warning btn-sm" data-toggle="modal" data-target="#PastImmersionTrip">
                            View Past Announcements
                        </button>
                    </center>
                    <!--Central Modal Large Warning-->
                    <div class="modal fade" id="PastImmersionTrip" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg modal-notify modal-warning" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="heading lead">Past Announcements</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="white-text">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <!-- Display a list of announcements-->
                                    <asp:Repeater ID="RepeaterImmersionTripsPastAnnouncement" runat="server" OnItemCommand="RepeaterImmersionTrips_ItemCommand">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-12 col-sm-12">
                                                    <div class="list-group">
                                                        <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                                            <small>Trip Name:
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName") %>'></asp:Label></small>
                                                            <div class="d-flex w-100 justify-content-between">
                                                                <h5 class="mb-1">

                                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                                        Text='<%#Eval("announcementTitle") %>' data-toggle="tooltip" data-html="true" data-placement="right"
                                                                        title='<%#"Stop showing on "+Eval("timeDue") %>'>
                                                                    </asp:LinkButton>
                                                                </h5>
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
                                    <!--//Display a list of announcements-->
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-outline-secondary-modal waves-effect btn-sm" data-dismiss="modal">
                                        Close
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--//Central Modal Large Warning-->


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
                <p>Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate, pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem. Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem enim, pretium nec, feugiat nec, luctus a, lacus.</p>
                <p>Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit hendrerit.</p>
            </div>
        </div>
        <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>
    </p>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <!--//Page Content-->
</asp:Content>
