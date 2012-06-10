<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="admin_edit.aspx.cs" Inherits="ShowShop.Web.admin.member.admin_edit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">编辑管理员
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="admin_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">管理员的信息管理&nbsp; 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>

    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">管理员帐号：<asp:HiddenField ID="txtAdminId" runat="server" />
            </td>
		    <td>
                <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtNameTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">管理员密码：</td>
		    <td>
                <asp:TextBox ID="txtPasswordRe"   runat="server" TextMode="Password"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtPasswordReTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">密码确认：</td>
		    <td>
                <asp:TextBox ID="txtPassword"   runat="server" TextMode="Password"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtPasswordTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">角色设置：</td>
		    <td>
                
                <asp:RadioButtonList ID="ckbPower" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">普通管理员</asp:ListItem>
                    <asp:ListItem Value="0">超级管理员</asp:ListItem>
                </asp:RadioButtonList>
                
            </td>
		    <td>
		        <div class="msgNormal">超级管理员：拥有所有权限。某些权限（如管理员管理、网站信息配置、角色管理等管理权限）只有超级管理员才有。 普通管理员：需要详细指定每一项角色权限 </div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">管理员状态：</td>
		    <td>
                
                <asp:CheckBox ID="ckbState" runat="server" Text="冻结该帐号" />
                <br />
                <asp:CheckBox ID="ckbAllowModifyPassword" runat="server" Text="允许该管理员修改自己的密码" />
                
            </td>
		    <td>
		        <div class="msgNormal">管理员的其他一些信息</div>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">管理开始时间：</td>
		    <td>
                <asp:TextBox ID="txtManageBeginTime" CssClass="date_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtManageBeginTimeTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">管理结束时间：</td>
		    <td>
                <asp:TextBox ID="txtManageEndTime" CssClass="date_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtManageEndTimeTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
    </table>

</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="admin_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>