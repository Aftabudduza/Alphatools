<%@ Page Title="Alpha Professional Tools® :: Moisture Calculator" Language="C#" MasterPageFile="~/MasterPages/Product.master" AutoEventWireup="true" CodeFile="MoistureCalculator.aspx.cs" Inherits="pages_MoistureCalculator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <asp:PlaceHolder runat="server" ID="metaTags" />
     <style type="text/css">
        .control-group {
            float: left;
            width: 100%;
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
    <link href="../Scripts/jquery.datetimepicker.css" rel="stylesheet" />
    <style type="text/css">
        .input-validation-error {
            border: 1px solid #ff0000;
            background-color: #ffeeee;
        }

        .field-validation-error {
            color: #ff0000;
        }      
    </style>
    <style type='text/css'>      
        #calendar {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
    </style>
    <style type="text/css">
        .custom-date-style {
            background-color: red !important;
        }

        .input {
        }

        .input-wide {
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-intro">
        <ol class="breadcrumb">
                <li><i class="fa fa-home pr-10"></i>
                    <a href="/Default.aspx">Home</a></li>
                <li class="active">Concrete Moisture Calculator</li>
            </ol>
    </div>
    <section class="main-container" style="margin-top: 0px;">
         <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span class="title"> <h3>Concrete Moisture Calculator</h3></span>
                        </div>
                        <div class="panel-body">
                              <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                               </asp:ToolkitScriptManager>
                            <p>
					            Contact Alpha Professional Tools&reg; headquarters, factory service centers or sales contacts with any questions or comments regarding the products for cutting, drilling, grinding, polishing and profiling many types of materials for professionals in the natural stone, engineered stone, porcelain, ceramic, glass and construction industries. 
					        </p>
                            <h3> 
                                <a href="../Files/MoistureCalcinstructions.pdf" target="_blank">  <font size="2" color="CMYK - 91-58-64-60">  Moisture Calculator Instruction Manual &amp; MSDS</font> </a>
                            </h3>
                            <h3> 
                                <a href="http://www.astm.org/Standards/F1869.htm" target="_blank">  <font size="2" color="CMYK - 91-58-64-60"> ASTM International Standards Information </font> </a>
                            </h3>
                            <h3> Concrete Moisture Emissions Calculator</h3>

                          
                            <fieldset style="width:95%; padding:10px;">   
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Job Name:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtJobName" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="control-group">
                                        <label class="control-label" for="input20">
                                          Test Number: 	 </label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTestNumber" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group clearfix" style="border: none;">
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                            Enter Begin Weight (grams):</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtStartWeight" CssClass="span6"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="Regex1" Style="float:left;"  ForeColor="Red" Display="Dynamic" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                             ErrorMessage="Please enter Begin Weight with valid integer or decimal number with 2 decimal places." ControlToValidate="txtStartWeight" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="input15">
                                           Enter End Weight (grams):</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtEndWeight"   CssClass="span6"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  Style="float:left;" ForeColor="Red" Display="Dynamic" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                             ErrorMessage="Please enter End Weight with valid integer or decimal number with 2 decimal places." ControlToValidate="txtEndWeight" />
                                        </div>
                                    </div>
                                </div>
                              
                               
                                <div class="control-group clearfix" style="border: none;">                                    
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                            Weight Gain (grams):</label>
                                        <div class="controls">
                                               <span id="spanWeight" runat="server"></span>                        
                                        </div>
                                    </div> 
                                   <div class="control-group">
                                        <label class="control-label" for="input20">
                                           (24 Hour Clock)</label>
                                        <div class="controls">
                                                                                                             
                                        </div>
                                    </div> 
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                           Start Date:</label>
                                        <div class="controls">
                                          <asp:TextBox runat="server" ID="txtStartDate"  CssClass="span6 datetimepicker_mask" Text=""></asp:TextBox>
                                        </div>
                                    </div> 
                                   
                                     <div class="control-group">
                                        <label class="control-label" for="input20">
                                           End Date:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtEndDate"  CssClass="span6 datetimepicker_mask"  runat="server"></asp:TextBox>                                           
                                                                  
                                        </div>
                                    </div>   
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                          </label>
                                        <div class="controls">
                                           <span id="spanDuration" runat="server"></span>                                                                  
                                        </div>
                                    </div>   
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                           Total Time (hours):</label>
                                        <div class="controls">                                           
                                           <span id="spanTime" runat="server"></span>                        
                                        </div>
                                    </div>  
                                    <div class="control-group">
                                        <label class="control-label" for="input20">
                                          Moisture Calculated:</label>
                                        <div class="controls">                                           
                                          <span id="spanResult" runat="server"></span>                         
                                        </div>
                                    </div> 
                                </div>                                
                            </fieldset>
                            <div class="form-actions">
                                <asp:Button ID="btnSubmit" Text="Calculate" runat="server" ValidationGroup="checkout" style="margin-left:20px;"  CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                            </div>
                        </div>               
                     </div>
                </div>
            </div>
    </section>
   
</asp:Content>


