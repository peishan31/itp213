﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="StudentWithdrawalResult.aspx.cs" Inherits="ITP213.StudentWithdrawalResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet' href='Content/mdb.min.css' />    
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color: #D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Withdrawal Result</li>
        <!--1. Change the name!-->
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
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Withdrawal Result"></asp:Label>
    </h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <div class="container">
            <div class="row">
                <table id="example" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <th>
                            <!--<input type="checkbox" onclick="checkAll(this)">-->
                            <center>Read</center>
                        </th>
                        <th>Status</th>
                        <th>Trip Name</th>
                        <th>Created On</th>
                        <th>Reason</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:Repeater ID="RepeaterStudyTrips" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <center>
                                            <input type="checkbox" name="">
                                        </center>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("withdrawalTripRequestStatus") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("tripNameAndTripType") %>'
                                            data-toggle="tooltip" data-html="true" data-placement="right" title='<%#"From "+Convert.ToDateTime(Eval("departureDate")).ToShortDateString()+" to "+ Convert.ToDateTime(Eval("arrivalDate")).ToShortDateString()%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <button data-toggle="modal" data-target="#centralModalLGInfoDemo<%# Eval("withdrawTripRequestID") %>" type="button" class="btn btn-warning btn-sm mt-2">
                                             View Withdrawal Request
                                        </button>
                                        <!-- Central Modal Large Info-->
                                        <div class="modal fade" id="centralModalLGInfoDemo<%# Eval("withdrawTripRequestID") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-notify modal-warning modal-top" role="document">
                                                <!--Content-->
                                                <div class="modal-content">
                                                    <!--Header-->
                                                    <div class="modal-header">
                                                        <p class="heading lead text-white">
                                                            <asp:Label ID="Label6" runat="server" Text='Withdrawal Request'></asp:Label>
                                                        </p>

                                                        <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true" class="white-text">&times;</span>
                                                        </button>
                                                    </div>

                                                    <!--Body-->
                                                    <div class="modal-body">
                                                        <div class="text-center">
                                                            <i class="fas fa-file-alt fa-4x mb-3 animated rotateIn" style="color: #FF941A"></i>
                                                            <p>
                                                                <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                                    <table style="border: 0;" class="text-left table borderless" style="border: none; background-color: rgba(210,130,240, 0.3) !important;">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="font-size: 15px; font-weight: bold;">
                                                                                    Reasons:
                                                                                </div>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("withdrawalReason") %>'></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                            </p>
                                                        </div>
                                                    </div>

                                                    <!--Footer-->
                                                    <div class="modal-footer">
                                                        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary-modal waves-effect" data-dismiss="modal" Text="Close" />
                                                    </div>
                                                </div>
                                                <!--/.Content-->
                                            </div>
                                        </div>
                                        <!-- Central Modal Large Info-->
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

    </p>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <!--//Page Content-->
</asp:Content>
