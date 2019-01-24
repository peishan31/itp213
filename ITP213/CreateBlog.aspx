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
    <p>
        <asp:Panel ID="panelError" runat="server" Visible="false">
            <div class="alert alert-danger alert-dismissible fade show" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
        <asp:Panel ID="panelSuccess" runat="server" Visible="false">
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False"></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-6 col-sm-12">
                Title:
            <asp:TextBox ID="txtBoxTitle" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6 col-sm-12">
                Trip Name:
            <asp:DropDownList ID="ddlTripName" runat="server" class="form-control">
            </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                Content:
            <asp:TextBox ID="txtBoxContent" runat="server" Rows="8" Columns="10" TextMode="MultiLine" class="form-control" Height="186px" Width="1002px" Style="resize: none"></asp:TextBox>
            </div>
        </div>
        <!--//Page Content-->
        <br />
        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnPublish" runat="server" Text="Publish" OnClick="btnPublish_Click" class="btn btn-success" />
            </div>
        </div>
        <br />
        
        <br />
    </p>
</asp:Content>
