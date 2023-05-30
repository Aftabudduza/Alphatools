using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;

public partial class pages_Quivers : Page
{
    string PageTitle = "";
    string PageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        if (!IsPostBack)
        {
           loadSEOContent();
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

    private void loadSEOContent()
    {
        try
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "keywords";
            hm.Content = "buffing tools, buffing pads, drilling tools, cutting blades, cutting tools, cutting systems, cutting wheel, diamond tools, diamond saw blades, diamond polishing pads, grinding wheel, grinding tools industrial abrasives, pneumatic air tools, polishers, polishing pads, polishing tools, polishing wheels, polishing discs, profiling tools, profiling wheels, router bits, scratch removal, stain removers, stone cutter, stone polishing, core bits, flush cutting blades, groove cutting blades, dry cutting blades, wet cutting blades, diamond cutting blades, marble cutting tools, diamond cutting tools, edge polishers, tile profiling wheels, diamond profiling wheels, rust stain removers, stone stain removers, stone polishing machinery, stone polishing tools, wet concrete core bits, dry core bits";
            this.metaTags.Controls.Add(hm);

            HtmlMeta hm2 = new HtmlMeta();
            hm2.Name = "description";
            hm2.Content = "Contact Alpha Professional Tools® headquarters, factory service center or sales contacts with any questions or comments regarding the cutting, drilling, grinding, polishing & profiling tools offered.";
            this.metaTags.Controls.Add(hm2);
            Page.Title = "Quivers and Alpha";
        }
        catch (Exception ex)
        {

        }
    }
}
