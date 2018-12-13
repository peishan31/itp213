<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewAllocatedTrip.aspx.cs" Inherits="ITP213.ViewAllocatedTrip" %>
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
        <li class="breadcrumb-item active">Allocated trip</li> <!--1. Change the name!-->
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
    <h1>Allocated trip</h1> <!--2. Change the title!-->
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
                    <ul class="list-group">
                      <li class="list-group-item">2018 - Japan Trip</li>
                      <li class="list-group-item">2019 - Indonesia Trip</li>
                      <li class="list-group-item">2019 - Jakarta Trip</li>
                    </ul>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br /> 
                    <ul class="list-group">
                      <li class="list-group-item">2018 - Japan Trip</li>
                      <li class="list-group-item">2019 - Jakarta Trip</li>
                    </ul>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <br /> 
                    <ul class="list-group">
                      <li class="list-group-item">2019 - Jakarta Trip</li>
                    </ul>
                </asp:View>
            </asp:MultiView>
        </div>
    </p>
    <!--//Page Content-->
</asp:Content>
