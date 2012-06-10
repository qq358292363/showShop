<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="area_setting.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.area_setting" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript">
    function Sort()
    {
        window.location.reload();
    }
    
    function DelArea(id)
    { 
       if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
       {
            var param = "Option=del&id=" + id;
            var options = 
            { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv=="ok")
                     {
                         window.location.href=window.location.href;
                     }
                     else if(retv=="no")
                     {
                      alert("对不起，你没有删除权限！");
                     }
                     else
                     {
                         alert(retv);
                     }
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('area_setting.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">地区分站配置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">您现在的位置是：<asp:Literal ID="tool" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
