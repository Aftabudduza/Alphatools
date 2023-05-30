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

public partial class pages_Affiliations : Page
{
    private int _productId = 0; 
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Affiliations();
        }
    }

    #region functions

    public string GetLink(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='" + sFileName + "'>" + sFileName + "</a>";
            }
            else
            {
                s = "";
            }
        }
        catch (Exception)
        {
            //
        }

        return s;
    }

    public string GetPDF(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='/Files/Affiliations/PDFs/" + sFileName + "'>Download PDF >></a>";
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
                s = "/Files/Affiliations/Logos/" + sImageFileName;
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

    public void Affiliations()
    {
        try
        {
            List<Affiliations> objAffiliations = new List<Affiliations>();

            objAffiliations = new AffiliationsDa().GetAllAffiliations();
            objAffiliations = objAffiliations.Where(x => x.CurrentYN == true).ToList();
            objAffiliations = objAffiliations.OrderBy(x => x.AffiliateName).ToList();

            if (objAffiliations != null)
            {
                if (objAffiliations.Count > 0)
                {
                    InventoryItems.DataSource = objAffiliations;
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

    //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    try
    //    {
    //        (InventoryItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //        this.Associations();
    //    }
    //    catch (Exception ex)
    //    { }
    //}
    //protected void OnPagePropertiesChangingNew(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    try
    //    {
    //        (lvIndustry.FindControl("DataPager2") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //        this.IndustryAffiliations();
    //    }
    //    catch (Exception ex)
    //    { }
    //}
    #endregion
}

