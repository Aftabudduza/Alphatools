using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Web.Providers.Entities;
using System.Xml;

public partial class pages_RequestADealerInfo : Page
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
            LoadControls();
        }
    }
    public void LoadControls()
    {
        try
        {
            state.Items.Clear();
            state.AppendDataBoundItems = true;
            state.Items.Add(new ListItem("Select State", "-1"));
            state.Items.Add(new ListItem("Outside US", "XX"));
            state.Items.Add(new ListItem("Alabama", "AL"));
            state.Items.Add(new ListItem("Alaska", "AK"));
            state.Items.Add(new ListItem("Arizona", "AZ"));
            state.Items.Add(new ListItem("Arkansas", "AR"));
            state.Items.Add(new ListItem("California", "CA"));
            state.Items.Add(new ListItem("Colorado", "CO"));
            state.Items.Add(new ListItem("Connecticut", "CT"));
            state.Items.Add(new ListItem("District of Columbia", "DC"));
            state.Items.Add(new ListItem("Delaware", "DE"));
            state.Items.Add(new ListItem("Florida", "FL"));
            state.Items.Add(new ListItem("Georgia", "Ga"));
            state.Items.Add(new ListItem("Hawaii", "HI"));
            state.Items.Add(new ListItem("Idaho", "ID"));
            state.Items.Add(new ListItem("Illinois", "IL"));
            state.Items.Add(new ListItem("Indiana", "IN"));
            state.Items.Add(new ListItem("Iowa", "IA"));
            state.Items.Add(new ListItem("Kansas", "KS"));
            state.Items.Add(new ListItem("Kentucky", "KY"));
            state.Items.Add(new ListItem("Louisiana", "LA"));
            state.Items.Add(new ListItem("Maine", "ME"));
            state.Items.Add(new ListItem("Maryland", "MD"));
            state.Items.Add(new ListItem("Massachusetts", "MA"));
            state.Items.Add(new ListItem("Michigan", "MI"));
            state.Items.Add(new ListItem("Minnesota", "MN"));
            state.Items.Add(new ListItem("Mississippi", "MS"));
            state.Items.Add(new ListItem("Missouri", "MO"));
            state.Items.Add(new ListItem("Montana", "MT"));
            state.Items.Add(new ListItem("Nebraska", "NE"));
            state.Items.Add(new ListItem("Nevada", "NV"));
            state.Items.Add(new ListItem("New Hampshire", "NH"));
            state.Items.Add(new ListItem("New Jersey", "NJ"));
            state.Items.Add(new ListItem("New Mexico", "NM"));
            state.Items.Add(new ListItem("New York", "NY"));
            state.Items.Add(new ListItem("North Carolina", "NC"));
            state.Items.Add(new ListItem("North Dakota", "ND"));
            state.Items.Add(new ListItem("Ohio", "OH"));
            state.Items.Add(new ListItem("Oklahoma", "OK"));
            state.Items.Add(new ListItem("Oregon", "OR"));
            state.Items.Add(new ListItem("Pennsylvania", "PA"));
            state.Items.Add(new ListItem("Rhode Island", "RI"));
            state.Items.Add(new ListItem("South Carolina", "SC"));
            state.Items.Add(new ListItem("South Dakota", "SD"));
            state.Items.Add(new ListItem("Tennessee", "TN"));
            state.Items.Add(new ListItem("Texas", "TX"));
            state.Items.Add(new ListItem("Utah", "UT"));
            state.Items.Add(new ListItem("Vermont", "VT"));
            state.Items.Add(new ListItem("Virginia", "VA"));
            state.Items.Add(new ListItem("Washington", "WA"));
            state.Items.Add(new ListItem("West Virginia", "WV"));
            state.Items.Add(new ListItem("Wisconsin", "WI"));
            state.Items.Add(new ListItem("Wyoming", "WY"));
            state.DataBind();
            state.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

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

            if (txtAddress1.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Address Line 1" + Environment.NewLine;
            }

            if (txtCity.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter City" + Environment.NewLine;
            }
            if (state.SelectedValue == "-1")
            {
                errStr += "Please Select State" + Environment.NewLine;
            }
            if (txtZipCode.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Postal Code" + Environment.NewLine;
            }
          
            if (txtEmail.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Email" + Environment.NewLine;
            }

            if (txtWorkPhone.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Work phone" + Environment.NewLine;
            }


        }
        catch (Exception ex)
        {
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
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        state.SelectedValue = "-1";
        txtZipCode.Text = "";
        txtCountry.Text = "";
        txtWorkPhone.Text = "";
        txtEmail.Text = "";
        txtHomePhone.Text = "";
        txtMobile.Text = "";
        txtPurpose.Text = "";
    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            errStr = Validate_Control();
            if (errStr.Length <= 0)
            {
                if (SendEmail())
                {
                    ClearControls();
                    WebUtility.DisplayMsg("Request Sent Successfully. We will contact with you soon !!", this);
                }
                else {
                    WebUtility.DisplayMsg("Mail was not sent !!", this);
                }
            }
            else
            {
                WebUtility.DisplayMsg(errStr, this);
            }
        }
        catch
        {
            WebUtility.DisplayMsg("Operation can not proceed. Please try again !!", this);
        }
    }

    public System.Text.StringBuilder EmailHtml()
    {
        System.Text.StringBuilder emailbody = new System.Text.StringBuilder();
        string sWeb = System.Configuration.ConfigurationManager.AppSettings.Get("WebURL");
        try
        {
            emailbody.Append("<table>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            //emailbody.Append("<tr><td colspan='2'><img  alt='File-IT' width='170' height='66' src='" + sWeb + "Images/logo.gif'></td></tr>");
            //emailbody.Append("<tr><td colspan='2'></td></tr>");
         
            emailbody.Append("<tr><td colspan='2' style='text-align:Left;font-size:14px;font-weight:bold;color:0000cc;'>Dear " + txtName.Text.ToString() + ", </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'><p>Thank you for your Request. Your given information are as follows: </p> </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'>Name: " + txtName.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Company: " + txtCompanyName.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Address Line 1: " + txtAddress1.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Address Line 2: " + txtAddress2.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>City: " + txtCity.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>State: " + state.SelectedItem.Text.ToString() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Postal Code: " + txtZipCode.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Country: " + txtCountry.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Email: " + txtEmail.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Work Phone: " + txtWorkPhone.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Home Phone: " + txtHomePhone.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Mobile Phone: " + txtMobile.Text.ToString().Trim() + "</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Description: " + txtPurpose.Text.ToString().Trim() + "</td></tr>");

            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'><p>Our Representative will contact with you shortly.</p> </td></tr>");
            emailbody.Append("<tr><td colspan='2'></td></tr>");
            emailbody.Append("<tr><td colspan='2'>Best regards</td></tr>");
            emailbody.Append("<tr><td colspan='2'>Alpha Pro Tools Team</td></tr>");
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
            string strMailServer = string.Empty;
            string strMailUser = "";
            string strMailPassword = "";
            string strMailPort = System.Configuration.ConfigurationManager.AppSettings.Get("strMailPort");
            strMailUser = System.Configuration.ConfigurationManager.AppSettings.Get("strMailUser");
            strMailPassword = System.Configuration.ConfigurationManager.AppSettings.Get("strMailPassword");
            strMailServer = System.Configuration.ConfigurationManager.AppSettings.Get("strMailServer");          
            string from_address = "";
            string to_address = "";
            from_address = System.Configuration.ConfigurationManager.AppSettings.Get("fromAddress");

            try
            {
                to_address = txtEmail.Text.ToString().Trim();
            }
            catch (Exception e)
            {
                to_address = System.Configuration.ConfigurationManager.AppSettings.Get("toAddress");
            }

            //strMailServer = "mail.etag365.com";
            //strMailUser = "do_not_reply@etag365.com";
            //strMailPassword = "E365donotreply#809";
            //strMailPort = "587";

            String isMailLive = "true";

            if (isMailLive == "true")
            {
                objSmtpClient = new System.Net.Mail.SmtpClient(strMailServer, Convert.ToInt32(strMailPort));
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = false;
                objSmtpClient.Credentials = new System.Net.NetworkCredential(strMailUser, strMailPassword);
            }
            else
            {
                objSmtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.Credentials = new System.Net.NetworkCredential("info.visaformalaysia@gmail.com", "admin_321");
            }

            //objMailMessage = new System.Net.Mail.MailMessage();
            //objMailMessage.From = new System.Net.Mail.MailAddress(from_address, "Support", System.Text.Encoding.UTF8);
            //objMailMessage.To.Add(new System.Net.Mail.MailAddress(to_address));
            //objMailMessage.Bcc.Add(new System.Net.Mail.MailAddress("info@alpha-tools.com"));

            //objMailMessage.Subject = "Request To Find a Dealer from alpha-tools.com";
            //objMailMessage.IsBodyHtml = true;

            //objMailMessage.Body = this.EmailHtml().ToString();
            //objSmtpClient.TargetName = "STARTTLS/smtp.office365.com";
            //try
            //{
            //    objSmtpClient.Send(objMailMessage);
            //    IsSentSuccessful = true;
            //}
            //catch (Exception ex)
            //{

            //}

            objMailMessage = new System.Net.Mail.MailMessage();
            objMailMessage.From = new System.Net.Mail.MailAddress(strMailUser, "Support", System.Text.Encoding.UTF8);
            objMailMessage.To.Add(new System.Net.Mail.MailAddress(to_address));
            // objMailMessage.Bcc.Add(new System.Net.Mail.MailAddress("info@alpha-tools.com"));
            objMailMessage.Subject = "Request To Find a Dealer from alpha-tools.com";
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Body = this.EmailHtml().ToString();
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            objSmtpClient.TargetName = "STARTTLS/smtp.office365.com";
            //objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;


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

        return IsSentSuccessful;
    }
    //public bool SendEmail()
    //{
    //    bool IsSentSuccessful = false;
    //    try
    //    {
    //        string strMailServer = string.Empty;
    //        string strMailUser = "";
    //        string strMailPassword = "";
    //        string strMailPort = System.Configuration.ConfigurationManager.AppSettings.Get("strMailPort");           

    //        strMailUser = System.Configuration.ConfigurationManager.AppSettings.Get("strMailUser");
    //        strMailPassword = System.Configuration.ConfigurationManager.AppSettings.Get("strMailPassword");
    //        strMailServer = System.Configuration.ConfigurationManager.AppSettings.Get("strMailServer");

    //        //objSmtpClient = new System.Net.Mail.SmtpClient("smtp.office365.com", Convert.ToInt32(strMailPort));
    //        //objSmtpClient = new System.Net.Mail.SmtpClient(strMailServer, Convert.ToInt32(strMailPort));
    //        //objSmtpClient.EnableSsl = true;
    //        //objSmtpClient.Credentials = new System.Net.NetworkCredential(strMailUser, strMailPassword);
    //        //objSmtpClient.UseDefaultCredentials = false;
    //        string from_address = "";
    //        string to_address = "";
    //        from_address = System.Configuration.ConfigurationManager.AppSettings.Get("fromAddress");

    //        try
    //        {
    //            to_address = txtEmail.Text.ToString().Trim();
    //        }
    //        catch (Exception e)
    //        {
    //            to_address = System.Configuration.ConfigurationManager.AppSettings.Get("toAddress");
    //        }

    //        objSmtpClient = new System.Net.Mail.SmtpClient(strMailServer, Convert.ToInt32(strMailPort));
    //        objSmtpClient.UseDefaultCredentials = false;
    //        objSmtpClient.Credentials = new System.Net.NetworkCredential(strMailUser, strMailPassword);

    //        objMailMessage = new System.Net.Mail.MailMessage();
    //        objMailMessage.From = new System.Net.Mail.MailAddress(strMailUser);
    //        objMailMessage.To.Add(new System.Net.Mail.MailAddress(to_address));
    //        //  objMailMessage.To.Add(new System.Net.Mail.MailAddress("aftabudduza@gmail.com"));
    //        objMailMessage.Subject = "Request To Find a Dealer from alpha-tools.com";
    //        objMailMessage.IsBodyHtml = true;

    //        objMailMessage.Body = this.EmailHtml().ToString();

    //        try
    //        {
    //            objSmtpClient.Send(objMailMessage);
    //            IsSentSuccessful = true;
    //        }
    //        catch (Exception ex)
    //        {

    //        }

    //        // objMailMessage = new System.Net.Mail.MailMessage();
    //        // objMailMessage.From = new System.Net.Mail.MailAddress(strMailUser, "Support", System.Text.Encoding.UTF8);
    //        // objMailMessage.To.Add(new System.Net.Mail.MailAddress(to_address));
    //        //// objMailMessage.Bcc.Add(new System.Net.Mail.MailAddress("info@alpha-tools.com"));
    //        // objMailMessage.Subject = "Request To Find a Dealer from alpha-tools.com";
    //        // objMailMessage.IsBodyHtml = true;
    //        // objMailMessage.Body = this.EmailHtml().ToString();
    //        // objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
    //        // objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
    //        // //objSmtpClient.TargetName = "STARTTLS/smtp.office365.com";
    //        // objSmtpClient.TargetName = "STARTTLS/mail.etag365.com";
    //        // //objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

    //        // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;


    //        // objSmtpClient.Send(objMailMessage);


    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //    finally
    //    {
    //        if ((objSmtpClient == null) == false)
    //        {
    //            objSmtpClient = null;
    //        }

    //        if ((objMailMessage == null) == false)
    //        {
    //            objMailMessage.Dispose();
    //            objMailMessage = null;
    //        }
    //    }

    //    return IsSentSuccessful;
    //}

    //public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
    //{
    //    //Get the Original MailMessage object
    //    MailMessage mail = (MailMessage)e.UserState;

    //    //write out the subject
    //    string subject = mail.Subject;

    //    if (e.Cancelled)
    //    {
    //        Console.WriteLine("Send canceled for mail with subject [{0}].", subject);
    //    }
    //    if (e.Error != null)
    //    {
    //        Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
    //    }
    //    else
    //    {
    //        Console.WriteLine("Message [{0}] sent.", subject);
    //    }
    //}

}
