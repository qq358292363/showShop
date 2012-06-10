<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="productstepone_edit.aspx.cs" Inherits="ShowShop.Web.admin.product.productstepone_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script language="javascript" type="text/javascript">
    //选择一级分类后的联动效果
function firstarry(id)
 {
    var param = "Option=first&ID="+ id;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	        var retv=transport.responseText;
		    document.getElementById("secondClass").innerHTML = retv;
            document.getElementById("thirdClass").innerHTML = "<select size='18' style='width: 180px'></select>";
            document.getElementById("fourClass").innerHTML = "<select size='18' style='width: 180px'></select>";
		}     
	  }
	new  Ajax.Request('product_edit.aspx',options);
}
//选择二级分类后的联动效果
function Secondarry(id) 
{
    var param = "Option=Secondarry&ID="+ id;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		  document.getElementById("thirdClass").innerHTML = retv;
          document.getElementById("fourClass").innerHTML = "<select size='18' style='width: 180px'></select>";
		}     
	  }
	new  Ajax.Request('product_edit.aspx',options);
}
//选择三级分类后的联动效果
function thirdarry(id) {
var param = "Option=thirdarry&ID="+ id;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		 document.getElementById("fourClass").innerHTML = retv;
		}     
	  }
	new  Ajax.Request('product_edit.aspx',options);
}
function OptionValue(ClassID) 
{
    $("<%=hfProductClassID.ClientID %>").value = ClassID; //使用隐藏域记录下商品分类ID，以便商品添加时取值
    var param = "Option=Vali&ID="+ ClassID;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
              var retv=transport.responseText;
              if (retv == "false") 
              {
                  document.getElementById("butNext").disabled = false;
              }
              else 
              {
                  document.getElementById("butNext").disabled =true;
              }
		}     
	  }
	new  Ajax.Request('product_edit.aspx',options);
}
function NextShow()
{
    var cid= $("<%=hfProductClassID.ClientID %>").value;
    window.location.href="product_edit.aspx?cid="+cid;
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">商品编辑
    <asp:HyperLink ID="returnLinkBottom" runat="server" NavigateUrl="product_list.aspx" Text="返回列表"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"></asp:HyperLink>
    <input ID="butNext" type="button" value="下一步"  Class="inputbutton" onclick="NextShow()" disabled="false"  onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加或编辑商品
    请选择商品分类
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
         <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
             <tr>
                 <td style="text-align:left;padding-right: 10px;color: #0099FF;font-weight: bold;" colspan="4">请选择商品分类：<asp:HiddenField ID="hfProductClassID" runat="server" />
                 </td>
             </tr>
             <tr>
                 <td style="width: 25%; text-align: center">
                    <div>
                        <asp:Literal ID="lrafirstClass" runat="server"></asp:Literal>
                    </div>
                </td>
                    <td>
                    <div id="secondClass">
                        <select size="18" style="width: 180px">
                        </select>
                    </div>
                </td>
                <td style="width: 25%; text-align: center">
                    <div id="thirdClass">
                        <select size="18" style="width: 180px">
                        </select>
                    </div>
                </td>
                <td style="width: 25%; text-align: center">
                    <div id="fourClass">
                        <select size="18" style="width: 180px">
                        </select>
                    </div>
                </td>
             </tr>
        </table>
</asp:Content>