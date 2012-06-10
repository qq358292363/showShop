<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="mail_setting.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.mail_setting" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
邮件设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
配置系统邮件发送用的服务器信息&nbsp; 
    <asp:Button ID="Button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
		    <td class="form_table_input_info">SMTP服务器：<asp:HiddenField ID="txtId" runat="server" />
            </td>
		    <td>
                <asp:TextBox ID="txtSmtpServerIP" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtSmtpServerIPTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">SMTP服务器端口：
            </td>
		    <td>
                <asp:TextBox ID="txtSmtpServerPort" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtSmtpServerPortTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">发送人邮箱：
            </td>
		    <td>
                <asp:TextBox ID="txtMailId" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtMailIdTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">邮箱密码：
            </td>
		    <td>
                <asp:TextBox ID="txtMailPassword" TextMode="Password" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtMailPasswordTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
        
    </table>
    
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>