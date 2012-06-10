<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_specialspecification_list.aspx.cs" Inherits="ShowShop.Web.admin.product.product_specialspecification_list" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server"><asp:Label ID="Spec" runat="server"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton"  Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">可以为每一个规格值上传多张图片
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>