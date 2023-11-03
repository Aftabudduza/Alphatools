<%@ Page Title="Tool Repair" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Toolrepair.aspx.cs" Inherits="pages_ToolRepair" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
    <style type="text/css">
        @media screen and (min-width: 768px) and (max-width: 1920px) {

            .imgtd {
                /*padding-left: 40% !important;
                width: 28%;*/
            }

            .txttd {
                /*width: 28%;*/
            }
        }


        @media screen and (min-width: 320px) and (max-width: 360px) {
            .tdwidth {
                /*width: 28%;*/
                width: 50px;
                display: block;
            }
        }
   
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
         <ol id="Breadcrumb" class="breadcrumb">
                <li><i class="fa fa-home pr-10"></i>
                    <a href="/Default.aspx">Home</a></li>
                <li class="active">Tool Repair</li>
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
        <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>Tool Repair</h3></span>
                        </div>
                      <div class="panel-body">
			            <p>Welcome to our Tool Repair Technical Page. This page is intended for professional repair shops to learn the proper techniques for repairing Alpha® tools. Included here are how-to videos, step-by-step documentation and links for necessary tools.</p>
                          <p>
                                    For more information on Alpha&reg;Tool Repairs, e-mail us at 
                   	                       <a href="mailto:tooldesk@alpha-tools.com">
                                            tooldesk@alpha-tools.com</a>  
                                    or contact our main office at (800) 648-7229.
                            </p></div>
                      <div><table class="table table-responsive">
<tbody>
<tr style="border-bottom: 1px solid #000">
 <td><a href="../ProductRegistration.aspx"><strong>Product Registration</strong></a>
 <a href="../ProductRegistration.aspx"><img style="padding-left: 5px; margin-top: 5px; float: left;" src="../images/polisher.jpg"/></a></td>
 <td><a href="../Pages/RepairCenters.aspx"><strong>Authorized Repair Centers</strong></a> <a href="../Pages/RepairCenters.aspx"><img style="padding-left: 5px; margin-top: 5px; float: left;" src="../images/repcenter.jpg"/></a></td>
</tr>
</tbody>
</table></div>     
<div><table class="table table-responsive">
<tbody>
<tr style="border-bottom: 1px solid #000">
 <td><a href="/files/docs/ToolRepair/ToolRepairTools-Alpha.pdf"><strong>Tool Repair Tools Available from Alpha®</strong><a href="/files/docs/ToolRepair/ToolRepairTools-Alpha.pdf"><img style="padding-left: 5px; margin-top: 5px; float: left;" src="../images/Tools-Alpha.jpg"/></a></td>
 
 <td><a href="/files/docs/ToolRepair/ToolRepairTools-McMaster.pdf"><strong>Tool Repair Tools Available from McMaster-Carr</strong></a> <a href="/files/docs/ToolRepair/ToolRepairTools-McMaster.pdf"><img style="padding-left: 5px; margin-top: 5px; float: left;" src="../images/Tools-McMaster-Carr.jpg"/></a></td>
</tr>
</tbody>
</table></div>                     
                     <table class="table table-responsive">
                                <tbody>
                                   <tr style="border-bottom: 1px solid #000">
                                  <td width="134" class="imgtd tdwidth">
                                            <div align="center"><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk"><img src="../files/Products/Misc/AIR-800_Series.jpg" alt="" name="AIR 800 Series" id="AIR 800 Series" width="100" height="100"></a></div>
                                     </td>
                         <td width="331" class="txttd">
                       <p><h3 style="color: #337ab7;">AIR 800 SERIES</h3></p>              <h4><a href="https://alphaprotools-my.sharepoint.com/:v:/g/personal/kjordan_alpha-tools_com/EYzlkWE7FvNBr-OveIn8Li4BdVHaec_MoJbUmDP94nJpTw?e=fIUbGv" target="_blank"><strong>Disassembly Video</strong></a></h4>
                                     
                                     <h4><a href="https://alphaprotools-my.sharepoint.com/:v:/g/personal/kjordan_alpha-tools_com/EeAJWYb2Z-hFrsXd9N1lpsUBpAJ5841bdywkOhf8cIL4Hw?e=zJtncM" target="_blank"><strong>Assembly Video</strong></a></h4>
 <%--<a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Disassembly Step-by-Step Instructions PDF</strong></a></h4>                                    <p><a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Assembly Step-by-Step Instructions PDF</strong></a>
                                       </h4>--%>
                                       <p><a href="../Pages/SparePartDetails.aspx?PageCode=2630" target="_blank"><strong>Spare Parts Page</strong></a>
                                       </h4>
                                     </p></tr>
                                     
                                 <%-- <tr style="border-bottom: 1px solid #000">
                                    
                                  <td width="134" class="imgtd tdwidth">
                                            <div align="center"><a href="../files/ToolRepair/AIR-800-Step-By-Step-Disassembly.pdf"><img src="../files/Products/parts/AIR-300.png" alt="" name="AIR 300 Series" id="AIR 300 Disassembly3" width="100" height="100" /></a><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk"></a></div>
                                    </td>
                                <td width="331" class="txttd">
                       <p>
                       <h3 style="color: #337ab7;">AIR 300 SERIES</h3>
                       </p>              <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Disassembly Video</strong></a></h4>
                                     <a href="/files/docs/ToolRepair/PDFs/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Disassembly Step-by-Step Instructions PDF</strong></a></h4>
                                     <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Assembly Video</strong></a></h4>
                                     <p><a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Assembly Step-by-Step Instructions PDF</strong></a>
                                       </h4>
                                       <p><a href="../Pages/SparePartDetails.aspx?PageCode=2630" target="_blank"><strong>Spare Parts Page</strong></a>
                                       </h4>
                                     </p></tr>
                                                                                  <tr style="border-bottom: 1px solid #000">
                                        <td class="imgtd tdwidth">
                                            <div align="center"><a href="../files/Toolrepair/AIR-800-Step-By-Step-Disassembly.pdf"><img src="../files/Products/parts/VSP-320.png" alt="" name="AIR 300 Series" id="AIR 300 Disassembly" width="100" height="100"></a></div></td>
                                <td width="331" class="txttd">
                       <p>                            <h3 style="color: #337ab7;">VSP 300 SERIES</h3>
                       </p>              <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Disassembly Video</strong></a></h4>
                                     <a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Disassembly Step-by-Step Instructions PDF</strong></a></h4>
                                     <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Assembly Video</strong></a></h4>
                                     <p><a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Assembly Step-by-Step Instructions PDF</strong></a>
                                       </h4>
                                       <p><a href="../Pages/SparePartDetails.aspx?PageCode=2630" target="_blank"><strong>Spare Parts Page</strong></a>
                                       </h4>
                                     </p></tr>
                                   <tr style="border-bottom: 1px solid #000">
                                        <td width="207" class="imgtd tdwidth"><div align="center"><a href="../files/ToolRepair/AIR-800-Step-By-Step-Disassembly.pdf"><img src="../files/Products/parts/PSC-600.png" alt="" name="PSC 600 Series" id="AIR 300 Disassembly2" width="100" height="100" /></a><a href="http://www.alpha-tools.com/files/Catalogs/PDFs/Construction_Catalog_v2.pdf"></a></div></td>      
                                         <td width="331" class="txttd">
                       <p>                            <h3 style="color: #337ab7;">PSC 600 SERIES</h3>
                       </p>              <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Disassembly Video</strong></a></h4>
                                     <a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Disassembly Step-by-Step Instructions PDF</strong></a></h4>
                                     <h4><a href="https://www.youtube.com/embed/H3sg-1Ox1Kk" target="_blank"><strong>Assembly Video</strong></a></h4>
                                     <p><a href="/files/docs/ToolRepair/AIR-800_Step-by-Step.pdf" target="_blank"><strong>Assembly Step-by-Step Instructions PDF</strong></a>
                                       </h4>
                                       <p><a href="../Pages/SparePartDetails.aspx?PageCode=2630" target="_blank"><strong>Spare Parts Page</strong></a>
                                       </h4>
                                     </p></tr>
                                  </tr>
                                    --%>
                               </tbody>
 
                            </table>
                                      
                        </div>               
                     </div>
                </div>
            </div>
     </section>

</asp:Content>


