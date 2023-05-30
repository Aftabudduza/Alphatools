<%@ Page Title="Alpha Professional Tools® :: Request Dealer Information" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="RequestADealerInfo.aspx.cs" Async="true" Inherits="pages_RequestADealerInfo" %>

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
                <li class="active">Request Dealer Information</li>
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
         <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>Request Dealer Information</h3></span>
                        </div>
                        <div class="panel-body">
                             <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                            <p>To locate an Authorized Alpha<sup>&reg;</sup> Dealer near you, please complete the following form and an Alpha<sup>&reg;</sup> representative will contact you. </p>

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
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                            <span class="required">*</span>Address Line 1</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtAddress1" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ControlToValidate="txtAddress1" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                            Address Line 2</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtAddress2"  CssClass="span6"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>City</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCity" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ControlToValidate="txtCity" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label for="input07" class="control-label">
                                            <span class="required">*</span>State</label>
                                        <div class="controls">                                            
                                            <asp:DropDownList ID= "state" name ="state" CssClass="span6" runat="server">
                                                 <asp:ListItem Value="-1">Select State</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic"  runat="server" ControlToValidate="state" InitialValue="-1" ErrorMessage="Please Select State" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Postal Code</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="txtZipCode" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input11">
                                            Country</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCountry" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
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
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Work Phone</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtWorkPhone" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" ControlToValidate="txtWorkPhone" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>                               
                                        </div>
                                    </div> 
                                   <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Home Phone</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtHomePhone" CssClass="span6"></asp:TextBox>                                                                     
                                        </div>
                                    </div> 
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Mobile Phone</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtMobile" CssClass="span6"></asp:TextBox>                            
                                        </div>
                                    </div> 
                                   
                                     <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Promotion Code</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtPromotionCode" CssClass="span6"></asp:TextBox>
                                                                  
                                        </div>
                                    </div>   
                                      <div class="control-group">
                                        <label class="control-label" for="input15">
                                           What is your profession?</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtProfession" TextMode="MultiLine"  CssClass="span6"></asp:TextBox>

                                        </div>
                                    </div>
                                      <div class="control-group">
                                        <label class="control-label" for="input15">
                                           How may we help you?</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtPurpose" TextMode="MultiLine"  CssClass="span6"></asp:TextBox>
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


