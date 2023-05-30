using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    string PageTitle = "";
    string pgName = "";
    string srcImg = "";
    protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            Session["PageName"] = null;
            Session["PageTitle"] = null;
            LoadBodyContents();
            LoadBanners();
            Page.Title = "Alpha Professional Tools";
        }
    }

    public void btnMemberLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Pages/Account/Login.aspx");
    }

    public void LoadBodyContents()
    {
        pgName += "<div class='main col-md-12'>";
        try
        {
            
            List<MWebSection> objMWebSections = new List<MWebSection>();
            objMWebSections = new MWebSectionDa().GetAllMWebSection().ToList();
            objMWebSections = objMWebSections.OrderBy(x => x.WebSectionSort).ToList();
            if (objMWebSections != null)
            {
                if (objMWebSections.Count > 0)
                {
                    foreach (var section in objMWebSections)
                    {
                        if (section.WebSection != "Discontinued")
                        {
                            if (section.CurrentYN == true)
                            {
                                srcImg = "Images/Icons/" + section.WebSectionIcon;
                                pgName +=
                                    "<div class='col-sm-4'>" +
                                    "<div class='box-style-2'>" +
                                    "<div class='icon-container'> " ;
                                if (section.WebSectionID == 90)
                                {
                                    pgName += "<a class='link' href='Pages/NewProducts.aspx'>" +
                                    "<img class='img-responsive' alt='' src='" + srcImg + "'>" +
                                    "</a></div>";
                                    pgName +=
                                        "<div class='body'>" +
                                        "<h2 class='SubCatTitle'>" +
                                        "<a class='link' href='Pages/NewProducts.aspx'>" +
                                        section.WebSection + "</a>" + "</h3>" +
                                        "<p>" + section.WebDescription + "" +
                                        "...</p><a class='link see-more' href='Pages/NewProducts.aspx'> See More >> </a>" +
                                        "</div>" +
                                        "</div>" +
                                        "</div>";
                                }
                                else if (section.WebSectionID == 80)
                                {
                                    pgName += "<a class='link' href='Pages/EducationalMetarials.aspx'>" +
                                    "<img class='img-responsive' alt='' src='" + srcImg + "'>" +
                                    "</a></div>";
                                    pgName +=
                                        "<div class='body'>" +
                                        "<h2 class='SubCatTitle'>" +
                                        "<a class='link' href='Pages/EducationalMetarials.aspx'>" +
                                        section.WebSection + "</a>" + "</h3>" +
                                        "<p>" + section.WebDescription + "" +
                                        "...</p><a class='link see-more' href='Pages/EducationalMetarials.aspx'> See More >> </a>" +
                                        "</div>" +
                                        "</div>" +
                                        "</div>";
                                }
                                else if (section.WebSectionID == 120)
                                {
                                    pgName += "<a class='link' href='Pages/ProductSpareParts.aspx?SectionId=" + section.WebSectionID + "'>" +
                                    "<img class='img-responsive' alt='' src='" + srcImg + "'>" +
                                    "</a></div>";
                                    pgName +=
                                        "<div class='body'>" +
                                        "<h2 class='SubCatTitle'>" +
                                        "<a class='link' href='Pages/ProductSpareParts.aspx?SectionId=" + section.WebSectionID + "'>" +
                                        section.WebSection + "</a>" + "</h3>" +
                                        "<p>" + section.WebDescription + "" +
                                        "...</p><a class='link see-more' href='Pages/ProductSpareParts.aspx?SectionId=" + section.WebSectionID + "'> See More >> </a>" +
                                        "</div>" +
                                        "</div>" +
                                        "</div>";
                                }
                                else
                                {
                                    pgName += "<a class='link' href='Pages/ProductPages.aspx?SectionId=" + section.WebSectionID + "'>" +
                                    "<img class='img-responsive' alt='' src='" + srcImg + "'>" +
                                    "</a></div>";
                                    pgName +=
                                        "<div class='body'>" +
                                        "<h2 class='SubCatTitle'>" +
                                        "<a class='link' href='Pages/ProductPages.aspx?SectionId=" + section.WebSectionID + "'>" +
                                        section.WebSection + "</a>" + "</h3>" +
                                        "<p>" + section.WebDescription + "" +
                                        "...</p><a class='link see-more' href='Pages/ProductPages.aspx?SectionId=" + section.WebSectionID + "'> See More >> </a>" +
                                        "</div>" +
                                        "</div>" +
                                        "</div>";
                                }
                            }
                        }
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            //
        }
        pgName += "</div>";

        sectionDiv.InnerHtml = pgName;
    }

    public void LoadBanners()
    {

        try
        {
            string sLink = "";
            string sImage = "";
            string sTitle = "";
            string sBannerHTML = "";
            DataTable dtHomeCarousel = new DataTable();
            dtHomeCarousel = WebUtility.GetRows("SELECT HomeProductsNo, HPName, HPImage, HPLink, CurrentYN  FROM HomeProducts WHERE CurrentYN = 1 ORDER BY Sort ASC ");
            if (dtHomeCarousel != null && dtHomeCarousel.Rows.Count > 0)
            {
                foreach (DataRow dr in dtHomeCarousel.Rows)
                {
                    try
                    {
                        if (dr["HPName"] != null && dr["HPName"].ToString() != "")
                        {
                            sTitle = dr["HPName"].ToString();
                        }
                        if (dr["HPLink"] != null && dr["HPLink"].ToString() != "")
                        {
                            sLink = dr["HPLink"].ToString();
                        }
                        if (dr["HPImage"] != null && dr["HPImage"].ToString() != "")
                        {
                            if (dr["HPImage"] != null)
                            {
                                if (File.Exists(Server.MapPath("/Files/Products/Carousel/" + dr["HPImage"])))
                                {
                                    sImage = "/Files/Products/Carousel/" + dr["HPImage"].ToString();
                                    sBannerHTML += "<div style='border:1px solid #337ab7; margin:5px;'>" +
                                                   "<div class='client' style='margin:0 auto;'><a style='font-weight:bold;' title='" + sTitle.Trim() + "' href='" +
                                      sLink.Trim() + "'> <img src='" + sImage.Trim() + "'></a></div></div>";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }

            carouselHome.InnerHtml = sBannerHTML.Trim();

        }
        catch (Exception ex)
        {
            //
        }


    }
}