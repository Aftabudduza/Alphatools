<%@ Page Title="Alpha Professional Tools® :: Alpha Tech Academy" Language="C#" AutoEventWireup="true" CodeFile="TechAcademy.aspx.cs" Inherits="Pages_TechAcademy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta charset="utf-8">
    <title>Alpha Professional Tools® :: Alpha Tech Academy</title>
    <!-- Mobile Meta -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

    <script type="text/javascript" src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="https://hovercart.quivers.com/?Marketplace=fa776595-91da-42c7-b31e-661468471f3c"></script>
    <%--<script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>--%>
    <!-- Favicon -->
    <link rel="shortcut icon" href="../Content/AlphaToolContent/images/favicon.ico">
    <!-- Web Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,400,700,300&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=PT+Serif' rel='stylesheet' type='text/css'>
    <!-- Bootstrap core CSS -->
    <link href="../Content/AlphaToolContent/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <!-- Font Awesome CSS -->
    <link href="../Content/AlphaToolContent/fonts/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Fontello CSS -->
    <link href="../Content/AlphaToolContent/fonts/fontello/css/fontello.css" rel="stylesheet" />
    <!-- Plugins -->
    <link href="../Content/AlphaToolContent/plugins/rs-plugin/css/settings.css" rel="stylesheet" />
    <link href="../Content/AlphaToolContent/plugins/rs-plugin/css/extralayers.css" rel="stylesheet" />
    <link href="../Content/AlphaToolContent/plugins/magnific-popup/magnific-popup.css" rel="stylesheet" />
    <link href="../Content/AlphaToolContent/css/animations.css" rel="stylesheet" />
    <link href="../Content/AlphaToolContent/plugins/owl-carousel/owl.carousel.css" rel="stylesheet" />
    <!-- Alpha core CSS file -->
    <link href="../Content/AlphaToolContent/css/style.css" rel="stylesheet" />
    <link href="../Content/CustomStyle/CustomStyle.css" rel="stylesheet" />
    <!-- Style Switcher Styles (Remove these two lines) -->
    <link href="../Content/AlphaToolContent/style-switcher/style-switcher.css" rel="stylesheet" />
    <!-- Custom css -->
    <link href="../Content/AlphaToolContent/css/custom.css" rel="stylesheet" />
    <link href="../Content/Styles/main.css" rel="stylesheet" />

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

        .groupNameColor2 {
            color: red !important;
            font-size: 20px;
            text-decoration:none;
        }
    </style>
    <style type="text/css">
        .table-responsive {
            border: none;
        }

        .panel-heading {
            padding: 0px !important;
        }

        .separator-2 {
            width: 5%;
            background-color: #cccccc;
            margin: 10px 0;
        }

        .groupNameColor {
            color: #337AB7 !important;
            font-size: 20px;
            font-weight: bold;
            text-align: center;
        }

        .spanGroupNameColor {
            color: red !important;
            font-weight: bold;
            font-size: 16px;
            padding-bottom: 10px;
        }

        .spanGroup {
            color: #343434 !important;
            font-weight: bold;
            font-size: 14px;
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
            /*overflow: auto;*/
        }

        .VideoDiv {
            float: left;
            /* margin-top: 10px; */
            /*width: 30%;*/
            background: #fff;
            /*padding: 10px 0 20px;*/
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

        .buyButtonclass {
            background: #e84c3d none repeat scroll 0 0;
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
                /*overflow: scroll;*/
                width: 100%;
            }
        }

        @media (max-width: 480px) {
            #specificationDiv {
                font-size: 10px;
            }

            #sparepartdiv {
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


        @media (min-width: 1024px) {
            .boxVideo {
                width: 40%;
                float: left;
            }

            .boxVideoText {
                width: 60%;
                float: left;
                height: 110px;
                font-size: 13px;
                color: #000000;
                text-align: left;
            }

            .VideoDiv img {
                text-align: center;
                float: left;
                padding: 0 10px;
                width: 110px;
            }

            .VideoDiv p {
                padding: 0px;
                float: left;
                height: 40px;
                overflow: hidden;
            }

            .listing-item {
                height: 110px;
                min-height: 110px;
            }

                .listing-item p {
                    color: #000000;
                    min-height: 5px;
                    max-height: 60px;
                    margin: 0;
                }
        }

        @media (min-width: 992px) and (max-width:1023px) {
            .boxVideo {
                width: 40%;
                float: left;
            }

            .boxVideoText {
                width: 60%;
                float: left;
                height: 110px;
                font-size: 13px;
                color: #000000;
                text-align: left;
            }

            .VideoDiv img {
                text-align: center;
                float: left;
                padding: 0 10px;
                width: 110px;
            }

            .VideoDiv p {
                padding: 0px;
                float: left;
                height: 40px;
                overflow: hidden;
            }

            .listing-item {
                height: 110px;
                min-height: 110px;
            }

                .listing-item p {
                    color: #000000;
                    min-height: 5px;
                    max-height: 60px;
                    margin: 0;
                }
        }

        @media (max-width: 991px) {
            .boxVideo {
                width: 40%;
                float: left;
            }

            .boxVideoText {
                width: 60%;
                float: left;
                height: 90px;
                font-size: 12px;
                color: #000000;
                text-align: left;
            }

            .VideoDiv img {
                text-align: center;
                float: left;
                padding: 0 10px;
                width: 110px;
            }

            .VideoDiv p {
                padding: 0px;
                float: left;
                height: 40px;
                overflow: hidden;
            }

            .listing-item {
                height: 90px;
                min-height: 90px;
            }

                .listing-item p {
                    color: #000000;
                    min-height: 5px;
                    max-height: 40px;
                    font-size: 12px;
                    margin: 0;
                }
        }

        .owl-carousel {
            -ms-touch-action: pan-y;
            touch-action: pan-y;
        }

        .listing-item {
            margin-bottom: 10px;
            border: none;
            border-bottom: 1px solid #337ab7;
        }

        .categoryboxn2 {
            width: 28%;
        }
    </style>
    <style type="text/css">
        /* Popup container - can be anything you want */
        .popup {
            position: relative;
            display: inline-block;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            /* The actual popup */
            .popup .popuptext {
                visibility: hidden;
                width: 300px;
                background-color: #555;
                color: #fff;
                text-align: center;
                border-radius: 6px;
                padding: 10px;
                position: absolute;
                z-index: 1;
                bottom: 125%;
                left: 50%;
                margin-left: -80px;
            }

                /* Popup arrow */
                .popup .popuptext::after {
                    content: "";
                    position: absolute;
                    top: 100%;
                    left: 50%;
                    margin-left: -5px;
                    border-width: 5px;
                    border-style: solid;
                    border-color: #555 transparent transparent transparent;
                }

            /* Toggle this class - hide and show the popup */
            .popup .show {
                visibility: visible;
                -webkit-animation: fadeIn 1s;
                animation: fadeIn 1s;
            }

        /* Add animation (fade in the popup) */
        @-webkit-keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }
    </style>

    <style type="text/css">
        .SpecsCharDiv {
            margin-left: auto;
            width: 100%;
        }

        .DivScroll {
            height: auto;
            width: 100%;
            overflow: auto;
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


        .iconA {
            float: left;
            margin: -46% -15% 0 75%;
            border: 0 none !important;
            background: 0 none !important;
            box-shadow: 0 0 0 rgba(0, 0, 0, 0.03) !important;
        }

        .iconB {
            background: 0 none !important;
            border: 0 none !important;
            float: left;
            margin: -55% -30% 0 70%;
            box-shadow: 0 0 0 rgba(0, 0, 0, 0.03) !important;
        }

        .dropdown-menu {
            top: 90% !important;
        }

        #form1 div .content-wrapper .container .main-container .row .col-md-12 .panel.panel-default .panel-body .col-md-12 .col-md-4 span {
            font-weight: bold;
        }
    </style>
</head>
<body style="width: 100%;">
    <div>
        <form id="form1" runat="server">
            <!-- scrollToTop -->
            <!-- ================ -->
            <div class="scrollToTop" style="display: none;">
                <i class="icon-up-open-big"></i>
            </div>
            <!-- page wrapper start -->
            <!-- header-top end -->
            <header class="header fixed clearfix">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4">                                                        
                                <div class="form-group">
                                    <div class="input-group">
                                        <input id="txtSearchTop" runat="server" class="form-control" type="text" placeholder="Search Product" />                                   
                                        <div class="input-group-addon">                                       
                                            <asp:ImageButton ImageUrl="~/Images/search2.png" Width="40" Height="34" runat="server" ID="btnSearchTopN" OnClick="btnSearchTopN_Click"    />
                                        </div>
                                    </div>
                                   <div class="col-sm-6 col-xs-11 pull-right" id="adv-search">
          		                       <a class="advanced-search pull-right" data-toggle="collapse" data-target="#filter-panel">Advanced Search</a>          

                                          <div id="filter-panel" class="collapse filter-panel">
                                              <a style="display: inline-block; margin: 2px -8px 0 0; float: right; background-color: #337AB7; color: white; padding: 4px; border-radius: 14px;" data-toggle="collapse" data-target="#filter-panel" class="advanced-search"><i class="fa fa-times"></i></a>
                                              <asp:Panel ID="Panel" runat="server" DefaultButton="btnSearchTop">
                                                    <div class="form-group">
												        <label>Part Number</label>
												        <asp:TextBox runat="server" Width="92%"  ID="txtPartNoTop"></asp:TextBox>
											        </div>
											        <div class="form-group">
												        <label>Product Name</label>
												        <asp:TextBox runat="server" Width="92%"  ID="txtProductNameTop"></asp:TextBox>
											        </div>
											        <div class="form-group">
												        <label>Process</label>
												        <asp:DropDownList ID="ddlProcessTop" Width="92%" runat="server"></asp:DropDownList>
											        </div>
                                                    <div class="form-group">
												        <label>Usage</label>
												        <asp:DropDownList ID="ddlUsageTop" Width="92%"  runat="server"></asp:DropDownList>
											        </div>
                                                    <div class="form-group">
												        <label>Material</label>
												        <asp:DropDownList ID="ddlMaterialTop" Width="92%"  runat="server"></asp:DropDownList>
											        </div>
                                                    <div class="form-group">
												        <label>Industry Group</label>
												        <asp:DropDownList ID="ddlIndustryTop" Width="92%"  runat="server"></asp:DropDownList>
											        </div>
                                                    <div class="form-group">
												        <label>Application</label>
												        <asp:DropDownList ID="ddlApplicationTop" Width="92%"  runat="server"></asp:DropDownList>
											        </div>
                                                    <div class="form-group">
												            <label>Main Category</label>
												            <asp:DropDownList ID="ddlCategory" Width="92%"  ValidationGroup="search"  runat="server"></asp:DropDownList>
											        </div>
											        <div class="form-group">
												        <asp:Button runat="server" ID="btnSearchTop" Text="Search" OnClick="btnSearchTop_Click" />
											        </div>
                                                  </asp:Panel>
                                          </div>          
                                    </div>
                                     <div class="col-sm-6 pull-left" id="spare-parts-search">
                                        <a style="color: #e84c3d;" href="../Pages/ProductSpareParts.aspx?SectionId=120">Search Spare Parts >></a>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-6 col-sm-9 col-xs-12">
                                <!-- header-right start -->
                                <!-- ================ -->
                                <div class="header-right clearfix">

                                    <!-- main-navigation start -->
                                    <!-- ================ -->
                                    <div class="main-navigation animated">

                                        <!-- navbar start -->
                                        <!-- ================ -->
                                        <nav class="navbar navbar-default" role="navigation">
                                            <div class="container-fluid">

                                                <!-- Toggle get grouped for better mobile display -->
                                                <div class="navbar-header">
                                                    <span class="m-category-box">Menu</span>

                                                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse-1">
                                                        <span class="sr-only">Toggle navigation</span>
                                                        <span class="icon-bar"></span>
                                                        <span class="icon-bar"></span>
                                                        <span class="icon-bar"></span>
                                                    </button>
                                                </div>

                                                <!-- Collect the nav links, forms, and other content for toggling -->
                                                <div id="navbar-collapse-1" class="collapse navbar-collapse">
                                                    <ul class="nav navbar-nav navbar-right">
                                                        <li class="dropdown"><a title="Home" href="/Default.aspx">Home</a></li>
                                                        <li class="dropdown" style="">
                                                            <a href="../Pages/AboutUs.aspx" title="About Us">About Us</a>
                                                            <a class="iconA dropdown-toggle" data-toggle="dropdown"><i class="fa fa-angle-down" aria-hidden="true"></i></a>
                                                            <ul class="dropdown-menu">
                                                                <li><a href="../Pages/AboutUs.aspx">Overview</a></li>
                                                                <li><a href="../WhatsNew.aspx">What's New</a></li>
                                                                <li><a href="../Employment.aspx">Careers </a></li>
                                                            </ul>
                                                        </li>
    
                                                        <li class="dropdown"><a title="Calendar" href="../Pages/Calendar.aspx">Calendar</a>

                                                        </li>
                                                        <li class="dropdown" style="">
                                                            <a title="Library" href="../Pages/Library.aspx">Library</a>
                                                            <a class="iconB iconA dropdown-toggle" data-toggle="dropdown"><i class="fa fa-angle-down" aria-hidden="true"></i></a>
                                                            <ul class="dropdown-menu">
                                                                <li><a href="../ProductCatalogs.aspx">Catalogs</a></li>
                                                                <li><a href="../Pages/Library.aspx#2">User Manuals</a></li>
                                                                <li><a href="../Pages/Library.aspx#1">Safety Data Sheets</a></li>
                                                                <li><a href="../Pages/FAQ.aspx">FAQs</a></li>
                                                                <li><a href="../Pages/Library.aspx#5">Parts-Schematic</a></li>
                                                                <li><a href="../Pages/Library.aspx#6">Flyers</a></li>
                                                                 <li><a href="../Pages/TechAcademy.aspx">Video  Library</a></li>
                                                            </ul>
                                                        </li>
                                                        <li class="dropdown">
                                                            <a href="../Pages/ContactUs.aspx" title="Contact Us">Contact Us</a>
                                                        </li>
                                                    </ul>


                                                </div>
                                            </div>
                                        </nav>
                                        <!-- navbar end -->
                                    </div>
                                    <!-- main-navigation end -->
                                </div>
                                <!-- header-right end -->
                            </div>
                            <div class="col-md-2" style="padding-right: 0px !important;">
                                <!-- header-left start  clearfix -->
                                <!-- ================ -->
                                <div class="header-left">
                                    <!-- logo -->
                                    <div class="logo">
                                        <a href="/Default.aspx">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.gif" />
                                           <%-- <img alt="" src="../Images/AlphaTechAcademy.jpg" />--%>
                                        </a>
                                    </div>
                                </div>
                                <!-- header-left end -->
                            </div>
                        </div>
                    </div>
                </header>
            <!-- header end -->
            <!-- header-top start (Add "dark" class to .header-top in order to enable dark header-top e.g <div class="header-top dark">) -->
            <!-- ================ -->
            <%-- <div class="header-top">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="header-top-first clearfix">
                                <div class="navbar-header navbar navbar-default">
                                    <span class="m-category-box">
                                        <% if (Session["categoryid"] != null)
                                           { %>
                                        <img class="imgMb2" src="../Images/1stcategory-sample_Final2.png">
                                        <% }%>
                                        <%else
                                           { %>
                                        <img class="imgMb2" src="../Images/1stcategory-sample_Final.png">
                                        <% } %>
                                    </span>
                                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse-2">
                                        <span class="sr-only">Toggle navigation</span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                    </button>
                                </div>

                                <div class="collapse navbar-collapse" id="navbar-collapse-2">
                                    <% if (Session["categoryid"] != null)
                                       { %>
                                    <div class="categoryboxn2 categoryboxn3">
                                        <img class="imgMb" src="../Images/1stcategory-sample_Final2.png">
                                    </div>
                                    <% }%>
                                    <%else
                                       { %>
                                    <div class="categoryboxn categoryboxn3">
                                        <img class="imgMb" src="../Images/1stcategory-sample_Final.png">
                                    </div>
                                    <% } %>

                                    <ul id="CategoryMenus" class="nav navbar-nav navbar-left category-nav" runat="server">
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>--%>
            <!-- header-top-first end -->
            <div>
                <!-- MENU SECTION END-->
                <div class="content-wrapper">
                    <div class="container">
                        <div class="page-intro">
                            <ol id="Breadcrumb" class="breadcrumb" runat="server">
                                <li><i class="fa fa-home pr-10"></i>
                                    <a href="Default.aspx">Home</a></li>
                                <li class="active">Media Library</li>
                            </ol>
                        </div>
                        <div class="main-container" style="margin-top: 0px;">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default" style="border: none;">
                                        <div class="panel-heading" style="border: none;">
                                            <span class="title" style="width: 70%; float: left; padding-left: 15px;">
                                                <h3>Alpha Tech Academy Media Library</h3>
                                            </span>
                                            <img style="float: right; width: 20%;" alt="" src="../Images/AlphaTechAcademy.jpg" />
                                        </div>
                                        <div class="panel-body" style="border: none; float: left;">
                                            <p style="float: left;">
                                                The Alpha&reg; Tech Academy  is our technical department with more than 30 years of experience in diamond  tooling for stone, tile, hardscape, just name a few.  Our goal is to provide technical knowledge on our  products and services, related applications, troubleshooting issues, as well as  other &ldquo;know-how&rdquo; to make your job easier. 
                   <br />
                                                On our site, you can find how to  videos, podcasts, and webinars for you to learn at your convenience.  In addition, we can organize hands-on training  in our facility in Oakland, NJ or schedule Virtual Product Knowledge Meetings via  video conference.  We can also deliver  technical support and troubleshooting via Virtual Site Visits through Facetime  or other smartphone apps.  The Alpha&reg;  Tech Academy can offer technical assistance in the development of specialty  tools for your unique applications or projects.  To contact our technical team, e-mail us at <a href="mailto:_technical@alpha-tools.com">technical@alpha-tools.com</a> or call 800-648-7229.
                                            </p>
                                            <p>Alpha Professional Tools<sup>&reg;</sup> is  available on many social media channels. We invite you to <strong>Join Us, Like Us,  Share With Us </strong>and become part of the Alpha<sup>&reg;</sup> family. We would love to <strong>See You in Action, Hear Your Thoughts and Ideas,</strong> as well as provide you with  Up-to-Date Industry Information to make your job more efficient.</p>
                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <h4 style="color: #337ab7;">Check Out Our Sites &gt; &gt; &gt;</h4>
                                                </p>
                                            </div>
                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <a href="https://www.facebook.com/alphaprotools/">
                                                        <img class="section-imgdiv" src="../Images/Icons/button-facebook-sq.jpg" width="60" alt="" name="Facebook" />
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <a href="https://www.instagram.com/alphaprotools/">
                                                        <img class="section-imgdiv" src="../Images/Icons/button-instagram-sq.jpg" width="60" alt="" name="Instagram" />
                                                    </a>
                                                </p>
                                            </div>

                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <a href="https://www.linkedin.com/company/alpha-professional-tools/">
                                                        <img class="section-imgdiv" src="../Images/Icons/button-linkedin-sq.jpg" width="60" alt="" name="LinkedIn" />
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <a href="https://www.twitter.com/alphaprotools/">
                                                        <img class="section-imgdiv" src="../Images/Icons/button-twitter-sq.jpg" width="60" alt="" name="Twitter" />
                                                    </a>
                                                </p>
                                            </div>
                                            <div class="col-sm-2">
                                                <p align="center">
                                                    <a href="https://www.youtube.com/alphamedia/">
                                                        <img class="section-imgdiv" src="../Images/Icons/button-youtube-sq.jpg" width="60" alt="" name="YouTube" />
                                                    </a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="float: left;">
                                        <div class="col-md-8" style="float: left;">
                                            <span id="ppcTop" runat="server"></span>
                                        </div>

                                        <%--                                            <div class="col-md-12" style="float: left;">
                                                <div class="col-md-8" style="float: left;">
                                                    <span id="ppcTop" runat="server"></span>
                                                </div>--%>
                                        <div class="col-md-4" style="float: left;">
                                            <span style="color: #f15e30; padding-right: 20px;"><strong>SELECT YOUR INDUSTRY >>></strong> </span>
                                            <asp:DropDownList ID="ddlPPCIndustry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPPCIndustry_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>


                                    <div id="div2" class="col-md-12" style="float: left;">
                                        <div id="videos2" runat="server">
                                        </div>
                                    </div>
                                    <div id="div3" class="col-md-12" style="float: left;">
                                        <div id="videos3" runat="server">
                                        </div>
                                    </div>
                                    <div id="div10" class="col-md-12" style="float: left;">
                                        <div id="videos10" runat="server">
                                        </div>
                                    </div>
                                    <div id="div4" class="col-md-12" style="float: left;">
                                        <div id="videos4" runat="server">
                                        </div>
                                    </div>
                                    <div id="div8" class="col-md-12" style="float: left;">
                                        <div id="videos8" runat="server">
                                        </div>
                                    </div>
                                    <div id="div5" class="col-md-12" style="float: left;">
                                        <div id="videos5" runat="server">
                                        </div>
                                    </div>
                                    <div id="div6" class="col-md-12" style="float: left;">
                                        <div id="videos6" runat="server">
                                        </div>
                                    </div>
                                    <div id="div9" class="col-md-12" style="float: left;">
                                        <div id="videos9" runat="server">
                                        </div>
                                    </div>
                                    <div id="div7" class="col-md-12" style="float: left;">
                                        <div id="videos7" runat="server">
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </form>

        <div>
            <div class="container">
            </div>
            <!-- CONTENT-WRAPPER SECTION END-->
            <footer id="footer">

                <!-- .footer start -->
                <!-- ================ -->
                <div class="footer">
                    <div class="container">
                        <div class="col-md-12">
                            <ul style="list-style: none;">
                                <li><a href="#"></a></li>
                            </ul>
                        </div>
                        <div class="row">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="col-md-3 col-sm-6 col-xs-6">
                                    <div class="footer-content">
                                        <h4>Company Overview</h4>
                                        <nav>
                                            <ul class="nav nav-pills nav-stacked">
                                                <li><a href="../Pages/AboutUs.aspx">About Us</a></li>
                                                <li><a href="../Pages/Policies.aspx">Policies/Terms of Use</a></li>
                                                <li><a href="../Pages/Employment.aspx">Careers</a></li>
                                                <%--<li><a href="../Pages/Privacy.aspx">Privacy/Terms of Use</a></li>--%>
                                                <li><a target="_blank" href="../Pages/Quivers.aspx">Quivers Ecommerce</a></li>
                                                <li><a target="_blank" href="../Pages/socialmedia.aspx">Social Media</a></li>
                                                <li><a  target="_blank" href="mailto: alphaweb@alpha-tools.com">Webmaster</a></li>
                                                <li><a href="../Pages/Sitemap.aspx">Sitemap</a></li>
                                                    
                                            </ul>
                                        </nav>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6 col-xs-6">
                                    <div class="footer-content">
                                        <h4>General Information</h4>
                                        <nav>
                                            <ul class="nav nav-pills nav-stacked">
                                                <li><a href="../Pages/ContactUs.aspx">Contact Us</a></li>
                                                <li><a href="../WhatsNew.aspx">What's New</a></li>

                                                <li><a href="../Pages/Library.aspx#6">Flyers</a></li>
                                                <li><a href="../Pages/Library.aspx#5">Other References</a></li>
                                                <li><a href="../Pages/EmailSignUp.aspx">Join our Mailing List</a></li>
                                                <li><a href="../Pages/BecomeADistributor.aspx">Become a Distributor</a></li>
                                                    <li><a href="../Pages/RequestADealerInfo.aspx">Find A Dealer</a></li>
                                            </ul>
                                        </nav>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6 col-xs-6">
                                    <div class="footer-content">
                                        <h4>Product Support</h4>
                                        <nav>
                                            <ul class="nav nav-pills nav-stacked">
                                                <li><a href="../ProductRegistration.aspx">Product Registration</a></li>
                                                <li><a href="../ProductBulletins.aspx">Product Bulletins</a></li>
                                                <li><a href="../Pages/RepairCenters.aspx">Tool Repair Centers</a></li>                                   
                                                <li><a href="../Pages/Library.aspx#2">Safety Data Sheets</a></li>
                                                <li><a href="../Pages/Library.aspx#3">User Manuals</a></li>
                                                <li><a href="../Pages/Library.aspx#4">Maintenance Cards</a></li>
                                                <li><a href="../Pages/Library.aspx#8">Parts Lists</a></li> 
                                                <li><a href="../Pages/FAQ.aspx">FAQs</a></li>
                                                <li><a href="../Pages/TechAcademy.aspx">Media Library</a></li>
                                    
                                                </ul>
                                        </nav>
                                    </div>
                                </div>
                                <div class="col-md-3 col-sm-6 col-xs-6">
                                    <div class="footer-content">
                                        <h4>Resources</h4>
                                        <nav>
                                            <ul class="nav nav-pills nav-stacked">
                                                <li><a href="../ProductCatalogs.aspx">Catalogs</a></li>
                                                <li><a href="../Calendar.aspx">Calendar</a></li>
                                                <li><a href="../LinksAndAffiliations.aspx">Links & Affiliations</a></li>
                                                <li><a href="../Pages/MoistureCalculator.aspx">Calculators</a></li>
                                                <li><a href="../EducationalMaterials.aspx">Educational Materials</a></li>
                                                <%-- <li><a href="../Pages/Account/Login.aspx">Member's Login</a></li>--%>
                                                <li><a href="../members.aspx">Member Login</a></li>
                                                <li><a target="_blank" href="../Pages/ProductSpareParts.aspx?SectionId=120">Parts Direct</a></li>
                                                <li><a href="../Pages/QuickOrder.aspx">Quick Order</a></li>
                                            </ul>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                        </div>
           
                        <div class="footer-content">
                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="col-md-2">
                                        <div class="logo-footer">
                                            <%--<img style="display:inline;" id="logo-footer" alt="" src="../Images/AlphaTechAcademy.jpg" />--%>
                                            <img style="display: inline;" id="logo-footer" src="../Content/AlphaToolContent/images/logo_red_footer.png" alt="" />

                                        </div>
                                    </div>
                            
                                    <div class="col-md-5" style="padding-top: 1%;">
                                        <ul class="social-links circle">
                                                        
                                            <li class="facebook"><a target="_blank" href="http://www.facebook.com/alphaprotools"><i class="fa fa-facebook"></i></a></li>
								            <li class="Instagram"><a target="_blank" href="http://www.instagram.com/alphaprotools"><i class="fa fa-instagram"></i></a></li>
                                            <li class="linkedin"><a target="_blank" href="https://www.linkedin.com/company/alpha-professional-tools"><i class="fa fa-linkedin"></i></a></li>
                                            <li class="twitter"><a target="_blank" href="http://www.twitter.com/alphaprotools"><i class="fa fa-twitter"></i></a></li>
                                            <li class="Youtube"><a target="_blank" href="https://www.youtube.com/user/alphamedia"><i class="fa fa-youtube"></i></a></li>
                                            <li class="googleplus"><a target="_blank" href="https://plus.google.com/113239087275763146558"><i class="fa fa-google-plus"></i></a></li>

                                        </ul>
                                    </div> 
                                    <%--<div>
                                        <table width="135" class="col-md-2" style="text-align:center;" border="0" cellpadding="2" cellspacing="0" title="Click to Verify - This site chose Symantec SSL for secure e-commerce and confidential communications.">
                                        <tbody>
                                            <tr>
                                            <td width="135" align="center" valign="top">
                                                <script type="text/javascript" src="https://seal.websecurity.norton.com/getseal?host_name=www.alpha-tools.com&amp;size=XS&amp;use_flash=NO&amp;use_transparent=NO&amp;lang=en"></script>
                                                <a href="javascript:vrsn_splash()" tabindex="-1"><img name="seal" border="true" src="https://seal.websecurity.norton.com/getseal?at=0&amp;sealid=3&amp;dn=www.alpha-tools.com&amp;lang=en&amp;tpt=opaque" oncontextmenu="return false;" alt="Click to Verify - This site has chosen an SSL Certificate to improve Web site security"></a><br>
                                            <a href="http://www.symantec.com/ssl-certificates" target="_blank" style="color:#000000; text-decoration:none; font:bold 7px verdana,sans-serif; letter-spacing:.5px; text-align:center; margin:0px; padding:0px;">ABOUT SSL CERTIFICATES</a></td>
                                            </tr>
                                        </tbody>

                                        </table>

                                    </div>--%>
                                    <div class="col-md-2" style="text-align:center;cellpadding:2px;">
                                        <input type="button" class="btn btn-default" value="Member Log in" onclick="document.location.href = '../members.aspx'"/>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <a href="../Pages/TechAcademy.aspx">
                                        <img style="background-color: #f1f1f1;border-color: #f1f1f1;padding-top: 25px;max-width: 160px;height: 65px;" alt="" src="../Images/AlphaTechAcademy.jpg" />
                                        <%--<img class="btn btn-default" style="background-color: #fff; border-color: #fff; padding: 15px 0px; max-width: 130px;" alt="" src="../Images/AlphaTechAcademy.jpg" />--%>
                                    </a> 
                                </div>
                            </div>
                        </div>
                </div>
                    </div>
                <!-- .footer end -->

                <!-- .subfooter start -->
                <!-- ================ -->
                <div class="subfooter">
                    <div class="container" style="text-align:center;">
                        <div class="row">
                            <div class="col-md-5">
                                <p>Copyright © <asp:Label ID="lblYear" runat="server"> 2018</asp:Label> by Alpha Professional Tools</p>
                            </div>
                            <div class="col-md-2 subfooter-icons">
                                <a href="https://outlook.office.com/owa" target="_blank">
                                    <img src="../Content/AlphaToolContent/images/icons/email.png" style="display:inline;"></a>
                                <a href="https://saleslogix.alpha-tools.com/slxclient" target="_blank">
                                    <img src="../Content/AlphaToolContent/images/icons/saleslogix.png" style="display:inline; margin-left: 10px; margin-right: 10px;">
                                </a><%--<a href="https://saleslogix.alpha-tools.com/slxmobile" target="_blank">
                                    <img src="../Content/AlphaToolContent/images/icons/saleslogixmobile.png" style="display:inline;" /></a>--%>
                                    <a href="https://portal.softtimeonline.com/sto/index.html" target="_blank">
                                    <img src="../Content/AlphaToolContent/images/icons/softtime.png" style="display:inline;margin-left: 10px; margin-right: 10px;" /></a>
                                        <a href="https://www.concursolutions.com/" target="_blank">               <img src="../Content/AlphaToolContent/images/icons/concur.png" style="display:inline;margin-left: 6px; margin-right: 6px;" /></a>
                            </div>
                                            <div class="col-md-5">
                                <p>103 Bauer Drive, Oakland, NJ 07436-3102 | 800-648-7229 | <a href="mailto:info@alpha-tools.com">E-mail Us</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .subfooter end -->

                </footer>
            <!-- footer end -->
            <!-- FOOTER SECTION END-->
        </div>

        <!-- footer end -->
        <!-- page-wrapper end -->
        <%--<script type="text/javascript" src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>--%>
        <script type="text/javascript" src="../Scripts/jquery-3.3.1.js"></script>
        <!-- Jquery and Bootstap core js files -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.min.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>
        <!-- Modernizr javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/modernizr.js"></script>
        <!-- jQuery REVOLUTION Slider  -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/rs-plugin/js/jquery.themepunch.tools.min.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
        <!-- Isotope javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/isotope/isotope.pkgd.min.js"></script>

        <!-- Owl carousel javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/owl-carousel/owl.carousel.js"></script>
        <!-- Magnific Popup javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/magnific-popup/jquery.magnific-popup.min.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/magnific-popup/jquery.magnific-popup.js"></script>
        <!-- Appear javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.appear.js"></script>
        <!-- Count To javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.countTo.js"></script>
        <!-- Parallax javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.parallax-1.1.3.js"></script>
        <!-- Contact form -->
        <%--  <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.validate.js"></script>--%>
        <!-- SmoothScroll javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.browser.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/SmoothScroll.js"></script>
        <!-- Initialization of Plugins -->
        <script type="text/javascript" src="../Content/AlphaToolContent/js/template.js"></script>
        <!-- Custom Scripts -->
        <script type="text/javascript" src="../Content/AlphaToolContent/js/custom.js"></script>
        <!-- Color Switcher (Remove these lines) -->
        <script type="text/javascript" src="../Content/gallery/jquery.fitvids.js"></script>
        <script type="text/javascript" src="../Content/gallery/jquery.iframetracker.js"></script>
        <script type="text/javascript">
            $.noConflict();
            jQuery(window).load(function () {
                jQuery('.youtube-media').magnificPopup({
                    type: 'iframe',
                    mainClass: 'mfpc-fade',
                    removalDelay: 160,
                    preloader: true,
                    fixedContentPos: false
                });

                jQuery('.owl-carousel').owlCarousel({
                    lazyLoad: true,
                    nav: true,
                    loop: false,
                    navRewind: false,
                    margin: 10
                });


            });


            //window.addEventListener("touchmove", function (event) { event.preventDefault(); }, { passive: false });
            //if (typeof window.devicePixelRatio != 'undefined' && window.devicePixelRatio > 2) {
            //    var meta = document.getElementById("viewport");
            //    meta.setAttribute('content', 'width=device-width, initial-scale=' + (2 / window.devicePixelRatio) + ', user-scalable=no');
            //}
        </script>

        <script type="text/javascript">
            $(".navbar-nav  li a").on("click", function () {
                $(".navbar-nav  li a").find(".active").removeClass("active");
                $(this).parent().addClass("active");
            });
        </script>
    </div>
    <!-- Start of LiveChat (www.livechatinc.com<http://www.livechatinc.com>) code -->

    <script type="text/javascript">

        window.__lc = window.__lc || {};

        window.__lc.license = 12228435;

        (function () {

            var lc = document.createElement('script'); lc.type = 'text/javascript'; lc.async = true;

            lc.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'cdn.livechatinc.com/tracking.js';

            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(lc, s);

        })();

    </script>

    <noscript>

        <a href="https://www.livechatinc.com/chat-with/12228435/" rel="nofollow">Chat with us</a>,

            powered by <a href="https://www.livechatinc.com/?welcome" rel="noopener nofollow" target="_blank">LiveChat</a>

    </noscript>

    <!-- End of LiveChat code -->
</body>
</html>
