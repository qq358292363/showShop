<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="capital_rest.aspx.cs" Inherits="ShowShop.Web.admin.member.capital_rest" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
   <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
其他资金明细管理
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
会员名称：  
    <asp:TextBox  ID="w_l_userName"  runat="server" ></asp:TextBox>
记录日期：
     <asp:TextBox  ID="w_d_noteDate"  runat="server" CssClass="date_input"></asp:TextBox>
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Literal ID="litMain" runat="server"></asp:Literal>
<asp:Literal ID="litFund" runat="server"></asp:Literal>
</asp:Content>