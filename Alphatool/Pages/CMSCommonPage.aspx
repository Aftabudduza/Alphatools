<%@ Page Language="C#" MasterPageFile="~/MasterPages/Home.master" CodeFile="CMSCommonPage.aspx.cs" Inherits="pages_CMSCommonPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server" ID="metaTags" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol id="Breadcrumb" class="breadcrumb" runat="server">
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
        <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title">
                                <h3 id="PageH3" runat="server"></h3>
                            </span>
                        </div>
                        <div class="panel-body">
                            <span runat="server" id="CMSContent"></span>
                        </div>

                    </div>
                </div>
            </div>
    </section>
   
</asp:Content>


