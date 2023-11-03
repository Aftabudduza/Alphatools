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

public partial class pages_IndustrialProducts : Page
{
    private int _productId = 0;
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ProductListByIndustrialProducts();
        }
    }

    #region functions

    

  

    public string GetImageFileName(string sImageFileName)
    {
        string s = "";

        try
        {
            if (sImageFileName != null && sImageFileName.Trim().Length > 0)
            {
                s = "/Files/MetalProducts/Photos/" + sImageFileName;
            }
            else
            {
                s = "/Images/not_found_image.jpg";
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
    public void ProductListByIndustrialProducts()
    {
        try
        {
            List<MetalProducts> objMetalProducts = new List<MetalProducts>();

            objMetalProducts = new MetalProductsDa().GetAllMetalProducts();
            objMetalProducts = objMetalProducts.Where(x => x.CurrentYN == true).ToList();
            objMetalProducts = objMetalProducts.OrderByDescending(x => x.DatePosted).ToList();

            if (objMetalProducts != null)
            {
                if (objMetalProducts.Count > 0)
                {
                    InventoryItems.DataSource = objMetalProducts;
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
            this.ProductListByIndustrialProducts();
        }
        catch (Exception ex)
        { }
    }

    #endregion
}

