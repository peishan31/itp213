<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="StudentWithdrawalRequest.aspx.cs" Inherits="ITP213.StudentWithdrawalRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--************README: Hi, please change some of the following things below when you're coding your features. Thanks! -PS -->

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Withdrawal Request</li> <!--1. Change the name!-->
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
    <h1>Withdrawal Request</h1> <!--2. Change the title!-->
    <hr/>
    <p> <!--3. This is where you code all your features-->

        This is a paragraph
    </p>
    <!--//Page Content-->
</asp:Content>
