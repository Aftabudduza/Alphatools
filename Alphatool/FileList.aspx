<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="FileList.aspx.cs" Inherits="FileList" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
   <%-- <% foreach (var dir in new DirectoryInfo("E:\\TEMP").GetDirectories()) { %>
        Directory: <%= dir.Name %><br />

        <% foreach (var file in dir.GetFiles()) { %>
            <%= file.Name %><br />
        <% } %>
        <br />
    <% } %>--%>
    <span id="spanFile" runat="server"></span>
</asp:Content>

