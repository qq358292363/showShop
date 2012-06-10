<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="pseudo_static_edit.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.pseudo_static_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">伪静态度规则
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加伪静态度规则&nbsp; 
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="bt_add_Click">保存</asp:LinkButton>
&nbsp;<asp:HyperLink ID="returnLink" runat="server" NavigateUrl="~/admin/systeminfo/pseudo_static_list.aspx">返回</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
            <td class="form_table_input_info">名 称</td>
            <td>
                <asp:TextBox ID="tb_name" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="tb_nameTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="form_table_input_info">后缀名称</td>
            <td>
                <asp:DropDownList ID="DDL_Lastname" runat="server" Height="22px" Width="268px">
                    <asp:ListItem Selected="True">.aspx</asp:ListItem>
                    <asp:ListItem>.htm</asp:ListItem>
                    <asp:ListItem>.html</asp:ListItem>
                    <asp:ListItem>.shtm</asp:ListItem>
                    <asp:ListItem>.shtml</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
               &nbsp;
            </td>
        </tr>
        <tr>
            <td class="form_table_input_info">虚拟地址</td>
            <td>
                <asp:TextBox ID="tb_path" runat="server" Width="271px"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="tb_pathTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td  class="form_table_input_info">虚拟规则</td>
            <td>
                <asp:TextBox ID="tb_pattern" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="tb_patternTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="form_table_input_info">
                真实地址</td>
            <td>
                <asp:TextBox ID="tb_page" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="tb_pageTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="form_table_input_info">
                传值方式
            </td>
            <td>
                <asp:TextBox ID="tb_query" runat="server" Width="270px"></asp:TextBox>
            </td>
            <td>
                <asp:Panel ID="tb_queryTip" runat="server">
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
