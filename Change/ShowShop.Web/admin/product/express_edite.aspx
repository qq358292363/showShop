<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="express_edite.aspx.cs" Inherits="ShowShop.Web.admin.product.express_edite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
添加/编辑快递公司
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="express_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">名称：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" MaxLength="12"></asp:TextBox>
        </td>
        <td>
            <asp:Panel ID="txtNameTip" runat="server"></asp:Panel>
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">公司全称：</td>
        <td>
           <asp:TextBox ID="txtFullName" runat="server"  MaxLength="25" CssClass="long_input"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtFullNameTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">地址：</td>
        <td>
           <asp:TextBox ID="txtAddress" runat="server"  MaxLength="100"  CssClass="long_input"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtAddressTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">联系电话：</td>
        <td>
           <asp:TextBox ID="txtPhone" runat="server"  MaxLength="15"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtPhoneTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">联系人：</td>
        <td>
           <asp:TextBox ID="txtPerson" runat="server" MaxLength="20"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtPersonTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">类别排序：</td>
       <td>
           <asp:TextBox ID="txtSort" runat="server" Width="50" Text="0" MaxLength="10"></asp:TextBox>
       </td>
       <td>
           <asp:Panel ID="txtSortTip" runat="server"></asp:Panel>
       </td>
    </tr>  
</table>   
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="express_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>