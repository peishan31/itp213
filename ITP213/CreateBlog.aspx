<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CreateBlog.aspx.cs" Inherits="ITP213.CreateBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--************README: Hi, please change some of the following things below when you're coding your features. Thanks! -PS -->

    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="/Default.aspx" style="color: #D6D6D6">Home</a>
        </li>

        <li class="breadcrumb-item active">New Post</li>
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
    <h1>New Post</h1>
    <!--2. Change the title!-->
    <hr />
    <table>
        <tr>
            <td>Title: </td>
            <td>
                <asp:TextBox ID="txtBoxTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter title" ControlToValidate="txtBoxTitle" ForeColor="#996600"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Trip Name:</td>
            <td>
                <asp:DropDownList ID="ddlTripName" runat="server">
                    <asp:ListItem Value="0">Select Trip</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlTripName" ErrorMessage="Select a trip" ForeColor="#CC3300" InitialValue="0"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:TextBox ID="txtBoxContent" runat="server" Rows="8" Columns="10" TextMode="MultiLine" class="form-control" Height="186px" Width="1002px" Style="resize: none"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter information" ControlToValidate="txtBoxContent" ForeColor="#CC3300"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Publish" OnClick="btnPublish_Click" class="btn btn-success"/></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#996600" />
            </td>
        </tr>
    </table>
</asp:Content>
