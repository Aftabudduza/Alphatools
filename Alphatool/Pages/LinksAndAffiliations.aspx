<%@ Page Title="Alpha Professional Tools® :: Links And Affiliations" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="LinksAndAffiliations.aspx.cs" Inherits="pages_LinksAndAffiliations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            font-variant-ligatures: normal !important;
            font-feature-settings: normal !important;
        }

        #mk-header .header-logo a img.mk-desktop-logo.dark-logo {
            width: 345px;
            max-width: none;
            height: 85px;
            max-height: none;
        }

        @media screen and (max-width: 959px) and (min-width: 768px) {
            #mk-header .header-logo a img.mk-desktop-logo.dark-logo {
                width: 240px;
                max-width: none;
                height: 59px;
                max-height: none;
            }
        }

        @media screen and (max-width: 767px) {
            #mk-header .header-logo a img.mk-desktop-logo.dark-logo {
                width: 200px;
                max-width: none;
                height: 49px;
                max-height: none;
            }
        }
    </style>
    <style type="text/css">
        .groupNameColor {
            color: red !important;
            font-size: 20px;
        }

        .spanGroupNameColor {
            color: red !important;
            font-weight: bold;
            font-size: 20px;
        }

        .textColor1 {
            color: gray !important;
        }

        .textColor2 {
            color: blue !important;
        }

        .DivScroll {
            border: 1px solid #cccccc;
            /*max-height: 100%;*/
            height: auto;
            width: auto;
            overflow: scroll;
            /*width: 100%; d6eaf8*/
        }

        .selectedcss {
            background: #f1f1f1 none repeat scroll 0 0;
            /*border: 1px solid #f3f3f3;*/
        }

        .imgul {
            list-style: none !important;
            margin: 1px;
        }

        .imgLi {
            border-width: 1px !important;
            margin: auto !important;
        }

        .tdsize {
            padding: 15px;
            width: 150px;
            display: block;
        }

        @media screen and (min-width: 320px) {
            .tdsizemb {
                width: 100px !important;
            }
        }

        @media screen and (min-width: 320px) and (max-width: 360px) {
            .aFontSize {
                font-size: 12px;
            }
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">Links And Affiliations</li>
        </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
        <div class="row">
                <div class="main col-md-12">
                    <h2 class="page-title margin-top-clear" id="productTitle" runat="server">Links And Affiliations </h2>
                        <div id="newProductDiv" runat="server" class="table table-responsive">
                            <h4>Associations</h4>
                            <%--start grid view --%>
                            <asp:ListView ID="InventoryItems" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                                <ItemTemplate>
                                    <tr>
                                        <td valign="top">
                                            <table border="0" class="col-md-12" id="id2">
                                                <tbody>
                                                <tr valign="top" style="border-bottom:1px solid #a9a9a9; padding:10px;">
                                                    <td align="left" class="imgSize" style="padding:15px;">
                                                        <div class="col-md-2" style="padding: 3px 1px 10px;">
                                                        <a target="_blank" href='<%#GetImageFileName(Eval("LinkLogo").ToString())%>'>
                                                            <img class="img-responsive" alt="" src='<%#GetImageFileName(Eval("LinkLogo").ToString())%>'>
                                                        </a>
                                                            </div>
                                                        <div class="col-md-10">
                                                            <p> <%# (Eval("LinkName") != null ? Eval("LinkName").ToString() : "")%> </p>
                                                        <p> <%# (Eval("Link") != null ? GetBulletinInfoLink(Eval("Link").ToString()) : "")%></p>
                                                            </div>
                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--end grid view --%>                           
                        </div>
                    <hr class="color">
                    <div id="Industry" runat="server" class="table table-responsive">
                        <h4 style="margin-top: 10px;">Industry Affiliations</h4>
                        <%--start grid view --%>
                        <asp:ListView ID="lvIndustry" runat="server" GroupPlaceholderID="groupPlaceHolder2" ItemPlaceholderID="itemPlaceHolder2">
                            <ItemTemplate>
                                <tr>
                                    <td valign="top">
                                        <table border="0" class="col-md-12" id="id2">
                                            <tbody>
                                            <tr valign="top" style="border-bottom:1px solid #a9a9a9; padding:10px;">
                                                <td align="left" class="imgSize" style="padding:15px;">
                                                    <div class="col-md-2" style="padding: 3px 1px 10px;">
                                                    <a target="_blank" href='<%#GetImageFileName(Eval("LinkLogo").ToString())%>'>
                                                        <img class="img-responsive" alt="" src='<%#GetImageFileName(Eval("LinkLogo").ToString())%>'>
                                                    </a>
                                                        </div>
                                                <div class="col-md-10">
                                                    <p> <%# (Eval("LinkName") != null ? Eval("LinkName").ToString() : "")%> </p>
                                                    <p> <%# (Eval("Link") != null ? GetBulletinInfoLink(Eval("Link").ToString()) : "")%></p>
                                                    </div>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <%--end grid view --%>                           
                    </div>
                </div>
            </div>
    </section>
</asp:Content>




