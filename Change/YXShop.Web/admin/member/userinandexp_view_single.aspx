<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="userinandexp_view_single.aspx.cs" Inherits="ShowShop.Web.admin.member.userinandexp_view_single" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
汇款详细信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server"> 
<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
  <caption>详细信息</caption>
  <tr>
      <td class="form_text_row">到款时间：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblAdsumMoneyDate" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">会员账号：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblUserID" runat="server"></asp:Literal>&nbsp;</td>
  </tr>
                    
  <tr>
      <td class="form_text_row">用户名：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblUserName" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">交易方式：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblRemitMode" runat="server"></asp:Literal>&nbsp;</td>
 </tr>
                    
  <tr>
      <td class="form_text_row"> 收入金额：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblAdsumMoneyIn" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">支出金额：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblAdsumMoneyOut" runat="server"></asp:Literal>&nbsp;</td>
  </tr>
                    
  <tr>
      <td class="form_text_row">银行名称：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblRemitBank" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">状态：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblState" runat="server"></asp:Literal>&nbsp;</td>
 </tr>
            
  <tr>
      <td class="form_text_row">录入人：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblNoteName" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">录入时间：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblNoteDate" runat="server"></asp:Literal>&nbsp;</td>
 </tr>
                    
  <tr>
      <td class="form_text_row">备注：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblRemark" runat="server"></asp:Literal>&nbsp;</td>
      <td class="form_text_row">内部记录：</td>
      <td class="form_ctrl_row"><asp:Literal ID="lblBosomNote" runat="server"></asp:Literal>&nbsp;</td>
  </tr>
</table>
</asp:Content>
