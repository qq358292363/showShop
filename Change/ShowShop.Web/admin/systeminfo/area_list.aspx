<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="area_list.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.area_list" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script language="javascript" type="text/javascript">
    function Del(id)
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
                     else if(retv=="no")
                     {
                      alert("对不起，你没有删除权限！");
                     }
                 }
            }
        
        new Ajax.Request('area_list.aspx', options);
    }
    
    function SetSort(id)
    {
        var sortid=$("txtSort"+id).value;
        var num="^[0-9]*[1-9][0-9]*$";
        if(sortid.search(num)!=0)
        {
          return false;
        }
        var param = "Option=sort&SortID="+sortid+"&id=" + id;
        var options = 
        { method: 'post',parameters: param,onComplete:
             function(transport)
             {
                 var retv = transport.responseText;
                 if(retv=="ok")
                 {
                    window.location.href=window.location.href;
                 }
                 else if (retv=="no")
                 {
                  alert("对不起，你没有编辑权限！");
                 }
             }
        }
        new Ajax.Request('deliver_list.aspx', options);
    }
    
    function SetIsUser(id)
    {
        var param = "Option=isuse&id=" + id;
        var options = 
        { method: 'post',parameters: param,onComplete:
             function(transport)
             {
                 var retv = transport.responseText;
                 if(retv=="ok")
                 {
                    window.location.href=window.location.href;
                 }
                 else if (retv=="no")
                 {
                  alert("对不起，你没有编辑权限！");
                 }
             }
        }
        new Ajax.Request('deliver_list.aspx', options);
    }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
设置区域管理
<asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" 
          Height="24px" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">添加区域</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" 
        NavigateUrl="deliver_list.aspx"  Height="24px" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="pagesarch" runat="server">
名称：  <asp:TextBox ID="w_l_AreaName"  runat="server"></asp:TextBox>&nbsp;
        <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
</asp:Content>

