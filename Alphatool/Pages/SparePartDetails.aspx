<%@ Page Title="Alpha Professional Tools® :: Spare Part Details" Language="C#" MasterPageFile="~/MasterPages/ProductDetails.master" AutoEventWireup="true" CodeFile="SparePartDetails.aspx.cs" Inherits="pages_SparePartDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />

    <link rel="stylesheet" media="screen, projection" href="../dist/drift-basic.css" />
    <style type="text/css">
        .drift-demo-trigger {
            width: 100%;
            float: left;
        }

        .detail {
            position: relative;
            width: 95%;
            margin-left: 5%;
            float: left;
        }

        p:last-of-type {
            margin-bottom: 2em;
        }

        @media (max-width: 1023px) {
            .wrapper {
                text-align: center;
                width: auto;
            }

            #Body_spanImageLeft img {
                width: 100%;
                float: left;
            }

            .detail, .drift-demo-trigger {
                float: none;
            }

            .drift-demo-trigger {
                max-width: 100%;
                width: auto;
                margin: 0 auto;
            }

            .detail {
                margin: 0;
                width: auto;
            }

            p {
                margin: 0 auto 1em;
            }

            .responsive-hint {
                display: none;
            }

            .drift-bounding-box {
                display: none;
            }
        }

        @media (max-width: 767px) {
            .detail {
                display: none;
            }
        }
    </style>
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

        .ContainerTop {
            width: 100%;
            padding-bottom: 20px;
            float: left;
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

        @media (max-width:480px) {
            .nav-tabs {
                background-color: #fff;
            }
        }

        @media (max-width:991px) {
            .nav-tabs > li {
                width: 100%;
                margin-bottom: 1px !important;
                /*text-align: center;*/
            }
        }

        .nav-tabs > li > a {
            font-size: 15px;
            text-transform: uppercase;
            -webkit-border-radius: 0px;
            -moz-border-radius: 0px;
            border-radius: 0px;
            border-bottom: none;
            padding: 8px 25px;
            position: relative;
            color: #fff;
        }

        .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus, .nav-pills > li > a:hover, .nav-pills > li > a:focus {
            border: 0 solid #f3f3f3;
        }

        @media screen and (min-width: 320px) and (max-width: 1023px) {
            #tabsContents {
                display: none;
            }

            #tabsContents1 {
                display: none;
            }

            #accordion {
                display: block !important;
            }

            #accordion1 {
                display: block !important;
            }
        }


        .carousel-inner > .active {
            left: -9%;
        }

        .carousel-control {
            width: 25px !important;
        }

            .carousel-control.right {
                background-image: none !important;
                background-repeat: repeat-x;
                left: auto;
                right: 0;
            }

            .carousel-control.left {
                background-image: none !important;
                background-repeat: repeat-x;
            }

        @media screen and (min-width: 320px) and (max-width: 1023px) {
            .magnifier-preview {
                display: none;
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
            height: auto;
            width: 100%;
            overflow: auto;
        }

        .SpecsCharDiv {
            margin-left: auto;
            width: 100%;
        }

        .selectedcss1 {
            background: #f1f1f1 none repeat scroll 0 0;
        }

        .imgul {
            list-style: none !important;
            margin: 1px;
        }

        .imgLi {
            border-width: 1px !important;
            margin: auto !important;
        }

        .docspan {
            color: #e84c3d;
            font-weight: bold;
            float: left;
            width: 150px;
        }

        .selectedcss {
            background: #ededee none repeat scroll 0 0;
            border-image: none;
            border-radius: 4px 4px 0 0;
            float: left;
            font-family: calibri;
            font-size: 15px;
            font-weight: bold;
            height: 40px;
            text-decoration: none;
            margin-right: 2px;
            margin-bottom: 1px;
        }

        .tabclass {
            background: #337ab7 none repeat scroll 0 0;
            border-image: none;
            border-radius: 4px 4px 0 0;
            float: left;
            font-family: calibri;
            font-size: 15px;
            font-weight: bold;
            height: 40px;
            margin-right: 2px;
            text-decoration: none;
            margin-bottom: 1px;
        }


        tbody {
            background-color: #ededee;
        }

        @media screen and (min-width: 320px) and (max-width: 639px) {
            .DivScroll {
                min-height: 80px;
                overflow: scroll;
                width: 100%;
            }
        }

        @media (max-width: 480px) {
            #specificationDiv {
                font-size: 10px;
            }


            .table > thead > tr > th,
            .table > tbody > tr > th,
            .table > tfoot > tr > th,
            .table > thead > tr > td,
            .table > tbody > tr > td,
            .table > tfoot > tr > td {
                padding: 0;
            }
        }
    </style>
    <script type="text/javascript">
        function showtext(a) {
            alert(a);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ToolkitScriptManager ID="sc" CombineScripts="true" runat="server"></asp:ToolkitScriptManager>
    <div class="page-intro" style="margin: 10px 0 !important;">
        <div class="">
            <ol id="Breadcrumb" class="breadcrumb" runat="server">
            </ol>
        </div>
    </div>
    <section class="main-container" style="margin-bottom: 30px;">
        <div class="row">
            <div class="main col-md-12">
                <h2 class="page-title margin-top-clear" id="productTitle" style="color: #337AB7; font-weight: bold;" runat="server"></h2>
                <div class="ContainerTop  preview col">
                    <div class="col-md-3">
                        <div class="sidebar">
                            <span id="spanImageLeft" runat="server"></span>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <span id="spanImageMid" runat="server"></span>
                    </div>
                    <div class="col-md-6">
                        <div class="detail">
                            <span id="spanImageRight" style="width: 100%;" runat="server"></span>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="col-md-12" id="sparepartslink" runat="server">
                    </div>
                </div>

                <div style="width: 30%; float: left;">
                    <div class="form-group">
                        <div class="input-group">
                            <input id="txtSearchPart" clientidmode="Static" runat="server" class="form-control" type="text" placeholder="Search By Part No." />
                            <div class="input-group-addon">
                                <asp:ImageButton ImageUrl="~/Images/search2.png" Width="40" Height="34" runat="server" ID="btnSearchPart" OnClick="btnSearchPart_Click" />
                            </div>
                             <div class="input-group-addon">
                                <asp:ImageButton ImageUrl="~/Images/clear.png" Width="40" Height="34" runat="server" ID="btnSearchPartClear" OnClick="btnSearchPartClear_Click" />
                            </div>

                        </div>

                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="tabsContents" style="width: 100%; float: left;">
                            <ul class="nav nav-tabs" style="width: 60%;">
                                <li id="specsLi" class="tabclass" runat="server" style="text-align: center;">
                                    <asp:LinkButton ID="specsBtn" runat="server" OnClick="specsBtn_OnClick" Text="Specifications"><i class="fa fa-file-text-o pr-5"></i>Spare Parts</asp:LinkButton>
                                </li>


                                <li id="documentLi" class="tabclass" runat="server" style="text-align: center;">
                                    <asp:LinkButton ID="documentBtn" runat="server" OnClick="documentBtn_OnClick" Text="Documentation"><i class="fa fa-files-o pr-5"></i>Documentation</asp:LinkButton>
                                </li>


                                <li id="faqLi" class="tabclass" runat="server" style="text-align: center;">
                                    <asp:LinkButton ID="faqBtn" runat="server" OnClick="faqBtn_OnClick" Text="FAQS"><i class="fa fa-question pr-5"></i>FAQS</asp:LinkButton>
                                </li>
                            </ul>


                            <div style="background-color: #ededee; padding: 40px 20px;">
                                <asp:MultiView ID="ProductDetailsMultiView" runat="server">
                                    <asp:View ID="View1" runat="server">
                                        <div class="DivScroll">
                                            <div id="spareparts" runat="server" class="SpecsCharDiv">
                                            </div>
                                        </div>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                        <div id="documentation" runat="server" class="SpecsCharDiv">
                                        </div>
                                    </asp:View>
                                    <asp:View ID="View3" runat="server">
                                        <div id="faqsDiv" runat="server" class="SpecsCharDiv">
                                        </div>

                                    </asp:View>
                                </asp:MultiView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="panel-group" id="accordion" style="display: none;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#specificationDiv"><i class="fa fa-file-text-o pr-5"></i>SPARE PARTS</a>
                            </h4>

                        </div>
                        <div id="specificationDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div class="DivScroll">
                                    <div id="specsChrtAcc" runat="server" class="SpecsCharDiv" style="margin-bottom: 20px;"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#documentationDiv"><i class="fa fa-files-o pr-5"></i>DOCUMENTATION</a>
                            </h4>
                        </div>
                        <div id="documentationDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div id="documentDivAcc" runat="server" class="SpecsCharDiv">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#faqDiv"><i class="fa fa-question pr-5"></i>FAQS</a>
                            </h4>
                        </div>
                        <div id="faqDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div id="faqDivAcc" runat="server" class="SpecsCharDiv">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- main-container end -->
    <script src="../dist/Drift.js" type="text/javascript"></script>
    <script type="text/javascript">
        new Drift(document.querySelector('.drift-demo-trigger'), {
            paneContainer: document.querySelector('.detail'),
            inlinePane: 900,
            inlineOffsetY: -85,
            containInline: true,
            hoverBoundingBox: true
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Inner" runat="server">
    <div class="col-md-12">
        <div id="productDiv" class="owl-carousel" data-interval="false" style="padding-top: 8px;" runat="server">
        </div>
    </div>

</asp:Content>




