<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="productclass_list.aspx.cs" Inherits="ShowShop.Web.admin.product.productclass_list" %>

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
                     if(retv!="")
                     {
                          if(retv=="no")
                          {
                          alert("对不起，你没有删除权限！");
                          }
                          else
                          {       
                         alert(retv);
                         }
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
        new Ajax.Request('productclass_list.aspx', options);
    }
    
    function Sort(id)
    {
        var sort=$("sort"+id).value;
        var num="^[0-9]*[1-9][0-9]*$";
        if(sort.search(num)!=0)
        {
          return false;
        }
        var param = "Option=sort&sort="+sort+"&id=" + id;
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
                  alert("对不起，你没有编辑权限！");
                 }
             }
        }
        new Ajax.Request('productclass_list.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品分类管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
您现在的位置是：<asp:Literal ID="tool" runat="server"></asp:Literal> <br />
   
</asp:Content>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="pagesarch" runat="server">
分类名称：  
    <asp:TextBox ID="w_l_name" runat="server"></asp:TextBox>
    <asp:Button ID="butSearch" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>