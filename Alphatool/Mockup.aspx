<%@ Page Title="Welcome To Our Alpha Professional Tools®" Language="C#" AutoEventWireup="true" CodeFile="Mockup.aspx.cs" Inherits="Mockup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>Alpha Professional Tools®</title>
    <!-- Mobile Meta -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <script type="text/javascript" src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>
    <%--<script type="text/javascript" src="https://hovercart.quivers.com/?Marketplace=fa776595-91da-42c7-b31e-661468471f3c"></script>--%>
   <%-- <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>--%>
    <!-- Favicon -->
    <link rel="shortcut icon" href="../Content/AlphaToolContent/images/favicon.ico">
    <!-- Web Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,400,700,300&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=PT+Serif' rel='stylesheet' type='text/css'>
    <!-- Bootstrap core CSS -->
    <link href="../Content/AlphaToolContent/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/full-width-slider.slider/Slider.css" rel="stylesheet" />
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
        .box-style-2 .body {
            margin-bottom: 10px;
        }

        h2 {
            margin-bottom: 5px;
        }

        /*p {
            margin-bottom: 0;
            max-height: 50px;
            overflow: hidden;
        }*/

        .box-style-2 .icon-container {
            width: 25%;
            height: 30%;
        }

        .loginBtnClass {
            text-align: center;
        }
    </style>
    <style type="text/css">
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
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <!-- scrollToTop -->
            <!-- ================ -->
            <%--  <div class="scrollToTop" style="display: none;">
                <i class="icon-up-open-big"></i>
            </div>--%>
            <!-- page wrapper start -->
            <!-- ================ -->
            <!-- header-top end -->
            <header class="header fixed clearfix" style="border-bottom: none;">
                <div class="container">
                    <div class="row">
                        <div class="col-md-2">                                                        
                            <div class="header-left">
                                <div class="logo">
                                    <a href="/Default.aspx">
                                        <asp:Image style="padding-top: 20px;" ID="Image2" runat="server" ImageUrl="~/Images/alphalogo.gif" />
                                    </a>
                                </div>
                            </div>     
                        </div>
                        <div class="col-md-8 col-sm-9 col-xs-12">
                            <div class="header-right clearfix" style="text-align:center; width:100%;padding-top: 50px; float:left;">
                              <p>Welcome to the <b>VIP website</b> </p>
                            </div>                           
                        </div>
                        <div class="col-md-2" style="padding-right: 0 !important;">
                            <div class="header-left">
                                <div class="logo">
                                   <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ProDiamond.jpg" />
                                </div>
                            </div>                           
                        </div>
                    </div>
                </div>
            </header>


            <div class="container">
                <div class="banner">
                    <!-- slideshow start -->
                    <!-- ================ -->
                    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0; left: 0; width: 1920px; height: 520px; overflow: hidden; visibility: hidden;">
                        <div id="BannerHome" runat="server" data-u="slides" style="cursor: default; position: relative; top: 0; left: 0; width: 1920px; height: 520px; overflow: hidden;">
                            <div data-p="225.00">
                                <a style="font-weight: bold;" title="PSC-150" href="/Pages/ProductDetails.aspx?PageCode=2110">
                                    <img alt="" src="/Images/Banners-Home/PSC-150.jpg" /></a>
                            </div>
                        </div>
                        <!-- Bullet Navigator -->
                        <div data-u="navigator" class="jssorb05" style="bottom: 16px; right: 16px;" data-autocenter="1">
                            <!-- bullet navigator item prototype -->
                            <div data-u="prototype" style="width: 16px; height: 16px;"></div>
                        </div>
                        <!-- Arrow Navigator -->
                        <span data-u="arrowleft" class="jssora22l" style="top: 0; left: 12px; width: 40px; height: 58px;" data-autocenter="2"></span>
                        <span data-u="arrowright" class="jssora22r" style="top: 0; right: 12px; width: 40px; height: 58px;" data-autocenter="2"></span>
                    </div>
                </div>
                <hr />
            </div>

            <div>
                <!-- MENU SECTION END-->
                <div class="content-wrapper">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-3">
                                &nbsp;  
                            </div>
                            <div class="col-md-8">
                                <p><span style="color: #0000ff;">How To Use</span></p>
                                <ol style="color: #0000ff;">
                                    <li><span style="color: #0000ff;">Get an account setup with ProSpec, LLC&reg; to get added to the Alpha&reg; VIP System</span></li>
                                    <li><span style="color: #0000ff;">Sign in and setup your password and billing information <em>(one time setup)</em></span></li>
                                    <li><span style="color: #0000ff;">Purchase product at the special VIP price and get it shipped directly to you</span></li>
                                </ol>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 20px;">
                            <div class="col-md-4">
                                <p>
                                    <strong>First-time User?</strong><br />
                                    If you are a first-time user and have not activated your account, you must do so before you can purchase product on this site.
                                 <a href="#">
                                     <asp:Image Style="padding-top: 20px;" ID="Image4" runat="server" ImageUrl="~/Images/RegisterButton.png" />
                                 </a>
                                </p>
                            </div>
                            <div class="col-md-4">
                                &nbsp;  
                            </div>
                            <div class="col-md-4">
                                <strong>Already Registered?</strong>
                                <a href="#">
                                    <asp:Image Style="padding-top: 20px;" ID="Image5" runat="server" ImageUrl="~/Images/ShopNowButton.png" />
                                </a>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-md-12" style="text-align: center; font-size: 12px;">
                                <p>This site is for the exclusive use of registered Alpha&reg;/ProSpec, LLC&reg; customers to purchase Alpha&reg; Products and other consumables.</p>
                            </div>
                        </div>

                        <div class="row" style="font-size: 12px; font-style:italic;">
                            <div class="col-md-7">
                                <p>
                                    Alpha Professional Tools&reg; was founded in 1986 and has become a<br />
                                    leading manufacturer of quality tools for professionals in the natural/engineered <br />
                                    stone, porcelain, ceramic, glass, construction, marine and automotive industries.
                                </p>
                            </div>
                            <div class="col-md-5">
                                <p>
                                    Pro Spec, LLC&reg; represents world class manufacturers of <br />
                                    interior and exterior finishes to the project design, specification, <br />
                                    and construction communities.
                                </p>
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
                <div class="footer">                   
                    <!-- .subfooter start -->
                    <!-- ================ -->
                    <div class="subfooter">
                        <div class="container" style="text-align: center;">
                            <div class="row">
                                <div class="col-md-5">
                                    <p>
                                        Copyright ©
                                        <asp:Label ID="lblYear" runat="server"> 2019</asp:Label>
                                        by Alpha Professional Tools
                                    </p>
                                </div>
                                <div class="col-md-2 subfooter-icons">
                                    <a href="https://mail.alpha-tools.com/owa" target="_blank">
                                        <img src="../Content/AlphaToolContent/images/icons/email.png" style="display:inline;"></a>
                                    <a href="https://saleslogix.alpha-tools.com/slxclient" target="_blank">
                                        <img src="../Content/AlphaToolContent/images/icons/saleslogix.png" style="display:inline; margin-left: 10px; margin-right: 10px;">
                                  </a>
                                      <a href="https://portal.softtimeonline.com/sto/index.html" target="_blank">
                                        <img src="../Content/AlphaToolContent/images/icons/softtime.png" style="display:inline;margin-left: 10px; margin-right: 10px;"></a>
                                          <a href="https://www.concursolutions.com/" target="_blank">               
                                        <img src="../Content/AlphaToolContent/images/icons/concur.png" style="display:inline;margin-left: 6px; margin-right: 6px;"></a>
                                </div>
                                <div class="col-md-5">
                                    <p>103 Bauer Drive, Oakland, NJ 07436-3102 | 800-648-7229 | <a href="mailto:info@alpha-tools.com">E-mail Us</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- .subfooter end -->
                </div>
            </footer>

        </div>

        <!-- CONTENT-WRAPPER SECTION END-->

        <!-- page-wrapper end -->
        <!-- JavaScript files placed at the end of the document so the pages load faster
		================================================== -->

        <script type="text/javascript" src="../Content/full-width-slider.slider/js/jquery-1.11.3.min.js"></script>
        <script type="text/javascript" src="../Content/full-width-slider.slider/js/jssor.slider.mini.js"></script>
        <script type="text/javascript" src="../Scripts/Slider.js"></script>
        <!-- Jquery and Bootstap core js files -->
        <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>
        <%--   <script type="text/javascript" src="https://hovercart.quivers.com/?Marketplace=fa776595-91da-42c7-b31e-661468471f3c"></script>--%>
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
        <!-- Appear javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.appear.js"></script>
        <!-- Count To javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.countTo.js"></script>
        <!-- Parallax javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.parallax-1.1.3.js"></script>
        <!-- Contact form -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.validate.js"></script>
        <!-- SmoothScroll javascript -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.browser.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/SmoothScroll.js"></script>
        <!-- Initialization of Plugins -->
        <script type="text/javascript" src="../Content/AlphaToolContent/js/template.js"></script>
        <!-- Custom Scripts -->
        <script type="text/javascript" src="../Content/AlphaToolContent/js/custom.js"></script>
        <!-- Color Switcher (Remove these lines) -->
        <script type="text/javascript" src="../Content/AlphaToolContent/style-switcher/style-switcher.js"></script>
        <script type="text/javascript" src="../Scripts/jquery.datetimepicker.full.min.js"></script>

        <script src="../autocomplete/jquery-ui-1.8.21.custom.min.js" type="text/javascript"></script>

        <link href="../autocomplete/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />


    </div>
</body>
</html>
