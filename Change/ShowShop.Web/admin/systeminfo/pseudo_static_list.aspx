<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="pseudo_static_list.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.pseudo_static_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/images.js" type="text/javascript"></script>
    <style type="text/css">
    .Title
    {
        color: #000000;
        font-weight: bold;
        height: 24px;
        background-image: url(../images/head_bg.gif);
        cursor: hand;
    }
    .Mian
    {
    	height: 23px;
	    padding-left: 9px;
	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">伪静态规则
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">伪静态规则管理
<a href="pseudo_static_edit.aspx">添加伪静态规则</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:DataGrid ID="DataGrid1" runat="server" s 
            onpageindexchanged="DataGrid1_PageIndexChanged" PageSize="10" Width="100%" 
            oneditcommand="DataGrid1_EditCommand" 
            oncancelcommand="DataGrid1_CancelCommand" 
            onupdatecommand="DataGrid1_UpdateCommand" 
            ondeletecommand="DataGrid1_DeleteCommand" AutoGenerateColumns="False"> 
            <PagerStyle HorizontalAlign="Center" Mode="NumericPages" NextPageText="下一页" 
                PrevPageText="上一页" />
            <ItemStyle BorderColor="White" BorderStyle="Ridge" BorderWidth="1px" 
                CssClass="contentGrid" />
            <Columns>
                
                <asp:BoundColumn DataField="name" HeaderText="名称"></asp:BoundColumn>
                <asp:BoundColumn DataField="path" HeaderText="虚拟地址" ></asp:BoundColumn>
                <asp:BoundColumn DataField="pattern" HeaderText="规则" ></asp:BoundColumn>
                <asp:BoundColumn DataField="page" HeaderText="真实地址" ></asp:BoundColumn>
                <asp:BoundColumn DataField="querystring" HeaderText="传值方式" >
                </asp:BoundColumn>
                
                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" 
                    EditText="编辑" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" 
                    HeaderText="操作">
                <ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
                </asp:EditCommandColumn>

                <asp:ButtonColumn CommandName="delete" Text="删除" HeaderText="删除"></asp:ButtonColumn>

            </Columns>
            <HeaderStyle BorderColor="White" CssClass="Title" BorderWidth="1px"/>
            <ItemStyle CssClass="Mian" />
        </asp:DataGrid>
        <asp:HiddenField ID="hdf_key" runat="server" />
</asp:Content>
