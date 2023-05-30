<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="pages_AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">


    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="title">Admin Home</span>
                </div>
                <div class="panel-body">
                    <table style="float: left; width: 100%;">
                        <tr>
                            <td>
                                <ul>
                                    <%--<li>
                                        <a href="frmGeneralArea.aspx">General Area</a>
                                    </li>
                                    <li>
                                        <a href="frmConferenceRegistrationList.aspx">Conference Area</a>
                                    </li>
                                    <li>
                                        <a href="frmRegistrationArea.aspx">Registration Area</a>
                                    </li>
                                    <li>
                                        <a href="frmForumArea.aspx">Forum Area</a>
                                    </li>
                                    <li>
                                        <a href="frmUser.aspx">Users</a>
                                    </li>

                                    <li>
                                        <a href="BasicData.aspx">Add Basic Data</a>
                                    </li>
                                    <li>
                                        <a href="frmSchools.aspx">Schools</a>
                                    </li>
                                    <li>
                                        <a href="ExportHyattReport.aspx">Reports</a>
                                    </li>--%>
                                    <%--<li>
                                        <a href="../../Pages/Admin/Categories.aspx" style=" color: #e84c3d;">Add Categoris/Subcategories</a>
                                    </li>
                                    <li>
                                        <a href="../../Pages/Admin/BasicData.aspx" style=" color: #e84c3d;">Add Basic Data (Countries, States...)</a>
                                    </li>
                                    <li>
                                        <a href="../../Pages/Admin/UserList.aspx" style=" color: #e84c3d;">User Management</a>
                                    </li>--%>
                                    <li>
                                        <a href="../../CMS/MaintainCMS.aspx" style=" color: #e84c3d;">Maintain CMS Pages</a>
                                    </li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
   

</asp:Content>
