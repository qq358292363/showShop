<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="ordercard_edit.aspx.cs" Inherits="ShowShop.Web.admin.ordercard.ordercard_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script language="javascript" language="javascript">
    function isShopSale(str)
    {
        if(str=="1")
        {
            document.getElementById('ctl00_workspace_OptionProduct').style.display='';
        }
        if(str=="0")
        {
            document.getElementById('ctl00_workspace_OptionProduct').style.display='none';;
        }
    }
    function isMode(str)
    {alert(str)
        if(str=="1")
        {
            document.getElementById('line').style.display='';
            document.getElementById('dline').style.display='none';
        }
        if(str=="2")
        {
            document.getElementById('dline').style.display='';
            document.getElementById('line').style.display='none';
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品品牌
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="ordercard_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加或编辑商品品牌&nbsp; 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td  class="form_table_input_info"><span style="font-weight:bold;">充值卡类型：</span></td>
            <td>
                <asp:RadioButtonList ID="rbCardType" runat="server">
                   <asp:ListItem Text="本商城充值卡" Value="1" Selected="True"></asp:ListItem>
                   <asp:ListItem Text="其它公司充值卡" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <div class="msgNormal">充值卡来源</div>
            </td>
        </tr>
        <tr>
            <td  class="form_table_input_info">充值卡所属商品：</td>
            <td>
                <asp:RadioButtonList ID="rblIsShopSale" runat="server" RepeatDirection="Horizontal">
                   <asp:ListItem Text="通过商城出售" Value="1" onclick="javascript:isShopSale(this.value);"></asp:ListItem>
                   <asp:ListItem Text="不通过商城出售" Value="0" Selected="True" onclick="javascript:isShopSale(this.value);"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td><div class="msgNormal">选中通过商城出售该卡将在前专栏目售销;选中不通过商城出售该卡将着为商城充值使用</div></td>
        </tr>
         
        <tr id="OptionProduct" runat="server" style="display:none">
            <td class="form_table_input_info">选择商品：</td>
            <td>
                <asp:TextBox ID="txtProduct" runat="server" ReadOnly></asp:TextBox>
                <asp:HiddenField runat="server" ID="hfid" />
            </td>
            <td><div class="msgNormal">要出售的点卡</div></td>
        </tr>
        <tr>
            <td class="form_table_input_info">添加方式：</td>
            <td>
                <asp:RadioButtonList ID="brlmode" runat="server" RepeatDirection="Horizontal">
                   <asp:ListItem Text="单张充值卡" Value="1" Selected="True" onclick="javascript:isMode(this.value);"></asp:ListItem>
                   <asp:ListItem Text="批量添加充值卡" Value="2" onclick="javascript:isMode(this.value);"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr id="line">
            <td colspan="3">
            <table  class="form_table_input" width="100%">
            <tr>
                <td class="form_table_input_info">充值卡卡号：</td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server" Width="163px"></asp:TextBox>&nbsp;
                    <span style="color: blue">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                    </span>
                    </td>
                    <td>
                        <div class="msgNormal">建议设为10--15位</div>
                    </td>
        </tr>
        <tr>
            <td class="form_table_input_info">充值卡密码：</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>&nbsp;
                <span style="color: blue"><asp:Label ID="Label4" runat="server"></asp:Label>
                <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
                </span>
            </td>
            <td>
                <div class="msgNormal">建议设为10--15位</div>
            </td>
        </tr>
            </table>
            </td>
        </tr>
        
        <tr id="dline" style="display:none">
           <td class="form_table_input_info">格式文本：</br>
<span style="color:Red;"></td>
           <td>
               <asp:TextBox ID="txtBatch" runat="server" TextMode="MultiLine" Height="149px" 
                   Width="275px"></asp:TextBox><br />分隔符：<asp:TextBox ID="tbSp" 
                   runat="server" Width="108px"></asp:TextBox>注：逗号不能作为分隔符。<asp:Label ID="Label5" runat="server"></asp:Label>
           </td>
           <td>
               <div class="msgNormal">请按照每行一张卡，每张卡按“卡号＋分隔符＋密码”的格式录入,例1：734534759*kSo94Sf4Xs（以“*”作为分隔符）;例2：98273305834|lo23ji6x（以“|”作为分隔符）</div>
           </td>   
        </tr>
        
        <tr>
            <td class="form_table_input_info">充值卡面值：</td>
            <td>
                <asp:TextBox ID="txtFaceValue" runat="server" MaxLength="15" ></asp:TextBox>
                </td>
             <td>
                <asp:Panel ID="txtFaceValueTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td  class="form_table_input_info">充值卡点数、资金或有效期：</td>
            <td>
                <asp:TextBox ID="txtPoint" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddty" runat="server" DataTextField="YX_DWName" DataValueField="YX_DWName">
                    <asp:ListItem Text="点" Value="点"></asp:ListItem>
                    <asp:ListItem Text="天" Value="天"></asp:ListItem>
                    <asp:ListItem Text="月" Value="月"></asp:ListItem>
                    <asp:ListItem Text="年" Value="年"></asp:ListItem>
                    <asp:ListItem Text="元" Value="元"></asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                     <div class="msgNormal">购买人可以得到的点数、资金或有效期</div>
                </td>
        </tr>
    <tr>
        <td class="form_table_input_info"><span style="font-weight:bold;">充值卡售价：</span></td>
        <td>
            <asp:TextBox ID="txtPrice" runat="server" MaxLength="20"></asp:TextBox>
         </td>
         <td>
             <asp:Panel ID="txtPriceTip" runat="server">
                </asp:Panel>
         </td>
    </tr>
    
        <tr>
            <td class="form_table_input_info"><span style="font-weight:bold;">截止日期：</span></td>
            <td >
                <asp:TextBox ID="txtEndTime" CssClass="date_input" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="txtHandselCouponsBeginTimeTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td  class="form_table_input_info"><span style="font-weight:bold;">代理商：</span></td>
            <td><asp:TextBox ID="txtBusinessAgent" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="ordercard_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>