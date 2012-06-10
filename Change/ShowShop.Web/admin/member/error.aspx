<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="ShowShop.Web.admin.member.error" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
操作失败
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<table  width="350" cellpadding="1" cellspacing="3" border="0"  align="center" style="margin-top:30px">
        <tr>
            <td align="center">
                <table width="100%" cellspacing="0" align="center" bgcolor="white">
                    <tr>
                        <td>
                            </td>
                    </tr>
                    <tr>
                       <td colspan="2"><asp:Label ID="Label2" runat="server" Text="错误信息"></asp:Label></td>
                    </tr>
                    <tr>
                        <td height="100px">
                         <span style="color:Red"> 产生错误的可能原因：</span> <br /><br /><%=Key %></td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="F0F5FB"></td>
                    </tr>
                    <tr>
                        <td height="22px">
                         <a href="javascript:window.history.back()">【返回上一页】</a></td>
                    </tr>
                </table>
            </td>
        </tr>
 </table>
</asp:Content>