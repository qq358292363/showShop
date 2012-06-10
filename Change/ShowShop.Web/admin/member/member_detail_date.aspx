<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_detail_date.aspx.cs" Inherits="ShowShop.Web.admin.member.member_detail_date" %>

<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
 <link rel="stylesheet" href="../style/admin.css" type="text/css" /> 
 <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">有效期记录</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo">
起始日期：<asp:TextBox ID="txtStartTime" CssClass="date_input" runat="server"></asp:TextBox>结束日期：<asp:TextBox ID="txtEndTime" CssClass="date_input" runat="server"></asp:TextBox>用户名称：<asp:TextBox ID="txtName" CssClass="Long_input" runat="server"></asp:TextBox> 
        <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="btnSelect_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="ContSarch" ContentPlaceHolderID="pagesarch" runat="server">
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
              <div class="msgNormal">如果有效期明细记录太多，影响了系统性能，可以删除一定时间段前的记录以加快速度。<br />但可能会带来会员在查看以前收过费的信息时重复收费（这样会引发众多消费纠纷问题），无法通过有效期明细记录来真实分析会员的消费习惯等问题！</div>
            </td>
        </tr>
    </table>
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
   <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Literal ID="LitDate" runat="server"></asp:Literal>
</asp:Content>