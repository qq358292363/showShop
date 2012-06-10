﻿<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="productunit_list.aspx.cs" Inherits="ShowShop.Web.admin.product.productunit_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script language="javascript" type="text/javascript">
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
                     if(retv=="ok")
                     {
                         window.location.reload();
                     }
                     else if(retv=="no")
                     {
                      alert("对不起，你没有删除权限！");
                     }
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('productunit_list.aspx', options);
    }
    
    </script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品单位
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="productunit_edit.aspx" Text="添加单位" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"></asp:HyperLink>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">商品单位管理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<div id="Layer1" style="display:none;position:absolute;z-index:1;"></div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>