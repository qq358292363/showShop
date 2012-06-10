<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="order_transfer.aspx.cs" Inherits="ShowShop.Web.admin.order.order_transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
订单过户
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存过户信息</asp:LinkButton>&nbsp;
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
            <div class="msgNormal">订单目前所属的客户</div>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">用户名：</td>
        <td>
            <asp:Literal ID="lblUserName" runat="server"></asp:Literal>                
        </td>
        <td>
            <div class="msgNormal">订单目前所属的用户名</div>      
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
       <td class="form_table_input_info">将过户给：</td>
       <td>
          <asp:TextBox ID="txtTransferName" runat="server"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtTransferNameTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">手续费：</td>
       <td>
          <asp:TextBox ID="txtPoundAge" runat="server" Width="50px"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtPoundAgeTip" runat="server"></asp:Panel>   
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">手续费支付者：</td>
       <td>
          <asp:RadioButtonList ID="rabPoundPay" runat="server" RepeatLayout="Flow">
            <asp:ListItem Value="0" Selected="True">订单当前所有者</asp:ListItem>
            <asp:ListItem Value="1">过户对象</asp:ListItem>
          </asp:RadioButtonList>
       </td>
       <td>
           <div class="msgNormal">请选择谁将支付过户手续费</div>  
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
</table>   
</asp:Content>
