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

public partial class pages_Calender : Page
{
    private int _productId = 0;
    private string _btnText = "";
    private int i = 0;
    private string bredCrumb = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        Session["EventDate"] = null;
        EventCalenderListByEvents();
    }

    #region functions

    public string GetPDF(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='/Files/Calendar/PDFs/" + sFileName + "'>View PDF >></a>";
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

    public string GetEventLink(string sFileName)
    {
        string s = "";

        try
        {
            if (sFileName != null && sFileName.Trim().Length > 0)
            {
                s = "<a target='_blank' href='" + sFileName + "'>View Link >></a>";
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

    public string GetURL(string sURL, string sFileName)
    {
        string s = "";

        try
        {
            if (sURL != null && sURL.Trim().Length > 0)
            {               
                if (sFileName != null && sFileName.Trim().Length > 0)
                {
                    s = "<a target='_blank' href='" + sURL + "'><img alt='' src='" + GetImageFileName(sFileName).ToString() + "' /></a>";
                }   
            }
            else
            {
                 if (sFileName != null && sFileName.Trim().Length > 0)
                 {
                      s = "<img alt='' src='"+ GetImageFileName(sFileName).ToString() + "' />";
                 }        
               
            }
        }
        catch (Exception)
        {
            //
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
                if (File.Exists(Server.MapPath("/Files/Calendar/Logos/" + sImageFileName)))
                {
                    s = "/Files/Calendar/Logos/" + sImageFileName;
                }
                else
                {
                    s = "/Images/not_found_image.jpg";
                }
                //s = "/Files/Calendar/Logos/" + sImageFileName;
            }
            
        }
        catch (Exception)
        {
            // ignored
        }

        return s;
    }

    public string GetEvent(string sCode)
    {
        string s = "";

        try
        {
            if (sCode != null && sCode.Trim().Length > 0)
            {
                //s =  "ProductDetails.aspx?PageCode=" + sCode;
            }
            else
            {
                //s = "";
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return s;
    }

    private DataSet GetData()
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM EventCalendar ec  WHERE ec.CurrentYN=1 ORDER BY ec.DateListed ASC"))
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

    public void EventCalenderListByEvents()
    {
        try
        {
            List<dynamic> objEventCalendars = new List<dynamic>();
            DataSet ds = this.GetData();
            if (ds != null)
            {   
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        
                        objEventCalendars.Add(new {
                            DateListed = dr["DateListed"],
                            EventTitle = dr["EventTitle"],
                            EventLogo = dr["EventLogo"],
                            EventBlurb = dr["EventBlurb"],
                            EventLink = dr["EventLink"],
                            EventDetailPDF = dr["EventDetailPDF"]
                        });
                    }
                }
                InventoryItems.DataSource = objEventCalendars;
                InventoryItems.DataBind();
            }
        }
        catch (Exception ex)
        {
            //
        }
    }
    
    #endregion functions

    #region events

    //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    try
    //    {
    //        (InventoryItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows,
    //            false);
    //        this.EventCalenderListByEvents();
    //    }
    //    catch (Exception ex)
    //    {
    //        //
    //    }
    //}

    #endregion
}

