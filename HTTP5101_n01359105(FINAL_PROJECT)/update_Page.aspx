<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="update_Page.aspx.cs" Inherits="HTTP5101_n01359105_FINAL_PROJECT_.update_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="update_element" runat="server">
       
        <h2>Updating HTML Tags</h2>
        
        <div>
            <label>HTML Tag Title</label>
            <asp:TextBox runat="server" ID="html_tag"></asp:TextBox>
        </div>
        <div>
            <label>HTML Tag Description</label>
            <asp:TextBox runat="server" ID="html_body"></asp:TextBox>
        </div>

       <asp:Button Text="Update Page" OnClick="Update_Page" runat="server" />
    </div>
</asp:Content>
