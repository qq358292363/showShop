<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_comment_list.aspx.cs" Inherits="ShowShop.Web.admin.product.product_comment_list" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
 <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
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
        new Ajax.Request('product_comment_list.aspx', options);
    }
function SelectAll(tempControl)
{
      var theBox=tempControl;
      xState=theBox.checked;    
      elem=theBox.form.elements;
      for(i=0;i<elem.length;i++)
      if(elem[i].type=='checkbox' && elem[i].id!=theBox.id)
      {
        if(elem[i].checked!=xState)
           elem[i].click();
                        
      }
}   

 function DelAll(id)
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
            var param = "Option=delAll&id=" + idStr;
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
        new Ajax.Request('product_comment_list.aspx', options);
    }
</script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
商品点评管理
</asp:Content>
<asp:Content ID="ContSarch" runat="server" ContentPlaceHolderID="pagesarch">
评论标题：
<asp:TextBox ID="w_l_title" runat="server"></asp:TextBox>
<asp:DropDownList ID="w_d_type" runat="server">
    <asp:ListItem Value="">所有点评</asp:ListItem>
    <asp:ListItem Value="1">商品点评</asp:ListItem>
    <asp:ListItem Value="2">店铺点评</asp:ListItem>
</asp:DropDownList>
<asp:Button ID="butSearch" runat="server" CssClass="inputbutton"  Text="查  询" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'" 
        onclick="butSearch_Click"/>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="#"  onclick="DelAll(-1)" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">批量删除</asp:HyperLink>
</asp:Content>