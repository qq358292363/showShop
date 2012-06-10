<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="product_back_list.aspx.cs" Inherits="ShowShop.Web.admin.product.product_back_list" %>
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
        new Ajax.Request('product_back_list.aspx', options);
    }
    
    </script>
    <script src="../scripts/images.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 78px;
        }
        .style2
        {
            width: 107px;
        }
        .style3
        {
            width: 59px;
        }
        .style4
        {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
发退货信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="pagesarch" ID="ContentSearch" runat="server">
    <table border="0" cellspacing="1" cellpadding="1" width="100%">
    <tr>
        <td>客户名称： <asp:TextBox ID="w_l_username" CssClass="date_input" runat="server" 
                Width="98px"></asp:TextBox>
        </td>
        <td>订单号：<asp:TextBox ID="w_l_orderid" CssClass="date_input" runat="server" 
                Width="98px"></asp:TextBox></td>
        <td class="style3">类型：</td>
        <td class="style4">
            <asp:DropDownList ID="w_d_consignmenttype" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="">--不限类别--</asp:ListItem>
                <asp:ListItem Value="1">退货信息</asp:ListItem>
                <asp:ListItem Value="0">发货信息</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td><asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="btnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/></td>
    </tr>
</table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="#" onclick="Del(-1)" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>