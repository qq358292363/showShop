<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_list.aspx.cs" Inherits="ShowShop.Web.admin.product.product_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function Delete(id)
    {
        var l;
        if(id < 0)
        {
            l = GetAllChecked();
            if(l == "")
            {
                alert("您没有选择要删除的信息!");
                return;
            }
        }
        else
        {
            l = id;
        }
        if(confirm('确定要永久删除您所选择的信息吗?该信息将不能被恢复!'))
        {
             SendAjax("del",l);
        }
    }
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
        new Ajax.Request('product_list.aspx', options);
    }


    
    </script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品管理
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">商品列表信息
</asp:Content>
<asp:Content ContentPlaceHolderID="pagesarch" ID="ContentSearch" runat="server">
<table border="0" cellspacing="1" cellpadding="1" width="100%">
    <tr>
        <td>
            <!--发布人类型-->
       
            所属分类：
            <asp:TextBox ID="txtProductClass" runat="server" Width="100px" ToolTip="点击选择所属分类"></asp:TextBox>
            <asp:HiddenField runat="server" ID="w_d_pro_CID" />
        <%--    <span runat="server" id="OptionMember">
            选择商家：
            <asp:TextBox ID="txtUserName" runat="server"  Width="50px" ToolTip="点击选择商家"></asp:TextBox>
            <asp:HiddenField runat="server" ID="w_d_pro_PutoutID" />
            </span>--%>
      </td>
    </tr>
    <tr>
        <td><!--商品状态-->
           商品状态: <asp:DropDownList ID="w_s_pro_State" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="">--全部--</asp:ListItem>
                <asp:ListItem Value="1">首页</asp:ListItem>
                <asp:ListItem Value="2">最新</asp:ListItem>
                <asp:ListItem Value="3">推荐</asp:ListItem>
                <asp:ListItem Value="4">特价</asp:ListItem>
                <asp:ListItem Value="5">热卖</asp:ListItem>
            </asp:DropDownList>
            <!--商品品牌-->
            <asp:DropDownList ID="w_d_pro_BrandID" runat="server">
            </asp:DropDownList>
           
           商品名称：
            <asp:TextBox ID="w_l_pro_Name" runat="server"></asp:TextBox>
            <asp:Button ID="butSearch" runat="server" CssClass="inputbutton" onclick="Button1_Click" Text="查询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<div id="Layer1" style="display:none;position:absolute;z-index:1;"></div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#"  onclick="Del(-1)"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>