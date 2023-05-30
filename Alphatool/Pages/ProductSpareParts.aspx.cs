using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class pages_ProductSpareParts : Page
{
    private string PageTitle = "";
    private int _CatagoryId = 0;
    private int _WebSectionId = 0;
    private int _WebGroupId = 0;
    private string pgName = "";
    private string bredCrumb = "";
    string imgSrc = "";
    string srcImg = "";

    private List<PartsPage> objPartsPage = new List<PartsPage>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["productId"] = null;
            Session["sparePartList"] = null;
            LoadControls();
            loadSEOContent();
            try
            {
                _CatagoryId = (Request.QueryString["CategoryId"] != null && Utility.IsNumeric(Request.QueryString["CategoryId"])) ? Convert.ToInt32(Request.QueryString["CategoryId"]) : 0;
                _WebSectionId = (Request.QueryString["SectionId"] != null && Utility.IsNumeric(Request.QueryString["SectionId"])) ? Convert.ToInt32(Request.QueryString["SectionId"]) : 0;
                _WebGroupId = (Request.QueryString["GroupId"] != null && Utility.IsNumeric(Request.QueryString["GroupId"])) ? Convert.ToInt32(Request.QueryString["GroupId"]) : 0;
            }
            catch
            {
                _CatagoryId = 0;
            }

            if (_CatagoryId > 0 && _WebSectionId > 0 && _WebGroupId == 0)
            {
                Session["categoryid"] = _CatagoryId;
                Session["WebSectionid"] = _WebSectionId;
                Session["WebGroupid"] = null;
                ProductByCategorySection(_CatagoryId, _WebSectionId);
                Session["CurrentGroup"] = null;
             //   LoadControls();
                //LoadControlsMb();
                LoadBannersIndustry();

            }
            else if (_CatagoryId > 0 && _WebSectionId > 0 && _WebGroupId > 0)
            {
                Session["categoryid"] = _CatagoryId;
                Session["WebSectionid"] = _WebSectionId;
                Session["WebGroupid"] = _WebGroupId;
                ProductByCategorySectionGroup(_CatagoryId, _WebSectionId, _WebGroupId);
                Session["CurrentGroup"] = null;
              //  LoadControls();
                //LoadControlsMb();
                LoadBannersIndustry();
            }

            else if (_CatagoryId > 0 && _WebSectionId == 0 && _WebGroupId == 0)
            {
                Session["categoryid"] = _CatagoryId;
                Session["WebSectionid"] = null;
                Session["WebGroupid"] = null;
                ProductByCategoryId(_CatagoryId);
                LoadBannersIndustry();

            }
            else if (_WebSectionId > 0 && _CatagoryId == 0 && _WebGroupId == 0)
            {
                Session["WebSectionid"] = _WebSectionId;
                Session["categoryid"] = null;
                Session["WebGroupid"] = null;
                ProductBySection(_WebSectionId);
                Session["CurrentGroup"] = null;
               // LoadControls();
                //LoadControlsMb();
                LoadBannersSection();
            }
            else if (_WebGroupId > 0 && _CatagoryId == 0)
            {
                Session["CurrentGroup"] = null;
              //  LoadControls();
                Session["categoryid"] = null;
                Session["WebGroupid"] = _WebGroupId;
                ProductByGroupId(_WebGroupId);
                LoadBannersSection();
            }
            else if (Session["SearchResult"] != null)
            {
                bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>Search Result</li>";
                Breadcrumb.InnerHtml = bredCrumb;
                productDiv.InnerHtml = Session["SearchResult"].ToString();
                Session["SearchResult"] = null;
            }

        }

        txtPartNo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_Body_btnSearch').click();return false;}} else {return true}; ");
        //txtPartNoMb.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearch').click();return false;}} else {return true}; ");
        txtProductName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_Body_btnSearch').click();return false;}} else {return true}; ");
        //txtProductNameMb.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearch').click();return false;}} else {return true}; ");
   
    }

    public void ProductByCategoryId(int categoryid)
    {
        try
        {
            MPPCIndustry objMppcIndustry = new MPPCIndustry();
            objMppcIndustry = new MppcIndustryDa().GetMPPCIndustrybyId(categoryid);

            Session["categoryid"] = objMppcIndustry.PPCIndustry;
            bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>" + objMppcIndustry.PPCIndustryName + "</li>";
            Page.Title = "Alpha Professional Tools® :: " + objMppcIndustry.PPCIndustryName;
            Breadcrumb.InnerHtml = bredCrumb;
            List<MPPCIndustrySectionGroupSpareParts> objReferenceTable = new List<MPPCIndustrySectionGroupSpareParts>();
            objReferenceTable = new MPPCIndustrySectionGroupSparePartsDa().GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(Convert.ToInt32(categoryid));
          
            if (objReferenceTable != null)
            {
                Session["sparePartList"] = objReferenceTable;
            }

            objReferenceTable = objReferenceTable.GroupBy(x => x.MWebSectionId, (key, x) => x.FirstOrDefault()).ToList();
            objReferenceTable = objReferenceTable.OrderBy(x => x.WebSectionSort).ToList();

            if (objReferenceTable != null)
            {
                if (objReferenceTable.Count > 0)
                {
                    pgName += "<div class='main col-md-12'>";
                    pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                    foreach (var websection in objReferenceTable)
                    {
                        var objIdustrySectionMap = new MppcIndustryDa().GetMPPCIndustrybyId(Convert.ToInt32(websection.MPPCInductryId));
                        List<MWebSection> objMWebSections = new List<MWebSection>();
                        objMWebSections = new MWebSectionDa().GetAllMWebSectionById(Convert.ToInt32(websection.MWebSectionId));
                        if (objMWebSections != null)
                            if (objMWebSections.Count > 0)
                            {
                                foreach (var section in objMWebSections)
                                {
                                    if (section.WebSection != "Discontinued")
                                    {
                                        if (section.CurrentYN == true)
                                        {
                                            srcImg = "/Images/Ind-Section-Thumb/" + objIdustrySectionMap.PPCIndustryName.ToString().Trim() +
                                                     "_" + section.WebSection.ToString().Trim() + ".jpg";
                                            if (!File.Exists(Server.MapPath(srcImg)))
                                            {
                                                srcImg = "/Images/not_found_image2.jpg";
                                            }

                                            pgName +=
                                                "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                                "<div class='listing-item_new'>" +
                                                "<div class='overlay-container'>" +
                                                "<a class='' href='ProductSpareParts.aspx?CategoryId=" +
                                                categoryid + "&SectionId=" + section.WebSectionID +
                                                "'><img class='category-section-imgdiv_new' width='120' alt='' src='" + srcImg + "'>" + "</a></div>";
                                            pgName +=
                                                "<div class='listing-item-body category-section-body_new clearfix'>" +
                                                "<h3>" +
                                                "<a href='ProductSpareParts.aspx?CategoryId=" +
                                                categoryid + "&SectionId=" +
                                                section.WebSectionID + "'>" +
                                                section.WebSection +
                                                "</a></h3></div></div></div>";
                                        }
                                    }
                                }

                            }
                    }
                    pgName += "</div>";
                    pgName += "</div>";
                    productDiv.InnerHtml = pgName;
                }
            }
        }
        catch (Exception ex)
        {
            //
        }

    }

    public void ProductByCategorySection(int categoryid, int websectionid)
    {
        try
        {
            MPPCIndustry objMppcIndustry = new MPPCIndustry();
            objMppcIndustry = new MppcIndustryDa().GetMPPCIndustrybyId(categoryid);
            Session["categoryid"] = objMppcIndustry.PPCIndustry;
            MWebSection objMWebSection = new MWebSection();
            objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(websectionid));
            Session["WebSectionName"] = objMWebSection.WebSection;
            bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li><a href='ProductSpareParts.aspx?CategoryId=" + categoryid + "'>" + objMppcIndustry.PPCIndustryName + "</a></li><li class='active'>" + objMWebSection.WebSection + "</li>";
            Breadcrumb.InnerHtml = bredCrumb;
            Page.Title = "Alpha Professional Tools® :: " + objMppcIndustry.PPCIndustryName + " - " + objMWebSection.WebSection;
            string grplst = "";

            List<MWebGroup> groupList = new List<MWebGroup>();
            groupList = new MWebGroupDa().GetAllMWebGroup().OrderBy(x => x.WebGroupSort).ToList();

            List<PartsPage> objPartsPagelist = new List<PartsPage>();
            List<PartsPage> objPartsPagelistNew = new List<PartsPage>();

            List<MPPCIndustrySectionGroupSpareParts> objReferenceTable = new List<MPPCIndustrySectionGroupSpareParts>();
          
            if (Session["sparePartList"] != null)
            {
                objReferenceTable = (List<MPPCIndustrySectionGroupSpareParts>)Session["sparePartList"];
            }
            else
            {
                objReferenceTable = new MPPCIndustrySectionGroupSparePartsDa().GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(Convert.ToInt32(categoryid));
                if (objReferenceTable != null)
                {
                    Session["sparePartList"] = objReferenceTable;
                }
            }

            objReferenceTable = objReferenceTable.Where(x => x.MWebSectionId == websectionid).ToList();
            objReferenceTable = objReferenceTable.GroupBy(x => x.MWebGroupId, (key, x) => x.FirstOrDefault()).ToList();
            objReferenceTable = objReferenceTable.OrderBy(x => x.MWebGroupId).ToList();

            groupList = groupList.Where(x => objReferenceTable.Any(y => y.MWebGroupId == x.WebGroupID)).ToList();                    
 
            if (groupList != null)
            {
                if (groupList.Count > 0)
                {
                    pgName += "<div class='main col-md-9'>";

                    foreach (var group in groupList)
                    {
                        grplst += "<li><a class='nobold' href='ProductSpareParts.aspx?CategoryId=" + categoryid + "&SectionId=" + websectionid + "&GroupId=" + group.WebGroupID + "'>" + group.WebGroup + "</a></li>";
                        pgName += "<span><a class='groupNameColor' href='ProductSpareParts.aspx?CategoryId=" + categoryid + "&SectionId=" + websectionid + "&GroupId=" + group.WebGroupID + "'>" + group.WebGroup + "<a></span><div class='separator-2'></div>";

                        if (Session["sparePartList"] != null)
                        {
                            objReferenceTable = (List<MPPCIndustrySectionGroupSpareParts>)Session["sparePartList"];
                        }
                        else
                        {
                            objReferenceTable = new MPPCIndustrySectionGroupSparePartsDa().GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(Convert.ToInt32(categoryid));
                            if (objReferenceTable != null)
                            {
                                Session["sparePartList"] = objReferenceTable;
                            }
                        }

                        objReferenceTable = objReferenceTable.Where(x => x.MWebSectionId == websectionid && x.MWebGroupId == group.WebGroupID).ToList();

                        objPartsPagelist = new PartsPageDa().GetAllPartsPageByGroupId(Convert.ToInt32(group.WebGroupID));

                        objPartsPagelistNew = objPartsPagelist.Where(x => objReferenceTable.Any(y => y.PartsPageCode == x.PartsPC)).ToList();

                        if (objReferenceTable != null)
                        {
                            if (objReferenceTable.Count > 0)
                            {
                                pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                                foreach (var product in objPartsPagelistNew)
                                {                                  
                                    //PartsPage objPartsPage = new PartsPage();
                                    //objPartsPage = new PartsPageDa().GetPartsPagebyPartCode(product.PartsPC);
                                    if (product.PPC != null)
                                    {
                                        if (!string.IsNullOrEmpty(product.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + product.ThumbNail)))
                                        {
                                            imgSrc = "/Files/Products/Thumbnails/" + product.ThumbNail;
                                        }
                                        else
                                        {
                                            imgSrc = "/Images/not_found_image.jpg";
                                        }
                                        pgName +=
                                            "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                            "<div class='listing-item'>" +
                                            "<div class='overlay-container'>" +
                                            "<a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" +
                                            "<img class='section-imgdiv' width='120' alt='' src='" + imgSrc + "'>" +
                                            "</a></div>";
                                        pgName +=
                                            "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" +
                                            product.PageName +
                                            "</a></h3></div></div></div>";
                                    }
                                }
                                pgName += "</div>";
                            }
                        }

                    }
                    pgName += "</div>";
                    prdgrplst.InnerHtml = grplst;  
                    productDiv.InnerHtml = pgName;

                }
            }

        }
        catch (Exception ex)
        {
            //
        }

    }

    public void ProductByCategorySectionGroup(int categoryid, int websectionid, int groupid)
    {
        try
        {
            MPPCIndustry objMppcIndustry = new MPPCIndustry();
            objMppcIndustry = new MppcIndustryDa().GetMPPCIndustrybyId(categoryid);
            Session["categoryid"] = objMppcIndustry.PPCIndustry;
            MWebSection objMWebSection = new MWebSection();
            objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(websectionid));
            Session["WebSectionName"] = objMWebSection.WebSection;
            MWebGroup objMWebGrouproduct = new MWebGroup();
            objMWebGrouproduct = new MWebGroupDa().GetMWebGroupbyId(groupid);
            bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li><a href='ProductSpareParts.aspx?CategoryId=" + Convert.ToInt32(Session["categoryid"]) + "'>" + objMppcIndustry.PPCIndustryName + "</a></li><li><a href='ProductSpareParts.aspx?CategoryId=" + objMppcIndustry.PPCIndustry + "&SectionId=" + objMWebSection.WebSectionID + "'>" + objMWebSection.WebSection + "</a></li><li class='active'>" + objMWebGrouproduct.WebGroup + "</li>";
            Breadcrumb.InnerHtml = bredCrumb;
            Page.Title = "Alpha Professional Tools® :: " + objMppcIndustry.PPCIndustryName + " - " + objMWebSection.WebSection + " - " + objMWebGrouproduct.WebGroup;
            List<PartsPage> objPartsPagelist = new List<PartsPage>();
            List<PartsPage> objPartsPagelistNew = new List<PartsPage>();
            LoadGroupListbyCategorySection(categoryid, websectionid);
            pgName += "<div class='main col-md-9'>";
            pgName += "<span class='spanGroupNameColor'>" + objMWebGrouproduct.WebGroup + "</span><div class='separator-2'></div>";
            objPartsPagelist = new PartsPageDa().GetAllPartsPageByGroupId(Convert.ToInt32(groupid));
            objPartsPagelist = objPartsPagelist.OrderBy(y => y.PageName).ToList();

            List<MPPCIndustrySectionGroupSpareParts> objReferenceTable = new List<MPPCIndustrySectionGroupSpareParts>();
            if (Session["sparePartList"] != null)
            {
                objReferenceTable = (List<MPPCIndustrySectionGroupSpareParts>)Session["sparePartList"];
            }
            else
            {
                objReferenceTable = new MPPCIndustrySectionGroupSparePartsDa().GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(Convert.ToInt32(categoryid));
                if (objReferenceTable != null)
                {
                    Session["sparePartList"] = objReferenceTable;
                }
            }

            objReferenceTable = objReferenceTable.Where(x => x.MWebSectionId == websectionid && x.MWebGroupId == groupid).ToList();

            if (objReferenceTable != null)
            {
                if (objReferenceTable.Count > 0)
                {
                    objPartsPagelistNew = objPartsPagelist.Where(x => objReferenceTable.Any(y => y.PartsPageCode == x.PartsPC)).ToList();

                    pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                    foreach (var product in objPartsPagelistNew)
                    {
                        //PartsPage objPartsPage = new PartsPage();
                        //objPartsPage = new PartsPageDa().GetPartsPagebyPartCode(product.PartsPC);
                        if (product.PPC != null)
                        {
                            if (!string.IsNullOrEmpty(product.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + product.ThumbNail)))
                            {
                                imgSrc = "/Files/Products/Thumbnails/" + product.ThumbNail;
                            }
                            else
                            {
                                imgSrc = "/Images/not_found_image.jpg";
                            }
                            pgName +=
                                "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                "<div class='listing-item'>" +
                                "<div class='overlay-container'>" +
                                "<a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" +
                                "<img class='section-imgdiv' width='120' alt='' src='" + imgSrc + "'>" +
                                "</a></div>";
                            pgName +=
                                "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" +
                                product.PPC + "'>" +
                                product.PageName +
                                "</a></h3>";
                            pgName += "</div></div></div>";
                        }
                    }
                    pgName += "</div>";
                }
            }
            pgName += "</div>";
            productDiv.InnerHtml = pgName;

        }
        catch (Exception)
        {
            //throw;
        }

    }

    public void ProductBySection(int websectionid)
    {
        try
        {
            MWebSection objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(websectionid));
            Session["WebSectionName"] = objMWebSection.WebSection;
            bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>" + objMWebSection.WebSection + "</li>";
            Page.Title = "Alpha Professional Tools® :: " + objMWebSection.WebSection;

            Breadcrumb.InnerHtml = bredCrumb;
            string grplst = "";

            List<MWebGroup> groupList = new MWebGroupDa().GetAllMWebGroup();
            groupList = groupList.OrderBy(x => x.WebGroupSort).ToList();

            objPartsPage = new PartsPageDa().GetAllPartsPageBySectionId(Convert.ToInt32(websectionid));
            objPartsPage = objPartsPage.GroupBy(x => x.WebGroupID, (key, x) => x.FirstOrDefault()).ToList();

            groupList = groupList.Where(x => objPartsPage.Any(y => y.WebGroupID == Convert.ToDouble(x.WebGroupID))).ToList();

            if (groupList.Count > 0)
            {
                pgName += "<div class='main col-md-9'>";
                foreach (var group in groupList)
                {
                    grplst += "<li><a class='nobold' href='ProductSpareParts.aspx?GroupId=" + group.WebGroupID + "'>" + group.WebGroup + "</a></li>";
                    pgName += "<span><a class='groupNameColor' href='ProductSpareParts.aspx?GroupId=" + group.WebGroupID + "'>" + group.WebGroup + "<a></span><div class='separator-2'></div>";
                    List<PartsPage> objPartsPagelist = new PartsPageDa().GetAllPartsPageByGroupId(Convert.ToInt32(group.WebGroupID));
                    objPartsPagelist = objPartsPagelist.OrderBy(y => y.PageName).ToList();
                    if (objPartsPagelist.Count > 0)
                    {
                        pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                        foreach (var product in objPartsPagelist)
                        {
                            List<PartsPage> objPartsPagelst = objPartsPagelist.Where(x => x.PartsPC == product.PartsPC).ToList();
                            if (objPartsPagelst.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(product.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + product.ThumbNail)))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + product.ThumbNail;
                                }
                                else
                                {
                                    imgSrc = "/Images/not_found_image.jpg";
                                }

                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" +
                                    "<img class='section-imgdiv' width='120' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";
                                pgName += "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" + product.PageName + "</a></h3>";
                                
                                pgName += "</div></div></div>";
                            }
                        }
                        pgName += "</div>";
                    }
                }
                pgName += "</div>";
                prdgrplst.InnerHtml = grplst;
                productDiv.InnerHtml = pgName;
            }
        }
        catch (Exception ex)
        {
            //
        }

    }

    public void ProductByGroupId(int webgroupid)
    {
        try
        {
            List<PartsPage> objPartsPagelist = new List<PartsPage>();
            List<PartsPage> objPartsPagelst = new List<PartsPage>();
            pgName += "<div class='main col-md-9'>";
            MWebGroup objMWebGroup = new MWebGroupDa().GetMWebGroupbyId(Convert.ToInt32(webgroupid));
            if (Session["WebSectionid"] != null)
            {
                MWebSection objMWebSection = new MWebSection();
                objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(Session["WebSectionid"]));
                Session["WebSectionName"] = objMWebSection.WebSection;
                Page.Title = "Alpha Professional Tools® :: " + objMWebSection.WebSection + " - " + objMWebGroup.WebGroup;

                bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li><a href='ProductSpareParts.aspx?SectionId=" + Convert.ToInt32(Session["WebSectionid"]) + "'>" + objMWebSection.WebSection + "</a></li><li class='active'>" + objMWebGroup.WebGroup + "</li>";
            }
            Breadcrumb.InnerHtml = bredCrumb;
            LoadGroupListbySection(Convert.ToInt32(Session["WebSectionid"]));
            pgName += "<span class='spanGroupNameColor'>" + objMWebGroup.WebGroup + "</span><div class='separator-2'></div>";
            objPartsPagelist = new PartsPageDa().GetAllPartsPageByGroupId(Convert.ToInt32(webgroupid));
            objPartsPagelist = objPartsPagelist.OrderBy(y => y.BannerName).ToList();
            if (objPartsPagelist != null)
            {
                if (objPartsPagelist.Count > 0)
                {
                    pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                    foreach (var product in objPartsPagelist)
                    {
                        objPartsPagelst = objPartsPagelist.Where(x => x.PartsPC == product.PartsPC).ToList();
                       
                        if (objPartsPagelst != null)
                        {
                            if (objPartsPagelst.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(product.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + product.ThumbNail)))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + product.ThumbNail;
                                }
                                else
                                {
                                    imgSrc = "/Images/not_found_image.jpg";
                                }
                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='SparePartDetails.aspx?PageCode=" + product.PPC + "'>" +
                                    "<img class='section-imgdiv' alt='' width='120' src='" + imgSrc + "'>" +
                                    "</a></div>";
                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" +
                                    product.PPC + "'>" +
                                    product.PageName + "</a></h3>";                               
                                pgName += "</div></div></div>";
                            }
                        }
                    }
                    pgName += "</div>";
                }
            }

            pgName += "</div>";
            productDiv.InnerHtml = pgName;

        }
        catch (Exception)
        {

            //throw;
        }

    }

    public void LoadGroupListbySection(int sectionid)
    {
        string grplst = "";
        List<MWebGroup> groupList = new MWebGroupDa().GetAllMWebGroup();
        groupList = groupList.OrderBy(x => x.WebGroupSort).ToList();

        objPartsPage = new PartsPageDa().GetAllPartsPageBySectionId(Convert.ToInt32(sectionid));
        objPartsPage = objPartsPage.GroupBy(x => x.WebGroupID, (key, x) => x.FirstOrDefault()).ToList();

        groupList = groupList.Where(x => objPartsPage.Any(y => y.WebGroupID == Convert.ToDouble(x.WebGroupID))).ToList();
        if (groupList.Count > 0)
        {
            foreach (var group in groupList)
            {
                if (Convert.ToInt32(Session["WebGroupid"]) == group.WebGroupID)
                {
                    grplst += "<li><a style='color:blue;' href='ProductSpareParts.aspx?GroupId=" + group.WebGroupID + "'>" +
                              group.WebGroup + "</a></li>";
                }
                else
                {
                    grplst += "<li><a class='nobold' href='ProductSpareParts.aspx?GroupId=" + group.WebGroupID + "'>" +
                              group.WebGroup + "</a></li>";
                }
            }
            prdgrplst.InnerHtml = grplst;
        }
    }

    public void LoadGroupListbyCategorySection(int categoryid, int sectionid)
    {
        string grplst = "";
        List<MWebGroup> groupList = new MWebGroupDa().GetAllMWebGroup();
        groupList = groupList.OrderBy(x => x.WebGroupSort).ToList();

        List<MPPCIndustrySectionGroupSpareParts> objReferenceTable = new List<MPPCIndustrySectionGroupSpareParts>();
        if (Session["sparePartList"] != null)
        {
            objReferenceTable = (List<MPPCIndustrySectionGroupSpareParts>)Session["sparePartList"];
        }
        else
        {
            objReferenceTable = new MPPCIndustrySectionGroupSparePartsDa().GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(Convert.ToInt32(categoryid));
            if (objReferenceTable != null)
            {
                Session["sparePartList"] = objReferenceTable;
            }
        }

        objReferenceTable = objReferenceTable.Where(x => x.MWebSectionId == sectionid).ToList();

        objReferenceTable = objReferenceTable.GroupBy(x => x.MWebGroupId, (key, x) => x.FirstOrDefault()).ToList();

        groupList = groupList.Where(x => objReferenceTable.Any(y => y.MWebGroupId == x.WebGroupID)).ToList();
        if (groupList.Count > 0)
        {
            foreach (var group in groupList)
            {
                if (Convert.ToInt32(Session["WebGroupid"]) == group.WebGroupID)
                {
                    grplst += "<li><a style='color:blue;' href='ProductSpareParts.aspx?CategoryId=" + categoryid + "&SectionId=" + sectionid + "&GroupId=" + group.WebGroupID + "'>" +
                              group.WebGroup + "</a></li>";
                }
                else
                {
                    grplst += "<li><a class='nobold' href='ProductSpareParts.aspx?CategoryId=" + categoryid + "&SectionId=" + sectionid + "&GroupId=" + group.WebGroupID + "'>" +
                              group.WebGroup + "</a></li>";
                }
            }

            prdgrplst.InnerHtml = grplst;
        }
    }
    
    public void LoadBannersIndustry()
    {

        try
        {
            string sLink = "";
            string sImage = "";
            string sTitle = "";
            string sBannerHTML = "";
            DataTable dtHomeBanner = new DataTable();
            if (Convert.ToInt32(Session["categoryid"]) > 0)
            {
                dtHomeBanner = WebUtility.GetRows("SELECT m.PPCIndustryImage, m.PPCIndustryLink FROM MPPCIndustry m WHERE m.PPCIndustry=" + Convert.ToInt32(Session["categoryid"]) + "");
            }


            if (dtHomeBanner != null && dtHomeBanner.Rows.Count > 0)
            {
                foreach (DataRow dr in dtHomeBanner.Rows)
                {
                    try
                    {
                        if (dr["PPCIndustryLink"] != null && dr["PPCIndustryLink"].ToString() != "")
                        {
                            sLink = dr["PPCIndustryLink"].ToString();
                        }
                        if (dr["PPCIndustryImage"] != null && dr["PPCIndustryImage"].ToString() != "")
                        {
                            if (dr["PPCIndustryImage"] != null)
                            {
                                sImage = "/Images/Banners-Industry/" + dr["PPCIndustryImage"].ToString();
                            }
                            else
                            {
                                sImage = "/Images/not_found_image.jpg";
                            }
                        }

                        sBannerHTML += "<a href='" + sLink.Trim() + "'><img src='" + sImage.Trim() + "' alt='' data-bgposition='center top' data-bgfit='cover' data-bgrepeat='no-repeat' /></a>";
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }

            BannerHome.InnerHtml = sBannerHTML.Trim();

        }
        catch (Exception ex)
        {
            //
        }


    }

    public void LoadBannersSection()
    {

        try
        {
            string sLink = "";
            string sImage = "";
            string sTitle = "";
            string sBannerHTML = "";
            DataTable dtHomeBanner = new DataTable();
            if (Convert.ToInt32(Session["WebSectionid"]) > 0)
            {
                dtHomeBanner = WebUtility.GetRows("SELECT ms.WebSectionImage, ms.WebSectionLink FROM MWebSection ms WHERE ms.WebSectionID=" + Convert.ToInt32(Session["WebSectionid"]) + "");
            }

            if (dtHomeBanner != null && dtHomeBanner.Rows.Count > 0)
            {
                foreach (DataRow dr in dtHomeBanner.Rows)
                {
                    try
                    {
                        if (dr["WebSectionLink"] != null && dr["WebSectionLink"].ToString() != "")
                        {
                            sLink = dr["WebSectionLink"].ToString();
                        }
                        if (dr["WebSectionImage"] != null && dr["WebSectionImage"].ToString() != "")
                        {
                            if (dr["WebSectionImage"] != null)
                            {
                                sImage = "/Images/Banners-Section/" + dr["WebSectionImage"].ToString();
                            }
                            else
                            {
                                sImage = "/Images/not_found_image.jpg";
                            }
                        }

                        sBannerHTML += "<a href='" + sLink.Trim() + "'><img src='" + sImage.Trim() + "' alt='' data-bgposition='center top' data-bgfit='cover' data-bgrepeat='no-repeat'/></a>";

                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }
            BannerHome.InnerHtml = sBannerHTML.Trim();
        }
        catch (Exception ex)
        {
            //
        }
    }

    public void LoadSectionImages(int categoryid, int sectionid)
    {
        try
        {
            if (sectionid == 10)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Cutting.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Cutting.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Cutting.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Cutting.png";
                }
            }

            if (sectionid == 20)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Profiling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Profiling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Profiling.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Profiling.png";
                }
            }

            if (sectionid == 30)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Grinding.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Grinding.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Grinding.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Profiling.png";
                }
            }

            if (sectionid == 40)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Drilling.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Drilling.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Drilling.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Drilling.png";
                }
            }

            if (sectionid == 50)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Accessories.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Accessories.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Accessories.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Accessories.png";
                }
            }

            if (sectionid == 60)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Polishing.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Polishing.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Polishing.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Polishing.png";
                }
            }

            if (sectionid == 70)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Restoration.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Restoration.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Restoration.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Restoration.png";
                }
            }

            if (sectionid == 80)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_educational.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_educational.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/educational.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/educational.png";
                }
            }

            if (sectionid == 100)
            {
                if (categoryid == 2)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Stone_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Stone_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else if (categoryid == 3)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Tile_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Tile_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else if (categoryid == 4)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Concrete_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Concrete_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else if (categoryid == 5)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Industrial_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Industrial_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else if (categoryid == 6)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Automotive_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Automotive_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else if (categoryid == 7)
                {
                    if (File.Exists(Server.MapPath("/Images/Ind-Section-Thumb/Composite_Tools.jpg")))
                    {
                        srcImg = "/Images/Ind-Section-Thumb/Composite_Tools.jpg";
                    }
                    else
                    {
                        srcImg = "/Images/Icons/Tools.png";
                    }
                }
                else
                {
                    srcImg = "/Images/Icons/Tools.png";
                }
            }

        }
        catch (Exception)
        {
            //throw;
        }
    }

    private void loadSEOContent()
    {
        try
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "keywords";
            hm.Content = "buffing tools, buffing pads, drilling tools, cutting blades, cutting tools, cutting systems, cutting wheel, diamond tools, diamond saw blades, diamond polishing pads, grinding wheel, grinding tools industrial abrasives, pneumatic air tools, polishers, polishing pads, polishing tools, polishing wheels, polishing discs, profiling tools, profiling wheels, router bits, scratch removal, stain removers, stone cutter, stone polishing, core bits, flush cutting blades, groove cutting blades, dry cutting blades, wet cutting blades, diamond cutting blades, marble cutting tools, diamond cutting tools, edge polishers, tile profiling wheels, diamond profiling wheels, rust stain removers, stone stain removers, stone polishing machinery, stone polishing tools, wet concrete core bits, dry core bits";
            this.metaTags.Controls.Add(hm);

            HtmlMeta hm2 = new HtmlMeta();
            hm2.Name = "description";
            hm2.Content = "Contact Alpha Professional Tools® headquarters, factory service center or sales contacts with any questions or comments regarding the cutting, drilling, grinding, polishing & profiling tools offered.";
            this.metaTags.Controls.Add(hm2);
        }
        catch (Exception ex)
        {

        }
    }

    public void LoadControls()
    {        

        try
        {
            ddlCategory.Items.Clear();
            ddlCategory.AppendDataBoundItems = true;
            ddlCategory.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtCategory = new DataTable();
            dtCategory = WebUtility.GetRows("select * from MPPCIndustry where PPCIndustry > 1");
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCategory.Rows)
                {
                    ddlCategory.Items.Add(new ListItem(dr["PPCIndustryName"].ToString(), dr["PPCIndustry"].ToString()));
                }
            }

            ddlCategory.DataBind();
            ddlCategory.SelectedValue = "-1";
        }
        catch (Exception ex)
        {
            //
        }
    }

    protected void btnSearchNew_Click(object sender, EventArgs e)
    {
        try
        {
            bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li><a href='ProductSpareParts.aspx?SectionId=120'>Spare Parts</a></li><li class='active'>Search Result</li>";
            Breadcrumb.InnerHtml = bredCrumb;
            string grplst = string.Empty;
            string sWhere = string.Empty;
            string sSQL = "";
          
            if (ddlCategory.SelectedValue != "-1")
            {
                sWhere += " AND pp.PPC IN (SELECT mi.PPCIndustryLink  FROM MPPCIndustrySectionGroupSpareParts mi WHERE mi.MPPCInductryId = '" + ddlCategory.SelectedValue + "') ";
            }
            if (txtPartNo.Text.ToString().Trim().Length > 0)
            {
                sWhere += " and pp.PartsPC IN (SELECT wt.PartsPageCode FROM PartsWebfields wt WHERE wt.PartNo LIKE '%" + txtPartNo.Text.ToString().Trim() + "%') ";
            }

            if (txtProductName.Text.ToString().Trim().Length > 0)
            {
                sWhere += " and pp.PageName like  '%" + txtProductName.Text.ToString().Trim() + "%' ";
            }

            sSQL = "SELECT * FROM PartsPage pp WHERE pp.PPC > 0  " + sWhere;

            if (sSQL.Length > 0)
            {
                sSQL += " ORDER BY pp.WebSectionID asc, pp.WebGroupID asc";
                DataTable dtProducts = new DataTable();
                dtProducts = WebUtility.GetRows(sSQL);
                int nCount = 0;
                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    pgName = "<div class='main col-md-9'>";
                    foreach (DataRow dr in dtProducts.Rows)
                    {
                        if (Convert.ToInt32(dr["WebGroupID"]) != 8400 && Convert.ToInt32(dr["WebGroupID"]) != 8600 && Convert.ToInt32(dr["WebGroupID"]) != 8610 && Convert.ToInt32(dr["WebGroupID"]) != 8620 && Convert.ToInt32(dr["WebGroupID"]) != 8630 && Convert.ToInt32(dr["WebGroupID"]) != 8640 && Convert.ToInt32(dr["WebGroupID"]) != 8650 && Convert.ToInt32(dr["WebGroupID"]) != 8660 && Convert.ToInt32(dr["WebGroupID"]) != 8670 && Convert.ToInt32(dr["WebGroupID"]) != 8680)
                        {
                            if (Session["CurrentGroup"] == null ||
                                (Session["CurrentGroup"] != null &&
                                 Convert.ToInt32(Session["CurrentGroup"].ToString()) !=
                                 Convert.ToInt32(dr["WebGroupID"].ToString())))
                            {
                                nCount = nCount + 1;
                                Session["CurrentGroup"] = dr["WebGroupID"];
                                MWebGroup objMWebGroup =
                                    new MWebGroupDa().GetMWebGroupbyId(Convert.ToInt32(dr["WebGroupID"]));
                                if (nCount > 1)
                                {
                                    pgName += "</div>";
                                }
                                grplst += "<li><a class='nobold' href='ProductSpareParts.aspx?GroupId=" + objMWebGroup.WebGroupID + "'>" + objMWebGroup.WebGroup + "</a></li>";
                                pgName += "<span><a class='groupNameColor' href='ProductSpareParts.aspx?GroupId=" +
                                          objMWebGroup.WebGroupID + "'>" + objMWebGroup.WebGroup +
                                          "<a></span><div class='separator-2'></div>";

                                pgName +=
                                    "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";

                             
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + dr["ThumbNail"])))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + dr["ThumbNail"];
                                }
                                else
                                {
                                    imgSrc = "/Images/not_found_image.jpg";
                                }
                                

                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='SparePartDetails.aspx?PageCode=" + dr["PPC"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" +
                                    dr["PPC"] + "'>" + dr["PageName"] + "</a></h3>";                                
                                pgName += "</div></div></div>";
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + dr["ThumbNail"])))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + dr["ThumbNail"];
                                }
                                else
                                {
                                    imgSrc = "/Images/not_found_image.jpg";
                                }

                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='SparePartDetails.aspx?PageCode=" + dr["PPC"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='SparePartDetails.aspx?PageCode=" +
                                    dr["PPC"] + "'>" + dr["PageName"] + "</a></h3>";
                                                              
                                pgName += "</div></div></div>";
                            }
                        }
                    }
                    pgName += "</div>";
                    pgName += "</div>";
                    productDiv.InnerHtml = pgName;
                    prdgrplst.InnerHtml = grplst;
                }
                else
                {
                    productDiv.InnerHtml = "Parts Not Found";
                }
            }
            else
            {
                productDiv.InnerHtml = "Parts Not Found";
            }

        }
        catch (Exception ex)
        {
            //
        }
    }
}
