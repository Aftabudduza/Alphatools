using System;
using System.Data;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class pages_FAQ : Page
{
    private string pgName = "";
    string PageTitle = "";
    string PageName = "";   
    private string bredCrumb = "";
    string imgSrc = "";
    private List<ProductPage> objProductPage = new List<ProductPage>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        //txtProductNameFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchFAQ').click();return false;}} else {return true}; ");
        //txtPartNoFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchFAQ').click();return false;}} else {return true}; ");
        //txtKeywordFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchFAQ').click();return false;}} else {return true}; ");
        txtProductNameFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearchFAQ').click();return false;}} else {return true}; ");
        txtPartNoFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearchFAQ').click();return false;}} else {return true}; ");
        txtKeywordFAQ.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearchFAQ').click();return false;}} else {return true}; ");

        if (!IsPostBack)
        {
            Session["SearchResult"] = null;
            LoadControls();
        }

        txtSearchTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchTopN').click();return false;}} else {return true}; ");
        //txtProductNameTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchTop').click();return false;}} else {return true}; ");
        //txtPartNoTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchTop').click();return false;}} else {return true}; ");
          txtProductNameTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearchTop').click();return false;}} else {return true}; ");
          txtPartNoTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('btnSearchTop').click();return false;}} else {return true}; ");

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

        }
    }
    protected void btnSearchTop_Click(object sender, EventArgs e)
    {
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

            //string sSQL = "SELECT * FROM ProductPage pp WHERE pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " )";
            string sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId and pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " )";

            if (txtProductNameTop.Text.ToString().Trim().Length > 0)
            {
                sSQL += " and pp.PageName like  '%" + txtProductNameTop.Text.ToString().Trim() + "%' ";
            }

            //if (txtSearchTop.Value.ToString().Trim().Length > 0)
            //{
            //    sSQL += " and (pp.PageName like  '%" + txtSearchTop.Value.ToString().Trim() + "%' or pp.ProductPageCode like  '%" + txtSearchTop.Value.ToString().Trim() + "%')";
            //    txtSearchTop.Value = "";

            //}

            if (sSQL.Length > 0)
            {
                //sSQL += " ORDER BY pp.WebSectionID asc, pp.WebGroupID asc";
                sSQL += "  ORDER BY mg.WebGroupSort"; //ORDER BY pp.WebSectionID asc, pp.WebGroupID asc";

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

                                //if (dr["ThumbNail"] != null)
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
                                    "<div class='overlay-container'><img style='width: 40%; margin-left:30%; margin-top:5%;' alt='' src='" +
                                    imgSrc + "'>" +
                                    "<a class='overlay small' href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] +
                                    "'></a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>"; // +
                                if (objProductText != null)
                                {
                                    pgName += "<p>" + objProductText.ShortDescription + "</p>";
                                }
                                pgName += "</div></div></div>";
                            }
                            else
                            {
                                ProductText objProductText = new ProductText();
                                objProductText = new ProductTextDa().GetProductTextbyId(Convert.ToInt32(dr["ProductPageCode"]));

                                //if (dr["ThumbNail"] != null)
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
                                    "<div class='overlay-container'><img style='width: 40%; margin-left:30%; margin-top:5%;' alt='' src='" + imgSrc + "'>" +
                                    "<a class='overlay small' href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'></a></div>";

                                pgName += "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>";// +

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
                    Session["SearchResult"] = "Product Not Found";
                }
            }
            else
            {
                Session["SearchResult"] = "Product Not Found";
            }

            Response.Redirect("~/Pages/ProductPages.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSearchTopN_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string sWhere = string.Empty;
            string dWhere = String.Empty;
            string sSQL = String.Empty;
            string tSql = String.Empty;
            DataTable dtProducts = new DataTable();
            if (txtSearchTop.Value.ToString().Trim().Length > 0)
            {
                tSql = "SELECT * FROM ProductFields w WHERE w.PartNo LIKE '%" + txtSearchTop.Value.ToString().Trim() + "%'";
                dtProducts = WebUtility.GetRows(tSql);
                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    sWhere += " and wt.PartNo LIKE '%" + txtSearchTop.Value.ToString().Trim() + "%' ";
                }
                else
                {
                    dWhere += " and pt.ShortDescription LIKE '%" + txtSearchTop.Value.ToString().Trim() + "%' ";
                }

            }

            if (!string.IsNullOrEmpty(sWhere))
            {
                //sSQL =
                //    "SELECT * FROM ProductPage pp WHERE pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " +
                //    sWhere + " )";

                sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId ";

                if (txtSearchTop.Value.ToString().Trim().Length > 0)
                {
                    sSQL += " and (pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " ) or (pp.PageName like  '%" + txtSearchTop.Value.ToString().Trim() + "%' or pp.ProductPageCode like  '%" + txtSearchTop.Value.ToString().Trim() + "%')) ";
                    dtProducts = WebUtility.GetRows(sSQL);
                    if (dtProducts != null && dtProducts.Rows.Count > 0)
                    {
                        txtSearchTop.Value = "";
                    }
                    else
                    {
                        sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId and pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " )";
                        txtSearchTop.Value = "";
                    }
                }
            }
            if (!string.IsNullOrEmpty(dWhere))
            {
                //sSQL =
                //    "SELECT * FROM ProductPage pp WHERE pp.ProductPageCode IN (SELECT pt.ProductPageCode FROM ProductText pt WHERE pt.ProductPageCode <> 0 " +
                //    dWhere + " )";
                sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId and  ((pp.PageName like  '%" + txtSearchTop.Value.ToString().Trim() + "%' or pp.ProductPageCode like  '%" + txtSearchTop.Value.ToString().Trim() + "%') or pp.ProductPageCode IN (SELECT pt.ProductPageCode FROM ProductText pt WHERE pt.ProductPageCode <> 0 " + dWhere + " ))";
            }

            //if (txtSearchTop.Value.ToString().Trim().Length > 0)
            //{
            //    //sSQL += " and (pp.PageName like  '%" + txtSearchTop.Value.ToString().Trim() + "%' or pp.ProductPageCode like  '%" + txtSearchTop.Value.ToString().Trim() + "%')";

            //    sSQL += " and (pp.PageName like  '%" + txtSearchTop.Value.ToString().Trim() + "%' or pp.ProductPageCode like  '%" + txtSearchTop.Value.ToString().Trim() + "%')";
            //    txtSearchTop.Value = "";
            //}

            if (sSQL.Length > 0)
            {
                //sSQL += " ORDER BY pp.WebSectionID asc, pp.WebGroupID asc";
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

                                //if (dr["ThumbNail"] != null)
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
                                    "<div class='overlay-container'><img style='width: 40%; margin-left:30%; margin-top:5%;' alt='' src='" +
                                    imgSrc + "'>" +
                                    "<a class='overlay small' href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] +
                                    "'><i class='fa fa-plus'></i><span>View Details</span></a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>"; // +
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

                                //if (dr["ThumbNail"] != null)
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
                                    "<div class='overlay-container'><img style='width: 40%; margin-left:30%; margin-top:5%;' alt='' src='" +
                                    imgSrc + "'>" +
                                    "<a class='overlay small' href='ProductDetails.aspx?PageCode=" + dr["ProductPageCode"] +
                                    "'><i class='fa fa-plus'></i><span>View Details</span></a></div>";

                                pgName +=
                                    "<div class='listing-item-body clearfix'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                    dr["ProductPageCode"] + "'>" + dr["PageName"] + "</a></h3>"; // +

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
                    Session["SearchResult"] = "Product Not Found";
                }
            }
            else
            {
                Session["SearchResult"] = "Product Not Found";
            }

            Response.Redirect("~/Pages/ProductPages.aspx", false);

        }
        catch (Exception ex)
        {
            //
        }
    }
    private void loadContent(string sPageRef)
    {
        try
        {
            string html = "";
            CMSPageRef objCmsPageRef = new CMSPageRef();
            objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive(sPageRef, "Y");
            if (objCmsPageRef != null)
            {
                html += objCmsPageRef.CMSContent;
                PageH3.InnerHtml = objCmsPageRef.CMSTitle;
                //CMSContent.InnerHtml = html;
                Breadcrumb.InnerHtml = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>" + objCmsPageRef.CMSTitle + "</li>";
            }                     
        }
        catch (Exception ex)
        {
            
        }
    }

    private void loadSEOContent(string sPageRef)
    {
        try
        {
            CMSPageRef objCmsPageRef = new CMSPageRef();
            objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive(sPageRef, "Y");
            if (objCmsPageRef != null)
            {

                HtmlMeta hm = new HtmlMeta();
                hm.Name = "keywords";
                hm.Content = objCmsPageRef.MetaKeywords != null ? objCmsPageRef.MetaKeywords.ToString() : "";
                this.metaTags.Controls.Add(hm);

                HtmlMeta hm2 = new HtmlMeta();
                hm2.Name = "description";
                hm2.Content = objCmsPageRef.MetaDescription != null ? objCmsPageRef.MetaDescription.ToString() : "";
                this.metaTags.Controls.Add(hm2);
                Page.Title = objCmsPageRef.MetaTitle != null ? objCmsPageRef.MetaTitle.ToString() : "";
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSearchFAQ_Click(object sender, EventArgs e)
    {
        try
        {
            string sWhere = string.Empty;
            string prdName = string.Empty;
            string kword = String.Empty;
            string sSQL = "";
            string srchResult = "";

            if (txtProductNameFAQ.Text.ToString().Trim().Length <= 0 && txtPartNoFAQ.Text.ToString().Trim().Length <= 0 && txtKeywordFAQ.Text.ToString().Trim().Length <= 0)
            {
                faqsDiv.InnerHtml = "Please enter text to search FAQ";
            }
            else
            {
                if (txtProductNameFAQ.Text.ToString().Trim().Length > 0)
                {
                    srchResult += txtProductNameFAQ.Text.ToString().Trim() + " ,";
                    sWhere += " AND pp.PageName LIKE '%" + txtProductNameFAQ.Text.ToString() + "%'";
                }

                if (txtPartNoFAQ.Text.ToString().Trim().Length > 0)
                {
                    srchResult += txtPartNoFAQ.Text.ToString().Trim() + " ,";
                    sWhere += " AND w.PartNo LIKE '%" + txtPartNoFAQ.Text.ToString().Trim() + "%'";
                    //sSQL = "SELECT * FROM TNTechNoteFAQ tnf , ProductPage pp, Webfields w where tnf.ProductPageCode = pp.ProductPageCode AND pp.ProductPageCode=w.ProductPageCode ";
                    sSQL = " SELECT tnf.TNQText, tnf.TNAText FROM TNTechNote tn, TNTechNoteFAQ tnf, ProductPage pp, Webfields w where tn.TNID = tnf.TNID and tn.ProductPageCode = pp.ProductPageCode AND pp.ProductPageCode=w.ProductPageCode  ";
                }
                else
                {
                    //sSQL = "SELECT * FROM TNTechNoteFAQ tnf , ProductPage pp where tnf.ProductPageCode = pp.ProductPageCode  ";
                    sSQL = " SELECT tnf.TNQText, tnf.TNAText FROM TNTechNote tn, TNTechNoteFAQ tnf, ProductPage pp  where tn.TNID = tnf.TNID and tn.ProductPageCode = pp.ProductPageCode  ";
                    
                }

                if (txtKeywordFAQ.Text.ToString().Trim().Length > 0)
                {
                    srchResult += txtKeywordFAQ.Text.ToString().Trim() + " ,";
                    sWhere += " AND (tnf.TNQText LIKE '%" + txtKeywordFAQ.Text.ToString().Trim() + "%' OR tnf.TNAText LIKE '%" + txtKeywordFAQ.Text.ToString().Trim() + "%')";
                }

                if (sWhere.Length > 0)
                {
                    sSQL = sSQL + sWhere;
                }
            }
            if (sSQL.Length > 0)
            {
                sSQL = sSQL + " order by tn.ProductPageOrderID, tnf.TNFAQOrderID ";
                DataTable dtProducts = new DataTable();
                dtProducts = WebUtility.GetRows(sSQL);
                int nCount = 0;
                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    pgName = "<div>";
                    foreach (DataRow dr in dtProducts.Rows)
                    {
                        if (dr["TNQText"] != null)
                        {
                            pgName += "<p align='justify' style='margin-bottom:10px;'><strong>Question :</strong> " + dr["TNQText"].ToString() + "<br /></p>";
                        }
                        if (dr["TNAText"] != null)
                        {
                            pgName += "<p align='justify' style='border-bottom:1px solid;padding-bottom:10px;'><strong>Answer :</strong> " + dr["TNAText"].ToString() + "<br /></p>";
                        }

                    }
                    //pgName += "</div>";
                    //pgName += "</div>";
                    faqsDiv.InnerHtml = pgName;
                    Session["SearchResult"] = pgName;
                }
                else
                {
                    faqsDiv.InnerHtml = "<p style='color:red; font-weight:bold;'>No FAQ Found. Please try again</p>";
                }

                if (srchResult.Length > 0)
                {
                    srchResult = srchResult.Substring(0, srchResult.Length - 1);
                }

                searchResultTile.InnerHtml = "Search Result For : " + srchResult;
            }
            else
            {
                searchResultTile.InnerHtml = "";
                faqsDiv.InnerHtml = "<p style='color:red; font-weight:bold;'>Please enter text to search FAQ </p>";
            }

           
        }
        catch (Exception ex)
        {
            //
        }
    }

    
}
