<%@ Page Language="C#"  MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="advertise_createjs.aspx.cs" Inherits="ShowShop.Web.admin.accessories.advertise_createjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
<!-- Hide

function killErrors() {
return true;
}

window.onerror = killErrors;

// -->
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
生成广告JS
<asp:HyperLink ID="returnLink" runat="server" NavigateUrl="~/admin/accessories/advertise_list.aspx"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
<br />

</asp:Content>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="pagesarch" runat="server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
</asp:Content>
