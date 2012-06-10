<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/admin/admin_page.master"  CodeBehind="leaveword_reply.aspx.cs" Inherits="ShowShop.Web.admin.accessories.leaveword_reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">留言回复
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    <asp:LinkButton ID="lbtnSave" runat="server" onclick="lbtnSave_Click">保存回复内容</asp:LinkButton>&nbsp;
    <asp:HyperLink ID="returnLink" runat="server" NavigateUrl="~/admin/accessories/leaveword_list.aspx">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">留言标题：</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" CssClass="long_input"></asp:TextBox>
        </td>
        <td>
            <div class="msgNormal">留言的标题</div>  
        </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">留言内容：</td>
       <td>
          <asp:TextBox ID="txtContent" runat="server" MaxLength="500"  
               TextMode="MultiLine" Height="80px"></asp:TextBox>
       </td>
       <td>
           <div class="msgNormal">留言的内容</div>      
       </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">是否回复：</td>
        <td>
            <asp:RadioButtonList ID="rabIsReply" RepeatLayout="Flow" RepeatColumns="2"  runat="server">
               <asp:ListItem Value="1" Text="是" Selected="True"></asp:ListItem>
               <asp:ListItem Value="0" Text="否"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
           <div class="msgNormal">选择是否是已回复状态</div>      
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">回复内容：</td>
       <td>
          <asp:TextBox ID="txtReplyContent" runat="server" MaxLength="500"  TextMode="MultiLine"
            Height="80px"></asp:TextBox>
       </td>
       <td>
           <div class="msgNormal">请输入回复的内容</div>      
       </td>
    </tr>
</table>   
</asp:Content>
