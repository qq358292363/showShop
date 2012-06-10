<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="admin_list.aspx.cs" Inherits="ShowShop.Web.admin.member.admin_list" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript">
        function GetStat(stat)
        {
            if(stat=="1")
            {
                document.write("是");
            }else
            {
                document.write("否");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">管理员管理
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="admin_edit.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">添加管理员</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">管理员信息管理,其中ADMIN帐号已被系统保护，无法删除。

帐号名称：<asp:TextBox ID="w_l_Name" runat="server"></asp:TextBox>
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Literal ID="ltlView" EnableViewState="false" runat="server"></asp:Literal>
</asp:Content>
