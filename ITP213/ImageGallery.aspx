<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ImageGallery.aspx.cs" Inherits="ITP213.ImageGallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel='stylesheet' href='Content/mdb.min.css' />
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="#" style="color:#D6D6D6">Home</a>
        </li>
        <li class="breadcrumb-item active">Image Gallery</li>
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
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            width: 37%;
        }
    </style>
    <!-- Page Content -->
    <h1>Image Gallery</h1> <!--2. Change the title!-->
    <hr/>
    <!--//Page Content-->
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">Upload Picture</button>
    <!-- The Modal -->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog modal-frame modal-top modal-notify modal-success" role="document">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" style="color:white !important">Upload Picture</h4>
                    <button type="button" class="close" data-dismiss="modal" style="color:white !important">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <table style="margin-left: auto; margin-right: auto;" class="auto-style2">
                        <tr>
                            <td class="auto-style1">Title</td>
                            <td>
                                <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxTitle" Font-Size="Smaller" ForeColor="Red" runat="server" ErrorMessage="Please enter title">*required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Location</td>
                            <td>
                                <asp:TextBox ID="TextBoxLocation" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxLocation" Font-Size="Smaller" ForeColor="Red" runat="server" ErrorMessage="Please enter location">*required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Select Image</td>
                            <td>
                                <asp:FileUpload ID="FileUploadImage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Modal footer -->
                <div class="modal-footer">
                   <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click" class="btn btn-success" Text="Upload" />
                  <button type="button" class="btn btn-outline-secondary-modal waves-effect" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="671px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="user" HeaderText="User" />
            <asp:BoundField DataField="location" HeaderText="Location" />
            <asp:ImageField DataImageUrlField="image" HeaderText="Image">
            </asp:ImageField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <br />
</asp:Content>
