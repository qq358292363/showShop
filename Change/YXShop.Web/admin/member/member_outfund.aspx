<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_outfund.aspx.cs" Inherits="ShowShop.Web.admin.member.member_outfund" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
添加/编辑支出金额
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
<asp:LinkButton ID="lbSave" runat="server" onclick="BtnWork_Click" >执行</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
 <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
 <table width="100%" border="0" cellspacing="1" cellpadding="1" class="form_table_input">
  <tr>
    <td width="20%" class="form_table_input_info"><div align="right">会员名：</div></td>
    <td>
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户的账号</div> </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">资金余额：</div></td>
    <td width="70%">
        <asp:Label ID="lblCapital" runat="server"></asp:Label>元
    </td>
    <td><div class="msgNormal">该用户所剩资金余额</div> </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">支出金额：</div></td>
    <td>
        <asp:TextBox ID="txtPayMoney" runat="server" Width="81px"></asp:TextBox>元
      </td>
      <td><asp:Panel ID="txtPayMoneyTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">原因备注：</div></td>
    <td>
        <asp:TextBox ID="txtWhy" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
    </td>
     <td><asp:Panel ID="txtWhyTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">内部记录：</div></td>
    <td>
        <asp:TextBox ID="txtLog" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
      </td>
      <td> <div class="msgNormal" >最多<b>1000</b>个字符，内容最多<b>1000</b>个字符<br /> 注意：汇款/收入信息一旦录入，就不能再修改或删除！所以在保存之前确认输入无误！</div></td>
  </tr>
  </table>
</asp:Content>