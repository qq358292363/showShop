<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_cupons_duty.aspx.cs" Inherits="ShowShop.Web.admin.member.member_cupons_duty" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">兑换点券</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
<asp:LinkButton ID="lbSave" runat="server" onclick="btnSave_Click">执行兑换</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
 <table width="100%" border="0" cellspacing="1" cellpadding="1" class="form_table_input">
  <tr>
    <td width="40%" class="form_table_input_info"><div align="right">会员名：</div></td>
    <td width="65%" >
        <asp:Label ID="lblName" runat="server"></asp:Label>
     </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">所属会员组：</div></td>
    <td>
        <asp:Label ID="lblGroup" runat="server"></asp:Label>
    </td>
     <td>
            <div class="msgNormal">向该用户所属的会员组</div>  
        </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">资金余额：</div></td>
    <td>
        <asp:Label ID="lblCapital" runat="server"></asp:Label>
     </td>
      <td>
            <div class="msgNormal">该用户的资金余额</div>  
        </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">点券数：</div></td>
    <td>
        <asp:Label ID="lblCoupons" runat="server"></asp:Label>
    </td>
     <td>
         <div class="msgNormal">该用户的点眷属</div>  
     </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">积分：</div></td>
    <td>
        <asp:Label ID="lblPoints" runat="server"></asp:Label>
    </td>
    <td>
         <div class="msgNormal">该用户的积分</div>  
     </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">有效期信息：</div></td>
    <td>
        剩余<asp:Label ID="lblValidity" runat="server" ForeColor="Blue"></asp:Label>天
    </td>
    <td>
         <div class="msgNormal">该用户剩余的有效天数/div>  
     </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">添加点券：</div></td>
    <td>
        <asp:TextBox ID="txtCoupons" runat="server" Width="80px" Rows="5"></asp:TextBox>点
       </td>
       <td><asp:Panel ID="txtCouponsTip" runat="server"></asp:Panel></td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">同时减去资金：</div></td>
    <td>
        <asp:TextBox ID="txtCapital" runat="server" Width="81px" MaxLength="5"></asp:TextBox>元
      </td>
      <td><asp:Panel ID="txtCapitalTip" runat="server" ></asp:Panel></td>
  </tr>
   <tr>
    <td class="form_table_input_info"><div align="right">原因：</div></td>
    <td width="75%">
        <asp:TextBox ID="txtWhy" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
    </td>
     <td><asp:Panel ID="txtWhyTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">内部记录：</div></td>
    <td>
        <asp:TextBox ID="txtLog" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
      </td>
      <td> <div class="msgNormal" >原因最多<b>1000</b>个字符，内容最多<b>1000</b>个字符</div></td>
  </tr>
  </table>
</asp:Content>