using System;
using System.Web.UI;
using AlphatoolServices.DA;

namespace Pages.Account
{
    public partial class pages_Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                new MembersDa(true);
            }
        }
        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtUserId.Text.Trim()) && !String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    if (txtUserId.Text.ToString().Trim().ToLower() == "aftab@alpha-tools.com" && txtPassword.Text.ToString().Trim() == "12Holidays")
                    {
                        Response.Redirect("http://173.248.151.145:100/admin/admin/Login.aspx?ReturnUrl=%2fadmin%2fdefault.aspx", false);
                    }
                    else
                    {
                        DisplayMsg("Your login attempt was not successful. Please try again !!", this);
                    }

                    //var objUser = new MembersDa(true).GetMembersByEmailPassword(txtUserId.Text, txtPassword.Text);
                    //if (objUser != null)
                    //{
                    //    Session["UserObject"] = objUser;

                    //    if (objUser.Email.Trim().ToLower() == "sstillman@alpha-tools.com")
                    //    {
                    //        Response.Redirect("~/Pages/Admin/AdminHome.aspx", false);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/Pages/Member/MemberDashboard.aspx", false);
                    //    }
                    //}
                    //else
                    //{
                    //    DisplayMsg("Member Not Exist !!", this);
                    //}
                }
                else
                {
                    DisplayMsg("Your login attempt was not successful. Please try again !!", this);
                }
            }
            catch (Exception)
            {
                DisplayMsg("Your login attempt was not successful. Please try again !!", this);
            }
        }

        public static void DisplayMsg(string msg, Page page)
        {
            msg = msg.Replace(Environment.NewLine, "\\n");
            string str = string.Format("alert('{0}');", msg);
            ScriptManager.RegisterClientScriptBlock(page.Page, page.Page.GetType(), "alert", str, true);
        }
    }
}