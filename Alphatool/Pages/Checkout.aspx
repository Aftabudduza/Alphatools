<%@ Page Title="Alpha Professional Tools® :: Checkout" Language="C#" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Pages_Checkout" %>

<%@ Register TagPrefix="AlphaTool" TagName="HeaderTopMenu" Src="~/UserControls/HeaderTop.ascx" %>
<%@ Register Src="~/UserControls/CategoryMenu.ascx" TagPrefix="AlphaTool" TagName="CategoryMenu" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="AlphaTool" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta charset="utf-8">
    <title>Alpha Professional Tools®</title>
    <!-- Mobile Meta -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <script type="text/javascript" src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="https://hovercart.quivers.com/?Marketplace=fa776595-91da-42c7-b31e-661468471f3c"></script>
    <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>
    <!-- Favicon -->
    <link rel="shortcut icon" href="../Content/AlphaToolContent/images/favicon.ico">
    <!-- Web Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,400,700,300&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=PT+Serif' rel='stylesheet' type='text/css'>
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
        #QuiversRibbon[data-position="top"][data-style="compact"] {
            width: auto !important;
        }

        #qBluesnapPaymentTypePayPal > .qPaymentTitle {
            display: flex;
        }

            #qBluesnapPaymentTypePayPal > .qPaymentTitle > .qMethodTitle, #qBluesnapPaymentTypePayPal > .qPaymentTitle > .qPayPalDivider {
                margin-top: auto;
            }

            #qBluesnapPaymentTypePayPal > .qPaymentTitle > .qAcceptedCards {
                margin-left: auto;
            }

            #qBluesnapPaymentTypePayPal > .qPaymentTitle > .qPaymentSelectorButton {
                min-width: 20px !important;
                min-height: 20px !important;
            }
    </style>
</head>
<body style="width: 100%;">
    <div>
        <%-- <form id="form1" runat="server">--%>
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
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-8 col-sm-9 col-xs-12">
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
                                            <AlphaTool:HeaderTopMenu runat="server" ID="HeaderTop" />
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
        <div class="header-top">
            <div class="container">
                <div class="row">
                    <%-- <div class="col-xs-12 col-md-11 col-md-offset-1">--%>
                    <div class="col-md-12">
                        <!-- header-top-first start -->
                        <!-- ================ -->
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
                                <AlphaTool:CategoryMenu runat="server" ID="CategoryMenu" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
        <!-- header-top-first end -->
        <div>
            <!-- MENU SECTION END-->
            <div class="content-wrapper">
                <div class="container">
                    <div class="page-intro">
                        <ol id="Breadcrumb" class="breadcrumb" runat="server">
                            <li><i class="fa fa-home pr-10"></i>
                                <a href="/Default.aspx">Home</a></li>
                            <li class="active">Order Cart</li>
                        </ol>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <span class="title">
                                        <h3 id="PageH3" runat="server">Order Cart</h3>
                                    </span>
                                </div>
                                <div class="panel-body">
                                    <p style="text-align: center;"><span><strong>Free Ground Shipping on all orders of $250.00 or more in the Continental United States</strong></span></p>
                                    <p style="text-align: center;">Shipping to Alaska, Hawaii or Internationally? Please contact us at (800) 648-7229 / (201) 337-3343 for a shipping quote or to place an order.</p>
                                    <p style="text-align: center;">E-mail inquiries can be sent to <a href="mailto:orderdesk@alpha-tools.com">orderdesk@alpha-tools.com</a> or for spare parts to <a href="mailto:tooldesk@alpha-tools.com">tooldesk@alpha-tools.com</a>.</p>

                                    <p style="text-align: center;">Login or cart issues, please contact Quivers at <a href="mailto:support@quivers.com">support@quivers.com</a> or at (805) 250-4555.</p>

                                    <hr />
                                    <div id="q-cart"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </form>--%>
        <div>
            <span>
                <AlphaTool:Footer runat="server" ID="FooterMenu" />
            </span>
        </div>
        <!-- footer end -->
        <!-- page-wrapper end -->

        <%--  <!-- Jquery and Bootstap core js files -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.min.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>--%>
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


