<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="Product_Property.aspx.cs" Inherits="ShowShop.Web.admin.product.Product_Property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">商品管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品属性列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<table border="0" cellspacing="1" cellpadding="1" width="100%">
    <tr>
        <td>
            <!--发布人类型-->
       
            属性名称：
            <asp:TextBox ID="txtName" runat="server" Width="100px" ></asp:TextBox>
            <asp:Button ID="bt_Search" runat="server" Text="查询" 
                onclick="bt_Search_Click"  />
      </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagesarch" runat="server">
<div id="Layer1" style="display:none;position:absolute;z-index:1;"></div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">
添加属性：<asp:TextBox ID="Pname" runat="server"></asp:TextBox><asp:Button ID="AddP" 
        runat="server" Text="添加" onclick="AddP_Click" />

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="pagebottom" runat="server">
</asp:Content>
