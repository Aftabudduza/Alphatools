using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.DA;

public partial class Pages_Sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["categoryid"] = null;
        Session["currentMsdslink"] = null;
        Session["currentManuallink"] = null;
        Session["currentMainTenCardlink"] = null;
        Session["currentOtherRefflink"] = null;
        Session["currentFlyerlink"] = null;
        Session["currentPartsList"] = null;
        Session["currentOtherlink"] = null;
        MsdsProducts();
        ManualsProducts();
        MainTenCardProducts();
        ReferenceProducts();
        FlyerProducts();
        PartsListProducts();
        OtherProducts();
    }

    public void MsdsProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(1);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";

                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentMsdslink"] = null;
                                    i = 0;
                                    DataView Productview = new DataView(dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() + "' and WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentMsdslink"]) != drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) && File.Exists(Server.MapPath("/Files/Docs/SDS/PDFs/" + drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }

                                                    categoryUl += "<li><a target='_blank' href='/Files/Docs/SDS/PDfs/" + drProduct["Filename"].ToString() + "'>" + drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentMsdslink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }
                            categoryUl += "</ul>";
                        }
                        

                        
                    }
                }
            }

            msdsDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }
    }

    public void ManualsProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(2);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";

                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentManuallink"] = null;
                                    i = 0;
                                    DataView Productview =new DataView(dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() + "' and WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentManuallink"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/Manuals/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }

                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/Manuals/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentManuallink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }
            manualDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }

    }

    public void MainTenCardProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(4);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";
                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentMainTenCardlink"] = null;
                                    i = 0;
                                    DataView Productview =
                                        new DataView(
                                            dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() +
                                                                       "' and WebSection='" +
                                                                       drSection["WebSection"].ToString() + "'")
                                                .CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentMainTenCardlink"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/MaintenanceCards/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }
                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/MaintenanceCards/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentMainTenCardlink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }

            mainTenCardDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }

    }

    public void ReferenceProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(3);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";
                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentOtherRefflink"] = null;
                                    i = 0;
                                    DataView Productview =
                                        new DataView(
                                            dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() +
                                                                       "' and WebSection='" +
                                                                       drSection["WebSection"].ToString() + "'")
                                                .CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentOtherRefflink"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/Reference/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }

                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/Reference/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentOtherRefflink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }

            otherReffDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }
    }

    public void FlyerProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(6);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";
                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentFlyerlink"] = null;
                                    i = 0;
                                    DataView Productview =
                                        new DataView(
                                            dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() +
                                                                       "' and WebSection='" +
                                                                       drSection["WebSection"].ToString() + "'")
                                                .CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentFlyerlink"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/Flyers/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }

                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/Flyers/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentFlyerlink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }

            flyerDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }
    }

    public void PartsListProducts()
    {
        try
        {
           
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(5);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";
                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentPartsList"] = null;
                                    i = 0;
                                    DataView Productview =
                                        new DataView(
                                            dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() +
                                                                       "' and WebSection='" +
                                                                       drSection["WebSection"].ToString() + "'")
                                                .CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentPartsList"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/Schematics/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }
                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/Schematics/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentPartsList"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }

            partsListDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {

        }

    }

    public void OtherProducts()
    {
        try
        {
            string categoryUl = "";
            DataSet dsProduct = GetProductLibraryByDocType(7);
            int i = 0;
            DataView sectionview = new DataView(dsProduct.Tables[0]);
            DataTable dtSection = sectionview.ToTable(true, "WebSection");

            if (dtSection != null && dtSection.Rows.Count > 0)
            {
                foreach (DataRow drSection in dtSection.Rows)
                {
                    if (drSection["WebSection"] != null && drSection["WebSection"] != string.Empty)
                    {
                        DataView groupview = new DataView(dsProduct.Tables[0].Select("WebSection='" + drSection["WebSection"].ToString() + "'").CopyToDataTable());
                        DataTable WebGroups = groupview.ToTable(true, "WebGroup");
                        if (WebGroups.Rows.Count > 0)
                        {
                            categoryUl += "<strong>" + drSection["WebSection"].ToString() + "</strong><ul><br />";
                            foreach (DataRow group in WebGroups.Rows)
                            {
                                if (group["WebGroup"] != null && group["WebGroup"] != string.Empty)
                                {
                                    Session["currentOtherlink"] = null;
                                    i = 0;
                                    DataView Productview =
                                        new DataView(
                                            dsProduct.Tables[0].Select("WebGroup='" + group["WebGroup"].ToString() +
                                                                       "' and WebSection='" +
                                                                       drSection["WebSection"].ToString() + "'")
                                                .CopyToDataTable());
                                    DataTable dtProduct = Productview.ToTable();
                                    if (dtProduct != null && dtProduct.Rows.Count > 0)
                                    {
                                        //categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                        foreach (DataRow drProduct in dtProduct.Rows)
                                        {
                                            if (Convert.ToString(Session["currentOtherlink"]) !=
                                                drProduct["DocTitle"].ToString())
                                            {
                                                if (!string.IsNullOrEmpty(drProduct["Filename"].ToString()) &&
                                                    File.Exists(
                                                        Server.MapPath("/Files/Docs/Other/PDFs/" +
                                                                       drProduct["Filename"].ToString())))
                                                {
                                                    i = i + 1;
                                                    if (i == 1)
                                                    {
                                                        categoryUl += "<li>" + group["WebGroup"].ToString() + "<ul>";
                                                    }

                                                    categoryUl +=
                                                        "<li><a target='_blank' href='/Files/Docs/Other/PDfs/" +
                                                        drProduct["Filename"].ToString() + "'>" +
                                                        drProduct["DocTitle"].ToString() + "</a></li>";
                                                }

                                                Session["currentOtherlink"] = drProduct["DocTitle"].ToString();
                                            }
                                        }
                                    }
                                    categoryUl += "</ul></li><br />";
                                }
                            }

                            categoryUl += "</ul>";
                        }
                    }
                }
            }

            otherDiv.InnerHtml = categoryUl;
        }
        catch (Exception ex)
        {
            //throw;
        }
    }


    private DataSet GetProductLibraryByDocType(int docType)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT distinct dt2.DocTypeName, ms.WebSectionSort, ms.WebSection, mg.WebGroupSort, mg.WebGroup, dt.DocNo,  max(dt.DocTitle) DocTitle, max(dt.[Filename]) FILENAME FROM DocType dt2, DocPPC dp, DocTitle dt, ProductPage pp, MWebSection ms, MWebGroup mg WHERE pp.ProductPageCode = dp.DocPPC AND ms.WebSectionID = pp.WebSectionID AND pp.WebGroupID = mg.WebGroupID AND  dt2.DocType = dt.DocType and dp.DocNo = dt.DocNo AND pp.WebSectionID > 0 AND dt.[Current] = 1  AND dt2.DocType = " + docType + " GROUP BY dt2.DocTypeName,ms.WebSectionSort, ms.WebSection,mg.WebGroupSort, mg.WebGroup,  dt.DocNo ORDER BY ms.WebSectionSort ASC, mg.WebGroupSort ASC,  max(dt.[Filename]) asc "))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }
}