<%@ Page Title="Welcome To Our Alpha Professional Tools®" Language="C#" MasterPageFile="~/MasterPages/Inner.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <!-- page-top start-->
    <!-- ================ -->
    <div class="page-top object-non-visible" data-animation-effect="fadeInUpSmall" data-effect-delay="100">
        <div class="container">
            <div class="row">
                <div id="sectionDiv" runat="server">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Inner" runat="server">

    <div class="section text-muted footer-top clearfix">
        <div class="row">
            <div class="col-md-9">
                <div class="owl-carousel clients" id="carouselHome" runat="server">
                </div>
            </div>
           <%-- <div class="col-md-2 loginBtnClass">
                <input type="button" class="btn btn-default" value="Member Log in" onclick="document.location.href = 'members.aspx'" />
                <a href="../Pages/TechAcademy.aspx">
                    <img style="background-color: #f1f1f1;border-color: #fff;max-width: 160px;height: 40px;margin-left: 8px;" alt="" src="../Content/AlphaToolContent/images/icons/LikeUsonFacebook.jpg" /></a>
            </div>--%>

            <div class="col-md-2 loginBtnClass" style="margin-top: 30px;">
                <input type="button" class="btn btn-default" value="Member Log in" onclick="document.location.href = 'members.aspx'" />
            </div>
            <div class="col-md-1" style="margin-top: 19px;text-align: center;">
                <a href="../Pages/TechAcademy.aspx">
                    <img class="btn btn-default" style="background-color: #fff;border-color: #fff;max-width: 180px;height: 64px;" alt="" src="../Content/AlphaToolContent/images/AlphaTechAcademy-Media.jpg"></a>
            </div>

        </div>
    </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .box-style-2 .body {
            margin-bottom: 10px;
        }

        /*.owl-carousel .owl-wrapper-outer {
            padding-left: 5%;
        }*/

        h2 {
            margin-bottom: 5px;
        }

        p {
            margin-bottom: 0;
            max-height: 50px;
            overflow: hidden;
        }

        .box-style-2 .icon-container {
            width: 25%;
            height: 30%;
        }

        .loginBtnClass {
            text-align: center;
        }
    </style>
</asp:Content>
