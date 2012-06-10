<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_comment_see.aspx.cs" Inherits="ShowShop.Web.admin.product.product_comment_see" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
 <link rel="stylesheet" href="../style/validator.css" type="text/css" />
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
商品点评详细
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/admin/product/product_comment_list.aspx" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0" style="line-height:26px;">
<tr>
   <td class="form_table_input_info">标题：</td>
   <td><asp:Literal ID="litName" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">评论时间：</td>
  <td><asp:Literal ID="litTime" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">商品标签：</td>
  <td><asp:Literal ID="litLable" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">内容：</td>
  <td><asp:Literal ID="litContent" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">反对数：</td>
  <td><asp:Literal ID="litAgainst" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">支持数：</td>
  <td><asp:Literal ID="litSupNum" runat="server"></asp:Literal></td>
</tr>
<tr>
  <td class="form_table_input_info">鲜花数：</td>
  <td><asp:Literal ID="litFlower" runat="server"></asp:Literal></td>
</tr>
</table>
</asp:Content>