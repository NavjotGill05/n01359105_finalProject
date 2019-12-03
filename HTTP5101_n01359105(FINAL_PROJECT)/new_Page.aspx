<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="new_Page.aspx.cs" Inherits="HTTP5101_n01359105_FINAL_PROJECT_.new_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>New HTML Tag</h2>
    <div class="formrow">
        <label>HTML Tag Title</label>
        <asp:TextBox runat="server" ID="html_title"></asp:TextBox>
    </div>
    <div class="formrow">
        <label>HTML Tag Description</label>
        <asp:TextBox runat="server" ID="html_body"></asp:TextBox>
    </div>

    <asp:Button OnClick="Add_Page" Text="Add Page" runat="server" />
</asp:Content>
