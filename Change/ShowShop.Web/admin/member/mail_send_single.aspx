<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"   MasterPageFile="~/admin/admin_page.master" CodeBehind="mail_send_single.aspx.cs" Inherits="ShowShop.Web.admin.member.mail_send_single" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">邮件发送
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<asp:LinkButton ID="lbSave" runat="server" onclick="lbSave_Click">发送</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
       
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">会员名：</td>
        <td>
            <asp:Literal ID="lblUserId" runat="server"></asp:Literal>
        </td>
        <td>
            <div class="msgNormal">选择向指定用户发送该邮件</div>  
        </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">所属会员组：</td>
	   <td>
	       <asp:Literal ID="lblGroupName" runat="server"></asp:Literal>
       </td>
       <td>
            <div class="msgNormal">该用户所属的会员组</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">资金余额：</td>
	   <td>
	      <asp:Literal ID="lblCapital" runat="server"></asp:Literal>
       </td>
       <td>
            <div class="msgNormal">该用户所有的资金余额</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">点卷数：</td>
	   <td>
	       <asp:Literal ID="lblCoupons" runat="server"></asp:Literal>	
       </td>
       <td>
           <div class="msgNormal">该用户所有的点卷数量</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">积分：</td>
	   <td>
	       <asp:Literal ID="lblPoints" runat="server"></asp:Literal>	
       </td>
       <td>
           <div class="msgNormal">该用户所有的积分</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">有效日期：</td>
	   <td>
	       剩余<font color="blue"><asp:Literal ID="lblPeriodOfValidity" runat="server"></asp:Literal></font>天	
       </td>
       <td>
           <div class="msgNormal">该用户所剩下的有效日期天数</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">要发送到的邮箱：</td>
	   <td>
	       <asp:Literal ID="lblEmail" runat="server"></asp:Literal>	
       </td>
       <td>
           <div class="msgNormal">该用户的邮箱，邮件将发往该地址</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">邮件主题：</td>
	   <td>
           <asp:TextBox ID="txtEmailTitle" CssClass="long_input" runat="server" MaxLength="50"></asp:TextBox> 
       </td>
       <td>
           <asp:Panel ID="txtEmailTitleTip" runat="server"></asp:Panel>
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">邮件内容：</td>
	   <td colspan="2">
           <FCKeditorV2:FCKeditor ID="txtEmailContent" runat="server" Width="500px"></FCKeditorV2:FCKeditor>
           <div class="msgNormal">内容限制在1000个字符以内</div>
       </td>
   </tr>
</table>
</asp:Content>
