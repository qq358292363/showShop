<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importfile.aspx.cs" Inherits="ShowShop.Web.admin.accessories.importfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/jscript">
    function dd()
    {
       document.getElementById("path").value=parent.repath();
    }
    function colse()
    {
       parent.closedivreload();
    }
    
    </script>
</head>
<body onload="dd()">
    <form id="form1" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    <div>
        <table  class="page_toolbar" border="0" width="100%" cellspacing="0" cellpadding="0">
             <tr>
                 <td class="form_table_input">上传文件：</td>
             </tr>
             <tr>
                 <td>
                     <asp:HiddenField ID="path" runat="server" />
                     <asp:FileUpload ID="fufile" runat="server" />
                     <asp:Button ID="butUpFile" runat="server" Text="上传" onclick="butUpFile_Click" />
                     <asp:Button ID="but" runat="server" Text="关闭" OnClientClick="colse()"/>
                 </td>
             </tr>
        </table>
    </div>
    </form>
</body>
</html>
