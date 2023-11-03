using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mockup : System.Web.UI.Page
{   
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
            Page.Title = "Alpha Professional Tools";
            LoadBanners();         
        }
    }
    
    public void LoadBanners()
    {

        try
        {
            string sLink = "";
            string sImage = "";
            string sTitle = "";
            string sBannerHTML = "";
            DataTable dtHomeBanner = new DataTable();
            dtHomeBanner = WebUtility.GetRows("SELECT HomeBannerNo, HBName, HBImage, HBLink, CurrentYN  FROM HomeBanners WHERE CurrentYN = 1 ORDER BY Sort ASC ");
            if (dtHomeBanner != null && dtHomeBanner.Rows.Count > 0)
            {
                foreach (DataRow dr in dtHomeBanner.Rows)
                {
                    try
                    {
                        if (dr["HBName"] != null && dr["HBName"].ToString() != "")
                        {
                            sTitle = dr["HBName"].ToString();
                        }
                        if (dr["HBLink"] != null && dr["HBLink"].ToString() != "")
                        {
                            sLink = dr["HBLink"].ToString();
                        }
                        if (dr["HBImage"] != null && dr["HBImage"].ToString() != "")
                        {
                            if (dr["HBImage"] != null)
                            {
                                sImage = "/Images/Banners-Home/" + dr["HBImage"].ToString();
                            }
                            else
                            {
                                sImage = "/Images/not_found_image.jpg";
                            }
                        }

                        sBannerHTML += "<div data-p='225.00' ><a style='font-weight:bold;' title='" + sTitle.Trim() + "' href='" +
                                       sLink.Trim() + "'> <img src='" + sImage.Trim() + "'></a></div>";
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            BannerHome.InnerHtml = sBannerHTML.Trim();

        }
        catch (Exception ex)
        {

        }


    }
    
   
}