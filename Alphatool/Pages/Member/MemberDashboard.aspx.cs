using System;
using System.Web.UI;
using AlphatoolServices.BO;

public partial class pages_MemberDashboard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserObject"] != null))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "HideProgress", "HideProgress();", true);
            Members objUser = new Members();
            objUser = (Members)Session["UserObject"];
            if (objUser != null)
            {
                Session["UserObject"] = objUser;
                if (!IsPostBack)
                {
                   
                }
            }
        }
       
       
    }
}
