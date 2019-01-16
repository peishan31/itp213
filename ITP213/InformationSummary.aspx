<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="InformationSummary.aspx.cs" Inherits="ITP213.InformationSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Information Summary</li> <!--1. Change the name!-->
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
    <!-- Page Content -->
    <h1>Information Summary</h1> <!--2. Change the title!-->
    <hr/>
    <h5>Please choose a summary&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownListSummary" runat="server" InitialValue="0" CssClass="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="DropDownListSummary_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>-- Select --</asp:ListItem>
        <asp:ListItem Value="Acad">Academic</asp:ListItem>
        <asp:ListItem Value="Diet">Dietary Needs</asp:ListItem>
    </asp:DropDownList>
    </h5>
    <asp:Panel ID="PanelAcademicSummary" Visible="false" runat="server">
        <h4 style="text-align: center">Academic Results Summary</h4>
        <br />
        <div class="row">
            <div class="container col-md-8">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Admin Number" DataField="adminNo" />
                        <asp:BoundField HeaderText="Cumulative GPA" DataField="cumulativeGPA" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelDietSummary" Visible="false" runat="server">
        <h4 style="text-align: center">Dietary Needs Summary</h4>
        <br />
        <div class="row">
            <div class="container col-md-8">
                <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Admin Number" DataField="adminNo" />
                        <asp:BoundField HeaderText="Student Name" DataField="studentName" />
                        <asp:BoundField DataField="dietaryNeeds" HeaderText="Dietary Needs" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
    <!--//Page Content-->
</asp:Content>
