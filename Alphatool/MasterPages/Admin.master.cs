using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

public partial class MasterPages_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString);
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        if (Session["UserObject"] != null)
        {
            var objUsersInfo = (Members)Session["UserObject"];
            if (objUsersInfo != null)
            {
                if (!IsPostBack)
                {
                    string html = "";
                    string links = "";

                    html += "Welcome  " + objUsersInfo.Name;
                    if (!string.IsNullOrEmpty(links) || links != "")
                    {
                        html +=  links;
                    }
                    spanUser.InnerHtml = html;
                    spanlogout.InnerHtml = "<a style='color: #e84c3d;' href='/Pages/Account/Logout.aspx'>Log Out</a>";

                }
            }
        }
    }
}

