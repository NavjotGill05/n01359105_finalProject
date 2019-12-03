<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="view_Page.aspx.cs" Inherits="HTTP5101_n01359105_FINAL_PROJECT_.view_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="viewnav">
        <ASP:Button OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" CssClass="right spaced" Text="Delete" runat="server"/>   
        <a class="right" href="update_Page.aspx?html_id=<%= Request.QueryString["html_id"] %>">Edit</a>
    </div>

    <div id="html_element" runat="server">
        HTML Tag: <span id="html_tag_title" runat="server"></span><br />
        Description: <span id="html_tag_desc" runat="server"></span><br />
    </div>

</asp:Content>
