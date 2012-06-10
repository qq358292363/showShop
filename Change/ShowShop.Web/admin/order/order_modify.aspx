<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="order_modify.aspx.cs" Inherits="ShowShop.Web.admin.order.order_modify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../scripts/prototype.js"></script>
    
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript">
    function updatePrice(Id,Price)
    {
        var param = "Option=ModifyPrice&Id="+Id+"&Price="+ Price;
        var options={
            method:'post',
            parameters:param,
            onComplete:
            function(transport)
	        {
	          var retv=transport.responseText;
		      window.location.reload();
		    }     
	      }
	    new  Ajax.Request("order_modify.aspx",options);
    }
    
    function updateNum(Id,Count)
    {
        var param = "Option=ModifyCount&Id="+Id+"&Count="+ Count;
        var options={
            method:'post',
            parameters:param,
            onComplete:
            function(transport)
	        {
	          var retv=transport.responseText;
		      window.location.reload();
		    }     

	      }
	    new  Ajax.Request("order_modify.aspx",options);
    }
    function DeleteProduct(Id,OrderId)
    {
        var param = "Option=DelProduct&OrderID="+OrderId+"&Id="+Id;
        var options={
            method:'post',
            parameters:param,
            onComplete:
            function(transport)
	        {
	          var retv=transport.responseText;
	          if(retv!=="")
	          {
	              alert(retv);
	          }
	          else
	          {
		          window.location.reload();
		      }
		    }     

	      }
	    new  Ajax.Request("order_modify.aspx",options);

    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
订单处理
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保存信息" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="hlBackList" runat="server"  CssClass="inputbutton" NavigateUrl="productbrand_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagesarch" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<!--订单信息-->
<div id="tab0" class="tabs" style="display:block;">
    <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
        <tr>
            <td class="form_text_row">客户名称：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbName" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">订单编号：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="blOrderNo" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">订单状态：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbOrderStatue" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">物流状态：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbLogisticsStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">用户名：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbUserName" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">下单时间：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbOrderDateTime" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">付款情况：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbPayment" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">&nbsp;</td>
            <td class="form_ctrl_row">&nbsp;</td>
        </tr>
    </table>
    <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
        <tr>
            <td class="form_text_row">收货人姓名：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeName" runat="server"></asp:TextBox>
            </td>
            <td class="form_text_row">联系电话：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeTel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">收货人地址：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeAddress" runat="server"></asp:TextBox>
            </td>
            <td class="form_text_row">邮政编码：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeZip" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">收货人邮箱：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeEmail" runat="server"></asp:TextBox>
            </td>
            <td class="form_text_row">收货人手机：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneeModile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">标志建筑：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConstructionSigns" runat="server"></asp:TextBox>
            </td>
            <td class="form_text_row">最佳送货时间：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtConsigneTime" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="form_text_row">付款方式：</td>
            <td class="form_ctrl_row">
                <asp:DropDownList ID="ddlPayMent" runat="server">
                    <asp:ListItem Value="0">预付款支付</asp:ListItem>
                    <asp:ListItem Value="1">银行转帐</asp:ListItem>
                    <asp:ListItem Value="2">在线支付</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="form_text_row">送货方式：</td>
            <td class="form_ctrl_row">
                 <asp:DropDownList ID="ddlDeliver" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">备注留言：</td>
            <td class="form_ctrl_row" colspan="3">
                <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="80px" runat="server" 
                    Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_text_row"><img src="../images/notice.gif" title="订单金额=商品总价+运费+支付手续费" />订单金额：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbOrderTotalPrice" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">运费：</td>
            <td class="form_ctrl_row">
                <asp:TextBox ID="txtCarriage" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Literal ID="litData" runat="server"></asp:Literal>
    <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td><img src="../images/notice.gif" title="向该订单中添加商品" />选择商品：</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                <asp:HiddenField runat="server" ID="hfid" />
                <asp:HiddenField runat="server" ID="hfOrderId" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</div>

<!--付款信息-->
<div id="tab1" class="tabs">
    <asp:Literal ID="lblMoneyList" runat="server"></asp:Literal>
</div>

<!--发退货记录-->
<div id="tab2" class="tabs">
   <asp:Literal ID="lblConsignList" runat="server"></asp:Literal>
</div>

<!--过户记录-->
<div id="tab3" class="tabs">
   <asp:Literal ID="lblTransList" runat="server"></asp:Literal>
</div>

<!--反馈记录-->
<div id="tab4" class="tabs">
   
</div>

</asp:Content>
