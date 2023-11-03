<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Pages_Videos" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Alpha Professional Tools - Videos for AWS-110 Wet Stone Cutter</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <title>Alpha Professional Tools®</title>
    <!-- Mobile Meta -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Favicon -->
    <link rel="shortcut icon" href="Content/AlphaToolContent/images/favicon.ico">
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
    <link href="#" data-style="styles" rel="stylesheet">
    <link href="../Content/AlphaToolContent/style-switcher/style-switcher.css" rel="stylesheet" />
    <!-- Custom css -->
    <link href="../Content/AlphaToolContent/css/custom.css" rel="stylesheet" />
    <link href="../Content/Styles/main.css" rel="stylesheet" />
    <%--<link href="../Content/AlphaToolContent/plugins/magnific-popup/magnific-popup.css" rel="stylesheet" />--%>
    <%--<link rel="Stylesheet" type="text/css" href="/includes/screen.css" media="screen" />--%>

</head>
<body id="popup" style="margin: 50px;">
    <div>
        <img src="/images/alphatools_sub_logo.gif" alt="Alpha Tools" title="Alpha Tools" width="182" height="43" />
        <br/>
        <p>Click a link below to view a video for <span id="productBanner" runat="server"></span>.</p>
        <p>Download times may vary depending upon your Internet connection. </p>
    </div>
    <div id="videos" runat="server">
        <ul id="videoList" runat="server">
        </ul>
    </div>

    <script src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>
        <script src="../Content/AlphaToolContent/html/assets/js/bootstrap.js"></script>

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

        <%--<link href="../Content/gallery/jquery.bxslider.css" rel="stylesheet" />--%>
        <script src="../Content/gallery/jquery.fitvids.js"></script>
        <%--<script src="../Content/gallery/jquery.bxslider.js"></script>--%>
        <script src="../Content/gallery/jquery.iframetracker.js"></script>

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

            //jQuery('.owl-carousel').owlCarousel({
            //    //autoplay: 5000,
            //    lazyLoad: true,
            //    nav: true,
            //    loop: false,
            //    navRewind: false,
            //    margin: 10
            //    //navigation: true
            //    //navigationText: [
            //    //  "<i class='icon-chevron-left icon-white'></i>",
            //    //  "<i class='icon-chevron-right icon-white'></i>"
            //    //]
            //});
        });
    </script>
            <!-- Start of LiveChat (www.livechatinc.com<http://www.livechatinc.com>) code -->

            <script type="text/javascript">

              window.__lc = window.__lc || {};

              window.__lc.license = 12228435;

              (function() {

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
