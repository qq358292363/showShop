<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_rank_edit.aspx.cs" Inherits="ShowShop.Web.admin.member.member_rank_edit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">会员等级编辑
    <asp:Button ID="button3" runat="server" CssClass="inputbutton" onclick="Button1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="member_rank_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>

    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">会员等级名称：<asp:HiddenField ID="txtId" runat="server" />
            </td>
		    <td>
                <asp:TextBox ID="txtName" CssClass="long_input"  runat="server"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtNameTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">等级图片：</td>
		    <td>
                <asp:Image ID="txtLogoPicImg" runat="server" />
                <asp:HiddenField ID="txtLogoPicUrl" runat="server" />
                <br />
                <asp:FileUpload ID="txtLogoPic" runat="server" />
            </td>
		    <td>
                <asp:Panel ID="txtLogoTip" runat="server" CssClass="msgNormal">
                上传该等级的Logo,文件需要是.gif或者是.jpg,并且大小在100K以内
                </asp:Panel>
                    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">积分下限：</td>
		    <td>
                <asp:TextBox ID="txtMinScore"   runat="server"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtMinScoreTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">积分上限：</td>
		    <td>
                <asp:TextBox ID="txtMaxScore"   runat="server"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtMaxScoreTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">每次购物最大金额：</td>
		    <td>
                <asp:TextBox ID="txtMaxMoney"   runat="server"></asp:TextBox> 元人民币
            </td>
		    <td>
		        <asp:Panel id="txtMaxMoneyTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">升级金额：</td>
		    <td>
                <asp:TextBox ID="txtUpgradeMoney"   runat="server"></asp:TextBox> 元人民币
            </td>
		    <td>
		        <asp:Panel id="txtUpgradeMoneyTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否可以升级：</td>
		    <td>
                <asp:RadioButtonList ID="ckbIsUpgrade" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
		    <td>
		        <div class="msgNormal">该等级的用户是否可以继续升级</div>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">打折率：</td>
		    <td>
                <asp:TextBox ID="txtDiscount" CssClass="short_input" runat="server"></asp:TextBox> %
            </td>
		    <td>
		        <asp:Panel id="txtDiscountTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">等级优先级：</td>
		    <td>
                <asp:TextBox ID="txtPriority" CssClass="short_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtPriorityTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">其他信息设置：</td>
		    <td>
                <asp:CheckBoxList ID="ckbOtherInfo" runat="server" RepeatColumns="1" 
                    RepeatLayout="Flow">
                    <asp:ListItem Value="IsShowPrice">在商品详情页显示该会员等级的商品价格</asp:ListItem>
                    <asp:ListItem Value="IsSpecial">特殊会员组(特殊会员组的会员不会随着积分的变化而变化)
                    </asp:ListItem>
                    <asp:ListItem Value="Article">是否允许发表资讯评论 
                    </asp:ListItem>
                    <asp:ListItem Value="Product">是否允许对商品进行评论 
                    </asp:ListItem>
                    <asp:ListItem Value="ArticleAuditing">发表的文章评论是否需要审核 
                    </asp:ListItem>
                    <asp:ListItem Value="ProductAuditing">发表的商品评论是否需要审核 
                    </asp:ListItem>
                </asp:CheckBoxList>
            </td>
		    <td>
		        <div class="msgNormal">用户等级的其他信息设置</div>
		    </td>
	    </tr>
    </table>

</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="butSave" runat="server" CssClass="inputbutton" onclick="Button1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_rank_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>