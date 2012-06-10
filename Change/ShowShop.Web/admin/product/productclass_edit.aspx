<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="productclass_edit.aspx.cs" Inherits="ShowShop.Web.admin.product.productclass_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/dtree.css" type="text/css" />
    <script type="text/javascript" src="../scripts/dtree.js"></script>
    <script type="text/javascript">
        var filelist=new Array();
        var objectC;
        function GetFile(control)
        {
            var y=control.offsetTop; 
            var x=control.offsetLeft; 
             
            objectC=control;
            while(control=control.offsetParent)
            {
                y+=control.offsetTop; 
                x+=control.offsetLeft;
            } 
            obj=$("fileLists");
            obj.style.visibility="visible";
            obj.style.left=x;
            obj.style.top=y+22;
        }
        function GetFileUrl(value)
        {
            objectC.value=value;
            $("fileLists").style.visibility="hidden";
        }
        function divfalse()
        {
          document.getElementById("fileLists").style.display="none";
        }
        
    </script>
    <style type="text/css">
    #fileLists
    {
    	height:200px;
	    width:247px;
	    overflow:auto;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品分类
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加或编辑商品分类&nbsp; 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
     <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
             <td class="form_table_input_info">所属分类：</td>
             <td>
                 <asp:DropDownList ID="ddlTheirclass" runat="server">
                 </asp:DropDownList>
                 <asp:HiddenField ID="hffatherid" runat="server" />
                 <asp:HiddenField ID="hfparentpath" runat="server" />
             </td>
         </tr>
   
         <tr>
		    <td class="form_table_input_info">分类名称：
            </td>
		    <td>
                <asp:TextBox ID="txtName" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtNameTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>
	  
	    <tr>
		    <td class="form_table_input_info">描述：
            </td>
		    <td>
                <asp:TextBox ID="txtDescription"  TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
		    <td>
                <div class="msgNormal">填写描述</div>
            </td>
	    </tr>
        <tr>
		    <td class="form_table_input_info">排列顺序：
            </td>
		    <td>
                <asp:TextBox ID="txtSort" CssClass="short_input" runat="server"></asp:TextBox>
            </td>
		    <td>
                <asp:Panel ID="txtSortTip" runat="server">
                </asp:Panel>
            </td>
	    </tr>

    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="buttonSave" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="returnLinkBottom" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>