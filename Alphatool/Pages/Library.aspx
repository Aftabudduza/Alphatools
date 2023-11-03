<%@ Page Title="Alpha Professional Tools® :: Technical Library" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Library.aspx.cs" Inherits="Pages_Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #cont ul li a {
            color: #337ab7 !important;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            <li><i class="fa fa-home pr-10"></i>
                <a href="/Default.aspx">Home</a></li>
            <li class="active">Technical Library</li>
        </ol>
    </div>

    <section class="main-container" style="margin-top: 0px;">
       <div class="row">
                <div class="main col-md-12">
                    <h2 class="page-title margin-top-clear" id="productTitle" runat="server">Technical Library </h2>
                    <a target="_blank" href="http://www.adobe.com/products/acrobat/readstep2.html">
                        <img width="32" height="32" title="Download Adobe Acrobat free to view these documents" alt="Download Adobe Acrobat free to view these documents" src="/Images/pdficon_large.gif" style="float: left; margin: 0px 10px 20px 0;">

                    </a>
                    <p>
                        Click one of the links below to find valuable technical information about the Alpha® product line. These documents are continually updated, as well as additional being added to help you keep current with the changing trends and applications. All documents are in Acrobat format. If you require Acrobat Reader, please
                        <a target="_blank" href="http://get.adobe.com/reader/">click here</a>
                        to download free.

                    </p>
                    <p style="text-align: center;">
                        <a target="_self" href="#1">Safety Data Sheets</a> | 
                        <a target="_self" href="#2">Manuals</a> | 
                        <a target="_self" href="#3">Reference</a> |
                        <a target="_self" href="#4">Maintenance Cards</a> | 
                        <a target="_self" href="#5">Parts-Schematics</a> | 
                        <a target="_self" href="#6">Flyers</a> | 
                        <a target="_self" href="#7">Other</a> | 
                        <a target="_blank" href="../Pages/TechAcademy.aspx">Videos</a>  
                    </p>
                    </div>
                     <div id="cont" class="main col-md-12" style="padding-left: 20%;">
                       <%-- <div id="1" class="table table-responsive">
                            <h3 style="color: #337ab7;">Tech Notes</h3>
                                <div id="techNoteDiv" runat="server"></div>
                        </div>
                        <hr/>--%>
                        <div id="1" class="table table-responsive">
                            <h3 style="color: #337ab7;">Safety Data Sheets</h3>
                                <div id="msdsDiv" runat="server"></div>
                        </div>
                        <hr/>
                        <div id="2" class="table table-responsive">
                            <h3 style="color: #337ab7;">Manuals</h3>
                                <div id="manualDiv" runat="server"></div>
                        </div>
                        <hr/>
                        <div id="3" class="table table-responsive">
                            <h3 style="color: #337ab7;">Reference</h3>
                                <div id="otherReffDiv" runat="server"></div>
                        </div>
                        <hr/>
                        <div id="4" class="table table-responsive">
                            <h3 style="color: #337ab7;">Maintenance Cards</h3>
                                <div id="mainTenCardDiv" runat="server"></div>
                        </div>
                        <hr/>
                        <div id="5" class="table table-responsive">
                            <h3 style="color: #337ab7;">Parts-Schematics</h3>
                                <div id="partsListDiv" runat="server"></div>
                        </div>
                        <hr/>
                       
                        <div id="6" class="table table-responsive">
                            <h3 style="color: #337ab7;">Flyers</h3>
                                <div id="flyerDiv" runat="server"></div>
                        </div>
                        <hr/>
                        <div id="7" class="table table-responsive">
                            <h3 style="color: #337ab7;">Other</h3>
                                <div id="otherDiv" runat="server"></div>
                        </div>
                </div>
            </div>
    </section>
</asp:Content>

