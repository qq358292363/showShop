<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="useful_add.aspx.cs" Inherits="ShowShop.Web.admin.member.useful_add" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
  <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
编辑有效期
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="BtnWork_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
 <table width="100%" border="0" cellspacing="1" cellpadding="1" class="form_table_input">
  <tr>
    <td class="form_table_input_info"><div align="right">选择所有会员：</div></td>
    <td>
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
            GroupName="radType"  Text="所有会员" 
            oncheckedchanged="RadioButton1_CheckedChanged"/>
    </td>
    <td><div class="msgNormal">选择所有用户</div></td>
  </tr> 
  <tr>
  <td class="form_table_input_info"><div align="right">选择指定会员组：</div></td>
    <td>
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="radType" 
            Text="指定会员组" oncheckedchanged="RadioButton2_CheckedChanged"/>
           <asp:CheckBoxList ID="cbxlMemberRank" RepeatColumns="4" runat="server">
           </asp:CheckBoxList>
      </td> 
      <td><div class="msgNormal">选择指定用户组</div></td>
  </tr>
  <tr>
    <td class="form_table_input_info" style="height:30px"><div align="right">选择指定用户名：</div></td>
    <td> 
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="radType" 
            Text="指定用户名" oncheckedchanged="RadioButton3_CheckedChanged" />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </td>
    <td>
       <div class="msgNormal">多个用户名间请用<span style="color:blue">英文的逗号</span>分隔</div>
    </td>
  </tr>
  <tr>
    <td class="form_table_input_info"><div align="right">设置有效日期：</div></td>
    <td>
        <asp:RadioButton ID="RadioButton4" runat="server" Text="添加有效期" Checked="True" 
            GroupName="asd" oncheckedchanged="RadioButton4_CheckedChanged"/>
           <asp:TextBox ID="txtManageTime" CssClass="date_input" runat="server"></asp:TextBox>            	 
          <br />
        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="asd" Text="有效期归零" 
            oncheckedchanged="RadioButton5_CheckedChanged" />
    </td>
    <td><asp:Panel id="txtManageTimeTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td  class="form_table_input_info"><div align="right">原因：</div></td>
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
    <td>
       <div  class="msgNormal">
         原因最多<b>1000</b>个字符，内容最多<b>1000</b>个字符
       </div>
    </td>
  </tr>
  
  </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="BtnWork_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>