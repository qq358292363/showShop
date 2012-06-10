<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="email_send.aspx.cs" Inherits="ShowShop.Web.admin.member.email_send" %>
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
    <asp:LinkButton ID="lbSave" runat="server" onclick="lbSave_Click" >发送</asp:LinkButton>
&nbsp;
    <asp:HyperLink ID="returnLink" runat="server" NavigateUrl="~/admin/member/member_list.aspx">返回用户列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
       
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">选择全体用户：</td>
        <td>
            <asp:RadioButton ID="rabtnAllUser" runat="server" GroupName="reciveUser" Text="选择"/>
        </td>
        <td>
            <div class="msgNormal">选择后将会给所有注册用户发送该邮件</div>  
        </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info" style="height:30px">指定会员组：</td>
	   <td>
	       <asp:RadioButton ID="rabtnMemberGroup" runat="server" GroupName="reciveUser" Text="选择"/>
           <asp:CheckBoxList ID="cbxlMemberRank" RepeatColumns="3" runat="server">
           </asp:CheckBoxList>
       </td>
       <td>
            <div class="msgNormal">选择后将会给所有您选择的会员组发送该邮件</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">指定用户名：</td>
	   <td>
		   <asp:RadioButton ID="rabtnCheckUser" Checked="true"  runat="server" GroupName="reciveUser" Text="选择"/><br />
		   <asp:TextBox ID="txtUserName" CssClass="long_input" runat="server"></asp:TextBox> 
       </td>
       <td>
            <div class="msgNormal">多个用户名间请用<span style="color: blue">英文的逗号</span>分隔</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">指定用户邮箱：</td>
	   <td>
	       <asp:RadioButton ID="rabtnCheckEmail" runat="server" GroupName="reciveUser" Text="选择"/><br />
           <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> 
       </td>
       <td>
           <div class="msgNormal">输入时请注意邮箱的格式</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">发件人邮箱：</td>
	   <td>
           <asp:TextBox ID="txtSendEmail" ReadOnly="true" runat="server"></asp:TextBox> 
       </td>
       <td>
           <div class="msgNormal">系统设置中指定的发件箱</div> 
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
