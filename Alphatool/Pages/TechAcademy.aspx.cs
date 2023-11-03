using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Pages_TechAcademy : System.Web.UI.Page
{
    private string pgName = "";
    private string bredCrumb = "";
    string imgSrc = "";
    private List<ProductPage> objProductPage = new List<ProductPage>();
    private readonly String _strWebUrl = System.Configuration.ConfigurationManager.AppSettings.Get("WebUrl");
    private int _CatagoryId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString);
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        if (!IsPostBack)
        {
            lblYear.Text = DateTime.Now.Year.ToString();
            Session["CurrentGroup"] = null;
            Session["SearchResult"] = null;
            Session["CurrentPPC"] = null;
            Session["CurrentWebSection"] = null;
            Session["CurrentWebGroup"] = null;
            Session["dsVideo"] = null;
            Session["sMenuTop"] = null;
            LoadControls();
            loadHeaderMenu();
            ddlPPCIndustry.SelectedValue = "2";
            loadVideosBySelection(2);

        }

        txtSearchTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchTopN').click();return false;}} else {return true}; ");
                     
        _CatagoryId = (Request.QueryString["CategoryId"] != null && Utility.IsNumeric(Request.QueryString["CategoryId"])) ? Convert.ToInt32(Request.QueryString["CategoryId"]) : 0;

    }
    private void loadHeaderMenu()
    {
        string html = "";
        int i = 0;
       // string sToplink = "<p style='text-align: center;'><a target='_self' href='#div10'>Hardscape</a> ";
        string sToplink = "<p style='text-align: center;'>";
        try
        {
            List<MPPCIndustry> categoryMenu = new MppcIndustryDa().GetAllMPPCIndustry();
            if (categoryMenu != null)
            {
                foreach (var menu in categoryMenu)
                {
                    if (menu.PPCIndustry != 1)
                    {
                        i += 1;
                        if (_CatagoryId == menu.PPCIndustry)
                        {
                            html += "<li><a style='font-weight:bold; color: #337ab7;' title='" + menu.PPCIndustryName + "' href='" + _strWebUrl + "../Pages/ProductPages.aspx?CategoryId=" + menu.PPCIndustry + "'>" +
                                    menu.PPCIndustryName + "</a></li>";
                        }
                        else
                        {
                            html += "<li><a style='font-weight:bold;' title='" + menu.PPCIndustryName + "' href='" + _strWebUrl + "../Pages/ProductPages.aspx?CategoryId=" + menu.PPCIndustry + "'>" +
                                  menu.PPCIndustryName + "</a></li>";
                        }

                        if (i == 1)
                        {
                            sToplink += " <a target='_self' href='#div" + menu.PPCIndustry + "'>" +
                                        menu.PPCIndustryName + "</a>";
                        }
                        else
                        {
                            sToplink += " | <a target='_self' href='#div" + menu.PPCIndustry + "'>" +
                                       menu.PPCIndustryName + "</a>";
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {

        }

        sToplink += "</p>";

      //  CategoryMenus.InnerHtml = html;

        ppcTop.InnerHtml = sToplink;
        Session["sMenuTop"] = sToplink;
    }
    public void LoadControls()
    {
        try
        {
            ddlProcessTop.Items.Clear();
            ddlProcessTop.AppendDataBoundItems = true;
            ddlProcessTop.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtProcess = new DataTable();
            dtProcess = WebUtility.GetRows("select * from MProcess where ProcessID > 0");
            if (dtProcess != null && dtProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProcess.Rows)
                {
                    ddlProcessTop.Items.Add(new ListItem(dr["Process"].ToString(), dr["ProcessID"].ToString()));
                }
            }

            ddlProcessTop.DataBind();
            ddlProcessTop.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

        try
        {
            ddlUsageTop.Items.Clear();
            ddlUsageTop.AppendDataBoundItems = true;
            ddlUsageTop.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtUsage = new DataTable();
            dtUsage = WebUtility.GetRows("select * from MPartUsage where PartUsageID > 0");
            if (dtUsage != null && dtUsage.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsage.Rows)
                {
                    ddlUsageTop.Items.Add(new ListItem(dr["PartUsage"].ToString(), dr["PartUsageID"].ToString()));
                }
            }

            ddlUsageTop.DataBind();
            ddlUsageTop.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

        try
        {
            ddlMaterialTop.Items.Clear();
            ddlMaterialTop.AppendDataBoundItems = true;
            ddlMaterialTop.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtMaterial = new DataTable();
            dtMaterial = WebUtility.GetRows("select * from MMaterial where MaterialCode <> ''");
            if (dtMaterial != null && dtMaterial.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMaterial.Rows)
                {
                    ddlMaterialTop.Items.Add(new ListItem(dr["Material"].ToString(), dr["MaterialCode"].ToString()));
                }
            }

            ddlMaterialTop.DataBind();
            ddlMaterialTop.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

        try
        {
            ddlIndustryTop.Items.Clear();
            ddlIndustryTop.AppendDataBoundItems = true;
            ddlIndustryTop.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtIndustry = new DataTable();
            dtIndustry = WebUtility.GetRows("select * from MIndustry where IndustryCode <> ''");
            if (dtIndustry != null && dtIndustry.Rows.Count > 0)
            {
                foreach (DataRow dr in dtIndustry.Rows)
                {
                    ddlIndustryTop.Items.Add(new ListItem(dr["Industry"].ToString(), dr["IndustryCode"].ToString()));
                }
            }

            ddlIndustryTop.DataBind();
            ddlIndustryTop.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

        try
        {
            ddlApplicationTop.Items.Clear();
            ddlApplicationTop.AppendDataBoundItems = true;
            ddlApplicationTop.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtApplication = new DataTable();
            dtApplication = WebUtility.GetRows("select * from MApplication where ApplicationID > 0");
            if (dtApplication != null && dtApplication.Rows.Count > 0)
            {
                foreach (DataRow dr in dtApplication.Rows)
                {
                    ddlApplicationTop.Items.Add(new ListItem(dr["Application"].ToString(), dr["ApplicationID"].ToString()));
                }
            }

            ddlApplicationTop.DataBind();
            ddlApplicationTop.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

        try
        {
            DataTable dtCategory = new DataTable();
            dtCategory = WebUtility.GetRows("select * from MPPCIndustry where PPCIndustry > 1 order by IndustrySort asc");

            ddlCategory.Items.Clear();
            ddlCategory.AppendDataBoundItems = true;
            ddlCategory.Items.Add(new ListItem("--Select All--", "-1"));

            ddlPPCIndustry.Items.Clear();
            ddlPPCIndustry.AppendDataBoundItems = true;
            ddlPPCIndustry.Items.Add(new ListItem("--Select All--", "-1"));

            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCategory.Rows)
                {
                    ddlCategory.Items.Add(new ListItem(dr["PPCIndustryName"].ToString(), dr["PPCIndustry"].ToString()));
                    ddlPPCIndustry.Items.Add(new ListItem(dr["PPCIndustryName"].ToString(), dr["PPCIndustry"].ToString()));
                }
            }

            ddlCategory.DataBind();
            ddlCategory.SelectedValue = "-1";

            ddlPPCIndustry.DataBind();
            ddlPPCIndustry.SelectedValue = "-1";
           
           
           
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSearchTop_Click(object sender, EventArgs e)
    {
        Session["CurrentGroup"] = null;
        try
        {

            string sWhere = string.Empty;
            if (ddlProcessTop.SelectedValue != "-1")
            {
                sWhere += " and wt.ProcessID = " + ddlProcessTop.SelectedValue;
            }
            if (ddlUsageTop.SelectedValue != "-1")
            {
                sWhere += " and wt.PartUsageID = " + ddlUsageTop.SelectedValue;
            }
            if (ddlApplicationTop.SelectedValue != "-1")
            {
                sWhere += " and wt.ApplicationID = " + ddlApplicationTop.SelectedValue;
            }

            if (ddlMaterialTop.SelectedValue != "-1")
            {
                sWhere += " AND wt.PartNo IN (SELECT mm.PartNo  FROM MPartMaterial mm WHERE mm.MaterialCode = '" + ddlMaterialTop.SelectedValue + "') ";
            }
            if (ddlIndustryTop.SelectedValue != "-1")
            {
                sWhere += " AND wt.PartNo IN (SELECT mi.PartNo  FROM MPartIndustry mi WHERE mi.IndustryCode = '" + ddlIndustryTop.SelectedValue + "') ";
            }
            if (ddlCategory.SelectedValue != "-1")
            {
                sWhere += " AND wt.ProductPageCode IN (SELECT mi.PPCIndustryLink  FROM MPPCIndustrySectionGroupPages mi WHERE mi.MPPCInductryId = '" + ddlCategory.SelectedValue + "') ";
            }
            if (txtPartNoTop.Text.ToString().Trim().Length > 0)
            {
                sWhere += " and wt.PartNo LIKE '%" + txtPartNoTop.Text.ToString().Trim() + "%' ";
            }

            if (txtSearchTop.Value.ToString().Trim().Length > 0)
            {
                sWhere += " and wt.PartNo LIKE '%" + txtSearchTop.Value.ToString().Trim() + "%' ";
            }

            string sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId and pp.WebSectionID > 0 and pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " )";

            if (txtProductNameTop.Text.ToString().Trim().Length > 0)
            {
                sSQL += " and pp.PageName like  '%" + txtProductNameTop.Text.ToString().Trim() + "%' ";
            }


            if (sSQL.Length > 0)
            {
                sSQL += "  ORDER BY mg.WebGroupSort";

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
                                pgName += "<span><a class='groupNameColor' href='ProductPages.aspx?GroupId=" +
                                          objMWebGroup.WebGroupID + "'>" + objMWebGroup.WebGroup +
                                          "<a></span><div class='separator-2'></div>";

                                pgName +=
                                    "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";

                                ProductText objProductText = new ProductText();
                                objProductText =
                                    new ProductTextDa().GetProductTextbyId(Convert.ToInt32(dr["ProductPageCode"]));
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]))
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
                                    "<a href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>";
                                if (objProductText != null)
                                {
                                    pgName += "<p>" + objProductText.ShortDescription + "</p>";
                                }
                                pgName += "</div></div></div>";
                            }
                            else
                            {
                                ProductText objProductText = new ProductText();
                                objProductText =
                                    new ProductTextDa().GetProductTextbyId(Convert.ToInt32(dr["ProductPageCode"]));
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + dr["ThumbNail"];
                                }
                                else
                                {
                                    imgSrc = "/Files/Products/Thumbnails/not_found_image.jpg";
                                }

                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>";

                                if (objProductText != null && objProductText.ShortDescription != null)
                                {
                                    pgName += "<p>" + objProductText.ShortDescription + "</p>";
                                }
                                pgName += "</div></div></div>";
                            }
                        }

                    }
                    pgName += "</div>";
                    pgName += "</div>";
                    Session["SearchResult"] = pgName;
                }
                else
                {
                    Session["SearchResult"] = "Currently there is no products available for the search. Please try again later.";
                }
            }
            else
            {
                Session["SearchResult"] = "Currently there is no products available for the search. Please try again later.";
            }

            Response.Redirect("~/Pages/ProductPages.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSearchTopN_Click(object sender, ImageClickEventArgs e)
    {
        Session["CurrentGroup"] = null;

        try
        {
            string sWhere = string.Empty;
            string dWhere = string.Empty;
            string sSQL = string.Empty;
            string tSql = string.Empty;

            string sPageCode = string.Empty;
            string sPageName = string.Empty;
            string sMetaTags = string.Empty;
            string sShortDescription = string.Empty;
            string sFullPhrase = string.Empty;
            DataTable dtProducts = new DataTable();
            char[] whitespace = new char[] { ' ', '\t', '\'', '\"', '!', '"', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            string[] searchArray = null;
            string sStr = "";
            sStr = txtSearchTop.Value.ToString().Trim();
            if (sStr.Length > 0)
            {
                Session["SearchKeywords"] = sStr;

                searchArray = sStr.Split(whitespace);
                foreach (string Str in searchArray)
                {
                    if (string.IsNullOrEmpty(Str))
                    {
                        continue;
                    }

                    sFullPhrase += Str + " ";
                    sPageCode += " or pp.ProductPageCode LIKE '%" + Str + "%'";
                    sPageName += " or pp.PageName LIKE '%" + Str + "%'";
                    sMetaTags += " or pp.MetaTags LIKE '%" + Str + "%'";
                    sShortDescription += " or pt.ProductText LIKE '%" + Str + "%'";
                }
            }


           

            sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId and pp.WebSectionID > 0 and (pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0  and wt.PartNo LIKE '%" + sFullPhrase.Trim() + "%' ) or (pp.PageName like  '%" + sFullPhrase.Trim() + "%' or pp.ProductPageCode like  '%" + sFullPhrase.Trim() + "%'  or pp.MetaTags like  '%" + sFullPhrase.Trim() + "%')  or pp.ProductPageCode IN (SELECT pt.ProductPageCode FROM ProductText pt WHERE pt.ProductPageCode <> 0 and pt.ProductText LIKE '%" + sFullPhrase.Trim() + "%'))";


            if (sSQL.Length > 0)
            {
                sSQL += "  ORDER BY mg.WebGroupSort";

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
                                pgName += "<span><a class='groupNameColor' href='ProductPages.aspx?GroupId=" +
                                          objMWebGroup.WebGroupID + "'>" + objMWebGroup.WebGroup +
                                          "<a></span><div class='separator-2'></div>";

                                pgName +=
                                    "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";

                                ProductText objProductText = new ProductText();
                                objProductText =
                                    new ProductTextDa().GetProductTextbyId(Convert.ToInt32(dr["ProductPageCode"]));
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]))
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
                                    "<a href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>";
                                if (objProductText != null)
                                {
                                    pgName += "<p>" + objProductText.ShortDescription + "</p>";
                                }
                                pgName += "</div></div></div>";
                            }
                            else
                            {
                                ProductText objProductText = new ProductText();
                                objProductText =
                                    new ProductTextDa().GetProductTextbyId(Convert.ToInt32(dr["ProductPageCode"]));
                                if (!string.IsNullOrEmpty((string)dr["ThumbNail"]))
                                {
                                    imgSrc = "/Files/Products/Thumbnails/" + dr["ThumbNail"];
                                }
                                else
                                {
                                    imgSrc = "/Files/Products/Thumbnails/not_found_image.jpg";
                                }

                                pgName +=
                                    "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                    "<div class='listing-item'>" +
                                    "<div class='overlay-container'>" +
                                    "<a href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'>" +
                                    "<img class='section-imgdiv' alt='' src='" + imgSrc + "'>" +
                                    "</a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>";

                                if (objProductText != null && objProductText.ShortDescription != null)
                                {
                                    pgName += "<p>" + objProductText.ShortDescription + "</p>";
                                }
                                pgName += "</div></div></div>";
                            }
                        }

                    }

                    pgName += "</div>";
                    pgName += "</div>";
                    Session["SearchResult"] = pgName;
                }
                else
                {
                    Session["SearchResult"] = "Currently there is no products available for the search. Please try again later.";
                }
            }
            else
            {
                Session["SearchResult"] = "Currently there is no products available for the search. Please try again later.";
            }

            Response.Redirect("~/Pages/ProductPages.aspx", false);

        }
        catch (Exception ex)
        {
            //
        }
    }
    //private void loadVideos(int nId)
    //{
    //    string pgName = "";
    //    Session["CurrentPPC"] = null;

    //    string sSQL = string.Empty;
    //    DataTable dtProducts = null;

    //    DataView dvVideo = null;
    //    DataTable dtVideo = null;

    //    sSQL = "    select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate from   "
    //           + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
    //           + "  (select V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
    //           + "   on A.VideoID = B.VideoID  "
    //           + "   left join MPPCIndustry C  "
    //           + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 "
    //           + "   order by C.IndustrySort asc, B.VUploadDate desc ";

       
      

    //    if (Session["dsVideo"] == null)
    //    {
    //        dtVideo = WebUtility.GetRows(sSQL);
    //        if (dtVideo != null && dtVideo.Rows.Count > 0)
    //        {
    //            Session["dsVideo"] = dtVideo;
    //        }
    //    }
    //    else
    //    {
    //        dtVideo = ((DataTable)Session["dsVideo"]);
    //    }

    //    try
    //    {
    //        if (dtVideo != null && dtVideo.Rows.Count > 0)
    //        {
    //            int nCount = 0;
              
    //            DataView Industryview = new DataView(dtVideo.Select("PPCIndustry='" + nId.ToString() + "'").CopyToDataTable());
    //            dtProducts = Industryview.ToTable();

    //            if (dtProducts != null && dtProducts.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr in dtProducts.Rows)
    //                {
    //                    string sVImage = "";
    //                    string sVImageName = "";
    //                    string sVImageText = "";
    //                    if (!string.IsNullOrEmpty(dr["Vimage"].ToString()) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + dr["Vimage"].ToString())))
    //                    {
    //                        sVImage = "<img width='150' src='../Files/Products/VideoImages/" + dr["Vimage"].ToString() + "' />";
    //                    }
    //                    else
    //                    {
    //                        sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
    //                    }


    //                    if (!string.IsNullOrEmpty(dr["VideoName"].ToString()))
    //                    {
    //                        sVImageName = "<p style='font-weight:bold;'>" + dr["VideoName"].ToString() + "</p>";
    //                    }
    //                    if (!string.IsNullOrEmpty(dr["VideoText"].ToString()))
    //                    {
    //                        sVImageText = dr["VideoText"].ToString();
    //                        if (sVImageText.Length > 100)
    //                        {
    //                            sVImageText = sVImageText.Substring(0, 100) + " ...";
    //                        }
    //                        sVImageText = "<p>" + sVImageText + "</p>";
    //                    }

    //                    if (Session["CurrentPPC"] == null || (Session["CurrentPPC"] != null && Convert.ToInt32(Session["CurrentPPC"].ToString()) != Convert.ToInt32(dr["PPCIndustry"].ToString())))
    //                    {
    //                        nCount = nCount + 1;
    //                        Session["CurrentPPC"] = dr["PPCIndustry"];

    //                        if (nCount > 1)
    //                        {
    //                            pgName += "</div></div>";
    //                        }
    //                        pgName += "<div id='#div" + dr["PPCIndustry"] + "' class='table table-responsive'><div class='panel-heading'><span class='title groupNameColor'><h3 style='background-color: #337AB7;color: #fff;padding: 5px 0;'>" + dr["PPCIndustryName"].ToString() +
    //                                  "</h3></span></div>";

    //                        pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";


    //                        pgName +=
    //                            "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
    //                            "<div class='listing-item'>";

    //                        pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
    //                        pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

    //                        pgName += "</div></div>";

    //                    }
    //                    else
    //                    {

    //                        pgName +=
    //                          "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
    //                          "<div class='listing-item'>";

    //                        pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
    //                        pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

    //                        pgName += "</div></div>";

    //                    }
    //                }

    //                pgName += "</div>";
    //                pgName += "</div>";

    //            }

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //    if (nId == 2)
    //    {
    //        videos2.InnerHtml = pgName;
    //    }
    //    else if (nId == 3)
    //    {
    //        videos3.InnerHtml = pgName;
    //    }
    //    else if (nId == 4)
    //    {
    //        videos4.InnerHtml = pgName;
    //    }
    //    else if (nId == 5)
    //    {
    //        videos5.InnerHtml = pgName;
    //    }
    //    else if (nId == 6)
    //    {
    //        videos6.InnerHtml = pgName;
    //    }
    //    else if (nId == 7)
    //    {
    //        videos7.InnerHtml = pgName;
    //    }
    //    else if (nId == 8)
    //    {
    //        videos8.InnerHtml = pgName;
    //    }
    //    else if (nId == 9)
    //    {
    //        videos9.InnerHtml = pgName;
    //    }
    //    else if (nId == 10)
    //    {
    //        videos10.InnerHtml = pgName;
    //    }

    //}
    //private void loadVideosBySelection(int nId)
    //{
    //    string pgName = "";
    //    Session["CurrentPPC"] = null;

    //    videos2.InnerHtml = "";
    //    videos3.InnerHtml = "";
    //    videos4.InnerHtml = "";
    //    videos5.InnerHtml = "";
    //    videos6.InnerHtml = "";
    //    videos7.InnerHtml = "";
    //    videos8.InnerHtml = "";
    //    videos9.InnerHtml = "";
    //    videos10.InnerHtml = "";

    //    string pgPPCName = "";
    //    string sSQL = string.Empty;
    //    DataTable dtProducts = null;

    //    DataView dvVideo = null;
    //    DataTable dtVideo = null;

    //    sSQL = "    select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate from   "
    //          + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
    //          + "  (select V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
    //          + "   on A.VideoID = B.VideoID  "
    //          + "   left join MPPCIndustry C  "
    //          + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 "
    //          + "   order by C.IndustrySort asc, B.VUploadDate desc ";

    //    //sSQL = " select distinct  C.PPCIndustry, max(C.PPCIndustryName) PPCIndustryName, max(C.IndustrySort) IndustrySort, B.VideoID VideoID,  max(B.VideoLink) VideoLink, max(B.VideoName) VideoName, max(B.VideoText) VideoText, max(B.Vimage) Vimage, max(B.VUploadDate) VUploadDate from   "
    //    //      + " (Select VideoID, IndustryID from VideoIndustry) A inner join "
    //    //      + " (select V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
    //    //      + " on A.VideoID = B.VideoID  "
    //    //      + " left join MPPCIndustry C  "
    //    //      + " on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 "
    //    //      + " group by C.PPCIndustry, B.VideoID  "
    //    //      + " order by max(C.IndustrySort) asc, max(B.VUploadDate) desc ";
       
     
    //    if (Session["dsVideo"] == null)
    //    {
    //        dtVideo = WebUtility.GetRows(sSQL);
    //        if (dtVideo != null && dtVideo.Rows.Count > 0)
    //        {
    //            Session["dsVideo"] = dtVideo;
    //        }
    //    }
    //    else
    //    {
    //        dtVideo = ((DataTable)Session["dsVideo"]);
    //    }

    //    try
    //    {
    //        if (dtVideo != null && dtVideo.Rows.Count > 0)
    //        {
    //            int nCount = 0;

    //            DataView Industryview = new DataView(dtVideo.Select("PPCIndustry='" + nId.ToString() + "'").CopyToDataTable());
    //            dtProducts = Industryview.ToTable();

    //            if (dtProducts != null && dtProducts.Rows.Count > 0)
    //            {
    //                foreach (DataRow dr in dtProducts.Rows)
    //                {
    //                    string sVImage = "";
    //                    string sVImageName = "";
    //                    string sVImageText = "";
    //                    if (!string.IsNullOrEmpty(dr["Vimage"].ToString()) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + dr["Vimage"].ToString())))
    //                    {
    //                        sVImage = "<img width='150' src='../Files/Products/VideoImages/" + dr["Vimage"].ToString() + "' />";
    //                    }
    //                    else
    //                    {
    //                        sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
    //                    }


    //                    if (!string.IsNullOrEmpty(dr["VideoName"].ToString()))
    //                    {
    //                        sVImageName = "<p style='font-weight:bold;'>" + dr["VideoName"].ToString() + "</p>";
    //                    }

    //                    if (!string.IsNullOrEmpty(dr["VideoText"].ToString()))
    //                    {
    //                        sVImageText = dr["VideoText"].ToString();
    //                        if (sVImageText.Length > 100)
    //                        {
    //                            sVImageText = sVImageText.Substring(0, 100) + " ...";
    //                        }
    //                        sVImageText = "<p>" + sVImageText + "</p>";
    //                    }

    //                    if (Session["CurrentPPC"] == null || (Session["CurrentPPC"] != null && Convert.ToInt32(Session["CurrentPPC"].ToString()) != Convert.ToInt32(dr["PPCIndustry"].ToString())))
    //                    {
    //                        nCount = nCount + 1;
    //                        Session["CurrentPPC"] = dr["PPCIndustry"];

    //                        if (nCount > 1)
    //                        {
    //                            pgName += "</div></div>";
    //                        }
    //                        pgName += "<div id='#div" + dr["PPCIndustry"] + "' class='table table-responsive'><div class='panel-heading'><span class='title groupNameColor'><h3 style='background-color: #337AB7;color: #fff;padding: 5px 0;'>" + dr["PPCIndustryName"].ToString() +
    //                                  "</h3></span></div>";

    //                        pgPPCName = dr["PPCIndustryName"].ToString();

    //                        pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";


    //                        pgName +=
    //                            "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
    //                            "<div class='listing-item'>";

    //                        pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
    //                        pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

    //                        pgName += "</div></div>";

    //                    }
    //                    else
    //                    {
    //                        pgName +=
    //                          "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
    //                          "<div class='listing-item'>";

    //                        pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
    //                        pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

    //                        pgName += "</div></div>";

    //                    }
    //                }

    //                pgName += "</div>";
    //                pgName += "</div>";

    //                Breadcrumb.InnerHtml =
    //                    "<li><i class='fa fa-home pr-10'></i><a href='Default.aspx'>Home</a></li><li>Alpha Tech Academy</li><li class='active'>" + pgPPCName + "</li>";
    //                ppcTop.InnerHtml = "";
    //            }

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //    if (nId == 2)
    //    {
    //        videos2.InnerHtml = pgName;
    //    }
    //    else if (nId == 3)
    //    {
    //        videos3.InnerHtml = pgName;
    //    }
    //    else if (nId == 4)
    //    {
    //        videos4.InnerHtml = pgName;
    //    }
    //    else if (nId == 5)
    //    {
    //        videos5.InnerHtml = pgName;
    //    }
    //    else if (nId == 6)
    //    {
    //        videos6.InnerHtml = pgName;
    //    }
    //    else if (nId == 7)
    //    {
    //        videos7.InnerHtml = pgName;
    //    }
    //    else if (nId == 8)
    //    {
    //        videos8.InnerHtml = pgName;
    //    }
    //    else if (nId == 9)
    //    {
    //        videos9.InnerHtml = pgName;
    //    }
    //    else if (nId == 10)
    //    {
    //        videos10.InnerHtml = pgName;
    //    }

    //}
    protected void ddlPPCIndustry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPPCIndustry.SelectedIndex > 0)
        {
            int nId = Convert.ToInt32(ddlPPCIndustry.SelectedValue);
            loadVideosBySelection(nId);
        }
        else
        {
            loadVideos(10);
            loadVideos(2);
            loadVideos(3);
            loadVideos(4);
            loadVideos(8);
            loadVideos(5);
            loadVideos(6);
            loadVideos(9);
            loadVideos(7);

            Breadcrumb.InnerHtml = "<li><i class='fa fa-home pr-10'></i><a href='Default.aspx'>Home</a></li><li class='active'>Video Library</li>";
            
            if (Session["sMenuTop"] != null)
            {
                ppcTop.InnerHtml = Session["sMenuTop"].ToString();
            }
           
        }
    }

    private void loadVideos(int nId)
    {
        string pgName = "";
        Session["CurrentPPC"] = null;
        Session["currentSection"] = null;
        string sSQL = string.Empty;
        DataTable dtProducts = null;

        DataView dvVideo = null;
        DataTable dtVideo = null;

        //sSQL = "    select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate from   "
        //       + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
        //       + "  (select V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
        //       + "   on A.VideoID = B.VideoID  "
        //       + "   left join MPPCIndustry C  "
        //       + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 "
        //       + "   order by C.IndustrySort asc, B.VUploadDate desc ";

        sSQL = "   select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate , isnull(M.WebSection,'') WebSection,isnull(M.WebSectionSort,0) WebSectionSort from   "
            + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
            + "  (select V.WebSection,V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
            + "   on A.VideoID = B.VideoID  "
            + "   left join MPPCIndustry C  "
            + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 left join MWebSection M on M.WebSectionID = B.WebSection "
            + "   order by C.IndustrySort asc, M.WebSectionSort asc, B.VUploadDate desc ";


        if (Session["dsVideo"] == null)
        {
            dtVideo = WebUtility.GetRows(sSQL);
            if (dtVideo != null && dtVideo.Rows.Count > 0)
            {
                Session["dsVideo"] = dtVideo;
            }
        }
        else
        {
            dtVideo = ((DataTable)Session["dsVideo"]);
        }

        try
        {
            if (dtVideo != null && dtVideo.Rows.Count > 0)
            {
                int nCount = 0;
                int   nCountGroup = 0;
                DataView Industryview = new DataView(dtVideo.Select("PPCIndustry='" + nId.ToString() + "'").CopyToDataTable());
                dtProducts = Industryview.ToTable();

                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtProducts.Rows)
                    {
                        string sVImage = "";
                        string sVImageName = "";
                        string sVImageText = "";
                        if (!string.IsNullOrEmpty(dr["Vimage"].ToString()) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + dr["Vimage"].ToString())))
                        {
                            sVImage = "<img width='150' src='../Files/Products/VideoImages/" + dr["Vimage"].ToString() + "' />";
                        }
                        else
                        {
                            sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
                        }


                        if (!string.IsNullOrEmpty(dr["VideoName"].ToString()))
                        {
                            sVImageName = "<p style='font-weight:bold;'>" + dr["VideoName"].ToString() + "</p>";
                        }
                        if (!string.IsNullOrEmpty(dr["VideoText"].ToString()))
                        {
                            sVImageText = dr["VideoText"].ToString();
                            if (sVImageText.Length > 100)
                            {
                                sVImageText = sVImageText.Substring(0, 100) + " ...";
                            }
                            sVImageText = "<p>" + sVImageText + "</p>";
                        }

                        if (Session["CurrentPPC"] == null || (Session["CurrentPPC"] != null && Convert.ToInt32(Session["CurrentPPC"].ToString()) != Convert.ToInt32(dr["PPCIndustry"].ToString())))
                        {
                            nCount = nCount + 1;
                            nCountGroup = 0;
                            Session["CurrentPPC"] = dr["PPCIndustry"];

                            if (nCount > 1)
                            {
                                pgName += "</div></div>";
                            }
                            pgName += "<div id='#div" + dr["PPCIndustry"] + "' class='table table-responsive'><div class='panel-heading'><span class='title groupNameColor'><h3 style='background-color: #337AB7;color: #fff;padding: 5px 0;'>" + dr["PPCIndustryName"].ToString() +
                                      "</h3></span></div>";

                          //  pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";


                            if (Session["currentSection"] == null || (Session["currentSection"] != null && Session["currentSection"].ToString() != dr["WebSection"].ToString()))
                            {
                                Session["currentSection"] = dr["WebSection"];
                                nCountGroup = nCountGroup + 1;

                                if (nCountGroup > 1)
                                {
                                    pgName += "</div>";
                                }
                                pgName += "<h1><a class='groupNameColor2'>" + dr["WebSection"].ToString() + "</a></h1>";
                                if (dr["WebSection"] != null && dr["WebSection"].ToString() != "")
                                {
                                    pgName += "<div class='separator-2'></div>";
                                }
                                pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                            }

                            pgName +=
                                "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                "<div class='listing-item'>";

                            pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
                            pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

                            pgName += "</div></div>";

                        }
                        else
                        {
                            if (Session["currentSection"] == null || (Session["currentSection"] != null && Session["currentSection"].ToString() != dr["WebSection"].ToString()))
                            {
                                Session["currentSection"] = dr["WebSection"];
                                nCountGroup = nCountGroup + 1;

                                if (nCountGroup > 1)
                                {
                                    pgName += "</div>";
                                }
                                pgName += "<h1><a class='groupNameColor2'>" + dr["WebSection"].ToString() + "</a></h1>";
                                if (dr["WebSection"] != null && dr["WebSection"].ToString() != "")
                                {
                                    pgName += "<div class='separator-2'></div>";
                                }
                                pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                            }
                           

                            pgName +=
                              "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                              "<div class='listing-item'>";

                            pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
                            pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

                            pgName += "</div></div>";

                        }
                    }

                    pgName += "</div>";
                    pgName += "</div>";

                }

            }

        }
        catch (Exception ex)
        {

        }

        if (nId == 2)
        {
            videos2.InnerHtml = pgName;
        }
        else if (nId == 3)
        {
            videos3.InnerHtml = pgName;
        }
        else if (nId == 4)
        {
            videos4.InnerHtml = pgName;
        }
        else if (nId == 5)
        {
            videos5.InnerHtml = pgName;
        }
        else if (nId == 6)
        {
            videos6.InnerHtml = pgName;
        }
        else if (nId == 7)
        {
            videos7.InnerHtml = pgName;
        }
        else if (nId == 8)
        {
            videos8.InnerHtml = pgName;
        }
        else if (nId == 9)
        {
            videos9.InnerHtml = pgName;
        }
        else if (nId == 10)
        {
            videos10.InnerHtml = pgName;
        }

    }
    private void loadVideosBySelection(int nId)
    {
        string pgName = "";
        Session["CurrentPPC"] = null;
        Session["currentSection"] = null;
        videos2.InnerHtml = "";
        videos3.InnerHtml = "";
        videos4.InnerHtml = "";
        videos5.InnerHtml = "";
        videos6.InnerHtml = "";
        videos7.InnerHtml = "";
        videos8.InnerHtml = "";
        videos9.InnerHtml = "";
        videos10.InnerHtml = "";

        string pgPPCName = "";
        string sSQL = string.Empty;
        DataTable dtProducts = null;

        DataView dvVideo = null;
        DataTable dtVideo = null;

        //sSQL = "    select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate from   "
        //      + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
        //      + "  (select V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
        //      + "   on A.VideoID = B.VideoID  "
        //      + "   left join MPPCIndustry C  "
        //      + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 "
        //      + "   order by C.IndustrySort asc, B.VUploadDate desc ";

        sSQL = "   select C.PPCIndustry, C.PPCIndustryName PPCIndustryName, C.IndustrySort IndustrySort, B.VideoID VideoID,  B.VideoLink VideoLink, B.VideoName VideoName, B.VideoText VideoText, B.Vimage Vimage, B.VUploadDate VUploadDate , isnull(M.WebSection,'') WebSection,isnull(M.WebSectionSort,0) WebSectionSort from   "
             + "  (Select VideoID, IndustryID from VideoIndustry) A inner join  "
             + "  (select V.WebSection,V.VideoID, isnull(V.VideoName,'') VideoName, isnull(V.VideoLink,'') VideoLink, isnull(V.VideoText,'') VideoText, isnull(V.Vimage,'') Vimage, V.VUploadDate from Video V where VCurrentYN = 1 and VideoLink is not null) B  "
             + "   on A.VideoID = B.VideoID  "
             + "   left join MPPCIndustry C  "
             + "   on A.IndustryID = C.PPCIndustry and C.PPCIndustry > 1 left join MWebSection M on M.WebSectionID = B.WebSection "
             + "   order by C.IndustrySort asc, M.WebSectionSort asc, B.VUploadDate desc ";

        if (Session["dsVideo"] == null)
        {
            dtVideo = WebUtility.GetRows(sSQL);
            if (dtVideo != null && dtVideo.Rows.Count > 0)
            {
                Session["dsVideo"] = dtVideo;
            }
        }
        else
        {
            dtVideo = ((DataTable)Session["dsVideo"]);
        }

        try
        {
            if (dtVideo != null && dtVideo.Rows.Count > 0)
            {
                int nCount = 0;
                int nCountGroup = 0;
                DataView Industryview = new DataView(dtVideo.Select("PPCIndustry='" + nId.ToString() + "'").CopyToDataTable());
                dtProducts = Industryview.ToTable();

                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtProducts.Rows)
                    {
                        string sVImage = "";
                        string sVImageName = "";
                        string sVImageText = "";
                        if (!string.IsNullOrEmpty(dr["Vimage"].ToString()) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + dr["Vimage"].ToString())))
                        {
                            sVImage = "<img width='150' src='../Files/Products/VideoImages/" + dr["Vimage"].ToString() + "' />";
                        }
                        else
                        {
                            sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
                        }


                        if (!string.IsNullOrEmpty(dr["VideoName"].ToString()))
                        {
                            sVImageName = "<p style='font-weight:bold;'>" + dr["VideoName"].ToString() + "</p>";
                        }

                        if (!string.IsNullOrEmpty(dr["VideoText"].ToString()))
                        {
                            sVImageText = dr["VideoText"].ToString();
                            if (sVImageText.Length > 100)
                            {
                                sVImageText = sVImageText.Substring(0, 100) + " ...";
                            }
                            sVImageText = "<p>" + sVImageText + "</p>";
                        }

                        if (Session["CurrentPPC"] == null || (Session["CurrentPPC"] != null && Convert.ToInt32(Session["CurrentPPC"].ToString()) != Convert.ToInt32(dr["PPCIndustry"].ToString())))
                        {
                            nCount = nCount + 1;
                            nCountGroup = 0;
                             Session["CurrentPPC"] = dr["PPCIndustry"];
                            

                            if (nCount > 1)
                            {
                                pgName += "</div></div>";
                            }

                            pgName += "<div id='#div" + dr["PPCIndustry"] + "' class='table table-responsive'><div class='panel-heading'><span class='title groupNameColor'><h3 style='background-color: #337AB7;color: #fff;padding: 5px 0;'>" + dr["PPCIndustryName"].ToString() +
                                      "</h3></span></div>";

                            pgPPCName = dr["PPCIndustryName"].ToString();                           


                          //  pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";

                            if (Session["currentSection"] == null || (Session["currentSection"] != null && Session["currentSection"].ToString() != dr["WebSection"].ToString()))
                            {
                                Session["currentSection"] = dr["WebSection"];
                                nCountGroup = nCountGroup + 1;

                                if (nCountGroup > 1)
                                {
                                    pgName += "</div>";
                                }
                                pgName += "<h1><a class='groupNameColor2'>" + dr["WebSection"].ToString() + "</a></h1>";
                                if (dr["WebSection"] != null && dr["WebSection"].ToString() != "")
                                {
                                    pgName += "<div class='separator-2'></div>";
                                }
                                pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                            }

                            pgName +=
                                "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                                "<div class='listing-item'>";

                            pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
                            pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

                            pgName += "</div></div>";

                        }
                        else
                        {
                            if (Session["currentSection"] == null || (Session["currentSection"] != null && Session["currentSection"].ToString() != dr["WebSection"].ToString()))
                            {
                                Session["currentSection"] = dr["WebSection"];
                                nCountGroup = nCountGroup + 1;

                                if (nCountGroup > 1)
                                {
                                    pgName += "</div>";
                                }
                                pgName += "<h1><a class='groupNameColor2'>" + dr["WebSection"].ToString() + "</a></h1>";
                                if (dr["WebSection"] != null && dr["WebSection"].ToString() != "")
                                {
                                    pgName += "<div class='separator-2'></div>";
                                }
                                pgName += "<div class='masonry-grid-fitrows row grid-space-20' style='position: relative; height: 736.9px;'>";
                            }


                            pgName +=
                              "<div class='col-lg-3 col-sm-6 masonry-grid-item' style='position: absolute; left: 0px; top: 0px;'>" +
                              "<div class='listing-item'>";

                            pgName += "<div class='boxVideo VideoDiv'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImage + "</a></div>";
                            pgName += "<div class='boxVideoText'><a class='youtube-media' href='" + dr["VideoLink"].ToString() + "?autoplay=1&rel=0'>" + sVImageName + "</a>" + sVImageText + "</div>";

                            pgName += "</div></div>";

                        }
                    }

                    pgName += "</div>";
                    pgName += "</div>";

                    Breadcrumb.InnerHtml =
                        "<li><i class='fa fa-home pr-10'></i><a href='Default.aspx'>Home</a></li><li>Alpha Tech Academy</li><li class='active'>" + pgPPCName + "</li>";
                    ppcTop.InnerHtml = "";
                }

            }

        }
        catch (Exception ex)
        {

        }

        if (nId == 2)
        {
            videos2.InnerHtml = pgName;
        }
        else if (nId == 3)
        {
            videos3.InnerHtml = pgName;
        }
        else if (nId == 4)
        {
            videos4.InnerHtml = pgName;
        }
        else if (nId == 5)
        {
            videos5.InnerHtml = pgName;
        }
        else if (nId == 6)
        {
            videos6.InnerHtml = pgName;
        }
        else if (nId == 7)
        {
            videos7.InnerHtml = pgName;
        }
        else if (nId == 8)
        {
            videos8.InnerHtml = pgName;
        }
        else if (nId == 9)
        {
            videos9.InnerHtml = pgName;
        }
        else if (nId == 10)
        {
            videos10.InnerHtml = pgName;
        }

    }

}