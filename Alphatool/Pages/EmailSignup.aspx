<%@ Page Title="Alpha Professional Tools® :: Request Dealer Information" Language="C#" MasterPageFile="~/MasterPages/Product.master" AutoEventWireup="true" CodeFile="EmailSignup.aspx.cs" Inherits="pages_EmailSignup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .control-group {
            float: left;
            width: 90%;
            padding: 5px 0;
        }

        label {
            float: left;
            width: 30%;
            font-weight: normal;
        }

        .span6 {
            float: left;
            width: 50%;
        }

        .controls {
            float: left;
            width: 60%;
        }

        .required {
            color: red;
        }
        @media screen and (min-width: 320px) and (max-width: 640px) {
            label {
                float: left;
                font-weight: normal;
                width: 100% !important;
            }

            .span6 {
                float: left;
                width: 88%;
            }

            .controls {
                float: left;
                width: 100% !important;
            }

            .btn {
                margin-left: 18% !important;
                min-width: 0;

            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
         <ol class="breadcrumb">
                <li><i class="fa fa-home pr-10"></i>
                    <a href="/Default.aspx">Home</a></li>
                <li class="active">Email Signup Information</li>
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
         <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>E-mail Signup Information</h3></span>
                        </div>   
                        <p>Register below to receive the latest company and product information!</p>                                            
                        <div class="panel-body">
                            
                            <div style="width:95%; padding:10px;">
                                <span class="required">*Indicates Required Data</span> <br />
                                <span class="required">Please be sure the information is complete before submitting the request.</span>                              
                       
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Name</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtName" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                     <div class="control-group">
                                        <label class="control-label" for="input20">
                                           <span class="required">*</span>  Company </label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="span6"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txtCompanyName" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                <%--</div>
                                <div class="control-group clearfix" style="border: none;">--%>
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Email</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtEmail" CssClass="span6"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator> 
                                           <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                                        runat="server" ErrorMessage="Invalid Email" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>                            
                                        </div>
                                    </div>                       
                                </div>  
                                                                 
                            </div> 
                        <div class="form-actions">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="checkout" style="margin-left:25%;" OnClick="btnSubmit_Click"  CssClass="btn btn-primary" />
                        </div>     
                                                
                        </div>  
                     </div>
                </div>
            </div>
    </section>
</asp:Content>


