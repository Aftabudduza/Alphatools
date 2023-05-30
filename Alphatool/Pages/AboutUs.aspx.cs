using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;

public partial class pages_AboutUs : Page
{
    string PageTitle = "";
    string PageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        if (!IsPostBack)
        {
            //loadContent("about");
            //loadSEOContent("about");
        }
    }

    //private void loadContent(string sPageRef)
    //{
    //    try
    //    {
    //        string html = "";
    //        CMSPageRef objCmsPageRef = new CMSPageRef();
    //        objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive(sPageRef, "Y");
    //        if (objCmsPageRef != null)
    //        {
    //            html += objCmsPageRef.CMSContent;
    //            PageH3.InnerHtml = objCmsPageRef.CMSTitle;
    //            CMSContent.InnerHtml = html;
    //            Breadcrumb.InnerHtml = "<li><i class='fa fa-home pr-10'></i><a href='/Default.aspx'>Home</a></li><li class='active'>" + objCmsPageRef.CMSTitle + "</li>";
    //        }                     
    //    }
    //    catch (Exception ex)
    //    {
            
    //    }
    //}

    //private void loadSEOContent(string sPageRef)
    //{
    //    try
    //    {
    //        CMSPageRef objCmsPageRef = new CMSPageRef();
    //        objCmsPageRef = new CmsPageRefDa().GetCmsPageRefbyPageNameIslive(sPageRef, "Y");
    //        if (objCmsPageRef != null)
    //        {

    //            HtmlMeta hm = new HtmlMeta();
    //            hm.Name = "keywords";
    //            hm.Content = objCmsPageRef.MetaKeywords != null ? objCmsPageRef.MetaKeywords.ToString() : "";
    //            this.metaTags.Controls.Add(hm);

    //            HtmlMeta hm2 = new HtmlMeta();
    //            hm2.Name = "description";
    //            hm2.Content = objCmsPageRef.MetaDescription != null ? objCmsPageRef.MetaDescription.ToString() : "";
    //            this.metaTags.Controls.Add(hm2);
    //            Page.Title = objCmsPageRef.MetaTitle != null ? objCmsPageRef.MetaTitle.ToString() : "";
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
}
