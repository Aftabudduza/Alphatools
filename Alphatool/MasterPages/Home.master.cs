using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPages_Home : System.Web.UI.MasterPage
{
    private string pgName = "";
    private string bredCrumb = "";
    string imgSrc = "";
    private List<ProductPage> objProductPage = new List<ProductPage>();
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString);
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        if (!IsPostBack)
        {
            Session["CurrentGroup"] = null;
            Session["SearchResult"] = null;
            LoadControls();
        }

        if (txtSearchTop.Value.ToString().Trim().Length > 0)
        {
            txtSearchTop.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('ctl00_btnSearchTopN').click();return false;}} else {return true}; ");

        }
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


            //if (txtSearchTop.Value.ToString().Trim().Length > 0)
            //{
            //    tSql = "SELECT * FROM Webfields w WHERE w.PartNo LIKE '%" + sFullPhrase.Trim() + "%'";
            //    dtProducts = WebUtility.GetRows(tSql);
            //    if (dtProducts != null && dtProducts.Rows.Count > 0)
            //    {
            //        sWhere += " and wt.PartNo LIKE '%" + sFullPhrase.Trim() + "%' ";
            //    }
            //    else
            //    {
            //        dWhere += " and pt.ShortDescription LIKE '%" + sFullPhrase.Trim() + "%' " + sShortDescription;
            //    }

            //}

            //if (!string.IsNullOrEmpty(sWhere))
            //{
            //    sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId  and pp.WebSectionID > 0  ";

            //    if (txtSearchTop.Value.ToString().Trim().Length > 0)
            //    {
            //        sSQL += " and (pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " ) or (pp.PageName like  '%" + sFullPhrase + "%' or pp.ProductPageCode like  '%" + sFullPhrase + "%'  or pp.MetaTags like  '%" + sFullPhrase + "%'" + sPageCode + sPageName + sMetaTags + " )  or pp.ProductPageCode IN (SELECT pt.ProductPageCode FROM ProductText pt WHERE pt.ProductPageCode <> 0 " + dWhere + " )) ";
            //        dtProducts = WebUtility.GetRows(sSQL);
            //        if (dtProducts != null && dtProducts.Rows.Count > 0)
            //        {
            //            txtSearchTop.Value = "";
            //        }
            //        else
            //        {
            //            sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId  and pp.WebSectionID > 0 and pp.ProductPageCode IN (SELECT wt.ProductPageCode FROM Webfields wt WHERE wt.ProductPageCode <> 0 " + sWhere + " )";
            //            txtSearchTop.Value = "";
            //        }
            //    }
            //}
            //if (!string.IsNullOrEmpty(dWhere))
            //{
            //    sSQL = "SELECT * FROM ProductPage pp, MWebGroup mg WHERE pp.WebGroupID = mg.WebGroupId  and pp.WebSectionID > 0 and  ((pp.PageName like  '%" + sFullPhrase + "%' or pp.ProductPageCode like  '%" + sFullPhrase + "%'  or pp.MetaTags like  '%" + sFullPhrase + "%') or pp.ProductPageCode IN (SELECT pt.ProductPageCode FROM ProductText pt WHERE pt.ProductPageCode <> 0 " + dWhere + " ))";
            //}

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
}
