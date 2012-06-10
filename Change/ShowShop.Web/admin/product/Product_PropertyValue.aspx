<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="Product_PropertyValue.aspx.cs" Inherits="ShowShop.Web.admin.product.Product_PropertyValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">商品管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品属性值列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<span>属性名：</span><%=ViewState["name"] %>
<br />
属性值：<asp:TextBox ID="Pname" runat="server"></asp:TextBox><asp:Button ID="AddP" 
        runat="server" Text="添加属性值" onclick="AddP_Click" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagesarch" runat="server">
<div id="Layer1" style="display:none;position:absolute;z-index:1;"></div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="pagebottom" runat="server">
</asp:Content>
