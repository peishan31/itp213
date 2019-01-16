<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewStatistics.aspx.cs" Inherits="ITP213.ViewStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Overseas Internships</li>
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
    <h1>View Statistics</h1>
    <hr/>
    <div class="container mt-5 mb-4">
        <asp:Button ID="btnTest" runat="server" Text="Button Test" />
        <div class="card pl-3 pr-3">
            <div class="pb-5 text-center m-md-3">
                <asp:Literal ID="testChart" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <!--//Page Content-->
</asp:Content>
