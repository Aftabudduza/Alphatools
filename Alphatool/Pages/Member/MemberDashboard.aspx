<%@ Page Title="Member's Site - Alpha Professional Tools® :: Member Dashboard" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="MemberDashboard.aspx.cs" Inherits="pages_MemberDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <span class="title">Member Dashboard</span>
                </div>
                <div class="panel-body">
                    <table style="float: left; width: 100%;">
                        <tr>
                            <td>
                                <ul>
                                    <li>
                                        <a href="MemberDashboard.aspx">Member Home</a>
                                    </li>
                                    <li style="list-style-type:none;">
                                        <ul style="margin-left:2px;">
                                            <li>
                                                <a href="GeneralInformation.aspx">General Information</a>
                                            </li>
                                             <li>
                                                <a href="TermsAndConditions.aspx">Terms And Conditions</a>
                                            </li>
                                             <li>
                                                <a href="Artwork.aspx">Artwork</a>
                                            </li>
                                            <li>
                                                <a href="DealerCorporate.aspx">Dealer-Corporate</a>
                                            </li>
                                        </ul>
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
