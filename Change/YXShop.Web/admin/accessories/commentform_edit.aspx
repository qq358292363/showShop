<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="commentform_edit.aspx.cs" Inherits="ShowShop.Web.admin.accessories.commentform_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function datavalue(value)
    {
        if(value=="1"||value=="2"||value=="3")
        {
            $("ctl00_workspace_trDatavalue").style.display="";
        }
        else
        {
            $("ctl00_workspace_trDatavalue").style.display="none";
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">点评表单
<asp:Button ID="Button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" onclick="javascript:history.back()" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返 回</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
		    <td class="form_table_input_info">评论项名称：</td>
		    <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtNameTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">评论项类型：
            </td>
		    <td>
                <asp:DropDownList ID="ddlType" runat="server" onchange ="datavalue(this.value);">
                    <asp:ListItem Value="1" Text="下拉列表" />
                    <asp:ListItem Value="2" Text="单选" />
                    <asp:ListItem Value="3" Text="多选" />
                    <asp:ListItem Value="4" Text="单行文本" />
                    <asp:ListItem Value="5" Text="多行文本" />
                </asp:DropDownList>
            </td>
		    <td>&nbsp;</td>
	    </tr>
	    <tr style="display:none">
		    <td class="form_table_input_info">是否必填：</td>
		    <td>
                <asp:RadioButtonList ID="rdolstIsRequire" RepeatDirection="Horizontal" runat="server">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Panel ID="fuBrandImagesTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr id="trDatavalue" runat="server">
		    <td class="form_table_input_info">可选值列表：
            </td>
		    <td>
                <asp:TextBox ID="txtDataValue" runat="server" Width="200px" Height="60px" TextMode="MultiLine" MaxLength="2500"></asp:TextBox>
            </td>
		    <td>
                <div class="msgNormal">当您选择评论项类型下拉列表中的下拉列表、单选或多选的时候，请在此输入属性的可选值，每行表示一个可选值</div>
            </td>
	    </tr>
    </table>
</asp:Content>
<asp:Content ID="ContBottom" runat="server" ContentPlaceHolderID="pagebottom">
 <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" onclick="javascript:history.back()" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返 回</asp:HyperLink>
</asp:Content>