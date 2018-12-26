<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewAllocatedTrip.aspx.cs" Inherits="ITP213.ViewAllocatedTrip"   MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <li class="breadcrumb-item active">Assignments</li>
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
    <h1>Assignments</h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <script>
            $(function () {
                $("#tabs").tabs();
            });
        </script>
        <asp:Panel ID="panelAlert" runat="server" Visible="False">
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                Yay! You have successfully added a group.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">Study Trips</a></li>
                <li><a href="#tabs-2">Immersion Trips</a></li>
                <li><a href="#tabs-3">Internships</a></li>
            </ul>
            <!--
                <a href="#" class="list-group-item list-group-item-action flex-column align-items-start active">
                    <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1">List group item heading</h5>
                        <small>3 days ago</small>
                    </div>
                    <p class="mb-1">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>
                    <small>Donec id elit non mi porta.</small>
                </a>
                -->
            
            <div id="tabs-1">
                <asp:Repeater ID="RepeaterStudyTrips" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-12 col-sm-12">
                                <div class="list-group">
                                    <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                        <div class="d-flex w-100 justify-content-between">
                                            <h5 class="mb-1">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' Text='<%#Eval("tripName") %>'>
                                                </asp:LinkButton>
                                            </h5>
                                            <small>
                                                <!--(Convert.ToDateTime(Eval("soDateTo"))).ToShortDateString()-->
                                                <% if (Session["accountType"].ToString() == "parent" || Session["accountType"].ToString() == "student"){%>
                                               <asp:Button ID="btnStudyTripsWithdraw" runat="server" Text="Withdraw" Class="btn btn-warning"  CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' OnClick="btnStudyTripsWithdraw_Click" OnCommand="btnStudyTrips_Command"/>
                                                <% } else{ %>
                                                    <asp:Button ID="btnCreateTest" runat="server" Class="btn btn-success" Text="Create Test" OnCommand="CreateTest_Command"   CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                    <asp:Button ID="btnStudyTripsEdit" runat="server" Class="btn btn-warning" Text="Edit Trip" OnCommand="EditTrip_Command"   CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                    <asp:Button ID="btnStudyTripsDelete" runat="server" Class="btn btn-danger" Text="Delete"  OnCommand="delete_Command"  CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                <% } %>
                                            </small>
                                            
                                        </div>
                                        <!--<p class="mb-1">
                                            
                                        </p>-->
                                        <small>
                                             From
                                            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("departureDate")).ToShortDateString() %>'></asp:Label>
                                            to
                                            <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToDateTime(Eval("arrivalDate")).ToShortDateString() %>'></asp:Label>
                                        </small>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!--If repeater is empty-->
                <asp:Panel ID="PanelStudyTrips" runat="server" Visible="False">
                    <div class="jumbotron jumbotron-fluid">
                        <div class="container">
                            <h1 class="display-4">You are currently not enrolled in any Study Trip programme.</h1>
                            <p class="lead">Keep a look out for future overseas programme!</p>
                        </div>
                    </div>
                </asp:Panel>
                <!--//If repeater is empty-->
            </div>
            <div id="tabs-2">
                <asp:Repeater ID="RepeaterImmersionTrips" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <!--
                            <div class="row">
                            <div class="col-6 col-sm-6">
                                <div class="list-group">
                                    <div href="#" class="list-group-item list-group-item-action flex-column align-items-start">
                                        <div class="d-flex w-100 justify-content-between">
                                            <h5 class="mb-1">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' Text='<%#Eval("tripName") %>'>
                                                </asp:LinkButton>
                                            </h5>
                                            <small>3 days ago</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            -->
                        <div class="row">
                            <div class="col-12 col-sm-12">
                                <div class="list-group">
                                    <div class="list-group-item list-group-item-action flex-column align-items-start">
                                        <div class="d-flex w-100 justify-content-between">
                                            <h5 class="mb-1">
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' Text='<%#Eval("tripName") %>'>
                                                </asp:LinkButton>
                                            </h5>
                                            <small>
                                                 <% if (Session["accountType"].ToString() == "parent" || Session["accountType"].ToString() == "student") {%>
                                                    <asp:Button ID="btnImmersionTripsWithdraw" runat="server" Text="Withdraw" Class="btn btn-warning"  CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' OnClick="btnStudyTripsWithdraw_Click" OnCommand="btnStudyTrips_Command"/>
                                                <% }else{ %>
                                                    <asp:Button ID="btnCreateTest" runat="server" Class="btn btn-success" Text="Create Test" OnCommand="CreateTest_Command"   CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                    <asp:Button ID="btnImmersionTripsEdit" runat="server" Class="btn btn-warning" Text="Edit Trip" OnCommand="EditTrip_Command"   CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                    <asp:Button ID="btnImmersionTripsDelete" runat="server" Class="btn btn-danger" Text="Delete" OnCommand="delete_Command"  CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>'/>
                                                <% } %>
                                            </small>
                                        </div>
                                        <small>
                                             From
                                            <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(Eval("departureDate")).ToShortDateString() %>'></asp:Label>
                                            to
                                            <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToDateTime(Eval("arrivalDate")).ToShortDateString() %>'></asp:Label>
                                        </small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!--If repeater is empty-->
                <asp:Panel ID="PanelImmersionTrips" runat="server" Visible="False">
                    <div class="jumbotron jumbotron-fluid">
                        <div class="container">
                            <h1 class="display-4">You are currently not enrolled in any Immersion Trip programme.</h1>
                            <p class="lead">Keep a look out for future overseas programme!</p>
                        </div>
                    </div>
                </asp:Panel>
                <!--//If repeater is empty-->
            </div>
            <div id="tabs-3">
                <p>Mauris eleifend est et turpis. Duis id erat. Suspendisse potenti. Aliquam vulputate, pede vel vehicula accumsan, mi neque rutrum erat, eu congue orci lorem eget lorem. Vestibulum non ante. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce sodales. Quisque eu urna vel enim commodo pellentesque. Praesent eu risus hendrerit ligula tempus pretium. Curabitur lorem enim, pretium nec, feugiat nec, luctus a, lacus.</p>
                <p>Duis cursus. Maecenas ligula eros, blandit nec, pharetra at, semper at, magna. Nullam ac lacus. Nulla facilisi. Praesent viverra justo vitae neque. Praesent blandit adipiscing velit. Suspendisse potenti. Donec mattis, pede vel pharetra blandit, magna ligula faucibus eros, id euismod lacus dolor eget odio. Nam scelerisque. Donec non libero sed nulla mattis commodo. Ut sagittis. Donec nisi lectus, feugiat porttitor, tempor ac, tempor vitae, pede. Aenean vehicula velit eu tellus interdum rutrum. Maecenas commodo. Pellentesque nec elit. Fusce in lacus. Vivamus a libero vitae lectus hendrerit hendrerit.</p>
            </div>
        </div>
        
        <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>
        
        
    </p>
    <!--//Page Content-->
</asp:Content>
