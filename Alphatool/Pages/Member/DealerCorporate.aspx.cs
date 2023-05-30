using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

public partial class pages_DealerCorporate : Page
{
    string PageTitle = "";
    string PageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadContent();
        }
    }

    private void loadContent()
    {
        try
        {
            string html = "";
            CMSPageRef objCmsPageRef = new CMSPageRef();
            objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive("DealerCorporate", "Y");
            if (objCmsPageRef != null)
            {
                html += objCmsPageRef.CMSContent;
                PageH3.InnerHtml = objCmsPageRef.CMSTitle;
            }

            CMSContent.InnerHtml = html;
            
        }
        catch (Exception ex)
        {
            
        }
    }
}
