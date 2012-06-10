<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/admin/admin_page.master"  CodeBehind="leaveword_list.aspx.cs" Inherits="ShowShop.Web.admin.accessories.leaveword_list" %>

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
        new Ajax.Request('leaveword_list.aspx', options);
    }
    
    function SetAudit(id,examid)
    {
        var param = "Option=exam&examid="+examid+"&id=" + id;
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
                     alert("对不起，你没有审核权限！");
                    }
             }
        }
        new Ajax.Request('leaveword_list.aspx', options);
    }
    </script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">留言信息管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<%--<a href="javascript:void(0)" onclick="Del(-1)">批量删除</a>--%>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagesarch" ID="ContentSearch" runat="server">
    <table border="0" cellspacing="1" cellpadding="1" width="100%">
    <tr>
        <td>留言人名称：</td>
        <td>
            <asp:TextBox ID="w_l_username" CssClass="date_input" runat="server"></asp:TextBox>
        </td>
        <td>留言类别：</td>
        <td>
            <asp:DropDownList ID="w_d_type" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="">--不限类别--</asp:ListItem>
                <asp:ListItem Value="1">普通反馈</asp:ListItem>
                <asp:ListItem Value="2">购物投诉</asp:ListItem>
                <asp:ListItem Value="3">询问求购</asp:ListItem>
                <asp:ListItem Value="4">售后咨询</asp:ListItem>
                <asp:ListItem Value="5">加盟合作</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>是否审核：</td>
        <td>
             <asp:DropDownList ID="w_d_isauditing" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="">--不受限制--</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">已审核</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="butSearch" runat="server" CssClass="inputbutton" onclick="btnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
            </td>
    </tr>
</table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="ContBottom" runat="server" ContentPlaceHolderID="pagebottom">
<asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="#"  onclick="Del(-1)" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>
