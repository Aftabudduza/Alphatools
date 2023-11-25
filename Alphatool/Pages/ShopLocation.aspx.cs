using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using System.Runtime;

public partial class pages_AboutUs : Page
{
    string PageTitle = "";
    string PageName = "";
    public string MAPStr = "";
    public string MAPCountryStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(
        //               UpdatePanel1,
        //               this.GetType(),
        //               "MyAction",
        //               "doMyAction();",
        //               true);
        // Register the JavaScript function on page load
       

        MAPCountryStr = "[39.670352, -74.822259]";
        Session["categoryid"] = null;
        if (!IsPostBack)
        {
            LoadControls();
            ltlStore.Text = "<p style='text-align: center;color: black;'><b>No Results</b><br/>Try entering a location or using your current location.</p>";
        }
    }


    public void LoadControls()
    {
        try
        {
            ddlType.Items.Clear();
            ddlType.AppendDataBoundItems = true;
            ddlType.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtProcess = new DataTable();
            dtProcess = WebUtility.GetRows("select type from  [DealerLocLocal]  where type is not null and type<>'' group by type  order by [type] asc");
            if (dtProcess != null && dtProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProcess.Rows)
                {
                    ddlType.Items.Add(new ListItem(dr["type"].ToString(), dr["type"].ToString()));
                }
            }

            ddlType.DataBind();
            ddlType.SelectedValue = "-1";

        }
              catch (Exception ex)
             
        {
           
        }

        try
        {
            ddlCountry.Items.Clear();
            ddlCountry.AppendDataBoundItems = true;
            ddlCountry.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtProcess = new DataTable();
            dtProcess = WebUtility.GetRows(" select [LocCountry] from  [DealerLocLocal]  where [LocCountry] is not null and [LocCountry]<>'' group by [LocCountry]  order by [LocCountry] asc");
            if (dtProcess != null && dtProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProcess.Rows)
                {
                    ddlCountry.Items.Add(new ListItem(dr["LocCountry"].ToString(), dr["LocCountry"].ToString()));
                }
            }

            ddlCountry.DataBind();
            ddlCountry.SelectedValue = "-1";

        }
        catch (Exception ex)
        {
        }


        try
        {
            var ecomlink = "";
            DataTable dtProcess = new DataTable();
            dtProcess = WebUtility.GetRows("select *  from [DealerLocOnline] where status='TRUE' order by tier asc,[DisplayName] asc");
            if (dtProcess != null && dtProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProcess.Rows)
                {
                    ecomlink = "https://" + dr["EComSite"].ToString();
                    ltlData.Text += 
                       "<div class='col-sm-2  ps-online-seller-cell'>" +
                                "<div class='ps-online-seller-content'>" +
                                    "<div class='ps-online-buy-cell'>" +
                                        "<img src='../Images/location/" + dr["Logo"].ToString() + "' /><br/>" +
                                        "<a href='" + ecomlink  + "' target='_blank'>Buy Now</a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
                }

            }
            else { ltlData.Text = "No Data Found"; }


  
        }
        catch (Exception ex)
        {
        }

    }


    public void LoadLocalStore()
    {

        //---Start Local Store
        try
        {
            ltlStore.Text = "";
            var maplink = "";
            var i = 0;
            var ExStr = "";


            if (ddlType.SelectedValue != "-1") {

                ExStr += " and type='" + ddlType.SelectedValue + "'" ;
            }
            if (ddlCountry.SelectedValue != "-1")
            {

                ExStr += " and LocCountry='" + ddlCountry.SelectedValue + "'";
            }


            if (txtSearch.Text.Length > 0)
            {
                var TotStr = txtSearch.Text.ToString().Trim();
                if (TotStr.Contains(","))
                {
                    string[] Finstr = TotStr.Split(',');
                    ExStr += " and LocCity like '%" + Finstr[0] + "%'";
                    ExStr += " and (LocSt like '%" + Finstr[1].Trim() + "%' or LocZip like '%" + Finstr[1].Trim() + "%')";
                }

            }



            DataTable dtProcess = new DataTable();
            dtProcess = WebUtility.GetRows("select *  from [DealerLocLocal] where status='TRUE' " + ExStr + " order by LocSt asc");
            if (dtProcess != null && dtProcess.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProcess.Rows)
                {
                    i = i + 1;
                    string tempHtml = "";
                    maplink = "https://www.google.com/maps/dir/?api=1&destination=" + dr["Latitude"].ToString() + ", " + dr["Longitude"].ToString();

                    string onClickScript = "showLocationOnMap(" + dr["Latitude"] + ", " + dr["Longitude"] + ", \"" + dr["CustName"].ToString().Replace("'", "") + "\", \"#" + dr["CustNo"].ToString() + "\", " + i.ToString() + ", \"" + maplink + "\"); return false;";
                    

                    ltlStore.Text += "<div class='ps-map-pushpin-select' onclick='{" + onClickScript + "}' data-store='25355849' data-action='popup'> " +
"                                        <div class='ps-map-k'><div class='ps-local-column-one' > " +
"                                            <img class='ps-pushpin' src ='../images/location/loc3.png' data -target='0' > " +
"<div class='marker-number'>"+i.ToString()+"</div>" +
"                                        </div> " +
"                                        <div class='ps-local-column-two' > " +
"                                            <div class='ps-local-seller-logo'> " +
"                                               " + dr["CustName"].ToString() + " #" + dr["CustNo"].ToString() + " " +
"                                          </div> " +
"                                            <div class='ps-address'> " +
"                                                <span>" + dr["LocAdd"].ToString() + "</span> " +
"                                                <span>" + dr["LocCity"].ToString()  + ", " + dr["LocSt"].ToString() + " " + dr["LocZip"].ToString() + "</span> " +
"                                                <span>" + dr["AccountNo"].ToString() + "</span> " +
"                                            </div> " +
"                                         </div> </div>" +
"                                        <div class='ps-local-column-four' > " +
"                                            <div class='ps-get-directions-mobile' > " +
"                                                <a class='ps-get-directions-button' onclick='event.stopPropagation();' href='" + maplink + "' target='_blank'> " +
"                                                    <svg xmlns='http://www.w3.org/2000/svg' width ='22px' height ='20px' viewBox ='0 0 22 20' > " +
"                                                        <path d='M 22 11.11C 22 10.63 21.9 10.18 21.73 9.77 21.71 9.66 21.69 9.55 21.66 9.45 21.66 9.45 19.75 4.25 19.75 4.25 19.75 4.25 19.74 4.2 19.74 4.2 19.07 2.02 18.12-0 15.7-0 15.7-0 6.48-0 6.48-0 4.01-0 3.14 2.07 2.45 4.19 2.45 4.19 0.45 9.4 0.45 9.4 0.16 9.91 0 10.49 0 11.11 0 11.11 0 12.73 0 12.73 0 12.98 0.03 13.22 0.08 13.46 0.03 13.6 0 13.75 0 13.91 0 13.91 0 18.72 0 18.72 0 19.43 0.52 20 1.16 20 1.16 20 3.58 20 3.58 20 4.22 20 4.74 19.43 4.74 18.72 4.74 18.72 4.74 16.32 4.74 16.32 4.74 16.32 17.4 16.32 17.4 16.32 17.4 16.32 17.4 18.72 17.4 18.72 17.4 19.43 17.92 20 18.56 20 18.56 20 20.84 20 20.84 20 21.48 20 22 19.43 22 18.72 22 18.72 22 13.91 22 13.91 22 13.75 21.97 13.6 21.92 13.46 21.97 13.22 22 12.98 22 12.73 22 12.73 22 11.11 22 11.11 22 11.11 22 11.11 22 11.11ZM 3.87 4.71C 4.63 2.36 5.24 1.64 6.48 1.64 6.48 1.64 15.7 1.64 15.7 1.64 16.93 1.64 17.62 2.44 18.31 4.7 18.31 4.7 19.71 7.8 19.71 7.8 19.25 7.62 18.75 7.52 18.22 7.52 18.22 7.52 3.78 7.52 3.78 7.52 3.3 7.52 2.85 7.6 2.43 7.75 2.43 7.75 3.87 4.71 3.87 4.71ZM 5.07 13.34C 5.07 13.34 2.52 13.34 2.52 13.34 2.06 13.34 1.69 12.93 1.69 12.43 1.69 11.92 2.06 11.52 2.52 11.52 2.52 11.52 5.07 11.52 5.07 11.52 5.53 11.52 5.9 11.92 5.9 12.43 5.9 12.93 5.53 13.34 5.07 13.34ZM 14.07 13.16C 14.07 13.16 8.14 13.16 8.14 13.16 7.85 13.16 7.62 12.9 7.62 12.58 7.62 12.26 7.85 12 8.14 12 8.14 12 14.07 12 14.07 12 14.36 12 14.6 12.26 14.6 12.58 14.6 12.9 14.36 13.16 14.07 13.16ZM 19.41 13.34C 19.41 13.34 16.87 13.34 16.87 13.34 16.41 13.34 16.04 12.93 16.04 12.43 16.04 11.92 16.41 11.52 16.87 11.52 16.87 11.52 19.41 11.52 19.41 11.52 19.87 11.52 20.25 11.92 20.25 12.43 20.25 12.93 19.87 13.34 19.41 13.34Z' fill ='rgb(0,0,0)' ></path> " +
"                                                    </svg> " +
"                                                    Directions " +
"                                                 </a> " +
"                                            </div> " +
"                                            <div class='ps-mobile-phone' > " +
"                                                <a class='ps-call-store-button' onclick='event.stopPropagation();' href ='tel:" + dr["AccountNo"].ToString() + "'>" +
"                                                    <svg xmlns='http://www.w3.org/2000/svg' width ='20px' height ='20px' viewBox ='0 0 20 20' > " +
"                                                        <path d='M 4.01 8.66C 5.56 11.77 8.23 14.33 11.34 16 11.34 16 13.78 13.55 13.78 13.55 14.11 13.22 14.56 13.11 14.89 13.33 16.11 13.78 17.44 13.99 18.89 13.99 19.55 13.99 19.99 14.44 19.99 15.11 19.99 15.11 19.99 18.89 19.99 18.89 19.99 19.55 19.55 20 18.89 20 8.45 20 0.01 11.55 0.01 1.1 0.01 0.43 0.46-0.01 1.12-0.01 1.12-0.01 5.01-0.01 5.01-0.01 5.67-0.01 6.12 0.43 6.12 1.1 6.12 2.44 6.34 3.77 6.78 5.1 6.9 5.44 6.78 5.88 6.56 6.21 6.56 6.21 4.01 8.66 4.01 8.66Z' fill ='rgb(0,0,0)' ></path> " +
"                                                    </svg> " +
"                                                    Call " +
"                                                </a> " +
"                                            </div> " +
"                                        </div> " +
" " +
"                                    </div> ";

                    MAPStr += "{ lat: "+ dr["Latitude"].ToString() + ", lng: "+ dr["Longitude"].ToString() + ", name: '" + dr["CustName"].ToString().Replace("'","") + "',cusno: '#"+ dr["CustNo"].ToString() + "' },";
                    if (ddlCountry.SelectedValue != "-1")
                    {
                        MAPCountryStr = "[" + dr["Latitude"].ToString() + ", " + dr["Longitude"].ToString() + "]";
                    }
                    if (txtSearch.Text.Length > 0)
                    {
                        MAPCountryStr = "[" + dr["Latitude"].ToString() + ", " + dr["Longitude"].ToString() + "]";
                    }

                    // Add OnClientClick attribute to call the JavaScript function
                    //ltlStore.Text += "<a href='#' onclick='" + onClickScript + "'>" + tempHtml + "</a>";
                    

                }
                MAPStr = MAPStr.TrimEnd(',');
            }
            else { ltlStore.Text = "<p style='text-align: center;color: black;'><b>No Results</b><br/>Try entering a location or using your current location.</p>"; }
            

        }
        catch (Exception ex)
        {
        }
        //---End Local Store



    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        LoadLocalStore();
    }




    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLocalStore();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLocalStore();
    }
}
