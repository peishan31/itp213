<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewIndividualTrip.aspx.cs" Inherits="ITP213.ViewIndividualTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color: #D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item">

            <a href="/ViewAllocatedTrip.aspx" style="color: #D6D6D6">Assignments</a>
        </li>
        <li class="breadcrumb-item active">
            <asp:Label ID="lblTripName2" runat="server" Text="Trip Name"></asp:Label></h1></li>
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
        <asp:Label ID="lblTripName" runat="server" Text="Trip Name"></asp:Label></h1>
    <!--2. Change the title!-->
    <hr />
    <p>
        <!--3. This is where you code all your features-->

        <div id="content-wrapper">

            <div class="container-fluid">
                <!-- Icon Cards-->
                <div class="row">
                    <div class="col-xl-6 col-sm-12 mb-3">
                        <div class="card text-white bg-primary o-hidden h-100" style="background-color: #5394FF !important">
                            <div class="card-body">
                                <div class="card-body-icon">
                                    <!--<i class="fas fa-bell"></i>-->
                                </div>
                                <div class="mr-5">26 Unread Announcements!</div>
                            </div>
                            <a class="card-footer text-white clearfix small z-1" href="/ViewAnnouncement.aspx">
                                <span class="float-left">View Details</span>
                                <span class="float-right">
                                    <i class="fas fa-angle-right"></i>
                                </span>
                            </a>
                        </div>
                    </div>
                    <div class="col-xl-6 col-sm-12 mb-3">
                        <div class="card text-white bg-warning o-hidden h-100" style="background-color: #FF8800 !important">
                            <div class="card-body">
                                <div class="card-body-icon">
                                    <!--<i class="fas fa-scroll"></i>-->
                                </div>
                                <div class="mr-5">10 Tests!</div>
                            </div>
                            <a class="card-footer text-white clearfix small z-1" href="#">
                                <span class="float-left">View Details</span>
                                <span class="float-right">
                                    <i class="fas fa-angle-right"></i>
                                </span>
                            </a>
                        </div>
                    </div>
                </div>
                <!-- Area Chart Example-->
                <asp:Repeater ID="RepeaterIndividualTrip" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-lg-8">
                                <div class="card mb-3">
                                    <div class="card-header">
                                        <i class="fas fa-plane"></i>
                                        Trip Details
                                    </div>
                                    <div class="card-body">
                                        <!--<canvas id="myBarChart" width="100%" height="50"></canvas>-->
                                        <b><ins><asp:Label ID="Label3" runat="server" Text='<%# Eval("tripName").ToString()%>'></asp:Label></ins></b> <br />
                                        <b>Trip Status:</b>
                                        <asp:Label ID="lblOverseasTripStatus" runat="server" Text='<%# Eval("overseasTripStatus").ToString()%>'></asp:Label>
                                        <br />
                                        <b>Trip Date:</b>
                                        From <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("departureDate")).ToShortDateString()%>'></asp:Label> to <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToDateTime(Eval("arrivalDate")).ToShortDateString()%>'></asp:Label>
                                        <br />
                                        <b>Country:</b>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("country").ToString() %>'></asp:Label>
                                        <br />
                                        <b>No of Students:</b>
                                        <asp:Label ID="lblNoOfStudents" runat="server" Text='<%# Eval("noOfStudents").ToString() %>'></asp:Label>
                                        <br />
                                        <b>No of Lecturers:</b>
                                        <asp:Label ID="lblNoOfLecturers" runat="server" Text='<%# Eval("noOfLecturers").ToString() %>'></asp:Label>
                                        <br />
                                    </div>
                                    <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <div class="col-lg-4">
                    <div class="card mb-3">
                        <div class="card-header">
                            <i class="fas fa-users"></i>
                            People in this trip:
                        </div>
                        <div class="card-body">
                            <!--<canvas id="myPieChart" width="100%" height="50"></canvas>-->
                            <b>Lecturer: </b><br />
                            <asp:Repeater ID="RepeaterStaffName" runat="server">
                                <ItemTemplate>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblStaffName" runat="server" Text='<%# "- " + Eval("name").ToString() %>'></asp:Label> <br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <b>Student: </b><br />
                            <asp:Repeater ID="RepeaterStudentName" runat="server">
                                <ItemTemplate>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblStudentName" runat="server" Text='<%# "- " + Eval("name").ToString() %>'></asp:Label> <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <!--//3-->
    </p>
    <!--//Page Content-->

</asp:Content>
