<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe.aspx.cs" Inherits="ShowShop.Web.admin.include.iframe" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <script language="JavaScript" type="text/javascript" src="../scripts/prototype.js"></script>
    <script language="JavaScript" type="text/javascript" src="../scripts/public.js"></script>
    
</head>
<body>
<div onmousedown="drag(event,$('s_id'));" style="cursor:move; border:solid 1px #B4C9C6">
    <table style="width:100%" cellpadding="0" cellspacing="0" style="background-color:#ECEEE9;">
        <tr>
            <td style="height:26px;">
                <font color="#418B96" style="font-weight:bold;">窗口可拖动;双击此处关闭窗口;列表处双击选择文件</font>
            </td>
        </tr>
    </table>
 </div>
<div id="select_iframe" runat="server" style="border:solid 1px #B4C9C6" />
</body>
</html>
