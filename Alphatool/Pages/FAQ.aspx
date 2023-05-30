<%@ Page Title="Alpha Professional Tools® :: FAQ" Language="C#" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="pages_FAQ" %>

<%@ Register TagPrefix="AlphaTool" TagName="HeaderTopMenu" Src="~/UserControls/HeaderTop.ascx" %>
<%@ Register Src="~/UserControls/CategoryMenu.ascx" TagPrefix="AlphaTool" TagName="CategoryMenu" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="AlphaTool" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Alpha Professional Tools®</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE10" />
    <!-- Mobile Meta -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
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
    <!-- Alpha core CSS file -->
    <link href="../Content/AlphaToolContent/css/style.css" rel="stylesheet" />
    <link href="../Content/CustomStyle/CustomStyle.css" rel="stylesheet" />
    <!-- Style Switcher Styles (Remove these two lines) -->
    <!-- Custom css -->
    <link href="../Content/AlphaToolContent/css/custom.css" rel="stylesheet" />
    <link href="../Content/Styles/main.css" rel="stylesheet" />

    <asp:PlaceHolder runat="server" ID="metaTags" />
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <!-- scrollToTop -->
            <!-- ================ -->
            <div class="scrollToTop" style="display: none;">
                <i class="icon-up-open-big"></i>
            </div>
            <!-- page wrapper start -->
            <!-- ================ -->
            
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
                             	<div class="col-sm-8 col-xs-11 pull-right" id="adv-search">
          		                   <a class="advanced-search pull-right" data-toggle="collapse" data-target="#filter-panel">Advanced Search</a>          
                                      <div id="filter-panel" class="collapse filter-panel">
                                          <a style="display: inline-block; margin: 2px -8px 0px 0px; float: right; background-color: #337AB7; color: white; padding: 4px; border-radius: 14px;" data-toggle="collapse" data-target="#filter-panel" class="advanced-search"><i class="fa fa-times"></i></a>
                                        
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
       			                     </div>          
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
                                        <%--<img id="logo" src="../../Images/logo.gif" alt="Alpha"/>--%>
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
                                    <span class="m-category-box">SELECT YOUR CATEGORY</span>
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
                            </ol>
                        </div>
                        <section class="main-container" style="margin-top: 0px;">
                          <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <span class="title">
                                                <h3 id="PageH3" runat="server"></h3>
                                            </span>
                                        </div>
                                        <div class="panel-body">
						                  <p>
					                 <H3>Frequently Asked Questions</H3></p>                                            
                                            <span><h4>Search by one of the following to find additional product information:</h4></span>
                                            <div class="form-group col-md-3">
                                                <label>Product Name</label>
                                                <asp:TextBox runat="server" Width="100%"  ID="txtProductNameFAQ"></asp:TextBox>
                                                </div>
                                            <div class="form-group col-md-3">
                                                <label>Part Number</label>
                                                <asp:TextBox runat="server" Width="100%"  ID="txtPartNoFAQ"></asp:TextBox>
                                                </div>
                                            <div class="form-group col-md-3">
                                                <label>Keywords</label>
                                                <asp:TextBox runat="server" Width="100%" ID="txtKeywordFAQ"></asp:TextBox>
                                                </div>
                                            <div class="form-group col-md-2">
                                                <div style="margin-top: 27px;">
                                                <asp:Button runat="server" ID="btnSearchFAQ" Text="Search" OnClick="btnSearchFAQ_Click"/>
                                                </div>								
                                            </div>
                                             </div>
							                 <p><h4>Not finding your answer? Contact us via e-mail at <a href="mailto:technicalsupport@alpha-tools.com">technicalsupport@alpha-tools.com</a> or via phone at 800-648-7229 option 1.</h4></p>
                                        <div class="panel-body">
                                            <div class="col-md-12">
                                                <div style="margin-bottom: 20px;">
                                                    <h4><span id="searchResultTile" runat="server"> </span></h4>
                                                    </div>
                                                <div id="faqsDiv" runat="server">
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </form>
        <div>
            <span>
                <AlphaTool:Footer runat="server" ID="FooterMenu" />
            </span>
        </div>
        <!-- footer end -->
        <!-- page-wrapper end -->
        <script type="text/javascript" src="../Content/AlphaToolContent/plugins/jquery.min.js"></script>
        <script type="text/javascript" src="../Content/AlphaToolContent/bootstrap/js/bootstrap.min.js"></script>      
        <script type="text/javascript" src="../Content/AlphaToolContent/js/custom.js"></script>      
        <script type="text/javascript" src="../Content/AlphaToolContent/html/assets/js/jquery-1.11.1.js"></script>
    </div>
</body>
</html>





