<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_custom_edit.aspx.cs" Inherits="ShowShop.Web.admin.member.member_custom_edit" Title="自定义会员注册属性管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function datavalue(value)
    {
        if(value=="1"||value=="2"||value=="3"||value=="6")
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


<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">自定义会员属性
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="memberproperty_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加或编辑注册会员属性&nbsp; 
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <%--<tr>
             <td class="form_table_input_info">所属分类：</td>
             <td>
                 <asp:TextBox ID="txtProductClass" runat="server" ReadOnly></asp:TextBox>
                 <asp:HiddenField runat="server" ID="hfcid" />
             </td>
             <td>
                 <div class="msgNormal">当为空时表示所添加的属性不属于任何商品分类</div>
             </td>
         </tr>--%>
         <tr>
		    <td class="form_table_input_info">属性名称：</td>
		    <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtNameTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">属性类型：
            </td>
		    <td>
                <asp:DropDownList ID="ddlType" runat="server" onchange ="datavalue(this.value);">
                    <asp:ListItem Value="1" Text="下拉列表" />
                    <asp:ListItem Value="2" Text="单选" />
                    <asp:ListItem Value="3" Text="多选" />
                    <asp:ListItem Value="4" Text="单行文本" />
                    <asp:ListItem Value="5" Text="多行文本" />
                    <asp:ListItem Value="6" Text="特殊类型" />
                </asp:DropDownList>
            </td>
		    <td>&nbsp;</td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否必填：</td>
		    <td>
                <asp:RadioButtonList ID="rdolstIsRequire" RepeatDirection="Horizontal" runat="server">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Panel ID="fuBrandImagesTip" runat="server"></asp:Panel>
            </td>
	    </tr>
        <tr>
		    <td class="form_table_input_info">排列顺序：
            </td>
		    <td>
                <asp:TextBox ID="txtSort" CssClass="short_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtSortTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr id="trDatavalue" runat="server">
		    <td class="form_table_input_info">可选值列表：
            </td>
		    <td>
                <asp:TextBox ID="txtDataValue" runat="server" Width="200px" Height="60px" TextMode="MultiLine" MaxLength="2500"></asp:TextBox>
            </td>
		    <td>
                <div class="msgNormal">当您选择属性类型下拉列表中的下拉列表、单选或多选的时候，请在此输入属性的可选值，每行表示一个可选值</div>
            </td>
	    </tr>
    </table>
</asp:Content>


<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="memberproperty_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
