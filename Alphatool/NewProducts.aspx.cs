using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;

public partial class pages_NewProducts : Page
{
    private int _productId = 0;
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ProductListByNewProducts();
        }
    }

    #region functions

    //public void ProductListByNewProducts()
    //{
    //    try
    //    {
    //        List<NewProducts> objNewProducts = new List<NewProducts>();
    //        objNewProducts = new NewProductsDa().GetAllNewProducts();
    //        objNewProducts = objNewProducts.OrderByDescending(x => x.DatePosted).ToList();
    //        string newproductHtml = "";
    //        string imgSrc = "";
    //        string pdfSrc = "";

    //        if (objNewProducts != null)
    //        {
    //            if (objNewProducts.Count > 0)
    //            {
    //                newproductHtml += "<table>";
    //                foreach (var newprod in objNewProducts)
    //                {
    //                    if (newprod.CurrentYN == true)
    //                    {
    //                        if (newprod.NewProductPhoto != null)
    //                        {
    //                            imgSrc = "/Files/NewProducts/Photos/" + newprod.NewProductPhoto;
    //                        }
    //                        else
    //                        {
    //                            imgSrc = "/Files/NewProducts/Photos/not_found_image.jpg";
    //                        }

    //                        if (newprod.NewProductPDF != null)
    //                        {
    //                            pdfSrc = "<a target='_blank' href='/Files/NewProducts/PDFs/" + newprod.NewProductPDF + "'>Download PDF >></a>";
    //                        }
    //                        else
    //                        {
    //                            pdfSrc = "";
    //                        }

    //                        newproductHtml += "<tr style='border-bottom:1px solid #000; padding:10px;'>" +
    //                                   "<td style='padding:15px;'><div><img src='" + imgSrc +
    //                                   "' /></div></td>" +
    //                                   "<td style='padding:15px;'><div><p><a style='color:blue !important;' href='ProductDetails.aspx?PageCode=" + newprod.ProductPageCode + "'>" + newprod.NewProductTitle + "</a></p><p>" +
    //                                   newprod.NewProductDescription + "</p><p>" + newprod.NewProductSummary +
    //                                   "</p><p style='font-weight:bold;'>" + pdfSrc + " </p></div></td>" +
    //                                   "</tr>";
    //                    }
    //                }
    //                newproductHtml += "</table>";
    //            }
    //        }

    //        newProductDiv.InnerHtml = newproductHtml;

    //    }
    //    catch (Exception ex)
    //    {
            
    //    }

    //}

    public string GetPDF(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='/Files/NewProducts/PDFs/" + sFileName + "'>Download PDF >></a>";
            }
            else
            {
                s = "";
            }
        }
        catch (Exception)
        {
           
        }

        return s;
    }

    public string GetImageFileName(string sImageFileName)
    {
        string s = "";

        try
        {
            if (sImageFileName != null && sImageFileName.Trim().Length > 0)
            {
                if (File.Exists(Server.MapPath("/Files/NewProducts/Photos/" + sImageFileName)))
                {
                    s = "/Files/NewProducts/Photos/" + sImageFileName;
                }
                else
                {
                    s = "/Images/not_found_image.jpg";
                }
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return s;
    }
    public string GetProduct(string sCode)
    {
        string s = "";

        try
        {
            if (sCode != null && sCode.Trim().Length > 0)
            {
                s =  "ProductDetails.aspx?PageCode=" + sCode;
            }
            else
            {
                s = "";
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return s;
    }
    public void ProductListByNewProducts()
    {
        try
        {
            List<NewProducts> objNewProducts = new List<NewProducts>();

            objNewProducts = new NewProductsDa().GetAllNewProducts();
            objNewProducts = objNewProducts.Where(x => x.CurrentYN == true).ToList();
            objNewProducts = objNewProducts.OrderByDescending(x => x.DatePosted).ToList();

            if (objNewProducts != null)
            {
                if (objNewProducts.Count > 0)
                {
                    InventoryItems.DataSource = objNewProducts;
                    InventoryItems.DataBind();
                }
                else
                {
                    InventoryItems.DataSource = null;
                    InventoryItems.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }

    }
    #endregion functions

    #region events

    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try
        {
            (InventoryItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.ProductListByNewProducts();
        }
        catch (Exception ex)
        { }
    }

    #endregion
}

