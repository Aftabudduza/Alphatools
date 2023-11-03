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

public partial class pages_SparePartDetails : Page
{
    private int _productId = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["ButtonText"] = null;
            //Session["SearchKeywords"] = null;
            loadSEOContent();
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
                ProductSpecification(_productId);
                ProductSparePartsAccordion(_productId);
                ProductDocumentationAccordion(_productId);
                ProductFaqsAccordion(_productId);
                ProductDetailsMultiView.ActiveViewIndex = 0;
                specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));               
                specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
                RelatedProductByProductid(_productId);
            }
        }
        else
        {
            if (Session["productId"] != null)
            {
                ProductSpecification(Convert.ToInt32(Session["productId"]));
                ProductSparePartsAccordion(Convert.ToInt32(Session["productId"]));
                ProductDocumentationAccordion(Convert.ToInt32(Session["productId"]));
                ProductFaqsAccordion(Convert.ToInt32(Session["productId"]));
            }

        }

        if (txtSearchPart.Value.ToString().Trim().Length > 0 || Session["SearchKeywords"] != null)
        {
            Session["SearchKeywords"] = txtSearchPart.Value.ToString().Trim();
            //  txtSearchPart.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13))  {document.getElementById('Body_btnSearchPart').click();return false;}} else {return true}; ");

            ProductDetailsMultiView.ActiveViewIndex = 0;
            ProductSpecificationByPartNo(true);
            ProductSpecificationByPartNoAcc(true);

            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        }


    }

    #region functions

    public void pageinfo(int ProductId)
    {
        try
        {
            var objPartPage = new PartsPageDa().GetPartsPagebyPPC(ProductId);
            var objMWebSection = new MWebSectionDa().GetMWebSectionbyId(Convert.ToInt32(objPartPage.WebSectionID));
            var objMWebGroup = new MWebGroupDa().GetMWebGroupbyId(Convert.ToInt32(objPartPage.WebGroupID));
            string imgSrc = "";
            string producttext = "";

            if (objPartPage != null)
            {
                if (objMWebSection != null && objMWebGroup != null)
                {
                    if (objMWebSection.WebSectionID > 0 && objMWebGroup.WebGroupID > 0)
                    {
                        Session["sectionid"] = objMWebSection.WebSectionID;
                        Session["groupid"] = objMWebGroup.WebGroupID;

                        bredCrumb =
                            "<li><i class='fa fa-home pr-10'></i><a href='../Default.aspx'>Home</a></li>" +
                            "<li><a href='ProductSpareParts.aspx?SectionId=" + objMWebSection.WebSectionID + "'>" +
                            objMWebSection.WebSection + "</a></li>" +
                            "<li><a href='ProductSpareParts.aspx?GroupId=" + objMWebGroup.WebGroupID + "'>" +
                            objMWebGroup.WebGroup + "</a></li>" +
                            "<li class='active'>" + objPartPage.PageName + "</li>";
                    }
                    else
                    {
                        bredCrumb = "<li><i class='fa fa-home pr-10'></i><a href='../Default.aspx'>Home</a></li>" +
                            "<li class='active'>" + objPartPage.PageName + "</li>";
                    }

                    productTitle.InnerHtml = objPartPage.PageName;
                }

                Breadcrumb.InnerHtml = bredCrumb;

                Page.Title = "Alpha Professional Tools® :: " + objPartPage.PageName;

                if (objPartPage.imgTool != null)
                {
                    if (File.Exists(Server.MapPath("/Files/Products/Schematics/" + objPartPage.imgTool + "")))
                    {
                        imgSrc = "/Files/Products/Schematics/" + objPartPage.imgTool + "";
                    }
                    if (imgSrc != null)
                    {
                        producttext = "<img width='400' alt='' src='" + imgSrc + "'>";
                        // producttext += "<div class='col-md-7'><div class='magnifier-preview' id='preview'><img width='400' alt='' src='" + imgSrc + "'></div></div>";
                       //  producttext = "<img class='drift-demo-trigger' data-zoom='" + imgSrc + "?w=1200&amp;ch=DPR&amp;dpr=2'  src='" + imgSrc + "?w=400&amp;ch=DPR&amp;dpr=2'  alt=''>";
                    }
                }

                spanImageLeft.InnerHtml = producttext;
                               
               

                if (objPartPage.ImgSchematic != null)
                {
                    if (File.Exists(Server.MapPath("/Files/Products/Schematics/" + objPartPage.ImgSchematic + "")))
                    {
                        imgSrc = "/Files/Products/Schematics/" + objPartPage.ImgSchematic + "";
                    }
                    if (imgSrc != null)
                    {
                        producttext = "<img height='auto' style='max-height: 400px !important;' alt='' src='" + imgSrc + "'>";
                        //   producttext += "<div class='app-figure' id='zoom-fig'><a id='Zoom-1' class='MagicZoom' href='" + imgSrc + "'><img style='width:50% !important;' alt='' src='" + imgSrc + "?scale.height=400'></a></div>";
                    }
                }

                spanImageRight.InnerHtml = producttext;

                if (imgSrc != null)
                {
                    producttext = "<img class='drift-demo-trigger' data-zoom='" + imgSrc + "?w=1200&amp;ch=DPR&amp;dpr=2'  src='" + imgSrc + "?w=600&amp;ch=DPR&amp;dpr=2'  alt=''>";


                }

                if (objPartPage.PDFSchematic != null)
                {
                    if (File.Exists(Server.MapPath("/Files/Products/Schematics/" + objPartPage.PDFSchematic + "")))
                    {
                        producttext += "<p style='color:#337AB7; font-weight:bold; text-align: center; padding-top: 20px; width:100%;'><a class='textColor' target='_blank' href='/Files/Products/Schematics/" + objPartPage.PDFSchematic + "'>Click here to view/print a PDF</a></p>";
                    }
                }

                spanImageMid.InnerHtml = producttext;

                sparepartslink.InnerHtml = "<p align='justify' style='color:#337AB7; font-weight:bold'><a style='color:#337AB7; font-weight:bold' class='textColor' href='/Pages/ProductDetails.aspx?PageCode=" + objPartPage.PPC.ToString() + "' > Back To Product Page</a> </p>";

            }
        }
        catch (Exception)
        {
            
        }
    }   

    public void ProductFaqs(int productid)
    {
        try
        {
            //string sqlfaq = "SELECT * FROM TNTechNoteFAQ tnf WHERE tnf.TNID IN(SELECT tn.TNID FROM TNTechNote tn WHERE tn.ProductPageCode=" + productid + ")";
            string sqlfaq = "SELECT tn.* FROM TNTechNoteFAQ tn WHERE tn.ProductPageCode =" + productid;
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

    public void ProductSpecification(int productid)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width:100%;float:left;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();
        
        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-responsive table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

       // string strSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw, PartsInfo P, PartsPage pp, MCAProp65 m WHERE pp.PartsPC = pw.PartsPageCode AND pw.PartNo = P.Partno AND m.CAProp65ID = P.CAProp65ID AND pp.PPC = " + productid + " order by pw.Sort asc, pw.Version asc";
        string strSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + productid + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";
        DataSet ds = this.GetData(strSQL);
        spareparts.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    tdpartsheaderCell = new TableHeaderCell { Text = "DRAWING NO." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "VERSION" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "IMAGE" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "PRICE" };
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
                            if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                            if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                            if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                {
                                    System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                    imgParts.Width = 80;
                                    imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                            if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Description"].ToString() };
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

                            if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                imgParts.Attributes.Add("runat", "server");
                                imgParts.Width = 50;
                                imgParts.ImageUrl = "/Images/Warning.png";
                                imgParts.ToolTip = dr["CAPProp65"].ToString();
                                imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                tddatacell.Controls.Add(imgParts);

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

                                System.Web.UI.HtmlControls.HtmlGenericControl addDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addDiv.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                              //  addDiv.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                tddatacell.Controls.Add(addDiv);
                                
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
                          
                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                            if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                            if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                            if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                {
                                    System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                    imgParts.Width = 80;
                                    imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                            if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Description"].ToString() };
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
                            if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                imgParts.Attributes.Add("runat", "server");
                                imgParts.Width = 50;
                                imgParts.ImageUrl = "/Images/Warning.png";
                                imgParts.ToolTip = dr["CAPProp65"].ToString();
                                imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                tddatacell.Controls.Add(imgParts);

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

                                System.Web.UI.HtmlControls.HtmlGenericControl addDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addDiv1.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                              //  addDiv1.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                tddatacell.Controls.Add(addDiv1);

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
            spareparts.Controls.Add(tblparts);
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
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "2")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "3")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "4")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "5")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "6")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }

                        if (drImage["DocType"].ToString() == "7")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
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

    public void RelatedProductByProductid(int productid)
    {
        try
        {
            string pgName = "";
            string imgSrc = "";
            var productText = new ProductTextDa().GetProductTextbyId(productid);
            var listOfProducts = productText.RelatedProduct.Split(';').ToList();
            if (listOfProducts != null)
            {
                if (listOfProducts.Count > 0)
                {
                    foreach (var product in listOfProducts)
                    {
                        int n = 0;
                        bool isnumeric = int.TryParse(product, out n);
                        if (isnumeric)
                        {
                            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(product));
                            if (objProductPage != null)
                            {
                                var objProductRelatedText =
                                    new ProductRelatedTextDa().GetProductRelatedTextbyId(
                                        Convert.ToInt32(objProductPage.ProductPageCode));
                                if (objProductRelatedText.Current == true)
                                {
                                    if (!string.IsNullOrEmpty(objProductPage.ThumbNail) && File.Exists(Server.MapPath("/Files/Products/Thumbnails/" + objProductPage.ThumbNail)))
                                    {
                                        imgSrc = "/Files/Products/Thumbnails/" + objProductPage.ThumbNail;
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
                                        objProductPage.ProductPageCode + "'>" +
                                        "</a></div>";
                                    pgName +=
                                        "<div class='listing-item-body clearfix' style='padding-top:10px;'><h3 class='title'><a href='ProductDetails.aspx?PageCode=" +
                                        objProductPage.ProductPageCode + "'>" +
                                        objProductPage.PageName +
                                        "</a></h3><p style='font-size:13.5px; color:#000'>" +
                                        objProductRelatedText.RelatedText + "</p></div></div></div>";
                                }
                            }
                        }

                       
                    }
                }
                productDiv.InnerHtml = pgName;
            }
        }
        catch (Exception e)
        {
            //
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

    #endregion functions

    #region functions for accordion   

    public void ProductSparePartsAccordion(int productid)
    {
        try
        {
            Table tblparts = new Table();
            tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width:100%;float:left;");
            TableRow trparts = new TableRow();
            TableCell tdparts = new TableCell();

            Table tblpartsSub = new Table();
            tblpartsSub.Attributes.Add("class", "table table-responsive table-striped table-bordered ");
            tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
            TableHeaderRow trpartsheaderRow = new TableHeaderRow();
            trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
            TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

           // string strSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(P.CAPProp65,'') CAPProp65  FROM PartsWebfields pw, PartsInfo P, PartsPage pp WHERE pp.PartsPC = pw.PartsPageCode AND pw.PartNo = P.Partno AND pp.PPC = " + productid + " order by pw.Sort asc, pw.Version asc";
            //string strSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw, PartsInfo P, PartsPage pp, MCAProp65 m WHERE pp.PartsPC = pw.PartsPageCode AND pw.PartNo = P.Partno AND m.CAProp65ID = P.CAProp65ID AND pp.PPC = " + productid + " order by pw.Sort asc, pw.Version asc";

            string strSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + productid + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";


            DataSet ds = this.GetData(strSQL);
         
            if (ds != null)
            {
                foreach (DataTable table in ds.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        tdpartsheaderCell = new TableHeaderCell { Text = "DRAWING NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "VERSION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "Image" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        tdpartsheaderCell.Width = 100;
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PRICE$" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "CAProp65" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "BUY NOW" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center; width:100px;");
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
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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


                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl accAddDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    accAddDiv.InnerHtml = "<div style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";

                                    tddatacell.Controls.Add(accAddDiv);

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

                                tblpartsSub.Controls.Add(trdataRow);
                            }
                            else
                            {
                                TableRow trdataRow = new TableRow();
                                TableCell tddatacell = new TableCell();
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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


                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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
                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl accAddDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    accAddDiv1.InnerHtml = "<div style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                    tddatacell.Controls.Add(accAddDiv1);

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
                specsChrtAcc.Controls.Add(tblparts);
            }
        }
        catch (Exception ex)
        {
            
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
                                producttext += "<tr><td><span class='docspan'>Safety Data Sheet : </span></td><td><a class='textColor' href='/Files/Docs/SDS/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "2")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Manual : </span></td><td><a class='textColor' href='/Files/Docs/Manuals/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "3")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Reference : </span></td><td><a class='textColor' href='/Files/Docs/Reference/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "4")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Maint Card : </span></td><td><a class='textColor' href='/Files/Docs/MaintenanceCards/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "5")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Parts-Schematic : </span></td><td><a class='textColor' href='/Files/Docs/Schematics/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }
                        if (drImage["DocType"].ToString() == "6")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Flyer : </span></td><td><a class='textColor' href='/Files/Docs/Flyers/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
                            }
                        }

                        if (drImage["DocType"].ToString() == "7")
                        {
                            if (!string.IsNullOrEmpty(drImage["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString())))
                            {
                                producttext += "<tr><td><span class='docspan'>Other : </span></td><td><a class='textColor' href='/Files/Docs/Other/PDFs/" + drImage["Filename"].ToString() + "' target='_blank'>" + drImage["Filename"].ToString() + "</a></td></tr>";
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


        }

        catch (Exception)
        {
            //throw;
        }
    }

    

    public void ProductFaqsAccordion(int productid)
    {
        try
        {
            //string sqlfaq = "SELECT * FROM TNTechNoteFAQ tnf WHERE tnf.TNID IN(SELECT tn.TNID FROM TNTechNote tn WHERE tn.ProductPageCode=" + productid + ")";
            string sqlfaq = "SELECT tn.* FROM TNTechNoteFAQ tn WHERE tn.ProductPageCode =" + productid;
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


    public void ProductSpecificationByPartNo(bool isPart)
    {
        Session["CurrentGroup"] = null;

        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width:100%;float:left;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-responsive table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

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

            try
            {
                _productId = (Request.QueryString["PageCode"] != null && Utility.IsNumeric(Request.QueryString["PageCode"])) ? Convert.ToInt32(Request.QueryString["PageCode"]) : 0;
            }
            catch (Exception)
            {
                _productId = 0;
            }

            if (isPart)
            {
                sStr = txtSearchPart.Value.ToString().Trim();

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
                    }
                }

                sSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno and pw.PartNo LIKE '%" + sFullPhrase.Trim() + "%' INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + _productId + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";

            }
            else
            {
                sSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + _productId + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";

            }

            DataSet ds = this.GetData(sSQL);
            spareparts.Controls.Clear();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable table in ds.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        tdpartsheaderCell = new TableHeaderCell { Text = "DRAWING NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "VERSION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "IMAGE" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PRICE" };
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
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl addDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    addDiv.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                    //  addDiv.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                    tddatacell.Controls.Add(addDiv);

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

                                tblpartsSub.Controls.Add(trdataRow);
                            }
                            else
                            {
                                TableRow trdataRow = new TableRow();
                                TableCell tddatacell = new TableCell();
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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
                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl addDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    addDiv1.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                    //  addDiv1.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                    tddatacell.Controls.Add(addDiv1);

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

                spareparts.Controls.Add(tblparts);

            }
            else
            {
                tdparts.Controls.Add(tblpartsSub);
                trparts.Controls.Add(tdparts);
                tblparts.Controls.Add(trparts);

                spareparts.Controls.Add(tblparts);

                Session["SearchResult"] = "Currently there is no Part available for the search. Please try again later.";
            }


        }
        catch (Exception ex)
        {
            //
        }
    }

    public void ProductSpecificationByPartNoAcc(bool isPart)
    {
        Session["CurrentGroup"] = null;

        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width:100%;float:left;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-responsive table-striped table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();

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

            try
            {
                _productId = (Request.QueryString["PageCode"] != null && Utility.IsNumeric(Request.QueryString["PageCode"])) ? Convert.ToInt32(Request.QueryString["PageCode"]) : 0;
            }
            catch (Exception)
            {
                _productId = 0;
            }

            if (isPart)
            {
                sStr = txtSearchPart.Value.ToString().Trim();

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
                    }
                }

                sSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno and pw.PartNo LIKE '%" + sFullPhrase.Trim() + "%' INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + _productId + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";

            }
            else
            {
                sSQL = "SELECT pp.*, pw.PartsPageCode, pw.DrawingNo DrawingNo, pw.PartNo, pw.Version, pw.Sort, P.[Description], P.[Image] PartsThumb, isnull(P.MSRP,0) MSRP, isnull(pw.QProductID, 0) QProductID, isnull(m.CAProp65Text,'') CAPProp65 FROM PartsWebfields pw INNER join PartsInfo P ON pw.PartNo = P.Partno INNER JOIN (SELECT * FROM  PartsPage WHERE PPC = " + _productId + ") pp ON pp.PartsPC = pw.PartsPageCode  left join MCAProp65 m on  m.CAProp65ID = P.CAProp65ID  order by pw.Sort asc, pw.Version ASC ";

            }

            DataSet ds = this.GetData(sSQL);
            specsChrtAcc.Controls.Clear();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable table in ds.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        tdpartsheaderCell = new TableHeaderCell { Text = "DRAWING NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "VERSION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "Image" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        tdpartsheaderCell.Width = 100;
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "PRICE$" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "CAProp65" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                        trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                        tdpartsheaderCell = new TableHeaderCell { Text = "BUY NOW" };
                        tdpartsheaderCell.Attributes.Add("style", "text-align:center; width:100px;");
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
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl addDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    addDiv.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                    //  addDiv.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                    tddatacell.Controls.Add(addDiv);

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

                                tblpartsSub.Controls.Add(trdataRow);
                            }
                            else
                            {
                                TableRow trdataRow = new TableRow();
                                TableCell tddatacell = new TableCell();
                                if (!string.IsNullOrEmpty(dr["DrawingNo"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["DrawingNo"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["Version"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Version"].ToString() };
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

                                if (!string.IsNullOrEmpty(dr["PartsThumb"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    if (File.Exists(Server.MapPath("/Files/Products/Parts/" + dr["PartsThumb"].ToString())))
                                    {
                                        System.Web.UI.WebControls.Image imgParts = new System.Web.UI.WebControls.Image();
                                        imgParts.Width = 80;
                                        imgParts.ImageUrl = "/Files/Products/Parts/" + dr["PartsThumb"].ToString();
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

                                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = dr["Description"].ToString() };
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
                                if (!string.IsNullOrEmpty(dr["CAPProp65"].ToString()))
                                {
                                    tddatacell = new TableCell { Text = "" };
                                    tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                    System.Web.UI.WebControls.ImageButton imgParts = new System.Web.UI.WebControls.ImageButton();
                                    imgParts.Attributes.Add("runat", "server");
                                    imgParts.Width = 50;
                                    imgParts.ImageUrl = "/Images/Warning.png";
                                    imgParts.ToolTip = dr["CAPProp65"].ToString();
                                    imgParts.OnClientClick = "javascript:showtext('" + dr["CAPProp65"].ToString() + "')";
                                    tddatacell.Controls.Add(imgParts);

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

                                    System.Web.UI.HtmlControls.HtmlGenericControl addDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                    addDiv1.InnerHtml = "<div  style = 'width:220px;' data-widget=" + dr["QProductID"].ToString() + "></div>";
                                    //  addDiv1.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                    tddatacell.Controls.Add(addDiv1);

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

                specsChrtAcc.Controls.Add(tblparts);

            }
            else
            {
                tdparts.Controls.Add(tblpartsSub);
                trparts.Controls.Add(tdparts);
                tblparts.Controls.Add(trparts);

                specsChrtAcc.Controls.Add(tblparts);

                Session["SearchResult"] = "Currently there is no Part available for the search. Please try again later.";
            }


        }
        catch (Exception ex)
        {
            //
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
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {
            
        }
    }

    protected void documentBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 1;
            if (Session["productId"] != null)
            {
                ProductDocumentation(Convert.ToInt32(Session["productId"]));
            }
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            documentBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
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
            ProductDetailsMultiView.ActiveViewIndex = 2;
            if (Session["productId"] != null)
            {
                ProductFaqs(Convert.ToInt32(Session["productId"]));
            }
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            faqBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            specsBtn.ForeColor = ColorTranslator.FromHtml("#fff");

        }
        catch (Exception)
        {
           
        }
    }

    protected void btnSearchPart_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 0;
            ProductSpecificationByPartNo(true);
            ProductSpecificationByPartNoAcc(true);

            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {

        }

       
    }

    protected void btnSearchPartClear_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            ProductDetailsMultiView.ActiveViewIndex = 0;
            txtSearchPart.Value = "";
            ProductSpecificationByPartNo(false);
            ProductSpecificationByPartNoAcc(false);

            specsLi.Attributes.Add("class", specsLi.Attributes["class"].Replace("tabclass", "selectedcss"));
            documentLi.Attributes.Add("class", documentLi.Attributes["class"].Replace("selectedcss", "tabclass"));
            faqLi.Attributes.Add("class", faqLi.Attributes["class"].Replace("selectedcss", "tabclass"));

            specsBtn.ForeColor = ColorTranslator.FromHtml("#666666");
            documentBtn.ForeColor = ColorTranslator.FromHtml("#fff");
            faqBtn.ForeColor = ColorTranslator.FromHtml("#fff");
        }
        catch (Exception)
        {

        }


    }

    #endregion

}

