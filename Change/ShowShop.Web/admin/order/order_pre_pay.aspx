<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="order_pre_pay.aspx.cs" Inherits="ShowShop.Web.admin.order.order_pre_pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
   <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
预付款支付
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保存信息" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="hlBack" runat="server"  CssClass="inputbutton" NavigateUrl="productbrand_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
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
       <td class="form_table_input_info">支出日期：</td>
       <td>
          <asp:TextBox ID="txtAdsumMoneyDate" runat="server" CssClass="date_input"></asp:TextBox>
       </td>
       <td>
           <div class="msgNormal">请选择支出的日期</div>      
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">支出金额：</td>
       <td>
          <asp:TextBox ID="txtPayoutMoney" runat="server" Width="50px"></asp:TextBox>
          
       </td>
       <td>
           <asp:Panel ID="txtPayoutMoneyTip" runat="server"></asp:Panel>   
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
</table>   
</asp:Content>
