using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.DA;
using AlphatoolServices.Utility;

public partial class Pages_Videos : System.Web.UI.Page
{
    private int _productId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        _productId = (Request.QueryString["PageCode"] != null && Utility.IsNumeric(Request.QueryString["PageCode"])) ? Convert.ToInt32(Request.QueryString["PageCode"]) : 0;
        if (_productId > 0)
        {
            ProductVideos(_productId);
        }
    }
    public void ProductVideos(int productid)
    {
        try
        {
            //ClientScriptManager cs = Page.ClientScript;
            //cs.RegisterStartupScript(typeof(Page), "ReApplyJavascript", "<script type=text/JavaScript>id();</script>", false);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReApplyJavascript", "<script type=text/JavaScript>load();</script>", false);
            string videolist = "";
            var objProductPage = new ProductPageDa().GetProductPagebyId(Convert.ToInt32(productid));
            if (objProductPage != null)
            {
                productBanner.InnerHtml = objProductPage.PageName;
                var productVedios = new ProductVideoDa().GetAllProductVideoByProductId(Convert.ToInt32(objProductPage.ProductPageCode));
                if (productVedios != null)
                {
                    if (productVedios.Count > 0)
                    {
                        foreach (var vlist in productVedios)
                        {
                            var objVideo = new VideoDa().GetVideobyId(Convert.ToInt32(vlist.VideoID));
                            videolist += "<li><a class='youtube-media' href='" + objVideo.VideoLink + "'>" + objVideo.VideoName + "</a></li>";

                        }
                        videoList.InnerHtml = videolist;
                    }
                    else
                    {
                        videoList.InnerHtml = "<p align='justify' style='color:blue; font-weight:bold'> Videos will added soon.... </p>";
                    }
                }

                //youtube-media
                Session["productId"] = objProductPage.ProductPageCode;
                //documentation.InnerHtml = producttext;
            }
        }
        catch (Exception)
        {
            //throw;
        }
    }
}