using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class pages_MoistureCalculator : Page
{
    string errStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
            loadSEOContent();
        }
    }
    private void loadSEOContent()
    {
        try
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "keywords";
            hm.Content = "buffing tools, buffing pads, drilling tools, cutting blades, cutting tools, cutting systems, cutting wheel, diamond tools, diamond saw blades, diamond polishing pads, grinding wheel, grinding tools industrial abrasives, pneumatic air tools, polishers, polishing pads, polishing tools, polishing wheels, polishing discs, profiling tools, profiling wheels, router bits, scratch removal, stain removers, stone cutter, stone polishing, core bits, flush cutting blades, groove cutting blades, dry cutting blades, wet cutting blades, diamond cutting blades, marble cutting tools, diamond cutting tools, edge polishers, tile profiling wheels, diamond profiling wheels, rust stain removers, stone stain removers, stone polishing machinery, stone polishing tools, wet concrete core bits, dry core bits";
            this.metaTags.Controls.Add(hm);

            HtmlMeta hm2 = new HtmlMeta();
            hm2.Name = "description";
            hm2.Content = "Contact Alpha Professional Tools® headquarters, factory service center or sales contacts with any questions or comments regarding the cutting, drilling, grinding, polishing & profiling tools offered.";
            this.metaTags.Controls.Add(hm2);
        }
        catch (Exception ex)
        {

        }
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
    public string Validate_Control()
    {
        try
        {
            
            if (txtStartDate.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Start Date" + Environment.NewLine;
            }
            else
            {
                if (!IsDate(txtStartDate.Text.ToString().Trim()))
                {
                    errStr += "Invalid Start Date" + Environment.NewLine;
                }
            }
            if (txtEndDate.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter End Date" + Environment.NewLine;
            }
            else
            {
                if (!IsDate(txtEndDate.Text.ToString().Trim()))
                {
                    errStr += "Invalid End Date" + Environment.NewLine;
                }
            }
        }
        catch (Exception ex)
        {
        }

        return errStr;
    }
    public void CalculateMoisture()
    {
        try
        {
            decimal dStartWeight = 0;
            decimal dEndWeight = 0;
            decimal Weightdifference = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            decimal nTotalHours = 0;
           
            if (txtStartWeight.Text.ToString().Trim().Length > 0)
            {
                dStartWeight = Convert.ToDecimal(txtStartWeight.Text.ToString().Trim());
            }

            if (txtEndWeight.Text.ToString().Trim().Length > 0)
            {
                dEndWeight = Convert.ToDecimal(txtEndWeight.Text.ToString().Trim());
            }

            Weightdifference = dEndWeight - dStartWeight;
            spanWeight.InnerText = Weightdifference.ToString();

            startDate = Convert.ToDateTime(txtStartDate.Text.ToString().Trim());
            endDate = Convert.ToDateTime(txtEndDate.Text.ToString().Trim());

            TimeSpan TimeDifference = endDate - startDate;
            string formatted = string.Format(
                                   CultureInfo.CurrentCulture,
                                   "Duration is {0} days, {1} hours and {2} minutes.",
                                   TimeDifference.Days,
                                   TimeDifference.Hours,
                                   TimeDifference.Minutes);

            spanDuration.InnerText = formatted;

            nTotalHours = Convert.ToDecimal(TimeDifference.Minutes)/60;
            nTotalHours = Convert.ToDecimal(TimeDifference.Days * 24 + TimeDifference.Hours) + Convert.ToDecimal(TimeDifference.Minutes) / 60;

            spanTime.InnerText = nTotalHours.ToString("###.##");

            decimal nMoisture = 120 * Weightdifference / nTotalHours;
            spanResult.InnerText = nMoisture.ToString("###.##");
        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            errStr = Validate_Control();

            if (errStr.Length <= 0)
            {
                CalculateMoisture();
            }
            else {
                WebUtility.DisplayMsg(errStr, this);
            }
        }
        catch
        {
            WebUtility.DisplayMsg("Operation can not proceed. Please try again !!", this);
        }

    }
}
