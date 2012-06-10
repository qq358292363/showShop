<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_changedata.aspx.cs" Inherits="ShowShop.Web.admin.member.member_changedata" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle"> 兑换有效期 </asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo"> 
 <asp:LinkButton ID="lbSave" runat="server" onclick="btnWork_Click" >执行</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
  <table width="100%" border="0" cellspacing="1" cellpadding="1" class="form_table_input" >
  <tr>
    <td width="20%" class="form_table_input_info"><div align="right">会员名：</div></td>
    <td>
        <asp:Label ID="lblName" runat="server"></asp:Label>
      </td>
      <td><div class="msgNormal">该用户账号</div> </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">所属会员组：</div></td>
    <td>
        <asp:Label ID="lblGroup" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户所属会员组</div> </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">资金余额：</div></td>
    <td>
        <asp:Label ID="lblCapital" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户所剩资金余额</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">点券数：</div></td>
    <td>
        <asp:Label ID="lblCoupons" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户所剩点卷数</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">积分：</div></td>
    <td>
        <asp:Label ID="lblPoints" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户所剩积分</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">有效期信息：</div></td>
    <td>
        剩余<asp:Label ID="lblDay" runat="server" ForeColor="Blue"></asp:Label>天
   </td>
   <td><div class="msgNormal">该用户所剩有效期天数</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">设置有效期：</div></td>
    <td>
         <asp:TextBox ID="txtManageTime" CssClass="date_input" runat="server"></asp:TextBox>
     </td>
     <td><asp:Panel ID="txtManageTimeTip" runat="server"></asp:Panel></td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">同时减去资金：</div></td>
    <td>
        <asp:TextBox ID="txtCapital" runat="server" Width="81px"></asp:TextBox> 元
     </td>
     <td><asp:Panel ID="txtCapitalTip" runat="server"></asp:Panel></td>
  </tr>
  
 <tr>
    <td class="form_table_input_info"><div align="right">原因：</div></td>
     <td>
        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
    </td>
    <td><asp:Panel ID="txtQuestionTip" runat="server"></asp:Panel></td>
  </tr> 
  <tr>
    <td class="form_table_input_info"><div align="right">内部记录：</div></td>
    <td>
        <asp:TextBox ID="txtLog" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
     </td>
     <td>
         <div class="msgNormal"> 原因最多<b>1000</b>个字符，内容最多<b>1000</b>个字符</div>  
     </td>
  </tr>
  </table>
</asp:Content>