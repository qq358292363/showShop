<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="order_order_list.aspx.cs" Inherits="ShowShop.Web.admin.order.order_order_list" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript">
    function SelectAll(tempControl)
    {
          var theBox=tempControl;
          xState=theBox.checked;    
          elem=theBox.form.elements;
          for(i=0;i<elem.length;i++)
          if(elem[i].type=='checkbox' && elem[i].id!=theBox.id)
          {
            if(elem[i].checked!=xState)
               elem[i].click();
                            
          }
    } 
    
    function DelAll(id)
    { 
       var idStr;
       if(id<0)
       {
            idStr = GetAllChecked();
            if(idStr == "")
            {
                alert("您没有选择要删除的信息!");
                return;
            }
       }
       else
       {
           idStr=id
       }
       if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
       {
             SendAjax("del",idStr);
       }
    }
    
    function SendAjax(op,id)
    {
        var param = "Option="+ op +"&id="+ id;
        var options={
            method:'post',
            parameters:param,
            onComplete:
            function(transport)
	        {
	          var retv=transport.responseText;
	          if(retv=="no")
	          {
	           alert("对不起，你没有删除权限！");
	          }
	          else
	          {
		      window.location.reload();
		      }
		    }     

	      }
	    new  Ajax.Request("order_order_list.aspx",options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
    订单管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
订单列表信息&nbsp;&nbsp;订单号：<asp:TextBox ID="w_l_OrderId" runat="server"></asp:TextBox>&nbsp;
用户名：<asp:TextBox ID="w_l_UserId" runat="server" Width="50px"></asp:TextBox>&nbsp;
收货人：<asp:TextBox ID="w_l_ConsigneeName" runat="server" Width="50px"></asp:TextBox>&nbsp;
订单类型：
<asp:DropDownList ID="w_d_OrderType" runat="server">
    <asp:ListItem Value="0">普通订单</asp:ListItem>
    <asp:ListItem Value="1">拍卖转成的订单</asp:ListItem>
    <asp:ListItem Value="2">团购转成的订单</asp:ListItem>
</asp:DropDownList>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagesarch" runat="server">

订单状态：
<asp:DropDownList ID="w_d_OrderStatus" runat="server">
    <asp:ListItem Value="">选择订单状态</asp:ListItem>
    <asp:ListItem Value="0">等待处理</asp:ListItem>
    <asp:ListItem Value="1">暂停处理</asp:ListItem>
    <asp:ListItem Value="2">已经确认</asp:ListItem>
    <asp:ListItem Value="3">末确认</asp:ListItem>
    <asp:ListItem Value="4">未结清</asp:ListItem>
    <asp:ListItem Value="5">已结清</asp:ListItem>
    <asp:ListItem Value="6">取消</asp:ListItem>
    <asp:ListItem Value="7">已经作废</asp:ListItem>
</asp:DropDownList>&nbsp;
付款状态：
<asp:DropDownList ID="w_d_PaymentStatus" runat="server">
    <asp:ListItem Value="">选择付款状态</asp:ListItem>
    <asp:ListItem Value="0">等待汇款</asp:ListItem>
    <asp:ListItem Value="1">已经付清</asp:ListItem>
    <asp:ListItem Value="2">未付清</asp:ListItem>
    <asp:ListItem Value="3">已收定金</asp:ListItem>
</asp:DropDownList>&nbsp;
物流状态：
<asp:DropDownList ID="w_d_OgisticsStatus" runat="server">
    <asp:ListItem Value="">选择物流状态</asp:ListItem>
    <asp:ListItem Value="0">配送中</asp:ListItem>
    <asp:ListItem Value="1">已发货</asp:ListItem>
    <asp:ListItem Value="2">已签收</asp:ListItem>
    <asp:ListItem Value="3">未送货</asp:ListItem>
</asp:DropDownList>&nbsp;
下单时间：<asp:TextBox ID="w_g_OrderDate" CssClass="date_input" runat="server"></asp:TextBox>
<asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="btnOk_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">
    <asp:Literal ID="ltlView" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="ContentBottomInfo" runat="server" ContentPlaceHolderID="pagebottom">
<asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="javascript:DelAll(-1)" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>
