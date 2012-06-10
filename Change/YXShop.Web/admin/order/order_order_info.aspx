<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="order_order_info.aspx.cs" Inherits="ShowShop.Web.admin.order.order_order_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../scripts/prototype.js"></script>
    
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" defer="defer">
        function ShowMenu(control)
        {
            var y=control.offsetTop; 
            var x=control.offsetLeft; 
             
            objectC=control;
            while(control=control.offsetParent)
            {
                y+=control.offsetTop; 
                x+=control.offsetLeft;
            } 
            $("munelist").style.left=x;
            $("munelist").style.top=y+20;
            $("munelist").style.display="block";
        }
        function HiddenMune(control)
        {
            control.style.display="none";
        }
        
       function Del(id)
       { 
           if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
           {
             var param = "LeaveOption=delleave&id=" + id;
             var options = 
             { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv=="ok")
                     {
                         window.location.href=window.location.href;
                     }
                 }
             }
         }
         else
         {
            return false;
         }
        new Ajax.Request('order_order_info.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
订单处理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<a href="#" id="mune" onmousemove="ShowMenu(this)"><font color='Red'>&#9758;</font> 操 作 </a>
<div id="munelist" class="toolmune" onclick="HiddenMune(this)">
        <div class="toolmunel"></div>
        <ul>
            <li><img src="../images/mune.gif" alt=""/>&nbsp;<a href="order_order_list.aspx">返回订单列表</a></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlModfiyOrder" runat="server" Text="修改订单"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlConfirmOrder" runat="server" Text="确认订单"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlCancelConfirm" runat="server" Text="取消确认"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlOrderInvalidated" runat="server" Text="订单作废"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlSuspendHandleOrder" runat="server" Text="暂停处理"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlResumeNormal" runat="server" Text="恢复正常"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlBankPayment" runat="server" Text="银行汇款支付"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlFuturePayment" runat="server" Text="预付款支付"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlCash" runat="server" Text="现金支付"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlRefundment" runat="server" Text="退款"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlConsignment" runat="server" Text="发货"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlReturned" runat="server" Text="客户退货"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlSquare" runat="server" Text="结清订单"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlSign" runat="server" Text="客户已签收"></asp:HyperLink></li>
            <li><img src="../images/mune.gif"/>&nbsp;<asp:HyperLink id="hlDel" runat="server" Text="删除该订单"></asp:HyperLink></li>
           
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="TabTitle0" class="titlemouseover" onclick="ShowTabs(0,5)">订单信息</td>
            <td id="TabTitle1" class="tabtitle" onclick="ShowTabs(1,5)">付款信息</td>
            <td id="TabTitle2" class="tabtitle" onclick="ShowTabs(2,5)">发退货记录</td>
            <td id="TabTitle3" class="tabtitle" onclick="ShowTabs(3,5)">过户记录</td>
            <td id="TabTitle4" class="tabtitle" onclick="ShowTabs(4,5)">反馈记录</td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
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
                <asp:Label ID="lbConsigneeName" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">联系电话：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneeTel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">收货人地址：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneeAddress" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">邮政编码：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneeZip" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">收货人邮箱：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneeEmail" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">收货人手机：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneeModile" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">付款方式：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbPaymentMode" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">送货方式：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbDeliveryMode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">标志建筑：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConstructionSigns" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">最佳送货时间：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbConsigneTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row"><img src="../images/notice.gif" title="订单金额=商品总价+运费+支付手续费" />订单金额：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbOrderTotalPrice" runat="server"></asp:Label>
            </td>
            <td class="form_text_row">运费：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbCarriage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="form_text_row">已付金额：</td>
            <td class="form_ctrl_row">
                <asp:Label ID="lbpaid" runat="server"></asp:Label>
            </td>
            <td class="form_text_row"></td>
            <td class="form_ctrl_row">
               
            </td>
        </tr>
    </table>
    <asp:Literal ID="litData" runat="server"></asp:Literal>
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
   <asp:Literal ID="lblOrderLeaveList" runat="server"></asp:Literal>

</div>
</td>
</tr>
</table>
</asp:Content>