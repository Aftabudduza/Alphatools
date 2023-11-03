using System;
using System.Web.UI;
using AlphatoolServices.BO;
using AlphatoolServices.DA;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class pages_ProductRegistration : Page
{
    string PageTitle = "";
    string PageName = "";
    string errStr = "";
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
            ddlModel.Items.Clear();
            ddlModel.AppendDataBoundItems = true;
            ddlModel.Items.Add(new ListItem("--Select All--", "-1"));
            DataTable dtModel = new DataTable();
            dtModel = WebUtility.GetRows(" select ProductModel from  MProductRegModel  where CurrentYN = 1  order by ProductModel asc ");
           
            if (dtModel != null && dtModel.Rows.Count > 0)
            {
                foreach (DataRow dr in dtModel.Rows)
                {
                    ddlModel.Items.Add(new ListItem(dr["ProductModel"].ToString(), dr["ProductModel"].ToString()));
                }
            }

            ddlModel.DataBind();
            ddlModel.SelectedValue = "-1";
        }
        catch (Exception ex)
        {

        }

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
            if (ddlModel.SelectedValue == "-1")
            {
                errStr += "Please Select Model" + Environment.NewLine;
            }
            if (txtSerial.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Serial No." + Environment.NewLine;
            }
            if (txtCompanyName.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Company Name" + Environment.NewLine;
            }
            if (txtFirstName.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter First Name" + Environment.NewLine;
            }
            if (txtLastName.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Last Name" + Environment.NewLine;
            }
            if (txtAddress1.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Address" + Environment.NewLine;
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
            if (txtCountry.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Country" + Environment.NewLine;
            }
            if (txtTelephone.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Telephone" + Environment.NewLine;
            }
            if (txtEmail.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Email" + Environment.NewLine;
            }            
           
            if (txtPurchaseDate.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Purchase Date" + Environment.NewLine;
            }
            else
            {
                if (!IsDate(txtPurchaseDate.Text.ToString().Trim()))
                {
                    errStr += "Invalid Purchase Date" + Environment.NewLine;
                }
            }

            if (txtDealer.Text.ToString().Length <= 0)
            {
                errStr += "Please Enter Dealer" + Environment.NewLine;
            }
            //if (txtUsed.Text.ToString().Length <= 0)
            //{
            //    errStr += "Please Enter the tool be used for" + Environment.NewLine;
            //}
            //if (txtIndustry.Text.ToString().Length <= 0)
            //{
            //    errStr += "Please Enter Industry Name" + Environment.NewLine;
            //}
          
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
        ddlModel.SelectedValue  = "-1";
        txtSerial.Text = "";
        txtCompanyName.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        state.SelectedValue = "-1";
        txtZipCode.Text = "";
        txtCountry.Text = "";
        txtTelephone.Text = "";
        txtEmail.Text = "";
        txtPurchaseDate.Text = "";
        txtDealer.Text = "";
        txtUsed.Text = "";
        txtIndustry.Text = "";
    }
    private ProductRegistration SetData(ProductRegistration obj)
    {
        try
        {
            obj.ModelNo = ddlModel.SelectedValue;
            obj.SerialNo = txtSerial.Text.ToString().Trim();
            obj.CompanyName = txtCompanyName.Text.ToString().Trim();
            obj.FirstName = txtFirstName.Text.ToString().Trim();
            obj.LastName = txtLastName.Text.ToString().Trim();
            obj.Address1 = txtAddress1.Text.ToString().Trim();
            obj.Address2 = txtAddress2.Text.ToString().Trim();
            obj.City = txtCity.Text.ToString().Trim();
            obj.State = state.SelectedValue;
            obj.Postal = txtZipCode.Text.ToString().Trim();
            obj.Country = txtCountry.Text.ToString().Trim();
            obj.Telephone = txtTelephone.Text.ToString().Trim();
            obj.Email = txtEmail.Text.ToString().Trim();
            if (txtPurchaseDate.Text.ToString().Trim().Length > 0 && IsDate(txtPurchaseDate.Text.ToString().Trim()))
            {
                obj.PurchaseDate = Convert.ToDateTime(txtPurchaseDate.Text.ToString());
            }
            else
            {
                obj.PurchaseDate = DateTime.Now; 
            }
            
            obj.Dealer = txtDealer.Text.ToString().Trim();
            obj.Purpose = txtUsed.Text.ToString().Trim();
            obj.Industry = txtIndustry.Text.ToString().Trim();
            obj.CurDate = DateTime.Now; 
        }
        catch (Exception ex)
        { 
        }

        return obj;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            errStr = Validate_Control();
            if (errStr.Length <= 0)
            {
                ProductRegistration obj = new ProductRegistration();
                obj = SetData(obj);
                int nId = 0;
                DataTable dtProducts = new DataTable();
                dtProducts = WebUtility.GetRows("SELECT TOP 1 * FROM ProductRegistration pr ORDER BY pr.PRid DESC ");
               
                if (dtProducts != null && dtProducts.Rows.Count > 0)
                {
                    if (dtProducts.Rows[0][0] != null && dtProducts.Rows[0][0] != string.Empty)
                    {
                        nId = Convert.ToInt32(dtProducts.Rows[0][0].ToString()) + 1;
                    }
                }

                obj.PRid = nId;
                if (new ProductRegistrationDa().Insert(obj))
                {
                    ClearControls();
                    WebUtility.DisplayMsg("Product saved successfully!", this);
                }
                else
                {
                    WebUtility.DisplayMsg("Product not saved!", this);
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
}
