<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewAllocatedTrip.aspx.cs" Inherits="ITP213.ViewAllocatedTrip" %>

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
        <li class="breadcrumb-item active">View Trips</li>
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
    <h1>View Trips</h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <asp:Panel ID="panelAlert" runat="server" Visible="False">
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                Yay! You have successfully added a group.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
        <asp:Menu ID="Menu1" runat="server" CssClass="tabs" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick">
            <StaticMenuItemStyle CssClass="tab" Font-Size="Large" />
            <StaticMenuStyle BackColor="White" />
            <StaticSelectedStyle CssClass="selectedTab" />
            <Items>
                <asp:MenuItem Text="Study Trips" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Immersion Trips" Value="1"></asp:MenuItem>
            </Items>
        </asp:Menu>

        <div class="tabContents">
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View1" runat="server">
                    <br />
                    <asp:Repeater ID="RepeaterStudyTrips" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <div>
                                <div class="list-group">
                                    <div class="list-group-item">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' Text='<%#Eval("tripName") %>'>
                                        </asp:LinkButton>
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
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />
                    <asp:Repeater ID="RepeaterImmersionTrips" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <div>
                                <div class="list-group">
                                    <div class="list-group-item">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="trips_Click" CommandArgument='<%# Eval("tripID") %>' Text='<%#Eval("tripName") %>'>
                                        </asp:LinkButton>
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
                </asp:View>
            </asp:MultiView>
        </div>
    <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>
    </p>
    <!--//Page Content-->
</asp:Content>
