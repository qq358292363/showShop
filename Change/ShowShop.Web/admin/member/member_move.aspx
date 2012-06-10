<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="member_move.aspx.cs" Inherits="ShowShop.Web.admin.member.member_move" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">会员组移动
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="lbSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
       
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
   <tr>
	   <td class="form_table_input_info">指定用户名：</td>
	   <td>
		   <asp:RadioButton ID="rabtnUser" Checked="true"  runat="server" GroupName="move" Text="选择"/><br />
		   <asp:TextBox ID="txtUserName" CssClass="long_input" runat="server"></asp:TextBox> 
       </td>
       <td>
            <div class="msgNormal">多个用户名间请用<span style="color: blue">英文的逗号</span>分隔</div>  
       </td>
   </tr>
   
   <tr>
	   <td class="form_table_input_info">指定用户组：</td>
	   <td>
	       <asp:RadioButton ID="rabtnGroup" runat="server" GroupName="move" Text="选择"/><br />
           <asp:ListBox ID="lbxFrom" runat="server" Height="150px" Width="80" 
               onselectedindexchanged="lbxFrom_SelectedIndexChanged"></asp:ListBox>
           把该组->移动到
           <asp:ListBox ID="lbxTo" runat="server" Height="150px" Width="80" 
               onselectedindexchanged="lbxTo_SelectedIndexChanged"></asp:ListBox>
       </td>
       <td>
           <div class="msgNormal">会将选中的用户组批量的移动到指定用户组下</div> 
       </td>
  </tr>
</table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>