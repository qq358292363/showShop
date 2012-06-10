<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master"  CodeBehind="userinandexp_list.aspx.cs" Inherits="ShowShop.Web.admin.member.userinandexp_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
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
                         window.location.href=window.location.href;
                     }
                 }
            }
        }
        else
        {
            return false;
        }
        new Ajax.Request('userinandexp_list.aspx', options);
    }
    
    function SetState(id)
    {
        var param = "Option=SetState&id=" + id;
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
                  alert("对不起，你没有编辑权限！");
                 }
             }
        }
        new Ajax.Request('userinandexp_list.aspx', options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
银行资金明细管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
   
</asp:Content>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="pagesarch" runat="server">
会员名称：  
    <asp:TextBox  ID="w_l_userid"  runat="server"></asp:TextBox>
到款日期：
     <asp:TextBox  ID="w_d_adsummoneydate"  runat="server"></asp:TextBox>
        <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
<asp:Literal ID="lblCount" runat="server"></asp:Literal>
</asp:Content>
