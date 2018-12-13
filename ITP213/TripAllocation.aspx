    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="TripAllocation.aspx.cs" Inherits="ITP213.TripAllocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs-->
    <ol class="breadcrumb">

        <li class="breadcrumb-item">

            <a href="/Default.aspx" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Create Trip</li>
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
    <h1>Create Trip</h1> 
    <hr/>
    <div class="form-row">
        <div class="form-group col-md-6">
            <p> Schools:
            <asp:DropDownList ID="ddlSchool" runat="server" class="form-control">
                <asp:ListItem>--Please Select--</asp:ListItem>
                <asp:ListItem Value="SBM">School of Business Management</asp:ListItem>
                <asp:ListItem Value="SCLS">School of Chemical &amp; Life Sciences</asp:ListItem>
                <asp:ListItem Value="SID">School of Design</asp:ListItem>
                <asp:ListItem Value="SEG">School of Engineering</asp:ListItem>
                <asp:ListItem Value="SHSS">School of Health &amp; Social Sciences</asp:ListItem>
                <asp:ListItem Value="SIT">School of Information Technology</asp:ListItem>
                <asp:ListItem Value="SIDM">School of Interactive &amp; Digital Media</asp:ListItem>
            </asp:DropDownList>
            </p>
        </div>
        <div class="form-group col-md-6">
            <p> Courses:<asp:DropDownList ID="ddlCourses" runat="server" class="form-control">
                <asp:ListItem>Common ICT Programme</asp:ListItem>
                <asp:ListItem>Business &amp; Financial Technology</asp:ListItem>
                <asp:ListItem>Business Intelligence &amp; Analytics</asp:ListItem>
                <asp:ListItem>Cybersecurity &amp; Digital Forensics</asp:ListItem>
                <asp:ListItem>Infocomm &amp; Security</asp:ListItem>
                <asp:ListItem>Information Technology</asp:ListItem>
                <asp:ListItem>Business Informatics</asp:ListItem>
                <asp:ListItem>Financial Informatics</asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
    </div>
    <p> Select Students:</p>
    <div class="form-row">
        <div class="form-group col-md-5">
            <asp:ListBox ID="lbStudents" runat="server" class="form-control">
                <asp:ListItem>Lin Peishan</asp:ListItem>
            </asp:ListBox>
            
            
        </div>
        <div class="form-group col-md-1">
            <asp:Button ID="Button1" class="btn btn-light" runat="server" Text="Add" />
        </div>
        <div class="form-group col-md-5">
            <asp:ListBox ID="lbSelectedStudents" runat="server" class="form-control">
                <asp:ListItem>--Please Select--</asp:ListItem>
            </asp:ListBox>
        </div>
    </div>
    <p> Select Lecturers:</p>
    <div class="form-row">
        <div class="form-group col-md-5">
            <asp:ListBox ID="lbLecturers" runat="server" class="form-control" >
                <asp:ListItem>Lecturer 1</asp:ListItem>
            </asp:ListBox>
        </div>
        <div class="form-group col-md-1">
            <asp:Button ID="Button2" class="btn btn-light" runat="server" Text="Add" />
        </div>
        <div class="form-group col-md-5">
            <asp:ListBox ID="lbSelectedLecturers" runat="server" class="form-control">
                <asp:ListItem>--Please Select--</asp:ListItem>
            </asp:ListBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-4">
            <p> Trip Name:<asp:TextBox ID="tbTripName" runat="server" class="form-control" ></asp:TextBox></p>
        </div>
        <div class="form-group col-md-4">
            <p> Trip Type:<asp:DropDownList ID="ddlTripType" runat="server" class="form-control">
                <asp:ListItem>--Please Select--</asp:ListItem>
                <asp:ListItem>Immersion Trip</asp:ListItem>
                <asp:ListItem>Internship</asp:ListItem>
                <asp:ListItem>Study Trip</asp:ListItem>
            </asp:DropDownList>
            </p>
        </div>
        <div class="form-group col-md-4">
            <p> Country:
                <asp:DropDownList ID="ddlCountry" runat="server" class="form-control">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Thailand</asp:ListItem>
                    <asp:ListItem>Vietnam</asp:ListItem>
                    <asp:ListItem>Indonesia</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>South Korea</asp:ListItem>
                    <asp:ListItem>Japan</asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <p> Departure Date:<asp:TextBox ID="TextBox2" runat="server" class="form-control" ></asp:TextBox>
        </p>
        </div>
        <div class="form-group col-md-6">
            <p> Arrival Date:<asp:TextBox ID="TextBox3" runat="server" class="form-control" ></asp:TextBox></p>
        </div>
     </div>        
   <div class="form-row">
        <div class="form-group col-md-5">
        </div>
       <div class="form-group col-md-2">
           <asp:Button ID="btnCreate" runat="server" class="btn btn-success" Text="Create" OnClick="btnCreate_Click" />
        </div>
       <div class="form-group col-md-5">
        </div>
   </div>
    <!--//Page Content-->
</asp:Content>
