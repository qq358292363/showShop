<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="exesql.aspx.cs" Inherits="ShowShop.Web.admin.accessories.exesql" %>

<asp:Content ID="exeSqlHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="exeSqlTitel" runat="server" ContentPlaceHolderID="pagetitle">
执行SQL语句
</asp:Content>
<asp:Content ID="exeSqlInfo" runat="server" ContentPlaceHolderID="pageinfo">
<strong>执行SQL语句请慎重</strong><br />
&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red;">执行SQL语句之前请做好数据库备份，以便执行SQL语句出错，进行数据恢复。</span>
</asp:Content>
<asp:Content ID="exeSqlMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
<table border="0" width="100%">
    <tr>
        <td>
            <asp:TextBox ID="txtExeSql" runat="server" TextMode="MultiLine" Height="269px" 
                Width="622px" ></asp:TextBox></td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="ContBottom" runat="server" ContentPlaceHolderID="pagebottom">
<asp:Button ID="butExeSql" runat="server" CssClass="inputbutton" Enabled="false"  Text="执行" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'" 
        onclick="butExeSql_Click"/>
</asp:Content>