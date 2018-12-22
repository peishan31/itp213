<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="TripAllocation.aspx.cs" Inherits="ITP213.TripAllocation"  MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript" >
    $(document).ready(function () {
        $(function () {
            $("#tbDepartureDate").datepicker();
            $("#tbArrivalDate").datepicker();
        });
    });
</script>
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
            <p> Student&#39;s school:
            <asp:DropDownList ID="ddlSchool" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                <asp:ListItem Value="--Please Select--">--Please Select--</asp:ListItem>
                <asp:ListItem Value="SBM">School of Business Management</asp:ListItem>
                <asp:ListItem Value="SCL">School of Chemical &amp; Life Sciences</asp:ListItem>
                <asp:ListItem Value="SID">School of Design</asp:ListItem>
                <asp:ListItem Value="SEG">School of Engineering</asp:ListItem>
                <asp:ListItem Value="SHSS">School of Health &amp; Social Sciences</asp:ListItem>
                <asp:ListItem Value="SIT">School of Information Technology</asp:ListItem>
                <asp:ListItem Value="SIDM">School of Interactive &amp; Digital Media</asp:ListItem>
            </asp:DropDownList>
            </p>
        </div>
        <div class="form-group col-md-6">
            <p> 
                <asp:Label ID="lblCourses" runat="server" Text="Student's course:" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlCourses" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged" Visible="False">
                </asp:DropDownList>
            </p>
        </div>
    </div>
    <p> Select Students:</p>
    <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Button ID="btnAddStudent" class="btn btn-success btn-block" runat="server" Text="Move All →" OnClick="btnAddStudent_Click" />
            <asp:ListBox ID="lbStudents" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="lbStudents_SelectedIndexChanged">
                
            </asp:ListBox>
            
            
        </div>
        <div class="form-group col-md-6">
            <asp:Button ID="btnRemoveStudent" class="btn btn-danger btn-block" runat="server" Text="← Remove All" OnClick="btnRemoveStudent_Click" />
            <asp:ListBox ID="lbSelectedStudents" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="lbSelectedStudents_SelectedIndexChanged">
            </asp:ListBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <p> Lecturer&#39;s department:
            <asp:DropDownList ID="ddlLecturerDepartment" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlLecturerDepartment_SelectedIndexChanged">
                <asp:ListItem Value="--Please Select--">--Please Select--</asp:ListItem>
                <asp:ListItem Value="SBM">School of Business Management</asp:ListItem>
                <asp:ListItem Value="SCL">School of Chemical &amp; Life Sciences</asp:ListItem>
                <asp:ListItem Value="SID">School of Design</asp:ListItem>
                <asp:ListItem Value="SEG">School of Engineering</asp:ListItem>
                <asp:ListItem Value="SHSS">School of Health &amp; Social Sciences</asp:ListItem>
                <asp:ListItem Value="SIT">School of Information Technology</asp:ListItem>
                <asp:ListItem Value="SIDM">School of Interactive &amp; Digital Media</asp:ListItem>
            </asp:DropDownList>
            </p>
        </div>
    </div>
    <p> Select Lecturers:</p>
    <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Button ID="btnAddLecturer" class="btn btn-success btn-block" runat="server" Text="Move All →" OnClick="btnAddLecturer_Click" />
            <asp:ListBox ID="lbLecturers" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="lbLecturers_SelectedIndexChanged" >
            </asp:ListBox>
        </div>
        <div class="form-group col-md-6">
            <asp:Button ID="btnRemoveLecturer" class="btn btn-danger btn-block" runat="server" Text="← Remove All" OnClick="btnRemoveLecturer_Click" />
            <asp:ListBox ID="lbSelectedLecturers" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="lbSelectedLecturers_SelectedIndexChanged">
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
            <p> Departure Date:<asp:TextBox ID="tbDepartureDate" runat="server" class="form-control" TextMode="DateTime" ClientIDMode="Static"></asp:TextBox>
        </p>
        </div>
        <div class="form-group col-md-6">
            <p> Arrival Date:<asp:TextBox ID="tbArrivalDate" runat="server" class="form-control" TextMode="DateTime" ClientIDMode="Static"></asp:TextBox></p>
        </div>
     </div>        
   <div class="form-row">
        <div class="form-group col-md-5">
        </div>
       <div class="form-group col-md-2">
           <asp:Button ID="btnCreate" runat="server" class="btn btn-success btn-block" Text="Create" OnClick="btnCreate_Click" />
        </div>
       <div class="form-group col-md-5">
           <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
   </div>
    <!--//Page Content-->


</asp:Content>
