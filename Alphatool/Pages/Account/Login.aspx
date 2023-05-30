<%@ Page Title="Alpha Professional Tools® :: Member's Login" Language="C#" MasterPageFile="~/MasterPages/LoginMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages.Account.pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link href="../../Content/LoginPageContent/assets/css/login.css" rel="stylesheet" />
    <style type="text/css">
        #ctl00_Body_formdiv
        {
            margin: 0 0 18px !important;  
        }
        .spanstyleforlogin
        {
            clear: both;
            float: right;
            font-size: 10px;
            font-weight: bold;
            margin-right: 16px;
            margin-top: 4px;
        }
         .spanstyleforlogincreate
        {
            clear: both;
            float: right;
            font-size: 10px;
            font-weight: bold;
            margin-right: 20px;
            margin-top: 4px;
            margin-bottom:15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="container">
        <div id="log-header">
            <img alt="AlphaTool logo" src="../../Content/AlphaToolContent/images/logo_red.png" />
            <p style="color: #f15d2f;">Alpha Professional Tools
            </p>
        </div>
        <div id="login-wrap">
            <div id="login-buttons">
                <%-- <a href="AddUser.aspx">Click here</a> to register to use our system   --%>
            </div>
            <div id="login-inner" class="login-inset">
                <div id="login-circle">
                    <section class="login-inner-form" data-angle="0" id="login-form">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                        <h1>Existing User Please Login Below.</h1>
                        <form id="form1" runat="server" class="form-vertical">
                            <div class="control-group-merged">
                                <div class="control-group">
                                    <asp:TextBox ID="txtUserId" placeholder="Email Address" runat="server" CssClass="big required input-username"></asp:TextBox>
                                </div>
                                <div class="control-group">
                                    <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" runat="server" CssClass="big required input-password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-actions">
                                <asp:Button ID="btnLogin" Style="background: #e84c3d; border: 0 none;" OnClick="btnLogin_Click" runat="server" Text="Login" CssClass="btn btn-success btn-block btn-large" />
                            </div>
                            <%--<div>
                                <span class="spanstyleforlogin"><a href="ForgetPassword.aspx">Did you forget your Password?</a></span>
                                <span class="spanstyleforlogincreate"><a href="CreateNewAccount.aspx">Create an account</a></span>
                            </div>--%>
                        </form>
                    </section>                   

                </div>
            </div>

        </div>
    </div>
</asp:Content>
