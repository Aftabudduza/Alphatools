<%@ Page Title="Social Media" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Social.aspx.cs" Inherits="pages_Social" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />

    <link rel="stylesheet" media="screen, projection" href="../dist/drift-basic.css" />
    <style type="text/css">
        .table tr,
        .table td {
            border: 0 none;
            outline: none;
        }

        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
            padding: 0;
        }

        .panel-body {
            padding: 0 5px;
        }

        .section-imgdiv {
            padding-top: 2%;
        }

        /*@media (max-width: 767px) {
            .section-imgdiv {
                padding-top: 0;
               
            }
        }*/
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
   <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">Social Media</li>
        </ol>
    </div>
    <div class="banner">
        <div runat="server" id="BannerCalender">
            <img src="../Images/Banners-Section/Banner_Social.jpg" alt='' data-bgposition='center top' data-bgfit='cover' data-bgrepeat='no-repeat'/>
        </div>
    </div>
    <hr />
    <section class="main-container" style="margin-top: 10px;">
       <div class="row">
                <div class="col-md-12">
                   <div class="panel-body" style="padding:10px 10px 0 10px;"> 
                            <p>Alpha Professional Tools<sup>&reg;</sup> is now available on many social media channels. We invite you to Join Us, Like Us,  Share With Us and become part of the Alpha<sup>&reg;</sup> family. </p>
                                      <p>We would love to See You in Action, Hear Your Thoughts and Ideas, as well as provide you with  Up-to-Date Industry Information to make your job more efficient.</p>
                                        <h4 style="color: #337ab7;">Select a Link to Check Out Our Sites &gt;&gt;&gt;    </h4>
                        </div>

                        <div class="panel-body" style="padding:10px 10px 0 10px;">  
                             <div class="main col-md-12">
                                            <div class="col-sm-2">
                                                  <p align="center">
                                                       <a href="https://www.facebook.com/alphaprotools/">
                                                            <img class="section-imgdiv" src="../Images/Icons/button-facebook-sq.jpg" width="225" alt="" name="Facebook"  />
                                                       </a>
                                                     </p>
                                            </div> 
                                            <div class="col-sm-2">
                                      <p align="center">
                                                         <a href="https://www.instagram.com/alphaprotools/">
                                                            <img class="section-imgdiv" src="../Images/Icons/button-instagram-sq.jpg"  width="225" alt="" name="Instagram"  />
                                                         </a>
                                                     </p>
                                            </div> 
                                            
                                      <div class="col-sm-2">
                                                <p align="center">
                                                         <a href="https://www.linkedin.com/company/alpha-professional-tools/">
                                                            <img class="section-imgdiv" src="../Images/Icons/button-linkedin-sq.jpg"  width="225" alt="" name="LinkedIn"   />
                                                         </a>
                                                     </p>
                                            </div>
                                 <div class="col-sm-2">
                                      <p align="center">
                                                        <a href="https://www.twitter.com/alphaprotools/">
                                                             <img class="section-imgdiv" src="../Images/Icons/button-twitter-sq.jpg"  width="225" alt="" name="Twitter" />
                                                        </a>
                                                    </p>
                                            </div> 
                                        <div class="col-sm-2">
                                               <p align="center">
                                                       <a href="https://www.youtube.com/alphamedia/">
                                                           <img class="section-imgdiv" src="../Images/Icons/button-youtube-sq.jpg"  width="225" alt="" name="YouTube"  />
                                                       </a>
                                                     </p>
                                            </div> 
                                 
                                            <div class="col-sm-2">
                                                <p align="center">
                                                         <a href="https://plus.google.com/113239087275763146558">
                                                            <img class="section-imgdiv" src="../Images/Icons/button-googleplus-sq.jpg"  width="225" alt="" name="Google+"  />
                                                        </a>
                                                         </p>      
                                            </div> 
                                        </div>                            
                                    </div>
                       <div class="panel-body" style="padding:0 10px 10px 10px;">  
                           <p>For more information on Alpha Professional Tools<sup>&reg;</sup>  social media and marketing,  e-mail us at <a href="mailto:marketing@alpha-tools.com"> marketing@alpha-tools.com</a> or contact our main office at (800) 648-7229.</p>
                        </div>
                </div>
            
            </div>
    </section>
</asp:Content>


