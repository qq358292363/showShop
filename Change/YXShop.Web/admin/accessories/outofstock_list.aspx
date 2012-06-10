<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/admin/admin_page.master" CodeBehind="outofstock_list.aspx.cs" Inherits="ShowShop.Web.admin.accessories.outofstock_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function Del(id)
    { 
       var idStr;
       if(id<0)
       {
            idStr = GetAllChecked();
            if(idStr == "")
            {
                alert("您没有选择要删除的信息!");
                return;
            }
       }
       else
       {
           idStr=id
       }
       if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
       {
            var param = "Option=del&id=" + idStr;
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
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('outofstock_list.aspx', options);
    }
    </script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">缺货登记管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="pagesarch" ID="ContentSearch" runat="server">
联系人名称：  
    <asp:TextBox ID="w_l_username"  runat="server"></asp:TextBox>
    <asp:Button ID="butSearch" runat="server" CssClass="inputbutton" onclick="lbtnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="#"  onclick="Del(-1)" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>