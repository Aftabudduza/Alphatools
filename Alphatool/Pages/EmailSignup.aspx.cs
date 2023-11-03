using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class pages_EmailSignup : Page
{
    string PageTitle = "";
    string PageName = "";
    string errStr = "";
    private System.Net.Mail.SmtpClient objSmtpClient;
    private System.Net.Mail.MailMessage objMailMessage;
    private Regex reEmail = new Regex("^(?:[0-9A-Z_-]+(?:\\.[0-9A-Z_-]+)*@[0-9A-Z-]+(?:\\.[0-9A-Z-]+)*(?:\\.[A-Z]{2,4}))$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadControls();
        }
    }
    
    public string Validate_Control()
    {
        try
        {
            if (txtName.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Name" + Environment.NewLine;
            }
            if (txtCompanyName.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Company Name" + Environment.NewLine;
            }
            if (txtEmail.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Email" + Environment.NewLine;
            }
        }
        catch (Exception ex)
        {
            //
        }

        return errStr;
    }
    public static bool IsDate(object Expression)
    {
        if (Expression != null)
        {
            if (Expression is DateTime)
            {
                return true;
            }
            if (Expression is string)
            {
                DateTime time1;
                return DateTime.TryParse((string)Expression, out time1);
            }
        }
        return false;
    }
    public bool ValidEmail(string value)
    {
        if ((value == null))
            return false;
        return reEmail.IsMatch(value);
    }
    public void ClearControls()
    {       
        txtName.Text = "";
        txtCompanyName.Text = "";
        txtEmail.Text = "";
    }
    private EmailSignup SetData(EmailSignup obj)
    {
        try
        {
            obj.Name = txtName.Text.ToString().Trim();
            obj.CompanyName = txtCompanyName.Text.ToString().Trim();
            obj.Email = txtEmail.Text.ToString().Trim();
        }
        catch (Exception ex)
        { 
            //
        }

        return obj;
    }
    public System.Text.StringBuilder EmailHtml()
    {
        System.Text.StringBuilder emailbody = new System.Text.StringBuilder();
        string sWeb = System.Configuration.ConfigurationManager.AppSettings.Get("WebURL");
        try
        {
            emailbody.Append("<table>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2' style='text-align:Left;font-size:14px;font-weight:bold;color:0000cc;'>Dear " + txtName.Text.ToString() + ", </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'><p>Thank you for your Request. Your given information are as follows: </p> </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'>Name: " + txtName.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Company: " + txtCompanyName.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Email: " + txtEmail.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'><p>Our Representative will contact with you shortly.</p> </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'>Best regards</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Alphatools Team</td></tr>");
            emailbody.Append("</table>");


        }
        catch (Exception ex)
        {
        }
        return emailbody;
    }

    public bool SendEmail()
    {
        bool IsSentSuccessful = false;
        try
        {
            //String from_address = "";
            //String to_address = "";

            //from_address = System.Configuration.ConfigurationManager.AppSettings.Get("fromAddress");

            //try
            //{
            //    to_address = txtEmail.Text.ToString().Trim();
            //}
            //catch (Exception e)
            //{
            //    to_address = System.Configuration.ConfigurationManager.AppSettings.Get("toAddress");
            //}

            //objMailMessage = new MailMessage()
            //{
            //    Subject = "Email Signup from alpha-tools.com",
            //    Body = this.EmailHtml().ToString(),
            //    IsBodyHtml = true
            //};
            //objMailMessage.To.Add(new MailAddress(to_address));
            //objSmtpClient = new SmtpClient();
            //objSmtpClient.SendAsync(objMailMessage, null);
            //IsSentSuccessful = true;

            //Specify senders address
            string SendersAddress = "gogreen@alpha-tools.com";
            const string subject = "Testing";
            //Write the contents of your mail
            string sBody = this.EmailHtml().ToString();
            
            try
            {
                String strMailServer = "mail.eproperty365.com";
                String strMailUser = "sbutcher@eproperty365.com";
                String strMailPassword = "Epr0perty365@809br";
                String strMailPort = "587";
                String isMailLive = "true";

                if (isMailLive == "true")
                {
                    objSmtpClient = new System.Net.Mail.SmtpClient(strMailServer, Convert.ToInt32(strMailPort));
                    objSmtpClient.UseDefaultCredentials = false;
                    
                    objSmtpClient.Credentials = new System.Net.NetworkCredential(strMailUser, strMailPassword);
                   
                }
                else
                {
                    objSmtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    objSmtpClient.UseDefaultCredentials = false;
                    objSmtpClient.EnableSsl = true;
                    objSmtpClient.Credentials = new System.Net.NetworkCredential("info.visaformalaysia@gmail.com", "admin_321");
                }

                objMailMessage = new System.Net.Mail.MailMessage();
                objMailMessage.From = new System.Net.Mail.MailAddress(SendersAddress);
                objMailMessage.To.Add(new System.Net.Mail.MailAddress(txtEmail.Text.ToString()));
               // objMailMessage.Bcc.Add(new System.Net.Mail.MailAddress("gogreen@alpha-tools.com"));
                objMailMessage.Subject = "Email Signup from alpha-tools.com";
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Body = sBody;
                objSmtpClient.Send(objMailMessage);
                IsSentSuccessful = true;
             

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if ((objSmtpClient == null) == false)
                {
                    objSmtpClient = null;
                }

                if ((objMailMessage == null) == false)
                {
                    objMailMessage.Dispose();
                    objMailMessage = null;
                }
            }
        }
        catch (Exception ex)
        {

        }

       

        return IsSentSuccessful;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SendEmail();

        //try
        //{
        //    errStr = Validate_Control();
        //    if (errStr.Length <= 0)
        //    {
        //        EmailSignup obj = new EmailSignup();
        //        obj = SetData(obj);
        //        if (new EmailSignupDa().Insert(obj))
        //        {
        //            if (SendEmail())
        //            {

        //            }
        //            ClearControls();
        //            WebUtility.DisplayMsg("Email Signup saved successfully!", this);
        //        }
        //        else
        //        {
        //            WebUtility.DisplayMsg("Email Signup not saved!", this);
        //        }
        //    }
        //    else
        //    {
        //        WebUtility.DisplayMsg(errStr, this);
        //    }
        //}
        //catch
        //{
        //    WebUtility.DisplayMsg("Operation can not proceed. Please try again!!", this);
        //}

    }
}