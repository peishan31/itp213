<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewIndividualAnnouncement.aspx.cs" Inherits="ITP213.ViewIndividualAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--************README: Hi, please change some of the following things below when you're coding your features. Thanks! -PS -->

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">
            <a href="/Default.aspx" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="/ViewAnnouncement.aspx" style="color:#D6D6D6">View Announcements</a>
        </li>
        <li class="breadcrumb-item active">View Individual Announcement</li> <!--1. Change the name!-->
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
    <h1><asp:Label ID="lblAnnouncementTitle" runat="server" Text="Label"></asp:Label></h1> <!--2. Change the title!-->
    <hr/>
    <p> <!--3. This is where you code all your features-->
        <p><asp:Label ID="lblAnnouncementMessage" runat="server" Text="Label"></asp:Label> <br /></p>
            
        <asp:button runat="server" class="btn btn-danger" text="Delete" id="btnDelete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnUpdate" class="btn btn-warning" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </p>
    <!--//Page Content-->
</asp:Content>
