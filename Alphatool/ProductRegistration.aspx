<%@ Page Title="Alpha Professional Tools® :: Product Registration" Language="C#" MasterPageFile="~/MasterPages/Product.master" AutoEventWireup="true" CodeFile="ProductRegistration.aspx.cs" Inherits="pages_ProductRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .control-group {
            float: left;
            width: 98%;
            padding: 5px 0;
        }

        label {
            float: left;
            width: 20%;
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
                <a href="Default.aspx">Home</a></li>
            <li class="active">Product Registration</li>
        </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
       <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>Product Registration</h3></span>
                        </div>
                        <div class="panel-body">
                             <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                            <div style="width:95%; padding:10px;">
                                 <div class="control-group clearfix" style="border: none;">
                                      <div class="control-group">
                                        <label for="input07" class="control-label">
                                            <span class="required">*</span>Model</label>
                                        <div class="controls">                                            
                                            <asp:DropDownList ID= "ddlModel" name ="state" CssClass="span6" runat="server">
                                                <asp:ListItem Value="-1">Select Model</asp:ListItem>
                                            </asp:DropDownList>                                          
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" ControlToValidate="ddlModel" InitialValue="-1" ErrorMessage="Please Select Model" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                     </div>
                                 <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Serial No.</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtSerial" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtSerial" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Company Name</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>First Name</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtFirstName" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span> Last Name</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtLastName" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                            <span class="required">*</span>Address</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtAddress1" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ControlToValidate="txtAddress1" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                            Address</label>
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
                                            <span class="required">*</span>Telephone</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTelephone" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" ControlToValidate="txtTelephone" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>                               
                                        </div>
                                    </div> 
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
                                            <span class="required">*</span>Purchase Date</label>
                                        <div class="controls">
                                             <asp:TextBox runat="server" ID="txtPurchaseDate" CssClass="span6" Text=""></asp:TextBox><img
                                        alt="" style=" float:left; margin-left: 5px; margin-top: 5px;" id="effectivedate" src="../Images/calender.jpg"
                                        width="20px" height="30px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtPurchaseDate" ValidationGroup="checkout"
                                        runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="effectivedate"
                                        TargetControlID="txtPurchaseDate">
                                    </asp:CalendarExtender>
                                    <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="txtPurchaseDate" ErrorMessage="Invalid Purchase Date" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2200" Display="Dynamic"></asp:RangeValidator>                             
                                        </div>
                                    </div> 
                                     <div class="control-group">
                                        <label class="control-label" for="input20">
                                            <span class="required">*</span>Dealer</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtDealer" CssClass="span6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" ControlToValidate="txtDealer" ValidationGroup="checkout"  
                                                runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>                               
                                        </div>
                                    </div>   
                                      <div class="control-group">
                                        <label class="control-label" for="input15">
                                           What will the tool be used for?</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtUsed" TextMode="MultiLine"  CssClass="span6"></asp:TextBox>

                                        </div>
                                    </div>
                                      <div class="control-group">
                                        <label class="control-label" for="input15">
                                            What is your industry?</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtIndustry" TextMode="MultiLine"  CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>                                           
                                </div>                                
                            </div> 
                        <div class="form-actions">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="checkout" style="margin-left:20%;" OnClick="btnSubmit_Click"  CssClass="btn btn-primary" />
                        </div>
                        </div>               
                     </div>
                </div>
            </div>
    </section>
</asp:Content>


