<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="coupons_record_list.aspx.cs" Inherits="ShowShop.Web.admin.member.coupons_record_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
会员点卷明细
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
   会员名称：<asp:TextBox  ID="w_l_userid"  runat="server"></asp:TextBox>
            <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="lbtnSearch_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="pagesarch" runat="server">
 <table width="100%" border="0" class="form_table_input">      
        <tr>
            <td align="center">
                时间范围：<asp:RadioButtonList ID="radTime" runat="server" RepeatDirection="Horizontal">
             <asp:ListItem  Text="10天前" Value="0" Selected="True"></asp:ListItem>
             <asp:ListItem Text="1月前" Value="1"  ></asp:ListItem>
             <asp:ListItem Text="2月前" Value="2"  ></asp:ListItem>
             <asp:ListItem Text="3月前" Value="3"  ></asp:ListItem>
             <asp:ListItem Text="6月前" Value="4"  ></asp:ListItem>
             <asp:ListItem Text="1年前" Value="5"  ></asp:ListItem>
             </asp:RadioButtonList>
                <asp:Button ID="BtnDel" runat="server" Text="删除" Width="65px" 
                    onclick="BtnDel_Click" />
            </td>
            <td>
              <div class="msgNormal">如果点卷明细记录太多，影响了系统性能，可以删除一定时间段前的记录以加快速度。<br />但可能会带来会员在查看以前收过费的信息时重复收费（这样会引发众多消费纠纷问题），无法通过有效期明细记录来真实分析会员的消费习惯等问题！</div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Literal ID="lblList" runat="server"></asp:Literal>
<asp:Literal ID="lblCount" runat="server"></asp:Literal>
</asp:Content>
