<%@ Page Title="CMS Page" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="pages_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
    <style>
        td {
            border: none;
            /*width: 28%;*/
        }

        @media (max-width:480px) {
            td {
                float: left;
            }
        }
    #Content2 body .main-container .row .col-md-10 .panel.panel-default .panel-body .table.table-responsive tbody tr td a strong {
	color: #2d6a9f;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
        </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
         <div class="row">
                <div class="col-md-10">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3 id="PageH3" runat="server">Contact Us</h3></span>
                        </div>
                        <div class="panel-body">
                            <%--<span runat="server" id="CMSContent"></span>--%>
				           <p>Contact Alpha Professional Tools<sup>&reg;</sup> headquarters, factory service centers or sales contacts with any questions or comments regarding the products for cutting, drilling, grinding, polishing and profiling many types of materials for professionals in the natural and engineered stone, porcelain, ceramic, glass, construction, marine and automotive industries.</p>
<table class="table table-responsive">
<tbody>
<tr>
<td valign="top">
<p><strong>Company Headquarters &amp;</strong></p>
<p><strong>Training Center:</strong></p>
</td>
<td><address>Alpha Professional Tools<sup>&reg;</sup><br /> 103 Bauer Drive<br /> Oakland, NJ 07436 USA</address></td>
<td><a href="https://www.google.com/maps/place/103+Bauer+Dr,+Oakland,+NJ+07436/@41.004934,-74.2451587,17z/data=!3m1!4b1!4m2!3m1!1s0x89c31d3f3fc205b5:0xb862b8b3d61de849" target="_blank" rel="noopener noreferrer"><img style="padding-right: 2px;" src="../images/Google_Maps_icon.jpg" />Directions</a></td>
</tr>
<tr>
<td>Hours of Operation:</td>
<td colspan="2">8:30 a.m. &ndash; 5:00 p.m. EST</td>
</tr>
<tr>
<td>Telephone Number:</td>
<td colspan="2">201-337-3343</td>
</tr>
<tr>
<td>Toll-Free Number:</td>
<td colspan="2">800-648-7229</td>
</tr>
<tr>
<td>Fax Number:</td>
<td colspan="2">201-337-2216</td>
</tr>
<tr>
<td>Customer Service Fax Number:</td>
<td colspan="2">800-286-0114</td>
</tr>
<tr>
<td>Tool Department Fax Number:</td>
<td colspan="2">201-337-2265</td>
</tr>
<tr>
<td>Accounting Department Fax Number:</td>
<td colspan="2">201-337-2262</td>
</tr>

<tr>
<td>E-mail orders to:</td>
<td colspan="2"><a href="mailto:orderdesk@alpha-tools.com">orderdesk@alpha-tools.com</a></td>
</tr>
<tr>
<td>E-mail Spare Parts orders to:</td>
<td colspan="2"><a href="mailto:tooldesk@alpha-tools.com">tooldesk@alpha-tools.com</a></td>
</tr>
<tr>
<td>Technical Support:</td>
<td colspan="2"><a href="mailto:technicalsupport@alpha-tools.com">technicalsupport@alpha-tools.com</a></td>
</tr>
<tr>
<td>General Information:</td>
<td colspan="2"><a href="mailto:info@alpha-tools.com">info@alpha-tools.com</a></td>
</tr>
<tr>
<td><a href="RepairCenters.aspx"><strong>Repair Center Information &gt;&gt;</strong></a></td>
<td colspan="2"><a href="/Files/Tool-Repair-Program-USA.pdf"><img style="padding-right: 5px; margin-top: 5px; float: left;" src="../images/USFlag.jpg" />USA Center Information</a></td>
</tr>
<tr>
  <td>&nbsp;</td>
  <td colspan="2"><a href="ProductRegistration.aspx"><img style="padding-right: 5px; margin-top: 5px; float: left;" src="../images/toolicon.jpg" />Product Registration</a></td>
</tr>
<tr>
<td colspan="3"><a href="RequestADealerInfo.aspx"><strong>Request Dealer Information &gt;&gt;</strong></a></td>
</tr>
<tr>
<td><strong>Sales Territories:</strong>  </td>
<td><a href="mailto:sales@alpha-tools.com">sales@alpha-tools.com</a></td>
<td><a href="/Files/TerritoryMap.pdf"><img style="padding-right: 5px; margin-top: 5px; float: left;" src="../images/MapNA.jpg" />View Map</a></td>

</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Caribbean</td>
<td>201-337-3343</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Canada</td>
<td>519-546-9861</td>
</tr>

<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Central Plains</td>
<td>800-648-7229</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Florida</td>
<td>786-570-4350</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  International</td>
<td>201-337-3343</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Mid-Atlantic</td>
<td>804-382-5357</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Midwest</td>
<td>630-849-7105</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Mountain</td>
<td>480-848-6808</td>
</tr>

<tr>
<td><a href="mailto:Sales@alpha-tools.com">  New England</td>
<td>860-933-6626</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Northern CA</td>
<td>925-428-1292</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Northwest</td>
<td>800-648-7229</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  NY Metro</td>
<td>973-830-7681</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Ohio Valley</td>
<td>440-364-3759</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Pacific</td>
<td>800-648-7229</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  South</td>
<td>713-252-9851</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Southeast</td>
<td>678-977-1147</td>
</tr>
<tr>
<td><a href="mailto:Sales@alpha-tools.com">  Southern CA</td>
<td>714-853-3476</td>

</tr>
<tr>
<td colspan="2"><a href="Employment.aspx"><strong>Employment Information &gt;&gt;</strong></a></td>
</tr>
</tbody>
</table>
                        </div>               
                     </div>
                </div>
            </div>
     </section>
</asp:Content>


