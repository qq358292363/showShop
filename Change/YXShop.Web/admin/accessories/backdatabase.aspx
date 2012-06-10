<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="backdatabase.aspx.cs" Inherits="ShowShop.Web.admin.accessories.backdatabase" %>

<asp:Content ID="backdatabaseHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script language="javascript">
     //删除文件
    function DelFile(FilePath)
    { 
       if(confirm('确定要永久删除该文件吗?删除后将不能被恢复!'))
       {
            var param = "Option=delFile&path=" + FilePath;
            var options = 
            { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv=="ok")
                     {
                         window.location.reload();
                     }
                     else
                     {
                         alert(retv);
                     }
                 }
            }
        }
        
        new Ajax.Request('backdatabase.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="backdatabaseTitel" runat="server" ContentPlaceHolderID="pagetitle">
数据库备份
</asp:Content>
<asp:Content ID="backdatabaseInfo" runat="server" ContentPlaceHolderID="pageinfo">
数据库备份列表<br />
&nbsp;&nbsp;&nbsp;&nbsp;数据库备份是把数据库备份成文件保存，以便系统损坏时或重构系统时，重新恢复数据库。本系统提供的备份功能建议作为数据库备份的辅助工具。建议使用数据库系统提供的备份功能。 
<br />&nbsp;&nbsp;&nbsp;&nbsp;在系统作数据清理时，或操作会影响大量数据的功能前，强烈建议先备份数据库。
</asp:Content>
<asp:Content ID="backdatabaseMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Literal ID="litBackDataBase" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="ContBottom" runat="server" ContentPlaceHolderID="pagebottom">
<asp:Button ID="button" runat="server" CssClass="inputbutton"  OnClick="btnBackDataBase_Click"  Text="开始备份" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
