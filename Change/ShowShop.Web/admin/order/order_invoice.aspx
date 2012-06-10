<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master"  CodeBehind="order_invoice.aspx.cs" Inherits="ShowShop.Web.admin.order.order_invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
开发票
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存发票信息</asp:LinkButton>&nbsp;
   <a href="javascript:;" title="返回" onclick="javascript:window.history.back()">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">客户名称：</td>
        <td>
            <asp:Literal ID="lblUserId" runat="server"></asp:Literal>
        </td>
        <td>
            <div class="msgNormal">订单所属的客户</div>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">用户名：</td>
        <td>
            <asp:Literal ID="lblUserName" runat="server"></asp:Literal>                
        </td>
        <td>
            <div class="msgNormal">订单所属的用户名</div>      
        </td>
    </tr>
     
    <tr>
       <td class="form_table_input_info">订单编号：</td>
       <td>
           <asp:Literal ID="lblOrderId" runat="server"></asp:Literal>   
       </td>
       <td>
           <div class="msgNormal">该订单的编号</div>   
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">订单金额：</td>
        <td>
            <asp:Literal ID="lblMoneyCount" runat="server"></asp:Literal>  
        </td>
        <td>
           <div class="msgNormal">该订单的金额总和</div> 
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">已付款：</td>
        <td>
            <asp:Literal ID="lblMoneyPayed" runat="server"></asp:Literal>  
        </td>
        <td>
           <div class="msgNormal">该订单已经支付的金额</div> 
       </td>
    </tr>
     
    <tr>
       <td class="form_table_input_info">开票日期：</td>
       <td>
          <asp:TextBox ID="txtInvoicedDate" runat="server" CssClass="date_input"></asp:TextBox>
       </td>
       <td>
           <div class="msgNormal">请选择开发票的日期</div>      
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">发票类型：</td>
       <td>
           <asp:DropDownList ID="ddlInvoiceType" runat="server">
           </asp:DropDownList>
       </td>
       <td>
           <div class="msgNormal">请选择发票的类型</div>        
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">发票号码：</td>
       <td>
          <asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtInvoiceNumberTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">发票抬头：</td>
       <td>
          <asp:TextBox ID="txtInvoiceRise" runat="server"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtInvoiceRiseTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">发票内容：</td>
        <td>
            <asp:TextBox ID="txtInvoiceContent" runat="server" TextMode="MultiLine" Height="50px"  CssClass="long_input"></asp:TextBox>
        </td>
        <td>
           <asp:Panel ID="txtInvoiceContentTip" runat="server"></asp:Panel> 
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">发票金额：</td>
       <td>
          <asp:TextBox ID="txtInvoiceMoney"  runat="server"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtInvoiceMoneyTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">开票人：</td>
       <td>
          <asp:TextBox ID="txtInvoiceName"  runat="server"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtInvoiceNameTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">备注：</td>
        <td>
            <asp:TextBox ID="txtRemark" runat="server"  CssClass="long_input"></asp:TextBox>
        </td>
        <td>
           <asp:Panel ID="txtRemarkTip" runat="server"></asp:Panel> 
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">内部信息：</td>
        <td>
            <asp:TextBox ID="txtBosomNote" runat="server" TextMode="MultiLine" Height="50px"  CssClass="long_input"></asp:TextBox>
        </td>
        <td>
           <asp:Panel ID="txtBosomNoteTip" runat="server"></asp:Panel> 
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">通知会员：</td>
        <td>
            <asp:CheckBoxList ID="cbxInformMode" runat="server">
            <asp:ListItem Value="0">同时使用站内短信通知会员已经开发票</asp:ListItem>
            <asp:ListItem Value="1">同时使用Email通知会员已经开发票<</asp:ListItem>
            <asp:ListItem Value="2">同时使用Email通知收货人已经开发票<</asp:ListItem>
            </asp:CheckBoxList>
        </td>
        <td>
           <div class="msgNormal">请选择确定后通知会员的方式</div> 
       </td>
    </tr>
</table>   
</asp:Content>
