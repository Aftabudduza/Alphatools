using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

public class WebUtility
{
    private static SqlConnection _conn;
    public static string LastError = "";
    public static string EncPass = "Jh3YdgQh4gBD0pQlM8b6xFH";

    //public WebUtility()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public static void DisplayMsg(string msg, Page page)
    {
        msg = msg.Replace(Environment.NewLine, "\\n");
        string str = string.Format("alert('{0}');", msg);
        ScriptManager.RegisterClientScriptBlock(page.Page, page.Page.GetType(), "alert", str, true);
    }

    public static void DisplayMsgAndRedirect(string msg, Page page, string redirectUrl)
    {
        ScriptManager.RegisterStartupScript(page.Page, page.Page.GetType(), "redirect", string.Format("alert('{0}'); window.location='" + redirectUrl + "';", msg), true);
    }
    public static string Connectionstring
    {
        get
        {
            try
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings["Alphatoolcon"].ConnectionString);
            }
            catch (Exception)
            {
                // ignored
            }
            return "";
        }
    }
    public static int WebsiteId
    {
        get
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["WebsiteID"]);
            }
            catch (Exception)
            {
                // ignored
            }
            return 0;
        }
    }
    public static DataTable GetRows(string sql)
    {
        DataTable dt = new DataTable();

        try
        {
            Connect();
            var cmd = new SqlCommand(sql, _conn);
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            Disconnect();
            return dt;
        }
        catch (SqlException ex)
        {
            LastError = TranslateException(ex);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
        }
        return null;
    }
    private static void Connect()
    {
        if (Connectionstring == "")
        {
            if (_conn == null) throw new Exception("Database not connected");
        }
        else
        {
            _conn = new SqlConnection(Connectionstring);
            _conn.Open();
        }
    }
    private static void Disconnect()
    {
        if (!Connectionstring.Equals("") && _conn != null)
        {
            try
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
    private static string TranslateException(SqlException ex)
    {
        return ex.Errors.Cast<SqlError>().Aggregate("", (current, er) => current + (er.Message + "\r\n"));
    }

    public static string Urlpath(ref HttpRequest req)
    {
        string sRoot = "http://" + req.Url.Host + ":" + req.Url.Port + "" + req.ApplicationPath;
        return sRoot;
    }

    public static string GetCMS_Message(string sPageRef, string sDefaultMessage)
    {
        string s = "";

        try
        {
            List<CMSPageRef> pageContent = new CmsPageRefDa().TotalCmsPage(sPageRef);
            pageContent = pageContent.Where(x => x.Live == "Y").ToList();
            if (pageContent != null)
            {
                s = pageContent.Count > 0 ? pageContent[0].CMSContent : "No Page Found !!";
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return s;
    }

    #region "Image Control"

    public static string NotFoundFileName()
    {
        string sSql = "select imagerootpath + '/'+ notfoundfilename from website where id=" + WebsiteId;

        DataTable resultSet = GetRows(sSql);
        string s = "";
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? resultSet.Rows[0]["imagerootpath"].ToString() : "";
        }
        return s;
    }

    public static string ImageRootPath()
    {
        string sSql = "select imagerootpath  from website where id=" + WebsiteId;
        DataTable resultSet = GetRows(sSql);
        string s = "";
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? resultSet.Rows[0]["imagerootpath"].ToString() : "";
        }
        return s;
    }
    public static string ThumbRootPath()
    {
        string sSql = "select thumbrootpath  from website where id=" + WebsiteId;
        DataTable resultSet = GetRows(sSql);
        string s = "";
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? resultSet.Rows[0]["thumbrootpath"].ToString() : "";
        }
        return s;

    }
    public static string ImageRootFilePath()
    {
        string sSql = "select imagerootfilepath from website where id=" + WebsiteId;
        DataTable resultSet = GetRows(sSql);
        string s = "";
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? resultSet.Rows[0]["imagerootfilepath"].ToString() : "";
        }
        return s;
    }
    public static string ThumbRootFilePath()
    {
        string sSql = "select thumbrootfilepath  from website where id=" + WebsiteId;
        DataTable resultSet = GetRows(sSql);
        string s = "";
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? resultSet.Rows[0]["thumbrootfilepath"].ToString() : "";
        }
        return s;
    }

    public static int Thumbimagewidth()
    {
        string sSql = "select thumbimagewidth  from website where id=" + WebsiteId;

        DataTable resultSet = GetRows(sSql);
        int s = 0;
        // Create the second-level nodes
        if (resultSet != null)
        {
            s = resultSet.Rows.Count > 0 ? Convert.ToInt32(resultSet.Rows[0]["thumbimagewidth"]) : 0;
        }

        return s;
    }
    #endregion

    #region "ImageRotation"

    public static string FixPath(string sPath)
    {
        if (sPath.Length > 0)
        {
            if (sPath.Substring(sPath.Length - 1, 1) != "\\")
            {
                sPath += "\\";
            }
        }
        return sPath;
    }
    public static string FixUrlPath(string sPath)
    {
        if (sPath.Length > 0)
        {
            if (sPath.Substring(sPath.Length - 1, 1) != "/")
            {
                sPath += "/";
            }
        }
        return sPath;
    }

    #endregion

    #region Error

    public static string ErrorLogPath
    {
        get { return ConfigurationManager.AppSettings["ErrorLogPath"]; }
    }
    public static void LogDataError(string information)
    {
        // Always on
        try
        {
            var sw = new StreamWriter(FixPath(ErrorLogPath) + "SQLDataError.log", true);
            sw.WriteLine(DateTime.Now + ": " + information);
            sw.Flush();
            sw.Close();
        }
        catch (Exception)
        {
            // ignored
        }
    }

    #endregion

    #region "Email"
    public static bool Send_Email(string strUserTo, string strEmailTo, string sSubject, StringBuilder sbBody, string sServer, string sEmailAccount, string sEmailPass, int iEmailPort, ref string sError)
    {
        try
        {
            var objCustomerEmail = new MailMessage();
            //Works also
            var objSmtpClient = new SmtpClient(sServer, iEmailPort)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            if (!string.IsNullOrEmpty(sEmailPass.Trim()))
            {
                objSmtpClient.Credentials = new NetworkCredential(sEmailAccount, sEmailPass);
            }
            objCustomerEmail.From = new MailAddress(sEmailAccount);
            objCustomerEmail.To.Add(new MailAddress(strEmailTo));
            objCustomerEmail.Headers.Set("Return-Path", sEmailAccount);
            objCustomerEmail.IsBodyHtml = true;
            objCustomerEmail.Subject = sSubject;
            objCustomerEmail.Body = sbBody.ToString();
            objSmtpClient.Send(objCustomerEmail);

            return true;
        }
        catch (Exception ex)
        {
            sError = ex.Message;
            LogDataError("Error sending email: " + ex.Message);
            return false;
        }

    }
    #endregion
}
