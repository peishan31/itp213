<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITP213.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--************README: Hi, please change some of the following things below when you're coding your features. Thanks! -PS -->

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item active" style="color:#031A82; cursor:pointer;">
            Home
        </li>
    </ol>
    <style>
        .breadcrumb
        {
        background-color: #FFFFFF !important;
            
        }
    </style>
    <!-- //Breadcrumbs end-->

    <!-- Page Content -->
    <h1><asp:Label ID="lblTitle" runat="server" Text="Home"></asp:Label></h1> <!--2. Change the title!-->
    <hr/>
    <p> <!--3. This is where you code all your features-->

        This is a paragraph
    </p>
    <!--//Page Content-->
</asp:Content>
