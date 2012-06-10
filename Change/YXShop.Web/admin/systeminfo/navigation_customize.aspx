<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="navigation_customize.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.navigation_customize" Title="自定义导航" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
     <script type="text/javascript">
        function LogoType(obj)
        {
        var navtype = obj.value;
        
            if(navtype=='1')
            {
                type1.style.display=""; 
                type2.style.display="none"; 
                type3.style.display="none"; 
            }
            else if(navtype=='2')
            {
               type2.style.display=""; 
                type1.style.display="none"; 
                type3.style.display="none"; 
            }
            else if(navtype=='3')
            {
                type3.style.display=""; 
                type1.style.display="none";
                type2.style.display="none"; 

            }
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">自定义导航
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="navigation_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加自定义导航 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
     <tr>
             <td class="form_table_input_info">导航类型：</td>
             <td>
                 <input type="radio" name="navtype" id="rdtype1" onclick="LogoType(this)" value=1 runat="server"  checked/>系统类
                 <input type="radio" name="navtype" id="rdtype2" onclick="LogoType(this)" value=2 runat="server" />商品类
                 <input type="radio" name="navtype" id="rdtype3" onclick="LogoType(this)" value=3  runat="server"/>资讯类
             </td>
         </tr>
         <tr id="type1" style="display:">
             <td class="form_table_input_info">系统内容：</td>
             <td>
                 <asp:TextBox ID="txtContentRegion1" runat="server"></asp:TextBox>
                 <asp:HiddenField runat="server" ID="hfcConentRegion1" />
             </td>
         </tr>
         <tr id="type2" style="display:none">
             <td class="form_table_input_info">系统商品内容：</td>
             <td>
                 <asp:TextBox ID="txtContentRegion2" runat="server"></asp:TextBox>
                 <asp:HiddenField runat="server" ID="hfcContentRegion2" />
             </td>
         </tr>
         <tr id="type3" style="display:none">
             <td class="form_table_input_info">系统资讯内容：</td>
             <td><asp:DropDownList ID="ddlContentRegion3" runat="server" 
                     onselectedindexchanged="ddlContentRegion3_SelectedIndexChanged"></asp:DropDownList>
           <asp:HiddenField ID="hfcContentRegion3" runat="server" />
       </td>
         </tr>
         <tr>
		    <td class="form_table_input_info">名称：</td>
		    <td>
                <asp:TextBox ID="txtField" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtFieldTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">链接地址：
            </td>
		    <td>
                <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtLinkTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">排序：</td>
		    <td>
                <asp:TextBox ID="txtSort" CssClass="short_input" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="txtSortTip" runat="server"></asp:Panel>
            </td>
	    </tr>
        <tr>
		    <td class="form_table_input_info">是否显示：
            </td>
		    <td>
                <asp:DropDownList ID="ddlIsShow" runat="server">
                <asp:ListItem Selected="True" Value=1>是</asp:ListItem>
                <asp:ListItem Value=0>否</asp:ListItem>                
                </asp:DropDownList>
            </td>
		    <td>
                <asp:Panel ID="txtIsShowTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否在新窗口打开：
            </td>
		    <td>
                <asp:DropDownList ID="ddlIsNewWindow" runat="server">
                <asp:ListItem Selected="True" Value=1>是</asp:ListItem>
                <asp:ListItem Value=0>否</asp:ListItem>                
                </asp:DropDownList>
            </td>
		    <td>
                <asp:Panel ID="ddlIsNewWindowTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">位置：
            </td>
		    <td>
                
                <asp:DropDownList ID="ddlPart" runat="server">
                <asp:ListItem Selected Value=1>顶部</asp:ListItem>
                <asp:ListItem Value=2>中间</asp:ListItem>
                <asp:ListItem Value=3>底部</asp:ListItem>
                </asp:DropDownList>
                
            </td>
		    <td>
                <asp:Panel ID="ddlPartTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="navigation_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
