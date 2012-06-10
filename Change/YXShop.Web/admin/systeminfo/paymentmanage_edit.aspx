<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="paymentmanage_edit.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.paymentmanage_edit" %>

<asp:Content ID="ContEditHead" runat="server" ContentPlaceHolderID="head">
<link rel="stylesheet" href="../style/validator.css" type="text/css" />
<script type="text/javascript" src="../scripts/validate.js"></script>
<link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
<script src="../scripts/public.js" type="text/javascript"></script>
 <script type="text/javascript" language="javascript">
 function PayType(t)
 {
 
    var a=t.options[t.selectedIndex].innerText;
    var s;
    var c=t.value;
    switch(c)
            {
               case "1":
                   $("<%=trSellerId.ClientID%>").style.display=""; 
                   $("<%=trKey.ClientID%>").style.display=""; 
                   $("<%=trAccount.ClientID%>").style.display=""; 
                   $("<%=trTaxis.ClientID%>").style.display=""; 
                   $("<%=trRdlSetup.ClientID%>").style.display=""; 
                   $("<%=trPortType.ClientID%>").style.display="none"; 
                   
               break;
               case "2":
                   $("<%=trSellerId.ClientID%>").style.display=""; 
                   $("<%=trPortType.ClientID%>").style.display="";               
                   $("<%=trKey.ClientID%>").style.display=""; 
                   $("<%=trAccount.ClientID%>").style.display=""; 
                   $("<%=trTaxis.ClientID%>").style.display=""; 
                   $("<%=trRdlSetup.ClientID%>").style.display="";
                   
               break;
               case "3":
                   $("<%=trSellerId.ClientID%>").style.display=""; 
                   $("<%=trKey.ClientID%>").style.display=""; 
                   $("<%=trAccount.ClientID%>").style.display=""; 
                   $("<%=trTaxis.ClientID%>").style.display=""; 
                   $("<%=trRdlSetup.ClientID%>").style.display=""; 
                   $("<%=trPortType.ClientID%>").style.display="none"; 
                   
               break;
               case "4":
                   $("<%=trSellerId.ClientID%>").style.display="none"; 
                   $("<%=trPortType.ClientID%>").style.display="none";               
                   $("<%=trKey.ClientID%>").style.display="none"; 
                   $("<%=trAccount.ClientID%>").style.display="none"; 
                   $("<%=trTaxis.ClientID%>").style.display="none"; 
                   $("<%=trRdlSetup.ClientID%>").style.display="none";
                   
                   $("<%=txtSellerId.ClientID%>").validatetype="ifisfloat";
                   $("<%=txtKey.ClientID%>").validatetype="ifisnull";
                   $("<%=txtAccount.ClientID%>").validatetype="ifisfloat";
                   $("<%=txtTaxis.ClientID%>").validatetype="ifisfloat";
                   
               break;
               case "5":
                   $("<%=trSellerId.ClientID%>").style.display="none"; 
                   $("<%=trPortType.ClientID%>").style.display="none";               
                   $("<%=trKey.ClientID%>").style.display="none"; 
                   $("<%=trAccount.ClientID%>").style.display="none"; 
                   $("<%=trTaxis.ClientID%>").style.display="none"; 
                   $("<%=trRdlSetup.ClientID%>").style.display="none";
                   
                   $("<%=txtSellerId.ClientID%>").validatetype="ifisfloat";
                   $("<%=txtKey.ClientID%>").validatetype="ifisnull";
                   $("<%=txtAccount.ClientID%>").validatetype="ifisfloat";
                   $("<%=txtTaxis.ClientID%>").validatetype="ifisfloat";
               break;
            }
 }
 
 </script>
</asp:Content>
<asp:Content ID="ContEditTitel" runat="server" ContentPlaceHolderID="pagetitle">
支付平台管理
    <asp:HyperLink ID="returnLink" NavigateUrl="paymentmanage_list.aspx" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
    <asp:Button ID="butSave" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>

</asp:Content>
<asp:Content ID="ContEditInfo" runat="server" ContentPlaceHolderID="pageinfo">
添加或编辑支付平台
</asp:Content>
<asp:Content ID="ContEditMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
   <table width="100%" border="0"  cellspacing="1" cellpadding="1" class="form_table_input">
  <tr>
    <td class="form_table_input_info">支付方式名称：</td>
    <td>
        <asp:TextBox ID="txtName" runat="server" MaxLength="30"></asp:TextBox>                         
      </td>
      <td><asp:Panel ID="txtNameTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info">支付方式描述：</td>
    <td>
        <asp:TextBox ID="txtPaymentDesc" runat="server" MaxLength="30" TextMode="MultiLine"></asp:TextBox>                         
      </td>
      <td><asp:Panel ID="txtPaymentDescTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info">支付类型：</td>
    <td>
        <select id="SelPayment" runat="server" onchange="PayType(this)">
        <option value="1" selected>财付通</option>
        <option value="2">支付宝</option>
        <option value="3">网银</option>
        <option value="4">线下支付</option>
        <option value="5">余额支付</option>
        </select>
      </td>
   
  </tr>
  <tr id="trPortType" runat="server" style="display:none;">
    <td class="form_table_input_info">接口类型：</td>
    <td>
       <asp:DropDownList ID="ddlPortType" runat="server">
       <asp:ListItem Value="1" Selected>使用标准双接口</asp:ListItem>
       <asp:ListItem Value="2">使用担保交易接口</asp:ListItem>
       <asp:ListItem Value="3">使用即时到帐交易接口</asp:ListItem>
       </asp:DropDownList>                               
      </td>
     <td></td>
  </tr>
  <tr id="trSellerId" runat="server">
    <td class="form_table_input_info">商 户 ID：</td>
    <td>
        <asp:TextBox ID="txtSellerId" runat="server"></asp:TextBox>                                  
      </td>
     <td><asp:Panel ID="txtSellerIdTip" runat="server"></asp:Panel></td>
  </tr>
  <tr id="trKey" runat="server">
    <td class="form_table_input_info">MD5 密钥：</td>
    <td>
        <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
      </td>
    <td><asp:Panel ID="txtKeyTip" runat="server"></asp:Panel></td>
  </tr>
  <tr id="trAccount" runat="server">
    <td class="form_table_input_info">商户帐户：</td>
    <td>
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
      </td>
     <td><asp:Panel ID="txtAccountTip" runat="server"></asp:Panel></td>
  </tr>
  <tr>
    <td class="form_table_input_info">支付手续费：</td>
    <td>
        <asp:TextBox ID="txtExpenses" runat="server" Width="20%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtExpensesTip" runat="server"></asp:Panel></td>  
  </tr>
  <tr id="trTaxis" runat="server">
    <td class="form_table_input_info">排&nbsp;&nbsp;&nbsp; 序：</td>
    <td>
        <asp:TextBox ID="txtTaxis" runat="server" Width="20%"></asp:TextBox>
    </td>
    <td><asp:Panel ID="txtTaxisTip" runat="server"></asp:Panel></td>
  </tr>
  <tr id="trRdlSetup" runat="server">
    <td class="form_table_input_info">设&nbsp;&nbsp;&nbsp; 置：</td>
    <td>         
         <asp:RadioButtonList ID="RdlSetup" runat="server" RepeatDirection="Horizontal" 
             Enabled="False">
             <asp:ListItem  Text="禁用" Value="1"></asp:ListItem>
             <asp:ListItem Text="默认" Value="0"  Selected="True"></asp:ListItem>
        </asp:RadioButtonList>  
      </td>
   
  </tr>
  
  </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="returnLinkBottom" runat="server" NavigateUrl="paymentmanage_list.aspx"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>