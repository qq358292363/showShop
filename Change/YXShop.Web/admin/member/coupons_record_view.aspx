<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="coupons_record_view.aspx.cs" Inherits="ShowShop.Web.admin.member.coupons_record_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
会员<asp:Literal ID="lblType3" runat="server"></asp:Literal>明细
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server"> 
<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
  <caption>详细信息</caption>
  <tr>
      <td class="form_text_row">用户账号：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblUserId" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">录入人：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblNoteName" runat="server"></asp:Literal>&nbsp;</td>
  </tr>
                    
  <tr>
      <td class="form_text_row">扣除<asp:Literal ID="lblType1" runat="server"></asp:Literal>：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblticketCountOut" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">添加<asp:Literal ID="lblType2" runat="server"></asp:Literal>：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblticketCountIn" runat="server"></asp:Literal>&nbsp;</td>
 </tr>
                    
  <tr>
      <td class="form_text_row"> 备注：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblCausation" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">内部记录：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblBosomNote" runat="server"></asp:Literal>&nbsp;</td>
  </tr>                   
</table>
</asp:Content>
