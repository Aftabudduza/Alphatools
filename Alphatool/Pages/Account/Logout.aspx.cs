using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using AlphatoolServices.BO;

namespace Pages.Account
{
    public partial class pages_Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserObject"] != null))
            {
                Members obj = new Members();
                obj = (Members)Session["UserObject"];
                HttpContext.Current.Cache.Remove(obj.Email);
            }

            FormsAuthentication.SignOut();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Session.Abandon();
            Session.Clear();
            //Response.Redirect("Login.aspx");
            Response.Redirect("/Default.aspx");
        }
    }
}
