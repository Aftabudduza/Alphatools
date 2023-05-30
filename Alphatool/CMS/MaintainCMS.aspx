<%@ Page Title="Maintain CMS" Language="C#" MasterPageFile="~/MasterPages/Admin.master" ValidateRequest="false"  Debug="true" CodeFile="MaintainCMS.aspx.cs" Inherits="CMS_MaintainCMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
    <script type="text/javascript">
        tinymce.init({
            mode: "textareas",
            editor_selector: "mceEditor",
            height: 500,
            theme: 'modern',
            external_plugins: { "nanospell": "/scripts/tinymce/nanospell/plugin.js" },
            nanospell_server: "asp.net",
            plugins: [
              'advlist autolink lists link image charmap print preview hr anchor pagebreak',
              'searchreplace wordcount visualblocks visualchars code fullscreen',
              'insertdatetime media nonbreaking save table contextmenu directionality',
              'emoticons template paste textcolor colorpicker textpattern imagetools'
            ],
            toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            toolbar2: 'print preview media | forecolor backcolor emoticons',
            image_advtab: true,
            templates: [
              { title: 'Test template 1', content: 'Test 1' },
              { title: 'Test template 2', content: 'Test 2' }
            ],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });
    </script>
    <style type="text/css">
        #TopArrow {
            background: none repeat scroll 0 0 #CCCCCC;
            bottom: 20px;
            color: #FF0000;
            float: right;
            font-weight: normal;
            padding: 3px;
            position: fixed;
            right: 20px;
            text-align: center;
            text-decoration: none;
            width: 40px;
            display: block;
        }

        a.menulink {
            font-size: 11px;
            font-weight: normal !important;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#TopArrow").click(function () {
                var elementClicked = $(this).attr("href");
                var destination = $(elementClicked).offset().top;
                $("html:not(:animated),body:not(:animated)").animate({ scrollTop: destination - 0 }, 700);
                return false;
            });
        });
    </script>

    <a id="Top"></a>

    <script type="text/javascript" language="javascript">
        window.onfocus = showfocus;

        function showfocus() {
            var objRef = document.getElementById('refreshPage');
            if (objRef != null) {
                if ((objRef.value * 1) > 0) {
                    objRef.value = 0;
                    window.document.forms[0].submit();
                }
            }
        }

        function setRefresh() {
            var objRef = document.getElementById('refreshPage');
            if (objRef != null) {
                objRef.value = 1;
            }
        }
    </script>

    <script type="text/javascript" language="javascript">

        function AddImageToText(sUrl) {
            //add the image to the text 
            var objImg = document.getElementById('hidAddImage');
            objImg.value = sUrl;
            //repost the form
            window.document.forms[0].submit();
        }

        function AddFileToText(sUrl) {
            //add the image to the text 
            var objImg = document.getElementById('hidAddFile');
            objImg.value = sUrl;
            //repost the form
            window.document.forms[0].submit();
        }

        function RefreshImages() {
            var objText = document.getElementById('hidRefreshImages');
            if (objText != null) {
                objText.value = 'Y';
                window.document.forms[0].submit();
            }
        }

        function RefreshFiles() {
            var objText = document.getElementById('hidRefreshFiles');
            if (objText != null) {
                objText.value = 'Y';
                window.document.forms[0].submit();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <input type="hidden" id="refreshPage" value="0" />
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-head-line">Maintain CMS Pages </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add New Page Info
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table cellpadding="4" cellspacing="0" class="table_valign table table-striped table-bordered table-hover">
                            <tr>
                                <td>Enter a new page:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNewCMSPage" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>Page Title:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNewCMSTitle" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-default" Text="Add Page" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add New Page Info
                </div>
                <div class="panel-body">
                    <div style="width: 100%;">

                        <div class="col-md-3" style="margin-top: 10px;">
                            <div style="border: 1px solid #C0C0C0; padding: 4px;">
                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                    <SelectedNodeStyle Font-Bold="True" />
                                    <Nodes>
                                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                                    </Nodes>
                                    <NodeStyle CssClass="menulink" />
                                </asp:TreeView>
                            </div>
                        </div>


                        <div class="col-md-9" style="margin-top: 10px;">

                            <div class="table-responsive">
                                <asp:HiddenField runat="server" ID="hidAddImage" />
                                <asp:HiddenField runat="server" ID="hidRefreshImages" />
                                <asp:HiddenField runat="server" ID="hidAddFile" />
                                <asp:HiddenField runat="server" ID="hidRefreshFiles" />
                                <table cellpadding="4" cellspacing="0" class="table_valign table table-striped table-bordered table-hover">
                                    <tr>
                                        <td>Page Title:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCMSTitle" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Version:
                                        </td>
                                        <td valign="middle">
                                            <span style="float: left;">
                                                <asp:DropDownList runat="server" ID="ddlVersion" Style="width: 100px !important" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlVersion_SelectedIndexChanged">
                                                </asp:DropDownList></span> <span style="float: left; margin-left: 10px; margin-top: 4px;">
                                                    <asp:Label runat="server" ID="lblLiveCMS">LIVE PAGE</asp:Label>
                                                    &nbsp;<asp:Button runat="server" ID="btnSetLive" Text="Make Live" OnClick="btnSetLive_Click" /></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Site Page URL:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPageURL" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Is Visible In Header Bar:
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoIsLeftSideBar" RepeatDirection="Horizontal" CssClass="radio radio2" runat="server">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Is Visible In Footer:
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoIsFooter" CssClass="radio radio2" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Header Menu Order:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtLeftMenuOrder" CssClass="form-control" MaxLength="100" Width="50px" Text="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Footer Menu Order:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtFooterMenuOrder" CssClass="form-control" MaxLength="250" Width="50px" Text="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>SEO Page Title:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="metaTitle" CssClass="form-control" MaxLength="250" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>SEO Page Description:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="metaDescription" TextMode="MultiLine" CssClass="form-control" MaxLength="1000"
                                                Width="300px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>SEO Page Keywords:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="metaKeywords" CssClass="form-control" MaxLength="500" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server" visible="false">
                                        <td>SEO Page Meta Tag:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="metaTag" CssClass="form-control" MaxLength="200" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Upoad Images: 
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="flImage" runat="server" />
                                            <asp:Button ID="btnupload" runat="server" CssClass="btn btn-default" Text="Upload" OnClick="btnupload_Click1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div style="overflow-y: scroll; max-height: 120px; overflow-x: hidden;" id="ImageContainer"
                                                runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-default" Text="Update Page" OnClick="btnUpdate_Click" />
                                            &nbsp;
                        <asp:Button runat="server" ID="btnNewVersion" CssClass="btn btn-default" ToolTip="Make a new version" Text="New Version" OnClick="btnNewVersion_Click" />
                                            &nbsp;
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-default" ToolTip="Delete" Text="Delete" OnClick="btnDelete_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Page Content:
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server">
                                        <td colspan="2">
                                            <asp:TextBox runat="server" ID="txtContent" Width="590" CssClass="form-control mceEditor" MaxLength="100"
                                                Height="400" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hidCurCMSPage" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblDetails" CssClass="noteText"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnUpdateNew" CssClass="btn btn-default" Text="Update Page" OnClick="btnUpdateNew_Click" />
                                            &nbsp;
                        <asp:Button runat="server" ID="btnNewVersionNew" CssClass="btn btn-default" ToolTip="Make a new version" Text="New Version" OnClick="btnNewVersionNew_Click" />
                                            &nbsp;
                        <asp:Button runat="server" ID="btnDeleteNew" CssClass="btn btn-default" ToolTip="Delete" Text="Delete" OnClick="btnDeleteNew_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div style="clear: both;">
    </div>
    <div>
        <asp:Literal runat="server" ID="litPage"></asp:Literal>
    </div>
</asp:Content>

