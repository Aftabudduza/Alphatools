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

public partial class pages_WhatsNew : Page
{
    private int _productId = 0;
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        if (!Page.IsPostBack)
        {
            GetWhatIsNew();
        }
    }

    #region functions
    

    public string GetPDF(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='/Files/Docs/Flyers/PDFs/" + sFileName + "'>More >></a>";
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
    public void GetWhatIsNew()
    {
        try
        {
            List<WhatIsNew> objWhatIsNew = new List<WhatIsNew>();

            objWhatIsNew = new WhatIsNewDa().GetAllWhatIsNew();
            objWhatIsNew = objWhatIsNew.Where(x => x.CurrentYN == true).ToList();
            objWhatIsNew = objWhatIsNew.OrderByDescending(x => x.DatePosted).ToList();

            if (objWhatIsNew != null)
            {
                if (objWhatIsNew.Count > 0)
                {
                    InventoryItems.DataSource = objWhatIsNew;
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
            this.GetWhatIsNew();
        }
        catch (Exception ex)
        { }
    }

    #endregion
}

