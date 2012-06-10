<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="area_setting_edit.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.area_setting_edit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">城市编辑
    <asp:HyperLink ID="returnLink" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
    <asp:Button ID="Button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">设置城市频道的相关信息&nbsp; 

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
		    <td class="form_table_input_info">所属城市[省/区]：<asp:HiddenField ID="txtId" runat="server" />
            </td>
		    <td>
                <asp:DropDownList ID="ddlParentId" runat="server"> </asp:DropDownList>
                <asp:HiddenField ID="txtParentPath" runat="server" /><asp:HiddenField ID="txtDepth" runat="server" />
            </td>
		    <td>
                <div class="msgNormal">该市/县所在的上一级地区【省/市/自治区】</div>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">城市名称：
            </td>
		    <td>
                <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtCityNameTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">城市英文名称：
            </td>
		    <td>
                <asp:TextBox ID="txtCityEnglishName" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtCityEnglishNameTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否开启该分站：
            </td>
		    <td>
                <asp:RadioButtonList ID="ckbIsUse" runat="server" RepeatDirection="Horizontal" 
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                    <asp:ListItem Value="0">不开启</asp:ListItem>
                </asp:RadioButtonList>
            </td>
		    <td>
                <div class="msgNormal">是否开启该省/市/县的地区分站</div>
            </td>
	    </tr>
        
    </table>

</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="returnLinkBottom" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>