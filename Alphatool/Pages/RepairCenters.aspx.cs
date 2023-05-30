using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;

public partial class pages_RepairCenters : Page
{
    string PageTitle = "";
    string PageName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        if (!IsPostBack)
        {}
    }
}
