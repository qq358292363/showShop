<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_useful.aspx.cs" Inherits="ShowShop.Web.admin.member.member_useful" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
 <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
编辑个人有效期
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo"> 
 <asp:LinkButton ID="lbSave" runat="server" onclick="btnOk_Click" >保存</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
 <table width="100%" border="0" cellspacing="1" cellpadding="1" class="form_table_input" >
  <tr>
    <td class="form_table_input_info"><div align="right">会员名：</div></td>
    <td>
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户的账号</div> </td>
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
    <td><div class="msgNormal">该用户的资金余额</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">点券数：</div></td>
    <td>
        <asp:Label ID="lblCoupon" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户的点卷数</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">积分：</div></td>
    <td>
        <asp:Label ID="lblPoint" runat="server"></asp:Label>
    </td>
    <td><div class="msgNormal">该用户的积分数</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">有效期信息：</div></td>
    <td>
        剩余<asp:Label ID="lblValidity" runat="server" ForeColor="Blue"></asp:Label>天
    </td>
    <td><div class="msgNormal">该用户的有效期剩余天数</div> </td>
  </tr>
 
  <tr>
    <td class="form_table_input_info"><div align="right">设置有效期：</div></td>
    <td>
        <asp:RadioButton ID="RadValidity" runat="server" GroupName="asd"  
            Text="有效期截至日期" Checked="True" oncheckedchanged="RadValidity_CheckedChanged" />
        &nbsp;
        <asp:TextBox ID="txtManageTime" CssClass="date_input" runat="server"></asp:TextBox>
                                                <br />
        <asp:RadioButton ID="RadZero" runat="server" GroupName="asd" Text="有效期归零" 
            oncheckedchanged="RadZero_CheckedChanged" />
     </td>
     <td><asp:Panel ID="txtManageTimeTip" runat="server"></asp:Panel></td>
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