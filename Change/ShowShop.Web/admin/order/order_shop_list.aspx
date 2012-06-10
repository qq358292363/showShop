<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="order_shop_list.aspx.cs" Inherits="ShowShop.Web.admin.order.order_shop_list" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript">
    function Del(id)
    { 
       if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
       {
            var param = "Option=del&id=" + id;
            var options = 
            { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv=="no")
                     {
                     alert("对不起，你没有删除权限！");
                     }
                     else
                     {
                     window.location.reload();
                     }
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('order_shop_list.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">购物车信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    用户：<asp:TextBox  ID="w_l_username" runat="server"></asp:TextBox>
    &nbsp;时间大于：<asp:TextBox CssClass="date_input" ID="w_g_lastupdateddate"  runat="server"></asp:TextBox>
    &nbsp;
    时间大于：<asp:TextBox CssClass="date_input" ID="w_e_lastupdateddate"  runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pagesarch" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="workspace" runat="server">
    <asp:Literal ID="ltlList" runat="server"></asp:Literal>
</asp:Content>
