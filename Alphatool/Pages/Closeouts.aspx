<%@ Page Title="Product Catalogs" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="ProductCatalogs.aspx.cs" Inherits="pages_ProductCatalogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
    <style type="text/css">
        @media screen and (min-width: 768px) and (max-width: 1920px) {
             
                .imgtd {
             padding-left: 40% !important;
             width: 28%;
         }
        .txttd {
            width: 28%;
        }
            }
        
         
        @media screen and (min-width: 320px) and (max-width: 360px) {
            .tdwidth {
                width: 28%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
         <ol id="Breadcrumb" class="breadcrumb">
                <li><i class="fa fa-home pr-10"></i>
                    <a href="/Default.aspx">Home</a></li>
                <li class="active">Closeouts</li>
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px; font-size: medium;">
        <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>Closeouts and Discontinued Products</h3></span>
                        </div>
                      <div class="panel-body">
				            <p>
					 The following products are on clearance as we have discontinued production on them. We will sell until our stock has been depleted. </p>
			            <p style="color:#337ab7;"><strong>Good News: We have also REDUCED THE PRICES!</strong></p>
				            <p>Select a product name, then choose the <strong>BUY NOW</strong> tab to purchase.</p>
                        <p>
                                      If you have any questions, or need more information,  e-mail us at <a href="mailto:info@alpha-tools.com"> info@alpha-tools.com</a>  
	                                  or contact our main office at (800) 648-7229.
                                </p>
  </td>
</tr>
<hr class="color" />
                                                           
                          <table class="table table-responsive">
                             <tbody>
                               <tr style="border-bottom: 1px solid #000">
                  <td class="imgtd tdwidth">
                  <div align="center"><a href="https://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1750"><img src="http://www.alpha-tools.com/files/Products/Photos/1750B.jpg" alt="" name="Ceramica Edge Polishing Discs" id="Hand Tooling" width="100" height="100" /></a></td>
 <td> <a href="https://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1750" target="_blank"><strong>Ceramica Edge Polishing Discs</strong></a></td>
                   </tr>
							<tr style="border-bottom: 1px solid #000">
           					  <td class="imgtd tdwidth">
                                            <div align="center">
 <a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1420"><img src="http://www.alpha-tools.com/files/Products/Photos/1420B.jpg" alt="" name="CNC Segmented Finger Bits" id="CNC Segmented Finger Bits" width="100" height="100" /></a></td>
 <td>
<a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1420" target="_blank"><strong>CNC Segmented Finger Bits</strong></a></td>
  
  </tr>       
                               <tr style="border-bottom: 1px solid #000">
                                      <td class="imgtd tdwidth">
                                          <div align="center"><a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1740"><img src="http://www.alpha-tools.com/files/Products/Photos/1740B.jpg" alt="" name="Moisture Test Kit for Calculating Vapor Emissions" id="Moisture Test Kit for Calculating Vapor Emissions" width="100" height="100"></a></div>
                                      </td>
                                       <td class="txttd"><h4><a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1740" target="_blank"><strong>Moisture Test Kit for Calculating Vapor Emissions</strong></a></h4>
                                 </td>
                                           
                               <tr style="border-bottom: 1px solid #000">
                                      <td class="imgtd tdwidth">
                                          <div align="center"><a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1260"><img src="http://www.alpha-tools.com/files/Products/Photos/1260D.jpg" alt="" name="Smart Trowel Kit with Ergonomic Handle" id="Smart Trowel Kit with Ergonomic Handle" width="100" height="100"></a></div>
                                 </td>
                                       <td class="txttd"><h4><a href="http://www.alpha-tools.com/Pages/ProductDetails.aspx?PageCode=1260" target="_blank"><strong>Smart Trowel Kit with Ergonomic Handle</strong></a></h4>
                                 </td>
                                </tr>
                            </tbody>    
                        </table>
                         <hr class="color" />
                      </div>               
                     </div>
                </div>
            </div>
     </section>

</asp:Content>


