<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="deliver_edit.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.deliver_edit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../scripts/prototype.js"></script>
    
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" language="javascript">
     function AddCity()
        {
            var value=document.getElementById("lblhidden").value;
            
            if(value!="")
            {
                var strs=value.split(",");
                var a1=strs[1];
	            var b1=strs[0];
	            var flage=1;
	            var ct=document.getElementsByName("getid");
	           for(var i=0;i<ct.length;i++)
	           {
	               if(ct[i].value==b1 )
	               {
	                   flage=2;
	               }
	           }
	           if(flage!=2)
	           {
	              document.getElementById("<%=tdArea.ClientID%>").innerHTML +="<input type='checkbox' value='"+b1+"' name='getid' id='chkcountry'  checked='checked' >"+a1+"</input>";
	           }
	        }
        }
    
    function PaymentType(obj,num)
        {
        var paytype = obj;
        
            switch(num)
            {
               case 3:
                if(paytype==1)
                {
                    document.getElementById("<%=trBasicFrees3.ClientID%>").style.display=""; 
                    document.getElementById("<%=trOverweight3.ClientID%>").style.display=""; 
                    document.getElementById("<%=trSingle3.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle3.ClientID%>").validatetype="ifisfloat";

                    $("<%=txtBasicFrees3.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight3.ClientID%>").validatetype="isfloat";
                

                    
                }
                else if(paytype==2)
                {
                   
                    $("<%=trSingle3.ClientID%>").style.display=""; 
                    $("<%=trOverweight3.ClientID%>").style.display="none";
                    $("<%=trBasicFrees3.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees3.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight3.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle3.ClientID%>").validatetype="isfloat";
                }
                break;
               case 6:
                if(paytype==1)
                {
                    $("<%=trBasicFrees6.ClientID%>").style.display=""; 
                    $("<%=trOverweight6.ClientID%>").style.display=""; 
                    $("<%=trSingle6.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle6.ClientID%>").validatetype="ifisfloat";
                    $("<%=trOverweight26.ClientID %>").style.display=""; 
                    $("<%=txtBasicFrees6.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight6.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle6.ClientID%>").style.display=""; 
                    $("<%=trOverweight6.ClientID%>").style.display="none";
                    $("<%=trBasicFrees6.ClientID%>").style.display="none"; 
                    $("<%=trOverweight26.ClientID %>").style.display="none"; 
                     $("<%=txtBasicFrees6.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight6.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle6.ClientID%>").validatetype="isfloat";
                }
                break;
                case 7:
                if(paytype==1)
                {
                    $("<%=trBasicFrees7.ClientID%>").style.display=""; 
                    $("<%=trOverweight7.ClientID%>").style.display="";
                    $("<%=trOverweight27.ClientID%>").style.display="";
                    $("<%=trSingle7.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle7.ClientID%>").validatetype="ifisfloat";
                    $("<%=txtPackagingCosts7.ClientID%>").validatetype="isfloat";
                    $("<%=txtBasicFrees7.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight7.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle7.ClientID%>").style.display=""; 
                    $("<%=trOverweight7.ClientID%>").style.display="none";
                    $("<%=trOverweight27.ClientID%>").style.display="none";
                    $("<%=trBasicFrees7.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees7.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight7.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle7.ClientID%>").validatetype="isfloat";
                }
                break;
                case 8:
                if(paytype==1)
                {
                    $("<%=trBasicFrees8.ClientID%>").style.display=""; 
                    $("<%=trOverweight8.ClientID%>").style.display=""; 
                    $("<%=trSingle8.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle8.ClientID%>").validatetype="ifisfloat";

                    $("<%=txtBasicFrees8.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight8.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle8.ClientID%>").style.display=""; 
                    $("<%=trOverweight8.ClientID%>").style.display="none";
                    $("<%=trBasicFrees8.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees8.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight8.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle8.ClientID%>").validatetype="isfloat";
                }
                break;
                case 9:
                if(paytype==1)
                {
                    $("<%=trBasicFrees9.ClientID%>").style.display=""; 
                    $("<%=trOverweight9.ClientID%>").style.display=""; 
                    $("<%=trSingle9.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle9.ClientID%>").validatetype="ifisfloat";

                    $("<%=txtBasicFrees9.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight9.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle9.ClientID%>").style.display=""; 
                    $("<%=trOverweight9.ClientID%>").style.display="none";
                    $("<%=trBasicFrees9.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees9.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight9.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle9.ClientID%>").validatetype="isfloat";
                }
                break;
                case 10:
                if(paytype==1)
                {
                    $("<%=trBasicFrees10.ClientID%>").style.display=""; 
                    $("<%=trOverweight10.ClientID%>").style.display=""; 
                    $("<%=trSingle10.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle10.ClientID%>").validatetype="ifisfloat";

                    $("<%=txtBasicFrees10.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight10.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle10.ClientID%>").style.display=""; 
                    $("<%=trOverweight10.ClientID%>").style.display="none";
                    $("<%=trBasicFrees10.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees10.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight10.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle10.ClientID%>").validatetype="isfloat";
                }
                break;
                case 11:
                if(paytype==1)
                {
                    $("<%=trBasicFrees11.ClientID%>").style.display=""; 
                    $("<%=trOverweight11.ClientID%>").style.display=""; 
                    $("<%=trSingle11.ClientID%>").style.display="none"; 
                       
                    $("<%=txtSingle11.ClientID%>").validatetype="ifisfloat";

                    $("<%=txtBasicFrees11.ClientID%>").validatetype="isfloat";
                    $("<%=txtOverweight11.ClientID%>").validatetype="isfloat";
                }
                else if(paytype==2)
                {
                    $("<%=trSingle11.ClientID%>").style.display=""; 
                    $("<%=trOverweight11.ClientID%>").style.display="none";
                    $("<%=trBasicFrees11.ClientID%>").style.display="none"; 
                       
                     $("<%=txtBasicFrees11.ClientID%>").validatetype="ifisfloat";
                     $("<%=txtOverweight11.ClientID%>").validatetype="ifisfloat";
                    
                     $("<%=txtSingle11.ClientID%>").validatetype="isfloat";
                }
                break;
            }
        }
    </script>
    <script type="text/javascript" defer="defer">
       
        function ShowMenu(control)
        {
            var y=control.offsetTop; 
            var x=control.offsetLeft; 
             
            objectC=control;
            while(control=control.offsetParent)
            {
                y+=control.offsetTop; 
                x+=control.offsetLeft;
            } 
            $("munelist").style.left=x;
            $("munelist").style.top=y+20;
            $("munelist").style.display="block";
        }
        function HiddenMune(control)
        {
            control.style.display="none";
        }
        
       function Del(id)
       { 
           if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
           {
             var param = "LeaveOption=delleave&id=" + id;
             var options = 
             { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv=="ok")
                     {
                         window.location.href=window.location.href;
                     }
                 }
             }
         }
         else
         {
            return false;
         }
        new Ajax.Request('deliver_edit.aspx', options);
    }
    </script>
    
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
            document.getElementById("thirdClass").innerHTML = "<select size='18' style='width: 150px'></select>";
		}     
	  }
	 var obj=document.getElementById("firstClass");
	 txt=obj.options[obj.selectedIndex].innerText;
	 	document.getElementById("lblhidden").value=id+","+txt;
	new  Ajax.Request('deliver_edit.aspx',options);
}
//选择二级分类后的联动效果
function Secondarry(id) 
{
    var varray=id.split("/");

    var param = "Option=Secondarry&ID="+ varray[0];
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		  document.getElementById("thirdClass").innerHTML = retv;
		  
		}     
	  }
	 document.getElementById("lblhidden").value=varray[0]+","+varray[1];
	new  Ajax.Request('deliver_edit.aspx',options);
}
//选择三级分类后的联动效果
function thirdarry(id) {
var varray=id.split("/");
var param = "Option=thirdarry&ID="+ varray[0];
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {

		}     
	  }
	document.getElementById("lblhidden").value=varray[0]+","+varray[1];
	new  Ajax.Request('deliver_edit.aspx',options);

}
function OptionValue(ClassID) 
{
varray = ClassID.split("/");
    $("<%=hfAreaClassID.ClientID %>").value = varray[0]; //使用隐藏域记录下商品分类ID，以便商品添加时取值
    var param = "Option=Vali&ID="+ varray[0];
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
	new  Ajax.Request('deliver_edit.aspx',options);
}
function NextShow()
{
    var cid= $("<%=hfAreaClassID.ClientID %>").value;
    window.location.href="deliver_edit.aspx?cid="+cid;
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
添加/编辑配送区域[<asp:Label runat="server" ID="txtTitle" />]
    <asp:Button ID="button8" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton"  Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">区域列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
<!--上门取货-->
<div id="tab0" runat="server" class="tabs" style="display:block;">
    
    <table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr align="center">
            <td class="form_table_input_info" align="right">配送区域名称：</td>
            <td  align="left">
                <asp:TextBox ID="txtAreaName1" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName1Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
    <asp:Literal ID="lblsmqhList" runat="server"></asp:Literal>
</div>


<!--城际快递-->
<div id="tab1" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr align="center">
            <td class="form_table_input_info" align="right">配送区域名称：</td>
            <td  align="left">
                <asp:TextBox ID="txtAreaName2" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName2Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">基本费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFees2" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFees2Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount2" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount2Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">货到付款支付费用：</td>
    <td>
        <asp:TextBox ID="txtCODPayFees2" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtCODPayFees2Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblcjkdList" runat="server"></asp:Literal>
</div>

<!--EMS 国内邮政特快专递-->
<div id="tab2" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName3" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName3Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>


        <input type="radio" name="RadioButtonList1" id="rdtype1" onclick="PaymentType(1,3)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList1" id="rdtype2" onclick="PaymentType(2,3)" value="2" runat="server" />按商品件数计算
    </td> 
    <td></td>  
  </tr>
        <tr id="trBasicFrees3" runat="server" style="display:">
            <td class="form_table_input_info">500克以内费用：</td>
            <td>
                <asp:TextBox ID="txtBasicFrees3" runat="server"  Width="60%"></asp:TextBox>
            </td> 
            <td><asp:Panel ID="txtBasicFrees3Tip" runat="server"></asp:Panel></td>  
          </tr>
          <tr runat="server" id="trOverweight3" style="display:">
            <td class="form_table_input_info">续重每500克或其零数的费用：</td>
            <td>
                <asp:TextBox ID="txtOverweight3" runat="server" Width="60%"></asp:TextBox>
            </td> 
            <td><asp:Panel ID="txtOverweight3Tip" runat="server"></asp:Panel></td>  
          </tr>
              <tr  id="trSingle3" runat="server" style="display:none;">
                        <td class="form_table_input_info">单件商品费用：</td>
                        <td>
                            <asp:TextBox ID="txtSingle3" runat="server" Width="60%"></asp:TextBox>
                        </td> 
                        <td><asp:Panel ID="txtSingle3Tip" runat="server"></asp:Panel></td>  
                      </tr>
        
  
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount3" runat="server" Width="60%"></asp:TextBox> 
    </td> 
    <td><asp:Panel ID="txtFreeAmount3Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblEMSList" runat="server"></asp:Literal>
</div>

<!--市内快递-->
<div id="tab3" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName4" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName4Tip" runat="server"></asp:Panel></td>
        </tr>        
        <tr>
    <td class="form_table_input_info">基本费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees4" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees4Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount4" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount4Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">货到付款支付费用：</td>
    <td>
        <asp:TextBox ID="txtCODPayFees4" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtCODPayFees4Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblsnkdList" runat="server"></asp:Literal>

</div>
<!--运费到付-->
<div id="tab4" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName5" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName5Tip" runat="server"></asp:Panel></td>
        </tr>        
        <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount5" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount5Tip" runat="server"></asp:Panel></td>  
  </tr>
   <tr><td style=" height:10px;" colspan=3></td></tr>
 </table>
   <asp:Literal ID="lblyfdfList" runat="server"></asp:Literal>

</div>
<!--邮政快递包裹-->
<div id="tab5" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName6" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName6Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
        <input type="radio" name="RadioButtonList2" id="rdtype3" onclick="PaymentType(1,6)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList2" id="rdtype4" onclick="PaymentType(2,6)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees6">
    <td class="form_table_input_info">1000克以内费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees6" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees6Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight6">
    <td class="form_table_input_info">5000克以内续重每500克费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight6" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight6Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight26">
    <td class="form_table_input_info">5001克以上续重500克费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight26" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td>&nbsp;</td>  
  </tr>
  <tr runat="server" id="trSingle6" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle6" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle6Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount6" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount6Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblyzkdbgList" runat="server"></asp:Literal>

</div>
<!--邮局平邮-->
<div id="tab6" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" 

bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName7" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName7Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
       <input type="radio" name="RadioButtonList3" id="rdtype5" onclick="PaymentType(1,7)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList3" id="rdtype6" onclick="PaymentType(2,7)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees7">
    <td class="form_table_input_info">1000克以内费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees7" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees7Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight7">
    <td class="form_table_input_info">5000克以内续重每1000克费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight7" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight7Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight27">
    <td class="form_table_input_info">5001克以上续重1000克费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight27" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td>&nbsp;</td>  
  </tr>
  <tr runat="server" id="trSingle7" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle7" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle7Tip" runat="server"></asp:Panel></td>  
  </tr>
<tr>
    <td class="form_table_input_info">包装费用：</td>
    <td>
        <asp:TextBox ID="txtPackagingCosts7" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtPackagingCosts7Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount7" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount7Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblyjpyList" runat="server"></asp:Literal>

</div>
<!--顺风速运-->
<div id="tab7" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" 

bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName8" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName8Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
       <input type="radio" name="RadioButtonList4" id="rdtype7" onclick="PaymentType(1,8)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList4" id="rdtype8" onclick="PaymentType(2,8)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees8">
    <td class="form_table_input_info">1000克以内费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees8" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees8Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight8">
    <td class="form_table_input_info">续重每1000克或其零数的费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight8" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight8Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trSingle8" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle8" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle8Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount8" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount8Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblsfsdList" runat="server"></asp:Literal>

</div>
<!--申通快递-->
<div id="tab8" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" 

bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName9" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName9Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
        <input type="radio" name="RadioButtonList5" id="rdtype9" onclick="PaymentType(1,9)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList5" id="rdtype10" onclick="PaymentType(2,9)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees9">
    <td class="form_table_input_info">1000克以内费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees9" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees9Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight9">
    <td class="form_table_input_info">续重每1000克或其零数的费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight9" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight9Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trSingle9" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle9" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle9Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount9" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount9Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblstkdList" runat="server"></asp:Literal>

</div>
<!--圆通速递-->
<div id="tab9" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD"   

bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName10" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName10Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
       <input type="radio" name="RadioButtonList6" id="rdtype11" onclick="PaymentType(1,10)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList6" id="rdtype12" onclick="PaymentType(2,10)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees10">
    <td class="form_table_input_info">首重费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees10" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees10Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight10">
    <td class="form_table_input_info">续重费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight10" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight10Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trSingle10" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle10" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle10Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount10" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount10Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">货到付款支付费用：</td>
    <td>
        <asp:TextBox ID="txtCODPayFees10" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtCODPayFees10Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblytsdList" runat="server"></asp:Literal>

</div>

<!--中通快递-->
<div id="tab10" class="tabs" runat="server">
<table width="100%"  cellspacing="0" cellpadding="0" border="0" bordercolorlight="#DDDDDD" 

bordercolordark="#FFFFFF" class="form_table_input">
        <tr><td style=" height:10px;" colspan=3></td></tr>
        <tr>
            <td class="form_table_input_info">配送区域名称：</td>
            <td>
                <asp:TextBox ID="txtAreaName11" runat="server" Width="261px"></asp:TextBox>
            </td>
           <td><asp:Panel ID="txtAreaName11Tip" runat="server"></asp:Panel></td>
        </tr>
        <tr>
    <td class="form_table_input_info">费用计算方式：</td>
    <td>
        <input type="radio" name="RadioButtonList5" id="rdtype13" onclick="PaymentType(1,11)" value="1" runat="server"  checked/>按重量计算
        <input type="radio" name="RadioButtonList5" id="rdtype14" onclick="PaymentType(2,11)" value="2" runat="server" />按商品件数计算
        
    </td> 
    <td></td>  
  </tr>
        <tr runat="server" id="trBasicFrees11">
    <td class="form_table_input_info">首重费用：</td>
    <td>
        <asp:TextBox ID="txtBasicFrees11" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtBasicFrees11Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trOverweight11">
    <td class="form_table_input_info">续重每1000克或其零数的费用：</td>
    <td>
        <asp:TextBox ID="txtOverweight11" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtOverweight11Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr runat="server" id="trSingle11" style="display:none;">
    <td class="form_table_input_info">单件商品费用：</td>
    <td>
        <asp:TextBox ID="txtSingle11" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtSingle11Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr>
    <td class="form_table_input_info">免费额度：</td>
    <td>
        <asp:TextBox ID="txtFreeAmount11" runat="server" Width="60%"></asp:TextBox>
    </td> 
    <td><asp:Panel ID="txtFreeAmount11Tip" runat="server"></asp:Panel></td>  
  </tr>
  <tr><td style=" height:10px;" colspan=3></td></tr>
    </table>
   <asp:Literal ID="lblztdList" runat="server"></asp:Literal>

</div>
  

</td>
</tr>
</table>
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
             <tr>
                 <td style="text-align:left;padding-right: 10px;color: #0099FF;font-weight: bold; width:200px;" colspan=7>所辖地区：<asp:HiddenField ID="hfAreaClassID" runat="server" />
                 <label visible="false" id="lblhidden"></label></td>
                 
                 <td ><input type="hidden" value="0" id="hiddenvalue" /></td>
             </tr>
             <tr><td id="tdArea" colspan=9 runat="server"></td></tr>
             <tr>
             <td valign=top><label  style=" white-space:nowrap;">国家：</label></td>
                 <td style="width: 22%; text-align: center">
                    <div>
                        <select size=18 style=" width:150px;"><option selected>中国</option></select>
                    </div>
                </td>
             <td valign=top><label  style=" white-space:nowrap;">省份：</label></td>
                
                <td style="width: 22%; text-align: center">
                    <div>
                        <asp:Literal ID="lrafirstClass" runat="server"></asp:Literal>
                    </div>
                </td>
             <td valign=top><label  style=" white-space:nowrap;">城市：</label></td>
                
                <td style="width: 22%; text-align: center">
                    <div id="secondClass">
                        <select size="18" style="width: 150px">
                        </select>
                    </div>
                </td>
             <td valign=top><label  style=" white-space:nowrap;">区/县：</label></td>
                
                <td style="width: 22%; text-align: center">
                    <div id="thirdClass">
                        <select size="18" style="width: 150px">
                        </select>
                    </div>
                </td>
                <td align="left" valign="top">
                    <input id="addcity" value="+" type="button" 
                        onclick="javascript:AddCity();" style=" width:31px;" /></td>
             </tr>
        </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button7" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="area_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">区域列表</asp:HyperLink>
</asp:Content>