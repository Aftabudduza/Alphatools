<%@ Page Title="Alpha Professional Tools® :: Sitemap" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Pages_Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
       #cont ul li a, ul ul li a {
            color:#337ab7 !important;
            text-decoration:underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
                <li><i class="fa fa-home pr-10"></i>
                    <a href="/Default.aspx">Home</a></li>
                <li class="active">Sitemap</li>
            </ol>
    </div>

    <section class="main-container" style="margin-top: 0px;">
           <div class="row">
                <div class="main col-md-12">
                    <h2 class="page-title margin-top-clear" id="productTitle" runat="server">Sitemap</h2>
                        <div id="cont" class="main col-md-6">
							<ul style="margin-top: 0; ">
								<li>
									<a href="WhatsNew.aspx" title="What's New">What's New</a> <br />
									Check out what’s new at Alpha Professional Tools&reg;, including information about the company's current activities, locations, products and team members. 
								</li>
								<li>
									<a href="Calendar.aspx" title="Calendar of Events">Calendar of Events</a><br />
									A list of events and expos in the stone, tile, concrete and metal and industries including the StonExpo, World of Concrete, Surfaces, Fabtech and Coverings.
								</li>
								<li>
									<a href="ProductBulletins.aspx" title="Product Bulletins">Product Bulletins</a><br />
									Get the latest enhancements and safety information for your Alpha&reg; products.
								</li>
								<li>
									<a href="Library.aspx" title="Technical Library">Technical Library</a><br />
									Valuable technical information including TechNotes and MSDS as well as manuals, flyers and parts lists. 
								</li>
								<li>
									<a href="RequestADealerInfo.aspx" title="Request Dealer Info">Request Dealer Info</a><br />
									Find a local distributor of quality tools for any type of material.  
								</li>
								<li>
									<a href="Affiliations.aspx" title="Affiliations">Affiliations</a><br />
									Alpha&reg; offers a list of affiliations in the stone, tile and concrete industries. 
								</li>
								<li>
									<a href="LinksAndAffiliations.aspx" title="Links">Links</a><br />
									Alpha&reg; offers a list of resources to help keep you updated about the stone, tile and concrete industries.
								</li>
								<li>
									<a href="AboutUs.aspx" title="About Us">About Us</a><br />
									Learn about the company and the history of Alpha Professional Tools&reg; and how it a leading manufacturer of quality professional tooling. 
								</li>
								<li>
									<a href="ContactUs.aspx" title="Contact Us">Contact Us</a><br />
									Contact us with any questions or comments about our professional tools for cutting, drilling, grinding, polishing &amp; profiling.
								</li>
								<li>
									<a href="Policies.aspx" title="Policies">Policies</a><br />
									Alpha Professional Tools&reg; policies include information on purchasing products and parts, pricing, sales tax, freight, warranty, repairs, loaner tools, returns, cautions and warnings.
								</li>
								<li>
									<a href="Employment.aspx" title="Employment">Employment</a><br />
									Alpha&reg; is always looking for qualified professionals to join our team.
								</li>
								<li>
									<a href="/Default.aspx" title="Home">Home</a><br />
									Alpha Professional Tools&reg; Home Page. 
								</li>
								<li>
									<a href="ProductRegistration.aspx" title="Home">Product Registration</a><br />
									Register your new tool to activate the warranty. 
								</li>

							
								<li>
									<a href="ProductPages.aspx?SectionId=8600" title="Close Outs">Close Outs and Discontinued Products</a><br />
									Great deals on over stock  and discontinued items. 								
                                </li>							
		                        <li>
									<a href="Quivers.aspx" title="Ecommerce">Ecommerce</a><br />
									Purchase product online and have a local dealer ship directly to you.
								</li>
									<li>
									<a href="ProductCatalogs.aspx" title="Catalogs">Product Catalogs</a><br />
									Download catalogs to suit your application. 
								</li>
		                        <li>
									<a href="MoistureCalculator.aspx" title="Moisture Calculator">Moisture Calculator</a><br />
									Use this form to calculate the moisture emmissions. 
								</li>
                                <li>
                                    <a href="EducationalMaterials.aspx" title="Learn More">Educational Materials</a><br />
                                    Educational and instructional DVD's providing how-to information about our product line.
                                </li>
                                <li>
                                    <a href="NewProducts.aspx" title="Learn More">New Products</a><br />
                                    Alpha® offers new and innovative products for cutting, drilling, profiling and polishing for all types of materials.
                                </li>
                              </ul>
						</div>
                         <div class="main col-md-6">
                             <ul style="margin-top: 0; list-style-type:none;" id="ulCategory" runat="server">			                      
                               </ul>
                        </div>
                  </div>
            </div>
    </section>
</asp:Content>

