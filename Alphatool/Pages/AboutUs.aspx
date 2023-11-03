<%@ Page Title="Alpha Professional Tools® :: About Us" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="pages_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">About Us</li>
        </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <span class="title">
                            <h3 id="PageH3" runat="server"> About Us</h3>
                        </span>
                    </div>
                    <div class="panel-body">
                        <%--<span runat="server" id="CMSContent"></span>--%>
                        <div style="float: right; text-align: center; margin-left: 10px;"><img src="../images/Alpha_OaklandNJ.jpg" alt="Alpha's&reg; facility in Oakland, NJ" width="300" height="135" />
                            <p style="margin-top: 3px; font-size: 12px; text-align: center;"><strong>Headquarters &amp; Training Center in Oakland, NJ</strong></p>
                            <br />
                            <p style="margin-top: 3px; font-size: 11px; text-align: center;">&nbsp;</p>
                            </div>
                            <p>Alpha Professional Tools<sup>&reg;</sup> was founded in 1986 and has become a leading manufacturer of quality tools for professionals in the natural/engineered stone, porcelain, ceramic, glass, construction, marine and automotive industries. Alpha<sup>&reg;</sup> provides the best products for cutting, drilling, shaping and polishing all types of materials.</p>
                            <p>In addition to providing the best products in the industry, Alpha Professional Tools<sup>&reg;</sup> offers a variety of services to support their products.</p>
                            <p>&nbsp;</p>
                            <h5>Our Mission</h5>
                            <p>Alpha<sup>&reg;</sup> leads the way by providing innovative products based on customer and industry needs through extensive marketing research.</p>
                            <p>Based on this research, our R&amp;D Department develops, tests, and produces high quality, high performance products.</p>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <%-- <div>

        <span runat="server" id="CMSContent"></span>
    </div>--%>
</asp:Content>


