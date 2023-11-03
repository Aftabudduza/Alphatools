using System;
using System.Configuration;
using System.Web;

//using PdfSharp.Pdf.Content.Objects;

/// <summary>
/// Summary description for appGlobal
/// </summary>
public class AppGlobal
{
    public string WebsiteId = "29";

    public static string Connectionstring
    {
        get
        {
            try
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings["SQLDB"].ConnectionString);
            }
            catch (Exception)
            {
                // ignored
            }
            return "";
        }
    }
    public static void processUrl(HttpContext context)
    {
        string path = context.Request.Path;       
        string nbase = "~";
        string stemp = "";
        string[] aArray = null;


        if (path.Contains("http://www.alpha-tools.com/"))
        {
            path = path.Replace("http://www.alpha-tools.com/", "http://www.alpha-tools.com/");
        }

        try
        {
            string old_path = HttpContext.Current.Request.Url.ToString().ToLower();
            if (old_path.Contains("http://www.alpha-tools.com/"))
            {
                old_path = old_path.Replace("http://www.alpha-tools.com/", "http://www.alpha-tools.com/");
            }

            if (old_path.Contains("section.aspx"))
            {
                stemp = "";
                aArray = null;
                aArray = old_path.Split('=');
                if ((aArray != null) & aArray.Length > 1)
                {
                    if ((aArray[1] != null))
                    {
                        stemp = aArray[1].ToString().Trim();
                        if (stemp.Length > 0)
                        {
                            string surl = "http://www.alpha-tools.com/pages/productpages.aspx?sectionid=" + stemp;
                            context.Response.Status = "301 Moved Permanently";
                            context.Response.AddHeader("Location", surl);
                            context.Response.End();
                        }
                    }
                }
            }
            else if (old_path.Contains("group.aspx"))
            {
                stemp = "";
                aArray = null;
                aArray = old_path.Split('=');
                if ((aArray != null) & aArray.Length > 1)
                {
                    if ((aArray[1] != null))
                    {
                        stemp = aArray[1].ToString().Trim();
                        if (stemp.Length > 0)
                        {
                            string surl = "http://www.alpha-tools.com/pages/productpages.aspx?GroupId=" + stemp;
                            context.Response.Status = "301 Moved Permanently";
                            context.Response.AddHeader("Location", surl);
                            context.Response.End();
                        }
                    }
                }
            }
            else if (old_path.Contains("product.aspx"))
            {
                stemp = "";
                aArray = null;
                aArray = old_path.Split('=');
                if ((aArray != null) & aArray.Length > 1)
                {
                    if ((aArray[1] != null))
                    {
                        stemp = aArray[1].ToString().Trim();
                        if (stemp.Length > 0)
                        {
                            string surl = "http://www.alpha-tools.com/pages/productdetails.aspx?pagecode=" + stemp;
                            context.Response.Status = "301 Moved Permanently";
                            context.Response.AddHeader("Location", surl);
                            context.Response.End();
                        }
                    }
                }
            }

            else if (old_path.Contains("index.aspx"))
            {
                old_path = "http://www.alpha-tools.com/default.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }

            else if (old_path.Contains("technicallibrary.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/Library.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
            else if (old_path.Contains("requestdealerinfo.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/RequestADealerInfo.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
            else if (old_path.Contains("links.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/LinksAndAffiliations.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
            else if (old_path.Contains("about.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/AboutUs.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
            else if (old_path.Contains("contact.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/ContactUs.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
           
            else if (old_path.Contains("Metals.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/IndustrialProducts.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
           
            else if (old_path.Contains("MCalc.aspx"))
            {
                old_path = "http://www.alpha-tools.com/Pages/MoistureCalculator.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }

            else if (old_path.Contains("admin/Login.aspx"))
            {
                old_path = "http://www.alpha-tools.com/pages/account/Login.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }
            else if (old_path.Contains("Members/Default.aspx"))
            {
                old_path = "http://www.alpha-tools.com/admin/Files/Members/Default.aspx";
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", old_path);
                context.Response.End();
            }

            if (path.Length > 0)
            {
                context.RewritePath(path, false);
            }
            else
            {
                context.RewritePath(old_path, false);
            }

        }
        catch (Exception ex)
        {
        }

    }
    
}