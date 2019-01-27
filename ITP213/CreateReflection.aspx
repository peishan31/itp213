<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CreateReflection.aspx.cs" Inherits="ITP213.CreateReflection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Create Reflection</li>
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
    <h1>Create Reflection</h1>
    <hr/>
    
    <div class="container mt-5 mb-4">
        <div class="card pl-3 pr-3">
            <div class="pb-5 text-left m-md-3">
            <table>
                <tr>
                    <td>Please enter your reflection for the week below</td>
                </tr>
                <tr>
                    <td>
                        Trip Name: <!--Displaying trips tht are internship, and are ongoing-->
                        <asp:DropDownList ID="ddlTripName" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbReflection" runat="server" Rows="9" Columns="12" TextMode="MultiLine" class="form-control" Height="200px" Width="1050px" style="resize:none"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmitReflecction" runat="server" Text="Submit Reflection" OnClick="btnSubmitReflecction_Click" class="btn btn-success"/>
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </div>
    <!--//Page Content-->
</asp:Content>