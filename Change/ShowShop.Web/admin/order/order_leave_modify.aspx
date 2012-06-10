<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master"  CodeBehind="order_leave_modify.aspx.cs" Inherits="ShowShop.Web.admin.order.order_leave_modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
编辑订单反馈信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存</asp:LinkButton>&nbsp;
    <a href="javascript:;" title="返回" onclick="javascript:window.history.back()">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">用户名：</td>
        <td>
            <asp:Literal ID="lblMemberId" runat="server"></asp:Literal>    
        </td>
        <td>
            <div class="msgNormal">反馈人的账号</div>
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">发表时间：</td>
        <td>
            <asp:Literal ID="lblCreateDate" runat="server"></asp:Literal>        
        </td>
        <td>
            <div class="msgNormal">该反馈发表的时间</div>
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">反馈内容：</td>
        <td>
            <asp:TextBox ID="txtContent" TextMode="MultiLine" runat="server" 
                MaxLength="180" Height="83px" ></asp:TextBox>              
        </td>
        <td>
            <asp:Panel ID="txtContentTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
</table>   
</asp:Content>
