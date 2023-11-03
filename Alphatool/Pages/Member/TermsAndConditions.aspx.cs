using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

public partial class pages_TermsAndConditions : Page
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
            objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive("TermsAndConditions", "Y");
            if (objCmsPageRef != null)
            {
               // Breadcrumb.InnerHtml = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>"+objCmsPageRef.CMSTitle+"</li>";
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
