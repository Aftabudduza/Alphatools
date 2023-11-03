using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using AlphatoolServices.Utility;
using System.Web.UI.HtmlControls;

public partial class Pages_QuickOrder : System.Web.UI.Page
{
    string sPartNo = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

       
    }
    private DataSet GetData(string sSQL)
    {
        string constr = ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(sSQL))
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
    public void GetProductsByPart(string partnumber)
    {
        Table tblparts = new Table();
        tblparts.Attributes.Add("style", "border:2px solid #3379B7; margin-bottom:0;width:100%;float:left;");
        TableRow trparts = new TableRow();
        TableCell tdparts = new TableCell();

        Table tblpartsSub = new Table();
        tblpartsSub.Attributes.Add("class", "table table-responsive table-bordered ");
        tblpartsSub.Attributes.Add("style", "margin-bottom:0;");
        TableHeaderRow trpartsheaderRow = new TableHeaderRow();
        trpartsheaderRow.Attributes.Add("style", "background:#3379B7;color:#fff;border:2px solid #3379B7; margin-bottom:0;");
        TableHeaderCell tdpartsheaderCell = new TableHeaderCell();
     
       // string strSQL = " SELECT DISTINCT  p.PartNo, min(pw.Sort) Sort, isnull(max(P.[Description]),'') Description, isnull(max(P.MSRP),0) MSRP, isnull(max(pw.QProductID), 0) QProductID FROM PartsWebfields pw, PartsInfo P WHERE pw.PartNo = P.Partno AND pw.PartNo = '" + partnumber + "'  GROUP BY P.Partno UNION SELECT DISTINCT  p.PartNo, min(pw.SORT4_Part) Sort, isnull(max(P.[Description]),'') Description, isnull(max(P.MSRP),0) MSRP, isnull(max(pw.QProductID), 0) QProductID FROM Webfields pw, ProductInfo P WHERE pw.PartNo = P.Partno AND pw.PartNo = '" + partnumber + "'  GROUP BY P.Partno ";

        string strSQL = " SELECT DISTINCT  A.QProductID, isnull(max(A.PartNo), 0) PartNo, min(A.Sort) Sort, isnull(max(A.[Description]),'') Description, isnull(max(A.MSRP),0) MSRP FROM (SELECT DISTINCT  p.PartNo, min(pw.Sort) Sort, isnull(max(P.[Description]),'') Description, isnull(max(P.MSRP),0) MSRP, isnull(max(pw.QProductID), 0) QProductID FROM PartsWebfields pw, PartsInfo P WHERE pw.PartNo = P.Partno AND pw.PartNo = '" + partnumber + "'  GROUP BY P.Partno  UNION SELECT DISTINCT  p.PartNo, min(pw.SORT4_Part) Sort, isnull(max(P.[Description]),'') Description, isnull(max(P.MSRP),0) MSRP, isnull(max(pw.QProductID), 0) QProductID FROM Webfields pw, ProductInfo P WHERE pw.PartNo = P.Partno AND pw.PartNo = '" + partnumber + "'  GROUP BY P.Partno) A GROUP BY A.QProductID ";
        DataSet ds = this.GetData(strSQL);
        
        spareparts.Controls.Clear();

        if (ds != null)
        {
            foreach (DataTable table in ds.Tables)
            {
                if (table.Rows.Count > 0)
                {                 

                    tdpartsheaderCell = new TableHeaderCell { Text = "PART NO." };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "DESCRIPTION" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:left;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "PRICE" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:right;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tdpartsheaderCell = new TableHeaderCell { Text = "BUY NOW" };
                    tdpartsheaderCell.Attributes.Add("style", "text-align:center;");
                    trpartsheaderRow.Controls.Add(tdpartsheaderCell);

                    tblpartsSub.Controls.Add(trpartsheaderRow);
                    int i = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();
                           

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }                          

                            if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Description"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }


                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:center;");

                                System.Web.UI.HtmlControls.HtmlGenericControl addDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addDiv.InnerHtml = "<div data-widget=" + dr["QProductID"].ToString() + "></div>";
                                //  addDiv.InnerHtml = "<a onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");'><div data-widget=" + dr["QProductID"].ToString() + "></div></a><br /><input class='btn btn-default' value='Add To Cart' onclick='Quivers.Catalog.ProductShort(" + dr["QProductID"].ToString() + ");' type='button'>";
                                tddatacell.Controls.Add(addDiv);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#D8E7F4; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                        else
                        {
                            TableRow trdataRow = new TableRow();
                            TableCell tddatacell = new TableCell();                           

                            if (!string.IsNullOrEmpty(dr["PartNo"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["PartNo"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }                                                    

                            if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                            {
                                tddatacell = new TableCell { Text = dr["Description"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "CALL" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:right;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            if (!string.IsNullOrEmpty(dr["MSRP"].ToString()) && Convert.ToDecimal(dr["MSRP"].ToString()) > 0)
                            {
                                tddatacell = new TableCell { Text = dr["MSRP"].ToString() };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:center;");

                                System.Web.UI.HtmlControls.HtmlGenericControl addDiv1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                                addDiv1.InnerHtml = "<div data-widget=" + dr["QProductID"].ToString() + "></div>";
                                tddatacell.Controls.Add(addDiv1);

                                if (tddatacell != null)
                                {
                                    trdataRow.Controls.Add(tddatacell);
                                }
                            }
                            else
                            {
                                tddatacell = new TableCell { Text = "" };
                                tddatacell.Attributes.Add("style", "background:#fff; color:#404040;text-align:left;");
                                trdataRow.Controls.Add(tddatacell);
                            }

                            tblpartsSub.Controls.Add(trdataRow);
                        }
                    }
                }
            }

            tdparts.Controls.Add(tblpartsSub);
            trparts.Controls.Add(tdparts);
            tblparts.Controls.Add(trparts);
            spareparts.Controls.Add(tblparts);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {           
            if (txtPartNoFAQ.Text.ToString().Trim().Length <= 0)
            {
                spareparts.InnerHtml = "Please enter text to search for a Spare Part Number";
            }
            else
            {
                GetProductsByPart(txtPartNoFAQ.Text.ToString().Trim());
            }
        }
        catch (Exception ex)
        {
            //
        }
    }
}