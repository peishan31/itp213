﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewInjuryReport.aspx.cs" Inherits="ITP213.ViewInjuryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel='stylesheet' href='Content/mdb.min.css' />
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="#" style="color: #D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">View Injury Report</li>
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
    <h1>View Injury Report</h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->
        <asp:Panel ID="PanelViewInjury" runat="server">
            <div class="jumbotron jumbotron-fluid">
                <div class="container">
                    <h1 class="display-4">No injury reports yet!</h1>
                    <p class="lead">Keep a look out for future injury reports!</p>
                </div>
            </div>
        </asp:Panel>
        <asp:Repeater ID="RepeaterViewInjury" runat="server" OnItemDataBound="RepeaterViewInjury_ItemDataBound">
            <ItemTemplate>
                <div class="row">
                    <div class="col-12 col-sm-12">
                        <div class="list-group">
                            <div class="list-group-item list-group-item-action flex-column align-items-start">
                                <small>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("tripName")+ " ("+Eval("tripType")+")" %>'></asp:Label>
                                </small>
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-1 mt-2">
                                        <a data-toggle="modal" data-target="#centralModalLGInfoDemo<%# Eval("injuryReportID") %>">
                                            <asp:Label ID="Label19" runat="server" Text='<%# "Injury Report: " + Eval("studentName") %>'></asp:Label>
                                        </a>
                                        <!--<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("injuryReportID") %>' Text='<%# "Injury Report: " + Eval("studentName") %>' data-toggle="modal" data-target="#centralModalLGInfoDemo">
                                        </asp:LinkButton>-->
                                    </h5>
                                    <small class="pb-1 mb-1">
                                        <a data-toggle="modal" data-target="#centralModalLGInfoDemo<%# Eval("injuryReportID") %>" class="btn btn-success btn-sm mx-auto">
                                            View Report
                                        </a>
                                        <asp:Button ID="btnStudyTripsEdit" runat="server" Class="btn btn-warning btn-sm mx-auto" Text="Edit Trip" CommandName="trips_Click" CommandArgument='<%# Eval("injuryReportID") %>' OnCommand="btnEdit_Command" style="z-index: 1;"/>
                                        <asp:Button ID="btnStudyTripsDelete" runat="server" Class="btn btn-danger btn-sm mx-auto" Text="Delete" CommandName="trips_Click" CommandArgument='<%# Eval("injuryReportID") %>' OnCommand="btnDelete_command" style="z-index: 1"/>
                                    </small>
                                </div>
                                <p class="mb-1" style="font-size: 0.8em">
                                </p>
                                <small>By:
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                                    (<asp:Label ID="Label20" runat="server" Text='<%# Eval("staffID") %>'></asp:Label>)
                                </small>
                                <small class="float-right">Posted on:
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("createdOn") %>'></asp:Label>
                                </small>

                            </div>
                            <!-- Central Modal Large Info-->
                            <div class="modal fade" id="centralModalLGInfoDemo<%# Eval("injuryReportID") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-notify modal-info modal-top" role="document">
                                    <!--Content-->
                                    <div class="modal-content">
                                        <!--Header-->
                                        <div class="modal-header">
                                            <p class="heading lead text-white">
                                                <asp:Label ID="Label6" runat="server" Text='<%# "Injury Report: " + Eval("studentName") %>'></asp:Label>
                                            </p>

                                            <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true" class="white-text">&times;</span>
                                            </button>
                                        </div>

                                        <!--Body-->
                                        <div class="modal-body">
                                            <div class="text-center">
                                                <i class="fas fa-user-injured fa-4x mb-3 animated rotateIn" style="color: #5394FF"></i>
                                                <!--<i class="fas fa-file fa-4x mb-3 animated rotateIn" style="color: #5394FF"></i>-->
                                                <!--<i class="fa fa-check fa-4x mb-3 animated rotateIn"></i>-->
                                                <p>
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <legend>Details of injured person:</legend>
                                                        <table style="border: 0;" class="text-left">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Trip:
                                                                    </div>
                                                                    <asp:Label ID="lblTrip" runat="server" Text='<%# Eval("tripName")+ " ("+Eval("tripType")+")" %>'></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Name: 
                                                                    </div>
                                                                    <asp:Label ID="lblStudentName" runat="server" Text='<%# Eval("studentName") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    <hr />
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <legend>Details of incident</legend>
                                                        <table style="border: 0;" class="text-left">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Date and time of injury: 
                                                                    </div>
                                                                    <asp:Label ID="lblDateTimeInjury" runat="server" Text='<%# Eval("datetimeOfInjury") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Location: 
                                                                    </div>
                                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Description: 
                                                                    </div>
                                                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    <hr />
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <legend>Details of witness:</legend>
                                                        <table style="border: 0;" class="text-left">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Witness name:
                                                                    </div>
                                                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("witnessName") %>'></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Witness phone: 
                                                                    </div>
                                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("witnessPhone") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    <hr />
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <legend>Details of injury:</legend>
                                                        <table style="border: 0;" class="text-left">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Nature of injury(eg burn, cut, sprain): 
                                                                    </div>
                                                                    <asp:Label ID="lblNatureOfInjury" runat="server" Text='<%# Eval("natureOfInjury") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Cause of injury(eg fall, grabbed by person): 
                                                                    </div>
                                                                    <asp:Label ID="lblCauseOfInjury" runat="server" Text='<%# Eval("causeOfInjury") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Location on body(eg back, left forearm): 
                                                                    </div>
                                                                    <asp:Label ID="lblLocationOnBody" runat="server" Text='<%# Eval("locationOnBody") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Agency(eg lounge char, another person, hot water): 
                                                                    </div>
                                                                    <asp:Label ID="lblAgency" runat="server" Text='<%# Eval("agency") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    <hr />
                                                    <fieldset visible="true" style="width: auto !important; margin-bottom: 0px !important; font-size: 12px; font-weight: bold;" class="text-left">
                                                        <legend>Treatment Administered:</legend>
                                                        <table style="border: 0;" class="text-left">
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        First Aid given: 
                                                                    </div>
                                                                    <asp:Label ID="lblFirstAidGiven" runat="server" Text='<%# Eval("firstAidGiven") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        First Aider name: 
                                                                    </div>
                                                                    <asp:Label ID="lblFirstAiderName" runat="server" Text='<%# Eval("firstAiderName") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="font-size: 15px; font-weight: bold;">
                                                                        Treatment: 
                                                                    </div>
                                                                    <asp:Label ID="lblTreatment" runat="server" Text='<%# Eval("treatment") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </p>
                                            </div>
                                        </div>

                                        <!--Footer-->
                                        <div class="modal-footer">
                                            <asp:Button ID="btnSendReportViaSMS" runat="server" Class="btn btn-primary-modal" Text="Inform Parent" OnClick="btnSendReportViaSMS_Click"  CommandName="informParent" OnCommand="btnSendReport_command" CommandArgument='<%# Eval("injuryReportID") %>'/>
                                            <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary-modal waves-effect" data-dismiss="modal" Text="Close" />
                                        </div>
                                    </div>
                                    <!--/.Content-->
                                </div>
                            </div>
                            <!-- Central Modal Large Info-->
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblTesting" runat="server" Text="Label"></asp:Label>
        
        
    </p>

    <!--//Page Content-->
</asp:Content>
