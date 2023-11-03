using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace UserControls
{
    public partial class CatetoryMenu : System.Web.UI.UserControl
    {
        private readonly String _strWebUrl = System.Configuration.ConfigurationManager.AppSettings.Get("WebUrl");
        private int _CatagoryId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _CatagoryId = (Request.QueryString["CategoryId"] != null && Utility.IsNumeric(Request.QueryString["CategoryId"])) ? Convert.ToInt32(Request.QueryString["CategoryId"]) : 0;

            if (!IsPostBack)
            {
                loadHeaderMenu();

            }
        }
        private void loadHeaderMenu()
        {
            string html = "";
            List<MPPCIndustry> categoryMenu = new MppcIndustryDa().GetAllMPPCIndustry();
            if (categoryMenu != null)
            {
                foreach (var menu in categoryMenu)
                {
                    if (menu.PPCIndustry != 1)
                    {
                        if (_CatagoryId == menu.PPCIndustry)
                        {
                            html += "<li><a style='font-weight:bold; color: #337ab7;' title='" + menu.PPCIndustryName + "' href='" + _strWebUrl + "../Pages/ProductPages.aspx?CategoryId=" + menu.PPCIndustry + "'>" +
                                    menu.PPCIndustryName + "</a></li>";
                        }
                        else
                        {
                            html += "<li><a style='font-weight:bold;' title='" + menu.PPCIndustryName + "' href='" + _strWebUrl + "../Pages/ProductPages.aspx?CategoryId=" + menu.PPCIndustry + "'>" +
                                  menu.PPCIndustryName + "</a></li>";
                        }
                    }
                }
                CategoryMenu.InnerHtml = html;
            }
        }
    }
}
