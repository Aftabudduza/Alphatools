using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;

public partial class pages_ToolRepair : Page
{
    string PageTitle = "";
    string PageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["categoryid"] = null;
            loadSEOContent();
        }
    }

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
            hm2.Content = "Tool Repair Technical Page. This page is intended for professional repair shops to learn the proper techniques for repairing Alpha® tools. Included here are how-to videos, step-by-step documentation and links for necessary tools.";
            this.metaTags.Controls.Add(hm2);
        }
        catch (Exception ex)
        {

        }
    }
}
