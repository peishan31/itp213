<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewAnnouncement.aspx.cs" Inherits="ITP213.ViewAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .tabs {
        position:relative;
        top: 1px;
        left: 10px;
    }
    .tab {
        border:solid 1px black;
        background-color:#F5F6FA;
        padding:5px 10px;
    }
    .selectedTab {
        background-color:white;
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

            <a href="/Default.aspx" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">View all announcements</li> <!--1. Change the name!-->
    </ol>
    <style>
        .breadcrumb
        {
        background-color: #FFFFFF !important;
            
        }
        .breadcrumb > .breadcrumb-item
        {
        color: #031A82 !important;
        }
        .breadcrumb .breadcrumb-item+.breadcrumb-item::before{
            color: #D6D6D6;
        }
    </style>
    <!-- //Breadcrumbs end-->

    <!-- Page Content -->
    <h1>View all announcements</h1> <!--2. Change the title!-->
    <hr/>
    <p> <!--3. This is where you code all your features-->
    <asp:Menu ID="Menu1" runat="server" CssClass="tabs" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick">
            <StaticMenuItemStyle CssClass="tab" Font-Size="Large" />
            <StaticMenuStyle BackColor="White" />
            <StaticSelectedStyle CssClass="selectedTab" />
        <Items>
            <asp:MenuItem Text="Study Trips" Value="0" Selected="true"></asp:MenuItem>
            <asp:MenuItem Text="Immersion Trips" Value="1"></asp:MenuItem>
            <asp:MenuItem Text="Internships" Value="2"></asp:MenuItem>
        </Items>
    </asp:Menu>

    <div class="tabContents">
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <br /> 
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="View Announcement" Text="View Announcement" />
                    </Columns>
                </asp:GridView>
                <!--<asp:Panel ID="PanelStudyTrip" runat="server">
                    <div class="card">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Label ID="lblAnnouncementTitle" runat="server" Text="Label"></asp:Label><br />
                                - <asp:Label ID="lblAnnouncementMessage" runat="server" Text="Label"></asp:Label> <br />
                            </li>
                        </ul>
                    </div>
                </asp:Panel>-->
            </asp:View>
            <asp:View ID="View2" runat="server">
                <br /> This is Second Tab
            </asp:View>
            <asp:View ID="View3" runat="server">
                <br /> This is third tab
            </asp:View>
        </asp:MultiView>
    </div>
    </p>
    <!--//Page Content-->
</asp:Content>
