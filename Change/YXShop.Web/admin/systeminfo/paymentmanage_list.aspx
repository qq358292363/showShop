<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="paymentmanage_list.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.paymentmanage_list" %>

<asp:Content ID="payContentHead" runat="server" ContentPlaceHolderID="head">
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
        new Ajax.Request('paymentmanage_list.aspx', options);
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
        new Ajax.Request('paymentmanage_list.aspx', options);
    }
</script>
</asp:Content>
<asp:Content ID="payContentTitel" runat="server" ContentPlaceHolderID="pagetitle">
支付平台管理
    <asp:HyperLink ID="Link"  runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">添加支付</asp:HyperLink>
</asp:Content>
<asp:Content ID="payContentMain" runat="server" ContentPlaceHolderID="pageinfo">
平台名称：<asp:TextBox ID="w_l_payment_name" runat="server"></asp:TextBox>发布类型：<asp:DropDownList ID="w_l_payment_putouttypeid" runat="server" CssClass="form_table_input_info"></asp:DropDownList>
发布人：<asp:TextBox ID="txtPerson" runat="server"></asp:TextBox>
    <asp:Button ID="btnSelect" runat="server" CssClass="inputbutton" onclick="btnSelect_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>

</asp:Content>
<asp:Content ID="payContentSarch" ContentPlaceHolderID="pagesarch" runat="server">
<a href="#"  onclick="DelAll(-1)">批量删除</a>
</asp:Content>
<asp:Content ID="payContentWorkspace" runat="server" ContentPlaceHolderID="workspace">
<asp:Literal ID="litPay" runat="server"></asp:Literal>
</asp:Content>
