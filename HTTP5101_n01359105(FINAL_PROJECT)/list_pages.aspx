<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="list_pages.aspx.cs" Inherits="HTTP5101_n01359105_FINAL_PROJECT_.list_pages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>HTML Tags</h1>

    <a href="new_Page.aspx">New Page</a>

       <div class="List_Pages" runat="server">
        <div class="listitem">
            <div class="col">HTML_Tag_Id</div>
            <div class="col">HTML_Tag_Title</div>
            <div class="col_last">HTML_Tag_Description</div>
        </div>
        <div id="pages_result" runat="server">

        </div>
    </div>
</asp:Content>
