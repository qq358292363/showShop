<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_page.master" CodeBehind="deliver_edite.aspx.cs" Inherits="ShowShop.Web.admin.product.deliver_edite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/images.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function delItem(str){
            var tr1=document.getElementById("<%=tr1.ClientID %>");
            var tr2=document.getElementById("<%=tr2.ClientID %>");
            var tr3=document.getElementById("<%=tr3.ClientID %>");
            if(str=="1"){
                tr1.style.display="none";
            }
            if(str=="2"){
                tr2.style.display="none";
            }
            if(str=="3"){
                tr3.style.display="none";
            }
        }
        
        function addItem(str){
            var tr1=document.getElementById("<%=tr1.ClientID %>");
            var tr2=document.getElementById("<%=tr2.ClientID %>");
            var tr3=document.getElementById("<%=tr3.ClientID %>");
            if(str=="1"){
                tr1.style.display="block";
            }
            if(str=="2"){
                tr2.style.display="block";
            }
            if(str=="3"){
                tr3.style.display="block";
            }
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
添加/编辑送货方式
    <asp:Button ID="button8" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="deliver_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">配送方式名称：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
        </td>
        <td>
            <asp:Panel ID="txtNameTip" runat="server"></asp:Panel>
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">价格：</td>
        <td>
           <asp:TextBox ID="txtInceptPrice" runat="server" Width="50" MaxLength="10" CssClass="long_input"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtInceptPriceTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">重量：</td>
        <td>
           <asp:TextBox ID="txtInceptWeight" runat="server" Width="50" MaxLength="10"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtInceptWeightTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">送货加价幅度：</td>
        <td>
           <asp:TextBox ID="txtAddPricelAdder" runat="server" Width="50" MaxLength="10"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtAddPricelAdderTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">重量加价幅度：</td>
        <td>
           <asp:TextBox ID="txtAddWeightlAdder" runat="server" Width="50" MaxLength="10"></asp:TextBox>             
        </td>
        <td>
           <asp:Panel ID="txtAddWeightlAdderTip" runat="server"></asp:Panel>   
        </td>
    </tr>
    
    <tr>
        <td class="form_table_input_info">范围价格：</td>
        <td>
           重量下限：<asp:TextBox ID="txtBoundU1" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp;
           上限：<asp:TextBox ID="txtBoundD1" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp; 
           价格：<asp:TextBox ID="txtBoundP1" Width="30" runat="server" MaxLength="50"></asp:TextBox>
           <input id="Button2" type="button" value="+" onclick="addItem(1)" />            
        </td>
        <td> 
           <div class="msgNormal">例如1到10千克，10到100千克<br />20,100.01,500<br />表示100千克以下20元</div>     
        </td>
    </tr>
    
    <tr runat="server" id="tr1">
        <td class="form_table_input_info"></td>
        <td>
           重量下限：<asp:TextBox ID="txtBoundU2" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp;
           上限：<asp:TextBox ID="txtBoundD2" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp; 
           价格：<asp:TextBox ID="txtBoundP2" Width="30" runat="server" MaxLength="50"></asp:TextBox>
           <input id="Button1" type="button" value="-" onclick="delItem(1)" />
           <input id="Button5" type="button" value="+" onclick="addItem(2)" />         
        </td>
        <td>
            <div class="msgNormal">删除前请清空该行内容</div>      
        </td>
    </tr>
    
    <tr  runat="server" id="tr2">
        <td class="form_table_input_info"></td>
        <td>
           重量下限：<asp:TextBox ID="txtBoundU3" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp;
           上限：<asp:TextBox ID="txtBoundD3" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp; 
           价格：<asp:TextBox ID="txtBoundP3" Width="30" runat="server" MaxLength="50"></asp:TextBox>
           <input id="Button3" type="button" value="-" onclick="delItem(2)" />
           <input id="Button6" type="button" value="+" onclick="addItem(3)" />               
        </td>
        <td>
            <div class="msgNormal">删除前请清空该行内容</div>    
        </td>
    </tr>
    
    <tr  runat="server" id="tr3">
        <td class="form_table_input_info"></td>
        <td>
           重量下限：<asp:TextBox ID="txtBoundU4" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp;
           上限：<asp:TextBox ID="txtBoundD4" Width="30" runat="server" MaxLength="50"></asp:TextBox>&nbsp; 
           价格：<asp:TextBox ID="txtBoundP4" Width="30" runat="server" MaxLength="50"></asp:TextBox>
           <input id="Button4" type="button" value="-" onclick="delItem(3)" />            
        </td>
        <td>
            <div class="msgNormal">删除前请清空该行内容</div> 
        </td>
    </tr>
     
     <tr>
       <td class="form_table_input_info">货到付款：</td>
       <td>
           <asp:RadioButtonList ID="rblArrivePay" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Text="允许" Selected="True"></asp:ListItem>
                 <asp:ListItem Value="0" Text="不允许"></asp:ListItem>
             </asp:RadioButtonList>
       </td>
       <td>
           <div class="msgNormal">选择是否货到付款</div>
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">是否范围价格：</td>
       <td>
           <asp:RadioButtonList ID="rblIsSpecial" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Text="允许" Selected="True"></asp:ListItem>
                 <asp:ListItem Value="0" Text="不允许"></asp:ListItem>
             </asp:RadioButtonList>
       </td>
       <td>
           <div class="msgNormal">选择是否范围价格</div>
       </td>
    </tr>
    
    <tr>
       <td class="form_table_input_info">是否启用：</td>
       <td>
           <asp:RadioButtonList ID="rblisused" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Text="允许" Selected="True"></asp:ListItem>
                 <asp:ListItem Value="0" Text="不允许"></asp:ListItem>
             </asp:RadioButtonList>
       </td>
       <td>
           <div class="msgNormal">选择是否启用该送货方式</div>
       </td>
    </tr>
    
     <tr>
       <td class="form_table_input_info">配送方式描述：</td>
       <td>
           <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" 
               Width="243px"  MaxLength="480" Height="92px"></asp:TextBox>
       </td>
       <td>
           <asp:Panel ID="txtDescriptionTip" runat="server"></asp:Panel>
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
    <asp:Button ID="button7" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="deliver_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>