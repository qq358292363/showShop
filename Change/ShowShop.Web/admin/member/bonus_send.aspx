<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/admin/admin_page.master" CodeBehind="bonus_send.aspx.cs" Inherits="ShowShop.Web.admin.member.bonus_send" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">奖金扣发
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server"> 
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>    
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">选择全体用户：</td>
        <td>
            <asp:RadioButton ID="rabtnAllUser" runat="server" GroupName="reciveUser" 
                Text="选择" oncheckedchanged="rabtnAllUser_CheckedChanged"/>
        </td>
        <td>
            <div class="msgNormal">选择后将会给所有注册用户扣发奖金</div>  
        </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info" style="height:30px">指定会员组：</td>
	   <td>
	       <asp:RadioButton ID="rabtnMemberGroup" runat="server" GroupName="reciveUser" 
               Text="选择" oncheckedchanged="rabtnMemberGroup_CheckedChanged"/>
           <asp:CheckBoxList ID="cbxlMemberRank" RepeatColumns="4" runat="server">
           </asp:CheckBoxList>
       </td>
       <td>
            <div class="msgNormal">选择后将会给所有您选择的会员组发送该邮件</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">指定用户名：</td>
	   <td>
		   <asp:RadioButton ID="rabtnCheckUser" Checked="true"  runat="server" 
               GroupName="reciveUser" Text="选择" 
               oncheckedchanged="rabtnCheckUser_CheckedChanged"/><br />
		   <asp:TextBox ID="txtName" CssClass="long_input" runat="server"></asp:TextBox> 
       </td>
       <td>
            <div class="msgNormal">多个用户名间请用<span style="color: blue">英文的逗号</span>分隔</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">金额：</td>
	   <td>
           <asp:TextBox ID="txtCapital" runat="server" MaxLength="10"></asp:TextBox> 
       </td>
       <td>
           <asp:Panel ID="txtCapitalTip" runat="server"></asp:Panel>
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">原因：</td>
	   <td>
           <asp:TextBox ID="txtReason"  runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox> 
       </td>
       <td>
           <asp:Panel ID="txtReasonTip" runat="server"></asp:Panel>
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">内部记录：</td>
	   <td>
           <asp:TextBox ID="txtRcord"  runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox> 
       </td>
       <td>
           <div class="msgNormal">请输入内部记录内容</div> 
       </td>
   </tr>
</table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="lbSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>