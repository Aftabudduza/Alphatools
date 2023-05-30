using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;
using System.Web.UI.HtmlControls;

public partial class pages_ProductDetails : Page
{
    private int _productId = 0;
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["ButtonText"] = null;
           // loadSEOContent();
            try
            {
                _productId = (Request.QueryString["PageCode"] != null && Utility.IsNumeric(Request.QueryString["PageCode"])) ? Convert.ToInt32(Request.QueryString["PageCode"]) : 0;
            }
            catch (Exception)
            {
                _productId = 0;
            }
            if (_productId > 0)
            {
                Session["productId"] = _productId;
                pageinfo(_productId);
                GalleryImageSlide(_productId);
                ProductFeature(_productId);
                ProductFeatureAccordion(_productId);
                ProductFeatureMultiview.ActiveViewIndex = 0;
                ProductSpecification(_productId);
                ProductDetailsAccordion(_productId);
                ProductSpecificationAccordion(_productId);
                ProductDocumentationAccordion(_productId);
                ProductVideos(_productId);
                ProductVideosAccordion(_productId);
                //ProductPartsWithDocumentAccordion(_productId);
                ProductFaqsAccordion(_productId);
                ProductSparePartsAccordion(_productId);
                ProductAdditional(_productId);
                ProductAdditionalAccordion(_productId);
                ProductDetailsMultiView.ActiveViewIndex = 0;
                specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
                btnFeatures.BackColor = ColorTranslator.FromHtml("#fafafa");
                specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
                //findDealerbtn.BackColor = ColorTranslator.FromHtml("#fff");
                //  buyOnlineBtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
                videosBtn.BackColor = ColorTranslator.FromHtml("#fafafa");
                videosBtn.ForeColor = ColorTranslator.FromHtml("#337ab7");
                findDealerbtn.ForeColor = ColorTranslator.FromHtml("#000");
                RelatedProductByProductid(_productId);

            }
        }
        else
        {
            //if (Session["productId"] != null)
            //{
            //    ProductSpecification(Convert.ToInt32(Session["productId"]));
            //    ProductDetailsAccordion(Convert.ToInt32(Session["productId"]));
            //    ProductSpecificationAccordion(Convert.ToInt32(Session["productId"]));
            //    ProductDocumentationAccordion(Convert.ToInt32(Session["productId"]));
            //    ProductVideosAccordion(Convert.ToInt32(Session["productId"]));
            //  //  ProductPartsWithDocumentAccordion(Convert.ToInt32(Session["productId"]));
            //    ProductFaqsAccordion(Convert.ToInt32(Session["productId"]));
            //    ProductSparePartsAccordion(Convert.ToInt32(Session["productId"]));
            //}
        }

    }

    #region functions

    public void pageinfo(int productid)
    {
        try
        {
            MPPCIndustry objMppcIndustry = new MPPCIndustry();
            if (Session["categoryid"] != null)
            {
                objMppcIndustry = new MppcIndustryDa().GetMPPCIndustrybyId(Convert.ToInt32(Session["categoryid"].ToString()));
            }
            var objproductPage = new ProductPageDa().GetProductPagebyId(productid);
            var objProductText = new ProductTextDa().GetProductTextbyId(productid);
            var objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(objproductPage.WebSectionID));
            var objMWebGroup = new MWebGroupDa().GetMWebGroupbyId(Convert.ToInt32(objproductPage.WebGroupID));
            var objWebFild = new WebfieldsDa().GetWebfieldsbyProductId(productid);

            if (objMppcIndustry != null && objMWebSection != null && objMWebGroup != null)
            {
                if (objMppcIndustry.PPCIndustry > 0 && objMWebSection.WebSectionID > 0 && objMWebGroup.WebGroupID > 0)
                {
                    Session["categoryid"] = objMppcIndustry.PPCIndustry;
                    Session["sectionid"] = objMWebSection.WebSectionID;
                    Session["groupid"] = objMWebGroup.WebGroupID;

                    bredCrumb =
                        "<li><i class='fa fa-home pr-10'></i><a href='../Default.aspx'>Home</a></li>" +
                        " <li><a href='ProductPages.aspx?CategoryId=" + objMppcIndustry.PPCIndustry + "'>" +
                        objMppcIndustry.PPCIndustryName + "</a></li> " +
                        "<li><a href='ProductPages.aspx?SectionId=" + objMWebSection.WebSectionID + "'>" +
                        objMWebSection.WebSection + "</a></li>" +
                        "<li><a href='ProductPages.aspx?GroupId=" + objMWebGroup.WebGroupID + "'>" +
                        objMWebGroup.WebGroup + "</a></li>" +
                        "<li class='active'>" + objproductPage.PageName + "</li>";
                }
                else
                {
                    Session["sectionid"] = objMWebSection.WebSectionID;
                    Session["groupid"] = objMWebGroup.WebGroupID;
                    bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='../Default.aspx'>Home</a></li>" +
                        "<li><a href='ProductPages.aspx?SectionId=" + objMWebSection.WebSectionID + "'>" +
                        objMWebSection.WebSection + "</a></li>" +
                        "<li><a href='ProductPages.aspx?GroupId=" + objMWebGroup.WebGroupID + "'>" +
                        objMWebGroup.WebGroup + "</a></li>" +
                        "<li class='active'>" + objproductPage.PageName + "</li>";
                }
                productTitle.InnerHtml = objproductPage.PageName;
                productShortDesc.InnerHtml = objProductText.ShortDescription;
            }
            Breadcrumb.InnerHtml = bredCrumb;
            //  accBuyOnline.HRef = objWebFild.ShopLink;

            Page.Title =  objproductPage.PageName + " | Alpha Professional Tools®";

            string sSQL = "SELECT isnull(MetaTags,'') MetaTags FROM ProductPage where ProductPageCode =" + productid; 

            DataSet ds = this.GetSEOData(sSQL);
            string sMeta = "";

            if (ds != null && ds.Tables.Count > 0)
            {
                sMeta = ds.Tables[0].Rows[0][0].ToString().Trim();
            }

            
            try
            {              

                HtmlMeta hm = new HtmlMeta();
                hm.Name = "keywords";
               
                if (sMeta.Trim().Length <= 0)
                {
                    hm.Content = "buffing tools, buffing pads, drilling tools, cutting blades, cutting tools, cutting systems, cutting wheel, diamond tools, diamond saw blades, diamond polishing pads, grinding wheel, grinding tools industrial abrasives, pneumatic air tools, polishers, polishing pads, polishing tools, polishing wheels, polishing discs, profiling tools, profiling wheels, router bits, scratch removal, stain removers, stone cutter, stone polishing, core bits, flush cutting blades, groove cutting blades, dry cutting blades, wet cutting blades, diamond cutting blades, marble cutting tools, diamond cutting tools, edge polishers, tile profiling wheels, diamond profiling wheels, rust stain removers, stone stain removers, stone polishing machinery, stone polishing tools, wet concrete core bits, dry core bits";
                }
                else 
                { 
                    hm.Content = sMeta; 
                }

                this.metaTags.Controls.Add(hm);            
               
            }
            catch (Exception ex)
            {

            }

            try
            {                

                HtmlMeta hm2 = new HtmlMeta();
                hm2.Name = "description";
                if (sMeta.Trim().Length <= 0)
                {
                    hm2.Content = "Contact Alpha Professional Tools® headquarters, factory service center or sales contacts with any questions or comments regarding the cutting, drilling, grinding, polishing & profiling tools offered.";
                }
                else
                {
                    hm2.Content = sMeta;
                }
                this.metaTags.Controls.Add(hm2);

            }
            catch (Exception ex)
            {

            }

        }
        catch (Exception ex)
        {
            //throw;
        }


        try
        {
            var objPartPage = new PartsPageDa().GetPartsPagebyPPC(Convert.ToDouble(productid));

            if (objPartPage != null)
            {
                if (objPartPage.AltPPC != null)
                {
                    sparepartslink.InnerHtml = "<span><a style='color:#337AB7; font-weight:bold; font-size: 15px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + objPartPage.AltPPC.ToString() + "' >Buy spare parts</a> <a style='color:#337AB7; font-weight:bold; font-size: 15px;margin-left: 12px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + objPartPage.AltPPC.ToString() + "' ><i class='fa fa-file-text' aria-hidden='true'></i></a></span>";

                }
                else if (objPartPage.PPC != null)
                {
                    sparepartslink.InnerHtml = "<span><a style='color:#337AB7; font-weight:bold; font-size: 15px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + objPartPage.PPC.ToString() + "' >Buy spare parts</a> <a style='color:#337AB7; font-weight:bold; font-size: 15px;margin-left: 12px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + objPartPage.PPC.ToString() + "' ><i class='fa fa-file-text' aria-hidden='true'></i></a></span>";

                }
                else
                {
                    sparepartslink.InnerHtml = "<span><a style='color:#337AB7; font-weight:bold; font-size: 15px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' >Buy spare parts</a> <a style='color:#337AB7; font-weight:bold; font-size: 15px;margin-left: 12px;' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' ><i class='fa fa-file-text' aria-hidden='true'></i></a></span>";

                }

                //sparepartslink.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'><a style='color:#337AB7; font-weight:bold' class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' >Buy Spare Products</a> </p>";
            }
            else
            {
                sparepartslink.InnerHtml = "";
            }
        }
        catch (Exception)
        {


        }

    }

    public void ProductDetails(int productid)
    {
        try
        {
            var objProductText = new ProductTextDa().GetProductTextbyId(Convert.ToInt32(productid));
            if (objProductText != null)
            {
                string producttext = "";
                if (objProductText.ProductText1 != "" || objProductText.ProductText1 != null)
                {
                    producttext = "<p align='justify'>" + objProductText.ProductText1 +
                                  "</p>";
                }
                Session["productId"] = objProductText.ProductPageCode;
                productText.InnerHtml = producttext;
            }

        }
        catch (Exception)
        {
            //throw;
        }


    }

    public void ProductFaqs(int productid)
    {
        try
        {
            string sqlfaq = "SELECT * FROM TNTechNoteFAQ tnf WHERE tnf.TNID IN(SELECT tn.TNID FROM TNTechNote tn WHERE tn.ProductPageCode=" + productid + ")";
            string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
            DataSet dsFaq = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlfaq))
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        dsFaq = ds;
                    }
                }
            }

            string faqtext = "";

            if (dsFaq != null && dsFaq.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsFaq.Tables[0].Rows)
                {
                    if (dr["TNQText"] != null)
                    {
                        faqtext += "<p align='justify' style='margin-bottom:10px;'><strong>Question :</strong> " + dr["TNQText"].ToString() + "<br /></p>";
                    }
                    if (dr["TNAText"] != null)
                    {
                        faqtext += "<p align='justify' style='border-bottom:1px solid;padding-bottom:10px;'><strong>Answer :</strong> " + dr["TNAText"].ToString() + "<br /></p>";
                    }
                }
            }
            else
            {
                faqtext += "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no FAQs available for this product... </p>";
            }

            faqsDiv.InnerHtml = faqtext;
            Session["productId"] = productid;
        }
        catch (Exception ex)
        {
            //throw;
        }

    }

    private DataSet GetData(int productid)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductBullets pb WHERE pb.ProductPageCode=" + productid + "  ORDER BY pb.PBOrderID ASC  "))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    private DataSet GetSEOData(string sSqL)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(sSqL))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }


    public void ProductFeature(int productid)
    {
        try
        {
            string productfeature = "";
            DataSet ds = this.GetData(productid);
            if (ds != null)
            {
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        productfeature += "<li>" + dr["PBText"].ToString() + "</li>";
                    }
                }
                productFeatures.InnerHtml = productfeature;
            }
            Session["productId"] = productid;
        }
        catch (Exception)
        {
            //throw;
        }
    }

    private DataSet GetDataSpecs(int productid)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM PPCSpecs p WHERE p.PPC=" + productid + " ORDER BY p.Sort"))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    public void ProductSpecsChart(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width: 100%;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblspcsSub = new Table();
        tblspcsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblspcsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trHeaderRow = new TableHeaderRow();
        trHeaderRow.Attributes.Add("style", "background:#fff;color:#337AB7;");
        TableHeaderCell tdHeaderCell = new TableHeaderCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
        DataSet ds = this.GetDataSpecs(productid);

        productSpecs.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdHeaderCell = new TableHeaderCell { Text = "Product Details" };
                    tdHeaderCell.Attributes.Add("style", "text-align:center;font-size:16px;");
                    trHeaderRow.Controls.Add(tdHeaderCell);

                    tblspcsSub.Controls.Add(trHeaderRow);
                    tdparts.Controls.Add(tblspcsSub);
                    trparts.Controls.Add(tdparts);
                    tblparts.Controls.Add(trparts);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Specification" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Data" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["SpecsName"].ToString()) && !string.IsNullOrEmpty(dr["SpecsData"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["SpecsName"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }

                                tddatacell = new TableCell { Text = dr["SpecsData"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["SpecsName"].ToString()) && !string.IsNullOrEmpty(dr["SpecsData"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["SpecsName"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["SpecsData"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            /*else
                            {
                                tddatacell = new TableCell { Text = "N/A" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (!string.IsNullOrEmpty(dr["SpecsData"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["SpecsData"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "N/A" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }*/
                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            productSpecs.Controls.Add(tblparts);
        }
    }

    private DataSet GetDataEquips(int productid)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM PPCEquip p WHERE p.PPC=" + productid + " ORDER BY p.Sort"))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    private DataSet GetProductImages(int productid)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT pi1.ImgFilename, pi1.MetaTags  FROM PageImages pi1, PageImagesPPC pip WHERE pi1.ImgNo = pip.ImgNo AND pip.ImgPPC = " + productid + " ORDER BY pi1.ImgFilename asc "))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    private DataSet GetProductDocFiles(int productid)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT dt2.DocTypeName, dt.* FROM DocType dt2, DocPPC dp, DocTitle dt WHERE dt2.DocType = dt.DocType and dp.DocNo = dt.DocNo AND dt.[Current] = 1 AND dp.DocPPC = " + productid + " ORDER BY dt.DocType asc "))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    public void ProductEquipsChart(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width: 100%;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblspcsSub = new Table();
        tblspcsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblspcsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trHeaderRow = new TableHeaderRow();//
        trHeaderRow.Attributes.Add("style", "background:#fff;color:#337AB7;");//
        TableHeaderCell tdHeaderCell = new TableHeaderCell();//

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

        productEquips.Controls.Clear();

        DataSet ds = this.GetDataEquips(productid);

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdHeaderCell = new TableHeaderCell { Text = "Equipment Included" };
                    tdHeaderCell.Attributes.Add("style", "text-align:center;font-size:16px;");
                    trHeaderRow.Controls.Add(tdHeaderCell);

                    tblspcsSub.Controls.Add(trHeaderRow);
                    tdparts.Controls.Add(tblspcsSub);
                    trparts.Controls.Add(tdparts);
                    tblparts.Controls.Add(trparts);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Item" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Quantity" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["EquipIncluded"].ToString()) && !string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EquipIncluded"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["Qty"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["EquipIncluded"].ToString()) && !string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EquipIncluded"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["Qty"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }
            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            productEquips.Controls.Add(tblparts);
        }
    }

    public void ProductSpecification(int productid)
    {
        try
        {

            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {
                string imgSrc = "";

                if (objProductPage.SpecChart != null || objProductPage.GritChart != null)
                {
                    var producttext = "";

                    ProductSpecsChart(productid);
                    ProductEquipsChart(productid);

                    if (objProductPage.ChartLayout == "P")
                    {
                        //ProductSpecsChart(productid);
                        //ProductEquipsChart(productid);
                        ProductSpecificationWithParts(productid);
                    }

                    if (objProductPage.ChartLayout == "G")
                    {
                        if (File.Exists(Server.MapPath("/Files/Products/SpecCharts/" + objProductPage.GritChart + "")))
                        {
                            imgSrc = "/Files/Products/SpecCharts/" + objProductPage.GritChart + "";
                        }
                        if (imgSrc != null)
                        {
                            producttext = "<img style='max-width:100%' alt='' src='" + imgSrc + "'>";
                            partsWithSpcs.InnerHtml = producttext;
                            //productSpecs.Attributes.Add("style", "margin-bottom:0 !important;");
                            //productEquips.Attributes.Add("style", "margin-bottom:0 !important;");
                        }
                    }
                }
                else
                {
                    ProductSpecificationWithParts(productid);
                }
                Session["productId"] = objProductPage.ProductPageCode;
            }
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void ProductSpecificationWithParts(int productid)
    {
        try
        {
            Table tblparts = new Table();
            tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;");
            TableRow trparts = new TableRow();
            TableCell tdparts = new TableCell();

            Table tblpartsSub = new Table();
            tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
            tblpartsSub.Attributes.Add("style", "border:2px solid #3379B7;margin-bottom:0");
            TableHeaderRow trpartsheaderRow = new TableHeaderRow();
            trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#ffffff;");
            TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
            tblparts.Attributes.Add("style", "width:100%;float:left;");

            string sql = "SELECT pi1.* FROM ProductInfo pi1,(SELECT pf.*, w.SORT4_Part FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + ") P WHERE pi1.PartNo = P.PartNo ORDER BY p.SORT4_Part Asc";

            //string sql = "SELECT pi1.* FROM ProductInfo pi1,(SELECT w.* FROM Webfields w WHERE w.ProductPageCode=" + productid + ") P WHERE pi1.PartNo = P.PartNo ORDER BY p.SORT4_Part Asc";
            int k = 0;
            partsWithSpcs.Controls.Clear();

            var objProductInfolistbyProductId = new ProductInfoDa().GetAllProductInfoBySQL(sql);
            if (objProductInfolistbyProductId.Count > 0)
            {
                string[] sPartNo = objProductInfolistbyProductId.Where(x => x.PartNo != null && x.PartNo != "").Select(x => x.PartNo).ToList().ToArray();
                if (sPartNo != null && sPartNo.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Part No." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sPartSize = objProductInfolistbyProductId.Where(x => x.PartSize != null && x.PartSize != "").Select(x => x.PartSize).ToList().ToArray();
                if (sPartSize != null && sPartSize.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Size" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sDiameter = objProductInfolistbyProductId.Where(x => x.Diameter != null && x.Diameter != "").Select(x => x.Diameter).ToList().ToArray();
                if (sDiameter != null && sDiameter.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Diameter" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sThickness = objProductInfolistbyProductId.Where(x => x.Thickness != null && x.Thickness != "").Select(x => x.Thickness).ToList().ToArray();
                if (sThickness != null && sThickness.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Thickness" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sPartMaxRPMs = objProductInfolistbyProductId.Where(x => x.PartMaxRPMs != null && x.PartMaxRPMs != "").Select(x => x.PartMaxRPMs).ToList().ToArray();
                if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Maximum RPM" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sType = objProductInfolistbyProductId.Where(x => x.Type != null && x.Type != "").Select(x => x.Type).ToList().ToArray();
                if (sType != null && sType.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Type" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sArbors = objProductInfolistbyProductId.Where(x => x.Arbors != null && x.Arbors != "").Select(x => x.Arbors).ToList().ToArray();
                if (sArbors != null && sArbors.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Arbor(s)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sShape = objProductInfolistbyProductId.Where(x => x.Shape != null && x.Shape != "").Select(x => x.Shape).ToList().ToArray();
                if (sShape != null && sShape.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Shape" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sRecommended = objProductInfolistbyProductId.Where(x => x.RecommendedFor != null && x.RecommendedFor != "").Select(x => x.RecommendedFor).ToList().ToArray();
                if (sRecommended != null && sRecommended.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Recommended For" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sThreads = objProductInfolistbyProductId.Where(x => x.Threads != null && x.Threads != "").Select(x => x.Threads).ToList().ToArray();
                if (sThreads != null && sThreads.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Threads" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sForUseOn = objProductInfolistbyProductId.Where(x => x.ForUseOn != null && x.ForUseOn != "").Select(x => x.ForUseOn).ToList().ToArray();
                if (sForUseOn != null && sForUseOn.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "For Use On" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sFinish = objProductInfolistbyProductId.Where(x => x.Finish != null && x.Finish != "").Select(x => x.Finish).ToList().ToArray();
                if (sFinish != null && sFinish.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Finish" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sGrit = objProductInfolistbyProductId.Where(x => x.Grit != null && x.Grit != "").Select(x => x.Grit).ToList().ToArray();
                if (sGrit != null && sGrit.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Grit" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sColor = objProductInfolistbyProductId.Where(x => x.Color != null && x.Color != "").Select(x => x.Color).ToList().ToArray();
                if (sColor != null && sColor.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Color" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sDepthOfCut = objProductInfolistbyProductId.Where(x => x.DepthOfCut != null && x.DepthOfCut != "").Select(x => x.DepthOfCut).ToList().ToArray();
                if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Depth Of Cut" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sQty = objProductInfolistbyProductId.Where(x => x.Qty != null && x.Qty != "").Select(x => x.Qty).ToList().ToArray();
                if (sQty != null && sQty.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Qty" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sBondType = objProductInfolistbyProductId.Where(x => x.BondType != null && x.BondType != "").Select(x => x.BondType).ToList().ToArray();
                if (sBondType != null && sBondType.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "BondType" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sContainer = objProductInfolistbyProductId.Where(x => x.Container != null && x.Container != "").Select(x => x.Container).ToList().ToArray();
                if (sContainer != null && sContainer.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Container" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sDescription = objProductInfolistbyProductId.Where(x => x.Description != null && x.Description != "").Select(x => x.Description).ToList().ToArray();
                if (sDescription != null && sDescription.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Description" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sPiecesPerCase = objProductInfolistbyProductId.Where(x => x.PiecesPerCase != null && x.PiecesPerCase != "").Select(x => x.PiecesPerCase).ToList().ToArray();
                if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Pieces Per Case" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }



                string[] sMaterial = objProductInfolistbyProductId.Where(x => x.Material != null && x.Material != "").Select(x => x.Material).ToList().ToArray();
                if (sMaterial != null && sMaterial.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Material" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sOrbitDiameter = objProductInfolistbyProductId.Where(x => x.OrbitDiameter != null && x.OrbitDiameter != "").Select(x => x.OrbitDiameter).ToList().ToArray();
                if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Orbit Diameter" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                decimal[] sMSRP = objProductInfolistbyProductId.Where(x => x.MSRP != null).Select(x => Convert.ToDecimal(x.MSRP)).ToList().ToArray();
                if (sMSRP != null && sMSRP.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "MSRP (USD)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                tblpartsSub.Controls.Add(trpartsheaderRow);

                int i = 0;
                foreach (var parts in objProductInfolistbyProductId)
                {
                    i++;
                    TableRow trdataRow = new TableRow();
                    TableCell tddatacell = new TableCell();

                    if (parts != null)
                    {

                        if (i % 2 == 0)
                        {
                            if (sPartNo != null && sPartNo.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartNo))
                                {
                                    tddatacell = new TableCell { Text = parts.PartNo };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartSize != null && sPartSize.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartSize))
                                {
                                    tddatacell = new TableCell { Text = parts.PartSize };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDiameter != null && sDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Diameter))
                                {
                                    tddatacell = new TableCell { Text = parts.Diameter };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThickness != null && sThickness.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Thickness))
                                {
                                    tddatacell = new TableCell { Text = parts.Thickness };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartMaxRPMs))
                                {
                                    tddatacell = new TableCell { Text = parts.PartMaxRPMs };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sType != null && sType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Type))
                                {
                                    tddatacell = new TableCell { Text = parts.Type };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sArbors != null && sArbors.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Arbors))
                                {
                                    tddatacell = new TableCell { Text = parts.Arbors };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sShape != null && sShape.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Shape))
                                {
                                    tddatacell = new TableCell { Text = parts.Shape };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sRecommended != null && sRecommended.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.RecommendedFor))
                                {
                                    tddatacell = new TableCell { Text = parts.RecommendedFor };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThreads != null && sThreads.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Threads))
                                {
                                    tddatacell = new TableCell { Text = parts.Threads };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sForUseOn != null && sForUseOn.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.ForUseOn))
                                {
                                    tddatacell = new TableCell { Text = parts.ForUseOn };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sFinish != null && sFinish.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Finish))
                                {
                                    tddatacell = new TableCell { Text = parts.Finish };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sGrit != null && sGrit.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Grit))
                                {
                                    tddatacell = new TableCell { Text = parts.Grit };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sColor != null && sColor.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Color))
                                {
                                    tddatacell = new TableCell { Text = parts.Color };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.DepthOfCut))
                                {
                                    tddatacell = new TableCell { Text = parts.DepthOfCut };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sQty != null && sQty.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Qty))
                                {
                                    tddatacell = new TableCell { Text = parts.Qty };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sBondType != null && sBondType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.BondType))
                                {
                                    tddatacell = new TableCell { Text = parts.BondType };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sContainer != null && sContainer.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Container))
                                {
                                    tddatacell = new TableCell { Text = parts.Container };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sDescription != null && sDescription.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Description))
                                {
                                    tddatacell = new TableCell { Text = parts.Description };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PiecesPerCase))
                                {
                                    tddatacell = new TableCell { Text = parts.PiecesPerCase };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sMaterial != null && sMaterial.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Material))
                                {
                                    tddatacell = new TableCell { Text = parts.Material };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.OrbitDiameter))
                                {
                                    tddatacell = new TableCell { Text = parts.OrbitDiameter };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sMSRP != null && sMSRP.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(parts.MSRP)))
                                {
                                    tddatacell = new TableCell { Text = Convert.ToString(parts.MSRP) };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                        }
                        else
                        {
                            if (sPartNo != null && sPartNo.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartNo))
                                {
                                    tddatacell = new TableCell { Text = parts.PartNo };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartSize != null && sPartSize.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartSize))
                                {
                                    tddatacell = new TableCell { Text = parts.PartSize };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDiameter != null && sDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Diameter))
                                {
                                    tddatacell = new TableCell { Text = parts.Diameter };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThickness != null && sThickness.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Thickness))
                                {
                                    tddatacell = new TableCell { Text = parts.Thickness };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartMaxRPMs))
                                {
                                    tddatacell = new TableCell { Text = parts.PartMaxRPMs };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sType != null && sType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Type))
                                {
                                    tddatacell = new TableCell { Text = parts.Type };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sArbors != null && sArbors.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Arbors))
                                {
                                    tddatacell = new TableCell { Text = parts.Arbors };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sShape != null && sShape.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Shape))
                                {
                                    tddatacell = new TableCell { Text = parts.Shape };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sRecommended != null && sRecommended.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.RecommendedFor))
                                {
                                    tddatacell = new TableCell { Text = parts.RecommendedFor };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThreads != null && sThreads.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Threads))
                                {
                                    tddatacell = new TableCell { Text = parts.Threads };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sForUseOn != null && sForUseOn.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.ForUseOn))
                                {
                                    tddatacell = new TableCell { Text = parts.ForUseOn };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sFinish != null && sFinish.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Finish))
                                {
                                    tddatacell = new TableCell { Text = parts.Finish };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sGrit != null && sGrit.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Grit))
                                {
                                    tddatacell = new TableCell { Text = parts.Grit };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sColor != null && sColor.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Color))
                                {
                                    tddatacell = new TableCell { Text = parts.Color };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.DepthOfCut))
                                {
                                    tddatacell = new TableCell { Text = parts.DepthOfCut };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sQty != null && sQty.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Qty))
                                {
                                    tddatacell = new TableCell { Text = parts.Qty };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sBondType != null && sBondType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.BondType))
                                {
                                    tddatacell = new TableCell { Text = parts.BondType };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sContainer != null && sContainer.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Container))
                                {
                                    tddatacell = new TableCell { Text = parts.Container };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sDescription != null && sDescription.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Description))
                                {
                                    tddatacell = new TableCell { Text = parts.Description };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PiecesPerCase))
                                {
                                    tddatacell = new TableCell { Text = parts.PiecesPerCase };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }


                            if (sMaterial != null && sMaterial.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Material))
                                {
                                    tddatacell = new TableCell { Text = parts.Material };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.OrbitDiameter))
                                {
                                    tddatacell = new TableCell { Text = parts.OrbitDiameter };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sMSRP != null && sMSRP.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(parts.MSRP)))
                                {
                                    tddatacell = new TableCell { Text = Convert.ToString(parts.MSRP) };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:right;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:right;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                        }

                        tblpartsSub.Controls.Add(trdataRow);

                    }
                }
            }
            else
            {
                partsTable.InnerHtml = "<span style='color:red; font-weight:bold;'>Currently, there are no Parts available for this product...</span>";
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);

            partsWithSpcs.Controls.Add(tblparts);

            Session["productId"] = productid;
        }
        catch (Exception)
        {
            //throw;itemA
        }
    }

    public void ProductDocumentation(int productid)
    {
        try
        {
            DataSet ds = this.GetProductDocFiles(productid);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var producttext = "<div  class='table-responsive'><table>";

                    foreach (DataRow drImage in ds.Tables[0].Rows)
                    {
                        if (drImage["DocType"].ToString() == "1")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if(!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "2")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "3")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "4")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "5")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "6")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }

                        if (drImage["DocType"].ToString() == "7")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }

                    }

                    producttext += "</table></div>";
                    documentation.InnerHtml = producttext;

                }
                else
                {
                    documentation.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
                }
            }
            else
            {
                documentation.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
            }

          

        }
        catch (Exception)
        {
            //throw;
        }
    }

    //public void ProductVideos(int productid)
    //{
    //    try
    //    {
    //        string videolist = "";
    //        var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
    //        if (objProductPage != null)
    //        {
    //           // productBanner.InnerHtml = objProductPage.PageName;
    //            var productVideos = new ProductVideoDa().GetAllProductVideoByProductId(Convert.ToInt32(objProductPage.ProductPageCode));
    //            if (productVideos != null)
    //            {
    //                if (productVideos.Count > 0)
    //                {
    //                    foreach (var vlist in productVideos)
    //                    {
    //                        var objVideo = new VideoDa().GetVideobyId(Convert.ToInt32(vlist.VideoID));

    //                        if (objVideo != null)
    //                        {
    //                            string sVImage = "";
    //                            if (!string.IsNullOrEmpty(objVideo.Vimage) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + objVideo.Vimage)))
    //                            {
    //                                sVImage = "<img src='../Files/Products/VideoImages/" + objVideo.Vimage + "' width='70px' style='display:inline; margin-right:8px;'>";
    //                            }
    //                            else
    //                            {
    //                                sVImage = "<img src='../Images/not_found_image.jpg' width='70px' style='display:inline; margin-right:8px;'>";
    //                            }

    //                            videolist += "<li style='width: 50%; float: left;'><a class='youtube-media' href='" + objVideo.VideoLink + "'>" + sVImage + objVideo.VideoName + "</a></li>";
    //                        }

    //                    }
    //                    videoList.InnerHtml = videolist;
    //                }
    //                else
    //                {
    //                    videoList.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no videos available for this product... </p>";
    //                }
    //            }
    //            Session["productId"] = objProductPage.ProductPageCode;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        //throw;
    //    }
    //}

    public void ProductVideos(int productid)
    {
        try
        {
            string videolist = "";
            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {
                // productBanner.InnerHtml = objProductPage.PageName;
                var productVideos = new ProductVideoDa().GetAllProductVideoByProductId(Convert.ToInt32(objProductPage.ProductPageCode));
                if (productVideos != null)
                {
                    if (productVideos.Count > 0)
                    {
                        foreach (var vlist in productVideos)
                        {
                            var objVideo = new VideoDa().GetVideobyId(Convert.ToInt32(vlist.VideoID));

                            if (objVideo != null)
                            {
                                if (objVideo.VCurrentYN != null && Convert.ToBoolean(objVideo.VCurrentYN) == true)
                                {
                                    string sVImage = "";
                                    string sVImageName = "";

                                    if (!string.IsNullOrEmpty(objVideo.Vimage) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + objVideo.Vimage)))
                                    {
                                        sVImage = "<img width='150' src='../Files/Products/VideoImages/" + objVideo.Vimage + "' />";
                                    }
                                    else
                                    {
                                        sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
                                    }
                                    //if (!string.IsNullOrEmpty(objVideo.VideoName))
                                    //{
                                    //    sVImageName = "<p>" + objVideo.VideoName + "</p>";
                                    //}

                                    if (!string.IsNullOrEmpty(objVideo.VideoName))
                                    {
                                        sVImageName = "<p>" + objVideo.VideoName + "</p>";
                                    }

                                    videolist += "<div class='boxVideo'><a style='font-weight: normal;' class='youtube-media' href='" + objVideo.VideoLink + "?autoplay=1&rel=0'>" + sVImage + sVImageName + "</a></div>";

                                }

                            }

                        }
                        videos.InnerHtml = videolist;
                    }
                    else
                    {
                        videos.InnerHtml = "<p> Currently, there are no videos available for this product... </p>";
                    }
                }
                Session["productId"] = objProductPage.ProductPageCode;
            }
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void ProductPartsWithDocument(int productid)
    {
        try
        {
            DataSet ds = this.GetProductDocFiles(productid);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var producttext = "<div  class='table-responsive'><table>";

                    foreach (DataRow drImage in ds.Tables[0].Rows)
                    {

                        if (drImage["DocType"].ToString() == "2")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }

                        if (drImage["DocType"].ToString() == "5")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }

                    }

                    producttext += "</table></div>";
                    // partsTable.InnerHtml = producttext;

                }
                else
                {
                    //  partsTable.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
                }
            }
            else
            {
                // partsTable.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
            }

            //var objPartPage = new PartsPageDa().GetPartsPagebyPPC(productid);

            //if (objPartPage != null)
            //{
            //    sparepartslink.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'><a class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' >Buy Spare Products</a> </p>";
            //}
            //else
            //{
            //    sparepartslink.InnerHtml = "";
            //}
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void RelatedProductByProductid(int productid)
    {
        try
        {
            string pgName = "";
            string imgSrc = "";
            int n = 0;
            DataTable dtRelatedProducts = new DataTable();
            dtRelatedProducts = WebUtility.GetRows("SELECT  Related  FROM ProductRelated where ProductPageCode = " + productid.ToString() + " and Related <> '' and Related is not null  order by RelatedOrderID asc  ");
            if (dtRelatedProducts != null && dtRelatedProducts.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRelatedProducts.Rows)
                {
                    try
                    {
                        if (dr["Related"] != null && dr["Related"].ToString() != "")
                        {
                            string product = dr["Related"].ToString();

                            bool isnumeric = int.TryParse(product, out n);
                            if (isnumeric)
                            {
                                var productPagbj = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(product));
                                if (productPagbj != null)
                                {
                                    var objProductRelatedText =
                                        new ProductRelatedTextDa().GetProductRelatedTextbyId(
                                            Convert.ToInt32(productPagbj.ProductPageCode));
                                    if (objProductRelatedText.Current == true)
                                    {
                                        if (!string.IsNullOrEmpty(productPagbj.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + productPagbj.ThumbNail)))
                                        {
                                            imgSrc = "/Files/Products/Thumbnails/" + productPagbj.ThumbNail;
                                        }
                                        else
                                        {
                                            imgSrc = "/Files/Products/Thumbnails/not_found_image.jpg";
                                        }
                                        pgName +=
                                            "<div class='client'>" +
                                            "<div class='listing-item' style='margin-bottom:0px; background-color:white;'>" +
                                            "<div class='overlay-container'>" +
                                            "<img class='section-imgdiv' alt='' src='" +
                                            imgSrc +
                                            "'>" +
                                            "<a class='overlay small' href='ProductDetails.aspx?PageCode=" +
                                            productPagbj.ProductPageCode + "'>" +
                                            "</a></div>";
                                        pgName +=
                                            "<div class='listing-item-body clearfix' style='padding-top:10px;'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                            productPagbj.ProductPageCode + "'>" +
                                            productPagbj.PageName +
                                            "</a></h3><p style='font-size:13.5px; color:#000'>" +
                                            objProductRelatedText.RelatedText + "</p></div></div></div>";
                                    }
                                }
                            }

                            else
                            {
                                string overview = "";
                                string websectionsql = "SELECT * FROM MWebSection ms WHERE ms.WebOverview LIKE '%" + product.ToString().Trim() + "%'";
                                var objMWebSection = new MWebSectionDa().GetMWebSectionbyBySQL(websectionsql);
                                if (objMWebSection != null)
                                {
                                    overview += " <span><a class='groupNameColor' style='font-size: 15px;' target='_blank' href='/Files/Overviews/" + product + ".html'>" + objMWebSection.WebSection + " overview</a><a style='color: #337ab7;font-size: 15px;margin-left: 12px;' target='_blank' href='/Files/Overviews/" + product + ".html'><i class='fa fa-file-text' aria-hidden='true'></i></a></span>";
                                }
                                overviewDiv.InnerHtml = overview;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }

            productDiv.InnerHtml = pgName;

        }
        catch (Exception ex)
        {
            //
        }

        //    var productText = new ProductTextDa().GetProductTextbyId(productid);
        //    var listOfProducts = productText.RelatedProduct.Split(';').ToList();
        //    if (listOfProducts != null)
        //    {
        //        if (listOfProducts.Count > 0)
        //        {
        //            foreach (var product in listOfProducts)
        //            {
        //                int n = 0;
        //                bool isnumeric = int.TryParse(product, out n);
        //                if (isnumeric)
        //                {
        //                    var productPagbj = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(product));
        //                    if (productPagbj != null)
        //                    {
        //                        var objProductRelatedText =
        //                            new ProductRelatedTextDa().GetProductRelatedTextbyId(
        //                                Convert.ToInt32(productPagbj.ProductPageCode));
        //                        if (objProductRelatedText.Current == true)
        //                        {
        //                            if (!string.IsNullOrEmpty(productPagbj.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + productPagbj.ThumbNail)))
        //                            {
        //                                imgSrc = "/Files/Products/Thumbnails/" + productPagbj.ThumbNail;
        //                            }
        //                            else
        //                            {
        //                                imgSrc = "/Files/Products/Thumbnails/not_found_image.jpg";
        //                            }
        //                            pgName +=
        //                                "<div class='client'>" +
        //                                "<div class='listing-item' style='margin-bottom:0px; background-color:white;'>" +
        //                                "<div class='overlay-container'>" +
        //                                "<img class='section-imgdiv' alt='' src='" +
        //                                imgSrc +
        //                                "'>" +
        //                                "<a class='overlay small' href='ProductDetails.aspx?PageCode=" +
        //                                productPagbj.ProductPageCode + "'>" +
        //                                "</a></div>";
        //                            pgName +=
        //                                "<div class='listing-item-body clearfix' style='padding-top:10px;'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
        //                                productPagbj.ProductPageCode + "'>" +
        //                                productPagbj.PageName +
        //                                "</a></h3><p style='font-size:13.5px; color:#000'>" +
        //                                objProductRelatedText.RelatedText + "</p></div></div></div>";
        //                        }
        //                    }
        //                }

        //                else
        //                {
        //                    string overview = "";
        //                    string websectionsql = "SELECT * FROM MWebSection ms WHERE ms.WebOverview LIKE '%" + product.ToString().Trim() + "%'";
        //                    var objMWebSection = new MWebSectionDa().GetMWebSectionbyBySQL(websectionsql);
        //                    if (objMWebSection != null)
        //                    {
        //                        overview += " <span><a class='groupNameColor' target='_blank' href='/Files/Overviews/" + product + ".html'>" + objMWebSection.WebSection + " overview</a><a style='color: #337ab7;font-size: 20px;margin-left: 12px;' target='_blank' href='/Files/Overviews/" + product + ".html'><i class='fa fa-file-text' aria-hidden='true'></i></a></span>";
        //                    }
        //                    overviewDiv.InnerHtml = overview;
        //                }
        //            }
        //        }
        //        productDiv.InnerHtml = pgName;
        //    }
        //}
        //catch (Exception e)
        //{
        //    //
        //}
    }

    public void GalleryImageSlide(int productid)
    {
        try
        {
            string gallarySliderImage = "";
            string subgallarySliderImage = "";
            var objProduct = new ProductPageDa().GetProductPagebyId(productid);
            if (objProduct.ProcessID != null || objProduct.ProcessID != 0)
            {
                if (objProduct.ProcessID == 1)
                {
                    wetdry.InnerHtml = "<img src='../Images/Wet.JPG' />";
                }
                else if (objProduct.ProcessID == 2)
                {
                    wetdry.InnerHtml = "<img src='../Images/dry.JPG' />";
                }
                else if (objProduct.ProcessID == 3)
                {
                    wetdry.InnerHtml = "<img src='../Images/wetdry.JPG' />";
                }
            }



            DataSet ds = this.GetProductImages(productid);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gallarySliderImage += "<ul id='image-gallery' class='gallery list-unstyled cS-hidden'>";

                    foreach (DataRow drImage in ds.Tables[0].Rows)
                    {
                        if (!string.IsNullOrEmpty(drImage["ImgFilename"].ToString()) && File.Exists(Server.MapPath("/Files/Products/Photos/" + drImage["ImgFilename"].ToString())))
                        {
                            gallarySliderImage += "<li data-thumb='/Files/Products/Photos/" + drImage["ImgFilename"].ToString() + "'><img src='/Files/Products/Photos/" + drImage["ImgFilename"].ToString() + "' /></li>";
                        }
                    }

                    gallarySliderImage += "</ul>";
                    gallery.InnerHtml = gallarySliderImage;

                }
            }
        }
        catch (Exception ex)
        {

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
            //Page.Title = "Contact Us for Cutting, Drilling, Grinding, Polishing & Profiling Tools for All Types of Materials";
        }
        catch (Exception ex)
        {

        }
    }

    private DataSet GetData(string sSQL)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(sSQL))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    public void ProductSpareParts(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;background-color: #ededee;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0; ");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
        tblparts.Attributes.Add("style", "width:100%;float:left;");

        string strSQL = " SELECT pi1.PartNo, isnull(P.Description,'') EcomDescription, isnull(p.Image,'') Image, isnull(pi1.MSRP,0) MSRP, isnull(P.QProductID, 0) QProductID, CAProp65Text =isnull((SELECT isnull(m.CAProp65Text,'') CAProp65Text from ProductFields pf, MCAProp65 m WHERE pf.PartNo = P.PartNo AND m.CAProp65ID = pf.CAProp65ID),'') FROM ProductInfo pi1, (SELECT pf.*, w.SORT4_Part FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + ") P WHERE pi1.PartNo = P.PartNo   ORDER BY P.SORT4_Part Asc ";

        DataSet ds = this.GetData(strSQL);
        buysparepartsDiv.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "IMAGE" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "PRICE (USD)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "CAProp65" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "BUY NOW" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center; width:100px;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["EcomDescription"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EcomDescription"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Image"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["Image"].ToString())))
                                {
                                    System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Files/Products/Parts/" + dr["Image"].ToString();
                                    tddatacell.Controls.Add(imgParts);
                                }

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CAProp65Text"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                //System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                //imgParts.Attributes.Add("runat", "server");
                                //imgParts.Width = 50;
                                //imgParts.ImageUrl = "/Images/Warning.png";
                                //imgParts.ToolTip = dr["CAProp65Text"].ToString();
                                //imgParts.OnClientClick = "javascript:showtext('" + dr["CAProp65Text"].ToString() + "')";
                                //tddatacell.Controls.Add(imgParts);

                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div style = \"width:50px;\" class=\"popup\" onclick=\"javascript:myFunction('P" + dr["PartNo"].ToString() + "')\"><img width=\"50\" src=\"/Images/Warning.png\" /><span class=\"popuptext\" id=\"P" + dr["PartNo"].ToString() + "\">" + dr["CAProp65Text"].ToString() + "</span></div>";
                                tddatacell.Controls.Add(addPDiv);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                tddatacell.Controls.Add(addPDiv);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left; ");
                                trdataRow.Controls.Add(tddatacell);
                            }




                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["EcomDescription"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EcomDescription"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Image"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["Image"].ToString())))
                                {
                                    System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Files/Products/Parts/" + dr["Image"].ToString();
                                    tddatacell.Controls.Add(imgParts);
                                }

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CAProp65Text"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };

                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div style = \"width:50px;\" class=\"popup\" onclick=\"javascript:myFunction('P" + dr["PartNo"].ToString() + "')\"><img width=\"50\" src=\"/Images/Warning.png\" /><span class=\"popuptext\" id=\"P" + dr["PartNo"].ToString() + "\">" + dr["CAProp65Text"].ToString() + "</span></div>";
                                tddatacell.Controls.Add(addPDiv);

                                //tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                //System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                //imgParts.Attributes.Add("runat", "server");
                                //imgParts.Width = 50;
                                //imgParts.ImageUrl = "/Images/Warning.png";
                                //imgParts.ToolTip = dr["CAProp65Text"].ToString();
                                //imgParts.OnClientClick = "javascript:showtext('" + dr["CAProp65Text"].ToString() + "')";
                                //tddatacell.Controls.Add(imgParts);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center; ");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                tddatacell.Controls.Add(addPDiv);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left; ");
                                trdataRow.Controls.Add(tddatacell);
                            }



                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            buysparepartsDiv.Controls.Add(tblparts);

            if (tblpartsSub.Rows.Count == 0)
                buysparepartsDiv.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
        else
        {
            buysparepartsDiv.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
    }

    public void ProductAdditional(int productid)
    {

        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;background-color: #ededee;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0; ");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
        tblparts.Attributes.Add("style", "width:100%;float:left;");

        string strSQL = "SELECT pf.* FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + "  ORDER BY w.SORT4_Part Asc";

        DataSet ds = this.GetData(strSQL);
        additionalDiv.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "PartNo" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "UPC Code" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Pkg. Weight (lbs)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Package Dimensions" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Commodity Code" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Country Of Origin" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["Barcode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Barcode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Weight"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Weight"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["PkgDimensions"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PkgDimensions"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CommodityCode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CommodityCode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CountryOrigin"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CountryOrigin"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["Barcode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Barcode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Weight"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Weight"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["PkgDimensions"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PkgDimensions"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CommodityCode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CommodityCode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CountryOrigin"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CountryOrigin"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }



                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            additionalDiv.Controls.Add(tblparts);

            if (tblpartsSub.Rows.Count == 0)
                additionalDiv.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
        else
        {
            additionalDiv.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
    }


    #endregion functions

    #region functions for accordion

    public void ProductSpecsChartAcc(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width: 100%;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblspcsSub = new Table();
        tblspcsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblspcsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trHeaderRow = new TableHeaderRow();
        trHeaderRow.Attributes.Add("style", "background:#fff;color:#337AB7;");
        TableHeaderCell tdHeaderCell = new TableHeaderCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

        DataSet ds = this.GetDataSpecs(productid);

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdHeaderCell = new TableHeaderCell { Text = "Product Details" };
                    tdHeaderCell.Attributes.Add("style", "text-align:center;font-size:16px;");
                    trHeaderRow.Controls.Add(tdHeaderCell);

                    tblspcsSub.Controls.Add(trHeaderRow);
                    tdparts.Controls.Add(tblspcsSub);
                    trparts.Controls.Add(tdparts);
                    tblparts.Controls.Add(trparts);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Specification" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Data" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["SpecsName"].ToString()) && !string.IsNullOrEmpty(dr["SpecsData"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["SpecsName"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }

                                tddatacell = new TableCell { Text = dr["SpecsData"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["SpecsName"].ToString()) && !string.IsNullOrEmpty(dr["SpecsData"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["SpecsName"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["SpecsData"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            specsChrtAcc.Controls.Add(tblparts);
        }
    }

    public void ProductEquipsChartAcc(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width: 100%;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblspcsSub = new Table();
        tblspcsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblspcsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trHeaderRow = new TableHeaderRow();
        trHeaderRow.Attributes.Add("style", "background:#fff;color:#337AB7;");
        TableHeaderCell tdHeaderCell = new TableHeaderCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();


        DataSet ds = this.GetDataEquips(productid);

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdHeaderCell = new TableHeaderCell { Text = "Equipment Included" };
                    tdHeaderCell.Attributes.Add("style", "text-align:center;font-size:16px;");
                    trHeaderRow.Controls.Add(tdHeaderCell);

                    tblspcsSub.Controls.Add(trHeaderRow);
                    tdparts.Controls.Add(tblspcsSub);
                    trparts.Controls.Add(tdparts);
                    tblparts.Controls.Add(trparts);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Item" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Quantity" };
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["EquipIncluded"].ToString()) && !string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EquipIncluded"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["Qty"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["EquipIncluded"].ToString()) && !string.IsNullOrEmpty(dr["Qty"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EquipIncluded"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                                tddatacell = new TableCell { Text = dr["Qty"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }
            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            equipsChartAcc.Controls.Add(tblparts);

        }
    }

    public void ProductFeatureAccordion(int productid)
    {
        try
        {
            string productfeature = "";
            DataSet ds = this.GetData(productid);
            if (ds != null)
            {

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        productfeature += "<li>" + dr["PBText"].ToString() + "</li>";
                    }
                }
                if (productfeature != null)
                {
                    prdFeaturesAcc.InnerHtml = productfeature;
                }

            }
            Session["productId"] = productid;
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void ProductDetailsAccordion(int productid)
    {
        try
        {
            var objProductText = new ProductTextDa().GetProductTextbyId(Convert.ToInt32(productid));
            if (objProductText != null)
            {
                string producttext = "";
                if (objProductText.ProductText1 != "" || objProductText.ProductText1 != null)
                {
                    producttext = "<p align='justify'>" + objProductText.ProductText1 +
                                  "</p>";
                }
                Session["productId"] = objProductText.ProductPageCode;
                prdDetailAcc.InnerHtml = producttext;
            }
        }
        catch (Exception)
        {
            //throw;
        }

    }

    public void ProductSpecificationAccordion(int productid)
    {
        try
        {

            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {
                string imgSrc = "";
                var producttext = "";

                if (objProductPage.SpecChart != null || objProductPage.GritChart != null)
                {
                    ProductSpecsChartAcc(productid);
                    ProductEquipsChartAcc(productid);

                    if (objProductPage.ChartLayout == "P")
                    {
                        ProductSpecificationWithPartsAccordion(productid);
                    }

                    if (objProductPage.ChartLayout == "G")
                    {
                        if (File.Exists(Server.MapPath("/Files/Products/SpecCharts/" + objProductPage.GritChart + "")))
                        {
                            imgSrc = "/Files/Products/SpecCharts/" + objProductPage.GritChart + "";
                        }
                        if (imgSrc != null)
                        {
                            producttext = "<img style='max-width:100%' alt='' src='" + imgSrc + "'>";
                            partsTblAccc.InnerHtml = producttext;
                        }
                    }

                }
                else
                {
                    ProductSpecificationWithPartsAccordion(productid);
                }
                Session["productId"] = objProductPage.ProductPageCode;
            }
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void ProductSpecificationWithPartsAccordion(int productid)
    {
        try
        {
            Table tblparts = new Table();
            tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;");
            TableRow trparts = new TableRow();
            TableCell tdparts = new TableCell();

            Table tblpartsSub = new Table();
            tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
            tblpartsSub.Attributes.Add("style", "border:2px solid #3379B7;margin-bottom:0");
            TableHeaderRow trpartsheaderRow = new TableHeaderRow();
            trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#ffffff;");
            TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
            tblparts.Attributes.Add("style", "width:100%;float:left;");
            string sql = "SELECT pi1.* FROM ProductInfo pi1,(SELECT pf.*, w.SORT4_Part FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + ") P WHERE pi1.PartNo = P.PartNo ORDER BY p.SORT4_Part Asc";
            int k = 0;
            var objProductInfolistbyProductId = new ProductInfoDa().GetAllProductInfoBySQL(sql);
            if (objProductInfolistbyProductId.Count > 0)
            {
                string[] sPartNo = objProductInfolistbyProductId.Where(x => x.PartNo != null && x.PartNo != "").Select(x => x.PartNo).ToList().ToArray();
                if (sPartNo != null && sPartNo.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Part No." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sPartSize = objProductInfolistbyProductId.Where(x => x.PartSize != null && x.PartSize != "").Select(x => x.PartSize).ToList().ToArray();
                if (sPartSize != null && sPartSize.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Size" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sDiameter = objProductInfolistbyProductId.Where(x => x.Diameter != null && x.Diameter != "").Select(x => x.Diameter).ToList().ToArray();
                if (sDiameter != null && sDiameter.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Diameter" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                string[] sThickness = objProductInfolistbyProductId.Where(x => x.Thickness != null && x.Thickness != "").Select(x => x.Thickness).ToList().ToArray();
                if (sThickness != null && sThickness.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Thickness" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sPartMaxRPMs = objProductInfolistbyProductId.Where(x => x.PartMaxRPMs != null && x.PartMaxRPMs != "").Select(x => x.PartMaxRPMs).ToList().ToArray();
                if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Maximum RPM" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sType = objProductInfolistbyProductId.Where(x => x.Type != null && x.Type != "").Select(x => x.Type).ToList().ToArray();
                if (sType != null && sType.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Type" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sArbors = objProductInfolistbyProductId.Where(x => x.Arbors != null && x.Arbors != "").Select(x => x.Arbors).ToList().ToArray();
                if (sArbors != null && sArbors.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Arbor(s)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sShape = objProductInfolistbyProductId.Where(x => x.Shape != null && x.Shape != "").Select(x => x.Shape).ToList().ToArray();
                if (sShape != null && sShape.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Shape" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sRecommended = objProductInfolistbyProductId.Where(x => x.RecommendedFor != null && x.RecommendedFor != "").Select(x => x.RecommendedFor).ToList().ToArray();
                if (sRecommended != null && sRecommended.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Recommended For" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sThreads = objProductInfolistbyProductId.Where(x => x.Threads != null && x.Threads != "").Select(x => x.Threads).ToList().ToArray();
                if (sThreads != null && sThreads.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Threads" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sForUseOn = objProductInfolistbyProductId.Where(x => x.ForUseOn != null && x.ForUseOn != "").Select(x => x.ForUseOn).ToList().ToArray();
                if (sForUseOn != null && sForUseOn.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "For Use On" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sFinish = objProductInfolistbyProductId.Where(x => x.Finish != null && x.Finish != "").Select(x => x.Finish).ToList().ToArray();
                if (sFinish != null && sFinish.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Finish" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sGrit = objProductInfolistbyProductId.Where(x => x.Grit != null && x.Grit != "").Select(x => x.Grit).ToList().ToArray();
                if (sGrit != null && sGrit.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Grit" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sColor = objProductInfolistbyProductId.Where(x => x.Color != null && x.Color != "").Select(x => x.Color).ToList().ToArray();
                if (sColor != null && sColor.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Color" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sDepthOfCut = objProductInfolistbyProductId.Where(x => x.DepthOfCut != null && x.DepthOfCut != "").Select(x => x.DepthOfCut).ToList().ToArray();
                if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Depth Of Cut" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sQty = objProductInfolistbyProductId.Where(x => x.Qty != null && x.Qty != "").Select(x => x.Qty).ToList().ToArray();
                if (sQty != null && sQty.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Qty" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sBondType = objProductInfolistbyProductId.Where(x => x.BondType != null && x.BondType != "").Select(x => x.BondType).ToList().ToArray();
                if (sBondType != null && sBondType.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "BondType" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sContainer = objProductInfolistbyProductId.Where(x => x.Container != null && x.Container != "").Select(x => x.Container).ToList().ToArray();
                if (sContainer != null && sContainer.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Container" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sDescription = objProductInfolistbyProductId.Where(x => x.Description != null && x.Description != "").Select(x => x.Description).ToList().ToArray();
                if (sDescription != null && sDescription.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Description" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sPiecesPerCase = objProductInfolistbyProductId.Where(x => x.PiecesPerCase != null && x.PiecesPerCase != "").Select(x => x.PiecesPerCase).ToList().ToArray();
                if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Pieces Per Case" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }


                string[] sMaterial = objProductInfolistbyProductId.Where(x => x.Material != null && x.Material != "").Select(x => x.Material).ToList().ToArray();
                if (sMaterial != null && sMaterial.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Material" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                string[] sOrbitDiameter = objProductInfolistbyProductId.Where(x => x.OrbitDiameter != null && x.OrbitDiameter != "").Select(x => x.OrbitDiameter).ToList().ToArray();
                if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "Orbit Diameter" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }
                decimal[] sMSRP = objProductInfolistbyProductId.Where(x => x.MSRP != null).Select(x => Convert.ToDecimal(x.MSRP)).ToList().ToArray();
                if (sMSRP != null && sMSRP.Length > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "MSRP$" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);
                }

                tblpartsSub.Controls.Add(trpartsheaderRow);

                int i = 0;
                foreach (var parts in objProductInfolistbyProductId)
                {
                    i++;
                    TableRow trdataRow = new TableRow();
                    TableCell tddatacell = new TableCell();

                    if (parts != null)
                    {

                        if (i % 2 == 0)
                        {
                            if (sPartNo != null && sPartNo.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartNo))
                                {
                                    tddatacell = new TableCell { Text = parts.PartNo };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartSize != null && sPartSize.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartSize))
                                {
                                    tddatacell = new TableCell { Text = parts.PartSize };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDiameter != null && sDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Diameter))
                                {
                                    tddatacell = new TableCell { Text = parts.Diameter };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThickness != null && sThickness.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Thickness))
                                {
                                    tddatacell = new TableCell { Text = parts.Thickness };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartMaxRPMs))
                                {
                                    tddatacell = new TableCell { Text = parts.PartMaxRPMs };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sType != null && sType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Type))
                                {
                                    tddatacell = new TableCell { Text = parts.Type };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sArbors != null && sArbors.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Arbors))
                                {
                                    tddatacell = new TableCell { Text = parts.Arbors };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sShape != null && sShape.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Shape))
                                {
                                    tddatacell = new TableCell { Text = parts.Shape };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sRecommended != null && sRecommended.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.RecommendedFor))
                                {
                                    tddatacell = new TableCell { Text = parts.RecommendedFor };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThreads != null && sThreads.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Threads))
                                {
                                    tddatacell = new TableCell { Text = parts.Threads };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sForUseOn != null && sForUseOn.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.ForUseOn))
                                {
                                    tddatacell = new TableCell { Text = parts.ForUseOn };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sFinish != null && sFinish.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Finish))
                                {
                                    tddatacell = new TableCell { Text = parts.Finish };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sGrit != null && sGrit.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Grit))
                                {
                                    tddatacell = new TableCell { Text = parts.Grit };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sColor != null && sColor.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Color))
                                {
                                    tddatacell = new TableCell { Text = parts.Color };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.DepthOfCut))
                                {
                                    tddatacell = new TableCell { Text = parts.DepthOfCut };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sQty != null && sQty.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Qty))
                                {
                                    tddatacell = new TableCell { Text = parts.Qty };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sBondType != null && sBondType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.BondType))
                                {
                                    tddatacell = new TableCell { Text = parts.BondType };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sContainer != null && sContainer.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Container))
                                {
                                    tddatacell = new TableCell { Text = parts.Container };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sDescription != null && sDescription.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Description))
                                {
                                    tddatacell = new TableCell { Text = parts.Description };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PiecesPerCase))
                                {
                                    tddatacell = new TableCell { Text = parts.PiecesPerCase };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sMaterial != null && sMaterial.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Material))
                                {
                                    tddatacell = new TableCell { Text = parts.Material };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.OrbitDiameter))
                                {
                                    tddatacell = new TableCell { Text = parts.OrbitDiameter };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sMSRP != null && sMSRP.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(parts.MSRP)))
                                {
                                    tddatacell = new TableCell { Text = Convert.ToString(parts.MSRP) };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                        }
                        else
                        {
                            if (sPartNo != null && sPartNo.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartNo))
                                {
                                    tddatacell = new TableCell { Text = parts.PartNo };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartSize != null && sPartSize.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartSize))
                                {
                                    tddatacell = new TableCell { Text = parts.PartSize };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDiameter != null && sDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Diameter))
                                {
                                    tddatacell = new TableCell { Text = parts.Diameter };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThickness != null && sThickness.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Thickness))
                                {
                                    tddatacell = new TableCell { Text = parts.Thickness };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPartMaxRPMs != null && sPartMaxRPMs.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PartMaxRPMs))
                                {
                                    tddatacell = new TableCell { Text = parts.PartMaxRPMs };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sType != null && sType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Type))
                                {
                                    tddatacell = new TableCell { Text = parts.Type };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sArbors != null && sArbors.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Arbors))
                                {
                                    tddatacell = new TableCell { Text = parts.Arbors };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sShape != null && sShape.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Shape))
                                {
                                    tddatacell = new TableCell { Text = parts.Shape };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sRecommended != null && sRecommended.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.RecommendedFor))
                                {
                                    tddatacell = new TableCell { Text = parts.RecommendedFor };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sThreads != null && sThreads.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Threads))
                                {
                                    tddatacell = new TableCell { Text = parts.Threads };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sForUseOn != null && sForUseOn.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.ForUseOn))
                                {
                                    tddatacell = new TableCell { Text = parts.ForUseOn };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sFinish != null && sFinish.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Finish))
                                {
                                    tddatacell = new TableCell { Text = parts.Finish };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sGrit != null && sGrit.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Grit))
                                {
                                    tddatacell = new TableCell { Text = parts.Grit };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sColor != null && sColor.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Color))
                                {
                                    tddatacell = new TableCell { Text = parts.Color };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sDepthOfCut != null && sDepthOfCut.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.DepthOfCut))
                                {
                                    tddatacell = new TableCell { Text = parts.DepthOfCut };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sQty != null && sQty.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Qty))
                                {
                                    tddatacell = new TableCell { Text = parts.Qty };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sBondType != null && sBondType.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.BondType))
                                {
                                    tddatacell = new TableCell { Text = parts.BondType };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sContainer != null && sContainer.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Container))
                                {
                                    tddatacell = new TableCell { Text = parts.Container };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sDescription != null && sDescription.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Description))
                                {
                                    tddatacell = new TableCell { Text = parts.Description };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:left;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }

                            if (sPiecesPerCase != null && sPiecesPerCase.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.PiecesPerCase))
                                {
                                    tddatacell = new TableCell { Text = parts.PiecesPerCase };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }


                            if (sMaterial != null && sMaterial.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.Material))
                                {
                                    tddatacell = new TableCell { Text = parts.Material };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sOrbitDiameter != null && sOrbitDiameter.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(parts.OrbitDiameter))
                                {
                                    tddatacell = new TableCell { Text = parts.OrbitDiameter };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }

                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:center;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            if (sMSRP != null && sMSRP.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(parts.MSRP)))
                                {
                                    tddatacell = new TableCell { Text = Convert.ToString(parts.MSRP) };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:right;");
                                    if (tddatacell != null)
                                    {
                                        trdataRow.Controls.Add(tddatacell);
                                    }
                                }
                                else
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "color:#404040;text-align:right;");
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                        }

                        tblpartsSub.Controls.Add(trdataRow);

                    }
                }
            }
            else
            {
                partsTable.InnerHtml = "<span style='color:red; font-weight:bold;'>Currently, there are no Parts available for this product...</span>";
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);

            partsTblAccc.Controls.Add(tblparts);

            Session["productId"] = productid;
        }
        catch (Exception)
        {
            //throw;
        }
    }

    public void ProductDocumentationAccordion(int productid)
    {
        try
        {
            DataSet ds = this.GetProductDocFiles(productid);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var producttext = "<div  class='table-responsive'><table>";

                    foreach (DataRow drImage in ds.Tables[0].Rows)
                    {
                        if (drImage["DocType"].ToString() == "1")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "2")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "3")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "4")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "5")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }
                        if (drImage["DocType"].ToString() == "6")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }

                        if (drImage["DocType"].ToString() == "7")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";
                            }
                            else if (!string.IsNullOrEmpty(drImage["URLLink"].ToString()))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='" + drImage["URLLink"].ToString() + "' target='_blank'>" + drImage["DocTitle"].ToString() + "</a></td></tr>";

                            }
                        }

                    }

                    producttext += "</table></div>";
                    documentDivAcc.InnerHtml = producttext;

                }
                else
                {
                    documentDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
                }
            }
            else
            {
                documentDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no documents available for this product....... </p>";
            }

            var objPartPage = new PartsPageDa().GetPartsPagebyPPC(productid);

            if (objPartPage != null)
            {
                sparepartsDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'><a class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' >Buy Spare Products</a> </p>";
            }
            else
            {
                sparepartsDivAcc.InnerHtml = "";
            }

        }

        catch (Exception)
        {
            //throw;
        }
    }

    //public void ProductVideosAccordion(int productid)
    //{
    //    try
    //    {
    //        string videolist = "";
    //        var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
    //        if (objProductPage != null)
    //        {
    //            //productBanner.InnerHtml = objProductPage.PageName;
    //            var productVideos = new ProductVideoDa().GetAllProductVideoByProductId(Convert.ToInt32(objProductPage.ProductPageCode));
    //            if (productVideos != null)
    //            {
    //                if (productVideos.Count > 0)
    //                {
    //                    foreach (var vlist in productVideos)
    //                    {
    //                        var objVideo = new VideoDa().GetVideobyId(Convert.ToInt32(vlist.VideoID));
    //                        if (objVideo != null)
    //                        {
    //                            string sVImage = "";
    //                            if (!string.IsNullOrEmpty(objVideo.Vimage) &&
    //                                File.Exists(Server.MapPath("/Files/Products/VideoImages/" + objVideo.Vimage)))
    //                            {
    //                                sVImage = "<img src='../Files/Products/VideoImages/" + objVideo.Vimage +
    //                                          "' width='70px' style='display:inline; margin-right:8px;'>";
    //                            } else
    //                            {
    //                                sVImage = "<img src='../Images/not_found_image.jpg' width='70px' style='display:inline; margin-right:8px;'>";
    //                            }


    //                            videolist += "<li style='width: 50%; float: left;'><a class='youtube-media' href='" + objVideo.VideoLink + "'>" + sVImage + objVideo.VideoName + "</a></li>";
    //                        }

    //                    }

    //                    AccvideoList.InnerHtml = videolist;
    //                }
    //                else
    //                {
    //                    AccvideoList.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no videos available for this product.... </p>";
    //                }
    //            }

    //            Session["productId"] = objProductPage.ProductPageCode;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        //throw;
    //    }
    //}

    public void ProductVideosAccordion(int productid)
    {
        try
        {
            string videolist = "";
            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {
                //productBanner.InnerHtml = objProductPage.PageName;
                var productVideos = new ProductVideoDa().GetAllProductVideoByProductId(Convert.ToInt32(objProductPage.ProductPageCode));
                if (productVideos != null)
                {
                    if (productVideos.Count > 0)
                    {
                        foreach (var vlist in productVideos)
                        {
                            var objVideo = new VideoDa().GetVideobyId(Convert.ToInt32(vlist.VideoID));
                            if (objVideo != null)
                            {
                                if (objVideo.VCurrentYN != null && Convert.ToBoolean(objVideo.VCurrentYN) == true)
                                {
                                    string sVImage = "";
                                    string sVImageName = "";

                                    if (!string.IsNullOrEmpty(objVideo.Vimage) && File.Exists(Server.MapPath("/Files/Products/VideoImages/" + objVideo.Vimage)))
                                    {
                                        sVImage = "<img width='150' src='../Files/Products/VideoImages/" + objVideo.Vimage + "' />";
                                    }
                                    else
                                    {
                                        sVImage = "<img width='123' src='../Images/not_found_image.jpg' />";
                                    }
                                    //if (!string.IsNullOrEmpty(objVideo.VideoName))
                                    //{
                                    //    sVImageName = "<p>" + objVideo.VideoName + "</p>";
                                    //}
                                    if (!string.IsNullOrEmpty(objVideo.VideoName))
                                    {
                                        sVImageName = "<p>" + objVideo.VideoName + "</p>";
                                    }
                                    videolist += "<div class='boxVideo VideoDiv'><a style='font-weight: normal;' class='youtube-media' href='" + objVideo.VideoLink + "?autoplay=1&rel=0'>" + sVImage + sVImageName + "</a></div>";

                                }
                            }

                        }

                        AccvideoLst.InnerHtml = videolist;
                    }
                    else
                    {
                        AccvideoLst.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no videos available for this product.... </p>";
                    }
                }

                Session["productId"] = objProductPage.ProductPageCode;
            }
        }
        catch (Exception)
        {
            //throw;
        }
    }


    public void ProductPartsWithDocumentAccordion(int productid)
    {
        try
        {
            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {

                var producttext = "<div class='table-responsive'><table>";
                if (objProductPage.PartsList != null && objProductPage.PartsList > 0)
                {
                    var objPartsList = new MPartsListDa().GetMPartsListbyId(Convert.ToInt32(objProductPage.PartsList));

                    producttext += "<tr><td><span class='docspan'>Parts List : </span></td><td><a class='textColor' href='/Files/PartsList/PDFs/"
                                   + objPartsList.MPartsListLink + "' target='_blank'>" + objPartsList.MPartsListLink + "</a></td></tr>";
                    producttext += "</table></div>";
                    //   partsDivAcc.InnerHtml = producttext;
                }
                else
                {
                    //  partsDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no references available for this product </p>";
                }

                Session["productId"] = objProductPage.ProductPageCode;

            }

            //var objPartPage = new PartsPageDa().GetPartsPagebyPPC(productid);

            //if (objPartPage != null)
            //{
            //    sparepartsDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'><a class='textColor' href='/Pages/SparePartDetails.aspx?PageCode=" + productid.ToString() + "' >Buy Spare Products</a> </p>";
            //}
            //else
            //{
            //    sparepartsDivAcc.InnerHtml = "";
            //}
        }
        catch (Exception)
        {

        }
    }

    public void ProductFaqsAccordion(int productid)
    {
        try
        {
            string sqlfaq = "SELECT * FROM TNTechNoteFAQ tnf WHERE tnf.TNID IN(SELECT tn.TNID FROM TNTechNote tn WHERE tn.ProductPageCode=" + productid + ")";
            string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
            DataSet dsFaq = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlfaq))
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        dsFaq = ds;
                    }
                }
            }

            string faqtext = "";

            if (dsFaq != null && dsFaq.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsFaq.Tables[0].Rows)
                {

                    if (dr["TNQText"] != null)
                    {
                        faqtext += "<p align='justify' style='margin-bottom:10px;'><strong>Question :</strong> " + dr["TNQText"].ToString() + "<br /></p>";
                    }
                    if (dr["TNAText"] != null)
                    {
                        faqtext += "<p align='justify' style='border-bottom:1px solid;padding-bottom:10px;'><strong>Answer :</strong> " + dr["TNAText"].ToString() + "<br /></p>";
                    }
                }
            }
            else
            {
                faqtext += "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no FAQs available for this product..... </p>";
            }

            faqDivAcc.InnerHtml = faqtext;
            Session["productId"] = productid;
        }
        catch (Exception ex)
        {
            //throw;
        }

    }

    public void ProductSparePartsAccordion(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width: 100%; float:left;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

        string strSQL = " SELECT pi1.PartNo, isnull(P.Description,'') EcomDescription, isnull(p.Image,'') Image, isnull(pi1.MSRP,0) MSRP, isnull(P.QProductID, 0) QProductID, CAProp65Text =isnull((SELECT isnull(m.CAProp65Text,'') CAProp65Text from ProductFields pf, MCAProp65 m WHERE pf.PartNo = P.PartNo AND m.CAProp65ID = pf.CAProp65ID),'') FROM ProductInfo pi1, (SELECT pf.*, w.SORT4_Part FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + ") P WHERE pi1.PartNo = P.PartNo   ORDER BY P.SORT4_Part Asc ";

        DataSet ds = this.GetData(strSQL);

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    //tdpartsheaderCell = new TableHeaderCell { Text = "Image" };
                    //tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    //tdpartsheaderCell.Width = 100;
                    //trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "PRICE (USD)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "WARNING" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "BUY NOW" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    tdpartsheaderCell.Width = 100;
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }


                            if (!string.IsNullOrEmpty(dr["EcomDescription"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EcomDescription"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }



                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CAProp65Text"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                //tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                //System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                //imgParts.Attributes.Add("runat", "server");
                                //imgParts.Width = 50;
                                //imgParts.ImageUrl = "/Images/Warning.png";
                                //imgParts.ToolTip = dr["CAProp65Text"].ToString();
                                //imgParts.OnClientClick = "javascript:showtext('" + dr["CAProp65Text"].ToString() + "')";
                                //tddatacell.Controls.Add(imgParts);

                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div style = \"width:50px;\" class=\"popup\" onclick=\"javascript:myFunction('P" + dr["PartNo"].ToString() + "')\"><img width=\"50\" src=\"/Images/Warning.png\" /><span class=\"popuptext\" id=\"P" + dr["PartNo"].ToString() + "\">" + dr["CAProp65Text"].ToString() + "</span></div>";
                                tddatacell.Controls.Add(addPDiv);


                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                System.Web.UI.HtmlControls.HtmlGenericControl accAddProductDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                accAddProductDiv.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                tddatacell.Controls.Add(accAddProductDiv);
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left; ");
                                trdataRow.Controls.Add(tddatacell);
                            }



                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["EcomDescription"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["EcomDescription"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }



                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CAProp65Text"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                //tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                //System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                //imgParts.Attributes.Add("runat", "server");
                                //imgParts.Width = 50;
                                //imgParts.ImageUrl = "/Images/Warning.png";
                                //imgParts.ToolTip = dr["CAProp65Text"].ToString();
                                //imgParts.OnClientClick = "javascript:showtext('" + dr["CAProp65Text"].ToString() + "')";
                                //tddatacell.Controls.Add(imgParts);

                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                System.Web.UI.HtmlControls.HtmlGenericControl addPDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addPDiv.InnerHtml = "<div style = \"width:50px;\" class=\"popup\" onclick=\"javascript:myFunction('P" + dr["PartNo"].ToString() + "')\"><img width=\"50\" src=\"/Images/Warning.png\" /><span class=\"popuptext\" id=\"P" + dr["PartNo"].ToString() + "\">" + dr["CAProp65Text"].ToString() + "</span></div>";
                                tddatacell.Controls.Add(addPDiv);


                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }

                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");

                                System.Web.UI.HtmlControls.HtmlGenericControl accAddProductDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                accAddProductDiv1.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                tddatacell.Controls.Add(accAddProductDiv1);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }



                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            sparepartdivAcc.Controls.Add(tblparts);
            if (tblpartsSub.Rows.Count == 0)
                sparepartdivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no Ecommerce available for this product </p>";
        }
        else
        {
            sparepartdivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'> Currently, there are no Ecommerce available for this product </p>";
        }
    }

    public void ProductAdditionalAccordion(int productid)
    {

        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;background-color: #ededee;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0; ");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
        tblparts.Attributes.Add("style", "width:100%;float:left;");

        string strSQL = "SELECT pf.* FROM Webfields w, ProductFields pf WHERE w.PartNo = pf.PartNo and w.ProductPageCode= " + productid + "  ORDER BY w.SORT4_Part Asc";

        DataSet ds = this.GetData(strSQL);
        buysparepartsDiv.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "PartNo" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Weight (Packaged)" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "UPS Code" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Package Dimensions" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Commodity Code" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "Country Of Origin" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;

                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Weight"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Weight"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["Barcode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Barcode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["PkgDimensions"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PkgDimensions"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CommodityCode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CommodityCode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CountryOrigin"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CountryOrigin"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["Weight"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Weight"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["Barcode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Barcode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["PkgDimensions"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PkgDimensions"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }
                            if (!string.IsNullOrEmpty(dr["CommodityCode"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CommodityCode"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["CountryOrigin"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["CountryOrigin"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }

                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            AdditionalDivAcc.Controls.Add(tblparts);

            if (tblpartsSub.Rows.Count == 0)
                AdditionalDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
        else
        {
            AdditionalDivAcc.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold;'> Currently, there are no Ecommerce available for this product </p>";
        }
    }

    #endregion functions for accordion

    #region events
    protected void specsBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 0;
            if (Session["productId"] != null)
            {
                ProductSpecification(Convert.ToInt32(Session["productId"]));
            }
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            //  partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("selectedcss", "tabclass"));
            sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("selectedcss", "buyButtonclass"));



            specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            detailsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            //  partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            btnadditional.ForeColor = ColorTranslator.FromHtml("#fff");
            btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {
            //throw;
        }
    }
    protected void detailsBtn_OnClick(object sender, EventArgs e)
    {
        ProductDetailsMultiView.ActiveViewIndex = 1;
        if (Session["productId"] != null)
        {
            ProductDetails(Convert.ToInt32(Session["productId"]));
        }
        detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
        documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
        specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
        // partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
        faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));
        additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("selectedcss", "tabclass"));
        sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("selectedcss", "buyButtonclass"));



        detailsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
        specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        //  partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        btnadditional.ForeColor = ColorTranslator.FromHtml("#fff");
        btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#fff");
    }
    protected void documentBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 2;
            if (Session["productId"] != null)
            {
                ProductDocumentation(Convert.ToInt32(Session["productId"]));
            }
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            // partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("selectedcss", "tabclass"));
            sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("selectedcss", "buyButtonclass"));



            documentBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            detailsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            //  partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            btnadditional.ForeColor = ColorTranslator.FromHtml("#fff");
            btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {
            //throw;
        }
    }

    protected void faqBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 4;
            if (Session["productId"] != null)
            {
                ProductFaqs(Convert.ToInt32(Session["productId"]));
            }
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            // partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("selectedcss", "tabclass"));
            sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("selectedcss", "buyButtonclass"));



            faqBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            //  partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            detailsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            btnadditional.ForeColor = ColorTranslator.FromHtml("#fff");
            btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#fff");

        }
        catch (Exception)
        {

            //throw;
        }
    }
    protected void btnBuySpareParts_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 6;

            if (Session["productId"] != null)
            {
                ProductSpareParts(Convert.ToInt32(Session["productId"]));
            }

            sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("buyButtonclass", "selectedcss"));
            //   partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("selectedcss", "tabclass"));



            btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#666666");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            //  partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            detailsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            btnadditional.ForeColor = ColorTranslator.FromHtml("#fff");

        }
        catch (Exception)
        {

            //throw;
        }
    }
    protected void btnadditional_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 5;
            if (Session["productId"] != null)
            {
                ProductAdditional(Convert.ToInt32(Session["productId"]));
            }
            additionalli.Attributes.Add("class", additionalli.Attributes["class"].Replace("tabclass", "selectedcss"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            detailsLi.Attributes.Add("class", detailsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            //    partsLi.Attributes.Add("class", partsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            sparepartli.Attributes.Add("class", sparepartli.Attributes["class"].Replace("selectedcss", "buyButtonclass"));


            btnadditional.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            detailsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            //    partsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            btnBuySpareParts.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {
            //throw;
        }
    }
    protected void findDealerbtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/Pages/RequestADealerInfo.aspx");
        }
        catch (Exception)
        {

            //throw;
        }
    }
    protected void videosBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductFeatureMultiview.ActiveViewIndex = 0;
            if (Session["productId"] != null)
            {
                ProductVideos(Convert.ToInt32(Session["productId"]));
            }
            //btnFeatures.BackColor = ColorTranslator.FromHtml("#f0f0f5");
            //findDealerbtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
            //buyOnlineBtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
            //videosBtn.BackColor = ColorTranslator.FromHtml("#fafafa");
        }
        catch (Exception)
        {

            //throw;
        }
    }
    protected void btnFeatures_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductFeatureMultiview.ActiveViewIndex = 1;
            if (Session["productId"] != null)
            {
                ProductFeature(Convert.ToInt32(Session["productId"]));
            }
            //btnFeatures.BackColor = ColorTranslator.FromHtml("#fafafa");
            //findDealerbtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
            //buyOnlineBtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
            //videosBtn.BackColor = ColorTranslator.FromHtml("#f0f0f5");
        }
        catch (Exception)
        {
            //throw;
        }
    }
    #endregion

}

