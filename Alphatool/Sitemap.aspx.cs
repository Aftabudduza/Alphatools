using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Sitemap : System.Web.UI.Page
{
    private List<ProductPage> objProductPage = new List<ProductPage>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        if (!IsPostBack)
        {
            GetAllSectionsGroups();
        }
    }
    public void GetAllSectionsGroups()
    {
        try
        {
            List<MWebSection> objMWebSections = new List<MWebSection>();
            string ulText = "";
            //string sql = "SELECT * FROM MWebSection ms WHERE ms.WebSectionID < 80  order by WebSectionID asc";
           // objMWebSections = new MWebSectionDa().GetAllMWebSectionBySQL(sql);
            objMWebSections = new MWebSectionDa().GetAllMWebSection();
            objMWebSections = objMWebSections.Where(x => x.WebSectionID < 80).ToList();
            objMWebSections = objMWebSections.OrderBy(x=>x.WebSectionID).ToList();

            if (objMWebSections != null && objMWebSections.Count > 0)
            {
                foreach (MWebSection section in objMWebSections)
                {
                    if (section.WebSection.Trim().ToUpper() == "PENDING")
                    {
                        ulText += "<li><ul><li><a href='ProductPages.aspx?GroupId=8400'>Pending Items</a></li></ul></li>";
                    }
                    else
                    {
                        ulText += "<li><a href='ProductPages.aspx?SectionId=" + section.WebSectionID.ToString() + "'>" + section.WebSection + "</a><ul>";
                        if (section.WebOverview != null)
                        {
                            ulText += "<li><a href='../Files/Overviews/" + section.WebOverview.ToString() + "l' target='_blank'>Overview</a></li>";

                        }

                        objProductPage = new ProductPageDa().GetAllProductPageBySectionId(Convert.ToInt32(section.WebSectionID));
                        objProductPage = objProductPage.GroupBy(x => x.WebGroupID, (key, x) => x.FirstOrDefault()).ToList();
                        objProductPage = objProductPage.OrderBy(x => x.WebGroupID).ToList();
                        if (objProductPage != null)
                        {
                            if (objProductPage.Count > 0)
                            {
                                foreach (var group in objProductPage)
                                {
                                    MWebGroup objMWebGroup = new MWebGroupDa().GetMWebGroupbyId(Convert.ToInt32(group.WebGroupID));
                                    if (objMWebGroup != null && objMWebGroup.WebGroup != null)
                                    {
                                        ulText += "<li><a href='ProductPages.aspx?GroupId=" + objMWebGroup.WebGroupID.ToString() + "'>" + objMWebGroup.WebGroup + "</a></li>";
                                    }
                                }
                            }
                        }            

                        ulText += "</ul></li>";
                    }
                }
            }

            ulCategory.InnerHtml = ulText.ToString();
          
        }
        catch (Exception ex)
        {
            
        }

    }
}