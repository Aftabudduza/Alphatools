<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderTop.ascx.cs" Inherits="UserControls.HeaderTop" %>
<style>
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
</style>
<ul class="nav navbar-nav navbar-right">
    <li class="dropdown"><a title="Home" href="/Default.aspx">Home</a></li>
    <li class="dropdown" style="">
        <a href="../Pages/AboutUs.aspx" title="About Us">About Us</a>
        <a class="iconA dropdown-toggle" data-toggle="dropdown"><i class="fa fa-angle-down" aria-hidden="true"></i></a>
        <ul class="dropdown-menu">
            <li><a href="../Pages/AboutUs.aspx">Overview</a></li>
            <li><a href="../Pages/WhatsNew.aspx">What's New</a></li>
            <li><a href="../Pages/Employment.aspx">Careers </a></li>
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
            <li><a href="../Pages/TechAcademy.aspx">Media Library</a></li>
        </ul>
    </li>
    <li class="dropdown">
        <a href="../Pages/ContactUs.aspx" title="Contact Us">Contact Us</a>
    </li>
    <li class="dropdown">
        <a id="" style="background-color: #337ab7; color: white; border-radius: 10px; text-align: center;"
            href="../Pages/ShopLocation.aspx">Buy Now</a>
    </li>


</ul>




