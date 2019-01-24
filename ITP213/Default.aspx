<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITP213.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <!--<h1><asp:Label ID="lblTitle" runat="server" Text="Home"></asp:Label></h1>-->
    <hr/>
    <p> <!--3. This is where you code all your features-->
        <div class="jumbotron p-3 p-md-5 text-white rounded bg-dark">
        <div class="col-md-10 px-0">
          <h1 class="display-4 font-italic" style="color:white !important">Overseas Trip Management</h1>
          <p class="lead my-3">We are a group of 4 who are building an application to automate NYP's overseas trip management. This system will be called the Student Overseas Trip Management System (SOTMS). This system will manage different types of overseas programmmes, which are Study Trips, Immersion Programs and internships</p>
        </div>
      </div>
    </p>
    <!--//Page Content-->
</asp:Content>
