<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_comment_revert.aspx.cs" Inherits="ShowShop.Web.admin.product.product_comment_revert" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
<script type="text/javascript" src="../scripts/validate.js"></script>
<link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
<script src="../scripts/public.js" type="text/javascript"></script>
<script language="javascript">
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
                     window.location.reload();
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('product_comment_revert.aspx', options);
    }
</script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
商品评论回复
 <asp:HyperLink ID="returnLink" NavigateUrl="~/admin/product/product_comment_list.aspx" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回</asp:HyperLink>
    <asp:Button ID="btnSarch" runat="server" CssClass="inputbutton" Text="回复" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'" 
        onclick="butSave_Click" />
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
  <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
<tr>
  <td class="form_table_input_info">评论标题：</td>
  <td><asp:Literal ID="litName" runat="server"></asp:Literal></td>
  <td><div class="msgNormal">标题</div></td>
</tr>
<tr>
<td class="form_table_input_info">回复内容：</td>
<td><asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine"></asp:TextBox></td>
<td><asp:Panel ID="txtReplyTip" runat="server"></asp:Panel></td>
</tr>
</table>
<br />
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>