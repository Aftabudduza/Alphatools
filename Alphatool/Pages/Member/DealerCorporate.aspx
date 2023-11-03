<%@ Page Title="Member's Site - Alpha Professional Tools® :: Dealer-Corporate" Language="C#" MasterPageFile="~/MasterPages/Admin.master" AutoEventWireup="true" CodeFile="DealerCorporate.aspx.cs" Inherits="pages_DealerCorporate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <div class="container">
            <ol id="Breadcrumb" class="breadcrumb" runat="server">
                        <li><i class="fa fa-home pr-10"></i>
                            <a href="MemberDashboard.aspx">Home</a></li>
                        <li class="active">Dealer-Corporate</li>
                    </ol>
        </div>
    </div>
    <section class="main-container" style="margin-top: 0px;">
        <div class="container">
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
        </div>
    </section>
    
</asp:Content>


