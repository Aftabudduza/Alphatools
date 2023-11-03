<%@ Page Title="Alpha Professional Tools® :: Product Details" Language="C#" MasterPageFile="~/MasterPages/ProductDetails.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="pages_ProductDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
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

        .lSSlideOuter {
            overflow: overlay !important;
            margin: none !important;
        }

        .lSSlideOuter .lSPager.lSGallery {
            margin: 25px 0 !important;
        }

         @media (min-width: 1024px) {
            .boxVideo {
                width: 23%;
                background: #FAFAFA;
                margin: 5px;
                float: left;
                min-height: 170px;
            }
            .VideoDiv img {
                text-align: center;
                float: left;
                padding: 10px;
                width:100%;
            }
            .VideoDiv p {
                padding: 0px;
                float: left;
                height: 40px;
                overflow: hidden;
            }
        }

        @media (min-width: 992px) and (max-width:1023px) {
            .boxVideo {
                width: 23%;
                background: #FAFAFA;
                margin: 5px;
                float: left;
                min-height: 170px;
            }
            .VideoDiv img {
                text-align: center;
                float: left;
                padding: 10px;
                width:100%;
            }
            .VideoDiv p {
                padding: 0px;
                float: left;
                height: 40px;
                overflow: hidden;
            }
        }
        
        @media (max-width: 991px) {
            .boxVideo {
                width: 23%;
                background: #FAFAFA;
                margin: 5px;
                float: left;
                min-height: 160px;
            }
             .VideoDiv img {
                text-align: center;
                float: left;
                padding: 10px;
            }
            .VideoDiv p {
                padding: 0px;
                font-size: 12px;
                float: left;
                height: 40px;
                overflow: hidden;
            }
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
      from {opacity: 0;} 
      to {opacity: 1;}
    }

    @keyframes fadeIn {
      from {opacity: 0;}
      to {opacity:1 ;}
    }
</style>

    <script type="text/javascript">
        function myFunction(b) {
            var popup = document.getElementById(b);
            popup.classList.toggle("show");
        }

        function showtext(a) {
            alert(a);
            window.location.href = url;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ToolkitScriptManager ID="sc" CombineScripts="true" runat="server"></asp:ToolkitScriptManager>
    <div class="page-intro" style="margin: 10px 0 !important;">
        <div>
            <ol id="Breadcrumb" class="breadcrumb" runat="server">
            </ol>
        </div>
    </div>
    <section class="main-container">
        <div class="row">
            <div class="main col-md-12">
                <h1 class="page-title margin-top-clear" id="productTitle" style="color: #337AB7; font-weight: bold" runat="server"></h1>
                <h4 class="page-title margin-top-clear" id="productShortDesc" runat="server"></h4>
                <div>
                    <div class="col-md-5" style="padding-bottom: 0px;">
                        <!-- Nav tabs -->
                        <ul role="tablist" class="nav nav-pills white space-top">                            
                            <li class="active">
                                <span id="wetdry" runat="server"></span>
                            </li>
                        </ul>
                        <!-- Tab panes start-->
                        <div class="tab-content clear-style">
                            <div class="demo">
                                <div class="item">            
                                    <div class="clearfix"  style="max-width:400px;" id="gallery" runat="server">
                                   
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Tab panes end-->
                    </div>
                    <aside class="col-md-7">
                        <div class="sidebar">
                            <div id="tabsContents1">
                                <ul class="nav nav-pills white space-top">    
                                    <li id="featureli" class="active" runat="server" style="text-align: center;">
                                        <asp:LinkButton ID="btnFeatures" runat="server" OnClick="btnFeatures_OnClick" Text="Features"><i class="fa fa-bars pr-5" style="color: #F3764F"></i>Features</asp:LinkButton>
                                    </li>
                                </ul>
                                <div  style="background-color: #fafafa; padding: 15px; float: left;">
                                    <asp:MultiView ID="ProductFeatureMultiview" runat="server">
                                        <asp:View ID="View7" runat="server">
                                            <div id="Div2" runat="server" class="SpecsCharDiv">
                                                <ul id="productFeatures" runat="server" class="SpecsCharDiv">
                                                </ul>
                                            </div>
                                        </asp:View>                                      
                                    </asp:MultiView>
                                    <div class="col-md-12">
                                         <asp:LinkButton ID="videosBtn" runat="server" OnClick="videosBtn_OnClick" Text="Videos"><i class="fa fa-file-video-o pr-5" style="color: #F3764F"></i>Videos</asp:LinkButton>
                                       
                                        <div id="videos" runat="server" class="col-md-12 VideoDiv">
                                            <%--<ul id="videoList" style="list-style-type: none;" runat="server">
                                            </ul>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </aside>
                </div>
                <div class="panel-group" id="accordion1" style="display: none;">  
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a   data-toggle="collapse" data-parent="#accordion1" href="#accfeatureDiv"><i class="fa fa-bars pr-5"></i>Features</a>
                            </h4>
                        </div>
                        <div id="accfeatureDiv" class="panel-collapse collapse in">
                            <div class="panel-body" style="padding: 20px 30px 15px 15px;">                                
                                <ul id="prdFeaturesAcc" runat="server" class="SpecsCharDiv">
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a  class="collapsed" data-toggle="collapse" data-parent="#accordion1" href="#accvideosDiv"><i style="font-size: 12px;" class="fa fa-file-video-o pr-5" ></i>Videos</a>
                            </h4>
                        </div>
                        <div id="accvideosDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 20px 30px 15px 15px; background: #fff !important;">
                                <div id="AccvideoLst" runat="server" class="SpecsCharDiv">
                                    <%--<ul id="AccvideoList"  style="list-style-type: none;" runat="server">
                                    </ul>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
                <div class="col-md-12" style="margin-bottom: 15px; padding: 10px; float: left;">
                    <div id="overviewDiv" style="float: left; width: 30%;margin-right: 10px;" runat="server"></div>
                    <div id="sparepartslink" style="float: left;width: 30%;margin-right: 10px;" runat="server"></div>
                    <div style="float: left;width: 30%;">
                        <asp:LinkButton ID="findDealerbtn" runat="server" OnClick="findDealerbtn_OnClick" Text="Find a dealer"><i class="fa fa-map-marker pr-5"></i>Find a dealer</asp:LinkButton>
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
                    <ContentTemplate>
                            <div id="tabsContents">                   
                                <ul class="nav nav-tabs">
                                    <li id="specsLi" class="tabclass" runat="server" style="text-align: center; ">
                                        <asp:LinkButton ID="specsBtn" runat="server" OnClick="specsBtn_OnClick" Text="Specifications"><i class="fa fa-file-text-o pr-5"></i>Specifications</asp:LinkButton>
                                    </li>
                                    <li id="detailsLi" class="tabclass" runat="server" style="text-align: center;">
                                        <asp:LinkButton ID="detailsBtn" runat="server" OnClick="detailsBtn_OnClick" Text="Description"><i class="fa fa-files-o pr-5"></i>Description</asp:LinkButton>
                                    </li>
                       
                                    <li id="documentLi" class="tabclass" runat="server" style="text-align: center; ">
                                        <asp:LinkButton ID="documentBtn" runat="server" OnClick="documentBtn_OnClick" Text="Documentation"><i class="fa fa-files-o pr-5"></i>Documentation</asp:LinkButton>
                                    </li>
                                    <li id="faqLi" class="tabclass" runat="server" style="text-align: center; ">
                                        <asp:LinkButton ID="faqBtn" runat="server" OnClick="faqBtn_OnClick" Text="FAQS"><i class="fa fa-question pr-5"></i>FAQS</asp:LinkButton>
                                    </li>
                                     <li id="additionalli" class="tabclass" runat="server" style="text-align: center; ">
                                        <asp:LinkButton ID="btnadditional" runat="server" OnClick="btnadditional_OnClick" Text="Additional"><i class="fa fa-file-text-o pr-5"></i>Additional</asp:LinkButton>
                                    </li>
                                    <li id="sparepartli" class="buyButtonclass" runat="server" style="text-align: center;">
                                        <asp:LinkButton ID="btnBuySpareParts" runat="server" OnClick="btnBuySpareParts_OnClick" Text="FAQS"><i class="fa fa-files-o pr-5"></i>Buy Now</asp:LinkButton>
                                    </li>
                                </ul>
                                <div style="background-color: #ededee; padding: 10px 10px; float: left; width: 90%;">
                                    <asp:MultiView ID="ProductDetailsMultiView" runat="server">
                                        <asp:View ID="View1" runat="server">
                                            <div id="productSpecs" runat="server" class="SpecsCharDiv" style="float: left;margin-bottom: 40px;width: 48%;"></div>
                                            <div id="productEquips" runat="server" class="SpecsCharDiv" style="float: left; margin-left: 10px; margin-bottom: 40px;width: 48%;"></div>
                                            <div class="DivScroll">
                                                <div id="partsWithSpcs" runat="server" class="SpecsCharDiv"></div>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <div id="productText" runat="server" class="SpecsCharDiv">
                                            </div>
                                        </asp:View>                            
                                        <asp:View ID="View3" runat="server">
                                            <div id="documentation" runat="server" class="SpecsCharDiv">
                                            </div>
                                        </asp:View>
                                        <asp:View ID="View4" runat="server">
                                            <div style="margin: 10px;" id="partsTable" runat="server">
                                            </div>
                                        </asp:View>
                                        <asp:View ID="View5" runat="server">
                                            <div id="faqsDiv" runat="server" class="SpecsCharDiv">
                                            </div>
                                        </asp:View>
                                         <asp:View ID="View9" runat="server">
                                            <div id="additionalDiv" runat="server" class="SpecsCharDiv">
                                            </div>
                                        </asp:View>
                                        <asp:View ID="View6" runat="server">
                                            <div class="DivScroll">
                                                <div id="buysparepartsDiv" runat="server" class="SpecsCharDiv" style="float: left; width:100%;  padding: 20px;background-color: #ededee;">
                                                </div>
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
                                <a   data-toggle="collapse" data-parent="#accordion" href="#specificationDiv"><i class="fa fa-file-text-o pr-5"></i>SPECIFICATIONS</a>
                            </h4>

                        </div>
                        <div id="specificationDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">                                
                                    <div id="specsChrtAcc" runat="server" class="SpecsCharDiv" style="margin-bottom: 20px;"></div>
                                    <div id="equipsChartAcc" runat="server" class="SpecsCharDiv" style="margin-bottom: 20px;"></div>                                
                                <div class="DivScroll">
                                    <div id="partsTblAccc" runat="server" class="SpecsCharDiv">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a  class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#descriptionDiv"><i class="fa fa-files-o pr-5"></i>DESCRIPTION</a>
                            </h4>
                        </div>
                       <div id="descriptionDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div id="prdDetailAcc" runat="server" class="SpecsCharDiv"></div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a  class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#documentationDiv"><i class="fa fa-files-o pr-5"></i>DOCUMENTATION</a>
                            </h4>
                        </div>
                        <div id="documentationDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div id="documentDivAcc" runat="server" class="SpecsCharDiv">
                                </div>
                                 <div style="margin: 10px;" id="sparepartsDivAcc" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>
                   
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a  class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#faqDiv"><i class="fa fa-question pr-5"></i>FAQS</a>
                            </h4>
                        </div>   
                        <div id="faqDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div id="faqDivAcc" runat="server" class="SpecsCharDiv">
                                </div>
                            </div>

                        </div>
                    </div>
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center">
                                <a  class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#additionalsDiv"><i class="fa fa-files-o pr-5"></i>Additional</a>
                            </h4>
                        </div>
                        <div id="additionalsDiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 40px 20px;">
                                <div class="DivScroll">
                                    <div id="AdditionalDivAcc" runat="server" class="SpecsCharDiv">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" style="text-align: center; background: #e84c3d; ">
                                <a style="background-color: #e84c3d;" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#sparepartdiv"><i class="fa fa-files-o pr-5"></i>Buy Now</a>
                            </h4>
                        </div>   
                        <div id="sparepartdiv" class="panel-collapse collapse">
                            <div class="panel-body" style="padding: 10px 10px;">
                                 <div class="DivScroll">
                                    <div id="sparepartdivAcc" runat="server">
                                    </div>
                                 </div>
                            </div>

                        </div>
                    </div>
                </div>     
                         
            </div>
        </div>
    </section>
    <!-- main-container end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Inner" runat="server">
    <div class="col-md-12">
        <div id="productDiv" class="owl-carousel" data-interval="false" style="padding-top: 8px;" runat="server">
        </div>
    </div>
</asp:Content>




