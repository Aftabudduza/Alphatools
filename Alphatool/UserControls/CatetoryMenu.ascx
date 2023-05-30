<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CatetoryMenu.ascx.cs" Inherits="UserControls.CatetoryMenu" %>

<% if (Session["categoryid"] != null)
   { %>
<div class="categoryboxn2 categoryboxn3">
    <img class="imgMb" src="https://www.alpha-tools.com/Images/1stcategory-sample_Final2.png">
</div>
<% }%>
<%else
   { %>
<div class="categoryboxn categoryboxn3">
    <img class="imgMb" src="https://www.alpha-tools.com/Images/1stcategory-sample_Final.png">
</div>
<% } %>

<ul id="CategoryMenu" class="nav navbar-nav navbar-left category-nav" runat="server">
</ul>

