<%@ Page Title="Alpha Professional Tools® :: Category / Section/ Group / Product Listings  " Language="C#" MasterPageFile="~/MasterPages/Home.master" CodeFile="ProductPages.aspx.cs" Inherits="pages_ProductPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
    <style type="text/css">
        ul
        {
            list-style: none !important;
        }

        @media screen and (max-width: 320px)
        {
            .category-section-imgdiv_new
            {
                margin-left: 15% !important;
            }
        }

        @media screen and (min-width: 360px) and (max-width: 980px)
        {
            .category-section-imgdiv_new
            {
                margin: 0 auto !important;
                width: 75% !important;
                min-height: 120px !important;
            }

            .category-section-body_new
            {
                height: 29px !important;
            }
        }

        .category-section-body_new
        {
            height: auto;
            margin-top: 0;
            overflow: hidden;
        }

        .listing-item_new
        {
            margin: 0 0 20px 0;
            border: 1px solid #337ab7;
            position: relative;
            overflow: hidden;
            text-align: center;
            width: 100%;
            overflow: hidden;
        }

        .category-section-imgdiv_new
        {
            margin: 0 auto;
            padding-top: 12.5%;
            width: 200px;
            min-height: 200px;
            text-align: center;
        }

        .category-section-imgdiv
        {
            margin-left: 40%;
            margin-top: 5%;
            width: 20%;
            min-height: 60px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol class="breadcrumb"></ol>
    </div>

    <div class="banner">
        <div runat="server" id="BannerHome">
        </div>
    </div>
    <hr />
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb breadcrumbCatetory" runat="server">
        </ol>
    </div>

    <section class="main-container" style="margin-top: 0;">
       <div class="row">
           <% if (Session["WebSectionid"] != null || Session["WebGroupid"] != null)
              { %>           
           <aside class="col-md-3">
               <div class="sidebar">
                   <div class="block clearfix"><div class=""><ul id="prdgrplst" runat="server" style="padding-left: 0 !important"></ul></div>
                   <div class="separator"></div>
                       <div id="searchPanel">
                           <span id="searchHead" class="searchHeading">Search Products</span>
                           <div id="formsearch" class="sorting-filters">
                                   <div class="form-group">
                                       <label>Part Number</label>
                                       <asp:TextBox runat="server" Width="200" ValidationGroup="search"  ID="txtPartNo"></asp:TextBox>
                                   </div>
                                   <div class="form-group">
                                       <label>Product Name</label>
                                       <asp:TextBox runat="server" Width="200"  ValidationGroup="search" ID="txtProductName"></asp:TextBox>
                                   </div>
                                   <div class="form-group">
                                       <label>Process</label>
                                       <asp:DropDownList ID="ddlProcess" Width="200" ValidationGroup="search"  runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>Usage</label>
                                       <asp:DropDownList ID="ddlUsage" Width="200"  ValidationGroup="search"  runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>Material</label>
                                       <asp:DropDownList ID="ddlMaterial" Width="200" ValidationGroup="search"   runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>Industry Group</label>
                                       <asp:DropDownList ID="ddlIndustry" Width="200" ValidationGroup="search"  runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>Application</label>
                                       <asp:DropDownList ID="ddlApplication" Width="200"  ValidationGroup="search"  runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <label>Main Category</label>
                                       <asp:DropDownList ID="ddlCategory" Width="200"  ValidationGroup="search"  runat="server"></asp:DropDownList>
                                   </div>
                                   <div class="form-group">
                                       <asp:Button runat="server" ID="btnSearch" Text="Submit"   OnClick="btnSearchNew_Click" />
                                   </div>
                           </div>                           
                       </div>
                   </div>
               </div>
           </aside>
           <% }%>
           <div id="productDiv" runat="server">
           </div>
       </div>
    </section>

</asp:Content>


