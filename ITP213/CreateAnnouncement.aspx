<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CreateAnnouncement.aspx.cs" Inherits="ITP213.CreateAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active"><asp:Label ID="lblTitle" runat="server" Text="Create an announcement"></asp:Label></li> <!--1. Change the name!-->
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
    <h1><asp:Label ID="lblTitle2" runat="server" Text="Create an announcement"></asp:Label></h1> <!--2. Change the title!-->
    <hr/>
    <!--//Page Content-->
    <br />
        <div class="form-group">
            Group:
                <asp:DropDownList ID="ddlGroup" runat="server" class="form-control">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>2018 - Thailand Trip</asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="form-group">
            Title:<asp:TextBox ID="tbTitle" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            Message:<asp:TextBox ID="tbMessage" runat="server" rows="8" columns="30" TextMode="MultiLine" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            Who can view this announcement in this group:<br />
            <asp:CheckBox ID="cbLecturers" runat="server" Text="Travelling lecturers" class="form-check-label"/>
            <br />
            <asp:CheckBox ID="cbStudents" runat="server" Text="Students" class="form-check-label"/>
            <br />
        </div>
        <center><asp:Button ID="btnCreate" runat="server" class="btn btn-success" Text="Create" OnClick="btnCreate_Click" /></center>
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Black"></asp:Label>
    
    
    
    
    
</asp:Content>
