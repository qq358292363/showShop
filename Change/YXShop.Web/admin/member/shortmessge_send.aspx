<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/admin/admin_page.master" CodeBehind="shortmessge_send.aspx.cs" Inherits="ShowShop.Web.admin.member.shortmessge_send" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">短消息发送
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<asp:LinkButton ID="lbSave" runat="server" onclick="lbSave_Click" >发送</asp:LinkButton>
&nbsp;<a href="#" onclick="window.history.back();">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
       
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">选择全体用户：</td>
        <td>
            <asp:RadioButton ID="rabtnAllUser" runat="server" GroupName="reciveUser" Text="选择全体用户"/>
        </td>
        <td>
            <div class="msgNormal">选择后将会给所有注册用户发送该短信息</div>  
        </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info" style="height:30px">指定会员组：</td>
	   <td>
	       <asp:RadioButton ID="rabtnMemberGroup" runat="server" GroupName="reciveUser" Text="选择会员组"/>
           <asp:CheckBoxList ID="cbxlMemberRank" RepeatLayout="Flow" RepeatColumns="3" runat="server">
           </asp:CheckBoxList>
       </td>
       <td>
            <div class="msgNormal">选择后将会给所有您选择的会员组发送该短信息</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">指定用户名：</td>
	   <td>
		   <asp:RadioButton ID="rabtnCheckUser" Checked="true"  runat="server" GroupName="reciveUser" Text="选择指定用户"/><br />
		   <asp:TextBox ID="txtUserName" CssClass="long_input" runat="server"></asp:TextBox> 
       </td>
       <td>
            <div class="msgNormal">多个用户名间请用<span style="color: blue">英文的逗号</span>分隔</div>  
       </td>
   </tr>
     
   <tr>
	   <td class="form_table_input_info">发送人：</td>
	   <td>
           <asp:TextBox ID="txtAdminName" Text="admin" ReadOnly="true" runat="server"></asp:TextBox> 
       </td>
       <td>
           <div class="msgNormal">请输入发送人，默认为当前管理员账号</div> 
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">短消息主题：</td>
	   <td>
           <asp:TextBox ID="txtTitle" CssClass="long_input" runat="server" MaxLength="50"></asp:TextBox> 
       </td>
       <td>
           <asp:Panel ID="txtTitleTip" runat="server"></asp:Panel>
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">短消息内容：</td>
	   <td>
        <asp:TextBox ID="txtContent" CssClass="long_input" TextMode="MultiLine" 
               runat="server" MaxLength="1000" Height="145px"></asp:TextBox>    
      </td>
      <td>
           <asp:Panel ID="txtContentTip" runat="server"></asp:Panel>
       </td>
   </tr>
</table>
</asp:Content>
