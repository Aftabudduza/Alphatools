using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

public partial class CMS_MaintainCMS : System.Web.UI.Page
{
    String sStylePrefix = "<div style='font-size: 11px;font-weight: normal !important;'>";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserObject"] != null))
        {
            Members objUser = new Members();
            objUser = (Members)Session["UserObject"];
            if (objUser != null)
            {
                if (!IsPostBack)
                {

                    fill_ddlVersion(1);
                    fill_TreeView();
                    Session["CreatedDate"] = null;
                    Session["PageName"] = null;
                    this.btnUpdate.Enabled = false;
                    this.btnUpdateNew.Enabled = false;
                    this.hidCurCMSPage.Value = "";

                    if (hidCurCMSPage.Value != null)
                    {
                        fillContent();
                    }
                    Get_Files();
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            CMSPageRef obj = new CMSPageRef();
            obj = SetData(obj);

            if (new CmsPageRefDa().Insert(obj))
            {
                WebUtility.DisplayMsg("Page saved successfully!", this);
                fill_TreeView();
            }
            else
            {
                WebUtility.DisplayMsg("Page not saved!", this);
            }
        }
        catch
        {

        }

    }

    private CMSPageRef SetData(CMSPageRef obj)
    {

        obj.CMSPage = txtNewCMSPage.Text.ToString();
        obj.CMSTitle = txtNewCMSTitle.Text.ToString();
        obj.CMSContent = "Please Add Content";
        obj.DateCreated = DateTime.UtcNow;
        obj.DateModified = DateTime.UtcNow;
        obj.WebsiteID = 1;
        obj.AffiliateID = 0;
        obj.CustomerID = 0;
        obj.CMSCategoryId = 0;
        obj.CMSVersion = 1;
        obj.Live = "Y";
        return obj;
    }

    #region "Tree View"
    private void fill_TreeView()
    {
        this.TreeView1.Nodes.Clear();
        //AddSystemCategories();       
        TreeNode lastNode = new TreeNode(sStylePrefix + "CMS Pages" + "</div>", 0.ToString(), "icons/materials.png");
        GeneratePageNodes(lastNode, 0);
        lastNode.Expanded = true;
        this.TreeView1.Nodes.Add(lastNode);
        this.TreeView1.NodeStyle.CssClass = "menulink";
    }
    private void GeneratePageNodes(TreeNode oNode, int iId)
    {
        try
        {
            List<CMSPageRef> listCMSPageRef = new CmsPageRefDa().GeneratePageNodes(iId);
            foreach (CMSPageRef itm in listCMSPageRef)
            {
                TreeNode pageNode = new TreeNode(sStylePrefix + itm.CMSTitle + "</div>", itm.CMSPage, "icons/notviewed.gif");
                oNode.ChildNodes.Add(pageNode);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void AddSystemCategories()
    {
        TreeNode oNode = new TreeNode();
        oNode = CreateSystemCatNode("Default Site Pages");
        oNode.ChildNodes.Add(CreateSystemNode("About Us Page", "AboutusMessage"));
        oNode.ChildNodes.Add(CreateSystemNode("Home Page", "HomePageMessage"));
        oNode.ChildNodes.Add(CreateSystemNode("Contact Page", "ContactMessage"));
        oNode.ChildNodes.Add(CreateSystemNode("Terms and Conditions Page", "TermsMessage"));
        oNode.ChildNodes.Add(CreateSystemNode("FAQ Page", "FAQMessage"));
        oNode.Expanded = false;
        this.TreeView1.Nodes.Add(oNode);

    }
    private TreeNode CreateSystemCatNode(string sText)
    {

        TreeNode oNode = new TreeNode(sStylePrefix + sText + "</div>", sText, "icons/materials.png");
        oNode.Expanded = true;
        return oNode;
    }
    private TreeNode CreateSystemNode(string sText, string sVal)
    {
        TreeNode pageNode = new TreeNode(sStylePrefix + sText + "</div>", sVal, "icons/notviewed.gif");
        pageNode.ToolTip = sText;
        return pageNode;
    }

    #endregion

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            TreeNode objNode = TreeView1.SelectedNode;
            if (objNode.Depth == 1)
            {
                if (objNode.ToolTip.ToString() == "")
                {
                    GetDisplayPage(objNode.Value);

                }
                else
                {
                    GetDisplayPageWebsite(objNode.Value, objNode.ToolTip);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void GetDisplayPageWebsite(String sCMSPage, String sCMSTitle)
    {
        try
        {


        }
        catch
        {

        }

    }
    private void GetDisplayPage(String sCMSPage)
    {
        Session["PageName"] = sCMSPage.ToString();
        try
        {
            List<CMSPageRef> listCMSPageRef = new CmsPageRefDa().EditCmsPage(sCMSPage);
            this.btnUpdate.Enabled = false;
            this.btnUpdateNew.Enabled = false;
            this.txtCMSTitle.Enabled = true;
            this.ddlVersion.Enabled = true;
            this.btnSetLive.Enabled = true;
            this.btnNewVersion.Enabled = true;
            this.txtPageURL.Enabled = true;
            if (listCMSPageRef != null)
            {
                DisplayPage(listCMSPageRef);
                this.btnUpdate.Enabled = true;
                this.btnUpdateNew.Enabled = true;
            }
            else
            {

                WebUtility.DisplayMsg("Error retrieving page info.", this);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void DisplayPage(List<CMSPageRef> CMSPageContains)
    {
        try
        {
            this.txtCMSTitle.Text = CMSPageContains[0].CMSTitle;
            String sDetails = "<table width='100%'><tr><td><b>Developer Ref:</b></td><td>" + CMSPageContains[0].CMSPage + "</td></tr>";
            sDetails += "<tr><td><b>Date Created:</b> </td><td>" + CMSPageContains[0].DateCreated + "</td></tr>";
            sDetails += "<tr><td><b>Last Modified:</b></td><td>" + CMSPageContains[0].DateModified + "</td></tr></table>";
            Session["CreatedDate"] = CMSPageContains[0].DateCreated;
            Session["Live"] = CMSPageContains[0].Live;
            this.lblDetails.Text = sDetails;
            this.txtContent.Text = HttpUtility.HtmlDecode(CMSPageContains[0].CMSContent);
            ddlVersion.Items.Clear();
            List<CMSPageRef> TotalCMSPageRef = new CmsPageRefDa().TotalCmsPage(CMSPageContains[0].CMSPage.ToString());
            for (int x = 0; x < TotalCMSPageRef.Count; x++)
            {
                var item = new ListItem
                {
                    Text = TotalCMSPageRef[x].CMSVersion.ToString(),
                    Value = TotalCMSPageRef[x].CMSVersion.ToString()
                };

                this.ddlVersion.Items.Add((item));


            }
            this.ddlVersion.SelectedValue = CMSPageContains[0].CMSVersion.ToString();
            int iMAXVERSION = GetMaxVersion(CMSPageContains[0].CMSPage);
            //fill_ddlVersion(iMAXVERSION);

            if (CMSPageContains[0].Live == "Y")
            {
                this.lblLiveCMS.Text = "LIVE IN SYSTEM";
                this.btnSetLive.Enabled = false;
            }

            else
            {
                this.lblLiveCMS.Text = "";
                this.btnSetLive.Enabled = true;
            }


            if (CMSPageContains[0].IsFooter.ToString() != null)
            {
                if (Convert.ToInt32(CMSPageContains[0].IsFooter) == 1)
                {
                    this.rdoIsFooter.SelectedValue = 1.ToString();
                }
                else
                {
                    this.rdoIsFooter.SelectedValue = 0.ToString();
                }

            }
            else
            {
                this.rdoIsFooter.SelectedValue = 0.ToString();
            }



            if (CMSPageContains[0].IsFooter.ToString() != null)
            {
                if (Convert.ToInt32(CMSPageContains[0].IsLeftMenu) == 1)
                {
                    this.rdoIsLeftSideBar.SelectedValue = 1.ToString();
                }
                else
                {
                    this.rdoIsLeftSideBar.SelectedValue = 0.ToString();
                }

            }
            else
            {
                this.rdoIsLeftSideBar.SelectedValue = 0.ToString();
            }


            if (CMSPageContains[0].IsFooter.ToString() != null)
            {
                if (Convert.ToInt32(CMSPageContains[0].LeftMenuOrder) > 0)
                {
                    this.txtLeftMenuOrder.Text = CMSPageContains[0].LeftMenuOrder.ToString();
                }
                else
                {
                    this.txtLeftMenuOrder.Text = 1.ToString();
                }

            }
            else
            {
                this.txtLeftMenuOrder.Text = 1.ToString();
            }


            if (CMSPageContains[0].IsFooter.ToString() != null)
            {
                if (Convert.ToInt32(CMSPageContains[0].FooterMenuOrder) > 0)
                {
                    this.txtFooterMenuOrder.Text = CMSPageContains[0].FooterMenuOrder.ToString();
                }
                else
                {
                    this.txtFooterMenuOrder.Text = 1.ToString();
                }

            }
            else
            {
                this.txtFooterMenuOrder.Text = 1.ToString();
            }

            this.txtPageURL.Text = CMSPageContains[0].PageURL;
            String sRefURL = "";
            this.litPage.Text = "";
            if (CMSPageContains[0].PageURL != null)
            {
                sRefURL = CMSPageContains[0].PageURL;
                if (CMSPageContains[0].Live != "Y")
                {
                    sRefURL += "?version=" + CMSPageContains[0].CMSVersion;
                }
            }

            String sUrl = "";
            sUrl = "../forms/EditorPopUp.aspx?table=CMSPAGEREF&id=" + CMSPageContains[0].CMSPage + "&idname=CMSPAGE&field=CMSCONTENT&version=" + CMSPageContains[0].CMSVersion;

            this.hidCurCMSPage.Value = CMSPageContains[0].CMSPage;
            metaTitle.Text = CMSPageContains[0].MetaTitle;
            metaKeywords.Text = CMSPageContains[0].MetaKeywords;
            metaDescription.Text = CMSPageContains[0].MetaDescription;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private int GetMaxVersion(string sPage)
    {
        int nCnt = 0;
        try
        {

            if (sPage != null)
            {
                nCnt = new CmsPageRefDa().GetMaxVersion(sPage);
                if (nCnt <= 0)
                {
                    nCnt = 1;
                }

            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return nCnt;
    }

    private void fill_ddlVersion(int VersionMax)
    {
        this.ddlVersion.Items.Clear();
        for (int x = 1; x <= VersionMax; x++)
        {
            var item = new ListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            };

            this.ddlVersion.Items.Add((item));
        }
    }

    protected void btnSetLive_Click(object sender, EventArgs e)
    {
        try
        {
            String sPageRef = this.hidCurCMSPage.Value;
            List<CMSPageRef> listCMSPageVersion = new CmsPageRefDa().GetSameVersionList_ByPageTitle(this.hidCurCMSPage.Value);

            foreach (CMSPageRef objVersionUpdate in listCMSPageVersion)
            {
                objVersionUpdate.Live = "N";
                new CmsPageRefDa().Update(objVersionUpdate);
            }


            CMSPageRef objVersionUpdate_2 = new CMSPageRef();
            objVersionUpdate_2 = SetData_Page(objVersionUpdate_2);
            objVersionUpdate_2.Live = "Y";
            objVersionUpdate_2.CMSPage = sPageRef.Replace("'", "''");
            objVersionUpdate_2.CMSVersion = Convert.ToInt32(this.ddlVersion.SelectedValue);
            if (new CmsPageRefDa().Update(objVersionUpdate_2))
            {
                this.GetDisplayPageVersion(sPageRef, Convert.ToInt32(this.ddlVersion.SelectedValue));
                WebUtility.DisplayMsg("Page set to live.", this);

            }
            else
            {
                WebUtility.DisplayMsg("Error setting page live.", this);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetDisplayPageVersion(String sCMSPage, int iVersion)
    {
        try
        {
            List<CMSPageRef> listCMSPageVersion = new CmsPageRefDa().DisplayPageVersion(sCMSPage, iVersion);
            this.btnUpdate.Enabled = false;
            this.btnUpdateNew.Enabled = false;
            this.txtCMSTitle.Enabled = true;
            if (listCMSPageVersion != null)
            {
                DisplayPage(listCMSPageVersion);
                this.btnUpdate.Enabled = true;
                this.btnUpdateNew.Enabled = true;
            }
            else
            {
                WebUtility.DisplayMsg("Error retrieving page info.", this);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnNewVersionNew_Click(object sender, EventArgs e)
    {
        btnNewVersion_Click(sender, e);
    }

    protected void btnUpdateNew_Click(object sender, EventArgs e)
    {
        btnUpdate_Click(sender, e);
    }

    protected void btnDeleteNew_Click(object sender, EventArgs e)
    {
        btnDelete_Click(sender, e);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCMSTitle.Text.ToString() == "")
            {
                WebUtility.DisplayMsg("You must enter a page title", this);

            }
            try
            {
                CMSPageRef obj = new CMSPageRef();
                obj = SetData_Page(obj);

                obj.CMSVersion = Convert.ToInt32(this.ddlVersion.SelectedValue.ToString());
                if (new CmsPageRefDa().Update(obj))
                {
                    Session["CreatedDate"] = "";
                    WebUtility.DisplayMsg("Page Information Updated Successfully.", this);
                    //ClearControll();
                    fill_TreeView();

                    foreach (TreeNode objNode in TreeView1.Nodes)
                    {
                        foreach (TreeNode innerNode in objNode.ChildNodes)
                        {
                            if (innerNode.Value == this.hidCurCMSPage.Value)
                            {
                                innerNode.Selected = true;
                                break;
                            }
                        }
                    }

                }
                else
                {
                    WebUtility.DisplayMsg("Error Updating Page Information.", this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    private CMSPageRef SetData_Page(CMSPageRef obj)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtCMSTitle.Text.ToString().Trim()) && txtCMSTitle.Text.ToString().Trim() != "")
            {
                obj.CMSTitle = txtCMSTitle.Text.ToString().Trim();
            }
            else
            {
                obj.CMSTitle = "";
            }

            if (!string.IsNullOrEmpty(metaTitle.Text.ToString().Trim()) && metaTitle.Text.ToString().Trim() != "")
            {
                obj.MetaTitle = metaTitle.Text.ToString().Trim();
            }
            else
            {
                obj.MetaTitle = "";
            }


            if (!string.IsNullOrEmpty(metaKeywords.Text.ToString().Trim()) && metaKeywords.Text.ToString().Trim() != "")
            {
                obj.MetaKeywords = metaKeywords.Text.ToString().Trim();
            }
            else
            {
                obj.MetaKeywords = "";
            }

            if (!string.IsNullOrEmpty(metaDescription.Text.ToString().Trim()) && metaDescription.Text.ToString().Trim() != "")
            {
                obj.MetaDescription = metaDescription.Text.ToString().Trim();
            }
            else
            {
                obj.MetaDescription = "";
            }

            if (!string.IsNullOrEmpty(metaTag.Text.ToString().Trim()) && metaTag.Text.ToString().Trim() != "")
            {
                obj.MetaTag = metaTag.Text.ToString().Trim();
            }
            else
            {
                obj.MetaTag = "";
            }

            if (!string.IsNullOrEmpty(txtPageURL.Text.ToString().Trim()) && txtPageURL.Text.ToString().Trim() != "")
            {
                obj.PageURL = txtPageURL.Text.ToString().Trim();
            }
            else
            {
                obj.PageURL = "";
            }

            if (!string.IsNullOrEmpty(txtContent.Text.ToString().Trim()) && txtContent.Text.ToString().Trim() != "")
            {
                obj.CMSContent = txtContent.Text.ToString().Trim();
            }
            else
            {
                obj.CMSContent = "";
            }

            obj.CMSPage = this.hidCurCMSPage.Value.Replace("'", "''");

            if (rdoIsFooter.SelectedIndex != -1)
            {
                if (rdoIsFooter.Items[0].Selected == true)
                {
                    obj.IsFooter = 1;
                }
                else
                {
                    obj.IsFooter = 0;
                }
            }

            if (rdoIsLeftSideBar.SelectedIndex != -1)
            {
                if (rdoIsLeftSideBar.Items[0].Selected == true)
                {
                    obj.IsLeftMenu = 1;
                }
                else
                {
                    obj.IsLeftMenu = 0;
                }
            }


            if (txtLeftMenuOrder.Text.ToString().Trim() != "")
            {
                obj.LeftMenuOrder = Convert.ToInt32(txtLeftMenuOrder.Text.ToString());

            }
            else
            {
                obj.LeftMenuOrder = 0;
            }

            if (txtFooterMenuOrder.Text.ToString().Trim() != "")
            {
                obj.FooterMenuOrder = Convert.ToInt32(txtFooterMenuOrder.Text.ToString());

            }
            else
            {
                obj.FooterMenuOrder = 0;
            }
            obj.WebsiteID = 1;
            obj.AffiliateID = 0;
            obj.CMSCategoryId = 0;
            obj.CustomerID = 0;
            if (Session["Live"] != null)
            {
                if (Session["Live"].ToString() == "Y")
                {
                    obj.Live = Session["Live"].ToString();
                }
                else
                {
                    obj.Live = "N";
                }
            }
            else
            {
                obj.Live = "N";
            }

            obj.DateModified = DateTime.UtcNow;
            if (Session["CreatedDate"] != null)
            {
                obj.DateCreated = Convert.ToDateTime(Session["CreatedDate"].ToString());
            }
            else
            {
                obj.DateCreated = DateTime.UtcNow;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }
    protected void btnNewVersion_Click(object sender, EventArgs e)
    {
        try
        {
            String sPageRef = this.hidCurCMSPage.Value;
            int iMaxVersion = this.GetMaxVersion(sPageRef);
            iMaxVersion += 1;
            CMSPageRef objNewVersion = new CMSPageRef();
            objNewVersion = SetData_Page(objNewVersion);
            objNewVersion.CMSVersion = iMaxVersion;
            objNewVersion.Live = "N";
            if (objNewVersion != null)
            {
                if (new CmsPageRefDa().Insert(objNewVersion))
                {
                    this.GetDisplayPageVersion(sPageRef, iMaxVersion);
                    WebUtility.DisplayMsg("New version added successfully.", this);
                }
                else
                {
                    WebUtility.DisplayMsg("Error adding new version.", this);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.hidCurCMSPage.Value != "" && Convert.ToInt32(this.ddlVersion.SelectedValue) > 0)
            {
                if (new CmsPageRefDa().DeleteById(this.hidCurCMSPage.Value, Convert.ToInt32(this.ddlVersion.SelectedValue)))
                {
                    ClearControll();
                    fill_TreeView();
                    WebUtility.DisplayMsg("Deleted Sucessfully.", this);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void ddlVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDisplayPageVersion(this.hidCurCMSPage.Value, Convert.ToInt32(this.ddlVersion.SelectedValue));
    }

    private void fillContent()
    {
        try
        {
            List<CMSPageRef> listCMSPageVersion = new CmsPageRefDa().Fillcontaint(this.hidCurCMSPage.Value, Convert.ToInt32(this.ddlVersion.SelectedValue));
            foreach (CMSPageRef page in listCMSPageVersion)
            {
                String sDetails = "<table width='100%'><tr><td><b>Developer Ref:</b></td><td>" + page.CMSPage + "</td></tr>";
                sDetails += "<tr><td><b>Date Created:</b> </td><td>" + fixdate(page.DateCreated) + "</td></tr>";
                sDetails += "<tr><td><b>Last Modified:</b></td><td>" + fixdate(page.DateModified) + "</td></tr></table>";
                this.lblDetails.Text = sDetails;
                this.txtContent.Text = HttpUtility.HtmlDecode(page.CMSContent);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string fixdate(Object s)
    {
        if (s == DBNull.Value)
        {
            return "N/A";
        }
        try
        {
            s = ((DateTime)s).ToString("MM/dd/yyyy hh:mm tt");
        }
        catch
        {
            s = "N/A";
        }

        return s.ToString();
    }

    private void Get_Files()
    {
        try
        {
            string FilePath = Path.Combine(Request.PhysicalApplicationPath, "Images/CMS/");
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string[] files = Directory.GetFiles(FilePath);
            Array.Sort(files);
            string html = "";
            foreach (string filePath in files)
            {
                string fileExt = Path.GetExtension(filePath).ToLower();
                if (fileExt == ".jpg" | fileExt == ".jpeg" | fileExt == ".gif" | fileExt == ".png" | fileExt == ".bmp")
                {
                    html += "<img src='../Images/CMS/" + Path.GetFileName(filePath) + "'  style='float:left;margin:10px 0 0 10px;' alt='' Width='100px' Height='100px'>";
                }
            }

            ImageContainer.InnerHtml = html;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnupload_Click1(object sender, EventArgs e)
    {
        try
        {
            if (flImage.FileName != null)
            {
                string FilePath = Path.Combine(Request.PhysicalApplicationPath, "Images/CMS/");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                String File = Path.Combine(FilePath, flImage.FileName);
                string fileExt = Path.GetExtension(flImage.FileName).ToLower();
                if (fileExt == ".jpg" | fileExt == ".jpeg" | fileExt == ".gif" | fileExt == ".png" | fileExt == ".bmp")
                {
                    if (!System.IO.File.Exists(File))
                    {
                        flImage.SaveAs(File);
                        Get_Files();
                        WebUtility.DisplayMsg("File Upload Sucessfully.", this);
                    }
                    else
                    {
                        Get_Files();
                        WebUtility.DisplayMsg("File Exits.", this);
                    }
                    Session["fileName"] = flImage.FileName;
                }
            }
            else
            {
                WebUtility.DisplayMsg("Please select a file.", this);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ClearControll()
    {
        txtCMSTitle.Text = "";
        metaDescription.Text = "";
        metaKeywords.Text = "";
        metaTag.Text = "";
        txtContent.Text = "";
        metaTitle.Text = "";
    }
}
