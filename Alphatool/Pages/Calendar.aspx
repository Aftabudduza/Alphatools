<%@ Page Title="Alpha Professional Tools® :: Calendar of Events" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="pages_Calender" %>

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
        @media screen and (min-width: 320px) and (max-width: 360px) {
            .par {
                font-size: 12px;
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

        p {
            font-size: 14px;
        }

        strong {
            font-size: 18px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ScriptManager ID="sc" runat="server"></asp:ScriptManager>
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">Calendar of Events</li>
        </ol>
    </div>
    <div class="banner">
        <div runat="server" id="BannerCalender">
            <img src="../Images/calendar-web-banner.jpg" alt='' data-bgposition='center top' data-bgfit='cover' data-bgrepeat='no-repeat'/>
        </div>
    </div>
    <hr />
    <section class="main-container" style="margin-top: 10px;">
        <div class="row">
                <div class="main col-md-12">
                    <h2 class="page-title margin-top-clear" id="productTitle" runat="server">Calendar of Events</h2>
                    <div>
                        <p>
                            Please join Alpha Professional Tools<sup>&reg;</sup> at these upcoming events. If you would like more information about any of these events, please contact our Customer Service or Sales Department at 800-648-7229 or via e-mail at <a href="mailto:info@alpha-tools.com">info@alpha-tools.com</a>.
                        </p>
                    </div>
                        <div id="newProductDiv" runat="server" class="table-responsive">
                            <%--start grid view --%>
                            <asp:ListView ID="InventoryItems" DataKeyNames="DateListed" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">                               
                               
                                <ItemTemplate>
                                    <table border="0" class="" id="id2">
                                        <tbody>                                                   
                                            <tr valign="top" style="border-bottom:2px solid #337ab7; padding:10px;">
                                                <td align="left" style="padding:15px;">
                                                    <div class="col-md-2" style="padding: 3px 1px 10px;">
                                                    <asp:Label id="Label1" runat="server" style="font-weight: bold" Text='<%#Eval("DateListed", "{0:d}")%>'></asp:Label>
                                                        </div>
                                                    <div class="col-md-4">
                                                    <p class="par" style="font-weight: bold;"><%#GetEvent(Eval("EventTitle").ToString())%> <%# (Eval("EventTitle") != null ? Eval("EventTitle").ToString() : "")%></p>
                                                    <span style="padding:15px;">   
                                                        <%# (Eval("EventLink") != null ? GetURL(Eval("EventLink").ToString(), Eval("EventLogo").ToString()) : "")%> 
                                                       <%-- <a target="_blank" href='<%#GetEventLink(Eval("EventLink").ToString())%>'><img alt="" src='<%#GetImageFileName(Eval("EventLogo").ToString())%>' /></a>--%>
                                                    </span>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <p class="par" align="justify"><%# (Eval("EventBlurb") != null ? Eval("EventBlurb").ToString() : "")%></p>
                                                        <p class="par" align="justify"><%# (Eval("EventLink") != null ? GetEventLink(Eval("EventLink").ToString()) : "")%>
                                                       <%# (Eval("EventDetailPDF") != null ? GetPDF(Eval("EventDetailPDF").ToString()) : "")%></p>
                                                    </div>
                                                </td>                                                       

                                            </tr>
                                            <tr>
                                                
                                            </tr>

                                        </tbody>

                                    </table>

                                </ItemTemplate>

                            </asp:ListView>
                            <%--end grid view --%>                           
                        </div> 

                </div>

        </div>

    </section>

</asp:Content>




